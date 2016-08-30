<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAdjustmentFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockAdjustmentFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbStockAdjustment = New System.Windows.Forms.TabControl()
        Me.tbpgAdd = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblOldCOACode = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblOldCOA = New System.Windows.Forms.Label()
        Me.lblPartNoDesc = New System.Windows.Forms.Label()
        Me.lblAvailableDesc = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.lblPartNo = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblAvailableQty = New System.Windows.Forms.Label()
        Me.rdbtnDecrease = New System.Windows.Forms.RadioButton()
        Me.rdbtnIncrease = New System.Windows.Forms.RadioButton()
        Me.lblAccountDesc = New System.Windows.Forms.Label()
        Me.lblT4Name = New System.Windows.Forms.Label()
        Me.lblT3Name = New System.Windows.Forms.Label()
        Me.lblT2Name = New System.Windows.Forms.Label()
        Me.lblT1Name = New System.Windows.Forms.Label()
        Me.lblT0Name = New System.Windows.Forms.Label()
        Me.btnSearchT4 = New System.Windows.Forms.Button()
        Me.btnSearchT3 = New System.Windows.Forms.Button()
        Me.btnSearchT2 = New System.Windows.Forms.Button()
        Me.btnSearchT1 = New System.Windows.Forms.Button()
        Me.btnSearchT0 = New System.Windows.Forms.Button()
        Me.txtT4 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.lblT4 = New System.Windows.Forms.Label()
        Me.txtT3 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.lblT3 = New System.Windows.Forms.Label()
        Me.txtT2 = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblT2 = New System.Windows.Forms.Label()
        Me.txtT1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblT1 = New System.Windows.Forms.Label()
        Me.txtT0 = New System.Windows.Forms.TextBox()
        Me.btnSearchAcCode = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtAccountCode = New System.Windows.Forms.TextBox()
        Me.lblAccountCode = New System.Windows.Forms.Label()
        Me.lblT0 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblAdjustmentUnit = New System.Windows.Forms.Label()
        Me.txtAdjValue = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblAdjValue = New System.Windows.Forms.Label()
        Me.txtAdjQty = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblAdjQty = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.btnSearchStockCode = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtStockCode = New System.Windows.Forms.TextBox()
        Me.lblStockCode = New System.Windows.Forms.Label()
        Me.lblStockDescription = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSearchSubBlock = New System.Windows.Forms.Button()
        Me.lblYOPName = New System.Windows.Forms.Label()
        Me.lblDivName = New System.Windows.Forms.Label()
        Me.txtSubBlock = New System.Windows.Forms.TextBox()
        Me.txtDiv = New System.Windows.Forms.TextBox()
        Me.txtYOP = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblSubBlock = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblDIV = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblYOP = New System.Windows.Forms.Label()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvAdjustDetails = New System.Windows.Forms.DataGridView()
        Me.STAStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAStockDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAvailableQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAdjustVal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAdjQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAUnit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAccountCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAccountDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAOldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAdjustmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAdjustmentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STARemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STASubBlock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STADivDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STASTAdjustmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT0Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT1Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT2Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT3Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT4Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAAccountID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STACategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAVarianceCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAdjust = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.STADIV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAYOP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAYOPName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STARejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STACOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STADIVID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STABlockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT0Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT1Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT2Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT3Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAT4Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STAStockCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STASTDPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsSTAAddEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DelToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnResetIB = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpApproval = New System.Windows.Forms.GroupBox()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.txtRejectedReason = New System.Windows.Forms.TextBox()
        Me.lblRejectedReason = New System.Windows.Forms.Label()
        Me.lblApprovalStatus = New System.Windows.Forms.Label()
        Me.grpRGN = New System.Windows.Forms.GroupBox()
        Me.txtBeritaAcaraAudit = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblRejReasonColon = New System.Windows.Forms.Label()
        Me.lblRejectedReasonValue = New System.Windows.Forms.Label()
        Me.lblRejectedReason1 = New System.Windows.Forms.Label()
        Me.txtRemarks = New System.Windows.Forms.TextBox()
        Me.txtAdjustmentNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpAdjustmentDate = New System.Windows.Forms.DateTimePicker()
        Me.lblAdjustmentStatus = New System.Windows.Forms.Label()
        Me.lblAdjustmentDate = New System.Windows.Forms.Label()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.lblAdjustmentNo = New System.Windows.Forms.Label()
        Me.tbSAView = New System.Windows.Forms.TabPage()
        Me.lblView = New System.Windows.Forms.Label()
        Me.dgvAdjustmentView = New System.Windows.Forms.DataGridView()
        Me.gvAdjustmentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvAdjustmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvEstate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvAdjQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvAdjValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclStockId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvRejectedReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvCOAID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvYOPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvDIVID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvBlockID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvT0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvT1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvT2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvT3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvT4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvSTAdjustmentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStockCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnlSearch = New Stepi.UI.ExtendedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.cmbAdjustViewStatus = New System.Windows.Forms.ComboBox()
        Me.lblViewStatus = New System.Windows.Forms.Label()
        Me.chkAdjustDate = New System.Windows.Forms.CheckBox()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.dtpAdjustmentViewDate = New System.Windows.Forms.DateTimePicker()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtAdjusViewtNo = New System.Windows.Forms.TextBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.lblAdjSearchNo = New System.Windows.Forms.Label()
        Me.btnAdjustSearch = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbStatusSearch = New System.Windows.Forms.ComboBox()
        Me.lblStatusSearch = New System.Windows.Forms.Label()
        Me.chkViewSIVDate = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtSIVDateSearch = New System.Windows.Forms.DateTimePicker()
        Me.txtSIVNoSearch = New System.Windows.Forms.TextBox()
        Me.txtContractNoSearch = New System.Windows.Forms.TextBox()
        Me.lblSearchBy = New System.Windows.Forms.Label()
        Me.lblContractNoSearch = New System.Windows.Forms.Label()
        Me.lblSIVNoSerach = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnViewReport = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tbStockAdjustment.SuspendLayout()
        Me.tbpgAdd.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAdjustDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAdjust.SuspendLayout()
        Me.cmsSTAAddEdit.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpApproval.SuspendLayout()
        Me.grpRGN.SuspendLayout()
        Me.tbSAView.SuspendLayout()
        CType(Me.dgvAdjustmentView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlSearch.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbStockAdjustment
        '
        Me.tbStockAdjustment.Controls.Add(Me.tbpgAdd)
        Me.tbStockAdjustment.Controls.Add(Me.tbSAView)
        Me.tbStockAdjustment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbStockAdjustment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStockAdjustment.Location = New System.Drawing.Point(0, 0)
        Me.tbStockAdjustment.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbStockAdjustment.Name = "tbStockAdjustment"
        Me.tbStockAdjustment.SelectedIndex = 0
        Me.tbStockAdjustment.Size = New System.Drawing.Size(1704, 1009)
        Me.tbStockAdjustment.TabIndex = 0
        '
        'tbpgAdd
        '
        Me.tbpgAdd.AutoScroll = True
        Me.tbpgAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbpgAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbpgAdd.Controls.Add(Me.GroupBox2)
        Me.tbpgAdd.Controls.Add(Me.btnSearchSubBlock)
        Me.tbpgAdd.Controls.Add(Me.lblYOPName)
        Me.tbpgAdd.Controls.Add(Me.lblDivName)
        Me.tbpgAdd.Controls.Add(Me.txtSubBlock)
        Me.tbpgAdd.Controls.Add(Me.txtDiv)
        Me.tbpgAdd.Controls.Add(Me.txtYOP)
        Me.tbpgAdd.Controls.Add(Me.Label19)
        Me.tbpgAdd.Controls.Add(Me.lblSubBlock)
        Me.tbpgAdd.Controls.Add(Me.Label22)
        Me.tbpgAdd.Controls.Add(Me.lblDIV)
        Me.tbpgAdd.Controls.Add(Me.Label24)
        Me.tbpgAdd.Controls.Add(Me.lblYOP)
        Me.tbpgAdd.Controls.Add(Me.btnResetAll)
        Me.tbpgAdd.Controls.Add(Me.btnSaveAll)
        Me.tbpgAdd.Controls.Add(Me.btnClose)
        Me.tbpgAdd.Controls.Add(Me.dgvAdjustDetails)
        Me.tbpgAdd.Controls.Add(Me.GroupBox4)
        Me.tbpgAdd.Controls.Add(Me.grpApproval)
        Me.tbpgAdd.Controls.Add(Me.grpRGN)
        Me.tbpgAdd.Location = New System.Drawing.Point(4, 29)
        Me.tbpgAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpgAdd.Name = "tbpgAdd"
        Me.tbpgAdd.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbpgAdd.Size = New System.Drawing.Size(1696, 976)
        Me.tbpgAdd.TabIndex = 0
        Me.tbpgAdd.Text = "Stock Adjustment"
        Me.tbpgAdd.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.lblOldCOACode)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.lblOldCOA)
        Me.GroupBox2.Controls.Add(Me.lblPartNoDesc)
        Me.GroupBox2.Controls.Add(Me.lblAvailableDesc)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.lblPartNo)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.lblAvailableQty)
        Me.GroupBox2.Controls.Add(Me.rdbtnDecrease)
        Me.GroupBox2.Controls.Add(Me.rdbtnIncrease)
        Me.GroupBox2.Controls.Add(Me.lblAccountDesc)
        Me.GroupBox2.Controls.Add(Me.lblT4Name)
        Me.GroupBox2.Controls.Add(Me.lblT3Name)
        Me.GroupBox2.Controls.Add(Me.lblT2Name)
        Me.GroupBox2.Controls.Add(Me.lblT1Name)
        Me.GroupBox2.Controls.Add(Me.lblT0Name)
        Me.GroupBox2.Controls.Add(Me.btnSearchT4)
        Me.GroupBox2.Controls.Add(Me.btnSearchT3)
        Me.GroupBox2.Controls.Add(Me.btnSearchT2)
        Me.GroupBox2.Controls.Add(Me.btnSearchT1)
        Me.GroupBox2.Controls.Add(Me.btnSearchT0)
        Me.GroupBox2.Controls.Add(Me.txtT4)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.lblT4)
        Me.GroupBox2.Controls.Add(Me.txtT3)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.lblT3)
        Me.GroupBox2.Controls.Add(Me.txtT2)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.lblT2)
        Me.GroupBox2.Controls.Add(Me.txtT1)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.lblT1)
        Me.GroupBox2.Controls.Add(Me.txtT0)
        Me.GroupBox2.Controls.Add(Me.btnSearchAcCode)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.txtAccountCode)
        Me.GroupBox2.Controls.Add(Me.lblAccountCode)
        Me.GroupBox2.Controls.Add(Me.lblT0)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.lblUnit)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.lblAdjustmentUnit)
        Me.GroupBox2.Controls.Add(Me.txtAdjValue)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.lblAdjValue)
        Me.GroupBox2.Controls.Add(Me.txtAdjQty)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblAdjQty)
        Me.GroupBox2.Controls.Add(Me.lblDescription)
        Me.GroupBox2.Controls.Add(Me.btnSearchStockCode)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtStockCode)
        Me.GroupBox2.Controls.Add(Me.lblStockCode)
        Me.GroupBox2.Controls.Add(Me.lblStockDescription)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 206)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(1388, 403)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock Details"
        '
        'lblOldCOACode
        '
        Me.lblOldCOACode.AutoSize = True
        Me.lblOldCOACode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldCOACode.ForeColor = System.Drawing.Color.Blue
        Me.lblOldCOACode.Location = New System.Drawing.Point(246, 329)
        Me.lblOldCOACode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOldCOACode.Name = "lblOldCOACode"
        Me.lblOldCOACode.Size = New System.Drawing.Size(0, 20)
        Me.lblOldCOACode.TabIndex = 323
        Me.lblOldCOACode.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(198, 329)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 20)
        Me.Label28.TabIndex = 322
        Me.Label28.Text = ":"
        Me.Label28.Visible = False
        '
        'lblOldCOA
        '
        Me.lblOldCOA.AutoSize = True
        Me.lblOldCOA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldCOA.Location = New System.Drawing.Point(24, 329)
        Me.lblOldCOA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOldCOA.Name = "lblOldCOA"
        Me.lblOldCOA.Size = New System.Drawing.Size(81, 20)
        Me.lblOldCOA.TabIndex = 321
        Me.lblOldCOA.Text = "Old COA"
        Me.lblOldCOA.Visible = False
        '
        'lblPartNoDesc
        '
        Me.lblPartNoDesc.AutoSize = True
        Me.lblPartNoDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNoDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblPartNoDesc.Location = New System.Drawing.Point(248, 197)
        Me.lblPartNoDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPartNoDesc.Name = "lblPartNoDesc"
        Me.lblPartNoDesc.Size = New System.Drawing.Size(0, 20)
        Me.lblPartNoDesc.TabIndex = 263
        '
        'lblAvailableDesc
        '
        Me.lblAvailableDesc.AutoSize = True
        Me.lblAvailableDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblAvailableDesc.Location = New System.Drawing.Point(248, 152)
        Me.lblAvailableDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvailableDesc.Name = "lblAvailableDesc"
        Me.lblAvailableDesc.Size = New System.Drawing.Size(0, 20)
        Me.lblAvailableDesc.TabIndex = 262
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(201, 197)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(16, 20)
        Me.Label38.TabIndex = 261
        Me.Label38.Text = ":"
        '
        'lblPartNo
        '
        Me.lblPartNo.AutoSize = True
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.Location = New System.Drawing.Point(27, 197)
        Me.lblPartNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(72, 20)
        Me.lblPartNo.TabIndex = 260
        Me.lblPartNo.Text = "Part No"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(201, 152)
        Me.Label34.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(16, 20)
        Me.Label34.TabIndex = 258
        Me.Label34.Text = ":"
        '
        'lblAvailableQty
        '
        Me.lblAvailableQty.AutoSize = True
        Me.lblAvailableQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvailableQty.Location = New System.Drawing.Point(27, 152)
        Me.lblAvailableQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAvailableQty.Name = "lblAvailableQty"
        Me.lblAvailableQty.Size = New System.Drawing.Size(123, 20)
        Me.lblAvailableQty.TabIndex = 257
        Me.lblAvailableQty.Text = "Available Qty"
        '
        'rdbtnDecrease
        '
        Me.rdbtnDecrease.AutoSize = True
        Me.rdbtnDecrease.Location = New System.Drawing.Point(837, 42)
        Me.rdbtnDecrease.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdbtnDecrease.Name = "rdbtnDecrease"
        Me.rdbtnDecrease.Size = New System.Drawing.Size(148, 24)
        Me.rdbtnDecrease.TabIndex = 11
        Me.rdbtnDecrease.TabStop = True
        Me.rdbtnDecrease.Text = "Decrease Qty"
        Me.rdbtnDecrease.UseVisualStyleBackColor = True
        '
        'rdbtnIncrease
        '
        Me.rdbtnIncrease.AutoSize = True
        Me.rdbtnIncrease.Location = New System.Drawing.Point(651, 40)
        Me.rdbtnIncrease.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdbtnIncrease.Name = "rdbtnIncrease"
        Me.rdbtnIncrease.Size = New System.Drawing.Size(144, 24)
        Me.rdbtnIncrease.TabIndex = 10
        Me.rdbtnIncrease.TabStop = True
        Me.rdbtnIncrease.Text = "Increase Qty"
        Me.rdbtnIncrease.UseVisualStyleBackColor = True
        '
        'lblAccountDesc
        '
        Me.lblAccountDesc.ForeColor = System.Drawing.Color.Blue
        Me.lblAccountDesc.Location = New System.Drawing.Point(507, 286)
        Me.lblAccountDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAccountDesc.Name = "lblAccountDesc"
        Me.lblAccountDesc.Size = New System.Drawing.Size(129, 88)
        Me.lblAccountDesc.TabIndex = 254
        '
        'lblT4Name
        '
        Me.lblT4Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT4Name.Location = New System.Drawing.Point(1100, 309)
        Me.lblT4Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT4Name.Name = "lblT4Name"
        Me.lblT4Name.Size = New System.Drawing.Size(284, 40)
        Me.lblT4Name.TabIndex = 253
        Me.lblT4Name.Visible = False
        '
        'lblT3Name
        '
        Me.lblT3Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT3Name.Location = New System.Drawing.Point(1095, 271)
        Me.lblT3Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT3Name.Name = "lblT3Name"
        Me.lblT3Name.Size = New System.Drawing.Size(288, 38)
        Me.lblT3Name.TabIndex = 252
        Me.lblT3Name.Visible = False
        '
        'lblT2Name
        '
        Me.lblT2Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT2Name.Location = New System.Drawing.Point(1095, 222)
        Me.lblT2Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT2Name.Name = "lblT2Name"
        Me.lblT2Name.Size = New System.Drawing.Size(288, 49)
        Me.lblT2Name.TabIndex = 251
        Me.lblT2Name.Visible = False
        '
        'lblT1Name
        '
        Me.lblT1Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT1Name.Location = New System.Drawing.Point(1095, 177)
        Me.lblT1Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT1Name.Name = "lblT1Name"
        Me.lblT1Name.Size = New System.Drawing.Size(288, 45)
        Me.lblT1Name.TabIndex = 250
        Me.lblT1Name.Visible = False
        '
        'lblT0Name
        '
        Me.lblT0Name.ForeColor = System.Drawing.Color.Blue
        Me.lblT0Name.Location = New System.Drawing.Point(1095, 138)
        Me.lblT0Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT0Name.Name = "lblT0Name"
        Me.lblT0Name.Size = New System.Drawing.Size(288, 38)
        Me.lblT0Name.TabIndex = 249
        Me.lblT0Name.Visible = False
        '
        'btnSearchT4
        '
        Me.btnSearchT4.BackgroundImage = CType(resources.GetObject("btnSearchT4.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT4.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT4.FlatAppearance.BorderSize = 0
        Me.btnSearchT4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT4.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT4.Location = New System.Drawing.Point(1052, 295)
        Me.btnSearchT4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchT4.Name = "btnSearchT4"
        Me.btnSearchT4.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchT4.TabIndex = 22
        Me.btnSearchT4.TabStop = False
        Me.btnSearchT4.UseVisualStyleBackColor = True
        Me.btnSearchT4.Visible = False
        '
        'btnSearchT3
        '
        Me.btnSearchT3.BackgroundImage = CType(resources.GetObject("btnSearchT3.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT3.FlatAppearance.BorderSize = 0
        Me.btnSearchT3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT3.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT3.Location = New System.Drawing.Point(1052, 252)
        Me.btnSearchT3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchT3.Name = "btnSearchT3"
        Me.btnSearchT3.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchT3.TabIndex = 20
        Me.btnSearchT3.TabStop = False
        Me.btnSearchT3.UseVisualStyleBackColor = True
        Me.btnSearchT3.Visible = False
        '
        'btnSearchT2
        '
        Me.btnSearchT2.BackgroundImage = CType(resources.GetObject("btnSearchT2.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT2.FlatAppearance.BorderSize = 0
        Me.btnSearchT2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT2.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT2.Location = New System.Drawing.Point(1052, 208)
        Me.btnSearchT2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchT2.Name = "btnSearchT2"
        Me.btnSearchT2.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchT2.TabIndex = 18
        Me.btnSearchT2.TabStop = False
        Me.btnSearchT2.UseVisualStyleBackColor = True
        Me.btnSearchT2.Visible = False
        '
        'btnSearchT1
        '
        Me.btnSearchT1.BackgroundImage = CType(resources.GetObject("btnSearchT1.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT1.FlatAppearance.BorderSize = 0
        Me.btnSearchT1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT1.Location = New System.Drawing.Point(1052, 165)
        Me.btnSearchT1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchT1.Name = "btnSearchT1"
        Me.btnSearchT1.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchT1.TabIndex = 16
        Me.btnSearchT1.TabStop = False
        Me.btnSearchT1.UseVisualStyleBackColor = True
        Me.btnSearchT1.Visible = False
        '
        'btnSearchT0
        '
        Me.btnSearchT0.BackgroundImage = CType(resources.GetObject("btnSearchT0.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchT0.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchT0.FlatAppearance.BorderSize = 0
        Me.btnSearchT0.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchT0.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchT0.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchT0.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchT0.Location = New System.Drawing.Point(1052, 125)
        Me.btnSearchT0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchT0.Name = "btnSearchT0"
        Me.btnSearchT0.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchT0.TabIndex = 14
        Me.btnSearchT0.TabStop = False
        Me.btnSearchT0.UseVisualStyleBackColor = True
        '
        'txtT4
        '
        Me.txtT4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT4.Location = New System.Drawing.Point(840, 302)
        Me.txtT4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtT4.Name = "txtT4"
        Me.txtT4.Size = New System.Drawing.Size(202, 28)
        Me.txtT4.TabIndex = 21
        Me.txtT4.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(806, 298)
        Me.Label33.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(16, 20)
        Me.Label33.TabIndex = 235
        Me.Label33.Text = ":"
        Me.Label33.Visible = False
        '
        'lblT4
        '
        Me.lblT4.AutoSize = True
        Me.lblT4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT4.Location = New System.Drawing.Point(646, 298)
        Me.lblT4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT4.Name = "lblT4"
        Me.lblT4.Size = New System.Drawing.Size(30, 20)
        Me.lblT4.TabIndex = 234
        Me.lblT4.Text = "T4"
        Me.lblT4.Visible = False
        '
        'txtT3
        '
        Me.txtT3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT3.Location = New System.Drawing.Point(840, 260)
        Me.txtT3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtT3.Name = "txtT3"
        Me.txtT3.Size = New System.Drawing.Size(202, 28)
        Me.txtT3.TabIndex = 19
        Me.txtT3.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(806, 257)
        Me.Label30.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(16, 20)
        Me.Label30.TabIndex = 232
        Me.Label30.Text = ":"
        Me.Label30.Visible = False
        '
        'lblT3
        '
        Me.lblT3.AutoSize = True
        Me.lblT3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT3.Location = New System.Drawing.Point(646, 257)
        Me.lblT3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT3.Name = "lblT3"
        Me.lblT3.Size = New System.Drawing.Size(30, 20)
        Me.lblT3.TabIndex = 231
        Me.lblT3.Text = "T3"
        Me.lblT3.Visible = False
        '
        'txtT2
        '
        Me.txtT2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT2.Location = New System.Drawing.Point(840, 217)
        Me.txtT2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtT2.Name = "txtT2"
        Me.txtT2.Size = New System.Drawing.Size(202, 28)
        Me.txtT2.TabIndex = 17
        Me.txtT2.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(806, 214)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(16, 20)
        Me.Label27.TabIndex = 229
        Me.Label27.Text = ":"
        Me.Label27.Visible = False
        '
        'lblT2
        '
        Me.lblT2.AutoSize = True
        Me.lblT2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT2.Location = New System.Drawing.Point(646, 214)
        Me.lblT2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT2.Name = "lblT2"
        Me.lblT2.Size = New System.Drawing.Size(30, 20)
        Me.lblT2.TabIndex = 228
        Me.lblT2.Text = "T2"
        Me.lblT2.Visible = False
        '
        'txtT1
        '
        Me.txtT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT1.Location = New System.Drawing.Point(840, 175)
        Me.txtT1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtT1.Name = "txtT1"
        Me.txtT1.Size = New System.Drawing.Size(202, 28)
        Me.txtT1.TabIndex = 15
        Me.txtT1.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(806, 172)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(16, 20)
        Me.Label26.TabIndex = 226
        Me.Label26.Text = ":"
        Me.Label26.Visible = False
        '
        'lblT1
        '
        Me.lblT1.AutoSize = True
        Me.lblT1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT1.Location = New System.Drawing.Point(646, 172)
        Me.lblT1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT1.Name = "lblT1"
        Me.lblT1.Size = New System.Drawing.Size(30, 20)
        Me.lblT1.TabIndex = 225
        Me.lblT1.Text = "T1"
        Me.lblT1.Visible = False
        '
        'txtT0
        '
        Me.txtT0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtT0.Location = New System.Drawing.Point(840, 134)
        Me.txtT0.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtT0.Name = "txtT0"
        Me.txtT0.Size = New System.Drawing.Size(202, 28)
        Me.txtT0.TabIndex = 13
        Me.txtT0.Visible = False
        '
        'btnSearchAcCode
        '
        Me.btnSearchAcCode.BackgroundImage = CType(resources.GetObject("btnSearchAcCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchAcCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchAcCode.FlatAppearance.BorderSize = 0
        Me.btnSearchAcCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchAcCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchAcCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchAcCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAcCode.Location = New System.Drawing.Point(453, 275)
        Me.btnSearchAcCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchAcCode.Name = "btnSearchAcCode"
        Me.btnSearchAcCode.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchAcCode.TabIndex = 9
        Me.btnSearchAcCode.TabStop = False
        Me.btnSearchAcCode.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(806, 131)
        Me.Label29.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(16, 20)
        Me.Label29.TabIndex = 216
        Me.Label29.Text = ":"
        Me.Label29.Visible = False
        '
        'txtAccountCode
        '
        Me.txtAccountCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccountCode.Location = New System.Drawing.Point(244, 285)
        Me.txtAccountCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAccountCode.Name = "txtAccountCode"
        Me.txtAccountCode.Size = New System.Drawing.Size(202, 28)
        Me.txtAccountCode.TabIndex = 8
        '
        'lblAccountCode
        '
        Me.lblAccountCode.AutoSize = True
        Me.lblAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountCode.ForeColor = System.Drawing.Color.Red
        Me.lblAccountCode.Location = New System.Drawing.Point(24, 285)
        Me.lblAccountCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAccountCode.Name = "lblAccountCode"
        Me.lblAccountCode.Size = New System.Drawing.Size(127, 20)
        Me.lblAccountCode.TabIndex = 213
        Me.lblAccountCode.Text = "Account Code"
        '
        'lblT0
        '
        Me.lblT0.AutoSize = True
        Me.lblT0.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblT0.ForeColor = System.Drawing.Color.Red
        Me.lblT0.Location = New System.Drawing.Point(646, 131)
        Me.lblT0.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblT0.Name = "lblT0"
        Me.lblT0.Size = New System.Drawing.Size(30, 20)
        Me.lblT0.TabIndex = 214
        Me.lblT0.Text = "T0"
        Me.lblT0.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(196, 285)
        Me.Label32.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(16, 20)
        Me.Label32.TabIndex = 215
        Me.Label32.Text = ":"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnit.ForeColor = System.Drawing.Color.Blue
        Me.lblUnit.Location = New System.Drawing.Point(246, 69)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(0, 20)
        Me.lblUnit.TabIndex = 179
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(198, 69)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 20)
        Me.Label21.TabIndex = 178
        Me.Label21.Text = ":"
        '
        'lblAdjustmentUnit
        '
        Me.lblAdjustmentUnit.AutoSize = True
        Me.lblAdjustmentUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjustmentUnit.Location = New System.Drawing.Point(28, 69)
        Me.lblAdjustmentUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjustmentUnit.Name = "lblAdjustmentUnit"
        Me.lblAdjustmentUnit.Size = New System.Drawing.Size(44, 20)
        Me.lblAdjustmentUnit.TabIndex = 177
        Me.lblAdjustmentUnit.Text = "Unit"
        '
        'txtAdjValue
        '
        Me.txtAdjValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjValue.Location = New System.Drawing.Point(246, 245)
        Me.txtAdjValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAdjValue.MaxLength = 15
        Me.txtAdjValue.Name = "txtAdjValue"
        Me.txtAdjValue.Size = New System.Drawing.Size(202, 28)
        Me.txtAdjValue.TabIndex = 7
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(198, 242)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 20)
        Me.Label17.TabIndex = 175
        Me.Label17.Text = ":"
        '
        'lblAdjValue
        '
        Me.lblAdjValue.AutoSize = True
        Me.lblAdjValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjValue.ForeColor = System.Drawing.Color.Red
        Me.lblAdjValue.Location = New System.Drawing.Point(24, 242)
        Me.lblAdjValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjValue.Name = "lblAdjValue"
        Me.lblAdjValue.Size = New System.Drawing.Size(97, 20)
        Me.lblAdjValue.TabIndex = 174
        Me.lblAdjValue.Text = "Adj. Value"
        '
        'txtAdjQty
        '
        Me.txtAdjQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjQty.Location = New System.Drawing.Point(840, 88)
        Me.txtAdjQty.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAdjQty.MaxLength = 15
        Me.txtAdjQty.Name = "txtAdjQty"
        Me.txtAdjQty.Size = New System.Drawing.Size(202, 28)
        Me.txtAdjQty.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(806, 85)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 20)
        Me.Label18.TabIndex = 171
        Me.Label18.Text = ":"
        '
        'lblAdjQty
        '
        Me.lblAdjQty.AutoSize = True
        Me.lblAdjQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjQty.ForeColor = System.Drawing.Color.Red
        Me.lblAdjQty.Location = New System.Drawing.Point(646, 85)
        Me.lblAdjQty.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjQty.Name = "lblAdjQty"
        Me.lblAdjQty.Size = New System.Drawing.Size(80, 20)
        Me.lblAdjQty.TabIndex = 170
        Me.lblAdjQty.Text = "Adj. Qty"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.Color.Blue
        Me.lblDescription.Location = New System.Drawing.Point(248, 106)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(0, 20)
        Me.lblDescription.TabIndex = 169
        '
        'btnSearchStockCode
        '
        Me.btnSearchStockCode.BackgroundImage = CType(resources.GetObject("btnSearchStockCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchStockCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchStockCode.FlatAppearance.BorderSize = 0
        Me.btnSearchStockCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchStockCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchStockCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchStockCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchStockCode.Location = New System.Drawing.Point(454, 18)
        Me.btnSearchStockCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchStockCode.Name = "btnSearchStockCode"
        Me.btnSearchStockCode.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchStockCode.TabIndex = 6
        Me.btnSearchStockCode.TabStop = False
        Me.btnSearchStockCode.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(200, 106)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(16, 20)
        Me.Label20.TabIndex = 8
        Me.Label20.Text = ":"
        '
        'txtStockCode
        '
        Me.txtStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCode.Location = New System.Drawing.Point(246, 28)
        Me.txtStockCode.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(202, 28)
        Me.txtStockCode.TabIndex = 5
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.ForeColor = System.Drawing.Color.Red
        Me.lblStockCode.Location = New System.Drawing.Point(28, 28)
        Me.lblStockCode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(106, 20)
        Me.lblStockCode.TabIndex = 1
        Me.lblStockCode.Text = "Stock Code"
        '
        'lblStockDescription
        '
        Me.lblStockDescription.AutoSize = True
        Me.lblStockDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDescription.Location = New System.Drawing.Point(22, 106)
        Me.lblStockDescription.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStockDescription.Name = "lblStockDescription"
        Me.lblStockDescription.Size = New System.Drawing.Size(112, 20)
        Me.lblStockDescription.TabIndex = 2
        Me.lblStockDescription.Text = " Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(198, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(16, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = ":"
        '
        'btnSearchSubBlock
        '
        Me.btnSearchSubBlock.BackgroundImage = CType(resources.GetObject("btnSearchSubBlock.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchSubBlock.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchSubBlock.FlatAppearance.BorderSize = 0
        Me.btnSearchSubBlock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchSubBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchSubBlock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchSubBlock.Location = New System.Drawing.Point(1610, 369)
        Me.btnSearchSubBlock.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSearchSubBlock.Name = "btnSearchSubBlock"
        Me.btnSearchSubBlock.Size = New System.Drawing.Size(45, 40)
        Me.btnSearchSubBlock.TabIndex = 251
        Me.btnSearchSubBlock.UseVisualStyleBackColor = True
        Me.btnSearchSubBlock.Visible = False
        '
        'lblYOPName
        '
        Me.lblYOPName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblYOPName.Location = New System.Drawing.Point(1612, 465)
        Me.lblYOPName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYOPName.Name = "lblYOPName"
        Me.lblYOPName.Size = New System.Drawing.Size(80, 18)
        Me.lblYOPName.TabIndex = 250
        Me.lblYOPName.Visible = False
        '
        'lblDivName
        '
        Me.lblDivName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblDivName.Location = New System.Drawing.Point(1612, 431)
        Me.lblDivName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDivName.Name = "lblDivName"
        Me.lblDivName.Size = New System.Drawing.Size(80, 18)
        Me.lblDivName.TabIndex = 249
        Me.lblDivName.Visible = False
        '
        'txtSubBlock
        '
        Me.txtSubBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubBlock.Location = New System.Drawing.Point(1401, 378)
        Me.txtSubBlock.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSubBlock.Name = "txtSubBlock"
        Me.txtSubBlock.Size = New System.Drawing.Size(202, 28)
        Me.txtSubBlock.TabIndex = 248
        Me.txtSubBlock.Visible = False
        '
        'txtDiv
        '
        Me.txtDiv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiv.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiv.Location = New System.Drawing.Point(1401, 422)
        Me.txtDiv.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDiv.Name = "txtDiv"
        Me.txtDiv.Size = New System.Drawing.Size(202, 28)
        Me.txtDiv.TabIndex = 247
        Me.txtDiv.Visible = False
        '
        'txtYOP
        '
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(1401, 460)
        Me.txtYOP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.Size = New System.Drawing.Size(202, 28)
        Me.txtYOP.TabIndex = 246
        Me.txtYOP.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(1545, 262)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(16, 20)
        Me.Label19.TabIndex = 245
        Me.Label19.Text = ":"
        Me.Label19.Visible = False
        '
        'lblSubBlock
        '
        Me.lblSubBlock.AutoSize = True
        Me.lblSubBlock.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubBlock.Location = New System.Drawing.Point(1396, 262)
        Me.lblSubBlock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubBlock.Name = "lblSubBlock"
        Me.lblSubBlock.Size = New System.Drawing.Size(125, 20)
        Me.lblSubBlock.TabIndex = 244
        Me.lblSubBlock.Text = "Field Number"
        Me.lblSubBlock.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(1545, 308)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(16, 20)
        Me.Label22.TabIndex = 243
        Me.Label22.Text = ":"
        Me.Label22.Visible = False
        '
        'lblDIV
        '
        Me.lblDIV.AutoSize = True
        Me.lblDIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDIV.Location = New System.Drawing.Point(1396, 308)
        Me.lblDIV.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDIV.Name = "lblDIV"
        Me.lblDIV.Size = New System.Drawing.Size(80, 20)
        Me.lblDIV.TabIndex = 242
        Me.lblDIV.Text = "Afdeling"
        Me.lblDIV.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(1545, 343)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(16, 20)
        Me.Label24.TabIndex = 241
        Me.Label24.Text = ":"
        Me.Label24.Visible = False
        '
        'lblYOP
        '
        Me.lblYOP.AutoSize = True
        Me.lblYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYOP.Location = New System.Drawing.Point(1396, 343)
        Me.lblYOP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblYOP.Name = "lblYOP"
        Me.lblYOP.Size = New System.Drawing.Size(42, 20)
        Me.lblYOP.TabIndex = 240
        Me.lblYOP.Text = "YOP"
        Me.lblYOP.Visible = False
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(1088, 898)
        Me.btnResetAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(147, 38)
        Me.btnResetAll.TabIndex = 27
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(870, 898)
        Me.btnSaveAll.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(206, 38)
        Me.btnSaveAll.TabIndex = 26
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(1245, 898)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(147, 38)
        Me.btnClose.TabIndex = 28
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'dgvAdjustDetails
        '
        Me.dgvAdjustDetails.AllowUserToAddRows = False
        Me.dgvAdjustDetails.AllowUserToDeleteRows = False
        Me.dgvAdjustDetails.AllowUserToResizeRows = False
        Me.dgvAdjustDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAdjustDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAdjustDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdjustDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAdjustDetails.ColumnHeadersHeight = 30
        Me.dgvAdjustDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.STAStockCode, Me.STAStockDesc, Me.STAAvailableQty, Me.STAPartNo, Me.STAAdjustVal, Me.STAAdjQty, Me.STAUnit, Me.STAAccountCode, Me.STAAccountDesc, Me.STAOldCOACode, Me.STAT0, Me.STAT1, Me.STAT2, Me.STAT3, Me.STAT4, Me.STAAdjustmentNo, Me.STAAdjustmentDate, Me.STARemarks, Me.STASubBlock, Me.STADivDesc, Me.STASTAdjustmentID, Me.STAT0Desc, Me.STAT1Desc, Me.STAT2Desc, Me.STAT3Desc, Me.STAT4Desc, Me.STAAccountID, Me.STACategoryID, Me.STAVarianceCOAID, Me.STADIV, Me.STAYOP, Me.STAYOPName, Me.STAStockID, Me.STARejectedReason, Me.STAStatus, Me.STACOAID, Me.STAYOPID, Me.STADIVID, Me.STABlockID, Me.STAT0Id, Me.STAT1Id, Me.STAT2Id, Me.STAT3Id, Me.STAT4Id, Me.STAStockCOAID, Me.STASTDPrice})
        Me.dgvAdjustDetails.ContextMenuStrip = Me.cmsSTAAddEdit
        Me.dgvAdjustDetails.EnableHeadersVisualStyles = False
        Me.dgvAdjustDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvAdjustDetails.Location = New System.Drawing.Point(4, 680)
        Me.dgvAdjustDetails.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvAdjustDetails.MultiSelect = False
        Me.dgvAdjustDetails.Name = "dgvAdjustDetails"
        Me.dgvAdjustDetails.ReadOnly = True
        Me.dgvAdjustDetails.RowHeadersVisible = False
        Me.dgvAdjustDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAdjustDetails.Size = New System.Drawing.Size(1392, 209)
        Me.dgvAdjustDetails.TabIndex = 25
        Me.dgvAdjustDetails.TabStop = False
        '
        'STAStockCode
        '
        Me.STAStockCode.DataPropertyName = "StockCode"
        Me.STAStockCode.HeaderText = "Stock Code"
        Me.STAStockCode.Name = "STAStockCode"
        Me.STAStockCode.ReadOnly = True
        '
        'STAStockDesc
        '
        Me.STAStockDesc.DataPropertyName = "StockDesc"
        Me.STAStockDesc.HeaderText = "Stock Desc"
        Me.STAStockDesc.Name = "STAStockDesc"
        Me.STAStockDesc.ReadOnly = True
        '
        'STAAvailableQty
        '
        Me.STAAvailableQty.DataPropertyName = "AvailableQty"
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.STAAvailableQty.DefaultCellStyle = DataGridViewCellStyle2
        Me.STAAvailableQty.HeaderText = "Available Qty"
        Me.STAAvailableQty.Name = "STAAvailableQty"
        Me.STAAvailableQty.ReadOnly = True
        Me.STAAvailableQty.Width = 150
        '
        'STAPartNo
        '
        Me.STAPartNo.DataPropertyName = "PartNo"
        Me.STAPartNo.HeaderText = "Part No"
        Me.STAPartNo.Name = "STAPartNo"
        Me.STAPartNo.ReadOnly = True
        '
        'STAAdjustVal
        '
        Me.STAAdjustVal.DataPropertyName = "AdjValue"
        Me.STAAdjustVal.HeaderText = "Adjust Value"
        Me.STAAdjustVal.Name = "STAAdjustVal"
        Me.STAAdjustVal.ReadOnly = True
        Me.STAAdjustVal.Width = 150
        '
        'STAAdjQty
        '
        Me.STAAdjQty.DataPropertyName = "AdjQty"
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.STAAdjQty.DefaultCellStyle = DataGridViewCellStyle3
        Me.STAAdjQty.HeaderText = "Adjust Qty"
        Me.STAAdjQty.Name = "STAAdjQty"
        Me.STAAdjQty.ReadOnly = True
        Me.STAAdjQty.Width = 150
        '
        'STAUnit
        '
        Me.STAUnit.DataPropertyName = "UOM"
        Me.STAUnit.HeaderText = "Unit"
        Me.STAUnit.Name = "STAUnit"
        Me.STAUnit.ReadOnly = True
        '
        'STAAccountCode
        '
        Me.STAAccountCode.DataPropertyName = "AccountCode"
        Me.STAAccountCode.HeaderText = "AccountCode"
        Me.STAAccountCode.Name = "STAAccountCode"
        Me.STAAccountCode.ReadOnly = True
        '
        'STAAccountDesc
        '
        Me.STAAccountDesc.DataPropertyName = "AccountDesc"
        Me.STAAccountDesc.HeaderText = "AccountDesc"
        Me.STAAccountDesc.Name = "STAAccountDesc"
        Me.STAAccountDesc.ReadOnly = True
        '
        'STAOldCOACode
        '
        Me.STAOldCOACode.DataPropertyName = "OldCOACode"
        Me.STAOldCOACode.HeaderText = "OldCOACode"
        Me.STAOldCOACode.Name = "STAOldCOACode"
        Me.STAOldCOACode.ReadOnly = True
        Me.STAOldCOACode.Visible = False
        '
        'STAT0
        '
        Me.STAT0.DataPropertyName = "T0Value"
        Me.STAT0.HeaderText = "T0"
        Me.STAT0.Name = "STAT0"
        Me.STAT0.ReadOnly = True
        Me.STAT0.Visible = False
        '
        'STAT1
        '
        Me.STAT1.DataPropertyName = "T1Value"
        Me.STAT1.HeaderText = "T1"
        Me.STAT1.Name = "STAT1"
        Me.STAT1.ReadOnly = True
        Me.STAT1.Visible = False
        '
        'STAT2
        '
        Me.STAT2.DataPropertyName = "T2Value"
        Me.STAT2.HeaderText = "T2"
        Me.STAT2.Name = "STAT2"
        Me.STAT2.ReadOnly = True
        Me.STAT2.Visible = False
        '
        'STAT3
        '
        Me.STAT3.DataPropertyName = "T3Value"
        Me.STAT3.HeaderText = "T3"
        Me.STAT3.Name = "STAT3"
        Me.STAT3.ReadOnly = True
        Me.STAT3.Visible = False
        '
        'STAT4
        '
        Me.STAT4.DataPropertyName = "T4Value"
        Me.STAT4.HeaderText = "T4"
        Me.STAT4.Name = "STAT4"
        Me.STAT4.ReadOnly = True
        Me.STAT4.Visible = False
        '
        'STAAdjustmentNo
        '
        Me.STAAdjustmentNo.DataPropertyName = "AdjustmentNo"
        Me.STAAdjustmentNo.HeaderText = "Adjustment No"
        Me.STAAdjustmentNo.Name = "STAAdjustmentNo"
        Me.STAAdjustmentNo.ReadOnly = True
        Me.STAAdjustmentNo.Visible = False
        Me.STAAdjustmentNo.Width = 150
        '
        'STAAdjustmentDate
        '
        Me.STAAdjustmentDate.DataPropertyName = "AdjustmentDate"
        Me.STAAdjustmentDate.HeaderText = "Adjustment Date"
        Me.STAAdjustmentDate.Name = "STAAdjustmentDate"
        Me.STAAdjustmentDate.ReadOnly = True
        Me.STAAdjustmentDate.Visible = False
        Me.STAAdjustmentDate.Width = 150
        '
        'STARemarks
        '
        Me.STARemarks.DataPropertyName = "Remarks"
        Me.STARemarks.HeaderText = "Remarks"
        Me.STARemarks.Name = "STARemarks"
        Me.STARemarks.ReadOnly = True
        Me.STARemarks.Visible = False
        '
        'STASubBlock
        '
        Me.STASubBlock.DataPropertyName = "BlockName"
        Me.STASubBlock.HeaderText = "FieldNo"
        Me.STASubBlock.Name = "STASubBlock"
        Me.STASubBlock.ReadOnly = True
        Me.STASubBlock.Visible = False
        '
        'STADivDesc
        '
        Me.STADivDesc.DataPropertyName = "DivDesc"
        Me.STADivDesc.HeaderText = "Afdeling Desc"
        Me.STADivDesc.Name = "STADivDesc"
        Me.STADivDesc.ReadOnly = True
        Me.STADivDesc.Visible = False
        '
        'STASTAdjustmentID
        '
        Me.STASTAdjustmentID.DataPropertyName = "STAdjustmentID"
        Me.STASTAdjustmentID.HeaderText = "STAdjustmentID"
        Me.STASTAdjustmentID.Name = "STASTAdjustmentID"
        Me.STASTAdjustmentID.ReadOnly = True
        Me.STASTAdjustmentID.Visible = False
        '
        'STAT0Desc
        '
        Me.STAT0Desc.DataPropertyName = "T0Desc"
        Me.STAT0Desc.HeaderText = "T0Desc"
        Me.STAT0Desc.Name = "STAT0Desc"
        Me.STAT0Desc.ReadOnly = True
        Me.STAT0Desc.Visible = False
        '
        'STAT1Desc
        '
        Me.STAT1Desc.DataPropertyName = "T1Desc"
        Me.STAT1Desc.HeaderText = "T1Desc"
        Me.STAT1Desc.Name = "STAT1Desc"
        Me.STAT1Desc.ReadOnly = True
        Me.STAT1Desc.Visible = False
        '
        'STAT2Desc
        '
        Me.STAT2Desc.DataPropertyName = "T2Desc"
        Me.STAT2Desc.HeaderText = "T2Desc"
        Me.STAT2Desc.Name = "STAT2Desc"
        Me.STAT2Desc.ReadOnly = True
        Me.STAT2Desc.Visible = False
        '
        'STAT3Desc
        '
        Me.STAT3Desc.DataPropertyName = "T3Desc"
        Me.STAT3Desc.HeaderText = "T3Desc"
        Me.STAT3Desc.Name = "STAT3Desc"
        Me.STAT3Desc.ReadOnly = True
        Me.STAT3Desc.Visible = False
        '
        'STAT4Desc
        '
        Me.STAT4Desc.DataPropertyName = "T4Desc"
        Me.STAT4Desc.HeaderText = "T4Desc"
        Me.STAT4Desc.Name = "STAT4Desc"
        Me.STAT4Desc.ReadOnly = True
        Me.STAT4Desc.Visible = False
        '
        'STAAccountID
        '
        Me.STAAccountID.DataPropertyName = "COAID"
        Me.STAAccountID.HeaderText = "AccountID"
        Me.STAAccountID.Name = "STAAccountID"
        Me.STAAccountID.ReadOnly = True
        Me.STAAccountID.Visible = False
        '
        'STACategoryID
        '
        Me.STACategoryID.DataPropertyName = "STCategoryID"
        Me.STACategoryID.HeaderText = "CategoryID"
        Me.STACategoryID.Name = "STACategoryID"
        Me.STACategoryID.ReadOnly = True
        Me.STACategoryID.Visible = False
        '
        'STAVarianceCOAID
        '
        Me.STAVarianceCOAID.ContextMenuStrip = Me.cmsAdjust
        Me.STAVarianceCOAID.DataPropertyName = "VarianceCOAID"
        Me.STAVarianceCOAID.HeaderText = "VarianceCOAID"
        Me.STAVarianceCOAID.Name = "STAVarianceCOAID"
        Me.STAVarianceCOAID.ReadOnly = True
        Me.STAVarianceCOAID.Visible = False
        '
        'cmsAdjust
        '
        Me.cmsAdjust.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsAdjust.Name = "cmsIPR"
        Me.cmsAdjust.Size = New System.Drawing.Size(135, 94)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(134, 30)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'STADIV
        '
        Me.STADIV.DataPropertyName = "DIV"
        Me.STADIV.HeaderText = "Afdeling"
        Me.STADIV.Name = "STADIV"
        Me.STADIV.ReadOnly = True
        Me.STADIV.Visible = False
        '
        'STAYOP
        '
        Me.STAYOP.DataPropertyName = "YOP"
        Me.STAYOP.HeaderText = "YOP"
        Me.STAYOP.Name = "STAYOP"
        Me.STAYOP.ReadOnly = True
        Me.STAYOP.Visible = False
        '
        'STAYOPName
        '
        Me.STAYOPName.DataPropertyName = "YOPName"
        Me.STAYOPName.HeaderText = "YOPName"
        Me.STAYOPName.Name = "STAYOPName"
        Me.STAYOPName.ReadOnly = True
        Me.STAYOPName.Visible = False
        '
        'STAStockID
        '
        Me.STAStockID.DataPropertyName = "StockID"
        Me.STAStockID.HeaderText = "StockID"
        Me.STAStockID.Name = "STAStockID"
        Me.STAStockID.ReadOnly = True
        Me.STAStockID.Visible = False
        '
        'STARejectedReason
        '
        Me.STARejectedReason.DataPropertyName = "RejectedReason"
        Me.STARejectedReason.HeaderText = "RejectedReason"
        Me.STARejectedReason.Name = "STARejectedReason"
        Me.STARejectedReason.ReadOnly = True
        Me.STARejectedReason.Visible = False
        '
        'STAStatus
        '
        Me.STAStatus.DataPropertyName = "Status"
        Me.STAStatus.HeaderText = "Status"
        Me.STAStatus.Name = "STAStatus"
        Me.STAStatus.ReadOnly = True
        '
        'STACOAID
        '
        Me.STACOAID.DataPropertyName = "COAID"
        Me.STACOAID.HeaderText = "COAID"
        Me.STACOAID.Name = "STACOAID"
        Me.STACOAID.ReadOnly = True
        Me.STACOAID.Visible = False
        '
        'STAYOPID
        '
        Me.STAYOPID.DataPropertyName = "YOPID"
        Me.STAYOPID.HeaderText = "YOPID"
        Me.STAYOPID.Name = "STAYOPID"
        Me.STAYOPID.ReadOnly = True
        Me.STAYOPID.Visible = False
        '
        'STADIVID
        '
        Me.STADIVID.DataPropertyName = "DIVID"
        Me.STADIVID.HeaderText = "Afdeling ID"
        Me.STADIVID.Name = "STADIVID"
        Me.STADIVID.ReadOnly = True
        Me.STADIVID.Visible = False
        '
        'STABlockID
        '
        Me.STABlockID.DataPropertyName = "BlockID"
        Me.STABlockID.HeaderText = "FieldNoID"
        Me.STABlockID.Name = "STABlockID"
        Me.STABlockID.ReadOnly = True
        Me.STABlockID.Visible = False
        '
        'STAT0Id
        '
        Me.STAT0Id.DataPropertyName = "T0Id"
        Me.STAT0Id.HeaderText = "T0Id"
        Me.STAT0Id.Name = "STAT0Id"
        Me.STAT0Id.ReadOnly = True
        Me.STAT0Id.Visible = False
        '
        'STAT1Id
        '
        Me.STAT1Id.DataPropertyName = "T1Id"
        Me.STAT1Id.HeaderText = "T1Id"
        Me.STAT1Id.Name = "STAT1Id"
        Me.STAT1Id.ReadOnly = True
        Me.STAT1Id.Visible = False
        '
        'STAT2Id
        '
        Me.STAT2Id.DataPropertyName = "T2Id"
        Me.STAT2Id.HeaderText = "T2Id"
        Me.STAT2Id.Name = "STAT2Id"
        Me.STAT2Id.ReadOnly = True
        Me.STAT2Id.Visible = False
        '
        'STAT3Id
        '
        Me.STAT3Id.DataPropertyName = "T3Id"
        Me.STAT3Id.HeaderText = "T3Id"
        Me.STAT3Id.Name = "STAT3Id"
        Me.STAT3Id.ReadOnly = True
        Me.STAT3Id.Visible = False
        '
        'STAT4Id
        '
        Me.STAT4Id.DataPropertyName = "T4Id"
        Me.STAT4Id.HeaderText = "T4Id"
        Me.STAT4Id.Name = "STAT4Id"
        Me.STAT4Id.ReadOnly = True
        Me.STAT4Id.Visible = False
        '
        'STAStockCOAID
        '
        Me.STAStockCOAID.DataPropertyName = "StockCOAID"
        Me.STAStockCOAID.HeaderText = "StockCOAID"
        Me.STAStockCOAID.Name = "STAStockCOAID"
        Me.STAStockCOAID.ReadOnly = True
        Me.STAStockCOAID.Visible = False
        '
        'STASTDPrice
        '
        Me.STASTDPrice.DataPropertyName = "StdPrice"
        Me.STASTDPrice.HeaderText = "STDPrice"
        Me.STASTDPrice.Name = "STASTDPrice"
        Me.STASTDPrice.ReadOnly = True
        Me.STASTDPrice.Visible = False
        '
        'cmsSTAAddEdit
        '
        Me.cmsSTAAddEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem2, Me.DelToolStripMenuItem3})
        Me.cmsSTAAddEdit.Name = "cmsIPR"
        Me.cmsSTAAddEdit.Size = New System.Drawing.Size(135, 64)
        '
        'EditToolStripMenuItem2
        '
        Me.EditToolStripMenuItem2.Image = CType(resources.GetObject("EditToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem2.Name = "EditToolStripMenuItem2"
        Me.EditToolStripMenuItem2.Size = New System.Drawing.Size(134, 30)
        Me.EditToolStripMenuItem2.Text = "Edit"
        '
        'DelToolStripMenuItem3
        '
        Me.DelToolStripMenuItem3.Image = CType(resources.GetObject("DelToolStripMenuItem3.Image"), System.Drawing.Image)
        Me.DelToolStripMenuItem3.Name = "DelToolStripMenuItem3"
        Me.DelToolStripMenuItem3.Size = New System.Drawing.Size(134, 30)
        Me.DelToolStripMenuItem3.Text = "Delete"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnResetIB)
        Me.GroupBox4.Controls.Add(Me.btnAdd)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 605)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox4.Size = New System.Drawing.Size(1392, 69)
        Me.GroupBox4.TabIndex = 23
        Me.GroupBox4.TabStop = False
        '
        'btnResetIB
        '
        Me.btnResetIB.BackgroundImage = CType(resources.GetObject("btnResetIB.BackgroundImage"), System.Drawing.Image)
        Me.btnResetIB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetIB.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetIB.Image = CType(resources.GetObject("btnResetIB.Image"), System.Drawing.Image)
        Me.btnResetIB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetIB.Location = New System.Drawing.Point(1240, 22)
        Me.btnResetIB.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnResetIB.Name = "btnResetIB"
        Me.btnResetIB.Size = New System.Drawing.Size(147, 38)
        Me.btnResetIB.TabIndex = 24
        Me.btnResetIB.Text = "Reset"
        Me.btnResetIB.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(1077, 22)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(147, 38)
        Me.btnAdd.TabIndex = 23
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'grpApproval
        '
        Me.grpApproval.Controls.Add(Me.btnConfirm)
        Me.grpApproval.Controls.Add(Me.Label23)
        Me.grpApproval.Controls.Add(Me.cmbStatus)
        Me.grpApproval.Controls.Add(Me.txtRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblRejectedReason)
        Me.grpApproval.Controls.Add(Me.lblApprovalStatus)
        Me.grpApproval.Location = New System.Drawing.Point(1246, 8)
        Me.grpApproval.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpApproval.Name = "grpApproval"
        Me.grpApproval.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpApproval.Size = New System.Drawing.Size(434, 183)
        Me.grpApproval.TabIndex = 29
        Me.grpApproval.TabStop = False
        Me.grpApproval.Text = "Approval"
        Me.grpApproval.Visible = False
        '
        'btnConfirm
        '
        Me.btnConfirm.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnConfirm.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirm.Image = CType(resources.GetObject("btnConfirm.Image"), System.Drawing.Image)
        Me.btnConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConfirm.Location = New System.Drawing.Point(214, 138)
        Me.btnConfirm.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(166, 43)
        Me.btnConfirm.TabIndex = 31
        Me.btnConfirm.Text = "Confirm"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(178, 18)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(16, 20)
        Me.Label23.TabIndex = 150
        Me.Label23.Text = ":"
        '
        'cmbStatus
        '
        Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"--Select Status--", "MANAGER APPROVED", "REJECTED"})
        Me.cmbStatus.Location = New System.Drawing.Point(27, 43)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(200, 28)
        Me.cmbStatus.TabIndex = 29
        '
        'txtRejectedReason
        '
        Me.txtRejectedReason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRejectedReason.ForeColor = System.Drawing.Color.Red
        Me.txtRejectedReason.Location = New System.Drawing.Point(27, 100)
        Me.txtRejectedReason.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRejectedReason.Multiline = True
        Me.txtRejectedReason.Name = "txtRejectedReason"
        Me.txtRejectedReason.Size = New System.Drawing.Size(353, 34)
        Me.txtRejectedReason.TabIndex = 30
        Me.txtRejectedReason.Visible = False
        '
        'lblRejectedReason
        '
        Me.lblRejectedReason.AutoSize = True
        Me.lblRejectedReason.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReason.ForeColor = System.Drawing.Color.Black
        Me.lblRejectedReason.Location = New System.Drawing.Point(27, 77)
        Me.lblRejectedReason.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRejectedReason.Name = "lblRejectedReason"
        Me.lblRejectedReason.Size = New System.Drawing.Size(152, 20)
        Me.lblRejectedReason.TabIndex = 149
        Me.lblRejectedReason.Text = "Rejected Reason"
        Me.lblRejectedReason.Visible = False
        '
        'lblApprovalStatus
        '
        Me.lblApprovalStatus.AutoSize = True
        Me.lblApprovalStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovalStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblApprovalStatus.Location = New System.Drawing.Point(27, 18)
        Me.lblApprovalStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblApprovalStatus.Name = "lblApprovalStatus"
        Me.lblApprovalStatus.Size = New System.Drawing.Size(65, 20)
        Me.lblApprovalStatus.TabIndex = 147
        Me.lblApprovalStatus.Text = "Status"
        '
        'grpRGN
        '
        Me.grpRGN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.grpRGN.Controls.Add(Me.txtBeritaAcaraAudit)
        Me.grpRGN.Controls.Add(Me.Label31)
        Me.grpRGN.Controls.Add(Me.Label35)
        Me.grpRGN.Controls.Add(Me.lblRejReasonColon)
        Me.grpRGN.Controls.Add(Me.lblRejectedReasonValue)
        Me.grpRGN.Controls.Add(Me.lblRejectedReason1)
        Me.grpRGN.Controls.Add(Me.txtRemarks)
        Me.grpRGN.Controls.Add(Me.txtAdjustmentNo)
        Me.grpRGN.Controls.Add(Me.Label6)
        Me.grpRGN.Controls.Add(Me.Label5)
        Me.grpRGN.Controls.Add(Me.lblStatus)
        Me.grpRGN.Controls.Add(Me.Label3)
        Me.grpRGN.Controls.Add(Me.Label1)
        Me.grpRGN.Controls.Add(Me.dtpAdjustmentDate)
        Me.grpRGN.Controls.Add(Me.lblAdjustmentStatus)
        Me.grpRGN.Controls.Add(Me.lblAdjustmentDate)
        Me.grpRGN.Controls.Add(Me.lblRemarks)
        Me.grpRGN.Controls.Add(Me.lblAdjustmentNo)
        Me.grpRGN.Location = New System.Drawing.Point(4, 9)
        Me.grpRGN.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpRGN.Name = "grpRGN"
        Me.grpRGN.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpRGN.Size = New System.Drawing.Size(1233, 188)
        Me.grpRGN.TabIndex = 1
        Me.grpRGN.TabStop = False
        Me.grpRGN.Text = "Stock Adjustment"
        '
        'txtBeritaAcaraAudit
        '
        Me.txtBeritaAcaraAudit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBeritaAcaraAudit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeritaAcaraAudit.Location = New System.Drawing.Point(225, 145)
        Me.txtBeritaAcaraAudit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtBeritaAcaraAudit.Name = "txtBeritaAcaraAudit"
        Me.txtBeritaAcaraAudit.Size = New System.Drawing.Size(353, 28)
        Me.txtBeritaAcaraAudit.TabIndex = 307
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(172, 148)
        Me.Label31.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(16, 20)
        Me.Label31.TabIndex = 308
        Me.Label31.Text = ":"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(28, 142)
        Me.Label35.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(114, 40)
        Me.Label35.TabIndex = 306
        Me.Label35.Text = "Berita Acara" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Audit"
        '
        'lblRejReasonColon
        '
        Me.lblRejReasonColon.AutoSize = True
        Me.lblRejReasonColon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejReasonColon.ForeColor = System.Drawing.Color.Black
        Me.lblRejReasonColon.Location = New System.Drawing.Point(796, 109)
        Me.lblRejReasonColon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRejReasonColon.Name = "lblRejReasonColon"
        Me.lblRejReasonColon.Size = New System.Drawing.Size(16, 20)
        Me.lblRejReasonColon.TabIndex = 305
        Me.lblRejReasonColon.Text = ":"
        '
        'lblRejectedReasonValue
        '
        Me.lblRejectedReasonValue.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReasonValue.ForeColor = System.Drawing.Color.Red
        Me.lblRejectedReasonValue.Location = New System.Drawing.Point(844, 109)
        Me.lblRejectedReasonValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRejectedReasonValue.Name = "lblRejectedReasonValue"
        Me.lblRejectedReasonValue.Size = New System.Drawing.Size(380, 45)
        Me.lblRejectedReasonValue.TabIndex = 304
        Me.lblRejectedReasonValue.Visible = False
        '
        'lblRejectedReason1
        '
        Me.lblRejectedReason1.AutoSize = True
        Me.lblRejectedReason1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRejectedReason1.ForeColor = System.Drawing.Color.Black
        Me.lblRejectedReason1.Location = New System.Drawing.Point(626, 109)
        Me.lblRejectedReason1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRejectedReason1.Name = "lblRejectedReason1"
        Me.lblRejectedReason1.Size = New System.Drawing.Size(152, 20)
        Me.lblRejectedReason1.TabIndex = 153
        Me.lblRejectedReason1.Text = "Rejected Reason"
        Me.lblRejectedReason1.Visible = False
        '
        'txtRemarks
        '
        Me.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(225, 68)
        Me.txtRemarks.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(353, 64)
        Me.txtRemarks.TabIndex = 3
        '
        'txtAdjustmentNo
        '
        Me.txtAdjustmentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAdjustmentNo.Enabled = False
        Me.txtAdjustmentNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdjustmentNo.Location = New System.Drawing.Point(225, 23)
        Me.txtAdjustmentNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAdjustmentNo.Name = "txtAdjustmentNo"
        Me.txtAdjustmentNo.Size = New System.Drawing.Size(202, 28)
        Me.txtAdjustmentNo.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(796, 71)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 20)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = ":"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(796, 23)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Blue
        Me.lblStatus.Location = New System.Drawing.Point(844, 71)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(56, 20)
        Me.lblStatus.TabIndex = 9
        Me.lblStatus.Text = "OPEN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(177, 69)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(177, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = ":"
        '
        'dtpAdjustmentDate
        '
        Me.dtpAdjustmentDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAdjustmentDate.Location = New System.Drawing.Point(844, 23)
        Me.dtpAdjustmentDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpAdjustmentDate.Name = "dtpAdjustmentDate"
        Me.dtpAdjustmentDate.Size = New System.Drawing.Size(200, 28)
        Me.dtpAdjustmentDate.TabIndex = 2
        Me.dtpAdjustmentDate.Value = New Date(2009, 10, 29, 0, 0, 0, 0)
        '
        'lblAdjustmentStatus
        '
        Me.lblAdjustmentStatus.AutoSize = True
        Me.lblAdjustmentStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjustmentStatus.Location = New System.Drawing.Point(626, 71)
        Me.lblAdjustmentStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjustmentStatus.Name = "lblAdjustmentStatus"
        Me.lblAdjustmentStatus.Size = New System.Drawing.Size(65, 20)
        Me.lblAdjustmentStatus.TabIndex = 4
        Me.lblAdjustmentStatus.Text = "Status"
        '
        'lblAdjustmentDate
        '
        Me.lblAdjustmentDate.AutoSize = True
        Me.lblAdjustmentDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjustmentDate.ForeColor = System.Drawing.Color.Red
        Me.lblAdjustmentDate.Location = New System.Drawing.Point(626, 23)
        Me.lblAdjustmentDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjustmentDate.Name = "lblAdjustmentDate"
        Me.lblAdjustmentDate.Size = New System.Drawing.Size(156, 20)
        Me.lblAdjustmentDate.TabIndex = 3
        Me.lblAdjustmentDate.Text = "Adjustment Date"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(28, 69)
        Me.lblRemarks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(84, 20)
        Me.lblRemarks.TabIndex = 2
        Me.lblRemarks.Text = "Remarks"
        '
        'lblAdjustmentNo
        '
        Me.lblAdjustmentNo.AutoSize = True
        Me.lblAdjustmentNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdjustmentNo.ForeColor = System.Drawing.Color.Red
        Me.lblAdjustmentNo.Location = New System.Drawing.Point(28, 25)
        Me.lblAdjustmentNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjustmentNo.Name = "lblAdjustmentNo"
        Me.lblAdjustmentNo.Size = New System.Drawing.Size(139, 20)
        Me.lblAdjustmentNo.TabIndex = 0
        Me.lblAdjustmentNo.Text = "Adjustment No"
        '
        'tbSAView
        '
        Me.tbSAView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbSAView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbSAView.Controls.Add(Me.lblView)
        Me.tbSAView.Controls.Add(Me.dgvAdjustmentView)
        Me.tbSAView.Controls.Add(Me.PnlSearch)
        Me.tbSAView.Location = New System.Drawing.Point(4, 29)
        Me.tbSAView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbSAView.Name = "tbSAView"
        Me.tbSAView.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.tbSAView.Size = New System.Drawing.Size(1696, 976)
        Me.tbSAView.TabIndex = 1
        Me.tbSAView.Text = "View"
        Me.tbSAView.UseVisualStyleBackColor = True
        '
        'lblView
        '
        Me.lblView.AutoSize = True
        Me.lblView.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblView.ForeColor = System.Drawing.Color.Red
        Me.lblView.Location = New System.Drawing.Point(438, 332)
        Me.lblView.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblView.Name = "lblView"
        Me.lblView.Size = New System.Drawing.Size(194, 20)
        Me.lblView.TabIndex = 183
        Me.lblView.Text = "Record not found !!"
        Me.lblView.Visible = False
        '
        'dgvAdjustmentView
        '
        Me.dgvAdjustmentView.AllowUserToAddRows = False
        Me.dgvAdjustmentView.AllowUserToDeleteRows = False
        Me.dgvAdjustmentView.AllowUserToResizeRows = False
        Me.dgvAdjustmentView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAdjustmentView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvAdjustmentView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdjustmentView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAdjustmentView.ColumnHeadersHeight = 30
        Me.dgvAdjustmentView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gvAdjustmentDate, Me.gvStockID, Me.gvAdjustmentNo, Me.gvEstate, Me.gvAdjQty, Me.gvAdjValue, Me.dgclStockId, Me.gvRejectedReason, Me.gvCOAID, Me.gvYOPID, Me.gvDIVID, Me.gvBlockID, Me.gvT0, Me.gvT1, Me.gvT2, Me.gvT3, Me.gvT4, Me.gvRemarks, Me.gvSTAdjustmentID, Me.gvStockCode, Me.gvStatus})
        Me.dgvAdjustmentView.ContextMenuStrip = Me.cmsAdjust
        Me.dgvAdjustmentView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAdjustmentView.EnableHeadersVisualStyles = False
        Me.dgvAdjustmentView.GridColor = System.Drawing.Color.Gray
        Me.dgvAdjustmentView.Location = New System.Drawing.Point(4, 194)
        Me.dgvAdjustmentView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvAdjustmentView.MultiSelect = False
        Me.dgvAdjustmentView.Name = "dgvAdjustmentView"
        Me.dgvAdjustmentView.ReadOnly = True
        Me.dgvAdjustmentView.RowHeadersVisible = False
        Me.dgvAdjustmentView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAdjustmentView.Size = New System.Drawing.Size(1688, 777)
        Me.dgvAdjustmentView.TabIndex = 182
        Me.dgvAdjustmentView.TabStop = False
        '
        'gvAdjustmentDate
        '
        Me.gvAdjustmentDate.DataPropertyName = "AdjustmentDate"
        Me.gvAdjustmentDate.HeaderText = "Adjustment Date"
        Me.gvAdjustmentDate.Name = "gvAdjustmentDate"
        Me.gvAdjustmentDate.ReadOnly = True
        Me.gvAdjustmentDate.Width = 150
        '
        'gvStockID
        '
        Me.gvStockID.DataPropertyName = "StockID"
        Me.gvStockID.HeaderText = "StockID"
        Me.gvStockID.Name = "gvStockID"
        Me.gvStockID.ReadOnly = True
        Me.gvStockID.Visible = False
        '
        'gvAdjustmentNo
        '
        Me.gvAdjustmentNo.DataPropertyName = "AdjustmentNo"
        Me.gvAdjustmentNo.HeaderText = "Adjustment No"
        Me.gvAdjustmentNo.Name = "gvAdjustmentNo"
        Me.gvAdjustmentNo.ReadOnly = True
        Me.gvAdjustmentNo.Width = 150
        '
        'gvEstate
        '
        Me.gvEstate.DataPropertyName = "EstateName"
        Me.gvEstate.HeaderText = "Estate"
        Me.gvEstate.Name = "gvEstate"
        Me.gvEstate.ReadOnly = True
        Me.gvEstate.Visible = False
        '
        'gvAdjQty
        '
        Me.gvAdjQty.DataPropertyName = "AdjQty"
        Me.gvAdjQty.HeaderText = "Adjust Qty"
        Me.gvAdjQty.Name = "gvAdjQty"
        Me.gvAdjQty.ReadOnly = True
        Me.gvAdjQty.Visible = False
        Me.gvAdjQty.Width = 150
        '
        'gvAdjValue
        '
        Me.gvAdjValue.DataPropertyName = "AdjValue"
        Me.gvAdjValue.HeaderText = "Adjust Value"
        Me.gvAdjValue.Name = "gvAdjValue"
        Me.gvAdjValue.ReadOnly = True
        Me.gvAdjValue.Visible = False
        Me.gvAdjValue.Width = 150
        '
        'dgclStockId
        '
        Me.dgclStockId.DataPropertyName = "StockID"
        Me.dgclStockId.HeaderText = "StockID"
        Me.dgclStockId.Name = "dgclStockId"
        Me.dgclStockId.ReadOnly = True
        Me.dgclStockId.Visible = False
        '
        'gvRejectedReason
        '
        Me.gvRejectedReason.DataPropertyName = "RejectedReason"
        Me.gvRejectedReason.HeaderText = "RejectedReason"
        Me.gvRejectedReason.Name = "gvRejectedReason"
        Me.gvRejectedReason.ReadOnly = True
        Me.gvRejectedReason.Visible = False
        '
        'gvCOAID
        '
        Me.gvCOAID.DataPropertyName = "COAID"
        Me.gvCOAID.HeaderText = "COAID"
        Me.gvCOAID.Name = "gvCOAID"
        Me.gvCOAID.ReadOnly = True
        Me.gvCOAID.Visible = False
        '
        'gvYOPID
        '
        Me.gvYOPID.DataPropertyName = "YOPID"
        Me.gvYOPID.HeaderText = "YOPID"
        Me.gvYOPID.Name = "gvYOPID"
        Me.gvYOPID.ReadOnly = True
        Me.gvYOPID.Visible = False
        '
        'gvDIVID
        '
        Me.gvDIVID.DataPropertyName = "DIVID"
        Me.gvDIVID.HeaderText = "Afdeling ID"
        Me.gvDIVID.Name = "gvDIVID"
        Me.gvDIVID.ReadOnly = True
        Me.gvDIVID.Visible = False
        '
        'gvBlockID
        '
        Me.gvBlockID.DataPropertyName = "BlockID"
        Me.gvBlockID.HeaderText = "FieldNoID"
        Me.gvBlockID.Name = "gvBlockID"
        Me.gvBlockID.ReadOnly = True
        Me.gvBlockID.Visible = False
        '
        'gvT0
        '
        Me.gvT0.DataPropertyName = "T0Value"
        Me.gvT0.HeaderText = "T0"
        Me.gvT0.Name = "gvT0"
        Me.gvT0.ReadOnly = True
        Me.gvT0.Visible = False
        '
        'gvT1
        '
        Me.gvT1.DataPropertyName = "T1Value"
        Me.gvT1.HeaderText = "T1"
        Me.gvT1.Name = "gvT1"
        Me.gvT1.ReadOnly = True
        Me.gvT1.Visible = False
        '
        'gvT2
        '
        Me.gvT2.DataPropertyName = "T2Value"
        Me.gvT2.HeaderText = "T2"
        Me.gvT2.Name = "gvT2"
        Me.gvT2.ReadOnly = True
        Me.gvT2.Visible = False
        '
        'gvT3
        '
        Me.gvT3.DataPropertyName = "T3Value"
        Me.gvT3.HeaderText = "T3"
        Me.gvT3.Name = "gvT3"
        Me.gvT3.ReadOnly = True
        Me.gvT3.Visible = False
        '
        'gvT4
        '
        Me.gvT4.DataPropertyName = "T4Value"
        Me.gvT4.HeaderText = "T4"
        Me.gvT4.Name = "gvT4"
        Me.gvT4.ReadOnly = True
        Me.gvT4.Visible = False
        '
        'gvRemarks
        '
        Me.gvRemarks.DataPropertyName = "Remarks"
        Me.gvRemarks.HeaderText = "Remarks"
        Me.gvRemarks.Name = "gvRemarks"
        Me.gvRemarks.ReadOnly = True
        '
        'gvSTAdjustmentID
        '
        Me.gvSTAdjustmentID.DataPropertyName = "STAdjustmentID"
        Me.gvSTAdjustmentID.HeaderText = "STAdjustmentID"
        Me.gvSTAdjustmentID.Name = "gvSTAdjustmentID"
        Me.gvSTAdjustmentID.ReadOnly = True
        Me.gvSTAdjustmentID.Visible = False
        '
        'gvStockCode
        '
        Me.gvStockCode.DataPropertyName = "StockCode"
        Me.gvStockCode.HeaderText = "StockCode"
        Me.gvStockCode.Name = "gvStockCode"
        Me.gvStockCode.ReadOnly = True
        Me.gvStockCode.Visible = False
        '
        'gvStatus
        '
        Me.gvStatus.DataPropertyName = "Status"
        Me.gvStatus.HeaderText = "Status"
        Me.gvStatus.Name = "gvStatus"
        Me.gvStatus.ReadOnly = True
        '
        'PnlSearch
        '
        Me.PnlSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PnlSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.PnlSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PnlSearch.BorderColor = System.Drawing.Color.Gray
        Me.PnlSearch.CaptionColorOne = System.Drawing.Color.White
        Me.PnlSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PnlSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlSearch.CaptionSize = 40
        Me.PnlSearch.CaptionText = "Search Stock Adjustment"
        Me.PnlSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.PnlSearch.Controls.Add(Me.Panel1)
        Me.PnlSearch.Controls.Add(Me.cmbAdjustViewStatus)
        Me.PnlSearch.Controls.Add(Me.lblViewStatus)
        Me.PnlSearch.Controls.Add(Me.chkAdjustDate)
        Me.PnlSearch.Controls.Add(Me.lblSearch)
        Me.PnlSearch.Controls.Add(Me.dtpAdjustmentViewDate)
        Me.PnlSearch.Controls.Add(Me.Label36)
        Me.PnlSearch.Controls.Add(Me.txtAdjusViewtNo)
        Me.PnlSearch.Controls.Add(Me.btnView)
        Me.PnlSearch.Controls.Add(Me.lblAdjSearchNo)
        Me.PnlSearch.Controls.Add(Me.btnAdjustSearch)
        Me.PnlSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.PnlSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.PnlSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlSearch.Location = New System.Drawing.Point(4, 5)
        Me.PnlSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.PnlSearch.Moveable = True
        Me.PnlSearch.Name = "PnlSearch"
        Me.PnlSearch.Size = New System.Drawing.Size(1688, 189)
        Me.PnlSearch.TabIndex = 40
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridView2)
        Me.Panel1.Location = New System.Drawing.Point(0, 242)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1686, 654)
        Me.Panel1.TabIndex = 33
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(4, 5)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(1677, 880)
        Me.DataGridView2.TabIndex = 31
        '
        'cmbAdjustViewStatus
        '
        Me.cmbAdjustViewStatus.FormattingEnabled = True
        Me.cmbAdjustViewStatus.Items.AddRange(New Object() {"SELECT ALL", "OPEN", "MANAGER APPROVED", "REJECTED"})
        Me.cmbAdjustViewStatus.Location = New System.Drawing.Point(656, 131)
        Me.cmbAdjustViewStatus.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbAdjustViewStatus.Name = "cmbAdjustViewStatus"
        Me.cmbAdjustViewStatus.Size = New System.Drawing.Size(226, 28)
        Me.cmbAdjustViewStatus.TabIndex = 403
        Me.cmbAdjustViewStatus.Text = "SELECT ALL"
        '
        'lblViewStatus
        '
        Me.lblViewStatus.AutoSize = True
        Me.lblViewStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblViewStatus.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblViewStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblViewStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblViewStatus.Location = New System.Drawing.Point(654, 97)
        Me.lblViewStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblViewStatus.Name = "lblViewStatus"
        Me.lblViewStatus.Size = New System.Drawing.Size(65, 20)
        Me.lblViewStatus.TabIndex = 91
        Me.lblViewStatus.Text = "Status"
        '
        'chkAdjustDate
        '
        Me.chkAdjustDate.AutoSize = True
        Me.chkAdjustDate.Location = New System.Drawing.Point(160, 97)
        Me.chkAdjustDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkAdjustDate.Name = "chkAdjustDate"
        Me.chkAdjustDate.Size = New System.Drawing.Size(182, 24)
        Me.chkAdjustDate.TabIndex = 400
        Me.chkAdjustDate.Text = "Adjustment Date"
        Me.chkAdjustDate.UseVisualStyleBackColor = True
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearch.Location = New System.Drawing.Point(3, 69)
        Me.lblSearch.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(103, 20)
        Me.lblSearch.TabIndex = 69
        Me.lblSearch.Text = "Search By"
        '
        'dtpAdjustmentViewDate
        '
        Me.dtpAdjustmentViewDate.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.dtpAdjustmentViewDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpAdjustmentViewDate.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.dtpAdjustmentViewDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpAdjustmentViewDate.Enabled = False
        Me.dtpAdjustmentViewDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdjustmentViewDate.Location = New System.Drawing.Point(160, 132)
        Me.dtpAdjustmentViewDate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpAdjustmentViewDate.Name = "dtpAdjustmentViewDate"
        Me.dtpAdjustmentViewDate.Size = New System.Drawing.Size(200, 28)
        Me.dtpAdjustmentViewDate.TabIndex = 401
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label36.Location = New System.Drawing.Point(120, 69)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(18, 22)
        Me.Label36.TabIndex = 70
        Me.Label36.Text = ":"
        '
        'txtAdjusViewtNo
        '
        Me.txtAdjusViewtNo.Location = New System.Drawing.Point(417, 132)
        Me.txtAdjusViewtNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtAdjusViewtNo.Name = "txtAdjusViewtNo"
        Me.txtAdjusViewtNo.Size = New System.Drawing.Size(192, 28)
        Me.txtAdjusViewtNo.TabIndex = 402
        '
        'btnView
        '
        Me.btnView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(1150, 123)
        Me.btnView.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(174, 45)
        Me.btnView.TabIndex = 405
        Me.btnView.Text = "View Report"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'lblAdjSearchNo
        '
        Me.lblAdjSearchNo.AutoSize = True
        Me.lblAdjSearchNo.BackColor = System.Drawing.Color.Transparent
        Me.lblAdjSearchNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblAdjSearchNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAdjSearchNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAdjSearchNo.Location = New System.Drawing.Point(416, 98)
        Me.lblAdjSearchNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdjSearchNo.Name = "lblAdjSearchNo"
        Me.lblAdjSearchNo.Size = New System.Drawing.Size(139, 20)
        Me.lblAdjSearchNo.TabIndex = 74
        Me.lblAdjSearchNo.Text = "Adjustment No"
        '
        'btnAdjustSearch
        '
        Me.btnAdjustSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdjustSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnAdjustSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnAdjustSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnAdjustSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdjustSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnAdjustSearch.Image = CType(resources.GetObject("btnAdjustSearch.Image"), System.Drawing.Image)
        Me.btnAdjustSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdjustSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAdjustSearch.Location = New System.Drawing.Point(950, 125)
        Me.btnAdjustSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAdjustSearch.Name = "btnAdjustSearch"
        Me.btnAdjustSearch.Size = New System.Drawing.Size(174, 45)
        Me.btnAdjustSearch.TabIndex = 404
        Me.btnAdjustSearch.Text = "Search"
        Me.btnAdjustSearch.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(558, 354)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 26)
        Me.Button1.TabIndex = 168
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(797, 78)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stock Adjustment"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(150, 45)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(236, 29)
        Me.TextBox1.TabIndex = 13
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(150, 15)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(135, 28)
        Me.TextBox2.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(512, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(16, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(512, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 20)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(547, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 20)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "OPEN"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(118, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(118, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(16, 20)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = ":"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(547, 15)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(135, 26)
        Me.DateTimePicker1.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(407, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 20)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(407, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(156, 20)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "Adjustment Date"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 20)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Remarks"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(19, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(139, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Adjustment No"
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(419, 359)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(135, 28)
        Me.TextBox3.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(288, 359)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Stock Code"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(387, 359)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = ":"
        '
        'cmbStatusSearch
        '
        Me.cmbStatusSearch.FormattingEnabled = True
        Me.cmbStatusSearch.Items.AddRange(New Object() {"SELECT ALL", "OPEN", "MANAGER APPROVED", "REJECTED"})
        Me.cmbStatusSearch.Location = New System.Drawing.Point(545, 67)
        Me.cmbStatusSearch.Name = "cmbStatusSearch"
        Me.cmbStatusSearch.Size = New System.Drawing.Size(169, 28)
        Me.cmbStatusSearch.TabIndex = 90
        '
        'lblStatusSearch
        '
        Me.lblStatusSearch.AutoSize = True
        Me.lblStatusSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblStatusSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblStatusSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblStatusSearch.Location = New System.Drawing.Point(542, 45)
        Me.lblStatusSearch.Name = "lblStatusSearch"
        Me.lblStatusSearch.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusSearch.TabIndex = 91
        Me.lblStatusSearch.Text = "Status"
        '
        'chkViewSIVDate
        '
        Me.chkViewSIVDate.AutoSize = True
        Me.chkViewSIVDate.Location = New System.Drawing.Point(94, 45)
        Me.chkViewSIVDate.Name = "chkViewSIVDate"
        Me.chkViewSIVDate.Size = New System.Drawing.Size(69, 17)
        Me.chkViewSIVDate.TabIndex = 1
        Me.chkViewSIVDate.Text = "SIV Date"
        Me.chkViewSIVDate.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(0, 157)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1124, 425)
        Me.Panel2.TabIndex = 33
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1118, 572)
        Me.DataGridView1.TabIndex = 31
        '
        'txtSIVDateSearch
        '
        Me.txtSIVDateSearch.CalendarFont = New System.Drawing.Font("Verdana", 7.5!)
        Me.txtSIVDateSearch.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSIVDateSearch.CalendarTitleForeColor = System.Drawing.Color.DimGray
        Me.txtSIVDateSearch.CustomFormat = "dd/MM/yyyy"
        Me.txtSIVDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtSIVDateSearch.Location = New System.Drawing.Point(94, 67)
        Me.txtSIVDateSearch.Name = "txtSIVDateSearch"
        Me.txtSIVDateSearch.Size = New System.Drawing.Size(129, 26)
        Me.txtSIVDateSearch.TabIndex = 2
        '
        'txtSIVNoSearch
        '
        Me.txtSIVNoSearch.Location = New System.Drawing.Point(229, 67)
        Me.txtSIVNoSearch.Name = "txtSIVNoSearch"
        Me.txtSIVNoSearch.Size = New System.Drawing.Size(129, 26)
        Me.txtSIVNoSearch.TabIndex = 3
        '
        'txtContractNoSearch
        '
        Me.txtContractNoSearch.Location = New System.Drawing.Point(366, 67)
        Me.txtContractNoSearch.Name = "txtContractNoSearch"
        Me.txtContractNoSearch.Size = New System.Drawing.Size(169, 26)
        Me.txtContractNoSearch.TabIndex = 4
        '
        'lblSearchBy
        '
        Me.lblSearchBy.AutoSize = True
        Me.lblSearchBy.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchBy.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchBy.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchBy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchBy.Location = New System.Drawing.Point(2, 45)
        Me.lblSearchBy.Name = "lblSearchBy"
        Me.lblSearchBy.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchBy.TabIndex = 69
        Me.lblSearchBy.Text = "Search By"
        '
        'lblContractNoSearch
        '
        Me.lblContractNoSearch.AutoSize = True
        Me.lblContractNoSearch.BackColor = System.Drawing.Color.Transparent
        Me.lblContractNoSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblContractNoSearch.ForeColor = System.Drawing.Color.DimGray
        Me.lblContractNoSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblContractNoSearch.Location = New System.Drawing.Point(366, 45)
        Me.lblContractNoSearch.Name = "lblContractNoSearch"
        Me.lblContractNoSearch.Size = New System.Drawing.Size(75, 13)
        Me.lblContractNoSearch.TabIndex = 83
        Me.lblContractNoSearch.Text = "Contract No"
        '
        'lblSIVNoSerach
        '
        Me.lblSIVNoSerach.AutoSize = True
        Me.lblSIVNoSerach.BackColor = System.Drawing.Color.Transparent
        Me.lblSIVNoSerach.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.lblSIVNoSerach.ForeColor = System.Drawing.Color.DimGray
        Me.lblSIVNoSerach.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSIVNoSerach.Location = New System.Drawing.Point(229, 45)
        Me.lblSIVNoSerach.Name = "lblSIVNoSerach"
        Me.lblSIVNoSerach.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNoSerach.TabIndex = 74
        Me.lblSIVNoSerach.Text = "SIV No"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(80, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(12, 14)
        Me.Label25.TabIndex = 70
        Me.Label25.Text = ":"
        '
        'btnViewReport
        '
        Me.btnViewReport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnViewReport.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnViewReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnViewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewReport.Image = CType(resources.GetObject("btnViewReport.Image"), System.Drawing.Image)
        Me.btnViewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnViewReport.Location = New System.Drawing.Point(862, 67)
        Me.btnViewReport.Name = "btnViewReport"
        Me.btnViewReport.Size = New System.Drawing.Size(116, 29)
        Me.btnViewReport.TabIndex = 7
        Me.btnViewReport.Text = "View Report"
        Me.btnViewReport.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearch.Location = New System.Drawing.Point(737, 67)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 29)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'StockAdjustmentFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1704, 1009)
        Me.Controls.Add(Me.tbStockAdjustment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "StockAdjustmentFrm"
        Me.Text = "Stock Adjustment Screen"
        Me.tbStockAdjustment.ResumeLayout(False)
        Me.tbpgAdd.ResumeLayout(False)
        Me.tbpgAdd.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvAdjustDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAdjust.ResumeLayout(False)
        Me.cmsSTAAddEdit.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.grpApproval.ResumeLayout(False)
        Me.grpApproval.PerformLayout()
        Me.grpRGN.ResumeLayout(False)
        Me.grpRGN.PerformLayout()
        Me.tbSAView.ResumeLayout(False)
        Me.tbSAView.PerformLayout()
        CType(Me.dgvAdjustmentView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlSearch.ResumeLayout(False)
        Me.PnlSearch.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbStockAdjustment As System.Windows.Forms.TabControl
    Friend WithEvents tbpgAdd As System.Windows.Forms.TabPage
    Friend WithEvents tbSAView As System.Windows.Forms.TabPage
    Friend WithEvents grpRGN As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearchStockCode As System.Windows.Forms.Button
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtAdjustmentNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpAdjustmentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAdjustmentStatus As System.Windows.Forms.Label
    Friend WithEvents lblAdjustmentDate As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents lblAdjustmentNo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblStockDescription As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblAdjQty As System.Windows.Forms.Label
    Friend WithEvents txtAdjValue As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblAdjValue As System.Windows.Forms.Label
    Friend WithEvents txtAdjQty As System.Windows.Forms.TextBox
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblAdjustmentUnit As System.Windows.Forms.Label
    Friend WithEvents grpApproval As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtRejectedReason As System.Windows.Forms.TextBox
    Friend WithEvents lblRejectedReason As System.Windows.Forms.Label
    Friend WithEvents lblApprovalStatus As System.Windows.Forms.Label
    Friend WithEvents cmbStatusSearch As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusSearch As System.Windows.Forms.Label
    Friend WithEvents chkViewSIVDate As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtSIVDateSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSIVNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtContractNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblSearchBy As System.Windows.Forms.Label
    Friend WithEvents lblContractNoSearch As System.Windows.Forms.Label
    Friend WithEvents lblSIVNoSerach As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents btnViewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents PnlSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents cmbAdjustViewStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblViewStatus As System.Windows.Forms.Label
    Friend WithEvents chkAdjustDate As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents dtpAdjustmentViewDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtAdjusViewtNo As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblAdjSearchNo As System.Windows.Forms.Label
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnAdjustSearch As System.Windows.Forms.Button
    Friend WithEvents dgvAdjustmentView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetIB As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblView As System.Windows.Forms.Label
    Friend WithEvents cmsAdjust As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents dgvAdjustDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblAccountDesc As System.Windows.Forms.Label
    Friend WithEvents lblT4Name As System.Windows.Forms.Label
    Friend WithEvents lblT3Name As System.Windows.Forms.Label
    Friend WithEvents lblT2Name As System.Windows.Forms.Label
    Friend WithEvents lblT1Name As System.Windows.Forms.Label
    Friend WithEvents lblT0Name As System.Windows.Forms.Label
    Friend WithEvents btnSearchT4 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT3 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT2 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT1 As System.Windows.Forms.Button
    Friend WithEvents btnSearchT0 As System.Windows.Forms.Button
    Friend WithEvents txtT4 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents lblT4 As System.Windows.Forms.Label
    Friend WithEvents txtT3 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents lblT3 As System.Windows.Forms.Label
    Friend WithEvents txtT2 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents lblT2 As System.Windows.Forms.Label
    Friend WithEvents txtT1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblT1 As System.Windows.Forms.Label
    Friend WithEvents txtT0 As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchAcCode As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents lblAccountCode As System.Windows.Forms.Label
    Friend WithEvents lblT0 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents rdbtnDecrease As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtnIncrease As System.Windows.Forms.RadioButton
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearchSubBlock As System.Windows.Forms.Button
    Friend WithEvents lblYOPName As System.Windows.Forms.Label
    Friend WithEvents lblDivName As System.Windows.Forms.Label
    Friend WithEvents txtSubBlock As System.Windows.Forms.TextBox
    Friend WithEvents txtDiv As System.Windows.Forms.TextBox
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblSubBlock As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblDIV As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lblYOP As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblAvailableQty As System.Windows.Forms.Label
    Friend WithEvents lblPartNoDesc As System.Windows.Forms.Label
    Friend WithEvents lblAvailableDesc As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblOldCOA As System.Windows.Forms.Label
    Friend WithEvents lblOldCOACode As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents gvAdjustmentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvAdjustmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvEstate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvAdjQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvAdjValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclStockId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvRejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvDIVID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvBlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvSTAdjustmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gvStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblRejectedReason1 As System.Windows.Forms.Label
    Friend WithEvents lblRejectedReasonValue As System.Windows.Forms.Label
    Friend WithEvents lblRejReasonColon As System.Windows.Forms.Label
    Friend WithEvents cmsSTAAddEdit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DelToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBeritaAcaraAudit As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents STAStockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAStockDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAvailableQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAdjustVal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAdjQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAUnit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAccountCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAccountDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAOldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAdjustmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAdjustmentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STARemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STASubBlock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STADivDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STASTAdjustmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT0Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT1Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT2Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT3Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT4Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAAccountID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STACategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAVarianceCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STADIV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAYOP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAYOPName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAStockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STARejectedReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STACOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAYOPID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STADIVID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STABlockID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT0Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT1Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT2Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT3Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAT4Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STAStockCOAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STASTDPrice As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaterialsWithTeam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MaterialsWithTeam))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcMaterial = New System.Windows.Forms.TabControl
        Me.tabMaterial = New System.Windows.Forms.TabPage
        Me.lblCOAID = New System.Windows.Forms.Label
        Me.btnRpt = New System.Windows.Forms.Button
        Me.lblStockDescp = New System.Windows.Forms.Label
        Me.btnStock = New System.Windows.Forms.Button
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.txtIssueQty = New System.Windows.Forms.TextBox
        Me.txtCOACode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUom3 = New System.Windows.Forms.Label
        Me.lblBalanceQty = New System.Windows.Forms.Label
        Me.lblColon10 = New System.Windows.Forms.Label
        Me.txtBalanceQty = New System.Windows.Forms.TextBox
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.lblUom2 = New System.Windows.Forms.Label
        Me.lblUom1 = New System.Windows.Forms.Label
        Me.lblUsageQty = New System.Windows.Forms.Label
        Me.lblColon9 = New System.Windows.Forms.Label
        Me.txtUsageQty = New System.Windows.Forms.TextBox
        Me.lblIssuedQty = New System.Windows.Forms.Label
        Me.lblColon8 = New System.Windows.Forms.Label
        Me.txtStockCode = New System.Windows.Forms.TextBox
        Me.lblSIVNo = New System.Windows.Forms.Label
        Me.txtSIVNo = New System.Windows.Forms.TextBox
        Me.lblStockCode = New System.Windows.Forms.Label
        Me.lblColon7 = New System.Windows.Forms.Label
        Me.lblColon6 = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblKraniEmpName = New System.Windows.Forms.Label
        Me.lblMandorEmpName = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.lblEmpId = New System.Windows.Forms.Label
        Me.lblTeam = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtGangName = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.lblGangMasterID = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.gbEnquipmentData = New System.Windows.Forms.GroupBox
        Me.dgvMaterial = New System.Windows.Forms.DataGridView
        Me.SivNoColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockCodeColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StockDescColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IssueQtyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UsageQtyColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.txtChange = New System.Windows.Forms.TextBox
        Me.lblMaterialUsageID = New System.Windows.Forms.Label
        Me.lblDailyDistributionID = New System.Windows.Forms.Label
        Me.ScreenCtrl = New System.Windows.Forms.TextBox
        Me.lblStockID = New System.Windows.Forms.Label
        Me.tcMaterial.SuspendLayout()
        Me.tabMaterial.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gbEnquipmentData.SuspendLayout()
        CType(Me.dgvMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcMaterial
        '
        Me.tcMaterial.Controls.Add(Me.tabMaterial)
        Me.tcMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcMaterial.Location = New System.Drawing.Point(0, 0)
        Me.tcMaterial.Name = "tcMaterial"
        Me.tcMaterial.SelectedIndex = 0
        Me.tcMaterial.Size = New System.Drawing.Size(845, 610)
        Me.tcMaterial.TabIndex = 202
        '
        'tabMaterial
        '
        Me.tabMaterial.AutoScroll = True
        Me.tabMaterial.BackColor = System.Drawing.Color.Transparent
        Me.tabMaterial.BackgroundImage = CType(resources.GetObject("tabMaterial.BackgroundImage"), System.Drawing.Image)
        Me.tabMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabMaterial.Controls.Add(Me.lblCOAID)
        Me.tabMaterial.Controls.Add(Me.btnRpt)
        Me.tabMaterial.Controls.Add(Me.lblStockDescp)
        Me.tabMaterial.Controls.Add(Me.btnStock)
        Me.tabMaterial.Controls.Add(Me.lblCOADescp)
        Me.tabMaterial.Controls.Add(Me.btnAdd)
        Me.tabMaterial.Controls.Add(Me.txtIssueQty)
        Me.tabMaterial.Controls.Add(Me.txtCOACode)
        Me.tabMaterial.Controls.Add(Me.Label1)
        Me.tabMaterial.Controls.Add(Me.Label2)
        Me.tabMaterial.Controls.Add(Me.lblUom3)
        Me.tabMaterial.Controls.Add(Me.lblBalanceQty)
        Me.tabMaterial.Controls.Add(Me.lblColon10)
        Me.tabMaterial.Controls.Add(Me.txtBalanceQty)
        Me.tabMaterial.Controls.Add(Me.btnSaveAll)
        Me.tabMaterial.Controls.Add(Me.lblUom2)
        Me.tabMaterial.Controls.Add(Me.lblUom1)
        Me.tabMaterial.Controls.Add(Me.lblUsageQty)
        Me.tabMaterial.Controls.Add(Me.lblColon9)
        Me.tabMaterial.Controls.Add(Me.txtUsageQty)
        Me.tabMaterial.Controls.Add(Me.lblIssuedQty)
        Me.tabMaterial.Controls.Add(Me.lblColon8)
        Me.tabMaterial.Controls.Add(Me.txtStockCode)
        Me.tabMaterial.Controls.Add(Me.lblSIVNo)
        Me.tabMaterial.Controls.Add(Me.txtSIVNo)
        Me.tabMaterial.Controls.Add(Me.lblStockCode)
        Me.tabMaterial.Controls.Add(Me.lblColon7)
        Me.tabMaterial.Controls.Add(Me.lblColon6)
        Me.tabMaterial.Controls.Add(Me.btnReset)
        Me.tabMaterial.Controls.Add(Me.GroupBox1)
        Me.tabMaterial.Controls.Add(Me.btnClose)
        Me.tabMaterial.Controls.Add(Me.gbEnquipmentData)
        Me.tabMaterial.Controls.Add(Me.btnUpdate)
        Me.tabMaterial.Controls.Add(Me.txtChange)
        Me.tabMaterial.Controls.Add(Me.lblMaterialUsageID)
        Me.tabMaterial.Controls.Add(Me.lblDailyDistributionID)
        Me.tabMaterial.Controls.Add(Me.ScreenCtrl)
        Me.tabMaterial.Controls.Add(Me.lblStockID)
        Me.tabMaterial.Location = New System.Drawing.Point(4, 22)
        Me.tabMaterial.Name = "tabMaterial"
        Me.tabMaterial.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMaterial.Size = New System.Drawing.Size(837, 584)
        Me.tabMaterial.TabIndex = 0
        Me.tabMaterial.Text = "Material"
        Me.tabMaterial.UseVisualStyleBackColor = True
        '
        'lblCOAID
        '
        Me.lblCOAID.AutoSize = True
        Me.lblCOAID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOAID.ForeColor = System.Drawing.Color.Blue
        Me.lblCOAID.Location = New System.Drawing.Point(482, 114)
        Me.lblCOAID.Name = "lblCOAID"
        Me.lblCOAID.Size = New System.Drawing.Size(60, 13)
        Me.lblCOAID.TabIndex = 194
        Me.lblCOAID.Text = "lblCOAID"
        Me.lblCOAID.Visible = False
        '
        'btnRpt
        '
        Me.btnRpt.BackgroundImage = CType(resources.GetObject("btnRpt.BackgroundImage"), System.Drawing.Image)
        Me.btnRpt.Enabled = False
        Me.btnRpt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRpt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRpt.ForeColor = System.Drawing.Color.Black
        Me.btnRpt.Image = CType(resources.GetObject("btnRpt.Image"), System.Drawing.Image)
        Me.btnRpt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRpt.Location = New System.Drawing.Point(245, 526)
        Me.btnRpt.Name = "btnRpt"
        Me.btnRpt.Size = New System.Drawing.Size(126, 28)
        Me.btnRpt.TabIndex = 11
        Me.btnRpt.Text = "View Report"
        Me.btnRpt.UseVisualStyleBackColor = True
        '
        'lblStockDescp
        '
        Me.lblStockDescp.AutoSize = True
        Me.lblStockDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblStockDescp.Location = New System.Drawing.Point(327, 169)
        Me.lblStockDescp.Name = "lblStockDescp"
        Me.lblStockDescp.Size = New System.Drawing.Size(78, 13)
        Me.lblStockDescp.TabIndex = 196
        Me.lblStockDescp.Text = "Stock Descp"
        '
        'btnStock
        '
        Me.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStock.Image = CType(resources.GetObject("btnStock.Image"), System.Drawing.Image)
        Me.btnStock.Location = New System.Drawing.Point(288, 162)
        Me.btnStock.Name = "btnStock"
        Me.btnStock.Size = New System.Drawing.Size(30, 26)
        Me.btnStock.TabIndex = 4
        Me.btnStock.TabStop = False
        Me.btnStock.UseVisualStyleBackColor = True
        '
        'lblCOADescp
        '
        Me.lblCOADescp.AutoSize = True
        Me.lblCOADescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOADescp.ForeColor = System.Drawing.Color.Blue
        Me.lblCOADescp.Location = New System.Drawing.Point(288, 114)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(81, 13)
        Me.lblCOADescp.TabIndex = 192
        Me.lblCOADescp.Text = "lblCOADescp"
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(18, 278)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 30)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtIssueQty
        '
        Me.txtIssueQty.BackColor = System.Drawing.Color.White
        Me.txtIssueQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssueQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueQty.Location = New System.Drawing.Point(144, 190)
        Me.txtIssueQty.MaxLength = 50
        Me.txtIssueQty.Name = "txtIssueQty"
        Me.txtIssueQty.Size = New System.Drawing.Size(76, 21)
        Me.txtIssueQty.TabIndex = 5
        '
        'txtCOACode
        '
        Me.txtCOACode.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtCOACode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCOACode.Enabled = False
        Me.txtCOACode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCOACode.Location = New System.Drawing.Point(144, 112)
        Me.txtCOACode.MaxLength = 50
        Me.txtCOACode.Name = "txtCOACode"
        Me.txtCOACode.Size = New System.Drawing.Size(138, 21)
        Me.txtCOACode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(22, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Activity"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = ":"
        '
        'lblUom3
        '
        Me.lblUom3.AutoSize = True
        Me.lblUom3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUom3.Location = New System.Drawing.Point(229, 248)
        Me.lblUom3.Name = "lblUom3"
        Me.lblUom3.Size = New System.Drawing.Size(29, 13)
        Me.lblUom3.TabIndex = 151
        Me.lblUom3.Text = "Unit"
        '
        'lblBalanceQty
        '
        Me.lblBalanceQty.AutoSize = True
        Me.lblBalanceQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceQty.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceQty.Location = New System.Drawing.Point(23, 243)
        Me.lblBalanceQty.Name = "lblBalanceQty"
        Me.lblBalanceQty.Size = New System.Drawing.Size(76, 13)
        Me.lblBalanceQty.TabIndex = 149
        Me.lblBalanceQty.Text = "Balance Qty"
        '
        'lblColon10
        '
        Me.lblColon10.AutoSize = True
        Me.lblColon10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon10.Location = New System.Drawing.Point(127, 243)
        Me.lblColon10.Name = "lblColon10"
        Me.lblColon10.Size = New System.Drawing.Size(11, 13)
        Me.lblColon10.TabIndex = 150
        Me.lblColon10.Text = ":"
        '
        'txtBalanceQty
        '
        Me.txtBalanceQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtBalanceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceQty.Enabled = False
        Me.txtBalanceQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalanceQty.Location = New System.Drawing.Point(144, 244)
        Me.txtBalanceQty.MaxLength = 50
        Me.txtBalanceQty.Name = "txtBalanceQty"
        Me.txtBalanceQty.Size = New System.Drawing.Size(76, 21)
        Me.txtBalanceQty.TabIndex = 148
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(18, 526)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(105, 30)
        Me.btnSaveAll.TabIndex = 9
        Me.btnSaveAll.Text = "&Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'lblUom2
        '
        Me.lblUom2.AutoSize = True
        Me.lblUom2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUom2.Location = New System.Drawing.Point(229, 220)
        Me.lblUom2.Name = "lblUom2"
        Me.lblUom2.Size = New System.Drawing.Size(29, 13)
        Me.lblUom2.TabIndex = 146
        Me.lblUom2.Text = "Unit"
        '
        'lblUom1
        '
        Me.lblUom1.AutoSize = True
        Me.lblUom1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUom1.Location = New System.Drawing.Point(229, 194)
        Me.lblUom1.Name = "lblUom1"
        Me.lblUom1.Size = New System.Drawing.Size(29, 13)
        Me.lblUom1.TabIndex = 145
        Me.lblUom1.Text = "Unit"
        '
        'lblUsageQty
        '
        Me.lblUsageQty.AutoSize = True
        Me.lblUsageQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsageQty.ForeColor = System.Drawing.Color.Red
        Me.lblUsageQty.Location = New System.Drawing.Point(23, 217)
        Me.lblUsageQty.Name = "lblUsageQty"
        Me.lblUsageQty.Size = New System.Drawing.Size(66, 13)
        Me.lblUsageQty.TabIndex = 140
        Me.lblUsageQty.Text = "Usage Qty"
        '
        'lblColon9
        '
        Me.lblColon9.AutoSize = True
        Me.lblColon9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon9.Location = New System.Drawing.Point(127, 217)
        Me.lblColon9.Name = "lblColon9"
        Me.lblColon9.Size = New System.Drawing.Size(11, 13)
        Me.lblColon9.TabIndex = 141
        Me.lblColon9.Text = ":"
        '
        'txtUsageQty
        '
        Me.txtUsageQty.BackColor = System.Drawing.Color.White
        Me.txtUsageQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsageQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsageQty.Location = New System.Drawing.Point(144, 217)
        Me.txtUsageQty.MaxLength = 50
        Me.txtUsageQty.Name = "txtUsageQty"
        Me.txtUsageQty.Size = New System.Drawing.Size(76, 21)
        Me.txtUsageQty.TabIndex = 6
        '
        'lblIssuedQty
        '
        Me.lblIssuedQty.AutoSize = True
        Me.lblIssuedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuedQty.ForeColor = System.Drawing.Color.Red
        Me.lblIssuedQty.Location = New System.Drawing.Point(22, 194)
        Me.lblIssuedQty.Name = "lblIssuedQty"
        Me.lblIssuedQty.Size = New System.Drawing.Size(69, 13)
        Me.lblIssuedQty.TabIndex = 137
        Me.lblIssuedQty.Text = "Issued Qty"
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(127, 194)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(11, 13)
        Me.lblColon8.TabIndex = 138
        Me.lblColon8.Text = ":"
        '
        'txtStockCode
        '
        Me.txtStockCode.BackColor = System.Drawing.Color.White
        Me.txtStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCode.Location = New System.Drawing.Point(144, 165)
        Me.txtStockCode.MaxLength = 50
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(138, 21)
        Me.txtStockCode.TabIndex = 3
        '
        'lblSIVNo
        '
        Me.lblSIVNo.AutoSize = True
        Me.lblSIVNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVNo.ForeColor = System.Drawing.Color.Black
        Me.lblSIVNo.Location = New System.Drawing.Point(22, 141)
        Me.lblSIVNo.Name = "lblSIVNo"
        Me.lblSIVNo.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNo.TabIndex = 131
        Me.lblSIVNo.Text = "SIV No"
        '
        'txtSIVNo
        '
        Me.txtSIVNo.BackColor = System.Drawing.Color.White
        Me.txtSIVNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIVNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIVNo.Location = New System.Drawing.Point(144, 139)
        Me.txtSIVNo.MaxLength = 100
        Me.txtSIVNo.Name = "txtSIVNo"
        Me.txtSIVNo.Size = New System.Drawing.Size(138, 21)
        Me.txtSIVNo.TabIndex = 0
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.ForeColor = System.Drawing.Color.Red
        Me.lblStockCode.Location = New System.Drawing.Point(22, 167)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(73, 13)
        Me.lblStockCode.TabIndex = 132
        Me.lblStockCode.Text = "Stock Code"
        '
        'lblColon7
        '
        Me.lblColon7.AutoSize = True
        Me.lblColon7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon7.Location = New System.Drawing.Point(127, 167)
        Me.lblColon7.Name = "lblColon7"
        Me.lblColon7.Size = New System.Drawing.Size(11, 13)
        Me.lblColon7.TabIndex = 134
        Me.lblColon7.Text = ":"
        '
        'lblColon6
        '
        Me.lblColon6.AutoSize = True
        Me.lblColon6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon6.Location = New System.Drawing.Point(127, 143)
        Me.lblColon6.Name = "lblColon6"
        Me.lblColon6.Size = New System.Drawing.Size(11, 13)
        Me.lblColon6.TabIndex = 133
        Me.lblColon6.Text = ":"
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(119, 278)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(105, 30)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblKraniEmpName)
        Me.GroupBox1.Controls.Add(Me.lblMandorEmpName)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.lblEmpId)
        Me.GroupBox1.Controls.Add(Me.lblTeam)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtGangName)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblColon1)
        Me.GroupBox1.Controls.Add(Me.lblGangMasterID)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(822, 95)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        '
        'lblKraniEmpName
        '
        Me.lblKraniEmpName.AutoSize = True
        Me.lblKraniEmpName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKraniEmpName.ForeColor = System.Drawing.Color.Blue
        Me.lblKraniEmpName.Location = New System.Drawing.Point(599, 61)
        Me.lblKraniEmpName.Name = "lblKraniEmpName"
        Me.lblKraniEmpName.Size = New System.Drawing.Size(70, 13)
        Me.lblKraniEmpName.TabIndex = 205
        Me.lblKraniEmpName.Text = "KraniName"
        '
        'lblMandorEmpName
        '
        Me.lblMandorEmpName.AutoSize = True
        Me.lblMandorEmpName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandorEmpName.ForeColor = System.Drawing.Color.Blue
        Me.lblMandorEmpName.Location = New System.Drawing.Point(599, 39)
        Me.lblMandorEmpName.Name = "lblMandorEmpName"
        Me.lblMandorEmpName.Size = New System.Drawing.Size(89, 13)
        Me.lblMandorEmpName.TabIndex = 206
        Me.lblMandorEmpName.Text = "MandoreName"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(578, 61)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(11, 13)
        Me.Label25.TabIndex = 204
        Me.Label25.Text = ":"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(578, 39)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 203
        Me.Label23.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(479, 59)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(74, 13)
        Me.Label24.TabIndex = 201
        Me.Label24.Text = "Krani Name"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(479, 37)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(86, 13)
        Me.Label22.TabIndex = 202
        Me.Label22.Text = "Mandor Name"
        '
        'lblEmpId
        '
        Me.lblEmpId.AutoSize = True
        Me.lblEmpId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpId.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpId.Location = New System.Drawing.Point(285, 79)
        Me.lblEmpId.Name = "lblEmpId"
        Me.lblEmpId.Size = New System.Drawing.Size(79, 13)
        Me.lblEmpId.TabIndex = 200
        Me.lblEmpId.Text = "Employee Id"
        Me.lblEmpId.Visible = False
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeam.ForeColor = System.Drawing.Color.Black
        Me.lblTeam.Location = New System.Drawing.Point(20, 59)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(39, 13)
        Me.lblTeam.TabIndex = 197
        Me.lblTeam.Text = "Team"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(123, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 198
        Me.Label17.Text = ":"
        '
        'txtGangName
        '
        Me.txtGangName.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtGangName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGangName.Enabled = False
        Me.txtGangName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGangName.Location = New System.Drawing.Point(144, 56)
        Me.txtGangName.MaxLength = 50
        Me.txtGangName.Name = "txtGangName"
        Me.txtGangName.Size = New System.Drawing.Size(135, 21)
        Me.txtGangName.TabIndex = 199
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Enabled = False
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(144, 25)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(135, 20)
        Me.dtpDate.TabIndex = 196
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(123, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 13)
        Me.Label15.TabIndex = 167
        Me.Label15.Text = ":"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Black
        Me.lblDate.Location = New System.Drawing.Point(19, 28)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date"
        '
        'lblColon1
        '
        Me.lblColon1.AutoSize = True
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(123, 28)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(11, 13)
        Me.lblColon1.TabIndex = 19
        Me.lblColon1.Text = ":"
        '
        'lblGangMasterID
        '
        Me.lblGangMasterID.AutoSize = True
        Me.lblGangMasterID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGangMasterID.ForeColor = System.Drawing.Color.Blue
        Me.lblGangMasterID.Location = New System.Drawing.Point(282, 59)
        Me.lblGangMasterID.Name = "lblGangMasterID"
        Me.lblGangMasterID.Size = New System.Drawing.Size(102, 13)
        Me.lblGangMasterID.TabIndex = 143
        Me.lblGangMasterID.Text = "lblGangMasterID"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(129, 526)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(110, 30)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbEnquipmentData
        '
        Me.gbEnquipmentData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbEnquipmentData.Controls.Add(Me.dgvMaterial)
        Me.gbEnquipmentData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEnquipmentData.Location = New System.Drawing.Point(16, 310)
        Me.gbEnquipmentData.Name = "gbEnquipmentData"
        Me.gbEnquipmentData.Size = New System.Drawing.Size(809, 209)
        Me.gbEnquipmentData.TabIndex = 14
        Me.gbEnquipmentData.TabStop = False
        '
        'dgvMaterial
        '
        Me.dgvMaterial.AllowUserToAddRows = False
        Me.dgvMaterial.AllowUserToDeleteRows = False
        Me.dgvMaterial.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver
        Me.dgvMaterial.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMaterial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMaterial.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMaterial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMaterial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SivNoColumn, Me.StockCodeColumn, Me.StockDescColumn, Me.IssueQtyColumn, Me.UsageQtyColumn})
        Me.dgvMaterial.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMaterial.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMaterial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMaterial.EnableHeadersVisualStyles = False
        Me.dgvMaterial.GridColor = System.Drawing.Color.Gray
        Me.dgvMaterial.Location = New System.Drawing.Point(11, 17)
        Me.dgvMaterial.Name = "dgvMaterial"
        Me.dgvMaterial.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterial.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMaterial.RowHeadersVisible = False
        Me.dgvMaterial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaterial.ShowCellErrors = False
        Me.dgvMaterial.Size = New System.Drawing.Size(787, 186)
        Me.dgvMaterial.TabIndex = 126
        '
        'SivNoColumn
        '
        Me.SivNoColumn.DataPropertyName = "SIVNo"
        Me.SivNoColumn.HeaderText = "SIV No"
        Me.SivNoColumn.Name = "SivNoColumn"
        Me.SivNoColumn.ReadOnly = True
        Me.SivNoColumn.Width = 71
        '
        'StockCodeColumn
        '
        Me.StockCodeColumn.DataPropertyName = "StockCode"
        Me.StockCodeColumn.HeaderText = "Stock Code"
        Me.StockCodeColumn.Name = "StockCodeColumn"
        Me.StockCodeColumn.ReadOnly = True
        Me.StockCodeColumn.Width = 97
        '
        'StockDescColumn
        '
        Me.StockDescColumn.DataPropertyName = "StockDesc"
        Me.StockDescColumn.HeaderText = "Stock Descp"
        Me.StockDescColumn.Name = "StockDescColumn"
        Me.StockDescColumn.ReadOnly = True
        Me.StockDescColumn.Width = 102
        '
        'IssueQtyColumn
        '
        Me.IssueQtyColumn.DataPropertyName = "IssuedQty"
        Me.IssueQtyColumn.HeaderText = "Issue Qty"
        Me.IssueQtyColumn.Name = "IssueQtyColumn"
        Me.IssueQtyColumn.ReadOnly = True
        Me.IssueQtyColumn.Width = 86
        '
        'UsageQtyColumn
        '
        Me.UsageQtyColumn.DataPropertyName = "UsageQty"
        Me.UsageQtyColumn.HeaderText = "Usage Qty"
        Me.UsageQtyColumn.Name = "UsageQtyColumn"
        Me.UsageQtyColumn.ReadOnly = True
        Me.UsageQtyColumn.Width = 90
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'btnUpdate
        '
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(18, 278)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(95, 30)
        Me.btnUpdate.TabIndex = 198
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'txtChange
        '
        Me.txtChange.Location = New System.Drawing.Point(668, 42)
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Size = New System.Drawing.Size(74, 20)
        Me.txtChange.TabIndex = 201
        '
        'lblMaterialUsageID
        '
        Me.lblMaterialUsageID.AutoSize = True
        Me.lblMaterialUsageID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterialUsageID.ForeColor = System.Drawing.Color.Blue
        Me.lblMaterialUsageID.Location = New System.Drawing.Point(697, 17)
        Me.lblMaterialUsageID.Name = "lblMaterialUsageID"
        Me.lblMaterialUsageID.Size = New System.Drawing.Size(101, 13)
        Me.lblMaterialUsageID.TabIndex = 198
        Me.lblMaterialUsageID.Text = "MaterialUsageID"
        '
        'lblDailyDistributionID
        '
        Me.lblDailyDistributionID.AutoSize = True
        Me.lblDailyDistributionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyDistributionID.ForeColor = System.Drawing.Color.Blue
        Me.lblDailyDistributionID.Location = New System.Drawing.Point(728, 112)
        Me.lblDailyDistributionID.Name = "lblDailyDistributionID"
        Me.lblDailyDistributionID.Size = New System.Drawing.Size(86, 13)
        Me.lblDailyDistributionID.TabIndex = 197
        Me.lblDailyDistributionID.Text = "DistributionID"
        Me.lblDailyDistributionID.Visible = False
        '
        'ScreenCtrl
        '
        Me.ScreenCtrl.Location = New System.Drawing.Point(748, 42)
        Me.ScreenCtrl.Name = "ScreenCtrl"
        Me.ScreenCtrl.Size = New System.Drawing.Size(50, 20)
        Me.ScreenCtrl.TabIndex = 195
        '
        'lblStockID
        '
        Me.lblStockID.AutoSize = True
        Me.lblStockID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockID.ForeColor = System.Drawing.Color.Blue
        Me.lblStockID.Location = New System.Drawing.Point(602, 169)
        Me.lblStockID.Name = "lblStockID"
        Me.lblStockID.Size = New System.Drawing.Size(66, 13)
        Me.lblStockID.TabIndex = 143
        Me.lblStockID.Text = "lblStockID"
        Me.lblStockID.Visible = False
        '
        'MaterialsWithTeam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(845, 610)
        Me.Controls.Add(Me.tcMaterial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "MaterialsWithTeam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material"
        Me.tcMaterial.ResumeLayout(False)
        Me.tabMaterial.ResumeLayout(False)
        Me.tabMaterial.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbEnquipmentData.ResumeLayout(False)
        CType(Me.dgvMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcMaterial As System.Windows.Forms.TabControl
    Friend WithEvents tabMaterial As System.Windows.Forms.TabPage
    Friend WithEvents lblUom3 As System.Windows.Forms.Label
    Friend WithEvents lblBalanceQty As System.Windows.Forms.Label
    Friend WithEvents lblColon10 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceQty As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents lblUom2 As System.Windows.Forms.Label
    Friend WithEvents lblUom1 As System.Windows.Forms.Label
    Friend WithEvents lblStockID As System.Windows.Forms.Label
    Friend WithEvents lblUsageQty As System.Windows.Forms.Label
    Friend WithEvents lblColon9 As System.Windows.Forms.Label
    Friend WithEvents txtUsageQty As System.Windows.Forms.TextBox
    Friend WithEvents lblIssuedQty As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSIVNo As System.Windows.Forms.Label
    Friend WithEvents txtSIVNo As System.Windows.Forms.TextBox
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents lblColon7 As System.Windows.Forms.Label
    Friend WithEvents lblColon6 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtGangName As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbEnquipmentData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMaterial As System.Windows.Forms.DataGridView
    Friend WithEvents txtCOACode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIssueQty As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents btnStock As System.Windows.Forms.Button
    Friend WithEvents lblGangMasterID As System.Windows.Forms.Label
    Friend WithEvents lblCOAID As System.Windows.Forms.Label
    Friend WithEvents lblEmpId As System.Windows.Forms.Label
    Friend WithEvents ScreenCtrl As System.Windows.Forms.TextBox
    Friend WithEvents lblStockDescp As System.Windows.Forms.Label
    Friend WithEvents lblDailyDistributionID As System.Windows.Forms.Label
    Friend WithEvents lblMaterialUsageID As System.Windows.Forms.Label
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtChange As System.Windows.Forms.TextBox
    Friend WithEvents btnRpt As System.Windows.Forms.Button
    Friend WithEvents SivNoColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockCodeColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockDescColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IssueQtyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UsageQtyColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblKraniEmpName As System.Windows.Forms.Label
    Friend WithEvents lblMandorEmpName As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class

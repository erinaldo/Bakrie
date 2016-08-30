<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Materials
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Materials))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcMaterial = New System.Windows.Forms.TabControl
        Me.tabMaterial = New System.Windows.Forms.TabPage
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblPartNo = New System.Windows.Forms.Label
        Me.txtActivity = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblColon6 = New System.Windows.Forms.Label
        Me.LblStockDescL = New System.Windows.Forms.Label
        Me.lblColon7 = New System.Windows.Forms.Label
        Me.lblStockCode = New System.Windows.Forms.Label
        Me.lblStockDescp = New System.Windows.Forms.Label
        Me.txtSIV = New System.Windows.Forms.TextBox
        Me.btnStock = New System.Windows.Forms.Button
        Me.lblSIVNo = New System.Windows.Forms.Label
        Me.lblActivity = New System.Windows.Forms.Label
        Me.txtStockCode = New System.Windows.Forms.TextBox
        Me.lblColon8 = New System.Windows.Forms.Label
        Me.txtIssueQty = New System.Windows.Forms.TextBox
        Me.lblIssuedQty = New System.Windows.Forms.Label
        Me.txtusageQty = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblColon9 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblUsageQty = New System.Windows.Forms.Label
        Me.lblUom3 = New System.Windows.Forms.Label
        Me.lblUom1 = New System.Windows.Forms.Label
        Me.lblBalanceQtyL = New System.Windows.Forms.Label
        Me.lblUom2 = New System.Windows.Forms.Label
        Me.lblColon10 = New System.Windows.Forms.Label
        Me.txtBalanceQty = New System.Windows.Forms.TextBox
        Me.btnRpt = New System.Windows.Forms.Button
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblEmpName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblEmpId = New System.Windows.Forms.Label
        Me.lblTeam = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtNIK = New System.Windows.Forms.TextBox
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblColon1 = New System.Windows.Forms.Label
        Me.lblGangMasterID = New System.Windows.Forms.Label
        Me.lblDailyDistributionID = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.gbEnquipmentData = New System.Windows.Forms.GroupBox
        Me.dgvMaterial = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ibtnAct = New System.Windows.Forms.Button
        Me.txtChange = New System.Windows.Forms.TextBox
        Me.lblMaterialUsageID = New System.Windows.Forms.Label
        Me.ScreenCtrl = New System.Windows.Forms.TextBox
        Me.lblActId = New System.Windows.Forms.Label
        Me.lblStockId = New System.Windows.Forms.Label
        Me.tcMaterial.SuspendLayout()
        Me.tabMaterial.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.tcMaterial.Size = New System.Drawing.Size(845, 594)
        Me.tcMaterial.TabIndex = 202
        '
        'tabMaterial
        '
        Me.tabMaterial.AutoScroll = True
        Me.tabMaterial.BackColor = System.Drawing.Color.Transparent
        Me.tabMaterial.BackgroundImage = CType(resources.GetObject("tabMaterial.BackgroundImage"), System.Drawing.Image)
        Me.tabMaterial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabMaterial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tabMaterial.Controls.Add(Me.btnAdd)
        Me.tabMaterial.Controls.Add(Me.btnUpdate)
        Me.tabMaterial.Controls.Add(Me.GroupBox2)
        Me.tabMaterial.Controls.Add(Me.btnRpt)
        Me.tabMaterial.Controls.Add(Me.btnSaveAll)
        Me.tabMaterial.Controls.Add(Me.btnReset)
        Me.tabMaterial.Controls.Add(Me.GroupBox1)
        Me.tabMaterial.Controls.Add(Me.btnClose)
        Me.tabMaterial.Controls.Add(Me.gbEnquipmentData)
        Me.tabMaterial.Controls.Add(Me.txtChange)
        Me.tabMaterial.Controls.Add(Me.lblMaterialUsageID)
        Me.tabMaterial.Controls.Add(Me.ScreenCtrl)
        Me.tabMaterial.Controls.Add(Me.lblActId)
        Me.tabMaterial.Controls.Add(Me.lblStockId)
        Me.tabMaterial.Location = New System.Drawing.Point(4, 22)
        Me.tabMaterial.Name = "tabMaterial"
        Me.tabMaterial.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMaterial.Size = New System.Drawing.Size(837, 568)
        Me.tabMaterial.TabIndex = 0
        Me.tabMaterial.Text = "Material"
        Me.tabMaterial.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(13, 286)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 25)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.BackgroundImage = CType(resources.GetObject("btnUpdate.BackgroundImage"), System.Drawing.Image)
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdate.Location = New System.Drawing.Point(13, 286)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(95, 25)
        Me.btnUpdate.TabIndex = 198
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblPartNo)
        Me.GroupBox2.Controls.Add(Me.txtActivity)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblColon6)
        Me.GroupBox2.Controls.Add(Me.LblStockDescL)
        Me.GroupBox2.Controls.Add(Me.lblColon7)
        Me.GroupBox2.Controls.Add(Me.lblStockCode)
        Me.GroupBox2.Controls.Add(Me.lblStockDescp)
        Me.GroupBox2.Controls.Add(Me.txtSIV)
        Me.GroupBox2.Controls.Add(Me.btnStock)
        Me.GroupBox2.Controls.Add(Me.lblSIVNo)
        Me.GroupBox2.Controls.Add(Me.lblActivity)
        Me.GroupBox2.Controls.Add(Me.txtStockCode)
        Me.GroupBox2.Controls.Add(Me.lblColon8)
        Me.GroupBox2.Controls.Add(Me.txtIssueQty)
        Me.GroupBox2.Controls.Add(Me.lblIssuedQty)
        Me.GroupBox2.Controls.Add(Me.txtusageQty)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblColon9)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.lblUsageQty)
        Me.GroupBox2.Controls.Add(Me.lblUom3)
        Me.GroupBox2.Controls.Add(Me.lblUom1)
        Me.GroupBox2.Controls.Add(Me.lblBalanceQtyL)
        Me.GroupBox2.Controls.Add(Me.lblUom2)
        Me.GroupBox2.Controls.Add(Me.lblColon10)
        Me.GroupBox2.Controls.Add(Me.txtBalanceQty)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(821, 181)
        Me.GroupBox2.TabIndex = 203
        Me.GroupBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(430, 92)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 13)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(341, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "Part No "
        '
        'lblPartNo
        '
        Me.lblPartNo.AutoSize = True
        Me.lblPartNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartNo.ForeColor = System.Drawing.Color.Blue
        Me.lblPartNo.Location = New System.Drawing.Point(448, 92)
        Me.lblPartNo.Name = "lblPartNo"
        Me.lblPartNo.Size = New System.Drawing.Size(45, 13)
        Me.lblPartNo.TabIndex = 202
        Me.lblPartNo.Text = "PartNo"
        '
        'txtActivity
        '
        Me.txtActivity.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtActivity.Enabled = False
        Me.txtActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtActivity.Location = New System.Drawing.Point(134, 19)
        Me.txtActivity.MaxLength = 50
        Me.txtActivity.Name = "txtActivity"
        Me.txtActivity.Size = New System.Drawing.Size(138, 21)
        Me.txtActivity.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(430, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 13)
        Me.Label7.TabIndex = 201
        Me.Label7.Text = ":"
        '
        'lblColon6
        '
        Me.lblColon6.AutoSize = True
        Me.lblColon6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon6.Location = New System.Drawing.Point(117, 50)
        Me.lblColon6.Name = "lblColon6"
        Me.lblColon6.Size = New System.Drawing.Size(12, 13)
        Me.lblColon6.TabIndex = 133
        Me.lblColon6.Text = ":"
        '
        'LblStockDescL
        '
        Me.LblStockDescL.AutoSize = True
        Me.LblStockDescL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStockDescL.ForeColor = System.Drawing.Color.Black
        Me.LblStockDescL.Location = New System.Drawing.Point(341, 74)
        Me.LblStockDescL.Name = "LblStockDescL"
        Me.LblStockDescL.Size = New System.Drawing.Size(82, 13)
        Me.LblStockDescL.TabIndex = 201
        Me.LblStockDescL.Text = "Stock Descp "
        '
        'lblColon7
        '
        Me.lblColon7.AutoSize = True
        Me.lblColon7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon7.Location = New System.Drawing.Point(117, 74)
        Me.lblColon7.Name = "lblColon7"
        Me.lblColon7.Size = New System.Drawing.Size(12, 13)
        Me.lblColon7.TabIndex = 134
        Me.lblColon7.Text = ":"
        '
        'lblStockCode
        '
        Me.lblStockCode.AutoSize = True
        Me.lblStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockCode.ForeColor = System.Drawing.Color.Red
        Me.lblStockCode.Location = New System.Drawing.Point(12, 74)
        Me.lblStockCode.Name = "lblStockCode"
        Me.lblStockCode.Size = New System.Drawing.Size(73, 13)
        Me.lblStockCode.TabIndex = 132
        Me.lblStockCode.Text = "Stock Code"
        '
        'lblStockDescp
        '
        Me.lblStockDescp.AutoSize = True
        Me.lblStockDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblStockDescp.Location = New System.Drawing.Point(448, 74)
        Me.lblStockDescp.Name = "lblStockDescp"
        Me.lblStockDescp.Size = New System.Drawing.Size(78, 13)
        Me.lblStockDescp.TabIndex = 196
        Me.lblStockDescp.Text = "Stock Descp"
        '
        'txtSIV
        '
        Me.txtSIV.BackColor = System.Drawing.Color.White
        Me.txtSIV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSIV.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSIV.Location = New System.Drawing.Point(134, 46)
        Me.txtSIV.MaxLength = 100
        Me.txtSIV.Name = "txtSIV"
        Me.txtSIV.Size = New System.Drawing.Size(138, 21)
        Me.txtSIV.TabIndex = 0
        '
        'btnStock
        '
        Me.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStock.Image = CType(resources.GetObject("btnStock.Image"), System.Drawing.Image)
        Me.btnStock.Location = New System.Drawing.Point(278, 69)
        Me.btnStock.Name = "btnStock"
        Me.btnStock.Size = New System.Drawing.Size(30, 26)
        Me.btnStock.TabIndex = 4
        Me.btnStock.TabStop = False
        Me.btnStock.UseVisualStyleBackColor = True
        '
        'lblSIVNo
        '
        Me.lblSIVNo.AutoSize = True
        Me.lblSIVNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSIVNo.ForeColor = System.Drawing.Color.Red
        Me.lblSIVNo.Location = New System.Drawing.Point(12, 48)
        Me.lblSIVNo.Name = "lblSIVNo"
        Me.lblSIVNo.Size = New System.Drawing.Size(47, 13)
        Me.lblSIVNo.TabIndex = 131
        Me.lblSIVNo.Text = "SIV No"
        '
        'lblActivity
        '
        Me.lblActivity.AutoSize = True
        Me.lblActivity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivity.ForeColor = System.Drawing.Color.Blue
        Me.lblActivity.Location = New System.Drawing.Point(278, 23)
        Me.lblActivity.Name = "lblActivity"
        Me.lblActivity.Size = New System.Drawing.Size(72, 13)
        Me.lblActivity.TabIndex = 192
        Me.lblActivity.Text = "COA Descp"
        '
        'txtStockCode
        '
        Me.txtStockCode.BackColor = System.Drawing.Color.White
        Me.txtStockCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStockCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockCode.Location = New System.Drawing.Point(134, 72)
        Me.txtStockCode.MaxLength = 50
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(138, 21)
        Me.txtStockCode.TabIndex = 3
        '
        'lblColon8
        '
        Me.lblColon8.AutoSize = True
        Me.lblColon8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon8.Location = New System.Drawing.Point(117, 101)
        Me.lblColon8.Name = "lblColon8"
        Me.lblColon8.Size = New System.Drawing.Size(12, 13)
        Me.lblColon8.TabIndex = 138
        Me.lblColon8.Text = ":"
        '
        'txtIssueQty
        '
        Me.txtIssueQty.BackColor = System.Drawing.Color.White
        Me.txtIssueQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIssueQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIssueQty.Location = New System.Drawing.Point(134, 97)
        Me.txtIssueQty.MaxLength = 50
        Me.txtIssueQty.Name = "txtIssueQty"
        Me.txtIssueQty.Size = New System.Drawing.Size(76, 21)
        Me.txtIssueQty.TabIndex = 5
        '
        'lblIssuedQty
        '
        Me.lblIssuedQty.AutoSize = True
        Me.lblIssuedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssuedQty.ForeColor = System.Drawing.Color.Red
        Me.lblIssuedQty.Location = New System.Drawing.Point(12, 101)
        Me.lblIssuedQty.Name = "lblIssuedQty"
        Me.lblIssuedQty.Size = New System.Drawing.Size(69, 13)
        Me.lblIssuedQty.TabIndex = 137
        Me.lblIssuedQty.Text = "Issued Qty"
        '
        'txtusageQty
        '
        Me.txtusageQty.BackColor = System.Drawing.Color.White
        Me.txtusageQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtusageQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusageQty.Location = New System.Drawing.Point(134, 124)
        Me.txtusageQty.MaxLength = 50
        Me.txtusageQty.Name = "txtusageQty"
        Me.txtusageQty.Size = New System.Drawing.Size(76, 21)
        Me.txtusageQty.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "Activity"
        '
        'lblColon9
        '
        Me.lblColon9.AutoSize = True
        Me.lblColon9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon9.Location = New System.Drawing.Point(118, 124)
        Me.lblColon9.Name = "lblColon9"
        Me.lblColon9.Size = New System.Drawing.Size(12, 13)
        Me.lblColon9.TabIndex = 141
        Me.lblColon9.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(117, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = ":"
        '
        'lblUsageQty
        '
        Me.lblUsageQty.AutoSize = True
        Me.lblUsageQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsageQty.ForeColor = System.Drawing.Color.Red
        Me.lblUsageQty.Location = New System.Drawing.Point(13, 124)
        Me.lblUsageQty.Name = "lblUsageQty"
        Me.lblUsageQty.Size = New System.Drawing.Size(66, 13)
        Me.lblUsageQty.TabIndex = 140
        Me.lblUsageQty.Text = "Usage Qty"
        '
        'lblUom3
        '
        Me.lblUom3.AutoSize = True
        Me.lblUom3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUom3.Location = New System.Drawing.Point(219, 155)
        Me.lblUom3.Name = "lblUom3"
        Me.lblUom3.Size = New System.Drawing.Size(29, 13)
        Me.lblUom3.TabIndex = 151
        Me.lblUom3.Text = "Unit"
        '
        'lblUom1
        '
        Me.lblUom1.AutoSize = True
        Me.lblUom1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUom1.Location = New System.Drawing.Point(219, 101)
        Me.lblUom1.Name = "lblUom1"
        Me.lblUom1.Size = New System.Drawing.Size(29, 13)
        Me.lblUom1.TabIndex = 145
        Me.lblUom1.Text = "Unit"
        '
        'lblBalanceQtyL
        '
        Me.lblBalanceQtyL.AutoSize = True
        Me.lblBalanceQtyL.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalanceQtyL.ForeColor = System.Drawing.Color.Black
        Me.lblBalanceQtyL.Location = New System.Drawing.Point(13, 150)
        Me.lblBalanceQtyL.Name = "lblBalanceQtyL"
        Me.lblBalanceQtyL.Size = New System.Drawing.Size(76, 13)
        Me.lblBalanceQtyL.TabIndex = 149
        Me.lblBalanceQtyL.Text = "Balance Qty"
        '
        'lblUom2
        '
        Me.lblUom2.AutoSize = True
        Me.lblUom2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUom2.Location = New System.Drawing.Point(219, 127)
        Me.lblUom2.Name = "lblUom2"
        Me.lblUom2.Size = New System.Drawing.Size(29, 13)
        Me.lblUom2.TabIndex = 146
        Me.lblUom2.Text = "Unit"
        '
        'lblColon10
        '
        Me.lblColon10.AutoSize = True
        Me.lblColon10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon10.Location = New System.Drawing.Point(118, 150)
        Me.lblColon10.Name = "lblColon10"
        Me.lblColon10.Size = New System.Drawing.Size(12, 13)
        Me.lblColon10.TabIndex = 150
        Me.lblColon10.Text = ":"
        '
        'txtBalanceQty
        '
        Me.txtBalanceQty.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtBalanceQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBalanceQty.Enabled = False
        Me.txtBalanceQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalanceQty.Location = New System.Drawing.Point(134, 151)
        Me.txtBalanceQty.MaxLength = 50
        Me.txtBalanceQty.Name = "txtBalanceQty"
        Me.txtBalanceQty.Size = New System.Drawing.Size(76, 21)
        Me.txtBalanceQty.TabIndex = 148
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
        Me.btnRpt.Location = New System.Drawing.Point(241, 525)
        Me.btnRpt.Name = "btnRpt"
        Me.btnRpt.Size = New System.Drawing.Size(126, 28)
        Me.btnRpt.TabIndex = 202
        Me.btnRpt.Text = "View Report"
        Me.btnRpt.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = CType(resources.GetObject("btnSaveAll.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(14, 525)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(105, 30)
        Me.btnSaveAll.TabIndex = 9
        Me.btnSaveAll.Text = "&Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(112, 286)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(105, 25)
        Me.btnReset.TabIndex = 8
        Me.btnReset.Text = "&Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblEmpName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblEmpId)
        Me.GroupBox1.Controls.Add(Me.lblTeam)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtNIK)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.lblColon1)
        Me.GroupBox1.Controls.Add(Me.lblGangMasterID)
        Me.GroupBox1.Controls.Add(Me.lblDailyDistributionID)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(822, 95)
        Me.GroupBox1.TabIndex = 129
        Me.GroupBox1.TabStop = False
        '
        'lblEmpName
        '
        Me.lblEmpName.AutoSize = True
        Me.lblEmpName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpName.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpName.Location = New System.Drawing.Point(448, 60)
        Me.lblEmpName.Name = "lblEmpName"
        Me.lblEmpName.Size = New System.Drawing.Size(100, 13)
        Me.lblEmpName.TabIndex = 203
        Me.lblEmpName.Text = "Employee Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(355, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(418, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = ":"
        '
        'lblEmpId
        '
        Me.lblEmpId.AutoSize = True
        Me.lblEmpId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpId.ForeColor = System.Drawing.Color.Blue
        Me.lblEmpId.Location = New System.Drawing.Point(308, 28)
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
        Me.lblTeam.Size = New System.Drawing.Size(28, 13)
        Me.lblTeam.TabIndex = 197
        Me.lblTeam.Text = "NIK"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(126, 58)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 13)
        Me.Label17.TabIndex = 198
        Me.Label17.Text = ":"
        '
        'txtNIK
        '
        Me.txtNIK.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtNIK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNIK.Enabled = False
        Me.txtNIK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNIK.Location = New System.Drawing.Point(144, 56)
        Me.txtNIK.MaxLength = 50
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Size = New System.Drawing.Size(135, 21)
        Me.txtNIK.TabIndex = 199
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
        Me.lblColon1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblColon1.Location = New System.Drawing.Point(123, 28)
        Me.lblColon1.Name = "lblColon1"
        Me.lblColon1.Size = New System.Drawing.Size(12, 13)
        Me.lblColon1.TabIndex = 19
        Me.lblColon1.Text = ":"
        '
        'lblGangMasterID
        '
        Me.lblGangMasterID.AutoSize = True
        Me.lblGangMasterID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGangMasterID.ForeColor = System.Drawing.Color.Blue
        Me.lblGangMasterID.Location = New System.Drawing.Point(392, 28)
        Me.lblGangMasterID.Name = "lblGangMasterID"
        Me.lblGangMasterID.Size = New System.Drawing.Size(57, 13)
        Me.lblGangMasterID.TabIndex = 143
        Me.lblGangMasterID.Text = "Team ID"
        Me.lblGangMasterID.Visible = False
        '
        'lblDailyDistributionID
        '
        Me.lblDailyDistributionID.AutoSize = True
        Me.lblDailyDistributionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDailyDistributionID.ForeColor = System.Drawing.Color.Blue
        Me.lblDailyDistributionID.Location = New System.Drawing.Point(462, 27)
        Me.lblDailyDistributionID.Name = "lblDailyDistributionID"
        Me.lblDailyDistributionID.Size = New System.Drawing.Size(86, 13)
        Me.lblDailyDistributionID.TabIndex = 197
        Me.lblDailyDistributionID.Text = "DistributionID"
        Me.lblDailyDistributionID.Visible = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = CType(resources.GetObject("btnClose.BackgroundImage"), System.Drawing.Image)
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(125, 525)
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
        Me.gbEnquipmentData.Controls.Add(Me.ibtnAct)
        Me.gbEnquipmentData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEnquipmentData.Location = New System.Drawing.Point(7, 310)
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
        Me.dgvMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvMaterial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvMaterial.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvMaterial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMaterial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMaterial.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
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
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaterial.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMaterial.RowHeadersVisible = False
        Me.dgvMaterial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaterial.ShowCellErrors = False
        Me.dgvMaterial.Size = New System.Drawing.Size(787, 186)
        Me.dgvMaterial.TabIndex = 126
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
        'ibtnAct
        '
        Me.ibtnAct.Enabled = False
        Me.ibtnAct.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnAct.Image = CType(resources.GetObject("ibtnAct.Image"), System.Drawing.Image)
        Me.ibtnAct.Location = New System.Drawing.Point(752, 32)
        Me.ibtnAct.Name = "ibtnAct"
        Me.ibtnAct.Size = New System.Drawing.Size(30, 26)
        Me.ibtnAct.TabIndex = 1
        Me.ibtnAct.UseVisualStyleBackColor = True
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
        'ScreenCtrl
        '
        Me.ScreenCtrl.Location = New System.Drawing.Point(748, 42)
        Me.ScreenCtrl.Name = "ScreenCtrl"
        Me.ScreenCtrl.Size = New System.Drawing.Size(50, 20)
        Me.ScreenCtrl.TabIndex = 195
        '
        'lblActId
        '
        Me.lblActId.AutoSize = True
        Me.lblActId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActId.ForeColor = System.Drawing.Color.Blue
        Me.lblActId.Location = New System.Drawing.Point(640, 17)
        Me.lblActId.Name = "lblActId"
        Me.lblActId.Size = New System.Drawing.Size(51, 13)
        Me.lblActId.TabIndex = 194
        Me.lblActId.Text = "COA ID"
        '
        'lblStockId
        '
        Me.lblStockId.AutoSize = True
        Me.lblStockId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStockId.ForeColor = System.Drawing.Color.Blue
        Me.lblStockId.Location = New System.Drawing.Point(487, 17)
        Me.lblStockId.Name = "lblStockId"
        Me.lblStockId.Size = New System.Drawing.Size(55, 13)
        Me.lblStockId.TabIndex = 143
        Me.lblStockId.Text = "Stock Id"
        '
        'Materials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(845, 594)
        Me.Controls.Add(Me.tcMaterial)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Materials"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material"
        Me.tcMaterial.ResumeLayout(False)
        Me.tabMaterial.ResumeLayout(False)
        Me.tabMaterial.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents lblBalanceQtyL As System.Windows.Forms.Label
    Friend WithEvents lblColon10 As System.Windows.Forms.Label
    Friend WithEvents txtBalanceQty As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents lblUom2 As System.Windows.Forms.Label
    Friend WithEvents lblUom1 As System.Windows.Forms.Label
    Friend WithEvents lblStockId As System.Windows.Forms.Label
    Friend WithEvents lblUsageQty As System.Windows.Forms.Label
    Friend WithEvents lblColon9 As System.Windows.Forms.Label
    Friend WithEvents txtusageQty As System.Windows.Forms.TextBox
    Friend WithEvents lblIssuedQty As System.Windows.Forms.Label
    Friend WithEvents lblColon8 As System.Windows.Forms.Label
    Friend WithEvents txtStockCode As System.Windows.Forms.TextBox
    Friend WithEvents lblSIVNo As System.Windows.Forms.Label
    Friend WithEvents txtSIV As System.Windows.Forms.TextBox
    Friend WithEvents lblStockCode As System.Windows.Forms.Label
    Friend WithEvents lblColon7 As System.Windows.Forms.Label
    Friend WithEvents lblColon6 As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtNIK As System.Windows.Forms.TextBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblColon1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbEnquipmentData As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMaterial As System.Windows.Forms.DataGridView
    Friend WithEvents ibtnAct As System.Windows.Forms.Button
    Friend WithEvents txtActivity As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIssueQty As System.Windows.Forms.TextBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblActivity As System.Windows.Forms.Label
    Friend WithEvents btnStock As System.Windows.Forms.Button
    Friend WithEvents lblGangMasterID As System.Windows.Forms.Label
    Friend WithEvents lblActId As System.Windows.Forms.Label
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblStockDescL As System.Windows.Forms.Label
    Friend WithEvents lblEmpName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPartNo As System.Windows.Forms.Label
End Class

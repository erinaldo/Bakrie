<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FFBTransportBudgetFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FFBTransportBudgetFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbFFBTransportBudget = New System.Windows.Forms.TabControl
        Me.tbFFBTransport = New System.Windows.Forms.TabPage
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GrpGrid = New System.Windows.Forms.GroupBox
        Me.dgAdminExpand = New System.Windows.Forms.DataGridView
        Me.AdminExpendID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BDGYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBudgetTotal = New System.Windows.Forms.Label
        Me.lblBudgetTotalL = New System.Windows.Forms.Label
        Me.grpMonths = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.lblRevisionDec = New System.Windows.Forms.Label
        Me.lblBudgetDec = New System.Windows.Forms.Label
        Me.lblRevisionAug = New System.Windows.Forms.Label
        Me.lblBudgetAug = New System.Windows.Forms.Label
        Me.lblRevisionApr = New System.Windows.Forms.Label
        Me.lblBudgetApr = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.lblRevisionNov = New System.Windows.Forms.Label
        Me.lblBudgetNov = New System.Windows.Forms.Label
        Me.lblRevisionJul = New System.Windows.Forms.Label
        Me.lblBudgetJul = New System.Windows.Forms.Label
        Me.lblRevisionMar = New System.Windows.Forms.Label
        Me.lblBudgetMar = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.lblRevisionOct = New System.Windows.Forms.Label
        Me.lblBudgetOct = New System.Windows.Forms.Label
        Me.lblRevisionJun = New System.Windows.Forms.Label
        Me.lblBudgetJun = New System.Windows.Forms.Label
        Me.lblRevisionFeb = New System.Windows.Forms.Label
        Me.lblBudgetFeb = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.lblRevisionSep = New System.Windows.Forms.Label
        Me.lblBudgetSep = New System.Windows.Forms.Label
        Me.lblRevisionMay = New System.Windows.Forms.Label
        Me.lblBudgetMay = New System.Windows.Forms.Label
        Me.lblRevisionJan = New System.Windows.Forms.Label
        Me.lblBudgetJan = New System.Windows.Forms.Label
        Me.txtRevDec = New System.Windows.Forms.TextBox
        Me.txtBudgetDec = New System.Windows.Forms.TextBox
        Me.txtRevAug = New System.Windows.Forms.TextBox
        Me.txtBudgetAug = New System.Windows.Forms.TextBox
        Me.txtRevApr = New System.Windows.Forms.TextBox
        Me.txtBudgetApr = New System.Windows.Forms.TextBox
        Me.txtRevNov = New System.Windows.Forms.TextBox
        Me.txtBudgetNov = New System.Windows.Forms.TextBox
        Me.txtRevJul = New System.Windows.Forms.TextBox
        Me.txtBudgetJul = New System.Windows.Forms.TextBox
        Me.txtRevMar = New System.Windows.Forms.TextBox
        Me.txtBudgetMar = New System.Windows.Forms.TextBox
        Me.txtRevOct = New System.Windows.Forms.TextBox
        Me.txtBudgetOct = New System.Windows.Forms.TextBox
        Me.txtRevJun = New System.Windows.Forms.TextBox
        Me.txtBudgetJun = New System.Windows.Forms.TextBox
        Me.txtRevFeb = New System.Windows.Forms.TextBox
        Me.txtBudgetFeb = New System.Windows.Forms.TextBox
        Me.txtRevSep = New System.Windows.Forms.TextBox
        Me.txtBudgetSep = New System.Windows.Forms.TextBox
        Me.txtRevMay = New System.Windows.Forms.TextBox
        Me.txtBudgetMay = New System.Windows.Forms.TextBox
        Me.txtRevJan = New System.Windows.Forms.TextBox
        Me.txtBudgetJan = New System.Windows.Forms.TextBox
        Me.lblRPM3 = New System.Windows.Forms.Label
        Me.lblRPM2 = New System.Windows.Forms.Label
        Me.lblRPM1 = New System.Windows.Forms.Label
        Me.lblRPM = New System.Windows.Forms.Label
        Me.lblRevisions = New System.Windows.Forms.Label
        Me.lblBudgets = New System.Windows.Forms.Label
        Me.lblRevisionL = New System.Windows.Forms.Label
        Me.lblBudgetL = New System.Windows.Forms.Label
        Me.lblRevision = New System.Windows.Forms.Label
        Me.lblBudget = New System.Windows.Forms.Label
        Me.grpBudgetYear = New System.Windows.Forms.GroupBox
        Me.btnDistribute = New System.Windows.Forms.Button
        Me.txtTotalTonnage = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblTotalTonnage = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblOldAccCode = New System.Windows.Forms.Label
        Me.lblOldCOACode = New System.Windows.Forms.Label
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.btnSearchAccountCode = New System.Windows.Forms.Button
        Me.txtCOACode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblCOA = New System.Windows.Forms.Label
        Me.btnSearchVehicleCategory = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtVehicleCategory = New System.Windows.Forms.TextBox
        Me.lblVehicleCategory = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtYOP = New System.Windows.Forms.TextBox
        Me.lblRemark = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblStatusL = New System.Windows.Forms.Label
        Me.lblVersionNo = New System.Windows.Forms.Label
        Me.lblVersionNoL = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBudgetYear = New System.Windows.Forms.Label
        Me.lblBudgetyearL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.tbFFBTransportBudget.SuspendLayout()
        Me.tbFFBTransport.SuspendLayout()
        Me.GrpGrid.SuspendLayout()
        CType(Me.dgAdminExpand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMonths.SuspendLayout()
        Me.grpBudgetYear.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbFFBTransportBudget
        '
        Me.tbFFBTransportBudget.Controls.Add(Me.tbFFBTransport)
        Me.tbFFBTransportBudget.Controls.Add(Me.tbView)
        Me.tbFFBTransportBudget.Location = New System.Drawing.Point(12, 0)
        Me.tbFFBTransportBudget.Name = "tbFFBTransportBudget"
        Me.tbFFBTransportBudget.SelectedIndex = 0
        Me.tbFFBTransportBudget.Size = New System.Drawing.Size(1089, 720)
        Me.tbFFBTransportBudget.TabIndex = 3
        '
        'tbFFBTransport
        '
        Me.tbFFBTransport.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbFFBTransport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbFFBTransport.Controls.Add(Me.btnReset)
        Me.tbFFBTransport.Controls.Add(Me.btnAdd)
        Me.tbFFBTransport.Controls.Add(Me.Label3)
        Me.tbFFBTransport.Controls.Add(Me.Label1)
        Me.tbFFBTransport.Controls.Add(Me.btnResetAll)
        Me.tbFFBTransport.Controls.Add(Me.btnSaveAll)
        Me.tbFFBTransport.Controls.Add(Me.btnClose)
        Me.tbFFBTransport.Controls.Add(Me.GrpGrid)
        Me.tbFFBTransport.Controls.Add(Me.lblBudgetTotal)
        Me.tbFFBTransport.Controls.Add(Me.lblBudgetTotalL)
        Me.tbFFBTransport.Controls.Add(Me.grpMonths)
        Me.tbFFBTransport.Controls.Add(Me.grpBudgetYear)
        Me.tbFFBTransport.Location = New System.Drawing.Point(4, 22)
        Me.tbFFBTransport.Name = "tbFFBTransport"
        Me.tbFFBTransport.Padding = New System.Windows.Forms.Padding(3)
        Me.tbFFBTransport.Size = New System.Drawing.Size(1081, 694)
        Me.tbFFBTransport.TabIndex = 0
        Me.tbFFBTransport.Text = "FFB Transport Budget"
        Me.tbFFBTransport.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(883, 427)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(97, 25)
        Me.btnReset.TabIndex = 2329
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(780, 427)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 25)
        Me.btnAdd.TabIndex = 2328
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(820, 401)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(11, 13)
        Me.Label3.TabIndex = 2327
        Me.Label3.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(990, 401)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Tonnes"
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(770, 663)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(106, 25)
        Me.btnResetAll.TabIndex = 244
        Me.btnResetAll.Text = "Reset"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(658, 663)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(106, 25)
        Me.btnSaveAll.TabIndex = 243
        Me.btnSaveAll.Text = "Save "
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(882, 663)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 25)
        Me.btnClose.TabIndex = 245
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GrpGrid
        '
        Me.GrpGrid.Controls.Add(Me.dgAdminExpand)
        Me.GrpGrid.Location = New System.Drawing.Point(11, 458)
        Me.GrpGrid.Name = "GrpGrid"
        Me.GrpGrid.Size = New System.Drawing.Size(1021, 202)
        Me.GrpGrid.TabIndex = 248
        Me.GrpGrid.TabStop = False
        '
        'dgAdminExpand
        '
        Me.dgAdminExpand.AllowUserToAddRows = False
        Me.dgAdminExpand.AllowUserToDeleteRows = False
        Me.dgAdminExpand.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgAdminExpand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAdminExpand.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgAdminExpand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAdminExpand.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgAdminExpand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAdminExpand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AdminExpendID, Me.BDGYear, Me.EstateID, Me.COAId, Me.COACode, Me.COADescp, Me.BudgetJan, Me.BudgetFeb, Me.BudgetMar, Me.BudgetApr, Me.BudgetMay, Me.BudgetJun, Me.BudgetJul, Me.BudgetAug, Me.BudgetSep, Me.BudgetOct, Me.BudgetNov, Me.BudgetDec, Me.RevJan, Me.RevFeb, Me.RevMar, Me.RevApr, Me.RevMay, Me.RevJun, Me.RevJul, Me.RevAug, Me.RevSep, Me.RevOct, Me.RevNov, Me.RevDec, Me.PinkJan, Me.PinkFeb, Me.PinkMar, Me.PinkApr, Me.PinkMay, Me.PinkJun, Me.PinkJul, Me.PinkAug, Me.PinkSep, Me.PinkOct, Me.PinkNov, Me.PinkDec, Me.Amount, Me.Remarks, Me.BudgetTotal, Me.VersionNo, Me.Status})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAdminExpand.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgAdminExpand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAdminExpand.EnableHeadersVisualStyles = False
        Me.dgAdminExpand.GridColor = System.Drawing.Color.Gray
        Me.dgAdminExpand.Location = New System.Drawing.Point(3, 17)
        Me.dgAdminExpand.Name = "dgAdminExpand"
        Me.dgAdminExpand.RowHeadersVisible = False
        Me.dgAdminExpand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAdminExpand.ShowCellErrors = False
        Me.dgAdminExpand.Size = New System.Drawing.Size(1015, 182)
        Me.dgAdminExpand.TabIndex = 120
        '
        'AdminExpendID
        '
        Me.AdminExpendID.DataPropertyName = "AdminExpendID"
        Me.AdminExpendID.HeaderText = "AdminExpendID"
        Me.AdminExpendID.Name = "AdminExpendID"
        Me.AdminExpendID.Visible = False
        Me.AdminExpendID.Width = 123
        '
        'BDGYear
        '
        Me.BDGYear.DataPropertyName = "BDGYear"
        Me.BDGYear.HeaderText = "Budget Year"
        Me.BDGYear.Name = "BDGYear"
        Me.BDGYear.Width = 101
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "EstateID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.Visible = False
        Me.EstateID.Width = 80
        '
        'COAId
        '
        Me.COAId.DataPropertyName = "COAId"
        Me.COAId.HeaderText = "COA Id"
        Me.COAId.Name = "COAId"
        Me.COAId.Visible = False
        Me.COAId.Width = 73
        '
        'COACode
        '
        Me.COACode.DataPropertyName = "COACode"
        Me.COACode.HeaderText = "COA Code"
        Me.COACode.Name = "COACode"
        Me.COACode.Width = 91
        '
        'COADescp
        '
        Me.COADescp.DataPropertyName = "COADescp"
        Me.COADescp.HeaderText = "COA Descp"
        Me.COADescp.Name = "COADescp"
        Me.COADescp.Width = 96
        '
        'BudgetJan
        '
        Me.BudgetJan.DataPropertyName = "BudgetJan"
        Me.BudgetJan.HeaderText = "BudgetJan"
        Me.BudgetJan.Name = "BudgetJan"
        Me.BudgetJan.Width = 90
        '
        'BudgetFeb
        '
        Me.BudgetFeb.DataPropertyName = "BudgetFeb"
        Me.BudgetFeb.HeaderText = "BudgetFeb"
        Me.BudgetFeb.Name = "BudgetFeb"
        Me.BudgetFeb.Width = 91
        '
        'BudgetMar
        '
        Me.BudgetMar.DataPropertyName = "BudgetMar"
        Me.BudgetMar.HeaderText = "BudgetMar"
        Me.BudgetMar.Name = "BudgetMar"
        Me.BudgetMar.Width = 92
        '
        'BudgetApr
        '
        Me.BudgetApr.DataPropertyName = "BudgetApr"
        Me.BudgetApr.HeaderText = "BudgetApr"
        Me.BudgetApr.Name = "BudgetApr"
        Me.BudgetApr.Width = 91
        '
        'BudgetMay
        '
        Me.BudgetMay.DataPropertyName = "BudgetMay"
        Me.BudgetMay.HeaderText = "BudgetMay"
        Me.BudgetMay.Name = "BudgetMay"
        Me.BudgetMay.Width = 94
        '
        'BudgetJun
        '
        Me.BudgetJun.DataPropertyName = "BudgetJun"
        Me.BudgetJun.HeaderText = "BudgetJun"
        Me.BudgetJun.Name = "BudgetJun"
        Me.BudgetJun.Width = 90
        '
        'BudgetJul
        '
        Me.BudgetJul.DataPropertyName = "BudgetJul"
        Me.BudgetJul.HeaderText = "BudgetJul"
        Me.BudgetJul.Name = "BudgetJul"
        Me.BudgetJul.Width = 86
        '
        'BudgetAug
        '
        Me.BudgetAug.DataPropertyName = "BudgetAug"
        Me.BudgetAug.HeaderText = "BudgetAug"
        Me.BudgetAug.Name = "BudgetAug"
        Me.BudgetAug.Width = 93
        '
        'BudgetSep
        '
        Me.BudgetSep.DataPropertyName = "BudgetSep"
        Me.BudgetSep.HeaderText = "BudgetSep"
        Me.BudgetSep.Name = "BudgetSep"
        Me.BudgetSep.Width = 93
        '
        'BudgetOct
        '
        Me.BudgetOct.DataPropertyName = "BudgetOct"
        Me.BudgetOct.HeaderText = "BudgetOct"
        Me.BudgetOct.Name = "BudgetOct"
        Me.BudgetOct.Width = 90
        '
        'BudgetNov
        '
        Me.BudgetNov.DataPropertyName = "BudgetNov"
        Me.BudgetNov.HeaderText = "BudgetNov"
        Me.BudgetNov.Name = "BudgetNov"
        Me.BudgetNov.Width = 93
        '
        'BudgetDec
        '
        Me.BudgetDec.DataPropertyName = "BudgetDec"
        Me.BudgetDec.HeaderText = "BudgetDec"
        Me.BudgetDec.Name = "BudgetDec"
        Me.BudgetDec.Width = 93
        '
        'RevJan
        '
        Me.RevJan.DataPropertyName = "RevJan"
        Me.RevJan.HeaderText = "RevJan"
        Me.RevJan.Name = "RevJan"
        Me.RevJan.Visible = False
        Me.RevJan.Width = 72
        '
        'RevFeb
        '
        Me.RevFeb.DataPropertyName = "RevFeb"
        Me.RevFeb.HeaderText = "RevFeb"
        Me.RevFeb.Name = "RevFeb"
        Me.RevFeb.Visible = False
        Me.RevFeb.Width = 73
        '
        'RevMar
        '
        Me.RevMar.DataPropertyName = "RevMar"
        Me.RevMar.HeaderText = "RevMar"
        Me.RevMar.Name = "RevMar"
        Me.RevMar.Visible = False
        Me.RevMar.Width = 74
        '
        'RevApr
        '
        Me.RevApr.DataPropertyName = "RevApr"
        Me.RevApr.HeaderText = "RevApr"
        Me.RevApr.Name = "RevApr"
        Me.RevApr.Visible = False
        Me.RevApr.Width = 73
        '
        'RevMay
        '
        Me.RevMay.DataPropertyName = "RevMay"
        Me.RevMay.HeaderText = "RevMay"
        Me.RevMay.Name = "RevMay"
        Me.RevMay.Visible = False
        Me.RevMay.Width = 76
        '
        'RevJun
        '
        Me.RevJun.DataPropertyName = "RevJun"
        Me.RevJun.HeaderText = "RevJun"
        Me.RevJun.Name = "RevJun"
        Me.RevJun.Visible = False
        Me.RevJun.Width = 72
        '
        'RevJul
        '
        Me.RevJul.DataPropertyName = "RevJul"
        Me.RevJul.HeaderText = "RevJul"
        Me.RevJul.Name = "RevJul"
        Me.RevJul.Visible = False
        Me.RevJul.Width = 68
        '
        'RevAug
        '
        Me.RevAug.DataPropertyName = "RevAug"
        Me.RevAug.HeaderText = "RevAug"
        Me.RevAug.Name = "RevAug"
        Me.RevAug.Visible = False
        Me.RevAug.Width = 75
        '
        'RevSep
        '
        Me.RevSep.DataPropertyName = "RevSep"
        Me.RevSep.HeaderText = "RevSep"
        Me.RevSep.Name = "RevSep"
        Me.RevSep.Visible = False
        Me.RevSep.Width = 75
        '
        'RevOct
        '
        Me.RevOct.DataPropertyName = "RevOct"
        Me.RevOct.HeaderText = "RevOct"
        Me.RevOct.Name = "RevOct"
        Me.RevOct.Visible = False
        Me.RevOct.Width = 72
        '
        'RevNov
        '
        Me.RevNov.DataPropertyName = "RevNov"
        Me.RevNov.HeaderText = "RevNov"
        Me.RevNov.Name = "RevNov"
        Me.RevNov.Visible = False
        Me.RevNov.Width = 75
        '
        'RevDec
        '
        Me.RevDec.DataPropertyName = "RevDec"
        Me.RevDec.HeaderText = "RevDec"
        Me.RevDec.Name = "RevDec"
        Me.RevDec.Visible = False
        Me.RevDec.Width = 75
        '
        'PinkJan
        '
        Me.PinkJan.DataPropertyName = "PinkJan"
        Me.PinkJan.HeaderText = "PinkJan"
        Me.PinkJan.Name = "PinkJan"
        Me.PinkJan.Visible = False
        Me.PinkJan.Width = 74
        '
        'PinkFeb
        '
        Me.PinkFeb.DataPropertyName = "PinkFeb"
        Me.PinkFeb.HeaderText = "PinkFeb"
        Me.PinkFeb.Name = "PinkFeb"
        Me.PinkFeb.Visible = False
        Me.PinkFeb.Width = 75
        '
        'PinkMar
        '
        Me.PinkMar.DataPropertyName = "PinkMar"
        Me.PinkMar.HeaderText = "PinkMar"
        Me.PinkMar.Name = "PinkMar"
        Me.PinkMar.Visible = False
        Me.PinkMar.Width = 76
        '
        'PinkApr
        '
        Me.PinkApr.DataPropertyName = "PinkApr"
        Me.PinkApr.HeaderText = "PinkApr"
        Me.PinkApr.Name = "PinkApr"
        Me.PinkApr.Visible = False
        Me.PinkApr.Width = 75
        '
        'PinkMay
        '
        Me.PinkMay.DataPropertyName = "PinkMay"
        Me.PinkMay.HeaderText = "PinkMay"
        Me.PinkMay.Name = "PinkMay"
        Me.PinkMay.Visible = False
        Me.PinkMay.Width = 78
        '
        'PinkJun
        '
        Me.PinkJun.DataPropertyName = "PinkJun"
        Me.PinkJun.HeaderText = "PinkJun"
        Me.PinkJun.Name = "PinkJun"
        Me.PinkJun.Visible = False
        Me.PinkJun.Width = 74
        '
        'PinkJul
        '
        Me.PinkJul.DataPropertyName = "PinkJul"
        Me.PinkJul.HeaderText = "PinkJul"
        Me.PinkJul.Name = "PinkJul"
        Me.PinkJul.Visible = False
        Me.PinkJul.Width = 70
        '
        'PinkAug
        '
        Me.PinkAug.DataPropertyName = "PinkAug"
        Me.PinkAug.HeaderText = "PinkAug"
        Me.PinkAug.Name = "PinkAug"
        Me.PinkAug.Visible = False
        Me.PinkAug.Width = 77
        '
        'PinkSep
        '
        Me.PinkSep.DataPropertyName = "PinkSep"
        Me.PinkSep.HeaderText = "PinkSep"
        Me.PinkSep.Name = "PinkSep"
        Me.PinkSep.Visible = False
        Me.PinkSep.Width = 77
        '
        'PinkOct
        '
        Me.PinkOct.DataPropertyName = "PinkOct"
        Me.PinkOct.HeaderText = "PinkOct"
        Me.PinkOct.Name = "PinkOct"
        Me.PinkOct.Visible = False
        Me.PinkOct.Width = 74
        '
        'PinkNov
        '
        Me.PinkNov.DataPropertyName = "PinkNov"
        Me.PinkNov.HeaderText = "PinkNov"
        Me.PinkNov.Name = "PinkNov"
        Me.PinkNov.Visible = False
        Me.PinkNov.Width = 77
        '
        'PinkDec
        '
        Me.PinkDec.DataPropertyName = "PinkDec"
        Me.PinkDec.HeaderText = "PinkDec"
        Me.PinkDec.Name = "PinkDec"
        Me.PinkDec.Visible = False
        Me.PinkDec.Width = 77
        '
        'Amount
        '
        Me.Amount.DataPropertyName = "Amount"
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.Width = 75
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 82
        '
        'BudgetTotal
        '
        Me.BudgetTotal.DataPropertyName = "BudgetTotal"
        Me.BudgetTotal.HeaderText = "BudgetTotal"
        Me.BudgetTotal.Name = "BudgetTotal"
        Me.BudgetTotal.Width = 99
        '
        'VersionNo
        '
        Me.VersionNo.DataPropertyName = "VersionNo"
        Me.VersionNo.HeaderText = "VersionNo"
        Me.VersionNo.Name = "VersionNo"
        Me.VersionNo.Width = 89
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 67
        '
        'lblBudgetTotal
        '
        Me.lblBudgetTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetTotal.Location = New System.Drawing.Point(844, 400)
        Me.lblBudgetTotal.Name = "lblBudgetTotal"
        Me.lblBudgetTotal.Size = New System.Drawing.Size(135, 21)
        Me.lblBudgetTotal.TabIndex = 247
        '
        'lblBudgetTotalL
        '
        Me.lblBudgetTotalL.AutoSize = True
        Me.lblBudgetTotalL.Location = New System.Drawing.Point(735, 400)
        Me.lblBudgetTotalL.Name = "lblBudgetTotalL"
        Me.lblBudgetTotalL.Size = New System.Drawing.Size(79, 13)
        Me.lblBudgetTotalL.TabIndex = 246
        Me.lblBudgetTotalL.Text = "Budget Total"
        '
        'grpMonths
        '
        Me.grpMonths.Controls.Add(Me.Label29)
        Me.grpMonths.Controls.Add(Me.Label30)
        Me.grpMonths.Controls.Add(Me.Label26)
        Me.grpMonths.Controls.Add(Me.Label27)
        Me.grpMonths.Controls.Add(Me.Label21)
        Me.grpMonths.Controls.Add(Me.Label20)
        Me.grpMonths.Controls.Add(Me.lblRevisionDec)
        Me.grpMonths.Controls.Add(Me.lblBudgetDec)
        Me.grpMonths.Controls.Add(Me.lblRevisionAug)
        Me.grpMonths.Controls.Add(Me.lblBudgetAug)
        Me.grpMonths.Controls.Add(Me.lblRevisionApr)
        Me.grpMonths.Controls.Add(Me.lblBudgetApr)
        Me.grpMonths.Controls.Add(Me.Label32)
        Me.grpMonths.Controls.Add(Me.Label33)
        Me.grpMonths.Controls.Add(Me.Label35)
        Me.grpMonths.Controls.Add(Me.Label36)
        Me.grpMonths.Controls.Add(Me.Label38)
        Me.grpMonths.Controls.Add(Me.Label39)
        Me.grpMonths.Controls.Add(Me.lblRevisionNov)
        Me.grpMonths.Controls.Add(Me.lblBudgetNov)
        Me.grpMonths.Controls.Add(Me.lblRevisionJul)
        Me.grpMonths.Controls.Add(Me.lblBudgetJul)
        Me.grpMonths.Controls.Add(Me.lblRevisionMar)
        Me.grpMonths.Controls.Add(Me.lblBudgetMar)
        Me.grpMonths.Controls.Add(Me.Label41)
        Me.grpMonths.Controls.Add(Me.Label42)
        Me.grpMonths.Controls.Add(Me.Label44)
        Me.grpMonths.Controls.Add(Me.Label45)
        Me.grpMonths.Controls.Add(Me.Label47)
        Me.grpMonths.Controls.Add(Me.Label48)
        Me.grpMonths.Controls.Add(Me.lblRevisionOct)
        Me.grpMonths.Controls.Add(Me.lblBudgetOct)
        Me.grpMonths.Controls.Add(Me.lblRevisionJun)
        Me.grpMonths.Controls.Add(Me.lblBudgetJun)
        Me.grpMonths.Controls.Add(Me.lblRevisionFeb)
        Me.grpMonths.Controls.Add(Me.lblBudgetFeb)
        Me.grpMonths.Controls.Add(Me.Label50)
        Me.grpMonths.Controls.Add(Me.Label51)
        Me.grpMonths.Controls.Add(Me.Label53)
        Me.grpMonths.Controls.Add(Me.Label54)
        Me.grpMonths.Controls.Add(Me.Label56)
        Me.grpMonths.Controls.Add(Me.Label57)
        Me.grpMonths.Controls.Add(Me.lblRevisionSep)
        Me.grpMonths.Controls.Add(Me.lblBudgetSep)
        Me.grpMonths.Controls.Add(Me.lblRevisionMay)
        Me.grpMonths.Controls.Add(Me.lblBudgetMay)
        Me.grpMonths.Controls.Add(Me.lblRevisionJan)
        Me.grpMonths.Controls.Add(Me.lblBudgetJan)
        Me.grpMonths.Controls.Add(Me.txtRevDec)
        Me.grpMonths.Controls.Add(Me.txtBudgetDec)
        Me.grpMonths.Controls.Add(Me.txtRevAug)
        Me.grpMonths.Controls.Add(Me.txtBudgetAug)
        Me.grpMonths.Controls.Add(Me.txtRevApr)
        Me.grpMonths.Controls.Add(Me.txtBudgetApr)
        Me.grpMonths.Controls.Add(Me.txtRevNov)
        Me.grpMonths.Controls.Add(Me.txtBudgetNov)
        Me.grpMonths.Controls.Add(Me.txtRevJul)
        Me.grpMonths.Controls.Add(Me.txtBudgetJul)
        Me.grpMonths.Controls.Add(Me.txtRevMar)
        Me.grpMonths.Controls.Add(Me.txtBudgetMar)
        Me.grpMonths.Controls.Add(Me.txtRevOct)
        Me.grpMonths.Controls.Add(Me.txtBudgetOct)
        Me.grpMonths.Controls.Add(Me.txtRevJun)
        Me.grpMonths.Controls.Add(Me.txtBudgetJun)
        Me.grpMonths.Controls.Add(Me.txtRevFeb)
        Me.grpMonths.Controls.Add(Me.txtBudgetFeb)
        Me.grpMonths.Controls.Add(Me.txtRevSep)
        Me.grpMonths.Controls.Add(Me.txtBudgetSep)
        Me.grpMonths.Controls.Add(Me.txtRevMay)
        Me.grpMonths.Controls.Add(Me.txtBudgetMay)
        Me.grpMonths.Controls.Add(Me.txtRevJan)
        Me.grpMonths.Controls.Add(Me.txtBudgetJan)
        Me.grpMonths.Controls.Add(Me.lblRPM3)
        Me.grpMonths.Controls.Add(Me.lblRPM2)
        Me.grpMonths.Controls.Add(Me.lblRPM1)
        Me.grpMonths.Controls.Add(Me.lblRPM)
        Me.grpMonths.Controls.Add(Me.lblRevisions)
        Me.grpMonths.Controls.Add(Me.lblBudgets)
        Me.grpMonths.Controls.Add(Me.lblRevisionL)
        Me.grpMonths.Controls.Add(Me.lblBudgetL)
        Me.grpMonths.Controls.Add(Me.lblRevision)
        Me.grpMonths.Controls.Add(Me.lblBudget)
        Me.grpMonths.Location = New System.Drawing.Point(11, 189)
        Me.grpMonths.Name = "grpMonths"
        Me.grpMonths.Size = New System.Drawing.Size(1027, 205)
        Me.grpMonths.TabIndex = 9
        Me.grpMonths.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(806, 29)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 2331
        Me.Label29.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(806, 52)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(11, 13)
        Me.Label30.TabIndex = 2330
        Me.Label30.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(806, 90)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 2328
        Me.Label26.Text = ":"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(806, 113)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 2327
        Me.Label27.Text = ":"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(806, 150)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 2325
        Me.Label21.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(806, 173)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 2324
        Me.Label20.Text = ":"
        '
        'lblRevisionDec
        '
        Me.lblRevisionDec.AutoSize = True
        Me.lblRevisionDec.Location = New System.Drawing.Point(750, 173)
        Me.lblRevisionDec.Name = "lblRevisionDec"
        Me.lblRevisionDec.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionDec.TabIndex = 2321
        Me.lblRevisionDec.Text = "Dec"
        '
        'lblBudgetDec
        '
        Me.lblBudgetDec.AutoSize = True
        Me.lblBudgetDec.Location = New System.Drawing.Point(750, 150)
        Me.lblBudgetDec.Name = "lblBudgetDec"
        Me.lblBudgetDec.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetDec.TabIndex = 2320
        Me.lblBudgetDec.Text = "Dec"
        '
        'lblRevisionAug
        '
        Me.lblRevisionAug.AutoSize = True
        Me.lblRevisionAug.Location = New System.Drawing.Point(750, 111)
        Me.lblRevisionAug.Name = "lblRevisionAug"
        Me.lblRevisionAug.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionAug.TabIndex = 2318
        Me.lblRevisionAug.Text = "Aug"
        '
        'lblBudgetAug
        '
        Me.lblBudgetAug.AutoSize = True
        Me.lblBudgetAug.Location = New System.Drawing.Point(750, 87)
        Me.lblBudgetAug.Name = "lblBudgetAug"
        Me.lblBudgetAug.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetAug.TabIndex = 2317
        Me.lblBudgetAug.Text = "Aug"
        '
        'lblRevisionApr
        '
        Me.lblRevisionApr.AutoSize = True
        Me.lblRevisionApr.Location = New System.Drawing.Point(750, 50)
        Me.lblRevisionApr.Name = "lblRevisionApr"
        Me.lblRevisionApr.Size = New System.Drawing.Size(27, 13)
        Me.lblRevisionApr.TabIndex = 2315
        Me.lblRevisionApr.Text = "Apr"
        '
        'lblBudgetApr
        '
        Me.lblBudgetApr.AutoSize = True
        Me.lblBudgetApr.Location = New System.Drawing.Point(750, 26)
        Me.lblBudgetApr.Name = "lblBudgetApr"
        Me.lblBudgetApr.Size = New System.Drawing.Size(27, 13)
        Me.lblBudgetApr.TabIndex = 2314
        Me.lblBudgetApr.Text = "Apr"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(567, 32)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(11, 13)
        Me.Label32.TabIndex = 2313
        Me.Label32.Text = ":"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(567, 55)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(11, 13)
        Me.Label33.TabIndex = 2312
        Me.Label33.Text = ":"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(567, 93)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(11, 13)
        Me.Label35.TabIndex = 2310
        Me.Label35.Text = ":"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(567, 116)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 13)
        Me.Label36.TabIndex = 2309
        Me.Label36.Text = ":"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(567, 153)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 13)
        Me.Label38.TabIndex = 2307
        Me.Label38.Text = ":"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(567, 176)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(11, 13)
        Me.Label39.TabIndex = 2306
        Me.Label39.Text = ":"
        '
        'lblRevisionNov
        '
        Me.lblRevisionNov.AutoSize = True
        Me.lblRevisionNov.Location = New System.Drawing.Point(516, 176)
        Me.lblRevisionNov.Name = "lblRevisionNov"
        Me.lblRevisionNov.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionNov.TabIndex = 2303
        Me.lblRevisionNov.Text = "Nov"
        '
        'lblBudgetNov
        '
        Me.lblBudgetNov.AutoSize = True
        Me.lblBudgetNov.Location = New System.Drawing.Point(516, 153)
        Me.lblBudgetNov.Name = "lblBudgetNov"
        Me.lblBudgetNov.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetNov.TabIndex = 2302
        Me.lblBudgetNov.Text = "Nov"
        '
        'lblRevisionJul
        '
        Me.lblRevisionJul.AutoSize = True
        Me.lblRevisionJul.Location = New System.Drawing.Point(516, 114)
        Me.lblRevisionJul.Name = "lblRevisionJul"
        Me.lblRevisionJul.Size = New System.Drawing.Size(22, 13)
        Me.lblRevisionJul.TabIndex = 2300
        Me.lblRevisionJul.Text = "Jul"
        '
        'lblBudgetJul
        '
        Me.lblBudgetJul.AutoSize = True
        Me.lblBudgetJul.Location = New System.Drawing.Point(516, 90)
        Me.lblBudgetJul.Name = "lblBudgetJul"
        Me.lblBudgetJul.Size = New System.Drawing.Size(22, 13)
        Me.lblBudgetJul.TabIndex = 2299
        Me.lblBudgetJul.Text = "Jul"
        '
        'lblRevisionMar
        '
        Me.lblRevisionMar.AutoSize = True
        Me.lblRevisionMar.Location = New System.Drawing.Point(516, 53)
        Me.lblRevisionMar.Name = "lblRevisionMar"
        Me.lblRevisionMar.Size = New System.Drawing.Size(28, 13)
        Me.lblRevisionMar.TabIndex = 2297
        Me.lblRevisionMar.Text = "Mar"
        '
        'lblBudgetMar
        '
        Me.lblBudgetMar.AutoSize = True
        Me.lblBudgetMar.Location = New System.Drawing.Point(516, 29)
        Me.lblBudgetMar.Name = "lblBudgetMar"
        Me.lblBudgetMar.Size = New System.Drawing.Size(32, 13)
        Me.lblBudgetMar.TabIndex = 2296
        Me.lblBudgetMar.Text = "Mar "
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(333, 32)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(11, 13)
        Me.Label41.TabIndex = 2295
        Me.Label41.Text = ":"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(333, 55)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(11, 13)
        Me.Label42.TabIndex = 2294
        Me.Label42.Text = ":"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(333, 93)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(11, 13)
        Me.Label44.TabIndex = 2292
        Me.Label44.Text = ":"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(333, 116)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(11, 13)
        Me.Label45.TabIndex = 2291
        Me.Label45.Text = ":"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(333, 153)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(11, 13)
        Me.Label47.TabIndex = 2289
        Me.Label47.Text = ":"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(333, 176)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(11, 13)
        Me.Label48.TabIndex = 2288
        Me.Label48.Text = ":"
        '
        'lblRevisionOct
        '
        Me.lblRevisionOct.AutoSize = True
        Me.lblRevisionOct.Location = New System.Drawing.Point(290, 176)
        Me.lblRevisionOct.Name = "lblRevisionOct"
        Me.lblRevisionOct.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionOct.TabIndex = 2285
        Me.lblRevisionOct.Text = "Oct"
        '
        'lblBudgetOct
        '
        Me.lblBudgetOct.AutoSize = True
        Me.lblBudgetOct.Location = New System.Drawing.Point(290, 153)
        Me.lblBudgetOct.Name = "lblBudgetOct"
        Me.lblBudgetOct.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetOct.TabIndex = 2284
        Me.lblBudgetOct.Text = "Oct"
        '
        'lblRevisionJun
        '
        Me.lblRevisionJun.AutoSize = True
        Me.lblRevisionJun.Location = New System.Drawing.Point(290, 114)
        Me.lblRevisionJun.Name = "lblRevisionJun"
        Me.lblRevisionJun.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJun.TabIndex = 2282
        Me.lblRevisionJun.Text = "Jun"
        '
        'lblBudgetJun
        '
        Me.lblBudgetJun.AutoSize = True
        Me.lblBudgetJun.Location = New System.Drawing.Point(290, 90)
        Me.lblBudgetJun.Name = "lblBudgetJun"
        Me.lblBudgetJun.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJun.TabIndex = 2281
        Me.lblBudgetJun.Text = "Jun"
        '
        'lblRevisionFeb
        '
        Me.lblRevisionFeb.AutoSize = True
        Me.lblRevisionFeb.Location = New System.Drawing.Point(290, 53)
        Me.lblRevisionFeb.Name = "lblRevisionFeb"
        Me.lblRevisionFeb.Size = New System.Drawing.Size(27, 13)
        Me.lblRevisionFeb.TabIndex = 2279
        Me.lblRevisionFeb.Text = "Feb"
        '
        'lblBudgetFeb
        '
        Me.lblBudgetFeb.AutoSize = True
        Me.lblBudgetFeb.Location = New System.Drawing.Point(290, 29)
        Me.lblBudgetFeb.Name = "lblBudgetFeb"
        Me.lblBudgetFeb.Size = New System.Drawing.Size(27, 13)
        Me.lblBudgetFeb.TabIndex = 2278
        Me.lblBudgetFeb.Text = "Feb"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(120, 29)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(11, 13)
        Me.Label50.TabIndex = 2277
        Me.Label50.Text = ":"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(120, 52)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(11, 13)
        Me.Label51.TabIndex = 2276
        Me.Label51.Text = ":"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(120, 90)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(11, 13)
        Me.Label53.TabIndex = 2274
        Me.Label53.Text = ":"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(120, 113)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(11, 13)
        Me.Label54.TabIndex = 2273
        Me.Label54.Text = ":"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(120, 150)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(11, 13)
        Me.Label56.TabIndex = 2271
        Me.Label56.Text = ":"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(120, 173)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(11, 13)
        Me.Label57.TabIndex = 2270
        Me.Label57.Text = ":"
        '
        'lblRevisionSep
        '
        Me.lblRevisionSep.AutoSize = True
        Me.lblRevisionSep.Location = New System.Drawing.Point(72, 173)
        Me.lblRevisionSep.Name = "lblRevisionSep"
        Me.lblRevisionSep.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionSep.TabIndex = 2267
        Me.lblRevisionSep.Text = "Sep"
        '
        'lblBudgetSep
        '
        Me.lblBudgetSep.AutoSize = True
        Me.lblBudgetSep.Location = New System.Drawing.Point(72, 150)
        Me.lblBudgetSep.Name = "lblBudgetSep"
        Me.lblBudgetSep.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetSep.TabIndex = 2266
        Me.lblBudgetSep.Text = "Sep"
        '
        'lblRevisionMay
        '
        Me.lblRevisionMay.AutoSize = True
        Me.lblRevisionMay.Location = New System.Drawing.Point(72, 111)
        Me.lblRevisionMay.Name = "lblRevisionMay"
        Me.lblRevisionMay.Size = New System.Drawing.Size(30, 13)
        Me.lblRevisionMay.TabIndex = 2264
        Me.lblRevisionMay.Text = "May"
        '
        'lblBudgetMay
        '
        Me.lblBudgetMay.AutoSize = True
        Me.lblBudgetMay.Location = New System.Drawing.Point(72, 87)
        Me.lblBudgetMay.Name = "lblBudgetMay"
        Me.lblBudgetMay.Size = New System.Drawing.Size(30, 13)
        Me.lblBudgetMay.TabIndex = 2263
        Me.lblBudgetMay.Text = "May"
        '
        'lblRevisionJan
        '
        Me.lblRevisionJan.AutoSize = True
        Me.lblRevisionJan.Location = New System.Drawing.Point(72, 50)
        Me.lblRevisionJan.Name = "lblRevisionJan"
        Me.lblRevisionJan.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJan.TabIndex = 2261
        Me.lblRevisionJan.Text = "Jan"
        '
        'lblBudgetJan
        '
        Me.lblBudgetJan.AutoSize = True
        Me.lblBudgetJan.Location = New System.Drawing.Point(72, 26)
        Me.lblBudgetJan.Name = "lblBudgetJan"
        Me.lblBudgetJan.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJan.TabIndex = 2260
        Me.lblBudgetJan.Text = "Jan"
        '
        'txtRevDec
        '
        Me.txtRevDec.Location = New System.Drawing.Point(834, 173)
        Me.txtRevDec.Name = "txtRevDec"
        Me.txtRevDec.Size = New System.Drawing.Size(135, 21)
        Me.txtRevDec.TabIndex = 32
        '
        'txtBudgetDec
        '
        Me.txtBudgetDec.Location = New System.Drawing.Point(834, 150)
        Me.txtBudgetDec.Name = "txtBudgetDec"
        Me.txtBudgetDec.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetDec.TabIndex = 20
        '
        'txtRevAug
        '
        Me.txtRevAug.Location = New System.Drawing.Point(834, 111)
        Me.txtRevAug.Name = "txtRevAug"
        Me.txtRevAug.Size = New System.Drawing.Size(135, 21)
        Me.txtRevAug.TabIndex = 28
        '
        'txtBudgetAug
        '
        Me.txtBudgetAug.Location = New System.Drawing.Point(834, 87)
        Me.txtBudgetAug.Name = "txtBudgetAug"
        Me.txtBudgetAug.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetAug.TabIndex = 16
        '
        'txtRevApr
        '
        Me.txtRevApr.Location = New System.Drawing.Point(834, 50)
        Me.txtRevApr.Name = "txtRevApr"
        Me.txtRevApr.Size = New System.Drawing.Size(135, 21)
        Me.txtRevApr.TabIndex = 24
        '
        'txtBudgetApr
        '
        Me.txtBudgetApr.Location = New System.Drawing.Point(834, 26)
        Me.txtBudgetApr.Name = "txtBudgetApr"
        Me.txtBudgetApr.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetApr.TabIndex = 12
        '
        'txtRevNov
        '
        Me.txtRevNov.Location = New System.Drawing.Point(592, 173)
        Me.txtRevNov.Name = "txtRevNov"
        Me.txtRevNov.Size = New System.Drawing.Size(135, 21)
        Me.txtRevNov.TabIndex = 31
        '
        'txtBudgetNov
        '
        Me.txtBudgetNov.Location = New System.Drawing.Point(592, 150)
        Me.txtBudgetNov.Name = "txtBudgetNov"
        Me.txtBudgetNov.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetNov.TabIndex = 19
        '
        'txtRevJul
        '
        Me.txtRevJul.Location = New System.Drawing.Point(592, 111)
        Me.txtRevJul.Name = "txtRevJul"
        Me.txtRevJul.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJul.TabIndex = 27
        '
        'txtBudgetJul
        '
        Me.txtBudgetJul.Location = New System.Drawing.Point(592, 87)
        Me.txtBudgetJul.Name = "txtBudgetJul"
        Me.txtBudgetJul.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetJul.TabIndex = 15
        '
        'txtRevMar
        '
        Me.txtRevMar.Location = New System.Drawing.Point(592, 50)
        Me.txtRevMar.Name = "txtRevMar"
        Me.txtRevMar.Size = New System.Drawing.Size(135, 21)
        Me.txtRevMar.TabIndex = 2223
        '
        'txtBudgetMar
        '
        Me.txtBudgetMar.Location = New System.Drawing.Point(592, 26)
        Me.txtBudgetMar.Name = "txtBudgetMar"
        Me.txtBudgetMar.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetMar.TabIndex = 11
        '
        'txtRevOct
        '
        Me.txtRevOct.Location = New System.Drawing.Point(367, 173)
        Me.txtRevOct.Name = "txtRevOct"
        Me.txtRevOct.Size = New System.Drawing.Size(135, 21)
        Me.txtRevOct.TabIndex = 30
        '
        'txtBudgetOct
        '
        Me.txtBudgetOct.Location = New System.Drawing.Point(367, 150)
        Me.txtBudgetOct.Name = "txtBudgetOct"
        Me.txtBudgetOct.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetOct.TabIndex = 18
        '
        'txtRevJun
        '
        Me.txtRevJun.Location = New System.Drawing.Point(367, 111)
        Me.txtRevJun.Name = "txtRevJun"
        Me.txtRevJun.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJun.TabIndex = 26
        '
        'txtBudgetJun
        '
        Me.txtBudgetJun.Location = New System.Drawing.Point(367, 87)
        Me.txtBudgetJun.Name = "txtBudgetJun"
        Me.txtBudgetJun.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetJun.TabIndex = 14
        '
        'txtRevFeb
        '
        Me.txtRevFeb.Location = New System.Drawing.Point(367, 50)
        Me.txtRevFeb.Name = "txtRevFeb"
        Me.txtRevFeb.Size = New System.Drawing.Size(135, 21)
        Me.txtRevFeb.TabIndex = 21
        '
        'txtBudgetFeb
        '
        Me.txtBudgetFeb.Location = New System.Drawing.Point(367, 26)
        Me.txtBudgetFeb.Name = "txtBudgetFeb"
        Me.txtBudgetFeb.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetFeb.TabIndex = 10
        '
        'txtRevSep
        '
        Me.txtRevSep.Location = New System.Drawing.Point(145, 173)
        Me.txtRevSep.Name = "txtRevSep"
        Me.txtRevSep.Size = New System.Drawing.Size(135, 21)
        Me.txtRevSep.TabIndex = 29
        '
        'txtBudgetSep
        '
        Me.txtBudgetSep.Location = New System.Drawing.Point(145, 150)
        Me.txtBudgetSep.Name = "txtBudgetSep"
        Me.txtBudgetSep.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetSep.TabIndex = 17
        '
        'txtRevMay
        '
        Me.txtRevMay.Location = New System.Drawing.Point(145, 111)
        Me.txtRevMay.Name = "txtRevMay"
        Me.txtRevMay.Size = New System.Drawing.Size(135, 21)
        Me.txtRevMay.TabIndex = 25
        '
        'txtBudgetMay
        '
        Me.txtBudgetMay.Location = New System.Drawing.Point(145, 87)
        Me.txtBudgetMay.Name = "txtBudgetMay"
        Me.txtBudgetMay.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetMay.TabIndex = 13
        '
        'txtRevJan
        '
        Me.txtRevJan.Location = New System.Drawing.Point(145, 50)
        Me.txtRevJan.Name = "txtRevJan"
        Me.txtRevJan.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJan.TabIndex = 21
        '
        'txtBudgetJan
        '
        Me.txtBudgetJan.Location = New System.Drawing.Point(145, 26)
        Me.txtBudgetJan.Name = "txtBudgetJan"
        Me.txtBudgetJan.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetJan.TabIndex = 9
        '
        'lblRPM3
        '
        Me.lblRPM3.AutoSize = True
        Me.lblRPM3.Location = New System.Drawing.Point(875, 10)
        Me.lblRPM3.Name = "lblRPM3"
        Me.lblRPM3.Size = New System.Drawing.Size(48, 13)
        Me.lblRPM3.TabIndex = 48
        Me.lblRPM3.Text = "Tonnes"
        '
        'lblRPM2
        '
        Me.lblRPM2.AutoSize = True
        Me.lblRPM2.Location = New System.Drawing.Point(627, 10)
        Me.lblRPM2.Name = "lblRPM2"
        Me.lblRPM2.Size = New System.Drawing.Size(48, 13)
        Me.lblRPM2.TabIndex = 47
        Me.lblRPM2.Text = "Tonnes"
        '
        'lblRPM1
        '
        Me.lblRPM1.AutoSize = True
        Me.lblRPM1.Location = New System.Drawing.Point(403, 10)
        Me.lblRPM1.Name = "lblRPM1"
        Me.lblRPM1.Size = New System.Drawing.Size(48, 13)
        Me.lblRPM1.TabIndex = 46
        Me.lblRPM1.Text = "Tonnes"
        '
        'lblRPM
        '
        Me.lblRPM.AutoSize = True
        Me.lblRPM.Location = New System.Drawing.Point(175, 10)
        Me.lblRPM.Name = "lblRPM"
        Me.lblRPM.Size = New System.Drawing.Size(48, 13)
        Me.lblRPM.TabIndex = 45
        Me.lblRPM.Text = "Tonnes"
        '
        'lblRevisions
        '
        Me.lblRevisions.AutoSize = True
        Me.lblRevisions.Location = New System.Drawing.Point(6, 173)
        Me.lblRevisions.Name = "lblRevisions"
        Me.lblRevisions.Size = New System.Drawing.Size(55, 13)
        Me.lblRevisions.TabIndex = 7
        Me.lblRevisions.Text = "Revision"
        '
        'lblBudgets
        '
        Me.lblBudgets.AutoSize = True
        Me.lblBudgets.Location = New System.Drawing.Point(6, 150)
        Me.lblBudgets.Name = "lblBudgets"
        Me.lblBudgets.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgets.TabIndex = 6
        Me.lblBudgets.Text = "Budget"
        '
        'lblRevisionL
        '
        Me.lblRevisionL.AutoSize = True
        Me.lblRevisionL.Location = New System.Drawing.Point(6, 111)
        Me.lblRevisionL.Name = "lblRevisionL"
        Me.lblRevisionL.Size = New System.Drawing.Size(55, 13)
        Me.lblRevisionL.TabIndex = 4
        Me.lblRevisionL.Text = "Revision"
        '
        'lblBudgetL
        '
        Me.lblBudgetL.AutoSize = True
        Me.lblBudgetL.Location = New System.Drawing.Point(6, 87)
        Me.lblBudgetL.Name = "lblBudgetL"
        Me.lblBudgetL.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetL.TabIndex = 3
        Me.lblBudgetL.Text = "Budget"
        '
        'lblRevision
        '
        Me.lblRevision.AutoSize = True
        Me.lblRevision.Location = New System.Drawing.Point(6, 50)
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Size = New System.Drawing.Size(55, 13)
        Me.lblRevision.TabIndex = 1
        Me.lblRevision.Text = "Revision"
        '
        'lblBudget
        '
        Me.lblBudget.AutoSize = True
        Me.lblBudget.Location = New System.Drawing.Point(6, 26)
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.Size = New System.Drawing.Size(47, 13)
        Me.lblBudget.TabIndex = 0
        Me.lblBudget.Text = "Budget"
        '
        'grpBudgetYear
        '
        Me.grpBudgetYear.AutoSize = True
        Me.grpBudgetYear.Controls.Add(Me.btnDistribute)
        Me.grpBudgetYear.Controls.Add(Me.txtTotalTonnage)
        Me.grpBudgetYear.Controls.Add(Me.Label7)
        Me.grpBudgetYear.Controls.Add(Me.lblTotalTonnage)
        Me.grpBudgetYear.Controls.Add(Me.Label16)
        Me.grpBudgetYear.Controls.Add(Me.lblOldAccCode)
        Me.grpBudgetYear.Controls.Add(Me.lblOldCOACode)
        Me.grpBudgetYear.Controls.Add(Me.lblCOADescp)
        Me.grpBudgetYear.Controls.Add(Me.btnSearchAccountCode)
        Me.grpBudgetYear.Controls.Add(Me.txtCOACode)
        Me.grpBudgetYear.Controls.Add(Me.Label5)
        Me.grpBudgetYear.Controls.Add(Me.lblCOA)
        Me.grpBudgetYear.Controls.Add(Me.btnSearchVehicleCategory)
        Me.grpBudgetYear.Controls.Add(Me.Label23)
        Me.grpBudgetYear.Controls.Add(Me.txtVehicleCategory)
        Me.grpBudgetYear.Controls.Add(Me.lblVehicleCategory)
        Me.grpBudgetYear.Controls.Add(Me.Label8)
        Me.grpBudgetYear.Controls.Add(Me.txtYOP)
        Me.grpBudgetYear.Controls.Add(Me.lblRemark)
        Me.grpBudgetYear.Controls.Add(Me.Label18)
        Me.grpBudgetYear.Controls.Add(Me.Label17)
        Me.grpBudgetYear.Controls.Add(Me.lblStatus)
        Me.grpBudgetYear.Controls.Add(Me.lblStatusL)
        Me.grpBudgetYear.Controls.Add(Me.lblVersionNo)
        Me.grpBudgetYear.Controls.Add(Me.lblVersionNoL)
        Me.grpBudgetYear.Controls.Add(Me.Label2)
        Me.grpBudgetYear.Controls.Add(Me.lblBudgetYear)
        Me.grpBudgetYear.Controls.Add(Me.lblBudgetyearL)
        Me.grpBudgetYear.Location = New System.Drawing.Point(6, 6)
        Me.grpBudgetYear.Name = "grpBudgetYear"
        Me.grpBudgetYear.Size = New System.Drawing.Size(1032, 196)
        Me.grpBudgetYear.TabIndex = 4
        Me.grpBudgetYear.TabStop = False
        '
        'btnDistribute
        '
        Me.btnDistribute.Location = New System.Drawing.Point(298, 122)
        Me.btnDistribute.Name = "btnDistribute"
        Me.btnDistribute.Size = New System.Drawing.Size(165, 23)
        Me.btnDistribute.TabIndex = 237
        Me.btnDistribute.Text = "Distribute to 12 months"
        Me.btnDistribute.UseVisualStyleBackColor = True
        '
        'txtTotalTonnage
        '
        Me.txtTotalTonnage.Location = New System.Drawing.Point(154, 124)
        Me.txtTotalTonnage.Name = "txtTotalTonnage"
        Me.txtTotalTonnage.Size = New System.Drawing.Size(135, 21)
        Me.txtTotalTonnage.TabIndex = 236
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(137, 124)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 13)
        Me.Label7.TabIndex = 238
        Me.Label7.Text = ":"
        '
        'lblTotalTonnage
        '
        Me.lblTotalTonnage.AutoSize = True
        Me.lblTotalTonnage.ForeColor = System.Drawing.Color.Red
        Me.lblTotalTonnage.Location = New System.Drawing.Point(9, 124)
        Me.lblTotalTonnage.Name = "lblTotalTonnage"
        Me.lblTotalTonnage.Size = New System.Drawing.Size(88, 13)
        Me.lblTotalTonnage.TabIndex = 235
        Me.lblTotalTonnage.Text = "Total Tonnage"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(137, 95)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 13)
        Me.Label16.TabIndex = 234
        Me.Label16.Text = ":"
        '
        'lblOldAccCode
        '
        Me.lblOldAccCode.AutoSize = True
        Me.lblOldAccCode.Location = New System.Drawing.Point(9, 95)
        Me.lblOldAccCode.Name = "lblOldAccCode"
        Me.lblOldAccCode.Size = New System.Drawing.Size(90, 13)
        Me.lblOldAccCode.TabIndex = 233
        Me.lblOldAccCode.Text = "Old COA Code"
        '
        'lblOldCOACode
        '
        Me.lblOldCOACode.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblOldCOACode.Location = New System.Drawing.Point(154, 99)
        Me.lblOldCOACode.Name = "lblOldCOACode"
        Me.lblOldCOACode.Size = New System.Drawing.Size(118, 15)
        Me.lblOldCOACode.TabIndex = 232
        Me.lblOldCOACode.Text = "Old COACode"
        Me.lblOldCOACode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCOADescp
        '
        Me.lblCOADescp.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescp.Location = New System.Drawing.Point(336, 63)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(152, 49)
        Me.lblCOADescp.TabIndex = 231
        Me.lblCOADescp.Text = "COA Desc"
        '
        'btnSearchAccountCode
        '
        Me.btnSearchAccountCode.BackgroundImage = CType(resources.GetObject("btnSearchAccountCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchAccountCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchAccountCode.FlatAppearance.BorderSize = 0
        Me.btnSearchAccountCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchAccountCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchAccountCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchAccountCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchAccountCode.Location = New System.Drawing.Point(295, 65)
        Me.btnSearchAccountCode.Name = "btnSearchAccountCode"
        Me.btnSearchAccountCode.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchAccountCode.TabIndex = 230
        Me.btnSearchAccountCode.TabStop = False
        Me.btnSearchAccountCode.UseVisualStyleBackColor = True
        '
        'txtCOACode
        '
        Me.txtCOACode.Location = New System.Drawing.Point(154, 69)
        Me.txtCOACode.Name = "txtCOACode"
        Me.txtCOACode.Size = New System.Drawing.Size(135, 21)
        Me.txtCOACode.TabIndex = 228
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(137, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(12, 13)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = ":"
        '
        'lblCOA
        '
        Me.lblCOA.AutoSize = True
        Me.lblCOA.ForeColor = System.Drawing.Color.Red
        Me.lblCOA.Location = New System.Drawing.Point(9, 69)
        Me.lblCOA.Name = "lblCOA"
        Me.lblCOA.Size = New System.Drawing.Size(33, 13)
        Me.lblCOA.TabIndex = 227
        Me.lblCOA.Text = "COA"
        '
        'btnSearchVehicleCategory
        '
        Me.btnSearchVehicleCategory.BackgroundImage = CType(resources.GetObject("btnSearchVehicleCategory.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVehicleCategory.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVehicleCategory.FlatAppearance.BorderSize = 0
        Me.btnSearchVehicleCategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVehicleCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVehicleCategory.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVehicleCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVehicleCategory.Location = New System.Drawing.Point(296, 33)
        Me.btnSearchVehicleCategory.Name = "btnSearchVehicleCategory"
        Me.btnSearchVehicleCategory.Size = New System.Drawing.Size(30, 26)
        Me.btnSearchVehicleCategory.TabIndex = 216
        Me.btnSearchVehicleCategory.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(137, 44)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(11, 13)
        Me.Label23.TabIndex = 226
        Me.Label23.Text = ":"
        '
        'txtVehicleCategory
        '
        Me.txtVehicleCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehicleCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVehicleCategory.Location = New System.Drawing.Point(154, 42)
        Me.txtVehicleCategory.Name = "txtVehicleCategory"
        Me.txtVehicleCategory.Size = New System.Drawing.Size(135, 21)
        Me.txtVehicleCategory.TabIndex = 215
        '
        'lblVehicleCategory
        '
        Me.lblVehicleCategory.AutoSize = True
        Me.lblVehicleCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVehicleCategory.ForeColor = System.Drawing.Color.Red
        Me.lblVehicleCategory.Location = New System.Drawing.Point(9, 42)
        Me.lblVehicleCategory.Name = "lblVehicleCategory"
        Me.lblVehicleCategory.Size = New System.Drawing.Size(105, 13)
        Me.lblVehicleCategory.TabIndex = 225
        Me.lblVehicleCategory.Text = "Vehicle Category"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(137, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 222
        Me.Label8.Text = ":"
        '
        'txtYOP
        '
        Me.txtYOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYOP.Enabled = False
        Me.txtYOP.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYOP.Location = New System.Drawing.Point(154, 156)
        Me.txtYOP.Multiline = True
        Me.txtYOP.Name = "txtYOP"
        Me.txtYOP.Size = New System.Drawing.Size(309, 20)
        Me.txtYOP.TabIndex = 217
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemark.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemark.Location = New System.Drawing.Point(9, 156)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(52, 13)
        Me.lblRemark.TabIndex = 221
        Me.lblRemark.Text = "Remark"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(922, 42)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 214
        Me.Label18.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(922, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 13)
        Me.Label17.TabIndex = 213
        Me.Label17.Text = ":"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(940, 37)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 20)
        Me.lblStatus.TabIndex = 147
        '
        'lblStatusL
        '
        Me.lblStatusL.AutoSize = True
        Me.lblStatusL.ForeColor = System.Drawing.Color.Black
        Me.lblStatusL.Location = New System.Drawing.Point(818, 38)
        Me.lblStatusL.Name = "lblStatusL"
        Me.lblStatusL.Size = New System.Drawing.Size(75, 13)
        Me.lblStatusL.TabIndex = 146
        Me.lblStatusL.Text = "Status        "
        '
        'lblVersionNo
        '
        Me.lblVersionNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVersionNo.Location = New System.Drawing.Point(940, 11)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(83, 21)
        Me.lblVersionNo.TabIndex = 143
        '
        'lblVersionNoL
        '
        Me.lblVersionNoL.AutoSize = True
        Me.lblVersionNoL.ForeColor = System.Drawing.Color.Black
        Me.lblVersionNoL.Location = New System.Drawing.Point(818, 12)
        Me.lblVersionNoL.Name = "lblVersionNoL"
        Me.lblVersionNoL.Size = New System.Drawing.Size(73, 13)
        Me.lblVersionNoL.TabIndex = 142
        Me.lblVersionNoL.Text = "Version No "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(137, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = ":"
        '
        'lblBudgetYear
        '
        Me.lblBudgetYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYear.Location = New System.Drawing.Point(154, 11)
        Me.lblBudgetYear.Name = "lblBudgetYear"
        Me.lblBudgetYear.Size = New System.Drawing.Size(135, 21)
        Me.lblBudgetYear.TabIndex = 4
        '
        'lblBudgetyearL
        '
        Me.lblBudgetyearL.AutoSize = True
        Me.lblBudgetyearL.Location = New System.Drawing.Point(9, 11)
        Me.lblBudgetyearL.Name = "lblBudgetyearL"
        Me.lblBudgetyearL.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetyearL.TabIndex = 0
        Me.lblBudgetyearL.Text = "Budget Year"
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(1081, 694)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'FFBTransportBudgetFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1210, 698)
        Me.Controls.Add(Me.tbFFBTransportBudget)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FFBTransportBudgetFrm"
        Me.Text = "FFBTransportBudgetFrm"
        Me.tbFFBTransportBudget.ResumeLayout(False)
        Me.tbFFBTransport.ResumeLayout(False)
        Me.tbFFBTransport.PerformLayout()
        Me.GrpGrid.ResumeLayout(False)
        CType(Me.dgAdminExpand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMonths.ResumeLayout(False)
        Me.grpMonths.PerformLayout()
        Me.grpBudgetYear.ResumeLayout(False)
        Me.grpBudgetYear.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbFFBTransportBudget As System.Windows.Forms.TabControl
    Friend WithEvents tbFFBTransport As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GrpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgAdminExpand As System.Windows.Forms.DataGridView
    Friend WithEvents AdminExpendID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BDGYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblBudgetTotal As System.Windows.Forms.Label
    Friend WithEvents lblBudgetTotalL As System.Windows.Forms.Label
    Friend WithEvents grpMonths As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblRevisionDec As System.Windows.Forms.Label
    Friend WithEvents lblBudgetDec As System.Windows.Forms.Label
    Friend WithEvents lblRevisionAug As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAug As System.Windows.Forms.Label
    Friend WithEvents lblRevisionApr As System.Windows.Forms.Label
    Friend WithEvents lblBudgetApr As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblRevisionNov As System.Windows.Forms.Label
    Friend WithEvents lblBudgetNov As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJul As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJul As System.Windows.Forms.Label
    Friend WithEvents lblRevisionMar As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMar As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents lblRevisionOct As System.Windows.Forms.Label
    Friend WithEvents lblBudgetOct As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJun As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJun As System.Windows.Forms.Label
    Friend WithEvents lblRevisionFeb As System.Windows.Forms.Label
    Friend WithEvents lblBudgetFeb As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents lblRevisionSep As System.Windows.Forms.Label
    Friend WithEvents lblBudgetSep As System.Windows.Forms.Label
    Friend WithEvents lblRevisionMay As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMay As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJan As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJan As System.Windows.Forms.Label
    Friend WithEvents txtRevDec As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetDec As System.Windows.Forms.TextBox
    Friend WithEvents txtRevAug As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetAug As System.Windows.Forms.TextBox
    Friend WithEvents txtRevApr As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetApr As System.Windows.Forms.TextBox
    Friend WithEvents txtRevNov As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetNov As System.Windows.Forms.TextBox
    Friend WithEvents txtRevJul As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJul As System.Windows.Forms.TextBox
    Friend WithEvents txtRevMar As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMar As System.Windows.Forms.TextBox
    Friend WithEvents txtRevOct As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetOct As System.Windows.Forms.TextBox
    Friend WithEvents txtRevJun As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJun As System.Windows.Forms.TextBox
    Friend WithEvents txtRevFeb As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetFeb As System.Windows.Forms.TextBox
    Friend WithEvents txtRevSep As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetSep As System.Windows.Forms.TextBox
    Friend WithEvents txtRevMay As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMay As System.Windows.Forms.TextBox
    Friend WithEvents txtRevJan As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJan As System.Windows.Forms.TextBox
    Friend WithEvents lblRPM3 As System.Windows.Forms.Label
    Friend WithEvents lblRPM2 As System.Windows.Forms.Label
    Friend WithEvents lblRPM1 As System.Windows.Forms.Label
    Friend WithEvents lblRPM As System.Windows.Forms.Label
    Friend WithEvents lblRevisions As System.Windows.Forms.Label
    Friend WithEvents lblBudgets As System.Windows.Forms.Label
    Friend WithEvents lblRevisionL As System.Windows.Forms.Label
    Friend WithEvents lblBudgetL As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents grpBudgetYear As System.Windows.Forms.GroupBox
    Friend WithEvents btnSearchVehicleCategory As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtVehicleCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblVehicleCategory As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtYOP As System.Windows.Forms.TextBox
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatusL As System.Windows.Forms.Label
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblVersionNoL As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYear As System.Windows.Forms.Label
    Friend WithEvents lblBudgetyearL As System.Windows.Forms.Label
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblOldAccCode As System.Windows.Forms.Label
    Friend WithEvents lblOldCOACode As System.Windows.Forms.Label
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchAccountCode As System.Windows.Forms.Button
    Friend WithEvents txtCOACode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblCOA As System.Windows.Forms.Label
    Friend WithEvents btnDistribute As System.Windows.Forms.Button
    Friend WithEvents txtTotalTonnage As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotalTonnage As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperatingBudgetCostFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperatingBudgetCostFrm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbOperatingBDGCost = New System.Windows.Forms.TabControl
        Me.tbOperatingCost = New System.Windows.Forms.TabPage
        Me.lblBudgetTotal = New System.Windows.Forms.Label
        Me.lblBudgetTotalL = New System.Windows.Forms.Label
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.dgOperatingCost = New System.Windows.Forms.DataGridView
        Me.OperatingBudgetByCostID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDetailCostCodeID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDetailCostCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Percentage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Day = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.BudgetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grpButtons = New System.Windows.Forms.GroupBox
        Me.btnResetGeneral = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtRevDec = New System.Windows.Forms.TextBox
        Me.txtBudgetDec = New System.Windows.Forms.TextBox
        Me.lblRevisionDec = New System.Windows.Forms.Label
        Me.lblBudgetDec = New System.Windows.Forms.Label
        Me.txtRevAug = New System.Windows.Forms.TextBox
        Me.txtBudgetAug = New System.Windows.Forms.TextBox
        Me.lblRevisionAug = New System.Windows.Forms.Label
        Me.lblBudgetAug = New System.Windows.Forms.Label
        Me.txtRevApr = New System.Windows.Forms.TextBox
        Me.txtBudgetApr = New System.Windows.Forms.TextBox
        Me.lblRevisionApr = New System.Windows.Forms.Label
        Me.lblBudgetApr = New System.Windows.Forms.Label
        Me.txtRevNov = New System.Windows.Forms.TextBox
        Me.txtBudgetNov = New System.Windows.Forms.TextBox
        Me.lblRevisionNov = New System.Windows.Forms.Label
        Me.lblBudgetNov = New System.Windows.Forms.Label
        Me.txtRevJul = New System.Windows.Forms.TextBox
        Me.txtBudgetJul = New System.Windows.Forms.TextBox
        Me.lblRevisionJul = New System.Windows.Forms.Label
        Me.lblBudgetJul = New System.Windows.Forms.Label
        Me.txtRevMar = New System.Windows.Forms.TextBox
        Me.txtBudgetMar = New System.Windows.Forms.TextBox
        Me.lblRevisionMar = New System.Windows.Forms.Label
        Me.lblBudgetMar = New System.Windows.Forms.Label
        Me.txtRevOct = New System.Windows.Forms.TextBox
        Me.txtBudgetOct = New System.Windows.Forms.TextBox
        Me.lblRevisionOct = New System.Windows.Forms.Label
        Me.lblBudgetOct = New System.Windows.Forms.Label
        Me.txtRevJun = New System.Windows.Forms.TextBox
        Me.txtBudgetJun = New System.Windows.Forms.TextBox
        Me.lblRevisionJun = New System.Windows.Forms.Label
        Me.lblBudgetJun = New System.Windows.Forms.Label
        Me.txtRevFeb = New System.Windows.Forms.TextBox
        Me.txtBudgetFeb = New System.Windows.Forms.TextBox
        Me.lblRevisionFeb = New System.Windows.Forms.Label
        Me.lblBudgetFeb = New System.Windows.Forms.Label
        Me.txtRevSep = New System.Windows.Forms.TextBox
        Me.txtBudgetSep = New System.Windows.Forms.TextBox
        Me.lblRevisionSep = New System.Windows.Forms.Label
        Me.lblBudgetSep = New System.Windows.Forms.Label
        Me.txtRevMay = New System.Windows.Forms.TextBox
        Me.txtBudgetMay = New System.Windows.Forms.TextBox
        Me.lblRevisionMay = New System.Windows.Forms.Label
        Me.lblBudgetMay = New System.Windows.Forms.Label
        Me.txtRevJan = New System.Windows.Forms.TextBox
        Me.txtBudgetJan = New System.Windows.Forms.TextBox
        Me.lblRevisionJan = New System.Windows.Forms.Label
        Me.lblBudgetJan = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblRevision = New System.Windows.Forms.Label
        Me.lblBudget = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblStatusL = New System.Windows.Forms.Label
        Me.lblVersionNo = New System.Windows.Forms.Label
        Me.lblVersionNoL = New System.Windows.Forms.Label
        Me.btnAddDescp = New System.Windows.Forms.Button
        Me.txtPercentage = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblPercentage = New System.Windows.Forms.Label
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblDay = New System.Windows.Forms.Label
        Me.txtIDR = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblIDR = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblQty = New System.Windows.Forms.Label
        Me.txtUnit = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblUnit = New System.Windows.Forms.Label
        Me.txtSubDescp = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblSubDescp = New System.Windows.Forms.Label
        Me.grpOperatingCost = New System.Windows.Forms.GroupBox
        Me.lblVHDescp = New System.Windows.Forms.Label
        Me.btnSearchVHcostCode = New System.Windows.Forms.Button
        Me.txtVHDetailCostCode = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblDetailCostCode = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDriverName = New System.Windows.Forms.Label
        Me.lblDriver = New System.Windows.Forms.Label
        Me.btnSearchVHNo = New System.Windows.Forms.Button
        Me.txtVHNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblVHNo = New System.Windows.Forms.Label
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.btnSearchVHGroup = New System.Windows.Forms.Button
        Me.txtVHGroup = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblVHGroup = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBudgetYear = New System.Windows.Forms.Label
        Me.lblBudgetyearL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.lblNoRecord = New System.Windows.Forms.Label
        Me.dgOperatingCostView = New System.Windows.Forms.DataGridView
        Me.OperatingBudgetByCostIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYearView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDetailCostCodeIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAGroupView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescpView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDetailCostCodeView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHNoView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VHDescpView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmpNameView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubDescView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDRView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PercentageView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MonthView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJanView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetFebView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMarView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAprView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetMayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJunView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetJulView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetAugView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetSepView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetOctView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetNovView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetDecView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJanView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevFebView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMarview = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAprView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJunView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJulView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAugView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevSepView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevOctView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevNovView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevDecView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetTotalView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNoView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsOperatingCost = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlOperatingBudgetByCost = New Stepi.UI.ExtendedPanel
        Me.btnSearchVHNoView = New System.Windows.Forms.Button
        Me.lblVHDescpView = New System.Windows.Forms.Label
        Me.lblVHNoView = New System.Windows.Forms.Label
        Me.btnSearchVHGroupView = New System.Windows.Forms.Button
        Me.txtVHNoView = New System.Windows.Forms.TextBox
        Me.txtCOAGroupView = New System.Windows.Forms.TextBox
        Me.lblCOADescpView = New System.Windows.Forms.Label
        Me.lblCOAGroupV = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.lblBudgetYearV = New System.Windows.Forms.Label
        Me.cmbBudgetyear = New System.Windows.Forms.ComboBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.tbOperatingBDGCost.SuspendLayout()
        Me.tbOperatingCost.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgOperatingCost, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpButtons.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.grpOperatingCost.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgOperatingCostView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsOperatingCost.SuspendLayout()
        Me.pnlOperatingBudgetByCost.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbOperatingBDGCost
        '
        Me.tbOperatingBDGCost.Controls.Add(Me.tbOperatingCost)
        Me.tbOperatingBDGCost.Controls.Add(Me.tbView)
        Me.tbOperatingBDGCost.Location = New System.Drawing.Point(12, 17)
        Me.tbOperatingBDGCost.Name = "tbOperatingBDGCost"
        Me.tbOperatingBDGCost.SelectedIndex = 0
        Me.tbOperatingBDGCost.Size = New System.Drawing.Size(1164, 755)
        Me.tbOperatingBDGCost.TabIndex = 0
        '
        'tbOperatingCost
        '
        Me.tbOperatingCost.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbOperatingCost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbOperatingCost.Controls.Add(Me.lblBudgetTotal)
        Me.tbOperatingCost.Controls.Add(Me.lblBudgetTotalL)
        Me.tbOperatingCost.Controls.Add(Me.btnSaveAll)
        Me.tbOperatingCost.Controls.Add(Me.btnPrint)
        Me.tbOperatingCost.Controls.Add(Me.btnResetAll)
        Me.tbOperatingCost.Controls.Add(Me.btnClose)
        Me.tbOperatingCost.Controls.Add(Me.GroupBox4)
        Me.tbOperatingCost.Controls.Add(Me.grpButtons)
        Me.tbOperatingCost.Controls.Add(Me.GroupBox3)
        Me.tbOperatingCost.Controls.Add(Me.GroupBox2)
        Me.tbOperatingCost.Controls.Add(Me.grpOperatingCost)
        Me.tbOperatingCost.Location = New System.Drawing.Point(4, 22)
        Me.tbOperatingCost.Name = "tbOperatingCost"
        Me.tbOperatingCost.Padding = New System.Windows.Forms.Padding(3)
        Me.tbOperatingCost.Size = New System.Drawing.Size(1156, 729)
        Me.tbOperatingCost.TabIndex = 0
        Me.tbOperatingCost.Text = "OperatingCost"
        Me.tbOperatingCost.UseVisualStyleBackColor = True
        '
        'lblBudgetTotal
        '
        Me.lblBudgetTotal.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetTotal.Location = New System.Drawing.Point(814, 400)
        Me.lblBudgetTotal.Name = "lblBudgetTotal"
        Me.lblBudgetTotal.Size = New System.Drawing.Size(117, 21)
        Me.lblBudgetTotal.TabIndex = 88
        '
        'lblBudgetTotalL
        '
        Me.lblBudgetTotalL.AutoSize = True
        Me.lblBudgetTotalL.Location = New System.Drawing.Point(716, 404)
        Me.lblBudgetTotalL.Name = "lblBudgetTotalL"
        Me.lblBudgetTotalL.Size = New System.Drawing.Size(96, 13)
        Me.lblBudgetTotalL.TabIndex = 87
        Me.lblBudgetTotalL.Text = "Budget Total   :"
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(536, 700)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(97, 25)
        Me.btnSaveAll.TabIndex = 33
        Me.btnSaveAll.Text = "Save "
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.BackgroundImage = CType(resources.GetObject("btnPrint.BackgroundImage"), System.Drawing.Image)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.Color.Black
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(836, 700)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(98, 25)
        Me.btnPrint.TabIndex = 30
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(636, 700)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(97, 25)
        Me.btnResetAll.TabIndex = 34
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(736, 700)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(97, 25)
        Me.btnClose.TabIndex = 35
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgOperatingCost)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 464)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(926, 230)
        Me.GroupBox4.TabIndex = 22
        Me.GroupBox4.TabStop = False
        '
        'dgOperatingCost
        '
        Me.dgOperatingCost.AllowUserToAddRows = False
        Me.dgOperatingCost.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgOperatingCost.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgOperatingCost.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgOperatingCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOperatingCost.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgOperatingCost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOperatingCost.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OperatingBudgetByCostID, Me.EstateID, Me.BudgetYear, Me.VHID, Me.VHNo, Me.VHDescp, Me.COAID, Me.COAGroup, Me.COADescp, Me.VHDetailCostCodeID, Me.VHDetailCostCode, Me.EmpName, Me.SubDesc, Me.IDR, Me.Percentage, Me.Unit, Me.Day, Me.Qty, Me.Month, Me.BudgetJan, Me.BudgetFeb, Me.BudgetMar, Me.BudgetApr, Me.BudgetMay, Me.BudgetJun, Me.BudgetJul, Me.BudgetAug, Me.BudgetSep, Me.BudgetOct, Me.BudgetNov, Me.BudgetDec, Me.RevJan, Me.RevFeb, Me.RevMar, Me.RevApr, Me.RevMay, Me.RevJun, Me.RevJul, Me.RevAug, Me.RevSep, Me.RevOct, Me.RevNov, Me.RevDec, Me.BudgetTotal, Me.VersionNo, Me.Status})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOperatingCost.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgOperatingCost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOperatingCost.EnableHeadersVisualStyles = False
        Me.dgOperatingCost.Location = New System.Drawing.Point(3, 17)
        Me.dgOperatingCost.Name = "dgOperatingCost"
        Me.dgOperatingCost.RowHeadersVisible = False
        Me.dgOperatingCost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOperatingCost.Size = New System.Drawing.Size(920, 210)
        Me.dgOperatingCost.TabIndex = 0
        Me.dgOperatingCost.TabStop = False
        '
        'OperatingBudgetByCostID
        '
        Me.OperatingBudgetByCostID.DataPropertyName = "OperatingBudgetByCostID"
        Me.OperatingBudgetByCostID.HeaderText = "Operating Budget By CostID"
        Me.OperatingBudgetByCostID.Name = "OperatingBudgetByCostID"
        Me.OperatingBudgetByCostID.Visible = False
        '
        'EstateID
        '
        Me.EstateID.DataPropertyName = "EstateID"
        Me.EstateID.HeaderText = "Estate ID"
        Me.EstateID.Name = "EstateID"
        Me.EstateID.Visible = False
        '
        'BudgetYear
        '
        Me.BudgetYear.DataPropertyName = "BudgetYear"
        Me.BudgetYear.HeaderText = "Budget Year"
        Me.BudgetYear.Name = "BudgetYear"
        '
        'VHID
        '
        Me.VHID.DataPropertyName = "VHID"
        Me.VHID.HeaderText = "VH ID"
        Me.VHID.Name = "VHID"
        Me.VHID.Visible = False
        '
        'VHNo
        '
        Me.VHNo.DataPropertyName = "VHNo"
        Me.VHNo.HeaderText = "VH NO"
        Me.VHNo.Name = "VHNo"
        '
        'VHDescp
        '
        Me.VHDescp.DataPropertyName = "VHDescp"
        Me.VHDescp.HeaderText = "VH Descp"
        Me.VHDescp.Name = "VHDescp"
        '
        'COAID
        '
        Me.COAID.DataPropertyName = "COAID"
        Me.COAID.HeaderText = "COAID"
        Me.COAID.Name = "COAID"
        Me.COAID.Visible = False
        '
        'COAGroup
        '
        Me.COAGroup.DataPropertyName = "COAGroup"
        Me.COAGroup.HeaderText = "VehicleGroup"
        Me.COAGroup.Name = "COAGroup"
        '
        'COADescp
        '
        Me.COADescp.DataPropertyName = "COADescp"
        Me.COADescp.HeaderText = "COADescp"
        Me.COADescp.Name = "COADescp"
        '
        'VHDetailCostCodeID
        '
        Me.VHDetailCostCodeID.DataPropertyName = "VHDetailCostCodeID"
        Me.VHDetailCostCodeID.HeaderText = "VHDetail CostCodeID"
        Me.VHDetailCostCodeID.Name = "VHDetailCostCodeID"
        Me.VHDetailCostCodeID.Visible = False
        '
        'VHDetailCostCode
        '
        Me.VHDetailCostCode.DataPropertyName = "VHDetailCostCode"
        Me.VHDetailCostCode.HeaderText = "VHDetailCostCode"
        Me.VHDetailCostCode.Name = "VHDetailCostCode"
        Me.VHDetailCostCode.Width = 125
        '
        'EmpName
        '
        Me.EmpName.DataPropertyName = "EmpName"
        Me.EmpName.HeaderText = "Driver"
        Me.EmpName.Name = "EmpName"
        '
        'SubDesc
        '
        Me.SubDesc.DataPropertyName = "SubDesc"
        Me.SubDesc.HeaderText = "Sub Desc"
        Me.SubDesc.Name = "SubDesc"
        '
        'IDR
        '
        Me.IDR.DataPropertyName = "IDR"
        Me.IDR.HeaderText = "IDR"
        Me.IDR.Name = "IDR"
        '
        'Percentage
        '
        Me.Percentage.DataPropertyName = "Percentage"
        Me.Percentage.HeaderText = "Percentage"
        Me.Percentage.Name = "Percentage"
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        '
        'Day
        '
        Me.Day.DataPropertyName = "Day"
        Me.Day.HeaderText = "Day"
        Me.Day.Name = "Day"
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        '
        'Month
        '
        Me.Month.DataPropertyName = "Month"
        Me.Month.HeaderText = "Month"
        Me.Month.Name = "Month"
        '
        'BudgetJan
        '
        Me.BudgetJan.DataPropertyName = "BudgetJan"
        Me.BudgetJan.HeaderText = "BudgetJan"
        Me.BudgetJan.Name = "BudgetJan"
        '
        'BudgetFeb
        '
        Me.BudgetFeb.DataPropertyName = "BudgetFeb"
        Me.BudgetFeb.HeaderText = "Budget Feb"
        Me.BudgetFeb.Name = "BudgetFeb"
        '
        'BudgetMar
        '
        Me.BudgetMar.DataPropertyName = "BudgetMar"
        Me.BudgetMar.HeaderText = "BudgetMar"
        Me.BudgetMar.Name = "BudgetMar"
        '
        'BudgetApr
        '
        Me.BudgetApr.DataPropertyName = "BudgetApr"
        Me.BudgetApr.HeaderText = "BudgetApr"
        Me.BudgetApr.Name = "BudgetApr"
        '
        'BudgetMay
        '
        Me.BudgetMay.DataPropertyName = "BudgetMay"
        Me.BudgetMay.HeaderText = "BudgetMay"
        Me.BudgetMay.Name = "BudgetMay"
        '
        'BudgetJun
        '
        Me.BudgetJun.DataPropertyName = "BudgetJun"
        Me.BudgetJun.HeaderText = "BudgetJun"
        Me.BudgetJun.Name = "BudgetJun"
        '
        'BudgetJul
        '
        Me.BudgetJul.DataPropertyName = "BudgetJul"
        Me.BudgetJul.HeaderText = "BudgetJul"
        Me.BudgetJul.Name = "BudgetJul"
        '
        'BudgetAug
        '
        Me.BudgetAug.DataPropertyName = "BudgetAug"
        Me.BudgetAug.HeaderText = "BudgetAug"
        Me.BudgetAug.Name = "BudgetAug"
        '
        'BudgetSep
        '
        Me.BudgetSep.DataPropertyName = "BudgetSep"
        Me.BudgetSep.HeaderText = "BudgetSep"
        Me.BudgetSep.Name = "BudgetSep"
        '
        'BudgetOct
        '
        Me.BudgetOct.DataPropertyName = "BudgetOct"
        Me.BudgetOct.HeaderText = "BudgetOct"
        Me.BudgetOct.Name = "BudgetOct"
        '
        'BudgetNov
        '
        Me.BudgetNov.DataPropertyName = "BudgetNov"
        Me.BudgetNov.HeaderText = "BudgetNov"
        Me.BudgetNov.Name = "BudgetNov"
        '
        'BudgetDec
        '
        Me.BudgetDec.DataPropertyName = "BudgetDec"
        Me.BudgetDec.HeaderText = "BudgetDec"
        Me.BudgetDec.Name = "BudgetDec"
        '
        'RevJan
        '
        Me.RevJan.DataPropertyName = "RevJan"
        Me.RevJan.HeaderText = "RevJan"
        Me.RevJan.Name = "RevJan"
        Me.RevJan.Visible = False
        '
        'RevFeb
        '
        Me.RevFeb.DataPropertyName = "RevFeb"
        Me.RevFeb.HeaderText = "RevFeb"
        Me.RevFeb.Name = "RevFeb"
        Me.RevFeb.Visible = False
        '
        'RevMar
        '
        Me.RevMar.DataPropertyName = "RevMar"
        Me.RevMar.HeaderText = "RevMar"
        Me.RevMar.Name = "RevMar"
        Me.RevMar.Visible = False
        '
        'RevApr
        '
        Me.RevApr.DataPropertyName = "RevApr"
        Me.RevApr.HeaderText = "RevApr"
        Me.RevApr.Name = "RevApr"
        Me.RevApr.Visible = False
        '
        'RevMay
        '
        Me.RevMay.DataPropertyName = "RevMay"
        Me.RevMay.HeaderText = "RevMay"
        Me.RevMay.Name = "RevMay"
        Me.RevMay.Visible = False
        '
        'RevJun
        '
        Me.RevJun.DataPropertyName = "RevJun"
        Me.RevJun.HeaderText = "RevJun"
        Me.RevJun.Name = "RevJun"
        Me.RevJun.Visible = False
        '
        'RevJul
        '
        Me.RevJul.DataPropertyName = "RevJul"
        Me.RevJul.HeaderText = "RevJul"
        Me.RevJul.Name = "RevJul"
        Me.RevJul.Visible = False
        '
        'RevAug
        '
        Me.RevAug.DataPropertyName = "RevAug"
        Me.RevAug.HeaderText = "RevAug"
        Me.RevAug.Name = "RevAug"
        Me.RevAug.Visible = False
        '
        'RevSep
        '
        Me.RevSep.DataPropertyName = "RevSep"
        Me.RevSep.HeaderText = "RevSep"
        Me.RevSep.Name = "RevSep"
        Me.RevSep.Visible = False
        '
        'RevOct
        '
        Me.RevOct.DataPropertyName = "RevOct"
        Me.RevOct.HeaderText = "RevOct"
        Me.RevOct.Name = "RevOct"
        Me.RevOct.Visible = False
        '
        'RevNov
        '
        Me.RevNov.DataPropertyName = "RevNov"
        Me.RevNov.HeaderText = "RevNov"
        Me.RevNov.Name = "RevNov"
        Me.RevNov.Visible = False
        '
        'RevDec
        '
        Me.RevDec.DataPropertyName = "RevDec"
        Me.RevDec.HeaderText = "RevDec"
        Me.RevDec.Name = "RevDec"
        Me.RevDec.Visible = False
        '
        'BudgetTotal
        '
        Me.BudgetTotal.DataPropertyName = "BudgetTotal"
        Me.BudgetTotal.HeaderText = "BudgetTotal"
        Me.BudgetTotal.Name = "BudgetTotal"
        '
        'VersionNo
        '
        Me.VersionNo.DataPropertyName = "VersionNo"
        Me.VersionNo.HeaderText = "VersionNo"
        Me.VersionNo.Name = "VersionNo"
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'grpButtons
        '
        Me.grpButtons.BackColor = System.Drawing.Color.Transparent
        Me.grpButtons.Controls.Add(Me.btnResetGeneral)
        Me.grpButtons.Controls.Add(Me.btnAdd)
        Me.grpButtons.Location = New System.Drawing.Point(699, 420)
        Me.grpButtons.Name = "grpButtons"
        Me.grpButtons.Size = New System.Drawing.Size(244, 44)
        Me.grpButtons.TabIndex = 30
        Me.grpButtons.TabStop = False
        '
        'btnResetGeneral
        '
        Me.btnResetGeneral.BackgroundImage = CType(resources.GetObject("btnResetGeneral.BackgroundImage"), System.Drawing.Image)
        Me.btnResetGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetGeneral.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetGeneral.Image = CType(resources.GetObject("btnResetGeneral.Image"), System.Drawing.Image)
        Me.btnResetGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetGeneral.Location = New System.Drawing.Point(134, 13)
        Me.btnResetGeneral.Name = "btnResetGeneral"
        Me.btnResetGeneral.Size = New System.Drawing.Size(97, 25)
        Me.btnResetGeneral.TabIndex = 32
        Me.btnResetGeneral.Text = "Reset"
        Me.btnResetGeneral.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = CType(resources.GetObject("btnAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(19, 13)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 25)
        Me.btnAdd.TabIndex = 31
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.txtRevDec)
        Me.GroupBox3.Controls.Add(Me.txtBudgetDec)
        Me.GroupBox3.Controls.Add(Me.lblRevisionDec)
        Me.GroupBox3.Controls.Add(Me.lblBudgetDec)
        Me.GroupBox3.Controls.Add(Me.txtRevAug)
        Me.GroupBox3.Controls.Add(Me.txtBudgetAug)
        Me.GroupBox3.Controls.Add(Me.lblRevisionAug)
        Me.GroupBox3.Controls.Add(Me.lblBudgetAug)
        Me.GroupBox3.Controls.Add(Me.txtRevApr)
        Me.GroupBox3.Controls.Add(Me.txtBudgetApr)
        Me.GroupBox3.Controls.Add(Me.lblRevisionApr)
        Me.GroupBox3.Controls.Add(Me.lblBudgetApr)
        Me.GroupBox3.Controls.Add(Me.txtRevNov)
        Me.GroupBox3.Controls.Add(Me.txtBudgetNov)
        Me.GroupBox3.Controls.Add(Me.lblRevisionNov)
        Me.GroupBox3.Controls.Add(Me.lblBudgetNov)
        Me.GroupBox3.Controls.Add(Me.txtRevJul)
        Me.GroupBox3.Controls.Add(Me.txtBudgetJul)
        Me.GroupBox3.Controls.Add(Me.lblRevisionJul)
        Me.GroupBox3.Controls.Add(Me.lblBudgetJul)
        Me.GroupBox3.Controls.Add(Me.txtRevMar)
        Me.GroupBox3.Controls.Add(Me.txtBudgetMar)
        Me.GroupBox3.Controls.Add(Me.lblRevisionMar)
        Me.GroupBox3.Controls.Add(Me.lblBudgetMar)
        Me.GroupBox3.Controls.Add(Me.txtRevOct)
        Me.GroupBox3.Controls.Add(Me.txtBudgetOct)
        Me.GroupBox3.Controls.Add(Me.lblRevisionOct)
        Me.GroupBox3.Controls.Add(Me.lblBudgetOct)
        Me.GroupBox3.Controls.Add(Me.txtRevJun)
        Me.GroupBox3.Controls.Add(Me.txtBudgetJun)
        Me.GroupBox3.Controls.Add(Me.lblRevisionJun)
        Me.GroupBox3.Controls.Add(Me.lblBudgetJun)
        Me.GroupBox3.Controls.Add(Me.txtRevFeb)
        Me.GroupBox3.Controls.Add(Me.txtBudgetFeb)
        Me.GroupBox3.Controls.Add(Me.lblRevisionFeb)
        Me.GroupBox3.Controls.Add(Me.lblBudgetFeb)
        Me.GroupBox3.Controls.Add(Me.txtRevSep)
        Me.GroupBox3.Controls.Add(Me.txtBudgetSep)
        Me.GroupBox3.Controls.Add(Me.lblRevisionSep)
        Me.GroupBox3.Controls.Add(Me.lblBudgetSep)
        Me.GroupBox3.Controls.Add(Me.txtRevMay)
        Me.GroupBox3.Controls.Add(Me.txtBudgetMay)
        Me.GroupBox3.Controls.Add(Me.lblRevisionMay)
        Me.GroupBox3.Controls.Add(Me.lblBudgetMay)
        Me.GroupBox3.Controls.Add(Me.txtRevJan)
        Me.GroupBox3.Controls.Add(Me.txtBudgetJan)
        Me.GroupBox3.Controls.Add(Me.lblRevisionJan)
        Me.GroupBox3.Controls.Add(Me.lblBudgetJan)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.lblRevision)
        Me.GroupBox3.Controls.Add(Me.lblBudget)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 185)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(978, 211)
        Me.GroupBox3.TabIndex = 17
        Me.GroupBox3.TabStop = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(850, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(29, 13)
        Me.Label21.TabIndex = 103
        Me.Label21.Text = "IDR"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(638, 12)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 13)
        Me.Label20.TabIndex = 102
        Me.Label20.Text = "IDR"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(438, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 101
        Me.Label19.Text = "IDR"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(204, 12)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 13)
        Me.Label18.TabIndex = 100
        Me.Label18.Text = "IDR"
        '
        'txtRevDec
        '
        Me.txtRevDec.Location = New System.Drawing.Point(814, 175)
        Me.txtRevDec.Name = "txtRevDec"
        Me.txtRevDec.Size = New System.Drawing.Size(116, 21)
        Me.txtRevDec.TabIndex = 48
        '
        'txtBudgetDec
        '
        Me.txtBudgetDec.Location = New System.Drawing.Point(814, 152)
        Me.txtBudgetDec.Name = "txtBudgetDec"
        Me.txtBudgetDec.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetDec.TabIndex = 29
        '
        'lblRevisionDec
        '
        Me.lblRevisionDec.AutoSize = True
        Me.lblRevisionDec.Location = New System.Drawing.Point(762, 178)
        Me.lblRevisionDec.Name = "lblRevisionDec"
        Me.lblRevisionDec.Size = New System.Drawing.Size(46, 13)
        Me.lblRevisionDec.TabIndex = 97
        Me.lblRevisionDec.Text = "Dec   :"
        '
        'lblBudgetDec
        '
        Me.lblBudgetDec.AutoSize = True
        Me.lblBudgetDec.Location = New System.Drawing.Point(762, 156)
        Me.lblBudgetDec.Name = "lblBudgetDec"
        Me.lblBudgetDec.Size = New System.Drawing.Size(46, 13)
        Me.lblBudgetDec.TabIndex = 96
        Me.lblBudgetDec.Text = "Dec   :"
        '
        'txtRevAug
        '
        Me.txtRevAug.Location = New System.Drawing.Point(816, 114)
        Me.txtRevAug.Name = "txtRevAug"
        Me.txtRevAug.Size = New System.Drawing.Size(116, 21)
        Me.txtRevAug.TabIndex = 44
        '
        'txtBudgetAug
        '
        Me.txtBudgetAug.Location = New System.Drawing.Point(816, 91)
        Me.txtBudgetAug.Name = "txtBudgetAug"
        Me.txtBudgetAug.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetAug.TabIndex = 25
        '
        'lblRevisionAug
        '
        Me.lblRevisionAug.AutoSize = True
        Me.lblRevisionAug.Location = New System.Drawing.Point(762, 117)
        Me.lblRevisionAug.Name = "lblRevisionAug"
        Me.lblRevisionAug.Size = New System.Drawing.Size(46, 13)
        Me.lblRevisionAug.TabIndex = 93
        Me.lblRevisionAug.Text = "Aug   :"
        '
        'lblBudgetAug
        '
        Me.lblBudgetAug.AutoSize = True
        Me.lblBudgetAug.Location = New System.Drawing.Point(762, 96)
        Me.lblBudgetAug.Name = "lblBudgetAug"
        Me.lblBudgetAug.Size = New System.Drawing.Size(46, 13)
        Me.lblBudgetAug.TabIndex = 92
        Me.lblBudgetAug.Text = "Aug   :"
        '
        'txtRevApr
        '
        Me.txtRevApr.Location = New System.Drawing.Point(816, 53)
        Me.txtRevApr.Name = "txtRevApr"
        Me.txtRevApr.Size = New System.Drawing.Size(116, 21)
        Me.txtRevApr.TabIndex = 40
        '
        'txtBudgetApr
        '
        Me.txtBudgetApr.Location = New System.Drawing.Point(816, 30)
        Me.txtBudgetApr.Name = "txtBudgetApr"
        Me.txtBudgetApr.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetApr.TabIndex = 21
        '
        'lblRevisionApr
        '
        Me.lblRevisionApr.AutoSize = True
        Me.lblRevisionApr.Location = New System.Drawing.Point(762, 55)
        Me.lblRevisionApr.Name = "lblRevisionApr"
        Me.lblRevisionApr.Size = New System.Drawing.Size(48, 13)
        Me.lblRevisionApr.TabIndex = 89
        Me.lblRevisionApr.Text = "Apr    :"
        '
        'lblBudgetApr
        '
        Me.lblBudgetApr.AutoSize = True
        Me.lblBudgetApr.Location = New System.Drawing.Point(762, 31)
        Me.lblBudgetApr.Name = "lblBudgetApr"
        Me.lblBudgetApr.Size = New System.Drawing.Size(48, 13)
        Me.lblBudgetApr.TabIndex = 88
        Me.lblBudgetApr.Text = "Apr    :"
        '
        'txtRevNov
        '
        Me.txtRevNov.Location = New System.Drawing.Point(600, 175)
        Me.txtRevNov.Name = "txtRevNov"
        Me.txtRevNov.Size = New System.Drawing.Size(116, 21)
        Me.txtRevNov.TabIndex = 47
        '
        'txtBudgetNov
        '
        Me.txtBudgetNov.Location = New System.Drawing.Point(600, 152)
        Me.txtBudgetNov.Name = "txtBudgetNov"
        Me.txtBudgetNov.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetNov.TabIndex = 28
        '
        'lblRevisionNov
        '
        Me.lblRevisionNov.AutoSize = True
        Me.lblRevisionNov.Location = New System.Drawing.Point(551, 178)
        Me.lblRevisionNov.Name = "lblRevisionNov"
        Me.lblRevisionNov.Size = New System.Drawing.Size(42, 13)
        Me.lblRevisionNov.TabIndex = 85
        Me.lblRevisionNov.Text = "Nov  :"
        '
        'lblBudgetNov
        '
        Me.lblBudgetNov.AutoSize = True
        Me.lblBudgetNov.Location = New System.Drawing.Point(551, 156)
        Me.lblBudgetNov.Name = "lblBudgetNov"
        Me.lblBudgetNov.Size = New System.Drawing.Size(42, 13)
        Me.lblBudgetNov.TabIndex = 84
        Me.lblBudgetNov.Text = "Nov  :"
        '
        'txtRevJul
        '
        Me.txtRevJul.Location = New System.Drawing.Point(600, 114)
        Me.txtRevJul.Name = "txtRevJul"
        Me.txtRevJul.Size = New System.Drawing.Size(116, 21)
        Me.txtRevJul.TabIndex = 43
        '
        'txtBudgetJul
        '
        Me.txtBudgetJul.Location = New System.Drawing.Point(600, 91)
        Me.txtBudgetJul.Name = "txtBudgetJul"
        Me.txtBudgetJul.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetJul.TabIndex = 24
        '
        'lblRevisionJul
        '
        Me.lblRevisionJul.AutoSize = True
        Me.lblRevisionJul.Location = New System.Drawing.Point(551, 119)
        Me.lblRevisionJul.Name = "lblRevisionJul"
        Me.lblRevisionJul.Size = New System.Drawing.Size(43, 13)
        Me.lblRevisionJul.TabIndex = 81
        Me.lblRevisionJul.Text = "Jul    :"
        '
        'lblBudgetJul
        '
        Me.lblBudgetJul.AutoSize = True
        Me.lblBudgetJul.Location = New System.Drawing.Point(551, 96)
        Me.lblBudgetJul.Name = "lblBudgetJul"
        Me.lblBudgetJul.Size = New System.Drawing.Size(43, 13)
        Me.lblBudgetJul.TabIndex = 80
        Me.lblBudgetJul.Text = "Jul    :"
        '
        'txtRevMar
        '
        Me.txtRevMar.Location = New System.Drawing.Point(600, 53)
        Me.txtRevMar.Name = "txtRevMar"
        Me.txtRevMar.Size = New System.Drawing.Size(116, 21)
        Me.txtRevMar.TabIndex = 39
        '
        'txtBudgetMar
        '
        Me.txtBudgetMar.Location = New System.Drawing.Point(600, 30)
        Me.txtBudgetMar.Name = "txtBudgetMar"
        Me.txtBudgetMar.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetMar.TabIndex = 20
        '
        'lblRevisionMar
        '
        Me.lblRevisionMar.AutoSize = True
        Me.lblRevisionMar.Location = New System.Drawing.Point(551, 56)
        Me.lblRevisionMar.Name = "lblRevisionMar"
        Me.lblRevisionMar.Size = New System.Drawing.Size(45, 13)
        Me.lblRevisionMar.TabIndex = 77
        Me.lblRevisionMar.Text = "Mar   :"
        '
        'lblBudgetMar
        '
        Me.lblBudgetMar.AutoSize = True
        Me.lblBudgetMar.Location = New System.Drawing.Point(551, 31)
        Me.lblBudgetMar.Name = "lblBudgetMar"
        Me.lblBudgetMar.Size = New System.Drawing.Size(45, 13)
        Me.lblBudgetMar.TabIndex = 76
        Me.lblBudgetMar.Text = "Mar   :"
        '
        'txtRevOct
        '
        Me.txtRevOct.Location = New System.Drawing.Point(390, 175)
        Me.txtRevOct.Name = "txtRevOct"
        Me.txtRevOct.Size = New System.Drawing.Size(116, 21)
        Me.txtRevOct.TabIndex = 46
        '
        'txtBudgetOct
        '
        Me.txtBudgetOct.Location = New System.Drawing.Point(390, 152)
        Me.txtBudgetOct.Name = "txtBudgetOct"
        Me.txtBudgetOct.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetOct.TabIndex = 27
        '
        'lblRevisionOct
        '
        Me.lblRevisionOct.AutoSize = True
        Me.lblRevisionOct.Location = New System.Drawing.Point(331, 177)
        Me.lblRevisionOct.Name = "lblRevisionOct"
        Me.lblRevisionOct.Size = New System.Drawing.Size(47, 13)
        Me.lblRevisionOct.TabIndex = 73
        Me.lblRevisionOct.Text = "Oct    :"
        '
        'lblBudgetOct
        '
        Me.lblBudgetOct.AutoSize = True
        Me.lblBudgetOct.Location = New System.Drawing.Point(331, 156)
        Me.lblBudgetOct.Name = "lblBudgetOct"
        Me.lblBudgetOct.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetOct.TabIndex = 72
        Me.lblBudgetOct.Text = "Oct    :"
        '
        'txtRevJun
        '
        Me.txtRevJun.Location = New System.Drawing.Point(390, 114)
        Me.txtRevJun.Name = "txtRevJun"
        Me.txtRevJun.Size = New System.Drawing.Size(116, 21)
        Me.txtRevJun.TabIndex = 42
        '
        'txtBudgetJun
        '
        Me.txtBudgetJun.Location = New System.Drawing.Point(390, 91)
        Me.txtBudgetJun.Name = "txtBudgetJun"
        Me.txtBudgetJun.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetJun.TabIndex = 23
        '
        'lblRevisionJun
        '
        Me.lblRevisionJun.AutoSize = True
        Me.lblRevisionJun.Location = New System.Drawing.Point(331, 117)
        Me.lblRevisionJun.Name = "lblRevisionJun"
        Me.lblRevisionJun.Size = New System.Drawing.Size(47, 13)
        Me.lblRevisionJun.TabIndex = 69
        Me.lblRevisionJun.Text = "Jun    :"
        '
        'lblBudgetJun
        '
        Me.lblBudgetJun.AutoSize = True
        Me.lblBudgetJun.Location = New System.Drawing.Point(331, 94)
        Me.lblBudgetJun.Name = "lblBudgetJun"
        Me.lblBudgetJun.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetJun.TabIndex = 68
        Me.lblBudgetJun.Text = "Jun    :"
        '
        'txtRevFeb
        '
        Me.txtRevFeb.Location = New System.Drawing.Point(390, 53)
        Me.txtRevFeb.Name = "txtRevFeb"
        Me.txtRevFeb.Size = New System.Drawing.Size(116, 21)
        Me.txtRevFeb.TabIndex = 38
        '
        'txtBudgetFeb
        '
        Me.txtBudgetFeb.Location = New System.Drawing.Point(390, 30)
        Me.txtBudgetFeb.Name = "txtBudgetFeb"
        Me.txtBudgetFeb.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetFeb.TabIndex = 19
        '
        'lblRevisionFeb
        '
        Me.lblRevisionFeb.AutoSize = True
        Me.lblRevisionFeb.Location = New System.Drawing.Point(331, 58)
        Me.lblRevisionFeb.Name = "lblRevisionFeb"
        Me.lblRevisionFeb.Size = New System.Drawing.Size(48, 13)
        Me.lblRevisionFeb.TabIndex = 65
        Me.lblRevisionFeb.Text = "Feb    :"
        '
        'lblBudgetFeb
        '
        Me.lblBudgetFeb.AutoSize = True
        Me.lblBudgetFeb.Location = New System.Drawing.Point(331, 33)
        Me.lblBudgetFeb.Name = "lblBudgetFeb"
        Me.lblBudgetFeb.Size = New System.Drawing.Size(48, 13)
        Me.lblBudgetFeb.TabIndex = 64
        Me.lblBudgetFeb.Text = "Feb    :"
        '
        'txtRevSep
        '
        Me.txtRevSep.Location = New System.Drawing.Point(166, 175)
        Me.txtRevSep.Name = "txtRevSep"
        Me.txtRevSep.Size = New System.Drawing.Size(116, 21)
        Me.txtRevSep.TabIndex = 45
        '
        'txtBudgetSep
        '
        Me.txtBudgetSep.Location = New System.Drawing.Point(166, 152)
        Me.txtBudgetSep.Name = "txtBudgetSep"
        Me.txtBudgetSep.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetSep.TabIndex = 26
        '
        'lblRevisionSep
        '
        Me.lblRevisionSep.AutoSize = True
        Me.lblRevisionSep.Location = New System.Drawing.Point(109, 178)
        Me.lblRevisionSep.Name = "lblRevisionSep"
        Me.lblRevisionSep.Size = New System.Drawing.Size(46, 13)
        Me.lblRevisionSep.TabIndex = 61
        Me.lblRevisionSep.Text = "Sep   :"
        '
        'lblBudgetSep
        '
        Me.lblBudgetSep.AutoSize = True
        Me.lblBudgetSep.Location = New System.Drawing.Point(109, 154)
        Me.lblBudgetSep.Name = "lblBudgetSep"
        Me.lblBudgetSep.Size = New System.Drawing.Size(46, 13)
        Me.lblBudgetSep.TabIndex = 60
        Me.lblBudgetSep.Text = "Sep   :"
        '
        'txtRevMay
        '
        Me.txtRevMay.Location = New System.Drawing.Point(166, 114)
        Me.txtRevMay.Name = "txtRevMay"
        Me.txtRevMay.Size = New System.Drawing.Size(116, 21)
        Me.txtRevMay.TabIndex = 41
        '
        'txtBudgetMay
        '
        Me.txtBudgetMay.Location = New System.Drawing.Point(166, 91)
        Me.txtBudgetMay.Name = "txtBudgetMay"
        Me.txtBudgetMay.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetMay.TabIndex = 22
        '
        'lblRevisionMay
        '
        Me.lblRevisionMay.AutoSize = True
        Me.lblRevisionMay.Location = New System.Drawing.Point(109, 117)
        Me.lblRevisionMay.Name = "lblRevisionMay"
        Me.lblRevisionMay.Size = New System.Drawing.Size(47, 13)
        Me.lblRevisionMay.TabIndex = 57
        Me.lblRevisionMay.Text = "May   :"
        '
        'lblBudgetMay
        '
        Me.lblBudgetMay.AutoSize = True
        Me.lblBudgetMay.Location = New System.Drawing.Point(109, 94)
        Me.lblBudgetMay.Name = "lblBudgetMay"
        Me.lblBudgetMay.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetMay.TabIndex = 56
        Me.lblBudgetMay.Text = "May   :"
        '
        'txtRevJan
        '
        Me.txtRevJan.Location = New System.Drawing.Point(166, 53)
        Me.txtRevJan.Name = "txtRevJan"
        Me.txtRevJan.Size = New System.Drawing.Size(116, 21)
        Me.txtRevJan.TabIndex = 37
        '
        'txtBudgetJan
        '
        Me.txtBudgetJan.Location = New System.Drawing.Point(166, 30)
        Me.txtBudgetJan.Name = "txtBudgetJan"
        Me.txtBudgetJan.Size = New System.Drawing.Size(116, 21)
        Me.txtBudgetJan.TabIndex = 18
        '
        'lblRevisionJan
        '
        Me.lblRevisionJan.AutoSize = True
        Me.lblRevisionJan.Location = New System.Drawing.Point(109, 56)
        Me.lblRevisionJan.Name = "lblRevisionJan"
        Me.lblRevisionJan.Size = New System.Drawing.Size(47, 13)
        Me.lblRevisionJan.TabIndex = 53
        Me.lblRevisionJan.Text = "Jan    :"
        '
        'lblBudgetJan
        '
        Me.lblBudgetJan.AutoSize = True
        Me.lblBudgetJan.Location = New System.Drawing.Point(109, 33)
        Me.lblBudgetJan.Name = "lblBudgetJan"
        Me.lblBudgetJan.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetJan.TabIndex = 52
        Me.lblBudgetJan.Text = "Jan    :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 117)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Revision"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Budget"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Revision"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(10, 154)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Budget"
        '
        'lblRevision
        '
        Me.lblRevision.AutoSize = True
        Me.lblRevision.Location = New System.Drawing.Point(10, 56)
        Me.lblRevision.Name = "lblRevision"
        Me.lblRevision.Size = New System.Drawing.Size(55, 13)
        Me.lblRevision.TabIndex = 3
        Me.lblRevision.Text = "Revision"
        '
        'lblBudget
        '
        Me.lblBudget.AutoSize = True
        Me.lblBudget.Location = New System.Drawing.Point(10, 31)
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.Size = New System.Drawing.Size(47, 13)
        Me.lblBudget.TabIndex = 2
        Me.lblBudget.Text = "Budget"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAddDescp)
        Me.GroupBox2.Controls.Add(Me.txtPercentage)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblPercentage)
        Me.GroupBox2.Controls.Add(Me.txtMonth)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblMonth)
        Me.GroupBox2.Controls.Add(Me.txtDay)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.lblDay)
        Me.GroupBox2.Controls.Add(Me.txtIDR)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.lblIDR)
        Me.GroupBox2.Controls.Add(Me.txtQty)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.lblQty)
        Me.GroupBox2.Controls.Add(Me.txtUnit)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblUnit)
        Me.GroupBox2.Controls.Add(Me.txtSubDescp)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.lblSubDescp)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 85)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(978, 97)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(1049, 41)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 20)
        Me.lblStatus.TabIndex = 182
        '
        'lblStatusL
        '
        Me.lblStatusL.AutoSize = True
        Me.lblStatusL.ForeColor = System.Drawing.Color.Black
        Me.lblStatusL.Location = New System.Drawing.Point(963, 44)
        Me.lblStatusL.Name = "lblStatusL"
        Me.lblStatusL.Size = New System.Drawing.Size(43, 13)
        Me.lblStatusL.TabIndex = 181
        Me.lblStatusL.Text = "Status"
        '
        'lblVersionNo
        '
        Me.lblVersionNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVersionNo.Location = New System.Drawing.Point(1049, 17)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(83, 21)
        Me.lblVersionNo.TabIndex = 180
        '
        'lblVersionNoL
        '
        Me.lblVersionNoL.AutoSize = True
        Me.lblVersionNoL.ForeColor = System.Drawing.Color.Black
        Me.lblVersionNoL.Location = New System.Drawing.Point(963, 17)
        Me.lblVersionNoL.Name = "lblVersionNoL"
        Me.lblVersionNoL.Size = New System.Drawing.Size(69, 13)
        Me.lblVersionNoL.TabIndex = 179
        Me.lblVersionNoL.Text = "Version No"
        '
        'btnAddDescp
        '
        Me.btnAddDescp.Location = New System.Drawing.Point(265, 16)
        Me.btnAddDescp.Name = "btnAddDescp"
        Me.btnAddDescp.Size = New System.Drawing.Size(28, 23)
        Me.btnAddDescp.TabIndex = 178
        Me.btnAddDescp.TabStop = False
        Me.btnAddDescp.Text = "+"
        Me.btnAddDescp.UseVisualStyleBackColor = True
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(698, 16)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(116, 21)
        Me.txtPercentage.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(677, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 13)
        Me.Label8.TabIndex = 177
        Me.Label8.Text = ":"
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.ForeColor = System.Drawing.Color.Red
        Me.lblPercentage.Location = New System.Drawing.Point(612, 22)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(19, 13)
        Me.lblPercentage.TabIndex = 176
        Me.lblPercentage.Text = "%"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(442, 69)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(116, 21)
        Me.txtMonth.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(421, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(12, 13)
        Me.Label13.TabIndex = 174
        Me.Label13.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.ForeColor = System.Drawing.Color.Red
        Me.lblMonth.Location = New System.Drawing.Point(336, 73)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 173
        Me.lblMonth.Text = "Month"
        '
        'txtDay
        '
        Me.txtDay.Location = New System.Drawing.Point(441, 43)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(116, 21)
        Me.txtDay.TabIndex = 14
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(421, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(12, 13)
        Me.Label15.TabIndex = 171
        Me.Label15.Text = ":"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.ForeColor = System.Drawing.Color.Red
        Me.lblDay.Location = New System.Drawing.Point(336, 46)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(30, 13)
        Me.lblDay.TabIndex = 170
        Me.lblDay.Text = "Day"
        '
        'txtIDR
        '
        Me.txtIDR.Location = New System.Drawing.Point(441, 16)
        Me.txtIDR.Name = "txtIDR"
        Me.txtIDR.Size = New System.Drawing.Size(116, 21)
        Me.txtIDR.TabIndex = 13
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(421, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 13)
        Me.Label17.TabIndex = 168
        Me.Label17.Text = ":"
        '
        'lblIDR
        '
        Me.lblIDR.AutoSize = True
        Me.lblIDR.ForeColor = System.Drawing.Color.Red
        Me.lblIDR.Location = New System.Drawing.Point(336, 21)
        Me.lblIDR.Name = "lblIDR"
        Me.lblIDR.Size = New System.Drawing.Size(29, 13)
        Me.lblIDR.TabIndex = 167
        Me.lblIDR.Text = "IDR"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(118, 69)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(116, 21)
        Me.txtQty.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(100, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 13)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = ":"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.ForeColor = System.Drawing.Color.Red
        Me.lblQty.Location = New System.Drawing.Point(10, 73)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(27, 13)
        Me.lblQty.TabIndex = 164
        Me.lblQty.Text = "Qty"
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(118, 43)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(116, 21)
        Me.txtUnit.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(100, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(12, 13)
        Me.Label9.TabIndex = 162
        Me.Label9.Text = ":"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.ForeColor = System.Drawing.Color.Red
        Me.lblUnit.Location = New System.Drawing.Point(10, 46)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(29, 13)
        Me.lblUnit.TabIndex = 161
        Me.lblUnit.Text = "Unit"
        '
        'txtSubDescp
        '
        Me.txtSubDescp.Location = New System.Drawing.Point(118, 16)
        Me.txtSubDescp.Name = "txtSubDescp"
        Me.txtSubDescp.Size = New System.Drawing.Size(116, 21)
        Me.txtSubDescp.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(100, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 13)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = ":"
        '
        'lblSubDescp
        '
        Me.lblSubDescp.AutoSize = True
        Me.lblSubDescp.ForeColor = System.Drawing.Color.Red
        Me.lblSubDescp.Location = New System.Drawing.Point(10, 21)
        Me.lblSubDescp.Name = "lblSubDescp"
        Me.lblSubDescp.Size = New System.Drawing.Size(68, 13)
        Me.lblSubDescp.TabIndex = 158
        Me.lblSubDescp.Text = "Sub Descp"
        '
        'grpOperatingCost
        '
        Me.grpOperatingCost.Controls.Add(Me.lblStatus)
        Me.grpOperatingCost.Controls.Add(Me.lblVHDescp)
        Me.grpOperatingCost.Controls.Add(Me.lblStatusL)
        Me.grpOperatingCost.Controls.Add(Me.btnSearchVHcostCode)
        Me.grpOperatingCost.Controls.Add(Me.lblVersionNo)
        Me.grpOperatingCost.Controls.Add(Me.lblVersionNoL)
        Me.grpOperatingCost.Controls.Add(Me.txtVHDetailCostCode)
        Me.grpOperatingCost.Controls.Add(Me.Label6)
        Me.grpOperatingCost.Controls.Add(Me.lblDetailCostCode)
        Me.grpOperatingCost.Controls.Add(Me.Label1)
        Me.grpOperatingCost.Controls.Add(Me.lblDriverName)
        Me.grpOperatingCost.Controls.Add(Me.lblDriver)
        Me.grpOperatingCost.Controls.Add(Me.lblCOADescp)
        Me.grpOperatingCost.Controls.Add(Me.btnSearchVHNo)
        Me.grpOperatingCost.Controls.Add(Me.btnSearchVHGroup)
        Me.grpOperatingCost.Controls.Add(Me.txtVHGroup)
        Me.grpOperatingCost.Controls.Add(Me.txtVHNo)
        Me.grpOperatingCost.Controls.Add(Me.Label3)
        Me.grpOperatingCost.Controls.Add(Me.Label4)
        Me.grpOperatingCost.Controls.Add(Me.lblVHGroup)
        Me.grpOperatingCost.Controls.Add(Me.Label2)
        Me.grpOperatingCost.Controls.Add(Me.lblVHNo)
        Me.grpOperatingCost.Controls.Add(Me.lblBudgetYear)
        Me.grpOperatingCost.Controls.Add(Me.lblBudgetyearL)
        Me.grpOperatingCost.Location = New System.Drawing.Point(3, 4)
        Me.grpOperatingCost.Name = "grpOperatingCost"
        Me.grpOperatingCost.Size = New System.Drawing.Size(1147, 79)
        Me.grpOperatingCost.TabIndex = 5
        Me.grpOperatingCost.TabStop = False
        '
        'lblVHDescp
        '
        Me.lblVHDescp.ForeColor = System.Drawing.Color.Blue
        Me.lblVHDescp.Location = New System.Drawing.Point(780, 13)
        Me.lblVHDescp.Name = "lblVHDescp"
        Me.lblVHDescp.Size = New System.Drawing.Size(148, 29)
        Me.lblVHDescp.TabIndex = 164
        '
        'btnSearchVHcostCode
        '
        Me.btnSearchVHcostCode.BackgroundImage = CType(resources.GetObject("btnSearchVHcostCode.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVHcostCode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHcostCode.FlatAppearance.BorderSize = 0
        Me.btnSearchVHcostCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHcostCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHcostCode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHcostCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHcostCode.Location = New System.Drawing.Point(692, 41)
        Me.btnSearchVHcostCode.Name = "btnSearchVHcostCode"
        Me.btnSearchVHcostCode.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHcostCode.TabIndex = 157
        Me.btnSearchVHcostCode.TabStop = False
        Me.btnSearchVHcostCode.UseVisualStyleBackColor = True
        '
        'txtVHDetailCostCode
        '
        Me.txtVHDetailCostCode.Location = New System.Drawing.Point(566, 47)
        Me.txtVHDetailCostCode.Name = "txtVHDetailCostCode"
        Me.txtVHDetailCostCode.Size = New System.Drawing.Size(116, 21)
        Me.txtVHDetailCostCode.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(546, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 13)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = ":"
        '
        'lblDetailCostCode
        '
        Me.lblDetailCostCode.AutoSize = True
        Me.lblDetailCostCode.ForeColor = System.Drawing.Color.Red
        Me.lblDetailCostCode.Location = New System.Drawing.Point(440, 51)
        Me.lblDetailCostCode.Name = "lblDetailCostCode"
        Me.lblDetailCostCode.Size = New System.Drawing.Size(104, 13)
        Me.lblDetailCostCode.TabIndex = 155
        Me.lblDetailCostCode.Text = "Detail Cost Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(767, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = ":"
        '
        'lblDriverName
        '
        Me.lblDriverName.BackColor = System.Drawing.SystemColors.Control
        Me.lblDriverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDriverName.Location = New System.Drawing.Point(782, 48)
        Me.lblDriverName.Name = "lblDriverName"
        Me.lblDriverName.Size = New System.Drawing.Size(151, 21)
        Me.lblDriverName.TabIndex = 152
        '
        'lblDriver
        '
        Me.lblDriver.AutoSize = True
        Me.lblDriver.Location = New System.Drawing.Point(728, 50)
        Me.lblDriver.Name = "lblDriver"
        Me.lblDriver.Size = New System.Drawing.Size(43, 13)
        Me.lblDriver.TabIndex = 151
        Me.lblDriver.Text = "Driver"
        '
        'btnSearchVHNo
        '
        Me.btnSearchVHNo.BackgroundImage = CType(resources.GetObject("btnSearchVHNo.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVHNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHNo.FlatAppearance.BorderSize = 0
        Me.btnSearchVHNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHNo.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHNo.Location = New System.Drawing.Point(692, 6)
        Me.btnSearchVHNo.Name = "btnSearchVHNo"
        Me.btnSearchVHNo.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHNo.TabIndex = 150
        Me.btnSearchVHNo.TabStop = False
        Me.btnSearchVHNo.UseVisualStyleBackColor = True
        '
        'txtVHNo
        '
        Me.txtVHNo.Location = New System.Drawing.Point(566, 13)
        Me.txtVHNo.Name = "txtVHNo"
        Me.txtVHNo.Size = New System.Drawing.Size(116, 21)
        Me.txtVHNo.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(546, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 149
        Me.Label4.Text = ":"
        '
        'lblVHNo
        '
        Me.lblVHNo.AutoSize = True
        Me.lblVHNo.ForeColor = System.Drawing.Color.Red
        Me.lblVHNo.Location = New System.Drawing.Point(440, 17)
        Me.lblVHNo.Name = "lblVHNo"
        Me.lblVHNo.Size = New System.Drawing.Size(67, 13)
        Me.lblVHNo.TabIndex = 148
        Me.lblVHNo.Text = "Vehicle No"
        '
        'lblCOADescp
        '
        Me.lblCOADescp.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescp.Location = New System.Drawing.Point(292, 41)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(137, 28)
        Me.lblCOADescp.TabIndex = 146
        '
        'btnSearchVHGroup
        '
        Me.btnSearchVHGroup.BackgroundImage = CType(resources.GetObject("btnSearchVHGroup.BackgroundImage"), System.Drawing.Image)
        Me.btnSearchVHGroup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHGroup.FlatAppearance.BorderSize = 0
        Me.btnSearchVHGroup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHGroup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHGroup.Location = New System.Drawing.Point(251, 42)
        Me.btnSearchVHGroup.Name = "btnSearchVHGroup"
        Me.btnSearchVHGroup.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHGroup.TabIndex = 145
        Me.btnSearchVHGroup.TabStop = False
        Me.btnSearchVHGroup.UseVisualStyleBackColor = True
        '
        'txtVHGroup
        '
        Me.txtVHGroup.Location = New System.Drawing.Point(111, 48)
        Me.txtVHGroup.Name = "txtVHGroup"
        Me.txtVHGroup.Size = New System.Drawing.Size(137, 21)
        Me.txtVHGroup.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(96, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = ":"
        '
        'lblVHGroup
        '
        Me.lblVHGroup.AutoSize = True
        Me.lblVHGroup.ForeColor = System.Drawing.Color.Red
        Me.lblVHGroup.Location = New System.Drawing.Point(0, 53)
        Me.lblVHGroup.Name = "lblVHGroup"
        Me.lblVHGroup.Size = New System.Drawing.Size(87, 13)
        Me.lblVHGroup.TabIndex = 143
        Me.lblVHGroup.Text = "Vehicle Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(96, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = ":"
        '
        'lblBudgetYear
        '
        Me.lblBudgetYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYear.Location = New System.Drawing.Point(111, 15)
        Me.lblBudgetYear.Name = "lblBudgetYear"
        Me.lblBudgetYear.Size = New System.Drawing.Size(138, 21)
        Me.lblBudgetYear.TabIndex = 8
        '
        'lblBudgetyearL
        '
        Me.lblBudgetyearL.AutoSize = True
        Me.lblBudgetyearL.Location = New System.Drawing.Point(0, 15)
        Me.lblBudgetyearL.Name = "lblBudgetyearL"
        Me.lblBudgetyearL.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetyearL.TabIndex = 7
        Me.lblBudgetyearL.Text = "Budget Year"
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.GroupBox5)
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(971, 729)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lblNoRecord)
        Me.GroupBox5.Controls.Add(Me.dgOperatingCostView)
        Me.GroupBox5.Controls.Add(Me.pnlOperatingBudgetByCost)
        Me.GroupBox5.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(943, 475)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'lblNoRecord
        '
        Me.lblNoRecord.AutoSize = True
        Me.lblNoRecord.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecord.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecord.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecord.Location = New System.Drawing.Point(409, 231)
        Me.lblNoRecord.Name = "lblNoRecord"
        Me.lblNoRecord.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecord.TabIndex = 121
        Me.lblNoRecord.Text = "No Record Found !"
        Me.lblNoRecord.Visible = False
        '
        'dgOperatingCostView
        '
        Me.dgOperatingCostView.AllowUserToAddRows = False
        Me.dgOperatingCostView.AllowUserToDeleteRows = False
        Me.dgOperatingCostView.AllowUserToOrderColumns = True
        Me.dgOperatingCostView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgOperatingCostView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOperatingCostView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgOperatingCostView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgOperatingCostView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OperatingBudgetByCostIDView, Me.EstateIDView, Me.BudgetYearView, Me.VHIDView, Me.COAIDView, Me.VHDetailCostCodeIDView, Me.COAGroupView, Me.COADescpView, Me.VHDetailCostCodeView, Me.VHNoView, Me.VHDescpView, Me.EmpNameView, Me.SubDescView, Me.UnitView, Me.QtyView, Me.IDRView, Me.PercentageView, Me.DayView, Me.MonthView, Me.BudgetJanView, Me.BudgetFebView, Me.BudgetMarView, Me.BudgetAprView, Me.BudgetMayView, Me.BudgetJunView, Me.BudgetJulView, Me.BudgetAugView, Me.BudgetSepView, Me.BudgetOctView, Me.BudgetNovView, Me.BudgetDecView, Me.RevJanView, Me.RevFebView, Me.RevMarview, Me.RevAprView, Me.RevMayView, Me.RevJunView, Me.RevJulView, Me.RevAugView, Me.RevSepView, Me.RevOctView, Me.RevNovView, Me.RevDecView, Me.BudgetTotalView, Me.VersionNoView, Me.StatusView})
        Me.dgOperatingCostView.ContextMenuStrip = Me.cmsOperatingCost
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgOperatingCostView.DefaultCellStyle = DataGridViewCellStyle13
        Me.dgOperatingCostView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgOperatingCostView.EnableHeadersVisualStyles = False
        Me.dgOperatingCostView.Location = New System.Drawing.Point(3, 175)
        Me.dgOperatingCostView.Name = "dgOperatingCostView"
        Me.dgOperatingCostView.RowHeadersVisible = False
        Me.dgOperatingCostView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOperatingCostView.ShowCellErrors = False
        Me.dgOperatingCostView.Size = New System.Drawing.Size(937, 297)
        Me.dgOperatingCostView.TabIndex = 120
        '
        'OperatingBudgetByCostIDView
        '
        Me.OperatingBudgetByCostIDView.DataPropertyName = "OperatingBudgetByCostID"
        Me.OperatingBudgetByCostIDView.HeaderText = "OperatingBudgetByCostID"
        Me.OperatingBudgetByCostIDView.Name = "OperatingBudgetByCostIDView"
        Me.OperatingBudgetByCostIDView.Visible = False
        '
        'EstateIDView
        '
        Me.EstateIDView.DataPropertyName = "EstateID"
        Me.EstateIDView.HeaderText = "EstateID"
        Me.EstateIDView.Name = "EstateIDView"
        Me.EstateIDView.Visible = False
        '
        'BudgetYearView
        '
        Me.BudgetYearView.DataPropertyName = "BudgetYear"
        Me.BudgetYearView.HeaderText = "BudgetYear"
        Me.BudgetYearView.Name = "BudgetYearView"
        '
        'VHIDView
        '
        Me.VHIDView.DataPropertyName = "VHID"
        Me.VHIDView.HeaderText = "VHID"
        Me.VHIDView.Name = "VHIDView"
        Me.VHIDView.Visible = False
        '
        'COAIDView
        '
        Me.COAIDView.DataPropertyName = "COAID"
        Me.COAIDView.HeaderText = "COAID"
        Me.COAIDView.Name = "COAIDView"
        Me.COAIDView.Visible = False
        '
        'VHDetailCostCodeIDView
        '
        Me.VHDetailCostCodeIDView.DataPropertyName = "VHDetailCostCodeID"
        Me.VHDetailCostCodeIDView.HeaderText = "VHDetailCostCodeID"
        Me.VHDetailCostCodeIDView.Name = "VHDetailCostCodeIDView"
        Me.VHDetailCostCodeIDView.Visible = False
        '
        'COAGroupView
        '
        Me.COAGroupView.DataPropertyName = "COAGroup"
        Me.COAGroupView.HeaderText = "Vehicle Group"
        Me.COAGroupView.Name = "COAGroupView"
        Me.COAGroupView.Width = 125
        '
        'COADescpView
        '
        Me.COADescpView.DataPropertyName = "COADescp"
        Me.COADescpView.HeaderText = "COA Descp"
        Me.COADescpView.Name = "COADescpView"
        '
        'VHDetailCostCodeView
        '
        Me.VHDetailCostCodeView.DataPropertyName = "VHDetailCostCode"
        Me.VHDetailCostCodeView.HeaderText = "VHDetailCostCode"
        Me.VHDetailCostCodeView.Name = "VHDetailCostCodeView"
        Me.VHDetailCostCodeView.Width = 125
        '
        'VHNoView
        '
        Me.VHNoView.DataPropertyName = "VHNo"
        Me.VHNoView.HeaderText = "VHNo"
        Me.VHNoView.Name = "VHNoView"
        '
        'VHDescpView
        '
        Me.VHDescpView.DataPropertyName = "VHDescp"
        Me.VHDescpView.HeaderText = "VHDescp"
        Me.VHDescpView.Name = "VHDescpView"
        '
        'EmpNameView
        '
        Me.EmpNameView.DataPropertyName = "EmpName"
        Me.EmpNameView.HeaderText = "EmpName"
        Me.EmpNameView.Name = "EmpNameView"
        '
        'SubDescView
        '
        Me.SubDescView.DataPropertyName = "SubDesc"
        Me.SubDescView.HeaderText = "SubDesc"
        Me.SubDescView.Name = "SubDescView"
        Me.SubDescView.Visible = False
        '
        'UnitView
        '
        Me.UnitView.DataPropertyName = "Unit"
        Me.UnitView.HeaderText = "Unit"
        Me.UnitView.Name = "UnitView"
        Me.UnitView.Visible = False
        '
        'QtyView
        '
        Me.QtyView.DataPropertyName = "Qty"
        Me.QtyView.HeaderText = "Qty"
        Me.QtyView.Name = "QtyView"
        Me.QtyView.Visible = False
        '
        'IDRView
        '
        Me.IDRView.DataPropertyName = "IDR"
        Me.IDRView.HeaderText = "IDR"
        Me.IDRView.Name = "IDRView"
        Me.IDRView.Visible = False
        '
        'PercentageView
        '
        Me.PercentageView.DataPropertyName = "Percentage"
        Me.PercentageView.HeaderText = "Percentage"
        Me.PercentageView.Name = "PercentageView"
        Me.PercentageView.Visible = False
        '
        'DayView
        '
        Me.DayView.DataPropertyName = "Day"
        Me.DayView.HeaderText = "Day"
        Me.DayView.Name = "DayView"
        Me.DayView.Visible = False
        '
        'MonthView
        '
        Me.MonthView.DataPropertyName = "Month"
        Me.MonthView.HeaderText = "Month"
        Me.MonthView.Name = "MonthView"
        Me.MonthView.Visible = False
        '
        'BudgetJanView
        '
        Me.BudgetJanView.DataPropertyName = "BudgetJan"
        Me.BudgetJanView.HeaderText = "BudgetJan"
        Me.BudgetJanView.Name = "BudgetJanView"
        Me.BudgetJanView.Visible = False
        '
        'BudgetFebView
        '
        Me.BudgetFebView.DataPropertyName = "BudgetFeb"
        Me.BudgetFebView.HeaderText = "BudgetFeb"
        Me.BudgetFebView.Name = "BudgetFebView"
        Me.BudgetFebView.Visible = False
        '
        'BudgetMarView
        '
        Me.BudgetMarView.DataPropertyName = "BudgetMar"
        Me.BudgetMarView.HeaderText = "BudgetMar"
        Me.BudgetMarView.Name = "BudgetMarView"
        Me.BudgetMarView.Visible = False
        '
        'BudgetAprView
        '
        Me.BudgetAprView.DataPropertyName = "BudgetApr"
        Me.BudgetAprView.HeaderText = "BudgetApr"
        Me.BudgetAprView.Name = "BudgetAprView"
        Me.BudgetAprView.Visible = False
        '
        'BudgetMayView
        '
        Me.BudgetMayView.DataPropertyName = "BudgetMay"
        Me.BudgetMayView.HeaderText = "BudgetMay"
        Me.BudgetMayView.Name = "BudgetMayView"
        Me.BudgetMayView.Visible = False
        '
        'BudgetJunView
        '
        Me.BudgetJunView.DataPropertyName = "BudgetJun"
        Me.BudgetJunView.HeaderText = "BudgetJun"
        Me.BudgetJunView.Name = "BudgetJunView"
        Me.BudgetJunView.Visible = False
        '
        'BudgetJulView
        '
        Me.BudgetJulView.DataPropertyName = "BudgetJul"
        Me.BudgetJulView.HeaderText = "BudgetJul"
        Me.BudgetJulView.Name = "BudgetJulView"
        Me.BudgetJulView.Visible = False
        '
        'BudgetAugView
        '
        Me.BudgetAugView.DataPropertyName = "BudgetAug"
        Me.BudgetAugView.HeaderText = "BudgetAug"
        Me.BudgetAugView.Name = "BudgetAugView"
        Me.BudgetAugView.Visible = False
        '
        'BudgetSepView
        '
        Me.BudgetSepView.DataPropertyName = "BudgetSep"
        Me.BudgetSepView.HeaderText = "BudgetSep"
        Me.BudgetSepView.Name = "BudgetSepView"
        Me.BudgetSepView.Visible = False
        '
        'BudgetOctView
        '
        Me.BudgetOctView.DataPropertyName = "BudgetOct"
        Me.BudgetOctView.HeaderText = "BudgetOct"
        Me.BudgetOctView.Name = "BudgetOctView"
        Me.BudgetOctView.Visible = False
        '
        'BudgetNovView
        '
        Me.BudgetNovView.DataPropertyName = "BudgetNov"
        Me.BudgetNovView.HeaderText = "BudgetNov"
        Me.BudgetNovView.Name = "BudgetNovView"
        Me.BudgetNovView.Visible = False
        '
        'BudgetDecView
        '
        Me.BudgetDecView.DataPropertyName = "BudgetDec"
        Me.BudgetDecView.HeaderText = "BudgetDec"
        Me.BudgetDecView.Name = "BudgetDecView"
        Me.BudgetDecView.Visible = False
        '
        'RevJanView
        '
        Me.RevJanView.DataPropertyName = "RevJan"
        Me.RevJanView.HeaderText = "RevJan"
        Me.RevJanView.Name = "RevJanView"
        Me.RevJanView.Visible = False
        '
        'RevFebView
        '
        Me.RevFebView.DataPropertyName = "RevFeb"
        Me.RevFebView.HeaderText = "RevFeb"
        Me.RevFebView.Name = "RevFebView"
        Me.RevFebView.Visible = False
        '
        'RevMarview
        '
        Me.RevMarview.DataPropertyName = "RevMar"
        Me.RevMarview.HeaderText = "RevMar"
        Me.RevMarview.Name = "RevMarview"
        Me.RevMarview.Visible = False
        '
        'RevAprView
        '
        Me.RevAprView.DataPropertyName = "RevApr"
        Me.RevAprView.HeaderText = "RevApr"
        Me.RevAprView.Name = "RevAprView"
        Me.RevAprView.Visible = False
        '
        'RevMayView
        '
        Me.RevMayView.DataPropertyName = "RevMay"
        Me.RevMayView.HeaderText = "RevMay"
        Me.RevMayView.Name = "RevMayView"
        Me.RevMayView.Visible = False
        '
        'RevJunView
        '
        Me.RevJunView.DataPropertyName = "RevJun"
        Me.RevJunView.HeaderText = "RevJun"
        Me.RevJunView.Name = "RevJunView"
        Me.RevJunView.Visible = False
        '
        'RevJulView
        '
        Me.RevJulView.DataPropertyName = "RevJul"
        Me.RevJulView.HeaderText = "RevJul"
        Me.RevJulView.Name = "RevJulView"
        Me.RevJulView.Visible = False
        '
        'RevAugView
        '
        Me.RevAugView.DataPropertyName = "RevAug"
        Me.RevAugView.HeaderText = "RevAug"
        Me.RevAugView.Name = "RevAugView"
        Me.RevAugView.Visible = False
        '
        'RevSepView
        '
        Me.RevSepView.DataPropertyName = "RevSep"
        Me.RevSepView.HeaderText = "RevSep"
        Me.RevSepView.Name = "RevSepView"
        Me.RevSepView.Visible = False
        '
        'RevOctView
        '
        Me.RevOctView.DataPropertyName = "RevOct"
        Me.RevOctView.HeaderText = "RevOct"
        Me.RevOctView.Name = "RevOctView"
        Me.RevOctView.Visible = False
        '
        'RevNovView
        '
        Me.RevNovView.DataPropertyName = "RevNov"
        Me.RevNovView.HeaderText = "RevNov"
        Me.RevNovView.Name = "RevNovView"
        Me.RevNovView.Visible = False
        '
        'RevDecView
        '
        Me.RevDecView.DataPropertyName = "RevDec"
        Me.RevDecView.HeaderText = "RevDec"
        Me.RevDecView.Name = "RevDecView"
        Me.RevDecView.Visible = False
        '
        'BudgetTotalView
        '
        Me.BudgetTotalView.DataPropertyName = "BudgetTotal"
        Me.BudgetTotalView.HeaderText = "BudgetTotal"
        Me.BudgetTotalView.Name = "BudgetTotalView"
        '
        'VersionNoView
        '
        Me.VersionNoView.DataPropertyName = "VersionNo"
        Me.VersionNoView.HeaderText = "VersionNo"
        Me.VersionNoView.Name = "VersionNoView"
        '
        'StatusView
        '
        Me.StatusView.DataPropertyName = "Status"
        Me.StatusView.HeaderText = "Status"
        Me.StatusView.Name = "StatusView"
        '
        'cmsOperatingCost
        '
        Me.cmsOperatingCost.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsOperatingCost.Name = "cmsITNIn"
        Me.cmsOperatingCost.Size = New System.Drawing.Size(160, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditUpdateToolStripMenuItem
        '
        Me.EditUpdateToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditUpdateToolStripMenuItem.Image = CType(resources.GetObject("EditUpdateToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditUpdateToolStripMenuItem.Name = "EditUpdateToolStripMenuItem"
        Me.EditUpdateToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.EditUpdateToolStripMenuItem.Text = "Edit / Update"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'pnlOperatingBudgetByCost
        '
        Me.pnlOperatingBudgetByCost.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlOperatingBudgetByCost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlOperatingBudgetByCost.BorderColor = System.Drawing.Color.Gray
        Me.pnlOperatingBudgetByCost.CaptionColorOne = System.Drawing.Color.White
        Me.pnlOperatingBudgetByCost.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlOperatingBudgetByCost.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOperatingBudgetByCost.CaptionSize = 40
        Me.pnlOperatingBudgetByCost.CaptionText = "Search Operating Budget By Cost"
        Me.pnlOperatingBudgetByCost.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.btnSearchVHNoView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.lblVHDescpView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.lblVHNoView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.btnSearchVHGroupView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.txtVHNoView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.txtCOAGroupView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.lblCOADescpView)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.lblCOAGroupV)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.lblsearchCategory)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.lblBudgetYearV)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.cmbBudgetyear)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.btnSearch)
        Me.pnlOperatingBudgetByCost.Controls.Add(Me.btnviewReport)
        Me.pnlOperatingBudgetByCost.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlOperatingBudgetByCost.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlOperatingBudgetByCost.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlOperatingBudgetByCost.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOperatingBudgetByCost.ForeColor = System.Drawing.Color.Black
        Me.pnlOperatingBudgetByCost.Location = New System.Drawing.Point(3, 17)
        Me.pnlOperatingBudgetByCost.Name = "pnlOperatingBudgetByCost"
        Me.pnlOperatingBudgetByCost.Size = New System.Drawing.Size(937, 158)
        Me.pnlOperatingBudgetByCost.TabIndex = 119
        '
        'btnSearchVHNoView
        '
        Me.btnSearchVHNoView.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnSearchVHNoView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHNoView.FlatAppearance.BorderSize = 0
        Me.btnSearchVHNoView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHNoView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHNoView.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHNoView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHNoView.Location = New System.Drawing.Point(557, 76)
        Me.btnSearchVHNoView.Name = "btnSearchVHNoView"
        Me.btnSearchVHNoView.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHNoView.TabIndex = 141
        Me.btnSearchVHNoView.TabStop = False
        Me.btnSearchVHNoView.UseVisualStyleBackColor = True
        '
        'lblVHDescpView
        '
        Me.lblVHDescpView.ForeColor = System.Drawing.Color.Blue
        Me.lblVHDescpView.Location = New System.Drawing.Point(619, 80)
        Me.lblVHDescpView.Name = "lblVHDescpView"
        Me.lblVHDescpView.Size = New System.Drawing.Size(148, 29)
        Me.lblVHDescpView.TabIndex = 169
        '
        'lblVHNoView
        '
        Me.lblVHNoView.AutoSize = True
        Me.lblVHNoView.ForeColor = System.Drawing.Color.Black
        Me.lblVHNoView.Location = New System.Drawing.Point(428, 64)
        Me.lblVHNoView.Name = "lblVHNoView"
        Me.lblVHNoView.Size = New System.Drawing.Size(42, 13)
        Me.lblVHNoView.TabIndex = 166
        Me.lblVHNoView.Text = "VH No"
        '
        'btnSearchVHGroupView
        '
        Me.btnSearchVHGroupView.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnSearchVHGroupView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchVHGroupView.FlatAppearance.BorderSize = 0
        Me.btnSearchVHGroupView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchVHGroupView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchVHGroupView.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchVHGroupView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchVHGroupView.Location = New System.Drawing.Point(346, 73)
        Me.btnSearchVHGroupView.Name = "btnSearchVHGroupView"
        Me.btnSearchVHGroupView.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchVHGroupView.TabIndex = 140
        Me.btnSearchVHGroupView.TabStop = False
        Me.btnSearchVHGroupView.UseVisualStyleBackColor = True
        '
        'txtVHNoView
        '
        Me.txtVHNoView.Location = New System.Drawing.Point(431, 81)
        Me.txtVHNoView.Name = "txtVHNoView"
        Me.txtVHNoView.Size = New System.Drawing.Size(116, 21)
        Me.txtVHNoView.TabIndex = 2
        '
        'txtCOAGroupView
        '
        Me.txtCOAGroupView.Location = New System.Drawing.Point(221, 80)
        Me.txtCOAGroupView.MaxLength = 50
        Me.txtCOAGroupView.Name = "txtCOAGroupView"
        Me.txtCOAGroupView.Size = New System.Drawing.Size(115, 21)
        Me.txtCOAGroupView.TabIndex = 1
        '
        'lblCOADescpView
        '
        Me.lblCOADescpView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOADescpView.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescpView.Location = New System.Drawing.Point(218, 118)
        Me.lblCOADescpView.Name = "lblCOADescpView"
        Me.lblCOADescpView.Size = New System.Drawing.Size(171, 18)
        Me.lblCOADescpView.TabIndex = 141
        Me.lblCOADescpView.Text = "COA Descp"
        '
        'lblCOAGroupV
        '
        Me.lblCOAGroupV.AutoSize = True
        Me.lblCOAGroupV.ForeColor = System.Drawing.Color.Black
        Me.lblCOAGroupV.Location = New System.Drawing.Point(217, 64)
        Me.lblCOAGroupV.Name = "lblCOAGroupV"
        Me.lblCOAGroupV.Size = New System.Drawing.Size(58, 13)
        Me.lblCOAGroupV.TabIndex = 118
        Me.lblCOAGroupV.Text = "VHGroup"
        '
        'lblsearchCategory
        '
        Me.lblsearchCategory.AutoSize = True
        Me.lblsearchCategory.BackColor = System.Drawing.Color.Transparent
        Me.lblsearchCategory.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblsearchCategory.ForeColor = System.Drawing.Color.Black
        Me.lblsearchCategory.Location = New System.Drawing.Point(1, 41)
        Me.lblsearchCategory.Name = "lblsearchCategory"
        Me.lblsearchCategory.Size = New System.Drawing.Size(72, 13)
        Me.lblsearchCategory.TabIndex = 54
        Me.lblsearchCategory.Text = "Search By"
        '
        'lblBudgetYearV
        '
        Me.lblBudgetYearV.AutoSize = True
        Me.lblBudgetYearV.ForeColor = System.Drawing.Color.Black
        Me.lblBudgetYearV.Location = New System.Drawing.Point(105, 64)
        Me.lblBudgetYearV.Name = "lblBudgetYearV"
        Me.lblBudgetYearV.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetYearV.TabIndex = 16
        Me.lblBudgetYearV.Text = "Budget Year"
        '
        'cmbBudgetyear
        '
        Me.cmbBudgetyear.FormattingEnabled = True
        Me.cmbBudgetyear.Location = New System.Drawing.Point(108, 80)
        Me.cmbBudgetyear.Name = "cmbBudgetyear"
        Me.cmbBudgetyear.Size = New System.Drawing.Size(89, 21)
        Me.cmbBudgetyear.TabIndex = 117
        Me.cmbBudgetyear.TabStop = False
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(602, 118)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 25)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(745, 118)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(147, 25)
        Me.btnviewReport.TabIndex = 4
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        '
        'OperatingBudgetCostFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1205, 698)
        Me.Controls.Add(Me.tbOperatingBDGCost)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "OperatingBudgetCostFrm"
        Me.Text = "OperatingBudgetCostFrm"
        Me.tbOperatingBDGCost.ResumeLayout(False)
        Me.tbOperatingCost.ResumeLayout(False)
        Me.tbOperatingCost.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.dgOperatingCost, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpButtons.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grpOperatingCost.ResumeLayout(False)
        Me.grpOperatingCost.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgOperatingCostView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsOperatingCost.ResumeLayout(False)
        Me.pnlOperatingBudgetByCost.ResumeLayout(False)
        Me.pnlOperatingBudgetByCost.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbOperatingBDGCost As System.Windows.Forms.TabControl
    Friend WithEvents tbOperatingCost As System.Windows.Forms.TabPage
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents grpOperatingCost As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYear As System.Windows.Forms.Label
    Friend WithEvents lblBudgetyearL As System.Windows.Forms.Label
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHGroup As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVHGroup As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHNo As System.Windows.Forms.Button
    Friend WithEvents txtVHNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVHNo As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHcostCode As System.Windows.Forms.Button
    Friend WithEvents txtVHDetailCostCode As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDetailCostCode As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDriverName As System.Windows.Forms.Label
    Friend WithEvents lblDriver As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddDescp As System.Windows.Forms.Button
    Friend WithEvents txtPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents txtIDR As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblIDR As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtSubDescp As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblSubDescp As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents txtRevJan As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJan As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionJan As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJan As System.Windows.Forms.Label
    Friend WithEvents txtRevMay As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMay As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionMay As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMay As System.Windows.Forms.Label
    Friend WithEvents txtRevSep As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetSep As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionSep As System.Windows.Forms.Label
    Friend WithEvents lblBudgetSep As System.Windows.Forms.Label
    Friend WithEvents txtRevFeb As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetFeb As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionFeb As System.Windows.Forms.Label
    Friend WithEvents lblBudgetFeb As System.Windows.Forms.Label
    Friend WithEvents txtRevJun As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJun As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionJun As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJun As System.Windows.Forms.Label
    Friend WithEvents txtRevOct As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetOct As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionOct As System.Windows.Forms.Label
    Friend WithEvents lblBudgetOct As System.Windows.Forms.Label
    Friend WithEvents txtRevMar As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetMar As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionMar As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMar As System.Windows.Forms.Label
    Friend WithEvents txtRevJul As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetJul As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionJul As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJul As System.Windows.Forms.Label
    Friend WithEvents txtRevNov As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetNov As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionNov As System.Windows.Forms.Label
    Friend WithEvents lblBudgetNov As System.Windows.Forms.Label
    Friend WithEvents txtRevApr As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetApr As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionApr As System.Windows.Forms.Label
    Friend WithEvents lblBudgetApr As System.Windows.Forms.Label
    Friend WithEvents txtRevAug As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetAug As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionAug As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAug As System.Windows.Forms.Label
    Friend WithEvents txtRevDec As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetDec As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionDec As System.Windows.Forms.Label
    Friend WithEvents lblBudgetDec As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetGeneral As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblBudgetTotal As System.Windows.Forms.Label
    Friend WithEvents lblBudgetTotalL As System.Windows.Forms.Label
    Friend WithEvents dgOperatingCost As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlOperatingBudgetByCost As Stepi.UI.ExtendedPanel
    Friend WithEvents btnSearchVHGroupView As System.Windows.Forms.Button
    Friend WithEvents lblCOADescpView As System.Windows.Forms.Label
    Friend WithEvents txtCOAGroupView As System.Windows.Forms.TextBox
    Friend WithEvents lblCOAGroupV As System.Windows.Forms.Label
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents lblBudgetYearV As System.Windows.Forms.Label
    Friend WithEvents cmbBudgetyear As System.Windows.Forms.ComboBox
    Friend WithEvents lblVHDescp As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatusL As System.Windows.Forms.Label
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblVersionNoL As System.Windows.Forms.Label
    Friend WithEvents cmsOperatingCost As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblVHDescpView As System.Windows.Forms.Label
    Friend WithEvents txtVHNoView As System.Windows.Forms.TextBox
    Friend WithEvents lblVHNoView As System.Windows.Forms.Label
    Friend WithEvents btnSearchVHNoView As System.Windows.Forms.Button
    Friend WithEvents txtVHGroup As System.Windows.Forms.TextBox
    Friend WithEvents OperatingBudgetByCostID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Percentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents BudgetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblNoRecord As System.Windows.Forms.Label
    Friend WithEvents dgOperatingCostView As System.Windows.Forms.DataGridView
    Friend WithEvents OperatingBudgetByCostIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYearView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCodeIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAGroupView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescpView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDetailCostCodeView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHNoView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VHDescpView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmpNameView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubDescView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDRView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercentageView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJanView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetFebView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMarView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAprView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetMayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJunView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetJulView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetAugView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetSepView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetOctView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetNovView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetDecView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJanView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevFebView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMarview As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAprView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJunView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJulView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAugView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevSepView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevOctView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNovView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDecView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetTotalView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNoView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusView As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

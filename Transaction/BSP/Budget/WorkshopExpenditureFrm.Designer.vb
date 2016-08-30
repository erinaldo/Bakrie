<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkshopExpenditureFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkshopExpenditureFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tbWorkshopExpenditure = New System.Windows.Forms.TabControl
        Me.tbWorkshop = New System.Windows.Forms.TabPage
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblOldAccCode = New System.Windows.Forms.Label
        Me.lblOldCOACode = New System.Windows.Forms.Label
        Me.lblCOADescp = New System.Windows.Forms.Label
        Me.btnSearchAccountCode = New System.Windows.Forms.Button
        Me.txtCOACode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblBudgetYear = New System.Windows.Forms.Label
        Me.lblCOA = New System.Windows.Forms.Label
        Me.lblBudgetyearL = New System.Windows.Forms.Label
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnResetAll = New System.Windows.Forms.Button
        Me.btnSaveAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GrpGrid = New System.Windows.Forms.GroupBox
        Me.dgWorkshopExpand = New System.Windows.Forms.DataGridView
        Me.BudgetID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Day = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Percentage = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblBudgetTotal = New System.Windows.Forms.Label
        Me.lblBudgetTotalL = New System.Windows.Forms.Label
        Me.grpMonths = New System.Windows.Forms.GroupBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblPinkDecL = New System.Windows.Forms.Label
        Me.lblRevisionDec = New System.Windows.Forms.Label
        Me.lblBudgetDec = New System.Windows.Forms.Label
        Me.lblPinkAugL = New System.Windows.Forms.Label
        Me.lblRevisionAug = New System.Windows.Forms.Label
        Me.lblBudgetAug = New System.Windows.Forms.Label
        Me.lblPinkAprL = New System.Windows.Forms.Label
        Me.lblRevisionApr = New System.Windows.Forms.Label
        Me.lblBudgetApr = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.lblPinkNovL = New System.Windows.Forms.Label
        Me.lblRevisionNov = New System.Windows.Forms.Label
        Me.lblBudgetNov = New System.Windows.Forms.Label
        Me.lblPinkJulL = New System.Windows.Forms.Label
        Me.lblRevisionJul = New System.Windows.Forms.Label
        Me.lblBudgetJul = New System.Windows.Forms.Label
        Me.lblPinkMarL = New System.Windows.Forms.Label
        Me.lblRevisionMar = New System.Windows.Forms.Label
        Me.lblBudgetMar = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label49 = New System.Windows.Forms.Label
        Me.lblPinkOctL = New System.Windows.Forms.Label
        Me.lblRevisionOct = New System.Windows.Forms.Label
        Me.lblBudgetOct = New System.Windows.Forms.Label
        Me.lblPinkJunL = New System.Windows.Forms.Label
        Me.lblRevisionJun = New System.Windows.Forms.Label
        Me.lblBudgetJun = New System.Windows.Forms.Label
        Me.lblPinkFebL = New System.Windows.Forms.Label
        Me.lblRevisionFeb = New System.Windows.Forms.Label
        Me.lblBudgetFeb = New System.Windows.Forms.Label
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.lblPinkSepL = New System.Windows.Forms.Label
        Me.lblRevisionSep = New System.Windows.Forms.Label
        Me.lblBudgetSep = New System.Windows.Forms.Label
        Me.lblPinkMayL = New System.Windows.Forms.Label
        Me.lblRevisionMay = New System.Windows.Forms.Label
        Me.lblBudgetMay = New System.Windows.Forms.Label
        Me.lblPinkJanL = New System.Windows.Forms.Label
        Me.lblRevisionJan = New System.Windows.Forms.Label
        Me.lblBudgetJan = New System.Windows.Forms.Label
        Me.lblPinkDec = New System.Windows.Forms.Label
        Me.lblPinkNov = New System.Windows.Forms.Label
        Me.lblPinkAug = New System.Windows.Forms.Label
        Me.lblPinkJul = New System.Windows.Forms.Label
        Me.lblPinkApr = New System.Windows.Forms.Label
        Me.lblPinkMar = New System.Windows.Forms.Label
        Me.lblPinkOct = New System.Windows.Forms.Label
        Me.lblPinkJun = New System.Windows.Forms.Label
        Me.lblPinkFeb = New System.Windows.Forms.Label
        Me.lblPinkSep = New System.Windows.Forms.Label
        Me.lblPinkJan = New System.Windows.Forms.Label
        Me.lblPinkMay = New System.Windows.Forms.Label
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
        Me.lblPinks = New System.Windows.Forms.Label
        Me.lblRevisions = New System.Windows.Forms.Label
        Me.lblBudgets = New System.Windows.Forms.Label
        Me.lblPinkSlipL = New System.Windows.Forms.Label
        Me.lblRevisionL = New System.Windows.Forms.Label
        Me.lblBudgetL = New System.Windows.Forms.Label
        Me.lblPinkSlip = New System.Windows.Forms.Label
        Me.lblRevision = New System.Windows.Forms.Label
        Me.lblBudget = New System.Windows.Forms.Label
        Me.lblStatus = New System.Windows.Forms.Label
        Me.grpBudgetYear = New System.Windows.Forms.GroupBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtPercentage = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblPercentage = New System.Windows.Forms.Label
        Me.txtMonth = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblMonth = New System.Windows.Forms.Label
        Me.txtDay = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.lblDay = New System.Windows.Forms.Label
        Me.txtUnit = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblUnit = New System.Windows.Forms.Label
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblQty = New System.Windows.Forms.Label
        Me.txtSubDesc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblSubDesc = New System.Windows.Forms.Label
        Me.btnDistribute = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTotalPrice = New System.Windows.Forms.Label
        Me.lblStatusL = New System.Windows.Forms.Label
        Me.lblVersionNo = New System.Windows.Forms.Label
        Me.lblVersionNoL = New System.Windows.Forms.Label
        Me.tbView = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgWorkshopExpendView = New System.Windows.Forms.DataGridView
        Me.ExtendedPanel1 = New Stepi.UI.ExtendedPanel
        Me.Label11 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.lblNoRecordFound = New System.Windows.Forms.Label
        Me.dgCapitalExpView = New System.Windows.Forms.DataGridView
        Me.BudgetIDView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetYearView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateIdView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EstateCodeView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewCOAId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COACodeView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COADescpView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OldCOACodeView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubDescView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QtyView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CostView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MonthView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PercentageView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetTypeView = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.RevMarView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAprView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevMayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJunView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevJulView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevAugView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevSepView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevOctView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevNovView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevDecView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJanview = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkFebView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkMarView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkAprView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkMayView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJunView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkJulView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkAugView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkSepView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkOctView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkNovView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PinkDecView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RemarksView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BudgetTotalView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VersionNoView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.pnlCapitalExpSearch = New Stepi.UI.ExtendedPanel
        Me.lblBudgetYearView = New System.Windows.Forms.Label
        Me.btnSearchCOACode = New System.Windows.Forms.Button
        Me.lblCOADescpView = New System.Windows.Forms.Label
        Me.txtCOACodeView = New System.Windows.Forms.TextBox
        Me.lblCoaCodeV = New System.Windows.Forms.Label
        Me.lblsearchCategory = New System.Windows.Forms.Label
        Me.lblBudgetYearV = New System.Windows.Forms.Label
        Me.btnviewReport = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cmsWorkshopExpend = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewBudgetID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetYear = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewEstateID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewEstateCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COAIdView = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewCOADescp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewOldCOACode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewSubDesc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewCost = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewDay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewMonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRevDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkJan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkFeb = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkMar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkApr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkMay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkJun = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkJul = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkAug = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkSep = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkOct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkNov = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPinkDec = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewPrice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewBudgetTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewVersionNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbWorkshopExpenditure.SuspendLayout()
        Me.tbWorkshop.SuspendLayout()
        Me.GrpGrid.SuspendLayout()
        CType(Me.dgWorkshopExpand, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMonths.SuspendLayout()
        Me.grpBudgetYear.SuspendLayout()
        Me.tbView.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgWorkshopExpendView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ExtendedPanel1.SuspendLayout()
        CType(Me.dgCapitalExpView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCapitalExpSearch.SuspendLayout()
        Me.cmsWorkshopExpend.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbWorkshopExpenditure
        '
        Me.tbWorkshopExpenditure.Controls.Add(Me.tbWorkshop)
        Me.tbWorkshopExpenditure.Controls.Add(Me.tbView)
        Me.tbWorkshopExpenditure.Location = New System.Drawing.Point(12, 0)
        Me.tbWorkshopExpenditure.Name = "tbWorkshopExpenditure"
        Me.tbWorkshopExpenditure.SelectedIndex = 0
        Me.tbWorkshopExpenditure.Size = New System.Drawing.Size(1017, 720)
        Me.tbWorkshopExpenditure.TabIndex = 0
        '
        'tbWorkshop
        '
        Me.tbWorkshop.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbWorkshop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbWorkshop.Controls.Add(Me.Label18)
        Me.tbWorkshop.Controls.Add(Me.Label16)
        Me.tbWorkshop.Controls.Add(Me.Label17)
        Me.tbWorkshop.Controls.Add(Me.lblOldAccCode)
        Me.tbWorkshop.Controls.Add(Me.lblOldCOACode)
        Me.tbWorkshop.Controls.Add(Me.lblCOADescp)
        Me.tbWorkshop.Controls.Add(Me.btnSearchAccountCode)
        Me.tbWorkshop.Controls.Add(Me.txtCOACode)
        Me.tbWorkshop.Controls.Add(Me.Label3)
        Me.tbWorkshop.Controls.Add(Me.Label2)
        Me.tbWorkshop.Controls.Add(Me.lblBudgetYear)
        Me.tbWorkshop.Controls.Add(Me.lblCOA)
        Me.tbWorkshop.Controls.Add(Me.lblBudgetyearL)
        Me.tbWorkshop.Controls.Add(Me.btnReset)
        Me.tbWorkshop.Controls.Add(Me.btnAdd)
        Me.tbWorkshop.Controls.Add(Me.btnResetAll)
        Me.tbWorkshop.Controls.Add(Me.btnSaveAll)
        Me.tbWorkshop.Controls.Add(Me.btnClose)
        Me.tbWorkshop.Controls.Add(Me.GrpGrid)
        Me.tbWorkshop.Controls.Add(Me.lblBudgetTotal)
        Me.tbWorkshop.Controls.Add(Me.lblBudgetTotalL)
        Me.tbWorkshop.Controls.Add(Me.grpMonths)
        Me.tbWorkshop.Controls.Add(Me.lblStatus)
        Me.tbWorkshop.Controls.Add(Me.grpBudgetYear)
        Me.tbWorkshop.Controls.Add(Me.lblStatusL)
        Me.tbWorkshop.Controls.Add(Me.lblVersionNo)
        Me.tbWorkshop.Controls.Add(Me.lblVersionNoL)
        Me.tbWorkshop.Location = New System.Drawing.Point(4, 22)
        Me.tbWorkshop.Name = "tbWorkshop"
        Me.tbWorkshop.Padding = New System.Windows.Forms.Padding(3)
        Me.tbWorkshop.Size = New System.Drawing.Size(1009, 694)
        Me.tbWorkshop.TabIndex = 0
        Me.tbWorkshop.Text = "Workshop Expenditure"
        Me.tbWorkshop.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(879, 34)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(12, 13)
        Me.Label18.TabIndex = 214
        Me.Label18.Text = ":"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(140, 55)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(12, 13)
        Me.Label16.TabIndex = 261
        Me.Label16.Text = ":"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(879, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(12, 13)
        Me.Label17.TabIndex = 213
        Me.Label17.Text = ":"
        '
        'lblOldAccCode
        '
        Me.lblOldAccCode.AutoSize = True
        Me.lblOldAccCode.Location = New System.Drawing.Point(12, 55)
        Me.lblOldAccCode.Name = "lblOldAccCode"
        Me.lblOldAccCode.Size = New System.Drawing.Size(90, 13)
        Me.lblOldAccCode.TabIndex = 260
        Me.lblOldAccCode.Text = "Old COA Code"
        '
        'lblOldCOACode
        '
        Me.lblOldCOACode.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblOldCOACode.Location = New System.Drawing.Point(157, 59)
        Me.lblOldCOACode.Name = "lblOldCOACode"
        Me.lblOldCOACode.Size = New System.Drawing.Size(118, 15)
        Me.lblOldCOACode.TabIndex = 259
        Me.lblOldCOACode.Text = "Old COACode"
        Me.lblOldCOACode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCOADescp
        '
        Me.lblCOADescp.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescp.Location = New System.Drawing.Point(339, 23)
        Me.lblCOADescp.Name = "lblCOADescp"
        Me.lblCOADescp.Size = New System.Drawing.Size(152, 49)
        Me.lblCOADescp.TabIndex = 258
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
        Me.btnSearchAccountCode.Location = New System.Drawing.Point(298, 25)
        Me.btnSearchAccountCode.Name = "btnSearchAccountCode"
        Me.btnSearchAccountCode.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchAccountCode.TabIndex = 257
        Me.btnSearchAccountCode.TabStop = False
        Me.btnSearchAccountCode.UseVisualStyleBackColor = True
        '
        'txtCOACode
        '
        Me.txtCOACode.Location = New System.Drawing.Point(157, 29)
        Me.txtCOACode.Name = "txtCOACode"
        Me.txtCOACode.Size = New System.Drawing.Size(135, 21)
        Me.txtCOACode.TabIndex = 253
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(140, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(140, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 13)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = ":"
        '
        'lblBudgetYear
        '
        Me.lblBudgetYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYear.Location = New System.Drawing.Point(157, 3)
        Me.lblBudgetYear.Name = "lblBudgetYear"
        Me.lblBudgetYear.Size = New System.Drawing.Size(135, 21)
        Me.lblBudgetYear.TabIndex = 254
        '
        'lblCOA
        '
        Me.lblCOA.AutoSize = True
        Me.lblCOA.ForeColor = System.Drawing.Color.Red
        Me.lblCOA.Location = New System.Drawing.Point(12, 29)
        Me.lblCOA.Name = "lblCOA"
        Me.lblCOA.Size = New System.Drawing.Size(33, 13)
        Me.lblCOA.TabIndex = 252
        Me.lblCOA.Text = "COA"
        '
        'lblBudgetyearL
        '
        Me.lblBudgetyearL.AutoSize = True
        Me.lblBudgetyearL.Location = New System.Drawing.Point(12, 3)
        Me.lblBudgetyearL.Name = "lblBudgetyearL"
        Me.lblBudgetyearL.Size = New System.Drawing.Size(77, 13)
        Me.lblBudgetyearL.TabIndex = 251
        Me.lblBudgetyearL.Text = "Budget Year"
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(882, 494)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(97, 25)
        Me.btnReset.TabIndex = 250
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
        Me.btnAdd.Location = New System.Drawing.Point(779, 494)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(97, 25)
        Me.btnAdd.TabIndex = 249
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(745, 662)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(106, 25)
        Me.btnResetAll.TabIndex = 244
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(633, 662)
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
        Me.btnClose.Location = New System.Drawing.Point(857, 662)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(107, 25)
        Me.btnClose.TabIndex = 245
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GrpGrid
        '
        Me.GrpGrid.Controls.Add(Me.dgWorkshopExpand)
        Me.GrpGrid.Location = New System.Drawing.Point(11, 517)
        Me.GrpGrid.Name = "GrpGrid"
        Me.GrpGrid.Size = New System.Drawing.Size(985, 145)
        Me.GrpGrid.TabIndex = 248
        Me.GrpGrid.TabStop = False
        '
        'dgWorkshopExpand
        '
        Me.dgWorkshopExpand.AllowUserToAddRows = False
        Me.dgWorkshopExpand.AllowUserToDeleteRows = False
        Me.dgWorkshopExpand.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgWorkshopExpand.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgWorkshopExpand.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgWorkshopExpand.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWorkshopExpand.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgWorkshopExpand.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgWorkshopExpand.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BudgetID, Me.BudgetYear, Me.EstateID, Me.COAId, Me.COACode, Me.COADescp, Me.OldCOACode, Me.BudgetType, Me.SubDesc, Me.Qty, Me.Day, Me.Month, Me.Percentage, Me.BudgetJan, Me.BudgetFeb, Me.BudgetMar, Me.BudgetApr, Me.BudgetMay, Me.BudgetJun, Me.BudgetJul, Me.BudgetAug, Me.BudgetSep, Me.BudgetOct, Me.BudgetNov, Me.BudgetDec, Me.RevJan, Me.RevFeb, Me.RevMar, Me.RevApr, Me.RevMay, Me.RevJun, Me.RevJul, Me.RevAug, Me.RevSep, Me.RevOct, Me.RevNov, Me.RevDec, Me.PinkJan, Me.PinkFeb, Me.PinkMar, Me.PinkApr, Me.PinkMay, Me.PinkJun, Me.PinkJul, Me.PinkAug, Me.PinkSep, Me.PinkOct, Me.PinkNov, Me.PinkDec, Me.Price, Me.Remarks, Me.BudgetTotal, Me.VersionNo, Me.Status})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgWorkshopExpand.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgWorkshopExpand.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgWorkshopExpand.EnableHeadersVisualStyles = False
        Me.dgWorkshopExpand.GridColor = System.Drawing.Color.Gray
        Me.dgWorkshopExpand.Location = New System.Drawing.Point(3, 17)
        Me.dgWorkshopExpand.Name = "dgWorkshopExpand"
        Me.dgWorkshopExpand.RowHeadersVisible = False
        Me.dgWorkshopExpand.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWorkshopExpand.ShowCellErrors = False
        Me.dgWorkshopExpand.Size = New System.Drawing.Size(979, 125)
        Me.dgWorkshopExpand.TabIndex = 120
        '
        'BudgetID
        '
        Me.BudgetID.DataPropertyName = "BudgetID"
        Me.BudgetID.HeaderText = "BudgetID"
        Me.BudgetID.Name = "BudgetID"
        Me.BudgetID.Visible = False
        Me.BudgetID.Width = 123
        '
        'BudgetYear
        '
        Me.BudgetYear.DataPropertyName = "BudgetYear"
        Me.BudgetYear.HeaderText = "Budget Year"
        Me.BudgetYear.Name = "BudgetYear"
        Me.BudgetYear.Width = 101
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
        'OldCOACode
        '
        Me.OldCOACode.DataPropertyName = "OldCOACode"
        Me.OldCOACode.HeaderText = "OldCOACode"
        Me.OldCOACode.Name = "OldCOACode"
        '
        'BudgetType
        '
        Me.BudgetType.DataPropertyName = "BudgetType"
        Me.BudgetType.HeaderText = "Budget Type"
        Me.BudgetType.Name = "BudgetType"
        '
        'SubDesc
        '
        Me.SubDesc.DataPropertyName = "SubDesc"
        Me.SubDesc.HeaderText = "Sub Desc"
        Me.SubDesc.Name = "SubDesc"
        '
        'Qty
        '
        Me.Qty.DataPropertyName = "Qty"
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        '
        'Day
        '
        Me.Day.DataPropertyName = "Day"
        Me.Day.HeaderText = "Day"
        Me.Day.Name = "Day"
        '
        'Month
        '
        Me.Month.DataPropertyName = "Month"
        Me.Month.HeaderText = "Month"
        Me.Month.Name = "Month"
        '
        'Percentage
        '
        Me.Percentage.DataPropertyName = "Percentage"
        Me.Percentage.HeaderText = "Percentage"
        Me.Percentage.Name = "Percentage"
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
        'Price
        '
        Me.Price.DataPropertyName = "Price"
        Me.Price.HeaderText = "Amount"
        Me.Price.Name = "Price"
        Me.Price.Width = 75
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
        Me.lblBudgetTotal.Location = New System.Drawing.Point(844, 470)
        Me.lblBudgetTotal.Name = "lblBudgetTotal"
        Me.lblBudgetTotal.Size = New System.Drawing.Size(135, 21)
        Me.lblBudgetTotal.TabIndex = 247
        '
        'lblBudgetTotalL
        '
        Me.lblBudgetTotalL.AutoSize = True
        Me.lblBudgetTotalL.Location = New System.Drawing.Point(735, 470)
        Me.lblBudgetTotalL.Name = "lblBudgetTotalL"
        Me.lblBudgetTotalL.Size = New System.Drawing.Size(96, 13)
        Me.lblBudgetTotalL.TabIndex = 246
        Me.lblBudgetTotalL.Text = "Budget Total   :"
        '
        'grpMonths
        '
        Me.grpMonths.Controls.Add(Me.Label29)
        Me.grpMonths.Controls.Add(Me.Label30)
        Me.grpMonths.Controls.Add(Me.Label31)
        Me.grpMonths.Controls.Add(Me.Label26)
        Me.grpMonths.Controls.Add(Me.Label27)
        Me.grpMonths.Controls.Add(Me.Label28)
        Me.grpMonths.Controls.Add(Me.Label21)
        Me.grpMonths.Controls.Add(Me.Label20)
        Me.grpMonths.Controls.Add(Me.Label19)
        Me.grpMonths.Controls.Add(Me.lblPinkDecL)
        Me.grpMonths.Controls.Add(Me.lblRevisionDec)
        Me.grpMonths.Controls.Add(Me.lblBudgetDec)
        Me.grpMonths.Controls.Add(Me.lblPinkAugL)
        Me.grpMonths.Controls.Add(Me.lblRevisionAug)
        Me.grpMonths.Controls.Add(Me.lblBudgetAug)
        Me.grpMonths.Controls.Add(Me.lblPinkAprL)
        Me.grpMonths.Controls.Add(Me.lblRevisionApr)
        Me.grpMonths.Controls.Add(Me.lblBudgetApr)
        Me.grpMonths.Controls.Add(Me.Label32)
        Me.grpMonths.Controls.Add(Me.Label33)
        Me.grpMonths.Controls.Add(Me.Label34)
        Me.grpMonths.Controls.Add(Me.Label35)
        Me.grpMonths.Controls.Add(Me.Label36)
        Me.grpMonths.Controls.Add(Me.Label37)
        Me.grpMonths.Controls.Add(Me.Label38)
        Me.grpMonths.Controls.Add(Me.Label39)
        Me.grpMonths.Controls.Add(Me.Label40)
        Me.grpMonths.Controls.Add(Me.lblPinkNovL)
        Me.grpMonths.Controls.Add(Me.lblRevisionNov)
        Me.grpMonths.Controls.Add(Me.lblBudgetNov)
        Me.grpMonths.Controls.Add(Me.lblPinkJulL)
        Me.grpMonths.Controls.Add(Me.lblRevisionJul)
        Me.grpMonths.Controls.Add(Me.lblBudgetJul)
        Me.grpMonths.Controls.Add(Me.lblPinkMarL)
        Me.grpMonths.Controls.Add(Me.lblRevisionMar)
        Me.grpMonths.Controls.Add(Me.lblBudgetMar)
        Me.grpMonths.Controls.Add(Me.Label41)
        Me.grpMonths.Controls.Add(Me.Label42)
        Me.grpMonths.Controls.Add(Me.Label43)
        Me.grpMonths.Controls.Add(Me.Label44)
        Me.grpMonths.Controls.Add(Me.Label45)
        Me.grpMonths.Controls.Add(Me.Label46)
        Me.grpMonths.Controls.Add(Me.Label47)
        Me.grpMonths.Controls.Add(Me.Label48)
        Me.grpMonths.Controls.Add(Me.Label49)
        Me.grpMonths.Controls.Add(Me.lblPinkOctL)
        Me.grpMonths.Controls.Add(Me.lblRevisionOct)
        Me.grpMonths.Controls.Add(Me.lblBudgetOct)
        Me.grpMonths.Controls.Add(Me.lblPinkJunL)
        Me.grpMonths.Controls.Add(Me.lblRevisionJun)
        Me.grpMonths.Controls.Add(Me.lblBudgetJun)
        Me.grpMonths.Controls.Add(Me.lblPinkFebL)
        Me.grpMonths.Controls.Add(Me.lblRevisionFeb)
        Me.grpMonths.Controls.Add(Me.lblBudgetFeb)
        Me.grpMonths.Controls.Add(Me.Label50)
        Me.grpMonths.Controls.Add(Me.Label51)
        Me.grpMonths.Controls.Add(Me.Label52)
        Me.grpMonths.Controls.Add(Me.Label53)
        Me.grpMonths.Controls.Add(Me.Label54)
        Me.grpMonths.Controls.Add(Me.Label55)
        Me.grpMonths.Controls.Add(Me.Label56)
        Me.grpMonths.Controls.Add(Me.Label57)
        Me.grpMonths.Controls.Add(Me.Label58)
        Me.grpMonths.Controls.Add(Me.lblPinkSepL)
        Me.grpMonths.Controls.Add(Me.lblRevisionSep)
        Me.grpMonths.Controls.Add(Me.lblBudgetSep)
        Me.grpMonths.Controls.Add(Me.lblPinkMayL)
        Me.grpMonths.Controls.Add(Me.lblRevisionMay)
        Me.grpMonths.Controls.Add(Me.lblBudgetMay)
        Me.grpMonths.Controls.Add(Me.lblPinkJanL)
        Me.grpMonths.Controls.Add(Me.lblRevisionJan)
        Me.grpMonths.Controls.Add(Me.lblBudgetJan)
        Me.grpMonths.Controls.Add(Me.lblPinkDec)
        Me.grpMonths.Controls.Add(Me.lblPinkNov)
        Me.grpMonths.Controls.Add(Me.lblPinkAug)
        Me.grpMonths.Controls.Add(Me.lblPinkJul)
        Me.grpMonths.Controls.Add(Me.lblPinkApr)
        Me.grpMonths.Controls.Add(Me.lblPinkMar)
        Me.grpMonths.Controls.Add(Me.lblPinkOct)
        Me.grpMonths.Controls.Add(Me.lblPinkJun)
        Me.grpMonths.Controls.Add(Me.lblPinkFeb)
        Me.grpMonths.Controls.Add(Me.lblPinkSep)
        Me.grpMonths.Controls.Add(Me.lblPinkJan)
        Me.grpMonths.Controls.Add(Me.lblPinkMay)
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
        Me.grpMonths.Controls.Add(Me.lblPinks)
        Me.grpMonths.Controls.Add(Me.lblRevisions)
        Me.grpMonths.Controls.Add(Me.lblBudgets)
        Me.grpMonths.Controls.Add(Me.lblPinkSlipL)
        Me.grpMonths.Controls.Add(Me.lblRevisionL)
        Me.grpMonths.Controls.Add(Me.lblBudgetL)
        Me.grpMonths.Controls.Add(Me.lblPinkSlip)
        Me.grpMonths.Controls.Add(Me.lblRevision)
        Me.grpMonths.Controls.Add(Me.lblBudget)
        Me.grpMonths.Location = New System.Drawing.Point(11, 195)
        Me.grpMonths.Name = "grpMonths"
        Me.grpMonths.Size = New System.Drawing.Size(985, 271)
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
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(806, 77)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 13)
        Me.Label31.TabIndex = 2329
        Me.Label31.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(806, 113)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(11, 13)
        Me.Label26.TabIndex = 2328
        Me.Label26.Text = ":"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(806, 136)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(11, 13)
        Me.Label27.TabIndex = 2327
        Me.Label27.Text = ":"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(806, 161)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(11, 13)
        Me.Label28.TabIndex = 2326
        Me.Label28.Text = ":"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(806, 195)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 2325
        Me.Label21.Text = ":"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(806, 218)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 2324
        Me.Label20.Text = ":"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(806, 243)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(11, 13)
        Me.Label19.TabIndex = 2323
        Me.Label19.Text = ":"
        '
        'lblPinkDecL
        '
        Me.lblPinkDecL.AutoSize = True
        Me.lblPinkDecL.Location = New System.Drawing.Point(750, 242)
        Me.lblPinkDecL.Name = "lblPinkDecL"
        Me.lblPinkDecL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkDecL.TabIndex = 2322
        Me.lblPinkDecL.Text = "Dec"
        '
        'lblRevisionDec
        '
        Me.lblRevisionDec.AutoSize = True
        Me.lblRevisionDec.Location = New System.Drawing.Point(750, 218)
        Me.lblRevisionDec.Name = "lblRevisionDec"
        Me.lblRevisionDec.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionDec.TabIndex = 2321
        Me.lblRevisionDec.Text = "Dec"
        '
        'lblBudgetDec
        '
        Me.lblBudgetDec.AutoSize = True
        Me.lblBudgetDec.Location = New System.Drawing.Point(750, 195)
        Me.lblBudgetDec.Name = "lblBudgetDec"
        Me.lblBudgetDec.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetDec.TabIndex = 2320
        Me.lblBudgetDec.Text = "Dec"
        '
        'lblPinkAugL
        '
        Me.lblPinkAugL.AutoSize = True
        Me.lblPinkAugL.Location = New System.Drawing.Point(750, 159)
        Me.lblPinkAugL.Name = "lblPinkAugL"
        Me.lblPinkAugL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkAugL.TabIndex = 2319
        Me.lblPinkAugL.Text = "Aug"
        '
        'lblRevisionAug
        '
        Me.lblRevisionAug.AutoSize = True
        Me.lblRevisionAug.Location = New System.Drawing.Point(750, 134)
        Me.lblRevisionAug.Name = "lblRevisionAug"
        Me.lblRevisionAug.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionAug.TabIndex = 2318
        Me.lblRevisionAug.Text = "Aug"
        '
        'lblBudgetAug
        '
        Me.lblBudgetAug.AutoSize = True
        Me.lblBudgetAug.Location = New System.Drawing.Point(750, 110)
        Me.lblBudgetAug.Name = "lblBudgetAug"
        Me.lblBudgetAug.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetAug.TabIndex = 2317
        Me.lblBudgetAug.Text = "Aug"
        '
        'lblPinkAprL
        '
        Me.lblPinkAprL.AutoSize = True
        Me.lblPinkAprL.Location = New System.Drawing.Point(750, 74)
        Me.lblPinkAprL.Name = "lblPinkAprL"
        Me.lblPinkAprL.Size = New System.Drawing.Size(27, 13)
        Me.lblPinkAprL.TabIndex = 2316
        Me.lblPinkAprL.Text = "Apr"
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
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(567, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 13)
        Me.Label34.TabIndex = 2311
        Me.Label34.Text = ":"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(567, 116)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(11, 13)
        Me.Label35.TabIndex = 2310
        Me.Label35.Text = ":"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(567, 139)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(11, 13)
        Me.Label36.TabIndex = 2309
        Me.Label36.Text = ":"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(567, 164)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(11, 13)
        Me.Label37.TabIndex = 2308
        Me.Label37.Text = ":"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(567, 198)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(11, 13)
        Me.Label38.TabIndex = 2307
        Me.Label38.Text = ":"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(567, 221)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(11, 13)
        Me.Label39.TabIndex = 2306
        Me.Label39.Text = ":"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(567, 246)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 13)
        Me.Label40.TabIndex = 2305
        Me.Label40.Text = ":"
        '
        'lblPinkNovL
        '
        Me.lblPinkNovL.AutoSize = True
        Me.lblPinkNovL.Location = New System.Drawing.Point(516, 245)
        Me.lblPinkNovL.Name = "lblPinkNovL"
        Me.lblPinkNovL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkNovL.TabIndex = 2304
        Me.lblPinkNovL.Text = "Nov"
        '
        'lblRevisionNov
        '
        Me.lblRevisionNov.AutoSize = True
        Me.lblRevisionNov.Location = New System.Drawing.Point(516, 221)
        Me.lblRevisionNov.Name = "lblRevisionNov"
        Me.lblRevisionNov.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionNov.TabIndex = 2303
        Me.lblRevisionNov.Text = "Nov"
        '
        'lblBudgetNov
        '
        Me.lblBudgetNov.AutoSize = True
        Me.lblBudgetNov.Location = New System.Drawing.Point(516, 198)
        Me.lblBudgetNov.Name = "lblBudgetNov"
        Me.lblBudgetNov.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetNov.TabIndex = 2302
        Me.lblBudgetNov.Text = "Nov"
        '
        'lblPinkJulL
        '
        Me.lblPinkJulL.AutoSize = True
        Me.lblPinkJulL.Location = New System.Drawing.Point(516, 162)
        Me.lblPinkJulL.Name = "lblPinkJulL"
        Me.lblPinkJulL.Size = New System.Drawing.Size(22, 13)
        Me.lblPinkJulL.TabIndex = 2301
        Me.lblPinkJulL.Text = "Jul"
        '
        'lblRevisionJul
        '
        Me.lblRevisionJul.AutoSize = True
        Me.lblRevisionJul.Location = New System.Drawing.Point(516, 137)
        Me.lblRevisionJul.Name = "lblRevisionJul"
        Me.lblRevisionJul.Size = New System.Drawing.Size(22, 13)
        Me.lblRevisionJul.TabIndex = 2300
        Me.lblRevisionJul.Text = "Jul"
        '
        'lblBudgetJul
        '
        Me.lblBudgetJul.AutoSize = True
        Me.lblBudgetJul.Location = New System.Drawing.Point(516, 113)
        Me.lblBudgetJul.Name = "lblBudgetJul"
        Me.lblBudgetJul.Size = New System.Drawing.Size(22, 13)
        Me.lblBudgetJul.TabIndex = 2299
        Me.lblBudgetJul.Text = "Jul"
        '
        'lblPinkMarL
        '
        Me.lblPinkMarL.AutoSize = True
        Me.lblPinkMarL.Location = New System.Drawing.Point(516, 77)
        Me.lblPinkMarL.Name = "lblPinkMarL"
        Me.lblPinkMarL.Size = New System.Drawing.Size(28, 13)
        Me.lblPinkMarL.TabIndex = 2298
        Me.lblPinkMarL.Text = "Mar"
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
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(333, 80)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(11, 13)
        Me.Label43.TabIndex = 2293
        Me.Label43.Text = ":"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(333, 116)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(11, 13)
        Me.Label44.TabIndex = 2292
        Me.Label44.Text = ":"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(333, 139)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(11, 13)
        Me.Label45.TabIndex = 2291
        Me.Label45.Text = ":"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(333, 164)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(11, 13)
        Me.Label46.TabIndex = 2290
        Me.Label46.Text = ":"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(333, 198)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(11, 13)
        Me.Label47.TabIndex = 2289
        Me.Label47.Text = ":"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(333, 221)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(11, 13)
        Me.Label48.TabIndex = 2288
        Me.Label48.Text = ":"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(333, 246)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(11, 13)
        Me.Label49.TabIndex = 2287
        Me.Label49.Text = ":"
        '
        'lblPinkOctL
        '
        Me.lblPinkOctL.AutoSize = True
        Me.lblPinkOctL.Location = New System.Drawing.Point(290, 245)
        Me.lblPinkOctL.Name = "lblPinkOctL"
        Me.lblPinkOctL.Size = New System.Drawing.Size(26, 13)
        Me.lblPinkOctL.TabIndex = 2286
        Me.lblPinkOctL.Text = "Oct"
        '
        'lblRevisionOct
        '
        Me.lblRevisionOct.AutoSize = True
        Me.lblRevisionOct.Location = New System.Drawing.Point(290, 221)
        Me.lblRevisionOct.Name = "lblRevisionOct"
        Me.lblRevisionOct.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionOct.TabIndex = 2285
        Me.lblRevisionOct.Text = "Oct"
        '
        'lblBudgetOct
        '
        Me.lblBudgetOct.AutoSize = True
        Me.lblBudgetOct.Location = New System.Drawing.Point(290, 198)
        Me.lblBudgetOct.Name = "lblBudgetOct"
        Me.lblBudgetOct.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetOct.TabIndex = 2284
        Me.lblBudgetOct.Text = "Oct"
        '
        'lblPinkJunL
        '
        Me.lblPinkJunL.AutoSize = True
        Me.lblPinkJunL.Location = New System.Drawing.Point(290, 162)
        Me.lblPinkJunL.Name = "lblPinkJunL"
        Me.lblPinkJunL.Size = New System.Drawing.Size(26, 13)
        Me.lblPinkJunL.TabIndex = 2283
        Me.lblPinkJunL.Text = "Jun"
        '
        'lblRevisionJun
        '
        Me.lblRevisionJun.AutoSize = True
        Me.lblRevisionJun.Location = New System.Drawing.Point(290, 137)
        Me.lblRevisionJun.Name = "lblRevisionJun"
        Me.lblRevisionJun.Size = New System.Drawing.Size(26, 13)
        Me.lblRevisionJun.TabIndex = 2282
        Me.lblRevisionJun.Text = "Jun"
        '
        'lblBudgetJun
        '
        Me.lblBudgetJun.AutoSize = True
        Me.lblBudgetJun.Location = New System.Drawing.Point(290, 113)
        Me.lblBudgetJun.Name = "lblBudgetJun"
        Me.lblBudgetJun.Size = New System.Drawing.Size(26, 13)
        Me.lblBudgetJun.TabIndex = 2281
        Me.lblBudgetJun.Text = "Jun"
        '
        'lblPinkFebL
        '
        Me.lblPinkFebL.AutoSize = True
        Me.lblPinkFebL.Location = New System.Drawing.Point(290, 77)
        Me.lblPinkFebL.Name = "lblPinkFebL"
        Me.lblPinkFebL.Size = New System.Drawing.Size(27, 13)
        Me.lblPinkFebL.TabIndex = 2280
        Me.lblPinkFebL.Text = "Feb"
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
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(120, 77)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(11, 13)
        Me.Label52.TabIndex = 2275
        Me.Label52.Text = ":"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(120, 113)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(11, 13)
        Me.Label53.TabIndex = 2274
        Me.Label53.Text = ":"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(120, 136)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(11, 13)
        Me.Label54.TabIndex = 2273
        Me.Label54.Text = ":"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(120, 161)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(11, 13)
        Me.Label55.TabIndex = 2272
        Me.Label55.Text = ":"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(120, 195)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(11, 13)
        Me.Label56.TabIndex = 2271
        Me.Label56.Text = ":"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label57.Location = New System.Drawing.Point(120, 218)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(11, 13)
        Me.Label57.TabIndex = 2270
        Me.Label57.Text = ":"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(120, 243)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(11, 13)
        Me.Label58.TabIndex = 2269
        Me.Label58.Text = ":"
        '
        'lblPinkSepL
        '
        Me.lblPinkSepL.AutoSize = True
        Me.lblPinkSepL.Location = New System.Drawing.Point(72, 242)
        Me.lblPinkSepL.Name = "lblPinkSepL"
        Me.lblPinkSepL.Size = New System.Drawing.Size(29, 13)
        Me.lblPinkSepL.TabIndex = 2268
        Me.lblPinkSepL.Text = "Sep"
        '
        'lblRevisionSep
        '
        Me.lblRevisionSep.AutoSize = True
        Me.lblRevisionSep.Location = New System.Drawing.Point(72, 218)
        Me.lblRevisionSep.Name = "lblRevisionSep"
        Me.lblRevisionSep.Size = New System.Drawing.Size(29, 13)
        Me.lblRevisionSep.TabIndex = 2267
        Me.lblRevisionSep.Text = "Sep"
        '
        'lblBudgetSep
        '
        Me.lblBudgetSep.AutoSize = True
        Me.lblBudgetSep.Location = New System.Drawing.Point(72, 195)
        Me.lblBudgetSep.Name = "lblBudgetSep"
        Me.lblBudgetSep.Size = New System.Drawing.Size(29, 13)
        Me.lblBudgetSep.TabIndex = 2266
        Me.lblBudgetSep.Text = "Sep"
        '
        'lblPinkMayL
        '
        Me.lblPinkMayL.AutoSize = True
        Me.lblPinkMayL.Location = New System.Drawing.Point(72, 159)
        Me.lblPinkMayL.Name = "lblPinkMayL"
        Me.lblPinkMayL.Size = New System.Drawing.Size(30, 13)
        Me.lblPinkMayL.TabIndex = 2265
        Me.lblPinkMayL.Text = "May"
        '
        'lblRevisionMay
        '
        Me.lblRevisionMay.AutoSize = True
        Me.lblRevisionMay.Location = New System.Drawing.Point(72, 134)
        Me.lblRevisionMay.Name = "lblRevisionMay"
        Me.lblRevisionMay.Size = New System.Drawing.Size(30, 13)
        Me.lblRevisionMay.TabIndex = 2264
        Me.lblRevisionMay.Text = "May"
        '
        'lblBudgetMay
        '
        Me.lblBudgetMay.AutoSize = True
        Me.lblBudgetMay.Location = New System.Drawing.Point(72, 110)
        Me.lblBudgetMay.Name = "lblBudgetMay"
        Me.lblBudgetMay.Size = New System.Drawing.Size(30, 13)
        Me.lblBudgetMay.TabIndex = 2263
        Me.lblBudgetMay.Text = "May"
        '
        'lblPinkJanL
        '
        Me.lblPinkJanL.AutoSize = True
        Me.lblPinkJanL.Location = New System.Drawing.Point(72, 74)
        Me.lblPinkJanL.Name = "lblPinkJanL"
        Me.lblPinkJanL.Size = New System.Drawing.Size(26, 13)
        Me.lblPinkJanL.TabIndex = 2262
        Me.lblPinkJanL.Text = "Jan"
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
        'lblPinkDec
        '
        Me.lblPinkDec.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkDec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkDec.Location = New System.Drawing.Point(834, 242)
        Me.lblPinkDec.Name = "lblPinkDec"
        Me.lblPinkDec.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkDec.TabIndex = 84
        '
        'lblPinkNov
        '
        Me.lblPinkNov.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkNov.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkNov.Location = New System.Drawing.Point(592, 242)
        Me.lblPinkNov.Name = "lblPinkNov"
        Me.lblPinkNov.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkNov.TabIndex = 83
        '
        'lblPinkAug
        '
        Me.lblPinkAug.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkAug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkAug.Location = New System.Drawing.Point(834, 159)
        Me.lblPinkAug.Name = "lblPinkAug"
        Me.lblPinkAug.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkAug.TabIndex = 82
        '
        'lblPinkJul
        '
        Me.lblPinkJul.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkJul.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkJul.Location = New System.Drawing.Point(592, 159)
        Me.lblPinkJul.Name = "lblPinkJul"
        Me.lblPinkJul.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkJul.TabIndex = 81
        '
        'lblPinkApr
        '
        Me.lblPinkApr.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkApr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkApr.Location = New System.Drawing.Point(834, 74)
        Me.lblPinkApr.Name = "lblPinkApr"
        Me.lblPinkApr.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkApr.TabIndex = 80
        '
        'lblPinkMar
        '
        Me.lblPinkMar.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkMar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkMar.Location = New System.Drawing.Point(592, 74)
        Me.lblPinkMar.Name = "lblPinkMar"
        Me.lblPinkMar.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkMar.TabIndex = 79
        '
        'lblPinkOct
        '
        Me.lblPinkOct.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkOct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkOct.Location = New System.Drawing.Point(367, 242)
        Me.lblPinkOct.Name = "lblPinkOct"
        Me.lblPinkOct.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkOct.TabIndex = 78
        '
        'lblPinkJun
        '
        Me.lblPinkJun.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkJun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkJun.Location = New System.Drawing.Point(367, 159)
        Me.lblPinkJun.Name = "lblPinkJun"
        Me.lblPinkJun.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkJun.TabIndex = 77
        '
        'lblPinkFeb
        '
        Me.lblPinkFeb.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkFeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkFeb.Location = New System.Drawing.Point(367, 74)
        Me.lblPinkFeb.Name = "lblPinkFeb"
        Me.lblPinkFeb.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkFeb.TabIndex = 76
        '
        'lblPinkSep
        '
        Me.lblPinkSep.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkSep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkSep.Location = New System.Drawing.Point(145, 242)
        Me.lblPinkSep.Name = "lblPinkSep"
        Me.lblPinkSep.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkSep.TabIndex = 75
        '
        'lblPinkJan
        '
        Me.lblPinkJan.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkJan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkJan.Location = New System.Drawing.Point(145, 74)
        Me.lblPinkJan.Name = "lblPinkJan"
        Me.lblPinkJan.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkJan.TabIndex = 74
        '
        'lblPinkMay
        '
        Me.lblPinkMay.BackColor = System.Drawing.SystemColors.Control
        Me.lblPinkMay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPinkMay.Location = New System.Drawing.Point(145, 159)
        Me.lblPinkMay.Name = "lblPinkMay"
        Me.lblPinkMay.Size = New System.Drawing.Size(135, 21)
        Me.lblPinkMay.TabIndex = 73
        '
        'txtRevDec
        '
        Me.txtRevDec.Location = New System.Drawing.Point(834, 218)
        Me.txtRevDec.Name = "txtRevDec"
        Me.txtRevDec.Size = New System.Drawing.Size(135, 21)
        Me.txtRevDec.TabIndex = 32
        '
        'txtBudgetDec
        '
        Me.txtBudgetDec.Location = New System.Drawing.Point(834, 195)
        Me.txtBudgetDec.Name = "txtBudgetDec"
        Me.txtBudgetDec.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetDec.TabIndex = 20
        '
        'txtRevAug
        '
        Me.txtRevAug.Location = New System.Drawing.Point(834, 134)
        Me.txtRevAug.Name = "txtRevAug"
        Me.txtRevAug.Size = New System.Drawing.Size(135, 21)
        Me.txtRevAug.TabIndex = 28
        '
        'txtBudgetAug
        '
        Me.txtBudgetAug.Location = New System.Drawing.Point(834, 110)
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
        Me.txtRevNov.Location = New System.Drawing.Point(592, 218)
        Me.txtRevNov.Name = "txtRevNov"
        Me.txtRevNov.Size = New System.Drawing.Size(135, 21)
        Me.txtRevNov.TabIndex = 31
        '
        'txtBudgetNov
        '
        Me.txtBudgetNov.Location = New System.Drawing.Point(592, 195)
        Me.txtBudgetNov.Name = "txtBudgetNov"
        Me.txtBudgetNov.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetNov.TabIndex = 19
        '
        'txtRevJul
        '
        Me.txtRevJul.Location = New System.Drawing.Point(592, 134)
        Me.txtRevJul.Name = "txtRevJul"
        Me.txtRevJul.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJul.TabIndex = 27
        '
        'txtBudgetJul
        '
        Me.txtBudgetJul.Location = New System.Drawing.Point(592, 110)
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
        Me.txtRevOct.Location = New System.Drawing.Point(367, 218)
        Me.txtRevOct.Name = "txtRevOct"
        Me.txtRevOct.Size = New System.Drawing.Size(135, 21)
        Me.txtRevOct.TabIndex = 30
        '
        'txtBudgetOct
        '
        Me.txtBudgetOct.Location = New System.Drawing.Point(367, 195)
        Me.txtBudgetOct.Name = "txtBudgetOct"
        Me.txtBudgetOct.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetOct.TabIndex = 18
        '
        'txtRevJun
        '
        Me.txtRevJun.Location = New System.Drawing.Point(367, 134)
        Me.txtRevJun.Name = "txtRevJun"
        Me.txtRevJun.Size = New System.Drawing.Size(135, 21)
        Me.txtRevJun.TabIndex = 26
        '
        'txtBudgetJun
        '
        Me.txtBudgetJun.Location = New System.Drawing.Point(367, 110)
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
        Me.txtRevSep.Location = New System.Drawing.Point(145, 218)
        Me.txtRevSep.Name = "txtRevSep"
        Me.txtRevSep.Size = New System.Drawing.Size(135, 21)
        Me.txtRevSep.TabIndex = 29
        '
        'txtBudgetSep
        '
        Me.txtBudgetSep.Location = New System.Drawing.Point(145, 195)
        Me.txtBudgetSep.Name = "txtBudgetSep"
        Me.txtBudgetSep.Size = New System.Drawing.Size(135, 21)
        Me.txtBudgetSep.TabIndex = 17
        '
        'txtRevMay
        '
        Me.txtRevMay.Location = New System.Drawing.Point(145, 134)
        Me.txtRevMay.Name = "txtRevMay"
        Me.txtRevMay.Size = New System.Drawing.Size(135, 21)
        Me.txtRevMay.TabIndex = 25
        '
        'txtBudgetMay
        '
        Me.txtBudgetMay.Location = New System.Drawing.Point(145, 110)
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
        Me.lblRPM3.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM3.TabIndex = 48
        Me.lblRPM3.Text = "RPM"
        '
        'lblRPM2
        '
        Me.lblRPM2.AutoSize = True
        Me.lblRPM2.Location = New System.Drawing.Point(627, 10)
        Me.lblRPM2.Name = "lblRPM2"
        Me.lblRPM2.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM2.TabIndex = 47
        Me.lblRPM2.Text = "RPM"
        '
        'lblRPM1
        '
        Me.lblRPM1.AutoSize = True
        Me.lblRPM1.Location = New System.Drawing.Point(403, 10)
        Me.lblRPM1.Name = "lblRPM1"
        Me.lblRPM1.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM1.TabIndex = 46
        Me.lblRPM1.Text = "RPM"
        '
        'lblRPM
        '
        Me.lblRPM.AutoSize = True
        Me.lblRPM.Location = New System.Drawing.Point(175, 10)
        Me.lblRPM.Name = "lblRPM"
        Me.lblRPM.Size = New System.Drawing.Size(31, 13)
        Me.lblRPM.TabIndex = 45
        Me.lblRPM.Text = "RPM"
        '
        'lblPinks
        '
        Me.lblPinks.AutoSize = True
        Me.lblPinks.Location = New System.Drawing.Point(6, 242)
        Me.lblPinks.Name = "lblPinks"
        Me.lblPinks.Size = New System.Drawing.Size(56, 13)
        Me.lblPinks.TabIndex = 8
        Me.lblPinks.Text = "Pink Slip"
        '
        'lblRevisions
        '
        Me.lblRevisions.AutoSize = True
        Me.lblRevisions.Location = New System.Drawing.Point(6, 218)
        Me.lblRevisions.Name = "lblRevisions"
        Me.lblRevisions.Size = New System.Drawing.Size(55, 13)
        Me.lblRevisions.TabIndex = 7
        Me.lblRevisions.Text = "Revision"
        '
        'lblBudgets
        '
        Me.lblBudgets.AutoSize = True
        Me.lblBudgets.Location = New System.Drawing.Point(6, 195)
        Me.lblBudgets.Name = "lblBudgets"
        Me.lblBudgets.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgets.TabIndex = 6
        Me.lblBudgets.Text = "Budget"
        '
        'lblPinkSlipL
        '
        Me.lblPinkSlipL.AutoSize = True
        Me.lblPinkSlipL.Location = New System.Drawing.Point(6, 159)
        Me.lblPinkSlipL.Name = "lblPinkSlipL"
        Me.lblPinkSlipL.Size = New System.Drawing.Size(56, 13)
        Me.lblPinkSlipL.TabIndex = 5
        Me.lblPinkSlipL.Text = "Pink Slip"
        '
        'lblRevisionL
        '
        Me.lblRevisionL.AutoSize = True
        Me.lblRevisionL.Location = New System.Drawing.Point(6, 134)
        Me.lblRevisionL.Name = "lblRevisionL"
        Me.lblRevisionL.Size = New System.Drawing.Size(55, 13)
        Me.lblRevisionL.TabIndex = 4
        Me.lblRevisionL.Text = "Revision"
        '
        'lblBudgetL
        '
        Me.lblBudgetL.AutoSize = True
        Me.lblBudgetL.Location = New System.Drawing.Point(6, 110)
        Me.lblBudgetL.Name = "lblBudgetL"
        Me.lblBudgetL.Size = New System.Drawing.Size(47, 13)
        Me.lblBudgetL.TabIndex = 3
        Me.lblBudgetL.Text = "Budget"
        '
        'lblPinkSlip
        '
        Me.lblPinkSlip.AutoSize = True
        Me.lblPinkSlip.Location = New System.Drawing.Point(6, 74)
        Me.lblPinkSlip.Name = "lblPinkSlip"
        Me.lblPinkSlip.Size = New System.Drawing.Size(56, 13)
        Me.lblPinkSlip.TabIndex = 2
        Me.lblPinkSlip.Text = "Pink Slip"
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
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Location = New System.Drawing.Point(897, 29)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(36, 20)
        Me.lblStatus.TabIndex = 147
        '
        'grpBudgetYear
        '
        Me.grpBudgetYear.AutoSize = True
        Me.grpBudgetYear.Controls.Add(Me.Label23)
        Me.grpBudgetYear.Controls.Add(Me.txtRemarks)
        Me.grpBudgetYear.Controls.Add(Me.lblRemarks)
        Me.grpBudgetYear.Controls.Add(Me.txtPercentage)
        Me.grpBudgetYear.Controls.Add(Me.Label8)
        Me.grpBudgetYear.Controls.Add(Me.lblPercentage)
        Me.grpBudgetYear.Controls.Add(Me.txtMonth)
        Me.grpBudgetYear.Controls.Add(Me.Label10)
        Me.grpBudgetYear.Controls.Add(Me.lblMonth)
        Me.grpBudgetYear.Controls.Add(Me.txtDay)
        Me.grpBudgetYear.Controls.Add(Me.Label12)
        Me.grpBudgetYear.Controls.Add(Me.lblDay)
        Me.grpBudgetYear.Controls.Add(Me.txtUnit)
        Me.grpBudgetYear.Controls.Add(Me.Label7)
        Me.grpBudgetYear.Controls.Add(Me.lblUnit)
        Me.grpBudgetYear.Controls.Add(Me.txtQty)
        Me.grpBudgetYear.Controls.Add(Me.Label6)
        Me.grpBudgetYear.Controls.Add(Me.lblQty)
        Me.grpBudgetYear.Controls.Add(Me.txtSubDesc)
        Me.grpBudgetYear.Controls.Add(Me.Label1)
        Me.grpBudgetYear.Controls.Add(Me.lblSubDesc)
        Me.grpBudgetYear.Controls.Add(Me.btnDistribute)
        Me.grpBudgetYear.Controls.Add(Me.Label5)
        Me.grpBudgetYear.Controls.Add(Me.txtAmount)
        Me.grpBudgetYear.Controls.Add(Me.Label4)
        Me.grpBudgetYear.Controls.Add(Me.lblTotalPrice)
        Me.grpBudgetYear.Location = New System.Drawing.Point(6, 71)
        Me.grpBudgetYear.Name = "grpBudgetYear"
        Me.grpBudgetYear.Size = New System.Drawing.Size(990, 141)
        Me.grpBudgetYear.TabIndex = 4
        Me.grpBudgetYear.TabStop = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Red
        Me.Label23.Location = New System.Drawing.Point(607, 98)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(12, 13)
        Me.Label23.TabIndex = 226
        Me.Label23.Text = ":"
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(627, 98)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(324, 20)
        Me.txtRemarks.TabIndex = 225
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.ForeColor = System.Drawing.Color.Red
        Me.lblRemarks.Location = New System.Drawing.Point(532, 98)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(62, 13)
        Me.lblRemarks.TabIndex = 224
        Me.lblRemarks.Text = "Remarks "
        '
        'txtPercentage
        '
        Me.txtPercentage.Location = New System.Drawing.Point(627, 71)
        Me.txtPercentage.Name = "txtPercentage"
        Me.txtPercentage.Size = New System.Drawing.Size(135, 21)
        Me.txtPercentage.TabIndex = 209
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(607, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(12, 13)
        Me.Label8.TabIndex = 208
        Me.Label8.Text = ":"
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.Location = New System.Drawing.Point(532, 71)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(19, 13)
        Me.lblPercentage.TabIndex = 207
        Me.lblPercentage.Text = "%"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(627, 44)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(135, 21)
        Me.txtMonth.TabIndex = 206
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(607, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(12, 13)
        Me.Label10.TabIndex = 205
        Me.Label10.Text = ":"
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(532, 44)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(41, 13)
        Me.lblMonth.TabIndex = 204
        Me.lblMonth.Text = "Month"
        '
        'txtDay
        '
        Me.txtDay.Location = New System.Drawing.Point(627, 17)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(135, 21)
        Me.txtDay.TabIndex = 203
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(607, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 13)
        Me.Label12.TabIndex = 202
        Me.Label12.Text = ":"
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(532, 17)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(30, 13)
        Me.lblDay.TabIndex = 201
        Me.lblDay.Text = "Day"
        '
        'txtUnit
        '
        Me.txtUnit.Location = New System.Drawing.Point(151, 44)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(135, 21)
        Me.txtUnit.TabIndex = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(130, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(12, 13)
        Me.Label7.TabIndex = 199
        Me.Label7.Text = ":"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(10, 44)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(29, 13)
        Me.lblUnit.TabIndex = 198
        Me.lblUnit.Text = "Unit"
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(151, 71)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(135, 21)
        Me.txtQty.TabIndex = 197
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(130, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(12, 13)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = ":"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Location = New System.Drawing.Point(10, 71)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(27, 13)
        Me.lblQty.TabIndex = 195
        Me.lblQty.Text = "Qty"
        '
        'txtSubDesc
        '
        Me.txtSubDesc.Location = New System.Drawing.Point(151, 17)
        Me.txtSubDesc.Name = "txtSubDesc"
        Me.txtSubDesc.Size = New System.Drawing.Size(273, 21)
        Me.txtSubDesc.TabIndex = 194
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(130, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 13)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = ":"
        '
        'lblSubDesc
        '
        Me.lblSubDesc.AutoSize = True
        Me.lblSubDesc.Location = New System.Drawing.Point(6, 17)
        Me.lblSubDesc.Name = "lblSubDesc"
        Me.lblSubDesc.Size = New System.Drawing.Size(61, 13)
        Me.lblSubDesc.TabIndex = 192
        Me.lblSubDesc.Text = "Sub Desc"
        '
        'btnDistribute
        '
        Me.btnDistribute.Location = New System.Drawing.Point(329, 98)
        Me.btnDistribute.Name = "btnDistribute"
        Me.btnDistribute.Size = New System.Drawing.Size(165, 23)
        Me.btnDistribute.TabIndex = 7
        Me.btnDistribute.Text = "Distribute to 12 months"
        Me.btnDistribute.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(294, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "IDR"
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(151, 98)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(135, 21)
        Me.txtAmount.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(130, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(12, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = ":"
        '
        'lblTotalPrice
        '
        Me.lblTotalPrice.AutoSize = True
        Me.lblTotalPrice.ForeColor = System.Drawing.Color.Red
        Me.lblTotalPrice.Location = New System.Drawing.Point(10, 98)
        Me.lblTotalPrice.Name = "lblTotalPrice"
        Me.lblTotalPrice.Size = New System.Drawing.Size(67, 13)
        Me.lblTotalPrice.TabIndex = 2
        Me.lblTotalPrice.Text = "Total Price"
        '
        'lblStatusL
        '
        Me.lblStatusL.AutoSize = True
        Me.lblStatusL.ForeColor = System.Drawing.Color.Black
        Me.lblStatusL.Location = New System.Drawing.Point(775, 30)
        Me.lblStatusL.Name = "lblStatusL"
        Me.lblStatusL.Size = New System.Drawing.Size(75, 13)
        Me.lblStatusL.TabIndex = 146
        Me.lblStatusL.Text = "Status        "
        '
        'lblVersionNo
        '
        Me.lblVersionNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblVersionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblVersionNo.Location = New System.Drawing.Point(897, 3)
        Me.lblVersionNo.Name = "lblVersionNo"
        Me.lblVersionNo.Size = New System.Drawing.Size(83, 21)
        Me.lblVersionNo.TabIndex = 143
        '
        'lblVersionNoL
        '
        Me.lblVersionNoL.AutoSize = True
        Me.lblVersionNoL.ForeColor = System.Drawing.Color.Black
        Me.lblVersionNoL.Location = New System.Drawing.Point(775, 4)
        Me.lblVersionNoL.Name = "lblVersionNoL"
        Me.lblVersionNoL.Size = New System.Drawing.Size(73, 13)
        Me.lblVersionNoL.TabIndex = 142
        Me.lblVersionNoL.Text = "Version No "
        '
        'tbView
        '
        Me.tbView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbView.Controls.Add(Me.GroupBox2)
        Me.tbView.Location = New System.Drawing.Point(4, 22)
        Me.tbView.Name = "tbView"
        Me.tbView.Padding = New System.Windows.Forms.Padding(3)
        Me.tbView.Size = New System.Drawing.Size(1009, 694)
        Me.tbView.TabIndex = 1
        Me.tbView.Text = "View"
        Me.tbView.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.dgWorkshopExpendView)
        Me.GroupBox2.Controls.Add(Me.ExtendedPanel1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(853, 492)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(424, 330)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 13)
        Me.Label9.TabIndex = 122
        Me.Label9.Text = "No Record Found !"
        Me.Label9.Visible = False
        '
        'dgWorkshopExpendView
        '
        Me.dgWorkshopExpendView.AllowUserToAddRows = False
        Me.dgWorkshopExpendView.AllowUserToDeleteRows = False
        Me.dgWorkshopExpendView.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgWorkshopExpendView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgWorkshopExpendView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgWorkshopExpendView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgWorkshopExpendView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgWorkshopExpendView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgWorkshopExpendView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWorkshopExpendView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgWorkshopExpendView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ViewBudgetID, Me.ViewBudgetYear, Me.ViewEstateID, Me.ViewEstateCode, Me.COAIdView, Me.ViewCOACode, Me.ViewCOADescp, Me.ViewOldCOACode, Me.ViewSubDesc, Me.ViewQty, Me.ViewCost, Me.ViewDay, Me.ViewMonth, Me.ViewPercentage, Me.ViewBudgetType, Me.ViewBudgetJan, Me.ViewBudgetFeb, Me.ViewBudgetMar, Me.ViewBudgetApr, Me.ViewBudgetMay, Me.ViewBudgetJun, Me.ViewBudgetJul, Me.DataGridViewTextBoxColumn23, Me.ViewBudgetSep, Me.ViewBudgetOct, Me.ViewBudgetNov, Me.ViewBudgetDec, Me.ViewRevJan, Me.ViewRevFeb, Me.ViewRevMar, Me.ViewRevApr, Me.ViewRevMay, Me.ViewRevJun, Me.ViewRevJul, Me.ViewRevAug, Me.ViewRevSep, Me.ViewRevOct, Me.ViewRevNov, Me.ViewRevDec, Me.ViewPinkJan, Me.ViewPinkFeb, Me.ViewPinkMar, Me.ViewPinkApr, Me.ViewPinkMay, Me.ViewPinkJun, Me.ViewPinkJul, Me.ViewPinkAug, Me.ViewPinkSep, Me.ViewPinkOct, Me.ViewPinkNov, Me.ViewPinkDec, Me.ViewPrice, Me.ViewRemarks, Me.ViewBudgetTotal, Me.ViewVersionNo, Me.ViewStatus})
        Me.dgWorkshopExpendView.ContextMenuStrip = Me.cmsWorkshopExpend
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgWorkshopExpendView.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgWorkshopExpendView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgWorkshopExpendView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgWorkshopExpendView.EnableHeadersVisualStyles = False
        Me.dgWorkshopExpendView.GridColor = System.Drawing.Color.Gray
        Me.dgWorkshopExpendView.Location = New System.Drawing.Point(3, 174)
        Me.dgWorkshopExpendView.MultiSelect = False
        Me.dgWorkshopExpendView.Name = "dgWorkshopExpendView"
        Me.dgWorkshopExpendView.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgWorkshopExpendView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgWorkshopExpendView.RowHeadersVisible = False
        Me.dgWorkshopExpendView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgWorkshopExpendView.ShowCellErrors = False
        Me.dgWorkshopExpendView.Size = New System.Drawing.Size(847, 315)
        Me.dgWorkshopExpendView.TabIndex = 121
        Me.dgWorkshopExpendView.TabStop = False
        '
        'ExtendedPanel1
        '
        Me.ExtendedPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExtendedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExtendedPanel1.BorderColor = System.Drawing.Color.Gray
        Me.ExtendedPanel1.CaptionColorOne = System.Drawing.Color.White
        Me.ExtendedPanel1.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExtendedPanel1.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtendedPanel1.CaptionSize = 40
        Me.ExtendedPanel1.CaptionText = "Search Capital Expend"
        Me.ExtendedPanel1.CaptionTextColor = System.Drawing.Color.Black
        Me.ExtendedPanel1.Controls.Add(Me.Label11)
        Me.ExtendedPanel1.Controls.Add(Me.Button1)
        Me.ExtendedPanel1.Controls.Add(Me.Label13)
        Me.ExtendedPanel1.Controls.Add(Me.TextBox1)
        Me.ExtendedPanel1.Controls.Add(Me.Label14)
        Me.ExtendedPanel1.Controls.Add(Me.Label15)
        Me.ExtendedPanel1.Controls.Add(Me.Label22)
        Me.ExtendedPanel1.Controls.Add(Me.Button2)
        Me.ExtendedPanel1.Controls.Add(Me.Button3)
        Me.ExtendedPanel1.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.ExtendedPanel1.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.ExtendedPanel1.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.ExtendedPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExtendedPanel1.ForeColor = System.Drawing.Color.Black
        Me.ExtendedPanel1.Location = New System.Drawing.Point(3, 17)
        Me.ExtendedPanel1.Name = "ExtendedPanel1"
        Me.ExtendedPanel1.Size = New System.Drawing.Size(847, 157)
        Me.ExtendedPanel1.TabIndex = 119
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(108, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 21)
        Me.Label11.TabIndex = 218
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(493, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 26)
        Me.Button1.TabIndex = 140
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(551, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(231, 18)
        Me.Label13.TabIndex = 141
        Me.Label13.Text = "COA Descp"
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(287, 80)
        Me.TextBox1.MaxLength = 50
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(136, 21)
        Me.TextBox1.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(283, 64)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 13)
        Me.Label14.TabIndex = 118
        Me.Label14.Text = "COA Code"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(1, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 13)
        Me.Label15.TabIndex = 54
        Me.Label15.Text = "Search By"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(105, 64)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(77, 13)
        Me.Label22.TabIndex = 16
        Me.Label22.Text = "Budget Year"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(644, 118)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 25)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "View Report"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(501, 118)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 25)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Search"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblNoRecordFound
        '
        Me.lblNoRecordFound.AutoSize = True
        Me.lblNoRecordFound.BackColor = System.Drawing.Color.Transparent
        Me.lblNoRecordFound.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoRecordFound.ForeColor = System.Drawing.Color.Red
        Me.lblNoRecordFound.Location = New System.Drawing.Point(424, 330)
        Me.lblNoRecordFound.Name = "lblNoRecordFound"
        Me.lblNoRecordFound.Size = New System.Drawing.Size(125, 13)
        Me.lblNoRecordFound.TabIndex = 122
        Me.lblNoRecordFound.Text = "No Record Found !"
        Me.lblNoRecordFound.Visible = False
        '
        'dgCapitalExpView
        '
        Me.dgCapitalExpView.AllowUserToAddRows = False
        Me.dgCapitalExpView.AllowUserToDeleteRows = False
        Me.dgCapitalExpView.AllowUserToOrderColumns = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        Me.dgCapitalExpView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgCapitalExpView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgCapitalExpView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgCapitalExpView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgCapitalExpView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCapitalExpView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCapitalExpView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgCapitalExpView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BudgetIDView, Me.BudgetYearView, Me.EstateIdView, Me.EstateCodeView, Me.ViewCOAId, Me.COACodeView, Me.COADescpView, Me.OldCOACodeView, Me.SubDescView, Me.QtyView, Me.CostView, Me.DayView, Me.MonthView, Me.PercentageView, Me.BudgetTypeView, Me.BudgetJanView, Me.BudgetFebView, Me.BudgetMarView, Me.BudgetAprView, Me.BudgetMayView, Me.BudgetJunView, Me.BudgetJulView, Me.BudgetAugView, Me.BudgetSepView, Me.BudgetOctView, Me.BudgetNovView, Me.BudgetDecView, Me.RevJanView, Me.RevFebView, Me.RevMarView, Me.RevAprView, Me.RevMayView, Me.RevJunView, Me.RevJulView, Me.RevAugView, Me.RevSepView, Me.RevOctView, Me.RevNovView, Me.RevDecView, Me.PinkJanview, Me.PinkFebView, Me.PinkMarView, Me.PinkAprView, Me.PinkMayView, Me.PinkJunView, Me.PinkJulView, Me.PinkAugView, Me.PinkSepView, Me.PinkOctView, Me.PinkNovView, Me.PinkDecView, Me.PriceView, Me.RemarksView, Me.BudgetTotalView, Me.VersionNoView, Me.StatusView})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCapitalExpView.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgCapitalExpView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCapitalExpView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgCapitalExpView.EnableHeadersVisualStyles = False
        Me.dgCapitalExpView.GridColor = System.Drawing.Color.Gray
        Me.dgCapitalExpView.Location = New System.Drawing.Point(3, 173)
        Me.dgCapitalExpView.MultiSelect = False
        Me.dgCapitalExpView.Name = "dgCapitalExpView"
        Me.dgCapitalExpView.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.DimGray
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCapitalExpView.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgCapitalExpView.RowHeadersVisible = False
        Me.dgCapitalExpView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCapitalExpView.ShowCellErrors = False
        Me.dgCapitalExpView.Size = New System.Drawing.Size(847, 316)
        Me.dgCapitalExpView.TabIndex = 121
        Me.dgCapitalExpView.TabStop = False
        '
        'BudgetIDView
        '
        Me.BudgetIDView.DataPropertyName = "BudgetID"
        Me.BudgetIDView.HeaderText = "CapitalExpendID"
        Me.BudgetIDView.Name = "BudgetIDView"
        Me.BudgetIDView.ReadOnly = True
        Me.BudgetIDView.Visible = False
        Me.BudgetIDView.Width = 127
        '
        'BudgetYearView
        '
        Me.BudgetYearView.DataPropertyName = "BudgetYear"
        Me.BudgetYearView.HeaderText = "Budget Year"
        Me.BudgetYearView.Name = "BudgetYearView"
        Me.BudgetYearView.ReadOnly = True
        Me.BudgetYearView.Width = 101
        '
        'EstateIdView
        '
        Me.EstateIdView.DataPropertyName = "EstateID"
        Me.EstateIdView.HeaderText = "EstateID"
        Me.EstateIdView.Name = "EstateIdView"
        Me.EstateIdView.ReadOnly = True
        Me.EstateIdView.Visible = False
        Me.EstateIdView.Width = 80
        '
        'EstateCodeView
        '
        Me.EstateCodeView.DataPropertyName = "EstateCode"
        Me.EstateCodeView.HeaderText = "EstateCode"
        Me.EstateCodeView.Name = "EstateCodeView"
        Me.EstateCodeView.ReadOnly = True
        Me.EstateCodeView.Visible = False
        Me.EstateCodeView.Width = 96
        '
        'ViewCOAId
        '
        Me.ViewCOAId.DataPropertyName = "COAId"
        Me.ViewCOAId.HeaderText = "COAId"
        Me.ViewCOAId.Name = "ViewCOAId"
        Me.ViewCOAId.ReadOnly = True
        Me.ViewCOAId.Visible = False
        Me.ViewCOAId.Width = 69
        '
        'COACodeView
        '
        Me.COACodeView.DataPropertyName = "COACode"
        Me.COACodeView.HeaderText = "COA Code"
        Me.COACodeView.Name = "COACodeView"
        Me.COACodeView.ReadOnly = True
        Me.COACodeView.Width = 91
        '
        'COADescpView
        '
        Me.COADescpView.DataPropertyName = "COADescp"
        Me.COADescpView.HeaderText = "COA Descp"
        Me.COADescpView.Name = "COADescpView"
        Me.COADescpView.ReadOnly = True
        Me.COADescpView.Width = 96
        '
        'OldCOACodeView
        '
        Me.OldCOACodeView.DataPropertyName = "OldCOACode "
        Me.OldCOACodeView.HeaderText = "OldCOACode "
        Me.OldCOACodeView.Name = "OldCOACodeView"
        Me.OldCOACodeView.ReadOnly = True
        Me.OldCOACodeView.Visible = False
        Me.OldCOACodeView.Width = 110
        '
        'SubDescView
        '
        Me.SubDescView.DataPropertyName = "SubDesc"
        Me.SubDescView.HeaderText = "Sub Desc"
        Me.SubDescView.Name = "SubDescView"
        Me.SubDescView.ReadOnly = True
        Me.SubDescView.Visible = False
        Me.SubDescView.Width = 85
        '
        'QtyView
        '
        Me.QtyView.DataPropertyName = "Qty"
        Me.QtyView.HeaderText = "Qty"
        Me.QtyView.Name = "QtyView"
        Me.QtyView.ReadOnly = True
        Me.QtyView.Visible = False
        Me.QtyView.Width = 51
        '
        'CostView
        '
        Me.CostView.DataPropertyName = "Cost"
        Me.CostView.HeaderText = "Cost"
        Me.CostView.Name = "CostView"
        Me.CostView.ReadOnly = True
        Me.CostView.Visible = False
        Me.CostView.Width = 57
        '
        'DayView
        '
        Me.DayView.DataPropertyName = "Day"
        Me.DayView.HeaderText = "Day"
        Me.DayView.Name = "DayView"
        Me.DayView.ReadOnly = True
        Me.DayView.Visible = False
        Me.DayView.Width = 54
        '
        'MonthView
        '
        Me.MonthView.DataPropertyName = "Month"
        Me.MonthView.HeaderText = "Month"
        Me.MonthView.Name = "MonthView"
        Me.MonthView.ReadOnly = True
        Me.MonthView.Visible = False
        Me.MonthView.Width = 65
        '
        'PercentageView
        '
        Me.PercentageView.DataPropertyName = "Percentage"
        Me.PercentageView.HeaderText = "Percentage"
        Me.PercentageView.Name = "PercentageView"
        Me.PercentageView.ReadOnly = True
        Me.PercentageView.Visible = False
        Me.PercentageView.Width = 95
        '
        'BudgetTypeView
        '
        Me.BudgetTypeView.DataPropertyName = "BudgetType"
        Me.BudgetTypeView.HeaderText = "BudgetType"
        Me.BudgetTypeView.Name = "BudgetTypeView"
        Me.BudgetTypeView.ReadOnly = True
        Me.BudgetTypeView.Width = 99
        '
        'BudgetJanView
        '
        Me.BudgetJanView.DataPropertyName = "BudgetJan"
        Me.BudgetJanView.HeaderText = "BudgetJan"
        Me.BudgetJanView.Name = "BudgetJanView"
        Me.BudgetJanView.ReadOnly = True
        Me.BudgetJanView.Visible = False
        Me.BudgetJanView.Width = 90
        '
        'BudgetFebView
        '
        Me.BudgetFebView.DataPropertyName = "BudgetFeb"
        Me.BudgetFebView.HeaderText = "BudgetFeb"
        Me.BudgetFebView.Name = "BudgetFebView"
        Me.BudgetFebView.ReadOnly = True
        Me.BudgetFebView.Visible = False
        Me.BudgetFebView.Width = 91
        '
        'BudgetMarView
        '
        Me.BudgetMarView.DataPropertyName = "BudgetMar"
        Me.BudgetMarView.HeaderText = "BudgetMar"
        Me.BudgetMarView.Name = "BudgetMarView"
        Me.BudgetMarView.ReadOnly = True
        Me.BudgetMarView.Visible = False
        Me.BudgetMarView.Width = 92
        '
        'BudgetAprView
        '
        Me.BudgetAprView.DataPropertyName = "BudgetApr"
        Me.BudgetAprView.HeaderText = "BudgetApr"
        Me.BudgetAprView.Name = "BudgetAprView"
        Me.BudgetAprView.ReadOnly = True
        Me.BudgetAprView.Visible = False
        Me.BudgetAprView.Width = 91
        '
        'BudgetMayView
        '
        Me.BudgetMayView.DataPropertyName = "BudgetMay"
        Me.BudgetMayView.HeaderText = "BudgetMay"
        Me.BudgetMayView.Name = "BudgetMayView"
        Me.BudgetMayView.ReadOnly = True
        Me.BudgetMayView.Visible = False
        Me.BudgetMayView.Width = 94
        '
        'BudgetJunView
        '
        Me.BudgetJunView.DataPropertyName = "BudgetJun"
        Me.BudgetJunView.HeaderText = "BudgetJun"
        Me.BudgetJunView.Name = "BudgetJunView"
        Me.BudgetJunView.ReadOnly = True
        Me.BudgetJunView.Visible = False
        Me.BudgetJunView.Width = 90
        '
        'BudgetJulView
        '
        Me.BudgetJulView.DataPropertyName = "BudgetJul"
        Me.BudgetJulView.HeaderText = "BudgetJul"
        Me.BudgetJulView.Name = "BudgetJulView"
        Me.BudgetJulView.ReadOnly = True
        Me.BudgetJulView.Visible = False
        Me.BudgetJulView.Width = 86
        '
        'BudgetAugView
        '
        Me.BudgetAugView.DataPropertyName = "BudgetAug"
        Me.BudgetAugView.HeaderText = "BudgetAug"
        Me.BudgetAugView.Name = "BudgetAugView"
        Me.BudgetAugView.ReadOnly = True
        Me.BudgetAugView.Visible = False
        Me.BudgetAugView.Width = 93
        '
        'BudgetSepView
        '
        Me.BudgetSepView.DataPropertyName = "BudgetSep"
        Me.BudgetSepView.HeaderText = "BudgetSep"
        Me.BudgetSepView.Name = "BudgetSepView"
        Me.BudgetSepView.ReadOnly = True
        Me.BudgetSepView.Visible = False
        Me.BudgetSepView.Width = 93
        '
        'BudgetOctView
        '
        Me.BudgetOctView.DataPropertyName = "BudgetOct"
        Me.BudgetOctView.HeaderText = "BudgetOct"
        Me.BudgetOctView.Name = "BudgetOctView"
        Me.BudgetOctView.ReadOnly = True
        Me.BudgetOctView.Visible = False
        Me.BudgetOctView.Width = 90
        '
        'BudgetNovView
        '
        Me.BudgetNovView.DataPropertyName = "BudgetNov"
        Me.BudgetNovView.HeaderText = "BudgetNov"
        Me.BudgetNovView.Name = "BudgetNovView"
        Me.BudgetNovView.ReadOnly = True
        Me.BudgetNovView.Visible = False
        Me.BudgetNovView.Width = 93
        '
        'BudgetDecView
        '
        Me.BudgetDecView.DataPropertyName = "BudgetDec"
        Me.BudgetDecView.HeaderText = "BudgetDec"
        Me.BudgetDecView.Name = "BudgetDecView"
        Me.BudgetDecView.ReadOnly = True
        Me.BudgetDecView.Visible = False
        Me.BudgetDecView.Width = 93
        '
        'RevJanView
        '
        Me.RevJanView.DataPropertyName = "RevJan"
        Me.RevJanView.HeaderText = "Revision Jan"
        Me.RevJanView.Name = "RevJanView"
        Me.RevJanView.ReadOnly = True
        Me.RevJanView.Visible = False
        Me.RevJanView.Width = 102
        '
        'RevFebView
        '
        Me.RevFebView.DataPropertyName = "RevFeb"
        Me.RevFebView.HeaderText = "Revision Feb"
        Me.RevFebView.Name = "RevFebView"
        Me.RevFebView.ReadOnly = True
        Me.RevFebView.Visible = False
        Me.RevFebView.Width = 103
        '
        'RevMarView
        '
        Me.RevMarView.DataPropertyName = "RevMar"
        Me.RevMarView.HeaderText = "Revision Mar"
        Me.RevMarView.Name = "RevMarView"
        Me.RevMarView.ReadOnly = True
        Me.RevMarView.Visible = False
        Me.RevMarView.Width = 104
        '
        'RevAprView
        '
        Me.RevAprView.DataPropertyName = "RevApr"
        Me.RevAprView.HeaderText = "Revision Apr"
        Me.RevAprView.Name = "RevAprView"
        Me.RevAprView.ReadOnly = True
        Me.RevAprView.Visible = False
        Me.RevAprView.Width = 103
        '
        'RevMayView
        '
        Me.RevMayView.DataPropertyName = "RevMay"
        Me.RevMayView.HeaderText = "Revision May"
        Me.RevMayView.Name = "RevMayView"
        Me.RevMayView.ReadOnly = True
        Me.RevMayView.Visible = False
        Me.RevMayView.Width = 106
        '
        'RevJunView
        '
        Me.RevJunView.DataPropertyName = "RevJun"
        Me.RevJunView.HeaderText = "RevisionJun"
        Me.RevJunView.Name = "RevJunView"
        Me.RevJunView.ReadOnly = True
        Me.RevJunView.Visible = False
        Me.RevJunView.Width = 98
        '
        'RevJulView
        '
        Me.RevJulView.DataPropertyName = "RevJul"
        Me.RevJulView.HeaderText = "Revision Jul"
        Me.RevJulView.Name = "RevJulView"
        Me.RevJulView.ReadOnly = True
        Me.RevJulView.Visible = False
        Me.RevJulView.Width = 98
        '
        'RevAugView
        '
        Me.RevAugView.DataPropertyName = "RevAug"
        Me.RevAugView.HeaderText = "Revision Aug"
        Me.RevAugView.Name = "RevAugView"
        Me.RevAugView.ReadOnly = True
        Me.RevAugView.Visible = False
        Me.RevAugView.Width = 105
        '
        'RevSepView
        '
        Me.RevSepView.DataPropertyName = "RevSep"
        Me.RevSepView.HeaderText = "Revision Sep"
        Me.RevSepView.Name = "RevSepView"
        Me.RevSepView.ReadOnly = True
        Me.RevSepView.Visible = False
        Me.RevSepView.Width = 105
        '
        'RevOctView
        '
        Me.RevOctView.DataPropertyName = "RevOct"
        Me.RevOctView.HeaderText = "Revision Oct"
        Me.RevOctView.Name = "RevOctView"
        Me.RevOctView.ReadOnly = True
        Me.RevOctView.Visible = False
        Me.RevOctView.Width = 102
        '
        'RevNovView
        '
        Me.RevNovView.DataPropertyName = "RevNov"
        Me.RevNovView.HeaderText = "Revision Nov"
        Me.RevNovView.Name = "RevNovView"
        Me.RevNovView.ReadOnly = True
        Me.RevNovView.Visible = False
        Me.RevNovView.Width = 105
        '
        'RevDecView
        '
        Me.RevDecView.DataPropertyName = "RevDec"
        Me.RevDecView.HeaderText = "Revision Dec"
        Me.RevDecView.Name = "RevDecView"
        Me.RevDecView.ReadOnly = True
        Me.RevDecView.Visible = False
        Me.RevDecView.Width = 105
        '
        'PinkJanview
        '
        Me.PinkJanview.DataPropertyName = "PinkJan"
        Me.PinkJanview.HeaderText = "PinkSlip Jan"
        Me.PinkJanview.Name = "PinkJanview"
        Me.PinkJanview.ReadOnly = True
        Me.PinkJanview.Visible = False
        Me.PinkJanview.Width = 99
        '
        'PinkFebView
        '
        Me.PinkFebView.DataPropertyName = "PinkFeb"
        Me.PinkFebView.HeaderText = "PinkSlip Feb"
        Me.PinkFebView.Name = "PinkFebView"
        Me.PinkFebView.ReadOnly = True
        Me.PinkFebView.Visible = False
        '
        'PinkMarView
        '
        Me.PinkMarView.DataPropertyName = "PinkMar"
        Me.PinkMarView.HeaderText = "PinkSlip Mar"
        Me.PinkMarView.Name = "PinkMarView"
        Me.PinkMarView.ReadOnly = True
        Me.PinkMarView.Visible = False
        Me.PinkMarView.Width = 101
        '
        'PinkAprView
        '
        Me.PinkAprView.DataPropertyName = "PinkApr"
        Me.PinkAprView.HeaderText = "PinkSlip Apr"
        Me.PinkAprView.Name = "PinkAprView"
        Me.PinkAprView.ReadOnly = True
        Me.PinkAprView.Visible = False
        '
        'PinkMayView
        '
        Me.PinkMayView.DataPropertyName = "PinkMay"
        Me.PinkMayView.HeaderText = "PinkSlip May"
        Me.PinkMayView.Name = "PinkMayView"
        Me.PinkMayView.ReadOnly = True
        Me.PinkMayView.Visible = False
        Me.PinkMayView.Width = 103
        '
        'PinkJunView
        '
        Me.PinkJunView.DataPropertyName = "PinkJun"
        Me.PinkJunView.HeaderText = "PinkSlip Jun"
        Me.PinkJunView.Name = "PinkJunView"
        Me.PinkJunView.ReadOnly = True
        Me.PinkJunView.Visible = False
        Me.PinkJunView.Width = 99
        '
        'PinkJulView
        '
        Me.PinkJulView.DataPropertyName = "PinkJul"
        Me.PinkJulView.HeaderText = "PinkSlip Jul"
        Me.PinkJulView.Name = "PinkJulView"
        Me.PinkJulView.ReadOnly = True
        Me.PinkJulView.Visible = False
        Me.PinkJulView.Width = 95
        '
        'PinkAugView
        '
        Me.PinkAugView.DataPropertyName = "PinkAug"
        Me.PinkAugView.HeaderText = "PinkSlip Aug"
        Me.PinkAugView.Name = "PinkAugView"
        Me.PinkAugView.ReadOnly = True
        Me.PinkAugView.Visible = False
        Me.PinkAugView.Width = 102
        '
        'PinkSepView
        '
        Me.PinkSepView.DataPropertyName = "PinkSep"
        Me.PinkSepView.HeaderText = "PinkSlip Sep"
        Me.PinkSepView.Name = "PinkSepView"
        Me.PinkSepView.ReadOnly = True
        Me.PinkSepView.Visible = False
        Me.PinkSepView.Width = 102
        '
        'PinkOctView
        '
        Me.PinkOctView.DataPropertyName = "PinkOct"
        Me.PinkOctView.HeaderText = "PinkSlip Oct"
        Me.PinkOctView.Name = "PinkOctView"
        Me.PinkOctView.ReadOnly = True
        Me.PinkOctView.Visible = False
        Me.PinkOctView.Width = 99
        '
        'PinkNovView
        '
        Me.PinkNovView.DataPropertyName = "PinkNov"
        Me.PinkNovView.HeaderText = "PinkSlip Nov"
        Me.PinkNovView.Name = "PinkNovView"
        Me.PinkNovView.ReadOnly = True
        Me.PinkNovView.Visible = False
        Me.PinkNovView.Width = 102
        '
        'PinkDecView
        '
        Me.PinkDecView.DataPropertyName = "PinkDec"
        Me.PinkDecView.HeaderText = "PinkSlipDec"
        Me.PinkDecView.Name = "PinkDecView"
        Me.PinkDecView.ReadOnly = True
        Me.PinkDecView.Visible = False
        Me.PinkDecView.Width = 98
        '
        'PriceView
        '
        Me.PriceView.DataPropertyName = "Price"
        Me.PriceView.HeaderText = "Amount"
        Me.PriceView.Name = "PriceView"
        Me.PriceView.ReadOnly = True
        Me.PriceView.Visible = False
        Me.PriceView.Width = 75
        '
        'RemarksView
        '
        Me.RemarksView.DataPropertyName = "Remarks"
        Me.RemarksView.HeaderText = "Remarks"
        Me.RemarksView.Name = "RemarksView"
        Me.RemarksView.ReadOnly = True
        Me.RemarksView.Visible = False
        Me.RemarksView.Width = 82
        '
        'BudgetTotalView
        '
        Me.BudgetTotalView.DataPropertyName = "BudgetTotal"
        Me.BudgetTotalView.HeaderText = "BudgetTotal"
        Me.BudgetTotalView.Name = "BudgetTotalView"
        Me.BudgetTotalView.ReadOnly = True
        Me.BudgetTotalView.Visible = False
        Me.BudgetTotalView.Width = 99
        '
        'VersionNoView
        '
        Me.VersionNoView.DataPropertyName = "VersionNo"
        Me.VersionNoView.HeaderText = "Version No"
        Me.VersionNoView.Name = "VersionNoView"
        Me.VersionNoView.ReadOnly = True
        Me.VersionNoView.Width = 93
        '
        'StatusView
        '
        Me.StatusView.DataPropertyName = "Status"
        Me.StatusView.HeaderText = "Status"
        Me.StatusView.Name = "StatusView"
        Me.StatusView.ReadOnly = True
        Me.StatusView.Width = 67
        '
        'pnlCapitalExpSearch
        '
        Me.pnlCapitalExpSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCapitalExpSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pnlCapitalExpSearch.BorderColor = System.Drawing.Color.Gray
        Me.pnlCapitalExpSearch.CaptionColorOne = System.Drawing.Color.White
        Me.pnlCapitalExpSearch.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pnlCapitalExpSearch.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCapitalExpSearch.CaptionSize = 40
        Me.pnlCapitalExpSearch.CaptionText = "Search Capital Expend"
        Me.pnlCapitalExpSearch.CaptionTextColor = System.Drawing.Color.Black
        Me.pnlCapitalExpSearch.Controls.Add(Me.lblBudgetYearView)
        Me.pnlCapitalExpSearch.Controls.Add(Me.btnSearchCOACode)
        Me.pnlCapitalExpSearch.Controls.Add(Me.lblCOADescpView)
        Me.pnlCapitalExpSearch.Controls.Add(Me.txtCOACodeView)
        Me.pnlCapitalExpSearch.Controls.Add(Me.lblCoaCodeV)
        Me.pnlCapitalExpSearch.Controls.Add(Me.lblsearchCategory)
        Me.pnlCapitalExpSearch.Controls.Add(Me.lblBudgetYearV)
        Me.pnlCapitalExpSearch.Controls.Add(Me.btnviewReport)
        Me.pnlCapitalExpSearch.Controls.Add(Me.btnSearch)
        Me.pnlCapitalExpSearch.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.pnlCapitalExpSearch.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.pnlCapitalExpSearch.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.pnlCapitalExpSearch.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCapitalExpSearch.ForeColor = System.Drawing.Color.Black
        Me.pnlCapitalExpSearch.Location = New System.Drawing.Point(3, 16)
        Me.pnlCapitalExpSearch.Name = "pnlCapitalExpSearch"
        Me.pnlCapitalExpSearch.Size = New System.Drawing.Size(847, 157)
        Me.pnlCapitalExpSearch.TabIndex = 119
        '
        'lblBudgetYearView
        '
        Me.lblBudgetYearView.BackColor = System.Drawing.SystemColors.Control
        Me.lblBudgetYearView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBudgetYearView.Location = New System.Drawing.Point(108, 80)
        Me.lblBudgetYearView.Name = "lblBudgetYearView"
        Me.lblBudgetYearView.Size = New System.Drawing.Size(136, 21)
        Me.lblBudgetYearView.TabIndex = 218
        '
        'btnSearchCOACode
        '
        Me.btnSearchCOACode.BackgroundImage = Global.BSP.My.Resources.Resources.My_documents_32
        Me.btnSearchCOACode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSearchCOACode.FlatAppearance.BorderSize = 0
        Me.btnSearchCOACode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnSearchCOACode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchCOACode.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnSearchCOACode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSearchCOACode.Location = New System.Drawing.Point(493, 73)
        Me.btnSearchCOACode.Name = "btnSearchCOACode"
        Me.btnSearchCOACode.Size = New System.Drawing.Size(35, 26)
        Me.btnSearchCOACode.TabIndex = 140
        Me.btnSearchCOACode.TabStop = False
        Me.btnSearchCOACode.UseVisualStyleBackColor = True
        '
        'lblCOADescpView
        '
        Me.lblCOADescpView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCOADescpView.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCOADescpView.Location = New System.Drawing.Point(551, 83)
        Me.lblCOADescpView.Name = "lblCOADescpView"
        Me.lblCOADescpView.Size = New System.Drawing.Size(231, 18)
        Me.lblCOADescpView.TabIndex = 141
        Me.lblCOADescpView.Text = "COA Descp"
        '
        'txtCOACodeView
        '
        Me.txtCOACodeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCOACodeView.Location = New System.Drawing.Point(287, 80)
        Me.txtCOACodeView.MaxLength = 50
        Me.txtCOACodeView.Name = "txtCOACodeView"
        Me.txtCOACodeView.Size = New System.Drawing.Size(136, 20)
        Me.txtCOACodeView.TabIndex = 0
        '
        'lblCoaCodeV
        '
        Me.lblCoaCodeV.AutoSize = True
        Me.lblCoaCodeV.ForeColor = System.Drawing.Color.Black
        Me.lblCoaCodeV.Location = New System.Drawing.Point(283, 64)
        Me.lblCoaCodeV.Name = "lblCoaCodeV"
        Me.lblCoaCodeV.Size = New System.Drawing.Size(57, 13)
        Me.lblCoaCodeV.TabIndex = 118
        Me.lblCoaCodeV.Text = "COA Code"
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
        Me.lblBudgetYearV.Size = New System.Drawing.Size(66, 13)
        Me.lblBudgetYearV.TabIndex = 16
        Me.lblBudgetYearV.Text = "Budget Year"
        '
        'btnviewReport
        '
        Me.btnviewReport.BackgroundImage = CType(resources.GetObject("btnviewReport.BackgroundImage"), System.Drawing.Image)
        Me.btnviewReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewReport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnviewReport.ForeColor = System.Drawing.Color.Black
        Me.btnviewReport.Image = CType(resources.GetObject("btnviewReport.Image"), System.Drawing.Image)
        Me.btnviewReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnviewReport.Location = New System.Drawing.Point(644, 118)
        Me.btnviewReport.Name = "btnviewReport"
        Me.btnviewReport.Size = New System.Drawing.Size(147, 25)
        Me.btnviewReport.TabIndex = 2
        Me.btnviewReport.Text = "View Report"
        Me.btnviewReport.UseVisualStyleBackColor = True
        Me.btnviewReport.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.BackgroundImage = CType(resources.GetObject("btnSearch.BackgroundImage"), System.Drawing.Image)
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(501, 118)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(136, 25)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmsWorkshopExpend
        '
        Me.cmsWorkshopExpend.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditUpdateToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsWorkshopExpend.Name = "cmsITNIn"
        Me.cmsWorkshopExpend.Size = New System.Drawing.Size(160, 70)
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
        'ViewBudgetID
        '
        Me.ViewBudgetID.DataPropertyName = "BudgetID"
        Me.ViewBudgetID.HeaderText = "BudgetID"
        Me.ViewBudgetID.Name = "ViewBudgetID"
        Me.ViewBudgetID.ReadOnly = True
        Me.ViewBudgetID.Visible = False
        Me.ViewBudgetID.Width = 85
        '
        'ViewBudgetYear
        '
        Me.ViewBudgetYear.DataPropertyName = "BudgetYear"
        Me.ViewBudgetYear.HeaderText = "Budget Year"
        Me.ViewBudgetYear.Name = "ViewBudgetYear"
        Me.ViewBudgetYear.ReadOnly = True
        Me.ViewBudgetYear.Width = 101
        '
        'ViewEstateID
        '
        Me.ViewEstateID.DataPropertyName = "EstateID"
        Me.ViewEstateID.HeaderText = "EstateID"
        Me.ViewEstateID.Name = "ViewEstateID"
        Me.ViewEstateID.ReadOnly = True
        Me.ViewEstateID.Visible = False
        Me.ViewEstateID.Width = 80
        '
        'ViewEstateCode
        '
        Me.ViewEstateCode.DataPropertyName = "EstateCode"
        Me.ViewEstateCode.HeaderText = "EstateCode"
        Me.ViewEstateCode.Name = "ViewEstateCode"
        Me.ViewEstateCode.ReadOnly = True
        Me.ViewEstateCode.Visible = False
        Me.ViewEstateCode.Width = 96
        '
        'COAIdView
        '
        Me.COAIdView.DataPropertyName = "COAId"
        Me.COAIdView.HeaderText = "COAId"
        Me.COAIdView.Name = "COAIdView"
        Me.COAIdView.ReadOnly = True
        Me.COAIdView.Visible = False
        Me.COAIdView.Width = 69
        '
        'ViewCOACode
        '
        Me.ViewCOACode.DataPropertyName = "COACode"
        Me.ViewCOACode.HeaderText = "COA Code"
        Me.ViewCOACode.Name = "ViewCOACode"
        Me.ViewCOACode.ReadOnly = True
        Me.ViewCOACode.Width = 91
        '
        'ViewCOADescp
        '
        Me.ViewCOADescp.DataPropertyName = "COADescp"
        Me.ViewCOADescp.HeaderText = "COA Descp"
        Me.ViewCOADescp.Name = "ViewCOADescp"
        Me.ViewCOADescp.ReadOnly = True
        Me.ViewCOADescp.Width = 96
        '
        'ViewOldCOACode
        '
        Me.ViewOldCOACode.DataPropertyName = "OldCOACode "
        Me.ViewOldCOACode.HeaderText = "OldCOACode "
        Me.ViewOldCOACode.Name = "ViewOldCOACode"
        Me.ViewOldCOACode.ReadOnly = True
        Me.ViewOldCOACode.Visible = False
        Me.ViewOldCOACode.Width = 110
        '
        'ViewSubDesc
        '
        Me.ViewSubDesc.DataPropertyName = "SubDesc"
        Me.ViewSubDesc.HeaderText = "Sub Desc"
        Me.ViewSubDesc.Name = "ViewSubDesc"
        Me.ViewSubDesc.ReadOnly = True
        Me.ViewSubDesc.Visible = False
        Me.ViewSubDesc.Width = 85
        '
        'ViewQty
        '
        Me.ViewQty.DataPropertyName = "Qty"
        Me.ViewQty.HeaderText = "Qty"
        Me.ViewQty.Name = "ViewQty"
        Me.ViewQty.ReadOnly = True
        Me.ViewQty.Visible = False
        Me.ViewQty.Width = 51
        '
        'ViewCost
        '
        Me.ViewCost.DataPropertyName = "Cost"
        Me.ViewCost.HeaderText = "Cost"
        Me.ViewCost.Name = "ViewCost"
        Me.ViewCost.ReadOnly = True
        Me.ViewCost.Visible = False
        Me.ViewCost.Width = 57
        '
        'ViewDay
        '
        Me.ViewDay.DataPropertyName = "Day"
        Me.ViewDay.HeaderText = "Day"
        Me.ViewDay.Name = "ViewDay"
        Me.ViewDay.ReadOnly = True
        Me.ViewDay.Visible = False
        Me.ViewDay.Width = 54
        '
        'ViewMonth
        '
        Me.ViewMonth.DataPropertyName = "Month"
        Me.ViewMonth.HeaderText = "Month"
        Me.ViewMonth.Name = "ViewMonth"
        Me.ViewMonth.ReadOnly = True
        Me.ViewMonth.Visible = False
        Me.ViewMonth.Width = 65
        '
        'ViewPercentage
        '
        Me.ViewPercentage.DataPropertyName = "Percentage"
        Me.ViewPercentage.HeaderText = "Percentage"
        Me.ViewPercentage.Name = "ViewPercentage"
        Me.ViewPercentage.ReadOnly = True
        Me.ViewPercentage.Visible = False
        Me.ViewPercentage.Width = 95
        '
        'ViewBudgetType
        '
        Me.ViewBudgetType.DataPropertyName = "BudgetType"
        Me.ViewBudgetType.HeaderText = "BudgetType"
        Me.ViewBudgetType.Name = "ViewBudgetType"
        Me.ViewBudgetType.ReadOnly = True
        Me.ViewBudgetType.Width = 99
        '
        'ViewBudgetJan
        '
        Me.ViewBudgetJan.DataPropertyName = "BudgetJan"
        Me.ViewBudgetJan.HeaderText = "BudgetJan"
        Me.ViewBudgetJan.Name = "ViewBudgetJan"
        Me.ViewBudgetJan.ReadOnly = True
        Me.ViewBudgetJan.Visible = False
        Me.ViewBudgetJan.Width = 90
        '
        'ViewBudgetFeb
        '
        Me.ViewBudgetFeb.DataPropertyName = "BudgetFeb"
        Me.ViewBudgetFeb.HeaderText = "BudgetFeb"
        Me.ViewBudgetFeb.Name = "ViewBudgetFeb"
        Me.ViewBudgetFeb.ReadOnly = True
        Me.ViewBudgetFeb.Visible = False
        Me.ViewBudgetFeb.Width = 91
        '
        'ViewBudgetMar
        '
        Me.ViewBudgetMar.DataPropertyName = "BudgetMar"
        Me.ViewBudgetMar.HeaderText = "BudgetMar"
        Me.ViewBudgetMar.Name = "ViewBudgetMar"
        Me.ViewBudgetMar.ReadOnly = True
        Me.ViewBudgetMar.Visible = False
        Me.ViewBudgetMar.Width = 92
        '
        'ViewBudgetApr
        '
        Me.ViewBudgetApr.DataPropertyName = "BudgetApr"
        Me.ViewBudgetApr.HeaderText = "BudgetApr"
        Me.ViewBudgetApr.Name = "ViewBudgetApr"
        Me.ViewBudgetApr.ReadOnly = True
        Me.ViewBudgetApr.Visible = False
        Me.ViewBudgetApr.Width = 91
        '
        'ViewBudgetMay
        '
        Me.ViewBudgetMay.DataPropertyName = "BudgetMay"
        Me.ViewBudgetMay.HeaderText = "BudgetMay"
        Me.ViewBudgetMay.Name = "ViewBudgetMay"
        Me.ViewBudgetMay.ReadOnly = True
        Me.ViewBudgetMay.Visible = False
        Me.ViewBudgetMay.Width = 94
        '
        'ViewBudgetJun
        '
        Me.ViewBudgetJun.DataPropertyName = "BudgetJun"
        Me.ViewBudgetJun.HeaderText = "BudgetJun"
        Me.ViewBudgetJun.Name = "ViewBudgetJun"
        Me.ViewBudgetJun.ReadOnly = True
        Me.ViewBudgetJun.Visible = False
        Me.ViewBudgetJun.Width = 90
        '
        'ViewBudgetJul
        '
        Me.ViewBudgetJul.DataPropertyName = "BudgetJul"
        Me.ViewBudgetJul.HeaderText = "BudgetJul"
        Me.ViewBudgetJul.Name = "ViewBudgetJul"
        Me.ViewBudgetJul.ReadOnly = True
        Me.ViewBudgetJul.Visible = False
        Me.ViewBudgetJul.Width = 86
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "BudgetAug"
        Me.DataGridViewTextBoxColumn23.HeaderText = "BudgetAug"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.ReadOnly = True
        Me.DataGridViewTextBoxColumn23.Visible = False
        Me.DataGridViewTextBoxColumn23.Width = 93
        '
        'ViewBudgetSep
        '
        Me.ViewBudgetSep.DataPropertyName = "BudgetSep"
        Me.ViewBudgetSep.HeaderText = "BudgetSep"
        Me.ViewBudgetSep.Name = "ViewBudgetSep"
        Me.ViewBudgetSep.ReadOnly = True
        Me.ViewBudgetSep.Visible = False
        Me.ViewBudgetSep.Width = 93
        '
        'ViewBudgetOct
        '
        Me.ViewBudgetOct.DataPropertyName = "BudgetOct"
        Me.ViewBudgetOct.HeaderText = "BudgetOct"
        Me.ViewBudgetOct.Name = "ViewBudgetOct"
        Me.ViewBudgetOct.ReadOnly = True
        Me.ViewBudgetOct.Visible = False
        Me.ViewBudgetOct.Width = 90
        '
        'ViewBudgetNov
        '
        Me.ViewBudgetNov.DataPropertyName = "BudgetNov"
        Me.ViewBudgetNov.HeaderText = "BudgetNov"
        Me.ViewBudgetNov.Name = "ViewBudgetNov"
        Me.ViewBudgetNov.ReadOnly = True
        Me.ViewBudgetNov.Visible = False
        Me.ViewBudgetNov.Width = 93
        '
        'ViewBudgetDec
        '
        Me.ViewBudgetDec.DataPropertyName = "BudgetDec"
        Me.ViewBudgetDec.HeaderText = "BudgetDec"
        Me.ViewBudgetDec.Name = "ViewBudgetDec"
        Me.ViewBudgetDec.ReadOnly = True
        Me.ViewBudgetDec.Visible = False
        Me.ViewBudgetDec.Width = 93
        '
        'ViewRevJan
        '
        Me.ViewRevJan.DataPropertyName = "RevJan"
        Me.ViewRevJan.HeaderText = "Revision Jan"
        Me.ViewRevJan.Name = "ViewRevJan"
        Me.ViewRevJan.ReadOnly = True
        Me.ViewRevJan.Visible = False
        Me.ViewRevJan.Width = 102
        '
        'ViewRevFeb
        '
        Me.ViewRevFeb.DataPropertyName = "RevFeb"
        Me.ViewRevFeb.HeaderText = "Revision Feb"
        Me.ViewRevFeb.Name = "ViewRevFeb"
        Me.ViewRevFeb.ReadOnly = True
        Me.ViewRevFeb.Visible = False
        Me.ViewRevFeb.Width = 103
        '
        'ViewRevMar
        '
        Me.ViewRevMar.DataPropertyName = "RevMar"
        Me.ViewRevMar.HeaderText = "Revision Mar"
        Me.ViewRevMar.Name = "ViewRevMar"
        Me.ViewRevMar.ReadOnly = True
        Me.ViewRevMar.Visible = False
        Me.ViewRevMar.Width = 104
        '
        'ViewRevApr
        '
        Me.ViewRevApr.DataPropertyName = "RevApr"
        Me.ViewRevApr.HeaderText = "Revision Apr"
        Me.ViewRevApr.Name = "ViewRevApr"
        Me.ViewRevApr.ReadOnly = True
        Me.ViewRevApr.Visible = False
        Me.ViewRevApr.Width = 103
        '
        'ViewRevMay
        '
        Me.ViewRevMay.DataPropertyName = "RevMay"
        Me.ViewRevMay.HeaderText = "Revision May"
        Me.ViewRevMay.Name = "ViewRevMay"
        Me.ViewRevMay.ReadOnly = True
        Me.ViewRevMay.Visible = False
        Me.ViewRevMay.Width = 106
        '
        'ViewRevJun
        '
        Me.ViewRevJun.DataPropertyName = "RevJun"
        Me.ViewRevJun.HeaderText = "RevisionJun"
        Me.ViewRevJun.Name = "ViewRevJun"
        Me.ViewRevJun.ReadOnly = True
        Me.ViewRevJun.Visible = False
        Me.ViewRevJun.Width = 98
        '
        'ViewRevJul
        '
        Me.ViewRevJul.DataPropertyName = "RevJul"
        Me.ViewRevJul.HeaderText = "Revision Jul"
        Me.ViewRevJul.Name = "ViewRevJul"
        Me.ViewRevJul.ReadOnly = True
        Me.ViewRevJul.Visible = False
        Me.ViewRevJul.Width = 98
        '
        'ViewRevAug
        '
        Me.ViewRevAug.DataPropertyName = "RevAug"
        Me.ViewRevAug.HeaderText = "Revision Aug"
        Me.ViewRevAug.Name = "ViewRevAug"
        Me.ViewRevAug.ReadOnly = True
        Me.ViewRevAug.Visible = False
        Me.ViewRevAug.Width = 105
        '
        'ViewRevSep
        '
        Me.ViewRevSep.DataPropertyName = "RevSep"
        Me.ViewRevSep.HeaderText = "Revision Sep"
        Me.ViewRevSep.Name = "ViewRevSep"
        Me.ViewRevSep.ReadOnly = True
        Me.ViewRevSep.Visible = False
        Me.ViewRevSep.Width = 105
        '
        'ViewRevOct
        '
        Me.ViewRevOct.DataPropertyName = "RevOct"
        Me.ViewRevOct.HeaderText = "Revision Oct"
        Me.ViewRevOct.Name = "ViewRevOct"
        Me.ViewRevOct.ReadOnly = True
        Me.ViewRevOct.Visible = False
        Me.ViewRevOct.Width = 102
        '
        'ViewRevNov
        '
        Me.ViewRevNov.DataPropertyName = "RevNov"
        Me.ViewRevNov.HeaderText = "Revision Nov"
        Me.ViewRevNov.Name = "ViewRevNov"
        Me.ViewRevNov.ReadOnly = True
        Me.ViewRevNov.Visible = False
        Me.ViewRevNov.Width = 105
        '
        'ViewRevDec
        '
        Me.ViewRevDec.DataPropertyName = "RevDec"
        Me.ViewRevDec.HeaderText = "Revision Dec"
        Me.ViewRevDec.Name = "ViewRevDec"
        Me.ViewRevDec.ReadOnly = True
        Me.ViewRevDec.Visible = False
        Me.ViewRevDec.Width = 105
        '
        'ViewPinkJan
        '
        Me.ViewPinkJan.DataPropertyName = "PinkJan"
        Me.ViewPinkJan.HeaderText = "PinkSlip Jan"
        Me.ViewPinkJan.Name = "ViewPinkJan"
        Me.ViewPinkJan.ReadOnly = True
        Me.ViewPinkJan.Visible = False
        Me.ViewPinkJan.Width = 99
        '
        'ViewPinkFeb
        '
        Me.ViewPinkFeb.DataPropertyName = "PinkFeb"
        Me.ViewPinkFeb.HeaderText = "PinkSlip Feb"
        Me.ViewPinkFeb.Name = "ViewPinkFeb"
        Me.ViewPinkFeb.ReadOnly = True
        Me.ViewPinkFeb.Visible = False
        '
        'ViewPinkMar
        '
        Me.ViewPinkMar.DataPropertyName = "PinkMar"
        Me.ViewPinkMar.HeaderText = "PinkSlip Mar"
        Me.ViewPinkMar.Name = "ViewPinkMar"
        Me.ViewPinkMar.ReadOnly = True
        Me.ViewPinkMar.Visible = False
        Me.ViewPinkMar.Width = 101
        '
        'ViewPinkApr
        '
        Me.ViewPinkApr.DataPropertyName = "PinkApr"
        Me.ViewPinkApr.HeaderText = "PinkSlip Apr"
        Me.ViewPinkApr.Name = "ViewPinkApr"
        Me.ViewPinkApr.ReadOnly = True
        Me.ViewPinkApr.Visible = False
        '
        'ViewPinkMay
        '
        Me.ViewPinkMay.DataPropertyName = "PinkMay"
        Me.ViewPinkMay.HeaderText = "PinkSlip May"
        Me.ViewPinkMay.Name = "ViewPinkMay"
        Me.ViewPinkMay.ReadOnly = True
        Me.ViewPinkMay.Visible = False
        Me.ViewPinkMay.Width = 103
        '
        'ViewPinkJun
        '
        Me.ViewPinkJun.DataPropertyName = "PinkJun"
        Me.ViewPinkJun.HeaderText = "PinkSlip Jun"
        Me.ViewPinkJun.Name = "ViewPinkJun"
        Me.ViewPinkJun.ReadOnly = True
        Me.ViewPinkJun.Visible = False
        Me.ViewPinkJun.Width = 99
        '
        'ViewPinkJul
        '
        Me.ViewPinkJul.DataPropertyName = "PinkJul"
        Me.ViewPinkJul.HeaderText = "PinkSlip Jul"
        Me.ViewPinkJul.Name = "ViewPinkJul"
        Me.ViewPinkJul.ReadOnly = True
        Me.ViewPinkJul.Visible = False
        Me.ViewPinkJul.Width = 95
        '
        'ViewPinkAug
        '
        Me.ViewPinkAug.DataPropertyName = "PinkAug"
        Me.ViewPinkAug.HeaderText = "PinkSlip Aug"
        Me.ViewPinkAug.Name = "ViewPinkAug"
        Me.ViewPinkAug.ReadOnly = True
        Me.ViewPinkAug.Visible = False
        Me.ViewPinkAug.Width = 102
        '
        'ViewPinkSep
        '
        Me.ViewPinkSep.DataPropertyName = "PinkSep"
        Me.ViewPinkSep.HeaderText = "PinkSlip Sep"
        Me.ViewPinkSep.Name = "ViewPinkSep"
        Me.ViewPinkSep.ReadOnly = True
        Me.ViewPinkSep.Visible = False
        Me.ViewPinkSep.Width = 102
        '
        'ViewPinkOct
        '
        Me.ViewPinkOct.DataPropertyName = "PinkOct"
        Me.ViewPinkOct.HeaderText = "PinkSlip Oct"
        Me.ViewPinkOct.Name = "ViewPinkOct"
        Me.ViewPinkOct.ReadOnly = True
        Me.ViewPinkOct.Visible = False
        Me.ViewPinkOct.Width = 99
        '
        'ViewPinkNov
        '
        Me.ViewPinkNov.DataPropertyName = "PinkNov"
        Me.ViewPinkNov.HeaderText = "PinkSlip Nov"
        Me.ViewPinkNov.Name = "ViewPinkNov"
        Me.ViewPinkNov.ReadOnly = True
        Me.ViewPinkNov.Visible = False
        Me.ViewPinkNov.Width = 102
        '
        'ViewPinkDec
        '
        Me.ViewPinkDec.DataPropertyName = "PinkDec"
        Me.ViewPinkDec.HeaderText = "PinkSlipDec"
        Me.ViewPinkDec.Name = "ViewPinkDec"
        Me.ViewPinkDec.ReadOnly = True
        Me.ViewPinkDec.Visible = False
        Me.ViewPinkDec.Width = 98
        '
        'ViewPrice
        '
        Me.ViewPrice.DataPropertyName = "Price"
        Me.ViewPrice.HeaderText = "Amount"
        Me.ViewPrice.Name = "ViewPrice"
        Me.ViewPrice.ReadOnly = True
        Me.ViewPrice.Visible = False
        Me.ViewPrice.Width = 75
        '
        'ViewRemarks
        '
        Me.ViewRemarks.DataPropertyName = "Remarks"
        Me.ViewRemarks.HeaderText = "Remarks"
        Me.ViewRemarks.Name = "ViewRemarks"
        Me.ViewRemarks.ReadOnly = True
        Me.ViewRemarks.Visible = False
        Me.ViewRemarks.Width = 82
        '
        'ViewBudgetTotal
        '
        Me.ViewBudgetTotal.DataPropertyName = "BudgetTotal"
        Me.ViewBudgetTotal.HeaderText = "BudgetTotal"
        Me.ViewBudgetTotal.Name = "ViewBudgetTotal"
        Me.ViewBudgetTotal.ReadOnly = True
        Me.ViewBudgetTotal.Visible = False
        Me.ViewBudgetTotal.Width = 99
        '
        'ViewVersionNo
        '
        Me.ViewVersionNo.DataPropertyName = "VersionNo"
        Me.ViewVersionNo.HeaderText = "Version No"
        Me.ViewVersionNo.Name = "ViewVersionNo"
        Me.ViewVersionNo.ReadOnly = True
        Me.ViewVersionNo.Width = 93
        '
        'ViewStatus
        '
        Me.ViewStatus.DataPropertyName = "Status"
        Me.ViewStatus.HeaderText = "Status"
        Me.ViewStatus.Name = "ViewStatus"
        Me.ViewStatus.ReadOnly = True
        Me.ViewStatus.Width = 67
        '
        'WorkshopExpenditureFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1076, 698)
        Me.Controls.Add(Me.tbWorkshopExpenditure)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WorkshopExpenditureFrm"
        Me.Text = "k"
        Me.tbWorkshopExpenditure.ResumeLayout(False)
        Me.tbWorkshop.ResumeLayout(False)
        Me.tbWorkshop.PerformLayout()
        Me.GrpGrid.ResumeLayout(False)
        CType(Me.dgWorkshopExpand, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMonths.ResumeLayout(False)
        Me.grpMonths.PerformLayout()
        Me.grpBudgetYear.ResumeLayout(False)
        Me.grpBudgetYear.PerformLayout()
        Me.tbView.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgWorkshopExpendView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ExtendedPanel1.ResumeLayout(False)
        Me.ExtendedPanel1.PerformLayout()
        CType(Me.dgCapitalExpView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCapitalExpSearch.ResumeLayout(False)
        Me.pnlCapitalExpSearch.PerformLayout()
        Me.cmsWorkshopExpend.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbWorkshopExpenditure As System.Windows.Forms.TabControl
    Friend WithEvents tbWorkshop As System.Windows.Forms.TabPage
    Friend WithEvents tbView As System.Windows.Forms.TabPage
    Friend WithEvents grpBudgetYear As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtPercentage As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMonth As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents txtUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtSubDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblSubDesc As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblStatusL As System.Windows.Forms.Label
    Friend WithEvents lblVersionNo As System.Windows.Forms.Label
    Friend WithEvents lblVersionNoL As System.Windows.Forms.Label
    Friend WithEvents btnDistribute As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
    Friend WithEvents grpMonths As System.Windows.Forms.GroupBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblPinkDecL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionDec As System.Windows.Forms.Label
    Friend WithEvents lblBudgetDec As System.Windows.Forms.Label
    Friend WithEvents lblPinkAugL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionAug As System.Windows.Forms.Label
    Friend WithEvents lblBudgetAug As System.Windows.Forms.Label
    Friend WithEvents lblPinkAprL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionApr As System.Windows.Forms.Label
    Friend WithEvents lblBudgetApr As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblPinkNovL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionNov As System.Windows.Forms.Label
    Friend WithEvents lblBudgetNov As System.Windows.Forms.Label
    Friend WithEvents lblPinkJulL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJul As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJul As System.Windows.Forms.Label
    Friend WithEvents lblPinkMarL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionMar As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMar As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblPinkOctL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionOct As System.Windows.Forms.Label
    Friend WithEvents lblBudgetOct As System.Windows.Forms.Label
    Friend WithEvents lblPinkJunL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJun As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJun As System.Windows.Forms.Label
    Friend WithEvents lblPinkFebL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionFeb As System.Windows.Forms.Label
    Friend WithEvents lblBudgetFeb As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents lblPinkSepL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionSep As System.Windows.Forms.Label
    Friend WithEvents lblBudgetSep As System.Windows.Forms.Label
    Friend WithEvents lblPinkMayL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionMay As System.Windows.Forms.Label
    Friend WithEvents lblBudgetMay As System.Windows.Forms.Label
    Friend WithEvents lblPinkJanL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionJan As System.Windows.Forms.Label
    Friend WithEvents lblBudgetJan As System.Windows.Forms.Label
    Friend WithEvents lblPinkDec As System.Windows.Forms.Label
    Friend WithEvents lblPinkNov As System.Windows.Forms.Label
    Friend WithEvents lblPinkAug As System.Windows.Forms.Label
    Friend WithEvents lblPinkJul As System.Windows.Forms.Label
    Friend WithEvents lblPinkApr As System.Windows.Forms.Label
    Friend WithEvents lblPinkMar As System.Windows.Forms.Label
    Friend WithEvents lblPinkOct As System.Windows.Forms.Label
    Friend WithEvents lblPinkJun As System.Windows.Forms.Label
    Friend WithEvents lblPinkFeb As System.Windows.Forms.Label
    Friend WithEvents lblPinkSep As System.Windows.Forms.Label
    Friend WithEvents lblPinkJan As System.Windows.Forms.Label
    Friend WithEvents lblPinkMay As System.Windows.Forms.Label
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
    Friend WithEvents lblPinks As System.Windows.Forms.Label
    Friend WithEvents lblRevisions As System.Windows.Forms.Label
    Friend WithEvents lblBudgets As System.Windows.Forms.Label
    Friend WithEvents lblPinkSlipL As System.Windows.Forms.Label
    Friend WithEvents lblRevisionL As System.Windows.Forms.Label
    Friend WithEvents lblBudgetL As System.Windows.Forms.Label
    Friend WithEvents lblPinkSlip As System.Windows.Forms.Label
    Friend WithEvents lblRevision As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GrpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents dgWorkshopExpand As System.Windows.Forms.DataGridView
    Friend WithEvents lblBudgetTotal As System.Windows.Forms.Label
    Friend WithEvents lblBudgetTotalL As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblOldAccCode As System.Windows.Forms.Label
    Friend WithEvents lblOldCOACode As System.Windows.Forms.Label
    Friend WithEvents lblCOADescp As System.Windows.Forms.Label
    Friend WithEvents btnSearchAccountCode As System.Windows.Forms.Button
    Friend WithEvents txtCOACode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYear As System.Windows.Forms.Label
    Friend WithEvents lblCOA As System.Windows.Forms.Label
    Friend WithEvents lblBudgetyearL As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgWorkshopExpendView As System.Windows.Forms.DataGridView
    Friend WithEvents ExtendedPanel1 As Stepi.UI.ExtendedPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lblNoRecordFound As System.Windows.Forms.Label
    Friend WithEvents dgCapitalExpView As System.Windows.Forms.DataGridView
    Friend WithEvents BudgetIDView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYearView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateIdView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateCodeView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewCOAId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COACodeView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescpView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldCOACodeView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubDescView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QtyView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CostView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MonthView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PercentageView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetTypeView As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents RevMarView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAprView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevMayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJunView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevJulView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevAugView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevSepView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevOctView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevNovView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevDecView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJanview As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkFebView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkMarView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkAprView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkMayView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJunView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkJulView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkAugView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkSepView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkOctView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkNovView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PinkDecView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemarksView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetTotalView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNoView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlCapitalExpSearch As Stepi.UI.ExtendedPanel
    Friend WithEvents lblBudgetYearView As System.Windows.Forms.Label
    Friend WithEvents btnSearchCOACode As System.Windows.Forms.Button
    Friend WithEvents lblCOADescpView As System.Windows.Forms.Label
    Friend WithEvents txtCOACodeView As System.Windows.Forms.TextBox
    Friend WithEvents lblCoaCodeV As System.Windows.Forms.Label
    Friend WithEvents lblsearchCategory As System.Windows.Forms.Label
    Friend WithEvents lblBudgetYearV As System.Windows.Forms.Label
    Friend WithEvents btnviewReport As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents BudgetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Percentage As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BudgetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VersionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsWorkshopExpend As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewBudgetID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetYear As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewEstateID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewEstateCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COAIdView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewCOADescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewOldCOACode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewSubDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewDay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRevDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkJan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkFeb As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkMar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkApr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkMay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkJun As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkJul As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkAug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkSep As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkOct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkNov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPinkDec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewBudgetTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewVersionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViewStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class

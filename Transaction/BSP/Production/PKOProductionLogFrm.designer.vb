<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PKOProductionLogFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PKOProductionLogFrm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tcPKOroductionLog = New System.Windows.Forms.TabControl()
        Me.tpPKOProductionSave = New System.Windows.Forms.TabPage()
        Me.panCPO = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnDeleteAll = New System.Windows.Forms.Button()
        Me.btnSaveAll = New System.Windows.Forms.Button()
        Me.btnResetAll = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.dtPKOProductionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtMeterFrom = New System.Windows.Forms.TextBox()
        Me.lblMeterFrom = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.lblMeterTo = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtMeterTo = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tcPKOLog = New System.Windows.Forms.TabControl()
        Me.tbProduction = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gbShiftInformation = New System.Windows.Forms.GroupBox()
        Me.txtStartTime = New System.Windows.Forms.TextBox()
        Me.txtStopTime = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtTotalShiftKernelProcessed = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblKernelProcessedtoday = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtShiftHours = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvPKOLogShiftDetails = New System.Windows.Forms.DataGridView()
        Me.dgShift = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShiftAssistant = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShiftMandore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShiftStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShiftStopTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShiftHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgShiftKernelProcessed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsShiftInformation = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteShiftInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnResetShift = New System.Windows.Forms.Button()
        Me.btnAddShift = New System.Windows.Forms.Button()
        Me.ddlShift = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.lblYearTodateHrs = New System.Windows.Forms.Label()
        Me.lblProMonthToDateHrs = New System.Windows.Forms.Label()
        Me.lblTotalHoursHrs = New System.Windows.Forms.Label()
        Me.txtYearTodateHrs = New System.Windows.Forms.TextBox()
        Me.txtMonthTodateHrs = New System.Windows.Forms.TextBox()
        Me.txtTotalHours = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblYearTodate = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblProMonthToDate = New System.Windows.Forms.Label()
        Me.lblTotalHours = New System.Windows.Forms.Label()
        Me.txtKernelProcessed = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMandor = New System.Windows.Forms.TextBox()
        Me.txtAssistant = New System.Windows.Forms.TextBox()
        Me.lblKernelProcessed = New System.Windows.Forms.Label()
        Me.lblStopTime = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblMandore = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblAssistant = New System.Windows.Forms.Label()
        Me.tbProcessLog = New System.Windows.Forms.TabPage()
        Me.gplblProcessedKernel = New System.Windows.Forms.GroupBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtKernelProcessedYear = New System.Windows.Forms.TextBox()
        Me.txtKernelProcessedMonth = New System.Windows.Forms.TextBox()
        Me.txtKernelProcessedToday = New System.Windows.Forms.TextBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.lblKernelReceived = New System.Windows.Forms.Label()
        Me.lblKernelToday = New System.Windows.Forms.Label()
        Me.lblKernelMonthToDate = New System.Windows.Forms.Label()
        Me.lblKernelYearToDate = New System.Windows.Forms.Label()
        Me.gpReceivedKernel = New System.Windows.Forms.GroupBox()
        Me.ddlLoadingLocationKerRecd = New System.Windows.Forms.ComboBox()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtTotalReceivedQtyKerRec = New System.Windows.Forms.TextBox()
        Me.dgvReceivedKernel = New System.Windows.Forms.DataGridView()
        Me.dgMeLoadingLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeLoadingLocationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeQtyKerRecd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMePKOKERReceivedID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclKerRecdMonthTodate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclKerRecdYearToDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsKernelReceived = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteKernelReceived = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtYearTodateRecKer = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtqtyMtKerRecd = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblTotalReceivedQty = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblQtyMt = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblYearTodateMt = New System.Windows.Forms.Label()
        Me.lbllocation = New System.Windows.Forms.Label()
        Me.txtTodateMtRecKer = New System.Windows.Forms.TextBox()
        Me.lblTodate = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtVarianceBudget = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblVariance = New System.Windows.Forms.Label()
        Me.txtmonthtodatBudget = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblMonthToDate = New System.Windows.Forms.Label()
        Me.txtBudget = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblBudget = New System.Windows.Forms.Label()
        Me.lblTons = New System.Windows.Forms.Label()
        Me.txtBFQty = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblBFQty = New System.Windows.Forms.Label()
        Me.tbProcessingInfo = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.lblOERPercentage = New System.Windows.Forms.Label()
        Me.txtKERYear = New System.Windows.Forms.TextBox()
        Me.txtKERMonth = New System.Windows.Forms.TextBox()
        Me.txtKERToday = New System.Windows.Forms.TextBox()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.lblKER = New System.Windows.Forms.Label()
        Me.txtKerneltoday = New System.Windows.Forms.TextBox()
        Me.lblKernelProcess = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.lblLossOnKernel = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.txtLossOnKernelToday = New System.Windows.Forms.TextBox()
        Me.txtKernelMonth = New System.Windows.Forms.TextBox()
        Me.txtLossOnKernelMonth = New System.Windows.Forms.TextBox()
        Me.txtKernelYear = New System.Windows.Forms.TextBox()
        Me.lblThroughputMonthKgHr = New System.Windows.Forms.Label()
        Me.txtLossOnKernelYear = New System.Windows.Forms.TextBox()
        Me.lblThroughputKgHr = New System.Windows.Forms.Label()
        Me.lblKernelYearTon = New System.Windows.Forms.Label()
        Me.lblThroughputYearKgHr = New System.Windows.Forms.Label()
        Me.lblLossOnKernelYearTon = New System.Windows.Forms.Label()
        Me.txtThroughputYear = New System.Windows.Forms.TextBox()
        Me.lblKernelProcessTon = New System.Windows.Forms.Label()
        Me.txtThroughputMonthTodate = New System.Windows.Forms.TextBox()
        Me.lblLossOnKernelTon = New System.Windows.Forms.Label()
        Me.txtThroughput = New System.Windows.Forms.TextBox()
        Me.lblKernelMonthTon = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.lblLossOnKernelMonthTon = New System.Windows.Forms.Label()
        Me.lblThroughput = New System.Windows.Forms.Label()
        Me.lblProcessingToday = New System.Windows.Forms.Label()
        Me.lblEffectiveMonthHrs = New System.Windows.Forms.Label()
        Me.lblProcessingMonthToDate = New System.Windows.Forms.Label()
        Me.lblEffectiveProcessingHrs = New System.Windows.Forms.Label()
        Me.lblProcessingYearToDate = New System.Windows.Forms.Label()
        Me.lblEffectiveYearHrs = New System.Windows.Forms.Label()
        Me.txtLogRemarks = New System.Windows.Forms.TextBox()
        Me.txtEffectiveProcessingHoursYear = New System.Windows.Forms.TextBox()
        Me.lblRemarks = New System.Windows.Forms.Label()
        Me.txtEffectiveProcessingHoursMonth = New System.Windows.Forms.TextBox()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.txtEffectiveProcessingHoursToday = New System.Windows.Forms.TextBox()
        Me.lblPKOProduction = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.lblEffectiveProcessing = New System.Windows.Forms.Label()
        Me.lblMechanicalBreakDown = New System.Windows.Forms.Label()
        Me.lblTotalMonthHrs = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblTotalBreakDownHrs = New System.Windows.Forms.Label()
        Me.txtPKOProductionToday = New System.Windows.Forms.TextBox()
        Me.lblTotalYearsHrs = New System.Windows.Forms.Label()
        Me.txtMechanicalBreakDownToday = New System.Windows.Forms.TextBox()
        Me.txtTotalBreakDownYear = New System.Windows.Forms.TextBox()
        Me.txtPKOProductionMonthTodate = New System.Windows.Forms.TextBox()
        Me.txtTotalBreakDownMonth = New System.Windows.Forms.TextBox()
        Me.txtMechanicalBreakDownMonth = New System.Windows.Forms.TextBox()
        Me.txtTotalBreakDownToday = New System.Windows.Forms.TextBox()
        Me.txtPKOProductionYear = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.txtMechanicalBreakDownYear = New System.Windows.Forms.TextBox()
        Me.lblTotalBreakDown = New System.Windows.Forms.Label()
        Me.lblPKOProductionYearTon = New System.Windows.Forms.Label()
        Me.lblProcessingMonthHrs = New System.Windows.Forms.Label()
        Me.lblMechanicalYearHrs = New System.Windows.Forms.Label()
        Me.lblProcessingHrs = New System.Windows.Forms.Label()
        Me.lblPKOProductionTon = New System.Windows.Forms.Label()
        Me.lblProcessingYearHrs = New System.Windows.Forms.Label()
        Me.lblMechanicalHrs = New System.Windows.Forms.Label()
        Me.txtProcessingBreakDownYear = New System.Windows.Forms.TextBox()
        Me.lblPKOProductionMonthTon = New System.Windows.Forms.Label()
        Me.txtProcessingBreakDownMonth = New System.Windows.Forms.TextBox()
        Me.lblMechanicalMonthHrs = New System.Windows.Forms.Label()
        Me.txtProcessingBreakDownToday = New System.Windows.Forms.TextBox()
        Me.lblElectricalBreakDown = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.lblProcessingBreakDown = New System.Windows.Forms.Label()
        Me.txtElectricalBreakDownToday = New System.Windows.Forms.TextBox()
        Me.lblElectricalMonthHrs = New System.Windows.Forms.Label()
        Me.txtElectricalBreakDownMonth = New System.Windows.Forms.TextBox()
        Me.lblElectricalHrs = New System.Windows.Forms.Label()
        Me.txtElectricalBreakDownYear = New System.Windows.Forms.TextBox()
        Me.lblElectricalYearHrs = New System.Windows.Forms.Label()
        Me.tbPressInfo = New System.Windows.Forms.TabPage()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblUtiliStage2MonthPer = New System.Windows.Forms.Label()
        Me.lblUtilisStage1MonthPer = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblUtilisationStage1 = New System.Windows.Forms.Label()
        Me.lblAvgPressStage1 = New System.Windows.Forms.Label()
        Me.lblTotalPHStage1 = New System.Windows.Forms.Label()
        Me.lblAvgPressStage2Kg = New System.Windows.Forms.Label()
        Me.lblAvgPressStage1MonthKg = New System.Windows.Forms.Label()
        Me.lblAvgPressStage2MonthKg = New System.Windows.Forms.Label()
        Me.lblAvgPressStage1YrKg = New System.Windows.Forms.Label()
        Me.lblAvgPressStage2YrKg = New System.Windows.Forms.Label()
        Me.lblUtilisationStage2 = New System.Windows.Forms.Label()
        Me.lblAvgPressStage2 = New System.Windows.Forms.Label()
        Me.txtutilstage2yeartodate = New System.Windows.Forms.TextBox()
        Me.txtutilstage2monthtodate = New System.Windows.Forms.TextBox()
        Me.txtutilstage2 = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.txtutilstage1yeartodate = New System.Windows.Forms.TextBox()
        Me.txtutilstage1monthtodate = New System.Windows.Forms.TextBox()
        Me.txtutilstage1today = New System.Windows.Forms.TextBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.lblUtilisation = New System.Windows.Forms.Label()
        Me.txtAPTStage2yeartodate = New System.Windows.Forms.TextBox()
        Me.txtAPTstage2monthtodae = New System.Windows.Forms.TextBox()
        Me.txtAPTstage2today = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.lblAvgPressStage1Kg = New System.Windows.Forms.Label()
        Me.txtAPTstage1yeartodate = New System.Windows.Forms.TextBox()
        Me.txtAPHstage1monthtodate = New System.Windows.Forms.TextBox()
        Me.txtAPTstage1today = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.lblAveragePressThroughput = New System.Windows.Forms.Label()
        Me.lblPressYear = New System.Windows.Forms.Label()
        Me.lblPressMonth = New System.Windows.Forms.Label()
        Me.lblPressToday = New System.Windows.Forms.Label()
        Me.txtStage2yearTodate = New System.Windows.Forms.TextBox()
        Me.txtTPHYearTodateStage1 = New System.Windows.Forms.TextBox()
        Me.txtStage2monthTodate = New System.Windows.Forms.TextBox()
        Me.txtTPHMonthTodateStage1 = New System.Windows.Forms.TextBox()
        Me.txtStage2TodayTPH = New System.Windows.Forms.TextBox()
        Me.txtTPHTodaystage1 = New System.Windows.Forms.TextBox()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.lblTotalPHStage2 = New System.Windows.Forms.Label()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.lblTotalPressHours = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblPressNoDescp = New System.Windows.Forms.Label()
        Me.btnPressNoLookup = New System.Windows.Forms.Button()
        Me.ddlStage = New System.Windows.Forms.ComboBox()
        Me.lblTotalHoursPressHr = New System.Windows.Forms.Label()
        Me.ddlScrewStatus = New System.Windows.Forms.ComboBox()
        Me.txtCapacity = New System.Windows.Forms.TextBox()
        Me.lblCapacity = New System.Windows.Forms.Label()
        Me.lblCakeProcessTons = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.lblAvgpresstpTons = New System.Windows.Forms.Label()
        Me.txtCakeProcess = New System.Windows.Forms.TextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.lblCakeProcess = New System.Windows.Forms.Label()
        Me.txtAvgPressThroughput = New System.Windows.Forms.TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.lvlAvgpresstp = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.lblScrewStatus = New System.Windows.Forms.Label()
        Me.txtOPHrs = New System.Windows.Forms.TextBox()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.lblOPHrs = New System.Windows.Forms.Label()
        Me.btnResetPressinfo = New System.Windows.Forms.Button()
        Me.btnAddPressInfo = New System.Windows.Forms.Button()
        Me.txtTotalHoursPress = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.lblTotalHoursPress = New System.Windows.Forms.Label()
        Me.dgPressInfo = New System.Windows.Forms.DataGridView()
        Me.dgMeStage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMePressNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMePressNoDescp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeMeterFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeMeterTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeOPHrs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeProductionLogPressID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeScrewAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeMachineID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgMeScrewStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsPressInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletePressInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtPressNo = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.lblPressNo = New System.Windows.Forms.Label()
        Me.txtAgeOfScrew = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.lblAgeOfscrew = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.lblStage = New System.Windows.Forms.Label()
        Me.tpPKOProductionView = New System.Windows.Forms.TabPage()
        Me.dgvPKOProductionLogView = New System.Windows.Forms.DataGridView()
        Me.dgclProductionlogDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KernelProcessedACT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTotalBD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclEffectiveProcessingHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclPKOProductionLogID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclCropYieldID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclTotalHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLossOfKernel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLossOfKernelMTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclLossOfKernelYTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclMechanicalBD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclMechanicalBDMTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclMechanicalBDYTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclElectricalBD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclElectricalBDMTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclElectricalBDYTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProcessingBD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProcessingBDMTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclProcessingBDYTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgclRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsPKOProductionLog = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtendedPanel1 = New Stepi.UI.ExtendedPanel()
        Me.dtpPKOProdLogDateSearch = New System.Windows.Forms.DateTimePicker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.lblSearchby = New System.Windows.Forms.Label()
        Me.Label166 = New System.Windows.Forms.Label()
        Me.chkPKOLogDate = New System.Windows.Forms.CheckBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tcPKOroductionLog.SuspendLayout()
        Me.tpPKOProductionSave.SuspendLayout()
        Me.panCPO.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tcPKOLog.SuspendLayout()
        Me.tbProduction.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbShiftInformation.SuspendLayout()
        CType(Me.dgvPKOLogShiftDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsShiftInformation.SuspendLayout()
        Me.tbProcessLog.SuspendLayout()
        Me.gplblProcessedKernel.SuspendLayout()
        Me.gpReceivedKernel.SuspendLayout()
        CType(Me.dgvReceivedKernel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsKernelReceived.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tbProcessingInfo.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.tbPressInfo.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgPressInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPressInfo.SuspendLayout()
        Me.tpPKOProductionView.SuspendLayout()
        CType(Me.dgvPKOProductionLogView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPKOProductionLog.SuspendLayout()
        Me.ExtendedPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tcPKOroductionLog
        '
        Me.tcPKOroductionLog.Controls.Add(Me.tpPKOProductionSave)
        Me.tcPKOroductionLog.Controls.Add(Me.tpPKOProductionView)
        Me.tcPKOroductionLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcPKOroductionLog.Location = New System.Drawing.Point(0, 0)
        Me.tcPKOroductionLog.Name = "tcPKOroductionLog"
        Me.tcPKOroductionLog.SelectedIndex = 0
        Me.tcPKOroductionLog.Size = New System.Drawing.Size(829, 631)
        Me.tcPKOroductionLog.TabIndex = 4
        '
        'tpPKOProductionSave
        '
        Me.tpPKOProductionSave.AutoScroll = True
        Me.tpPKOProductionSave.BackgroundImage = CType(resources.GetObject("tpPKOProductionSave.BackgroundImage"), System.Drawing.Image)
        Me.tpPKOProductionSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpPKOProductionSave.Controls.Add(Me.panCPO)
        Me.tpPKOProductionSave.Location = New System.Drawing.Point(4, 22)
        Me.tpPKOProductionSave.Name = "tpPKOProductionSave"
        Me.tpPKOProductionSave.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPKOProductionSave.Size = New System.Drawing.Size(821, 605)
        Me.tpPKOProductionSave.TabIndex = 0
        Me.tpPKOProductionSave.Text = "PKO Production Log"
        Me.tpPKOProductionSave.UseVisualStyleBackColor = True
        '
        'panCPO
        '
        Me.panCPO.AutoScroll = True
        Me.panCPO.BackColor = System.Drawing.Color.Transparent
        Me.panCPO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.panCPO.Controls.Add(Me.GroupBox2)
        Me.panCPO.Controls.Add(Me.GroupBox9)
        Me.panCPO.Controls.Add(Me.GroupBox1)
        Me.panCPO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panCPO.Location = New System.Drawing.Point(3, 3)
        Me.panCPO.Name = "panCPO"
        Me.panCPO.Size = New System.Drawing.Size(815, 599)
        Me.panCPO.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.btnDeleteAll)
        Me.GroupBox2.Controls.Add(Me.btnSaveAll)
        Me.GroupBox2.Controls.Add(Me.btnResetAll)
        Me.GroupBox2.Controls.Add(Me.btnClose)
        Me.GroupBox2.Location = New System.Drawing.Point(20, 543)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(775, 42)
        Me.GroupBox2.TabIndex = 400
        Me.GroupBox2.TabStop = False
        '
        'btnDeleteAll
        '
        Me.btnDeleteAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnDeleteAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDeleteAll.Image = Global.BSP.My.Resources.Resources.icon_delete
        Me.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeleteAll.Location = New System.Drawing.Point(648, 13)
        Me.btnDeleteAll.Name = "btnDeleteAll"
        Me.btnDeleteAll.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteAll.TabIndex = 522
        Me.btnDeleteAll.Text = "Delete All"
        Me.btnDeleteAll.UseVisualStyleBackColor = True
        Me.btnDeleteAll.Visible = False
        '
        'btnSaveAll
        '
        Me.btnSaveAll.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSaveAll.Image = CType(resources.GetObject("btnSaveAll.Image"), System.Drawing.Image)
        Me.btnSaveAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveAll.Location = New System.Drawing.Point(271, 13)
        Me.btnSaveAll.Name = "btnSaveAll"
        Me.btnSaveAll.Size = New System.Drawing.Size(117, 25)
        Me.btnSaveAll.TabIndex = 401
        Me.btnSaveAll.Text = "Save All"
        Me.btnSaveAll.UseVisualStyleBackColor = True
        '
        'btnResetAll
        '
        Me.btnResetAll.BackgroundImage = CType(resources.GetObject("btnResetAll.BackgroundImage"), System.Drawing.Image)
        Me.btnResetAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetAll.Image = CType(resources.GetObject("btnResetAll.Image"), System.Drawing.Image)
        Me.btnResetAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetAll.Location = New System.Drawing.Point(398, 13)
        Me.btnResetAll.Name = "btnResetAll"
        Me.btnResetAll.Size = New System.Drawing.Size(117, 25)
        Me.btnResetAll.TabIndex = 402
        Me.btnResetAll.Text = "Reset All"
        Me.btnResetAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(525, 13)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(117, 25)
        Me.btnClose.TabIndex = 403
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox9.Controls.Add(Me.Label99)
        Me.GroupBox9.Controls.Add(Me.dtPKOProductionDate)
        Me.GroupBox9.Controls.Add(Me.lblDate)
        Me.GroupBox9.Controls.Add(Me.txtMeterFrom)
        Me.GroupBox9.Controls.Add(Me.lblMeterFrom)
        Me.GroupBox9.Controls.Add(Me.Label69)
        Me.GroupBox9.Controls.Add(Me.lblMeterTo)
        Me.GroupBox9.Controls.Add(Me.Label70)
        Me.GroupBox9.Controls.Add(Me.txtMeterTo)
        Me.GroupBox9.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(787, 41)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.ForeColor = System.Drawing.Color.Red
        Me.Label99.Location = New System.Drawing.Point(70, 16)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(11, 13)
        Me.Label99.TabIndex = 172
        Me.Label99.Text = ":"
        '
        'dtPKOProductionDate
        '
        Me.dtPKOProductionDate.CustomFormat = "dd/MM/yyyy"
        Me.dtPKOProductionDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtPKOProductionDate.Location = New System.Drawing.Point(87, 13)
        Me.dtPKOProductionDate.Name = "dtPKOProductionDate"
        Me.dtPKOProductionDate.Size = New System.Drawing.Size(172, 21)
        Me.dtPKOProductionDate.TabIndex = 1
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.Red
        Me.lblDate.Location = New System.Drawing.Point(23, 16)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(34, 13)
        Me.lblDate.TabIndex = 170
        Me.lblDate.Text = "Date"
        '
        'txtMeterFrom
        '
        Me.txtMeterFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMeterFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeterFrom.Location = New System.Drawing.Point(418, 16)
        Me.txtMeterFrom.MaxLength = 18
        Me.txtMeterFrom.Name = "txtMeterFrom"
        Me.txtMeterFrom.Size = New System.Drawing.Size(110, 21)
        Me.txtMeterFrom.TabIndex = 304
        Me.txtMeterFrom.Visible = False
        '
        'lblMeterFrom
        '
        Me.lblMeterFrom.AutoSize = True
        Me.lblMeterFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeterFrom.ForeColor = System.Drawing.Color.Black
        Me.lblMeterFrom.Location = New System.Drawing.Point(282, 20)
        Me.lblMeterFrom.Name = "lblMeterFrom"
        Me.lblMeterFrom.Size = New System.Drawing.Size(72, 13)
        Me.lblMeterFrom.TabIndex = 229
        Me.lblMeterFrom.Text = "Meter From"
        Me.lblMeterFrom.Visible = False
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(403, 20)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(11, 13)
        Me.Label69.TabIndex = 230
        Me.Label69.Text = ":"
        Me.Label69.Visible = False
        '
        'lblMeterTo
        '
        Me.lblMeterTo.AutoSize = True
        Me.lblMeterTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeterTo.ForeColor = System.Drawing.Color.Black
        Me.lblMeterTo.Location = New System.Drawing.Point(541, 20)
        Me.lblMeterTo.Name = "lblMeterTo"
        Me.lblMeterTo.Size = New System.Drawing.Size(57, 13)
        Me.lblMeterTo.TabIndex = 327
        Me.lblMeterTo.Text = "Meter To"
        Me.lblMeterTo.Visible = False
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(627, 20)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(11, 13)
        Me.Label70.TabIndex = 328
        Me.Label70.Text = ":"
        Me.Label70.Visible = False
        '
        'txtMeterTo
        '
        Me.txtMeterTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMeterTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeterTo.Location = New System.Drawing.Point(641, 16)
        Me.txtMeterTo.MaxLength = 18
        Me.txtMeterTo.Name = "txtMeterTo"
        Me.txtMeterTo.Size = New System.Drawing.Size(110, 21)
        Me.txtMeterTo.TabIndex = 305
        Me.txtMeterTo.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.tcPKOLog)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 42)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(787, 499)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'tcPKOLog
        '
        Me.tcPKOLog.Controls.Add(Me.tbProduction)
        Me.tcPKOLog.Controls.Add(Me.tbProcessLog)
        Me.tcPKOLog.Controls.Add(Me.tbProcessingInfo)
        Me.tcPKOLog.Controls.Add(Me.tbPressInfo)
        Me.tcPKOLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcPKOLog.Location = New System.Drawing.Point(3, 17)
        Me.tcPKOLog.Name = "tcPKOLog"
        Me.tcPKOLog.SelectedIndex = 0
        Me.tcPKOLog.Size = New System.Drawing.Size(781, 479)
        Me.tcPKOLog.TabIndex = 300
        '
        'tbProduction
        '
        Me.tbProduction.AutoScroll = True
        Me.tbProduction.BackgroundImage = CType(resources.GetObject("tbProduction.BackgroundImage"), System.Drawing.Image)
        Me.tbProduction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbProduction.Controls.Add(Me.Panel1)
        Me.tbProduction.Location = New System.Drawing.Point(4, 22)
        Me.tbProduction.Name = "tbProduction"
        Me.tbProduction.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProduction.Size = New System.Drawing.Size(773, 453)
        Me.tbProduction.TabIndex = 0
        Me.tbProduction.Text = "Production"
        Me.tbProduction.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.gbShiftInformation)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(767, 447)
        Me.Panel1.TabIndex = 0
        '
        'gbShiftInformation
        '
        Me.gbShiftInformation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbShiftInformation.BackColor = System.Drawing.Color.Transparent
        Me.gbShiftInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.gbShiftInformation.Controls.Add(Me.txtStartTime)
        Me.gbShiftInformation.Controls.Add(Me.txtStopTime)
        Me.gbShiftInformation.Controls.Add(Me.Label22)
        Me.gbShiftInformation.Controls.Add(Me.txtTotalShiftKernelProcessed)
        Me.gbShiftInformation.Controls.Add(Me.Label20)
        Me.gbShiftInformation.Controls.Add(Me.lblKernelProcessedtoday)
        Me.gbShiftInformation.Controls.Add(Me.Label19)
        Me.gbShiftInformation.Controls.Add(Me.Label3)
        Me.gbShiftInformation.Controls.Add(Me.txtShiftHours)
        Me.gbShiftInformation.Controls.Add(Me.Label12)
        Me.gbShiftInformation.Controls.Add(Me.Label15)
        Me.gbShiftInformation.Controls.Add(Me.dgvPKOLogShiftDetails)
        Me.gbShiftInformation.Controls.Add(Me.btnResetShift)
        Me.gbShiftInformation.Controls.Add(Me.btnAddShift)
        Me.gbShiftInformation.Controls.Add(Me.ddlShift)
        Me.gbShiftInformation.Controls.Add(Me.Label2)
        Me.gbShiftInformation.Controls.Add(Me.lblShift)
        Me.gbShiftInformation.Controls.Add(Me.Label9)
        Me.gbShiftInformation.Controls.Add(Me.Label115)
        Me.gbShiftInformation.Controls.Add(Me.lblYearTodateHrs)
        Me.gbShiftInformation.Controls.Add(Me.lblProMonthToDateHrs)
        Me.gbShiftInformation.Controls.Add(Me.lblTotalHoursHrs)
        Me.gbShiftInformation.Controls.Add(Me.txtYearTodateHrs)
        Me.gbShiftInformation.Controls.Add(Me.txtMonthTodateHrs)
        Me.gbShiftInformation.Controls.Add(Me.txtTotalHours)
        Me.gbShiftInformation.Controls.Add(Me.Label10)
        Me.gbShiftInformation.Controls.Add(Me.Label11)
        Me.gbShiftInformation.Controls.Add(Me.lblYearTodate)
        Me.gbShiftInformation.Controls.Add(Me.Label14)
        Me.gbShiftInformation.Controls.Add(Me.lblProMonthToDate)
        Me.gbShiftInformation.Controls.Add(Me.lblTotalHours)
        Me.gbShiftInformation.Controls.Add(Me.txtKernelProcessed)
        Me.gbShiftInformation.Controls.Add(Me.Label4)
        Me.gbShiftInformation.Controls.Add(Me.txtMandor)
        Me.gbShiftInformation.Controls.Add(Me.txtAssistant)
        Me.gbShiftInformation.Controls.Add(Me.lblKernelProcessed)
        Me.gbShiftInformation.Controls.Add(Me.lblStopTime)
        Me.gbShiftInformation.Controls.Add(Me.lblStartTime)
        Me.gbShiftInformation.Controls.Add(Me.Label18)
        Me.gbShiftInformation.Controls.Add(Me.lblMandore)
        Me.gbShiftInformation.Controls.Add(Me.Label16)
        Me.gbShiftInformation.Controls.Add(Me.lblAssistant)
        Me.gbShiftInformation.Location = New System.Drawing.Point(8, 10)
        Me.gbShiftInformation.Name = "gbShiftInformation"
        Me.gbShiftInformation.Size = New System.Drawing.Size(756, 391)
        Me.gbShiftInformation.TabIndex = 4
        Me.gbShiftInformation.TabStop = False
        Me.gbShiftInformation.Text = "Shift Information"
        '
        'txtStartTime
        '
        Me.txtStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStartTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartTime.Location = New System.Drawing.Point(98, 91)
        Me.txtStartTime.MaxLength = 14
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(52, 21)
        Me.txtStartTime.TabIndex = 14
        '
        'txtStopTime
        '
        Me.txtStopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStopTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStopTime.Location = New System.Drawing.Point(336, 91)
        Me.txtStopTime.MaxLength = 14
        Me.txtStopTime.Name = "txtStopTime"
        Me.txtStopTime.Size = New System.Drawing.Size(52, 21)
        Me.txtStopTime.TabIndex = 15
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(474, 340)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(34, 13)
        Me.Label22.TabIndex = 558
        Me.Label22.Text = "Tons"
        '
        'txtTotalShiftKernelProcessed
        '
        Me.txtTotalShiftKernelProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalShiftKernelProcessed.Enabled = False
        Me.txtTotalShiftKernelProcessed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalShiftKernelProcessed.Location = New System.Drawing.Point(373, 336)
        Me.txtTotalShiftKernelProcessed.MaxLength = 18
        Me.txtTotalShiftKernelProcessed.Name = "txtTotalShiftKernelProcessed"
        Me.txtTotalShiftKernelProcessed.Size = New System.Drawing.Size(100, 21)
        Me.txtTotalShiftKernelProcessed.TabIndex = 557
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(360, 340)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(11, 13)
        Me.Label20.TabIndex = 556
        Me.Label20.Text = ":"
        '
        'lblKernelProcessedtoday
        '
        Me.lblKernelProcessedtoday.AutoSize = True
        Me.lblKernelProcessedtoday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelProcessedtoday.ForeColor = System.Drawing.Color.Black
        Me.lblKernelProcessedtoday.Location = New System.Drawing.Point(157, 340)
        Me.lblKernelProcessedtoday.Name = "lblKernelProcessedtoday"
        Me.lblKernelProcessedtoday.Size = New System.Drawing.Size(203, 13)
        Me.lblKernelProcessedtoday.TabIndex = 555
        Me.lblKernelProcessedtoday.Text = "Total Kernel Processed in all shifts"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(719, 65)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 554
        Me.Label19.Text = "Ton"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(719, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 553
        Me.Label3.Text = "Hrs"
        '
        'txtShiftHours
        '
        Me.txtShiftHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShiftHours.Enabled = False
        Me.txtShiftHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShiftHours.Location = New System.Drawing.Point(609, 92)
        Me.txtShiftHours.MaxLength = 18
        Me.txtShiftHours.Name = "txtShiftHours"
        Me.txtShiftHours.Size = New System.Drawing.Size(108, 21)
        Me.txtShiftHours.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(594, 99)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(11, 13)
        Me.Label12.TabIndex = 551
        Me.Label12.Text = ":"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(484, 95)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 550
        Me.Label15.Text = "Shift Hours"
        '
        'dgvPKOLogShiftDetails
        '
        Me.dgvPKOLogShiftDetails.AllowUserToAddRows = False
        Me.dgvPKOLogShiftDetails.AllowUserToDeleteRows = False
        Me.dgvPKOLogShiftDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvPKOLogShiftDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPKOLogShiftDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPKOLogShiftDetails.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPKOLogShiftDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPKOLogShiftDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPKOLogShiftDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPKOLogShiftDetails.ColumnHeadersHeight = 30
        Me.dgvPKOLogShiftDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgShift, Me.dgShiftAssistant, Me.dgShiftMandore, Me.dgShiftStartTime, Me.dgShiftStopTime, Me.dgShiftHours, Me.dgShiftKernelProcessed})
        Me.dgvPKOLogShiftDetails.ContextMenuStrip = Me.cmsShiftInformation
        Me.dgvPKOLogShiftDetails.EnableHeadersVisualStyles = False
        Me.dgvPKOLogShiftDetails.GridColor = System.Drawing.Color.Gray
        Me.dgvPKOLogShiftDetails.Location = New System.Drawing.Point(14, 168)
        Me.dgvPKOLogShiftDetails.MultiSelect = False
        Me.dgvPKOLogShiftDetails.Name = "dgvPKOLogShiftDetails"
        Me.dgvPKOLogShiftDetails.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPKOLogShiftDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPKOLogShiftDetails.RowHeadersVisible = False
        Me.dgvPKOLogShiftDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPKOLogShiftDetails.Size = New System.Drawing.Size(704, 119)
        Me.dgvPKOLogShiftDetails.TabIndex = 319
        Me.dgvPKOLogShiftDetails.TabStop = False
        '
        'dgShift
        '
        Me.dgShift.DataPropertyName = "Shift"
        Me.dgShift.HeaderText = "Shift"
        Me.dgShift.Name = "dgShift"
        Me.dgShift.ReadOnly = True
        Me.dgShift.Width = 40
        '
        'dgShiftAssistant
        '
        Me.dgShiftAssistant.DataPropertyName = "Assistant"
        Me.dgShiftAssistant.HeaderText = "Assistant"
        Me.dgShiftAssistant.Name = "dgShiftAssistant"
        Me.dgShiftAssistant.ReadOnly = True
        '
        'dgShiftMandore
        '
        Me.dgShiftMandore.DataPropertyName = "Mandore"
        Me.dgShiftMandore.HeaderText = "Mandore"
        Me.dgShiftMandore.Name = "dgShiftMandore"
        Me.dgShiftMandore.ReadOnly = True
        '
        'dgShiftStartTime
        '
        Me.dgShiftStartTime.DataPropertyName = "StartTime"
        Me.dgShiftStartTime.HeaderText = "Start Time"
        Me.dgShiftStartTime.Name = "dgShiftStartTime"
        Me.dgShiftStartTime.ReadOnly = True
        '
        'dgShiftStopTime
        '
        Me.dgShiftStopTime.DataPropertyName = "StopTime"
        Me.dgShiftStopTime.HeaderText = "Stop Time"
        Me.dgShiftStopTime.Name = "dgShiftStopTime"
        Me.dgShiftStopTime.ReadOnly = True
        '
        'dgShiftHours
        '
        Me.dgShiftHours.DataPropertyName = "ShiftHours"
        Me.dgShiftHours.HeaderText = "Shift Hours"
        Me.dgShiftHours.Name = "dgShiftHours"
        Me.dgShiftHours.ReadOnly = True
        Me.dgShiftHours.Width = 95
        '
        'dgShiftKernelProcessed
        '
        Me.dgShiftKernelProcessed.DataPropertyName = "KernelProcessed"
        Me.dgShiftKernelProcessed.HeaderText = "Kernel Processed"
        Me.dgShiftKernelProcessed.Name = "dgShiftKernelProcessed"
        Me.dgShiftKernelProcessed.ReadOnly = True
        Me.dgShiftKernelProcessed.Width = 150
        '
        'cmsShiftInformation
        '
        Me.cmsShiftInformation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.DeleteShiftInfo})
        Me.cmsShiftInformation.Name = "cmsIPR"
        Me.cmsShiftInformation.Size = New System.Drawing.Size(117, 70)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem1.Text = "Add"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem2.Text = "Edit"
        '
        'DeleteShiftInfo
        '
        Me.DeleteShiftInfo.Name = "DeleteShiftInfo"
        Me.DeleteShiftInfo.Size = New System.Drawing.Size(116, 22)
        Me.DeleteShiftInfo.Text = "Delete"
        '
        'btnResetShift
        '
        Me.btnResetShift.BackgroundImage = CType(resources.GetObject("btnResetShift.BackgroundImage"), System.Drawing.Image)
        Me.btnResetShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetShift.Image = CType(resources.GetObject("btnResetShift.Image"), System.Drawing.Image)
        Me.btnResetShift.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnResetShift.Location = New System.Drawing.Point(622, 129)
        Me.btnResetShift.Name = "btnResetShift"
        Me.btnResetShift.Size = New System.Drawing.Size(81, 25)
        Me.btnResetShift.TabIndex = 20
        Me.btnResetShift.Text = "Reset"
        Me.btnResetShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnResetShift.UseVisualStyleBackColor = True
        '
        'btnAddShift
        '
        Me.btnAddShift.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddShift.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddShift.Image = CType(resources.GetObject("btnAddShift.Image"), System.Drawing.Image)
        Me.btnAddShift.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAddShift.Location = New System.Drawing.Point(532, 129)
        Me.btnAddShift.Name = "btnAddShift"
        Me.btnAddShift.Size = New System.Drawing.Size(84, 25)
        Me.btnAddShift.TabIndex = 19
        Me.btnAddShift.Text = "Add"
        Me.btnAddShift.UseVisualStyleBackColor = True
        '
        'ddlShift
        '
        Me.ddlShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlShift.FormattingEnabled = True
        Me.ddlShift.Items.AddRange(New Object() {"--Select--", "1", "2", "3"})
        Me.ddlShift.Location = New System.Drawing.Point(98, 32)
        Me.ddlShift.Name = "ddlShift"
        Me.ddlShift.Size = New System.Drawing.Size(108, 21)
        Me.ddlShift.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(83, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(11, 13)
        Me.Label2.TabIndex = 272
        Me.Label2.Text = ":"
        '
        'lblShift
        '
        Me.lblShift.AutoSize = True
        Me.lblShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Red
        Me.lblShift.Location = New System.Drawing.Point(9, 35)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(33, 13)
        Me.lblShift.TabIndex = 271
        Me.lblShift.Text = "Shift"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(323, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 13)
        Me.Label9.TabIndex = 257
        Me.Label9.Text = ":"
        '
        'Label115
        '
        Me.Label115.AutoSize = True
        Me.Label115.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label115.ForeColor = System.Drawing.Color.Red
        Me.Label115.Location = New System.Drawing.Point(83, 95)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(11, 13)
        Me.Label115.TabIndex = 251
        Me.Label115.Text = ":"
        '
        'lblYearTodateHrs
        '
        Me.lblYearTodateHrs.AutoSize = True
        Me.lblYearTodateHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearTodateHrs.ForeColor = System.Drawing.Color.Black
        Me.lblYearTodateHrs.Location = New System.Drawing.Point(712, 313)
        Me.lblYearTodateHrs.Name = "lblYearTodateHrs"
        Me.lblYearTodateHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblYearTodateHrs.TabIndex = 215
        Me.lblYearTodateHrs.Text = "Hrs"
        '
        'lblProMonthToDateHrs
        '
        Me.lblProMonthToDateHrs.AutoSize = True
        Me.lblProMonthToDateHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProMonthToDateHrs.ForeColor = System.Drawing.Color.Black
        Me.lblProMonthToDateHrs.Location = New System.Drawing.Point(474, 313)
        Me.lblProMonthToDateHrs.Name = "lblProMonthToDateHrs"
        Me.lblProMonthToDateHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblProMonthToDateHrs.TabIndex = 214
        Me.lblProMonthToDateHrs.Text = "Hrs"
        '
        'lblTotalHoursHrs
        '
        Me.lblTotalHoursHrs.AutoSize = True
        Me.lblTotalHoursHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHoursHrs.ForeColor = System.Drawing.Color.Black
        Me.lblTotalHoursHrs.Location = New System.Drawing.Point(225, 313)
        Me.lblTotalHoursHrs.Name = "lblTotalHoursHrs"
        Me.lblTotalHoursHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblTotalHoursHrs.TabIndex = 213
        Me.lblTotalHoursHrs.Text = "Hrs"
        '
        'txtYearTodateHrs
        '
        Me.txtYearTodateHrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYearTodateHrs.Enabled = False
        Me.txtYearTodateHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearTodateHrs.Location = New System.Drawing.Point(610, 309)
        Me.txtYearTodateHrs.MaxLength = 18
        Me.txtYearTodateHrs.Name = "txtYearTodateHrs"
        Me.txtYearTodateHrs.Size = New System.Drawing.Size(100, 21)
        Me.txtYearTodateHrs.TabIndex = 22
        '
        'txtMonthTodateHrs
        '
        Me.txtMonthTodateHrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMonthTodateHrs.Enabled = False
        Me.txtMonthTodateHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthTodateHrs.Location = New System.Drawing.Point(373, 309)
        Me.txtMonthTodateHrs.MaxLength = 18
        Me.txtMonthTodateHrs.Name = "txtMonthTodateHrs"
        Me.txtMonthTodateHrs.Size = New System.Drawing.Size(100, 21)
        Me.txtMonthTodateHrs.TabIndex = 21
        '
        'txtTotalHours
        '
        Me.txtTotalHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalHours.Enabled = False
        Me.txtTotalHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHours.Location = New System.Drawing.Point(123, 309)
        Me.txtTotalHours.MaxLength = 18
        Me.txtTotalHours.Name = "txtTotalHours"
        Me.txtTotalHours.Size = New System.Drawing.Size(100, 21)
        Me.txtTotalHours.TabIndex = 207
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(110, 313)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(11, 13)
        Me.Label10.TabIndex = 206
        Me.Label10.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(594, 313)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(11, 13)
        Me.Label11.TabIndex = 205
        Me.Label11.Text = ":"
        '
        'lblYearTodate
        '
        Me.lblYearTodate.AutoSize = True
        Me.lblYearTodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearTodate.ForeColor = System.Drawing.Color.Black
        Me.lblYearTodate.Location = New System.Drawing.Point(512, 313)
        Me.lblYearTodate.Name = "lblYearTodate"
        Me.lblYearTodate.Size = New System.Drawing.Size(80, 13)
        Me.lblYearTodate.TabIndex = 204
        Me.lblYearTodate.Text = "Year To date"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(359, 313)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(11, 13)
        Me.Label14.TabIndex = 203
        Me.Label14.Text = ":"
        '
        'lblProMonthToDate
        '
        Me.lblProMonthToDate.AutoSize = True
        Me.lblProMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProMonthToDate.ForeColor = System.Drawing.Color.Black
        Me.lblProMonthToDate.Location = New System.Drawing.Point(272, 313)
        Me.lblProMonthToDate.Name = "lblProMonthToDate"
        Me.lblProMonthToDate.Size = New System.Drawing.Size(88, 13)
        Me.lblProMonthToDate.TabIndex = 202
        Me.lblProMonthToDate.Text = "Month To date"
        '
        'lblTotalHours
        '
        Me.lblTotalHours.AutoSize = True
        Me.lblTotalHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHours.ForeColor = System.Drawing.Color.Black
        Me.lblTotalHours.Location = New System.Drawing.Point(5, 313)
        Me.lblTotalHours.Name = "lblTotalHours"
        Me.lblTotalHours.Size = New System.Drawing.Size(102, 13)
        Me.lblTotalHours.TabIndex = 201
        Me.lblTotalHours.Text = "Total Shift Hours"
        '
        'txtKernelProcessed
        '
        Me.txtKernelProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKernelProcessed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKernelProcessed.Location = New System.Drawing.Point(609, 61)
        Me.txtKernelProcessed.MaxLength = 18
        Me.txtKernelProcessed.Name = "txtKernelProcessed"
        Me.txtKernelProcessed.Size = New System.Drawing.Size(108, 21)
        Me.txtKernelProcessed.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(594, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(11, 13)
        Me.Label4.TabIndex = 195
        Me.Label4.Text = ":"
        '
        'txtMandor
        '
        Me.txtMandor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMandor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMandor.Location = New System.Drawing.Point(336, 61)
        Me.txtMandor.MaxLength = 50
        Me.txtMandor.Name = "txtMandor"
        Me.txtMandor.Size = New System.Drawing.Size(108, 21)
        Me.txtMandor.TabIndex = 12
        '
        'txtAssistant
        '
        Me.txtAssistant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAssistant.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssistant.Location = New System.Drawing.Point(98, 61)
        Me.txtAssistant.MaxLength = 50
        Me.txtAssistant.Name = "txtAssistant"
        Me.txtAssistant.Size = New System.Drawing.Size(108, 21)
        Me.txtAssistant.TabIndex = 11
        '
        'lblKernelProcessed
        '
        Me.lblKernelProcessed.AutoSize = True
        Me.lblKernelProcessed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelProcessed.ForeColor = System.Drawing.Color.Red
        Me.lblKernelProcessed.Location = New System.Drawing.Point(484, 65)
        Me.lblKernelProcessed.Name = "lblKernelProcessed"
        Me.lblKernelProcessed.Size = New System.Drawing.Size(106, 13)
        Me.lblKernelProcessed.TabIndex = 190
        Me.lblKernelProcessed.Text = "Kernel Processed"
        '
        'lblStopTime
        '
        Me.lblStopTime.AutoSize = True
        Me.lblStopTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStopTime.ForeColor = System.Drawing.Color.Red
        Me.lblStopTime.Location = New System.Drawing.Point(257, 95)
        Me.lblStopTime.Name = "lblStopTime"
        Me.lblStopTime.Size = New System.Drawing.Size(65, 13)
        Me.lblStopTime.TabIndex = 188
        Me.lblStopTime.Text = "Stop Time"
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartTime.ForeColor = System.Drawing.Color.Red
        Me.lblStartTime.Location = New System.Drawing.Point(9, 95)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(67, 13)
        Me.lblStartTime.TabIndex = 187
        Me.lblStartTime.Text = "Start Time"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(323, 65)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(11, 13)
        Me.Label18.TabIndex = 183
        Me.Label18.Text = ":"
        '
        'lblMandore
        '
        Me.lblMandore.AutoSize = True
        Me.lblMandore.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMandore.ForeColor = System.Drawing.Color.Black
        Me.lblMandore.Location = New System.Drawing.Point(257, 65)
        Me.lblMandore.Name = "lblMandore"
        Me.lblMandore.Size = New System.Drawing.Size(56, 13)
        Me.lblMandore.TabIndex = 182
        Me.lblMandore.Text = "Mandore"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(83, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(11, 13)
        Me.Label16.TabIndex = 181
        Me.Label16.Text = ":"
        '
        'lblAssistant
        '
        Me.lblAssistant.AutoSize = True
        Me.lblAssistant.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAssistant.ForeColor = System.Drawing.Color.Black
        Me.lblAssistant.Location = New System.Drawing.Point(9, 65)
        Me.lblAssistant.Name = "lblAssistant"
        Me.lblAssistant.Size = New System.Drawing.Size(58, 13)
        Me.lblAssistant.TabIndex = 180
        Me.lblAssistant.Text = "Assistant"
        '
        'tbProcessLog
        '
        Me.tbProcessLog.AutoScroll = True
        Me.tbProcessLog.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbProcessLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbProcessLog.Controls.Add(Me.gplblProcessedKernel)
        Me.tbProcessLog.Controls.Add(Me.gpReceivedKernel)
        Me.tbProcessLog.Controls.Add(Me.GroupBox4)
        Me.tbProcessLog.Location = New System.Drawing.Point(4, 22)
        Me.tbProcessLog.Name = "tbProcessLog"
        Me.tbProcessLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProcessLog.Size = New System.Drawing.Size(773, 453)
        Me.tbProcessLog.TabIndex = 1
        Me.tbProcessLog.Text = "ProcessLog"
        Me.tbProcessLog.UseVisualStyleBackColor = True
        '
        'gplblProcessedKernel
        '
        Me.gplblProcessedKernel.Controls.Add(Me.Label26)
        Me.gplblProcessedKernel.Controls.Add(Me.Label25)
        Me.gplblProcessedKernel.Controls.Add(Me.Label23)
        Me.gplblProcessedKernel.Controls.Add(Me.txtKernelProcessedYear)
        Me.gplblProcessedKernel.Controls.Add(Me.txtKernelProcessedMonth)
        Me.gplblProcessedKernel.Controls.Add(Me.txtKernelProcessedToday)
        Me.gplblProcessedKernel.Controls.Add(Me.Label67)
        Me.gplblProcessedKernel.Controls.Add(Me.lblKernelReceived)
        Me.gplblProcessedKernel.Controls.Add(Me.lblKernelToday)
        Me.gplblProcessedKernel.Controls.Add(Me.lblKernelMonthToDate)
        Me.gplblProcessedKernel.Controls.Add(Me.lblKernelYearToDate)
        Me.gplblProcessedKernel.Location = New System.Drawing.Point(7, 356)
        Me.gplblProcessedKernel.Name = "gplblProcessedKernel"
        Me.gplblProcessedKernel.Size = New System.Drawing.Size(752, 73)
        Me.gplblProcessedKernel.TabIndex = 217
        Me.gplblProcessedKernel.TabStop = False
        Me.gplblProcessedKernel.Text = "Processed Kernel"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(674, 45)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 339
        Me.Label26.Text = "Tons"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(477, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 13)
        Me.Label25.TabIndex = 338
        Me.Label25.Text = "Tons"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(281, 45)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 324
        Me.Label23.Text = "Tons"
        '
        'txtKernelProcessedYear
        '
        Me.txtKernelProcessedYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKernelProcessedYear.Enabled = False
        Me.txtKernelProcessedYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKernelProcessedYear.Location = New System.Drawing.Point(518, 43)
        Me.txtKernelProcessedYear.MaxLength = 18
        Me.txtKernelProcessedYear.Name = "txtKernelProcessedYear"
        Me.txtKernelProcessedYear.Size = New System.Drawing.Size(150, 21)
        Me.txtKernelProcessedYear.TabIndex = 219
        '
        'txtKernelProcessedMonth
        '
        Me.txtKernelProcessedMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKernelProcessedMonth.Enabled = False
        Me.txtKernelProcessedMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKernelProcessedMonth.Location = New System.Drawing.Point(325, 43)
        Me.txtKernelProcessedMonth.MaxLength = 18
        Me.txtKernelProcessedMonth.Name = "txtKernelProcessedMonth"
        Me.txtKernelProcessedMonth.Size = New System.Drawing.Size(150, 21)
        Me.txtKernelProcessedMonth.TabIndex = 218
        '
        'txtKernelProcessedToday
        '
        Me.txtKernelProcessedToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKernelProcessedToday.Enabled = False
        Me.txtKernelProcessedToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKernelProcessedToday.Location = New System.Drawing.Point(128, 43)
        Me.txtKernelProcessedToday.MaxLength = 18
        Me.txtKernelProcessedToday.Name = "txtKernelProcessedToday"
        Me.txtKernelProcessedToday.Size = New System.Drawing.Size(150, 21)
        Me.txtKernelProcessedToday.TabIndex = 337
        Me.txtKernelProcessedToday.TabStop = False
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(111, 45)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(11, 13)
        Me.Label67.TabIndex = 336
        Me.Label67.Text = ":"
        '
        'lblKernelReceived
        '
        Me.lblKernelReceived.AutoSize = True
        Me.lblKernelReceived.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelReceived.ForeColor = System.Drawing.Color.Black
        Me.lblKernelReceived.Location = New System.Drawing.Point(20, 45)
        Me.lblKernelReceived.Name = "lblKernelReceived"
        Me.lblKernelReceived.Size = New System.Drawing.Size(44, 13)
        Me.lblKernelReceived.TabIndex = 335
        Me.lblKernelReceived.Text = "Kernel"
        '
        'lblKernelToday
        '
        Me.lblKernelToday.AutoSize = True
        Me.lblKernelToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelToday.ForeColor = System.Drawing.Color.Black
        Me.lblKernelToday.Location = New System.Drawing.Point(178, 23)
        Me.lblKernelToday.Name = "lblKernelToday"
        Me.lblKernelToday.Size = New System.Drawing.Size(42, 13)
        Me.lblKernelToday.TabIndex = 332
        Me.lblKernelToday.Text = "Today"
        '
        'lblKernelMonthToDate
        '
        Me.lblKernelMonthToDate.AutoSize = True
        Me.lblKernelMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelMonthToDate.ForeColor = System.Drawing.Color.Black
        Me.lblKernelMonthToDate.Location = New System.Drawing.Point(352, 23)
        Me.lblKernelMonthToDate.Name = "lblKernelMonthToDate"
        Me.lblKernelMonthToDate.Size = New System.Drawing.Size(88, 13)
        Me.lblKernelMonthToDate.TabIndex = 333
        Me.lblKernelMonthToDate.Text = "Month To date"
        '
        'lblKernelYearToDate
        '
        Me.lblKernelYearToDate.AutoSize = True
        Me.lblKernelYearToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelYearToDate.ForeColor = System.Drawing.Color.Black
        Me.lblKernelYearToDate.Location = New System.Drawing.Point(554, 23)
        Me.lblKernelYearToDate.Name = "lblKernelYearToDate"
        Me.lblKernelYearToDate.Size = New System.Drawing.Size(76, 13)
        Me.lblKernelYearToDate.TabIndex = 334
        Me.lblKernelYearToDate.Text = "Year Todate"
        '
        'gpReceivedKernel
        '
        Me.gpReceivedKernel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpReceivedKernel.Controls.Add(Me.ddlLoadingLocationKerRecd)
        Me.gpReceivedKernel.Controls.Add(Me.btnReset)
        Me.gpReceivedKernel.Controls.Add(Me.btnAdd)
        Me.gpReceivedKernel.Controls.Add(Me.txtTotalReceivedQtyKerRec)
        Me.gpReceivedKernel.Controls.Add(Me.dgvReceivedKernel)
        Me.gpReceivedKernel.Controls.Add(Me.txtYearTodateRecKer)
        Me.gpReceivedKernel.Controls.Add(Me.Label8)
        Me.gpReceivedKernel.Controls.Add(Me.txtqtyMtKerRecd)
        Me.gpReceivedKernel.Controls.Add(Me.Label17)
        Me.gpReceivedKernel.Controls.Add(Me.lblTotalReceivedQty)
        Me.gpReceivedKernel.Controls.Add(Me.Label6)
        Me.gpReceivedKernel.Controls.Add(Me.lblQtyMt)
        Me.gpReceivedKernel.Controls.Add(Me.Label24)
        Me.gpReceivedKernel.Controls.Add(Me.lblYearTodateMt)
        Me.gpReceivedKernel.Controls.Add(Me.lbllocation)
        Me.gpReceivedKernel.Controls.Add(Me.txtTodateMtRecKer)
        Me.gpReceivedKernel.Controls.Add(Me.lblTodate)
        Me.gpReceivedKernel.Controls.Add(Me.Label21)
        Me.gpReceivedKernel.Location = New System.Drawing.Point(7, 114)
        Me.gpReceivedKernel.Name = "gpReceivedKernel"
        Me.gpReceivedKernel.Size = New System.Drawing.Size(752, 236)
        Me.gpReceivedKernel.TabIndex = 210
        Me.gpReceivedKernel.TabStop = False
        Me.gpReceivedKernel.Text = "Received Kernel"
        '
        'ddlLoadingLocationKerRecd
        '
        Me.ddlLoadingLocationKerRecd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlLoadingLocationKerRecd.FormattingEnabled = True
        Me.ddlLoadingLocationKerRecd.Location = New System.Drawing.Point(187, 22)
        Me.ddlLoadingLocationKerRecd.Name = "ddlLoadingLocationKerRecd"
        Me.ddlLoadingLocationKerRecd.Size = New System.Drawing.Size(258, 21)
        Me.ddlLoadingLocationKerRecd.TabIndex = 211
        '
        'btnReset
        '
        Me.btnReset.BackgroundImage = CType(resources.GetObject("btnReset.BackgroundImage"), System.Drawing.Image)
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(617, 78)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(90, 25)
        Me.btnReset.TabIndex = 216
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(521, 78)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 25)
        Me.btnAdd.TabIndex = 215
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtTotalReceivedQtyKerRec
        '
        Me.txtTotalReceivedQtyKerRec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalReceivedQtyKerRec.Enabled = False
        Me.txtTotalReceivedQtyKerRec.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReceivedQtyKerRec.Location = New System.Drawing.Point(577, 205)
        Me.txtTotalReceivedQtyKerRec.MaxLength = 18
        Me.txtTotalReceivedQtyKerRec.Name = "txtTotalReceivedQtyKerRec"
        Me.txtTotalReceivedQtyKerRec.Size = New System.Drawing.Size(130, 21)
        Me.txtTotalReceivedQtyKerRec.TabIndex = 323
        Me.txtTotalReceivedQtyKerRec.TabStop = False
        '
        'dgvReceivedKernel
        '
        Me.dgvReceivedKernel.AllowUserToAddRows = False
        Me.dgvReceivedKernel.AllowUserToDeleteRows = False
        Me.dgvReceivedKernel.AllowUserToResizeRows = False
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvReceivedKernel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvReceivedKernel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReceivedKernel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvReceivedKernel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvReceivedKernel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReceivedKernel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReceivedKernel.ColumnHeadersHeight = 30
        Me.dgvReceivedKernel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgMeLoadingLocation, Me.dgMeLoadingLocationID, Me.dgMeQtyKerRecd, Me.dgMePKOKERReceivedID, Me.dgclKerRecdMonthTodate, Me.dgclKerRecdYearToDate})
        Me.dgvReceivedKernel.ContextMenuStrip = Me.cmsKernelReceived
        Me.dgvReceivedKernel.EnableHeadersVisualStyles = False
        Me.dgvReceivedKernel.GridColor = System.Drawing.Color.Gray
        Me.dgvReceivedKernel.Location = New System.Drawing.Point(12, 109)
        Me.dgvReceivedKernel.MultiSelect = False
        Me.dgvReceivedKernel.Name = "dgvReceivedKernel"
        Me.dgvReceivedKernel.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReceivedKernel.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvReceivedKernel.RowHeadersVisible = False
        Me.dgvReceivedKernel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReceivedKernel.Size = New System.Drawing.Size(712, 90)
        Me.dgvReceivedKernel.TabIndex = 105
        '
        'dgMeLoadingLocation
        '
        Me.dgMeLoadingLocation.DataPropertyName = "LoadingLocation"
        Me.dgMeLoadingLocation.HeaderText = "Location (Received From)"
        Me.dgMeLoadingLocation.Name = "dgMeLoadingLocation"
        Me.dgMeLoadingLocation.ReadOnly = True
        Me.dgMeLoadingLocation.Width = 250
        '
        'dgMeLoadingLocationID
        '
        Me.dgMeLoadingLocationID.DataPropertyName = "LoadingLocationID"
        Me.dgMeLoadingLocationID.HeaderText = "Loading Location"
        Me.dgMeLoadingLocationID.Name = "dgMeLoadingLocationID"
        Me.dgMeLoadingLocationID.ReadOnly = True
        Me.dgMeLoadingLocationID.Visible = False
        '
        'dgMeQtyKerRecd
        '
        Me.dgMeQtyKerRecd.DataPropertyName = "QtyKerRecd"
        Me.dgMeQtyKerRecd.HeaderText = "Quantity (Tons)"
        Me.dgMeQtyKerRecd.Name = "dgMeQtyKerRecd"
        Me.dgMeQtyKerRecd.ReadOnly = True
        Me.dgMeQtyKerRecd.Width = 120
        '
        'dgMePKOKERReceivedID
        '
        Me.dgMePKOKERReceivedID.DataPropertyName = "PKOKERReceivedID"
        Me.dgMePKOKERReceivedID.HeaderText = "PKOKERReceivedID"
        Me.dgMePKOKERReceivedID.Name = "dgMePKOKERReceivedID"
        Me.dgMePKOKERReceivedID.ReadOnly = True
        Me.dgMePKOKERReceivedID.Visible = False
        '
        'dgclKerRecdMonthTodate
        '
        Me.dgclKerRecdMonthTodate.DataPropertyName = "KerRecdMonthTodate"
        Me.dgclKerRecdMonthTodate.HeaderText = "Month To date (Tons)"
        Me.dgclKerRecdMonthTodate.Name = "dgclKerRecdMonthTodate"
        Me.dgclKerRecdMonthTodate.ReadOnly = True
        Me.dgclKerRecdMonthTodate.Width = 160
        '
        'dgclKerRecdYearToDate
        '
        Me.dgclKerRecdYearToDate.DataPropertyName = "KerRecdYearTodate"
        Me.dgclKerRecdYearToDate.HeaderText = "Year To Date (Tons)"
        Me.dgclKerRecdYearToDate.Name = "dgclKerRecdYearToDate"
        Me.dgclKerRecdYearToDate.ReadOnly = True
        Me.dgclKerRecdYearToDate.Width = 150
        '
        'cmsKernelReceived
        '
        Me.cmsKernelReceived.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.DeleteKernelReceived})
        Me.cmsKernelReceived.Name = "cmsIPR"
        Me.cmsKernelReceived.Size = New System.Drawing.Size(117, 70)
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Image = CType(resources.GetObject("ToolStripMenuItem4.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem4.Text = "Add"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Image = CType(resources.GetObject("ToolStripMenuItem5.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem5.Text = "Edit"
        '
        'DeleteKernelReceived
        '
        Me.DeleteKernelReceived.Name = "DeleteKernelReceived"
        Me.DeleteKernelReceived.Size = New System.Drawing.Size(116, 22)
        Me.DeleteKernelReceived.Text = "Delete"
        '
        'txtYearTodateRecKer
        '
        Me.txtYearTodateRecKer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtYearTodateRecKer.Enabled = False
        Me.txtYearTodateRecKer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearTodateRecKer.Location = New System.Drawing.Point(594, 51)
        Me.txtYearTodateRecKer.MaxLength = 18
        Me.txtYearTodateRecKer.Name = "txtYearTodateRecKer"
        Me.txtYearTodateRecKer.Size = New System.Drawing.Size(130, 21)
        Me.txtYearTodateRecKer.TabIndex = 214
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(553, 207)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 13)
        Me.Label8.TabIndex = 322
        Me.Label8.Text = ":"
        '
        'txtqtyMtKerRecd
        '
        Me.txtqtyMtKerRecd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtqtyMtKerRecd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqtyMtKerRecd.Location = New System.Drawing.Point(594, 20)
        Me.txtqtyMtKerRecd.MaxLength = 18
        Me.txtqtyMtKerRecd.Name = "txtqtyMtKerRecd"
        Me.txtqtyMtKerRecd.Size = New System.Drawing.Size(130, 21)
        Me.txtqtyMtKerRecd.TabIndex = 212
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(573, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(11, 13)
        Me.Label17.TabIndex = 227
        Me.Label17.Text = ":"
        '
        'lblTotalReceivedQty
        '
        Me.lblTotalReceivedQty.AutoSize = True
        Me.lblTotalReceivedQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalReceivedQty.ForeColor = System.Drawing.Color.Black
        Me.lblTotalReceivedQty.Location = New System.Drawing.Point(395, 207)
        Me.lblTotalReceivedQty.Name = "lblTotalReceivedQty"
        Me.lblTotalReceivedQty.Size = New System.Drawing.Size(156, 13)
        Me.lblTotalReceivedQty.TabIndex = 321
        Me.lblTotalReceivedQty.Text = "Total Received Qty (Tons)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(573, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 13)
        Me.Label6.TabIndex = 230
        Me.Label6.Text = ":"
        '
        'lblQtyMt
        '
        Me.lblQtyMt.AutoSize = True
        Me.lblQtyMt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtyMt.ForeColor = System.Drawing.Color.Black
        Me.lblQtyMt.Location = New System.Drawing.Point(451, 25)
        Me.lblQtyMt.Name = "lblQtyMt"
        Me.lblQtyMt.Size = New System.Drawing.Size(96, 13)
        Me.lblQtyMt.TabIndex = 226
        Me.lblQtyMt.Text = "Quantity (Tons)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(173, 25)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(11, 13)
        Me.Label24.TabIndex = 221
        Me.Label24.Text = ":"
        '
        'lblYearTodateMt
        '
        Me.lblYearTodateMt.AutoSize = True
        Me.lblYearTodateMt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearTodateMt.ForeColor = System.Drawing.Color.Black
        Me.lblYearTodateMt.Location = New System.Drawing.Point(451, 55)
        Me.lblYearTodateMt.Name = "lblYearTodateMt"
        Me.lblYearTodateMt.Size = New System.Drawing.Size(121, 13)
        Me.lblYearTodateMt.TabIndex = 229
        Me.lblYearTodateMt.Text = "Year To date (Tons)"
        '
        'lbllocation
        '
        Me.lbllocation.AutoSize = True
        Me.lbllocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllocation.ForeColor = System.Drawing.Color.Black
        Me.lbllocation.Location = New System.Drawing.Point(20, 25)
        Me.lbllocation.Name = "lbllocation"
        Me.lbllocation.Size = New System.Drawing.Size(153, 13)
        Me.lbllocation.TabIndex = 220
        Me.lbllocation.Text = "Location (Received From)"
        '
        'txtTodateMtRecKer
        '
        Me.txtTodateMtRecKer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTodateMtRecKer.Enabled = False
        Me.txtTodateMtRecKer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTodateMtRecKer.Location = New System.Drawing.Point(187, 51)
        Me.txtTodateMtRecKer.MaxLength = 18
        Me.txtTodateMtRecKer.Name = "txtTodateMtRecKer"
        Me.txtTodateMtRecKer.Size = New System.Drawing.Size(130, 21)
        Me.txtTodateMtRecKer.TabIndex = 213
        '
        'lblTodate
        '
        Me.lblTodate.AutoSize = True
        Me.lblTodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodate.ForeColor = System.Drawing.Color.Black
        Me.lblTodate.Location = New System.Drawing.Point(20, 55)
        Me.lblTodate.Name = "lblTodate"
        Me.lblTodate.Size = New System.Drawing.Size(129, 13)
        Me.lblTodate.TabIndex = 223
        Me.lblTodate.Text = "Month To date (Tons)"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(173, 55)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(11, 13)
        Me.Label21.TabIndex = 224
        Me.Label21.Text = ":"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.txtVarianceBudget)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.lblVariance)
        Me.GroupBox4.Controls.Add(Me.txtmonthtodatBudget)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.lblMonthToDate)
        Me.GroupBox4.Controls.Add(Me.txtBudget)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.lblBudget)
        Me.GroupBox4.Controls.Add(Me.lblTons)
        Me.GroupBox4.Controls.Add(Me.txtBFQty)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.lblBFQty)
        Me.GroupBox4.Location = New System.Drawing.Point(7, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(752, 109)
        Me.GroupBox4.TabIndex = 207
        Me.GroupBox4.TabStop = False
        '
        'txtVarianceBudget
        '
        Me.txtVarianceBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVarianceBudget.Enabled = False
        Me.txtVarianceBudget.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVarianceBudget.Location = New System.Drawing.Point(566, 80)
        Me.txtVarianceBudget.MaxLength = 18
        Me.txtVarianceBudget.Name = "txtVarianceBudget"
        Me.txtVarianceBudget.Size = New System.Drawing.Size(150, 21)
        Me.txtVarianceBudget.TabIndex = 219
        Me.txtVarianceBudget.TabStop = False
        Me.txtVarianceBudget.Text = "0"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(545, 84)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(11, 13)
        Me.Label13.TabIndex = 218
        Me.Label13.Text = ":"
        '
        'lblVariance
        '
        Me.lblVariance.AutoSize = True
        Me.lblVariance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariance.ForeColor = System.Drawing.Color.Black
        Me.lblVariance.Location = New System.Drawing.Point(433, 84)
        Me.lblVariance.Name = "lblVariance"
        Me.lblVariance.Size = New System.Drawing.Size(57, 13)
        Me.lblVariance.TabIndex = 217
        Me.lblVariance.Text = "Variance"
        '
        'txtmonthtodatBudget
        '
        Me.txtmonthtodatBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmonthtodatBudget.Enabled = False
        Me.txtmonthtodatBudget.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmonthtodatBudget.Location = New System.Drawing.Point(566, 50)
        Me.txtmonthtodatBudget.MaxLength = 18
        Me.txtmonthtodatBudget.Name = "txtmonthtodatBudget"
        Me.txtmonthtodatBudget.Size = New System.Drawing.Size(150, 21)
        Me.txtmonthtodatBudget.TabIndex = 216
        Me.txtmonthtodatBudget.TabStop = False
        Me.txtmonthtodatBudget.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(545, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(11, 13)
        Me.Label7.TabIndex = 215
        Me.Label7.Text = ":"
        '
        'lblMonthToDate
        '
        Me.lblMonthToDate.AutoSize = True
        Me.lblMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthToDate.ForeColor = System.Drawing.Color.Black
        Me.lblMonthToDate.Location = New System.Drawing.Point(433, 54)
        Me.lblMonthToDate.Name = "lblMonthToDate"
        Me.lblMonthToDate.Size = New System.Drawing.Size(90, 13)
        Me.lblMonthToDate.TabIndex = 214
        Me.lblMonthToDate.Text = "Month To Date"
        '
        'txtBudget
        '
        Me.txtBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBudget.Enabled = False
        Me.txtBudget.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBudget.Location = New System.Drawing.Point(565, 20)
        Me.txtBudget.MaxLength = 18
        Me.txtBudget.Name = "txtBudget"
        Me.txtBudget.Size = New System.Drawing.Size(150, 21)
        Me.txtBudget.TabIndex = 213
        Me.txtBudget.TabStop = False
        Me.txtBudget.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(545, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(11, 13)
        Me.Label5.TabIndex = 212
        Me.Label5.Text = ":"
        '
        'lblBudget
        '
        Me.lblBudget.AutoSize = True
        Me.lblBudget.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBudget.ForeColor = System.Drawing.Color.Black
        Me.lblBudget.Location = New System.Drawing.Point(433, 24)
        Me.lblBudget.Name = "lblBudget"
        Me.lblBudget.Size = New System.Drawing.Size(47, 13)
        Me.lblBudget.TabIndex = 211
        Me.lblBudget.Text = "Budget"
        '
        'lblTons
        '
        Me.lblTons.AutoSize = True
        Me.lblTons.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTons.ForeColor = System.Drawing.Color.Black
        Me.lblTons.Location = New System.Drawing.Point(343, 24)
        Me.lblTons.Name = "lblTons"
        Me.lblTons.Size = New System.Drawing.Size(34, 13)
        Me.lblTons.TabIndex = 210
        Me.lblTons.Text = "Tons"
        '
        'txtBFQty
        '
        Me.txtBFQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBFQty.Enabled = False
        Me.txtBFQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBFQty.Location = New System.Drawing.Point(187, 20)
        Me.txtBFQty.MaxLength = 18
        Me.txtBFQty.Name = "txtBFQty"
        Me.txtBFQty.Size = New System.Drawing.Size(150, 21)
        Me.txtBFQty.TabIndex = 209
        Me.txtBFQty.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(173, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 13)
        Me.Label1.TabIndex = 208
        Me.Label1.Text = ":"
        '
        'lblBFQty
        '
        Me.lblBFQty.AutoSize = True
        Me.lblBFQty.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBFQty.ForeColor = System.Drawing.Color.Black
        Me.lblBFQty.Location = New System.Drawing.Point(20, 24)
        Me.lblBFQty.Name = "lblBFQty"
        Me.lblBFQty.Size = New System.Drawing.Size(50, 13)
        Me.lblBFQty.TabIndex = 207
        Me.lblBFQty.Text = "B/F Qty"
        '
        'tbProcessingInfo
        '
        Me.tbProcessingInfo.AutoScroll = True
        Me.tbProcessingInfo.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbProcessingInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbProcessingInfo.Controls.Add(Me.GroupBox7)
        Me.tbProcessingInfo.Location = New System.Drawing.Point(4, 22)
        Me.tbProcessingInfo.Name = "tbProcessingInfo"
        Me.tbProcessingInfo.Size = New System.Drawing.Size(773, 453)
        Me.tbProcessingInfo.TabIndex = 2
        Me.tbProcessingInfo.Text = "ProcessingInfo"
        Me.tbProcessingInfo.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox7.Controls.Add(Me.Label38)
        Me.GroupBox7.Controls.Add(Me.Label37)
        Me.GroupBox7.Controls.Add(Me.lblOERPercentage)
        Me.GroupBox7.Controls.Add(Me.txtKERYear)
        Me.GroupBox7.Controls.Add(Me.txtKERMonth)
        Me.GroupBox7.Controls.Add(Me.txtKERToday)
        Me.GroupBox7.Controls.Add(Me.Label121)
        Me.GroupBox7.Controls.Add(Me.lblKER)
        Me.GroupBox7.Controls.Add(Me.txtKerneltoday)
        Me.GroupBox7.Controls.Add(Me.lblKernelProcess)
        Me.GroupBox7.Controls.Add(Me.Label64)
        Me.GroupBox7.Controls.Add(Me.lblLossOnKernel)
        Me.GroupBox7.Controls.Add(Me.Label62)
        Me.GroupBox7.Controls.Add(Me.txtLossOnKernelToday)
        Me.GroupBox7.Controls.Add(Me.txtKernelMonth)
        Me.GroupBox7.Controls.Add(Me.txtLossOnKernelMonth)
        Me.GroupBox7.Controls.Add(Me.txtKernelYear)
        Me.GroupBox7.Controls.Add(Me.lblThroughputMonthKgHr)
        Me.GroupBox7.Controls.Add(Me.txtLossOnKernelYear)
        Me.GroupBox7.Controls.Add(Me.lblThroughputKgHr)
        Me.GroupBox7.Controls.Add(Me.lblKernelYearTon)
        Me.GroupBox7.Controls.Add(Me.lblThroughputYearKgHr)
        Me.GroupBox7.Controls.Add(Me.lblLossOnKernelYearTon)
        Me.GroupBox7.Controls.Add(Me.txtThroughputYear)
        Me.GroupBox7.Controls.Add(Me.lblKernelProcessTon)
        Me.GroupBox7.Controls.Add(Me.txtThroughputMonthTodate)
        Me.GroupBox7.Controls.Add(Me.lblLossOnKernelTon)
        Me.GroupBox7.Controls.Add(Me.txtThroughput)
        Me.GroupBox7.Controls.Add(Me.lblKernelMonthTon)
        Me.GroupBox7.Controls.Add(Me.Label66)
        Me.GroupBox7.Controls.Add(Me.lblLossOnKernelMonthTon)
        Me.GroupBox7.Controls.Add(Me.lblThroughput)
        Me.GroupBox7.Controls.Add(Me.lblProcessingToday)
        Me.GroupBox7.Controls.Add(Me.lblEffectiveMonthHrs)
        Me.GroupBox7.Controls.Add(Me.lblProcessingMonthToDate)
        Me.GroupBox7.Controls.Add(Me.lblEffectiveProcessingHrs)
        Me.GroupBox7.Controls.Add(Me.lblProcessingYearToDate)
        Me.GroupBox7.Controls.Add(Me.lblEffectiveYearHrs)
        Me.GroupBox7.Controls.Add(Me.txtLogRemarks)
        Me.GroupBox7.Controls.Add(Me.txtEffectiveProcessingHoursYear)
        Me.GroupBox7.Controls.Add(Me.lblRemarks)
        Me.GroupBox7.Controls.Add(Me.txtEffectiveProcessingHoursMonth)
        Me.GroupBox7.Controls.Add(Me.Label114)
        Me.GroupBox7.Controls.Add(Me.txtEffectiveProcessingHoursToday)
        Me.GroupBox7.Controls.Add(Me.lblPKOProduction)
        Me.GroupBox7.Controls.Add(Me.Label59)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Controls.Add(Me.lblEffectiveProcessing)
        Me.GroupBox7.Controls.Add(Me.lblMechanicalBreakDown)
        Me.GroupBox7.Controls.Add(Me.lblTotalMonthHrs)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Controls.Add(Me.lblTotalBreakDownHrs)
        Me.GroupBox7.Controls.Add(Me.txtPKOProductionToday)
        Me.GroupBox7.Controls.Add(Me.lblTotalYearsHrs)
        Me.GroupBox7.Controls.Add(Me.txtMechanicalBreakDownToday)
        Me.GroupBox7.Controls.Add(Me.txtTotalBreakDownYear)
        Me.GroupBox7.Controls.Add(Me.txtPKOProductionMonthTodate)
        Me.GroupBox7.Controls.Add(Me.txtTotalBreakDownMonth)
        Me.GroupBox7.Controls.Add(Me.txtMechanicalBreakDownMonth)
        Me.GroupBox7.Controls.Add(Me.txtTotalBreakDownToday)
        Me.GroupBox7.Controls.Add(Me.txtPKOProductionYear)
        Me.GroupBox7.Controls.Add(Me.Label45)
        Me.GroupBox7.Controls.Add(Me.txtMechanicalBreakDownYear)
        Me.GroupBox7.Controls.Add(Me.lblTotalBreakDown)
        Me.GroupBox7.Controls.Add(Me.lblPKOProductionYearTon)
        Me.GroupBox7.Controls.Add(Me.lblProcessingMonthHrs)
        Me.GroupBox7.Controls.Add(Me.lblMechanicalYearHrs)
        Me.GroupBox7.Controls.Add(Me.lblProcessingHrs)
        Me.GroupBox7.Controls.Add(Me.lblPKOProductionTon)
        Me.GroupBox7.Controls.Add(Me.lblProcessingYearHrs)
        Me.GroupBox7.Controls.Add(Me.lblMechanicalHrs)
        Me.GroupBox7.Controls.Add(Me.txtProcessingBreakDownYear)
        Me.GroupBox7.Controls.Add(Me.lblPKOProductionMonthTon)
        Me.GroupBox7.Controls.Add(Me.txtProcessingBreakDownMonth)
        Me.GroupBox7.Controls.Add(Me.lblMechanicalMonthHrs)
        Me.GroupBox7.Controls.Add(Me.txtProcessingBreakDownToday)
        Me.GroupBox7.Controls.Add(Me.lblElectricalBreakDown)
        Me.GroupBox7.Controls.Add(Me.Label40)
        Me.GroupBox7.Controls.Add(Me.Label35)
        Me.GroupBox7.Controls.Add(Me.lblProcessingBreakDown)
        Me.GroupBox7.Controls.Add(Me.txtElectricalBreakDownToday)
        Me.GroupBox7.Controls.Add(Me.lblElectricalMonthHrs)
        Me.GroupBox7.Controls.Add(Me.txtElectricalBreakDownMonth)
        Me.GroupBox7.Controls.Add(Me.lblElectricalHrs)
        Me.GroupBox7.Controls.Add(Me.txtElectricalBreakDownYear)
        Me.GroupBox7.Controls.Add(Me.lblElectricalYearHrs)
        Me.GroupBox7.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(725, 403)
        Me.GroupBox7.TabIndex = 481
        Me.GroupBox7.TabStop = False
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Black
        Me.Label38.Location = New System.Drawing.Point(624, 322)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(19, 13)
        Me.Label38.TabIndex = 488
        Me.Label38.Text = "%"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.Black
        Me.Label37.Location = New System.Drawing.Point(461, 322)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(19, 13)
        Me.Label37.TabIndex = 487
        Me.Label37.Text = "%"
        '
        'lblOERPercentage
        '
        Me.lblOERPercentage.AutoSize = True
        Me.lblOERPercentage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOERPercentage.ForeColor = System.Drawing.Color.Black
        Me.lblOERPercentage.Location = New System.Drawing.Point(295, 322)
        Me.lblOERPercentage.Name = "lblOERPercentage"
        Me.lblOERPercentage.Size = New System.Drawing.Size(19, 13)
        Me.lblOERPercentage.TabIndex = 486
        Me.lblOERPercentage.Text = "%"
        '
        'txtKERYear
        '
        Me.txtKERYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKERYear.Enabled = False
        Me.txtKERYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKERYear.Location = New System.Drawing.Point(512, 318)
        Me.txtKERYear.MaxLength = 18
        Me.txtKERYear.Name = "txtKERYear"
        Me.txtKERYear.Size = New System.Drawing.Size(110, 21)
        Me.txtKERYear.TabIndex = 485
        '
        'txtKERMonth
        '
        Me.txtKERMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKERMonth.Enabled = False
        Me.txtKERMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKERMonth.Location = New System.Drawing.Point(347, 318)
        Me.txtKERMonth.MaxLength = 18
        Me.txtKERMonth.Name = "txtKERMonth"
        Me.txtKERMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtKERMonth.TabIndex = 484
        '
        'txtKERToday
        '
        Me.txtKERToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKERToday.Enabled = False
        Me.txtKERToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKERToday.Location = New System.Drawing.Point(182, 318)
        Me.txtKERToday.MaxLength = 18
        Me.txtKERToday.Name = "txtKERToday"
        Me.txtKERToday.Size = New System.Drawing.Size(110, 21)
        Me.txtKERToday.TabIndex = 483
        Me.txtKERToday.TabStop = False
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label121.Location = New System.Drawing.Point(167, 322)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(11, 13)
        Me.Label121.TabIndex = 482
        Me.Label121.Text = ":"
        '
        'lblKER
        '
        Me.lblKER.AutoSize = True
        Me.lblKER.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKER.ForeColor = System.Drawing.Color.Black
        Me.lblKER.Location = New System.Drawing.Point(5, 322)
        Me.lblKER.Name = "lblKER"
        Me.lblKER.Size = New System.Drawing.Size(31, 13)
        Me.lblKER.TabIndex = 481
        Me.lblKER.Text = "OER"
        '
        'txtKerneltoday
        '
        Me.txtKerneltoday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKerneltoday.Enabled = False
        Me.txtKerneltoday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKerneltoday.Location = New System.Drawing.Point(182, 47)
        Me.txtKerneltoday.MaxLength = 18
        Me.txtKerneltoday.Name = "txtKerneltoday"
        Me.txtKerneltoday.Size = New System.Drawing.Size(110, 21)
        Me.txtKerneltoday.TabIndex = 311
        Me.txtKerneltoday.TabStop = False
        '
        'lblKernelProcess
        '
        Me.lblKernelProcess.AutoSize = True
        Me.lblKernelProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelProcess.ForeColor = System.Drawing.Color.Black
        Me.lblKernelProcess.Location = New System.Drawing.Point(7, 51)
        Me.lblKernelProcess.Name = "lblKernelProcess"
        Me.lblKernelProcess.Size = New System.Drawing.Size(106, 13)
        Me.lblKernelProcess.TabIndex = 307
        Me.lblKernelProcess.Text = "Kernel Processed"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label64.Location = New System.Drawing.Point(167, 51)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(11, 13)
        Me.Label64.TabIndex = 308
        Me.Label64.Text = ":"
        '
        'lblLossOnKernel
        '
        Me.lblLossOnKernel.AutoSize = True
        Me.lblLossOnKernel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLossOnKernel.ForeColor = System.Drawing.Color.Black
        Me.lblLossOnKernel.Location = New System.Drawing.Point(7, 81)
        Me.lblLossOnKernel.Name = "lblLossOnKernel"
        Me.lblLossOnKernel.Size = New System.Drawing.Size(93, 13)
        Me.lblLossOnKernel.TabIndex = 309
        Me.lblLossOnKernel.Text = "Loss On Kernel"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label62.Location = New System.Drawing.Point(167, 81)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(11, 13)
        Me.Label62.TabIndex = 310
        Me.Label62.Text = ":"
        '
        'txtLossOnKernelToday
        '
        Me.txtLossOnKernelToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLossOnKernelToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLossOnKernelToday.Location = New System.Drawing.Point(182, 77)
        Me.txtLossOnKernelToday.MaxLength = 18
        Me.txtLossOnKernelToday.Name = "txtLossOnKernelToday"
        Me.txtLossOnKernelToday.Size = New System.Drawing.Size(110, 21)
        Me.txtLossOnKernelToday.TabIndex = 201
        '
        'txtKernelMonth
        '
        Me.txtKernelMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKernelMonth.Enabled = False
        Me.txtKernelMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKernelMonth.Location = New System.Drawing.Point(347, 47)
        Me.txtKernelMonth.MaxLength = 18
        Me.txtKernelMonth.Name = "txtKernelMonth"
        Me.txtKernelMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtKernelMonth.TabIndex = 313
        '
        'txtLossOnKernelMonth
        '
        Me.txtLossOnKernelMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLossOnKernelMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLossOnKernelMonth.Location = New System.Drawing.Point(347, 77)
        Me.txtLossOnKernelMonth.MaxLength = 18
        Me.txtLossOnKernelMonth.Name = "txtLossOnKernelMonth"
        Me.txtLossOnKernelMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtLossOnKernelMonth.TabIndex = 315
        '
        'txtKernelYear
        '
        Me.txtKernelYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKernelYear.Enabled = False
        Me.txtKernelYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKernelYear.Location = New System.Drawing.Point(512, 47)
        Me.txtKernelYear.MaxLength = 18
        Me.txtKernelYear.Name = "txtKernelYear"
        Me.txtKernelYear.Size = New System.Drawing.Size(110, 21)
        Me.txtKernelYear.TabIndex = 314
        '
        'lblThroughputMonthKgHr
        '
        Me.lblThroughputMonthKgHr.AutoSize = True
        Me.lblThroughputMonthKgHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThroughputMonthKgHr.ForeColor = System.Drawing.Color.Black
        Me.lblThroughputMonthKgHr.Location = New System.Drawing.Point(460, 261)
        Me.lblThroughputMonthKgHr.Name = "lblThroughputMonthKgHr"
        Me.lblThroughputMonthKgHr.Size = New System.Drawing.Size(46, 13)
        Me.lblThroughputMonthKgHr.TabIndex = 472
        Me.lblThroughputMonthKgHr.Text = "Ton/Hr"
        '
        'txtLossOnKernelYear
        '
        Me.txtLossOnKernelYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLossOnKernelYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLossOnKernelYear.Location = New System.Drawing.Point(512, 77)
        Me.txtLossOnKernelYear.MaxLength = 18
        Me.txtLossOnKernelYear.Name = "txtLossOnKernelYear"
        Me.txtLossOnKernelYear.Size = New System.Drawing.Size(110, 21)
        Me.txtLossOnKernelYear.TabIndex = 316
        '
        'lblThroughputKgHr
        '
        Me.lblThroughputKgHr.AutoSize = True
        Me.lblThroughputKgHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThroughputKgHr.ForeColor = System.Drawing.Color.Black
        Me.lblThroughputKgHr.Location = New System.Drawing.Point(293, 262)
        Me.lblThroughputKgHr.Name = "lblThroughputKgHr"
        Me.lblThroughputKgHr.Size = New System.Drawing.Size(46, 13)
        Me.lblThroughputKgHr.TabIndex = 471
        Me.lblThroughputKgHr.Text = "Ton/Hr"
        '
        'lblKernelYearTon
        '
        Me.lblKernelYearTon.AutoSize = True
        Me.lblKernelYearTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelYearTon.ForeColor = System.Drawing.Color.Black
        Me.lblKernelYearTon.Location = New System.Drawing.Point(624, 51)
        Me.lblKernelYearTon.Name = "lblKernelYearTon"
        Me.lblKernelYearTon.Size = New System.Drawing.Size(34, 13)
        Me.lblKernelYearTon.TabIndex = 320
        Me.lblKernelYearTon.Text = "Tons"
        '
        'lblThroughputYearKgHr
        '
        Me.lblThroughputYearKgHr.AutoSize = True
        Me.lblThroughputYearKgHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThroughputYearKgHr.ForeColor = System.Drawing.Color.Black
        Me.lblThroughputYearKgHr.Location = New System.Drawing.Point(625, 261)
        Me.lblThroughputYearKgHr.Name = "lblThroughputYearKgHr"
        Me.lblThroughputYearKgHr.Size = New System.Drawing.Size(46, 13)
        Me.lblThroughputYearKgHr.TabIndex = 470
        Me.lblThroughputYearKgHr.Text = "Ton/Hr"
        '
        'lblLossOnKernelYearTon
        '
        Me.lblLossOnKernelYearTon.AutoSize = True
        Me.lblLossOnKernelYearTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLossOnKernelYearTon.ForeColor = System.Drawing.Color.Black
        Me.lblLossOnKernelYearTon.Location = New System.Drawing.Point(626, 81)
        Me.lblLossOnKernelYearTon.Name = "lblLossOnKernelYearTon"
        Me.lblLossOnKernelYearTon.Size = New System.Drawing.Size(34, 13)
        Me.lblLossOnKernelYearTon.TabIndex = 321
        Me.lblLossOnKernelYearTon.Text = "Tons"
        '
        'txtThroughputYear
        '
        Me.txtThroughputYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThroughputYear.Enabled = False
        Me.txtThroughputYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThroughputYear.Location = New System.Drawing.Point(512, 257)
        Me.txtThroughputYear.MaxLength = 18
        Me.txtThroughputYear.Name = "txtThroughputYear"
        Me.txtThroughputYear.Size = New System.Drawing.Size(110, 21)
        Me.txtThroughputYear.TabIndex = 469
        '
        'lblKernelProcessTon
        '
        Me.lblKernelProcessTon.AutoSize = True
        Me.lblKernelProcessTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelProcessTon.ForeColor = System.Drawing.Color.Black
        Me.lblKernelProcessTon.Location = New System.Drawing.Point(295, 52)
        Me.lblKernelProcessTon.Name = "lblKernelProcessTon"
        Me.lblKernelProcessTon.Size = New System.Drawing.Size(34, 13)
        Me.lblKernelProcessTon.TabIndex = 323
        Me.lblKernelProcessTon.Text = "Tons"
        '
        'txtThroughputMonthTodate
        '
        Me.txtThroughputMonthTodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThroughputMonthTodate.Enabled = False
        Me.txtThroughputMonthTodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThroughputMonthTodate.Location = New System.Drawing.Point(347, 257)
        Me.txtThroughputMonthTodate.MaxLength = 18
        Me.txtThroughputMonthTodate.Name = "txtThroughputMonthTodate"
        Me.txtThroughputMonthTodate.Size = New System.Drawing.Size(110, 21)
        Me.txtThroughputMonthTodate.TabIndex = 468
        '
        'lblLossOnKernelTon
        '
        Me.lblLossOnKernelTon.AutoSize = True
        Me.lblLossOnKernelTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLossOnKernelTon.ForeColor = System.Drawing.Color.Black
        Me.lblLossOnKernelTon.Location = New System.Drawing.Point(294, 82)
        Me.lblLossOnKernelTon.Name = "lblLossOnKernelTon"
        Me.lblLossOnKernelTon.Size = New System.Drawing.Size(34, 13)
        Me.lblLossOnKernelTon.TabIndex = 324
        Me.lblLossOnKernelTon.Text = "Tons"
        '
        'txtThroughput
        '
        Me.txtThroughput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThroughput.Enabled = False
        Me.txtThroughput.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtThroughput.Location = New System.Drawing.Point(182, 257)
        Me.txtThroughput.MaxLength = 18
        Me.txtThroughput.Name = "txtThroughput"
        Me.txtThroughput.Size = New System.Drawing.Size(110, 21)
        Me.txtThroughput.TabIndex = 467
        '
        'lblKernelMonthTon
        '
        Me.lblKernelMonthTon.AutoSize = True
        Me.lblKernelMonthTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKernelMonthTon.ForeColor = System.Drawing.Color.Black
        Me.lblKernelMonthTon.Location = New System.Drawing.Point(459, 51)
        Me.lblKernelMonthTon.Name = "lblKernelMonthTon"
        Me.lblKernelMonthTon.Size = New System.Drawing.Size(34, 13)
        Me.lblKernelMonthTon.TabIndex = 325
        Me.lblKernelMonthTon.Text = "Tons"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(167, 261)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(11, 13)
        Me.Label66.TabIndex = 466
        Me.Label66.Text = ":"
        '
        'lblLossOnKernelMonthTon
        '
        Me.lblLossOnKernelMonthTon.AutoSize = True
        Me.lblLossOnKernelMonthTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLossOnKernelMonthTon.ForeColor = System.Drawing.Color.Black
        Me.lblLossOnKernelMonthTon.Location = New System.Drawing.Point(461, 81)
        Me.lblLossOnKernelMonthTon.Name = "lblLossOnKernelMonthTon"
        Me.lblLossOnKernelMonthTon.Size = New System.Drawing.Size(34, 13)
        Me.lblLossOnKernelMonthTon.TabIndex = 326
        Me.lblLossOnKernelMonthTon.Text = "Tons"
        '
        'lblThroughput
        '
        Me.lblThroughput.AutoSize = True
        Me.lblThroughput.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThroughput.ForeColor = System.Drawing.Color.Black
        Me.lblThroughput.Location = New System.Drawing.Point(6, 261)
        Me.lblThroughput.Name = "lblThroughput"
        Me.lblThroughput.Size = New System.Drawing.Size(72, 13)
        Me.lblThroughput.TabIndex = 465
        Me.lblThroughput.Text = "Throughput"
        '
        'lblProcessingToday
        '
        Me.lblProcessingToday.AutoSize = True
        Me.lblProcessingToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingToday.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingToday.Location = New System.Drawing.Point(208, 21)
        Me.lblProcessingToday.Name = "lblProcessingToday"
        Me.lblProcessingToday.Size = New System.Drawing.Size(42, 13)
        Me.lblProcessingToday.TabIndex = 329
        Me.lblProcessingToday.Text = "Today"
        '
        'lblEffectiveMonthHrs
        '
        Me.lblEffectiveMonthHrs.AutoSize = True
        Me.lblEffectiveMonthHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveMonthHrs.ForeColor = System.Drawing.Color.Black
        Me.lblEffectiveMonthHrs.Location = New System.Drawing.Point(460, 231)
        Me.lblEffectiveMonthHrs.Name = "lblEffectiveMonthHrs"
        Me.lblEffectiveMonthHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblEffectiveMonthHrs.TabIndex = 464
        Me.lblEffectiveMonthHrs.Text = "Hrs"
        '
        'lblProcessingMonthToDate
        '
        Me.lblProcessingMonthToDate.AutoSize = True
        Me.lblProcessingMonthToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingMonthToDate.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingMonthToDate.Location = New System.Drawing.Point(360, 21)
        Me.lblProcessingMonthToDate.Name = "lblProcessingMonthToDate"
        Me.lblProcessingMonthToDate.Size = New System.Drawing.Size(88, 13)
        Me.lblProcessingMonthToDate.TabIndex = 330
        Me.lblProcessingMonthToDate.Text = "Month To date"
        '
        'lblEffectiveProcessingHrs
        '
        Me.lblEffectiveProcessingHrs.AutoSize = True
        Me.lblEffectiveProcessingHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveProcessingHrs.ForeColor = System.Drawing.Color.Black
        Me.lblEffectiveProcessingHrs.Location = New System.Drawing.Point(293, 232)
        Me.lblEffectiveProcessingHrs.Name = "lblEffectiveProcessingHrs"
        Me.lblEffectiveProcessingHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblEffectiveProcessingHrs.TabIndex = 463
        Me.lblEffectiveProcessingHrs.Text = "Hrs"
        '
        'lblProcessingYearToDate
        '
        Me.lblProcessingYearToDate.AutoSize = True
        Me.lblProcessingYearToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingYearToDate.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingYearToDate.Location = New System.Drawing.Point(528, 21)
        Me.lblProcessingYearToDate.Name = "lblProcessingYearToDate"
        Me.lblProcessingYearToDate.Size = New System.Drawing.Size(80, 13)
        Me.lblProcessingYearToDate.TabIndex = 331
        Me.lblProcessingYearToDate.Text = "Year To date"
        '
        'lblEffectiveYearHrs
        '
        Me.lblEffectiveYearHrs.AutoSize = True
        Me.lblEffectiveYearHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveYearHrs.ForeColor = System.Drawing.Color.Black
        Me.lblEffectiveYearHrs.Location = New System.Drawing.Point(625, 231)
        Me.lblEffectiveYearHrs.Name = "lblEffectiveYearHrs"
        Me.lblEffectiveYearHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblEffectiveYearHrs.TabIndex = 462
        Me.lblEffectiveYearHrs.Text = "Hrs"
        '
        'txtLogRemarks
        '
        Me.txtLogRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLogRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLogRemarks.Location = New System.Drawing.Point(182, 349)
        Me.txtLogRemarks.MaxLength = 450
        Me.txtLogRemarks.Multiline = True
        Me.txtLogRemarks.Name = "txtLogRemarks"
        Me.txtLogRemarks.Size = New System.Drawing.Size(440, 39)
        Me.txtLogRemarks.TabIndex = 326
        '
        'txtEffectiveProcessingHoursYear
        '
        Me.txtEffectiveProcessingHoursYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEffectiveProcessingHoursYear.Enabled = False
        Me.txtEffectiveProcessingHoursYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEffectiveProcessingHoursYear.Location = New System.Drawing.Point(512, 227)
        Me.txtEffectiveProcessingHoursYear.MaxLength = 18
        Me.txtEffectiveProcessingHoursYear.Name = "txtEffectiveProcessingHoursYear"
        Me.txtEffectiveProcessingHoursYear.Size = New System.Drawing.Size(110, 21)
        Me.txtEffectiveProcessingHoursYear.TabIndex = 461
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.Color.Black
        Me.lblRemarks.Location = New System.Drawing.Point(5, 351)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(58, 13)
        Me.lblRemarks.TabIndex = 415
        Me.lblRemarks.Text = "Remarks"
        '
        'txtEffectiveProcessingHoursMonth
        '
        Me.txtEffectiveProcessingHoursMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEffectiveProcessingHoursMonth.Enabled = False
        Me.txtEffectiveProcessingHoursMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEffectiveProcessingHoursMonth.Location = New System.Drawing.Point(347, 227)
        Me.txtEffectiveProcessingHoursMonth.MaxLength = 18
        Me.txtEffectiveProcessingHoursMonth.Name = "txtEffectiveProcessingHoursMonth"
        Me.txtEffectiveProcessingHoursMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtEffectiveProcessingHoursMonth.TabIndex = 460
        '
        'Label114
        '
        Me.Label114.AutoSize = True
        Me.Label114.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.Location = New System.Drawing.Point(167, 351)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(11, 13)
        Me.Label114.TabIndex = 416
        Me.Label114.Text = ":"
        '
        'txtEffectiveProcessingHoursToday
        '
        Me.txtEffectiveProcessingHoursToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEffectiveProcessingHoursToday.Enabled = False
        Me.txtEffectiveProcessingHoursToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEffectiveProcessingHoursToday.Location = New System.Drawing.Point(182, 227)
        Me.txtEffectiveProcessingHoursToday.MaxLength = 18
        Me.txtEffectiveProcessingHoursToday.Name = "txtEffectiveProcessingHoursToday"
        Me.txtEffectiveProcessingHoursToday.Size = New System.Drawing.Size(110, 21)
        Me.txtEffectiveProcessingHoursToday.TabIndex = 459
        '
        'lblPKOProduction
        '
        Me.lblPKOProduction.AutoSize = True
        Me.lblPKOProduction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPKOProduction.ForeColor = System.Drawing.Color.Black
        Me.lblPKOProduction.Location = New System.Drawing.Point(6, 291)
        Me.lblPKOProduction.Name = "lblPKOProduction"
        Me.lblPKOProduction.Size = New System.Drawing.Size(95, 13)
        Me.lblPKOProduction.TabIndex = 417
        Me.lblPKOProduction.Text = "PKO Production"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(167, 231)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(11, 13)
        Me.Label59.TabIndex = 458
        Me.Label59.Text = ":"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(167, 291)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(11, 13)
        Me.Label31.TabIndex = 418
        Me.Label31.Text = ":"
        '
        'lblEffectiveProcessing
        '
        Me.lblEffectiveProcessing.AutoSize = True
        Me.lblEffectiveProcessing.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEffectiveProcessing.ForeColor = System.Drawing.Color.Black
        Me.lblEffectiveProcessing.Location = New System.Drawing.Point(6, 231)
        Me.lblEffectiveProcessing.Name = "lblEffectiveProcessing"
        Me.lblEffectiveProcessing.Size = New System.Drawing.Size(158, 13)
        Me.lblEffectiveProcessing.TabIndex = 457
        Me.lblEffectiveProcessing.Text = "Effective Processing Hours"
        '
        'lblMechanicalBreakDown
        '
        Me.lblMechanicalBreakDown.AutoSize = True
        Me.lblMechanicalBreakDown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMechanicalBreakDown.ForeColor = System.Drawing.Color.Black
        Me.lblMechanicalBreakDown.Location = New System.Drawing.Point(7, 111)
        Me.lblMechanicalBreakDown.Name = "lblMechanicalBreakDown"
        Me.lblMechanicalBreakDown.Size = New System.Drawing.Size(143, 13)
        Me.lblMechanicalBreakDown.TabIndex = 419
        Me.lblMechanicalBreakDown.Text = "Mechanical Break Down"
        '
        'lblTotalMonthHrs
        '
        Me.lblTotalMonthHrs.AutoSize = True
        Me.lblTotalMonthHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalMonthHrs.ForeColor = System.Drawing.Color.Black
        Me.lblTotalMonthHrs.Location = New System.Drawing.Point(460, 201)
        Me.lblTotalMonthHrs.Name = "lblTotalMonthHrs"
        Me.lblTotalMonthHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblTotalMonthHrs.TabIndex = 456
        Me.lblTotalMonthHrs.Text = "Hrs"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(167, 111)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(11, 13)
        Me.Label29.TabIndex = 420
        Me.Label29.Text = ":"
        '
        'lblTotalBreakDownHrs
        '
        Me.lblTotalBreakDownHrs.AutoSize = True
        Me.lblTotalBreakDownHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBreakDownHrs.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBreakDownHrs.Location = New System.Drawing.Point(293, 202)
        Me.lblTotalBreakDownHrs.Name = "lblTotalBreakDownHrs"
        Me.lblTotalBreakDownHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblTotalBreakDownHrs.TabIndex = 455
        Me.lblTotalBreakDownHrs.Text = "Hrs"
        '
        'txtPKOProductionToday
        '
        Me.txtPKOProductionToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPKOProductionToday.Enabled = False
        Me.txtPKOProductionToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPKOProductionToday.Location = New System.Drawing.Point(182, 287)
        Me.txtPKOProductionToday.MaxLength = 18
        Me.txtPKOProductionToday.Name = "txtPKOProductionToday"
        Me.txtPKOProductionToday.Size = New System.Drawing.Size(110, 21)
        Me.txtPKOProductionToday.TabIndex = 421
        Me.txtPKOProductionToday.TabStop = False
        '
        'lblTotalYearsHrs
        '
        Me.lblTotalYearsHrs.AutoSize = True
        Me.lblTotalYearsHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalYearsHrs.ForeColor = System.Drawing.Color.Black
        Me.lblTotalYearsHrs.Location = New System.Drawing.Point(625, 201)
        Me.lblTotalYearsHrs.Name = "lblTotalYearsHrs"
        Me.lblTotalYearsHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblTotalYearsHrs.TabIndex = 454
        Me.lblTotalYearsHrs.Text = "Hrs"
        '
        'txtMechanicalBreakDownToday
        '
        Me.txtMechanicalBreakDownToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMechanicalBreakDownToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMechanicalBreakDownToday.Location = New System.Drawing.Point(182, 107)
        Me.txtMechanicalBreakDownToday.MaxLength = 18
        Me.txtMechanicalBreakDownToday.Name = "txtMechanicalBreakDownToday"
        Me.txtMechanicalBreakDownToday.Size = New System.Drawing.Size(110, 21)
        Me.txtMechanicalBreakDownToday.TabIndex = 317
        '
        'txtTotalBreakDownYear
        '
        Me.txtTotalBreakDownYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBreakDownYear.Enabled = False
        Me.txtTotalBreakDownYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBreakDownYear.Location = New System.Drawing.Point(512, 197)
        Me.txtTotalBreakDownYear.MaxLength = 18
        Me.txtTotalBreakDownYear.Name = "txtTotalBreakDownYear"
        Me.txtTotalBreakDownYear.Size = New System.Drawing.Size(110, 21)
        Me.txtTotalBreakDownYear.TabIndex = 453
        '
        'txtPKOProductionMonthTodate
        '
        Me.txtPKOProductionMonthTodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPKOProductionMonthTodate.Enabled = False
        Me.txtPKOProductionMonthTodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPKOProductionMonthTodate.Location = New System.Drawing.Point(347, 287)
        Me.txtPKOProductionMonthTodate.MaxLength = 18
        Me.txtPKOProductionMonthTodate.Name = "txtPKOProductionMonthTodate"
        Me.txtPKOProductionMonthTodate.Size = New System.Drawing.Size(110, 21)
        Me.txtPKOProductionMonthTodate.TabIndex = 423
        '
        'txtTotalBreakDownMonth
        '
        Me.txtTotalBreakDownMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBreakDownMonth.Enabled = False
        Me.txtTotalBreakDownMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBreakDownMonth.Location = New System.Drawing.Point(347, 197)
        Me.txtTotalBreakDownMonth.MaxLength = 18
        Me.txtTotalBreakDownMonth.Name = "txtTotalBreakDownMonth"
        Me.txtTotalBreakDownMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtTotalBreakDownMonth.TabIndex = 452
        '
        'txtMechanicalBreakDownMonth
        '
        Me.txtMechanicalBreakDownMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMechanicalBreakDownMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMechanicalBreakDownMonth.Location = New System.Drawing.Point(347, 107)
        Me.txtMechanicalBreakDownMonth.MaxLength = 18
        Me.txtMechanicalBreakDownMonth.Name = "txtMechanicalBreakDownMonth"
        Me.txtMechanicalBreakDownMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtMechanicalBreakDownMonth.TabIndex = 318
        '
        'txtTotalBreakDownToday
        '
        Me.txtTotalBreakDownToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalBreakDownToday.Enabled = False
        Me.txtTotalBreakDownToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalBreakDownToday.Location = New System.Drawing.Point(182, 197)
        Me.txtTotalBreakDownToday.MaxLength = 18
        Me.txtTotalBreakDownToday.Name = "txtTotalBreakDownToday"
        Me.txtTotalBreakDownToday.Size = New System.Drawing.Size(110, 21)
        Me.txtTotalBreakDownToday.TabIndex = 451
        '
        'txtPKOProductionYear
        '
        Me.txtPKOProductionYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPKOProductionYear.Enabled = False
        Me.txtPKOProductionYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPKOProductionYear.Location = New System.Drawing.Point(512, 287)
        Me.txtPKOProductionYear.MaxLength = 18
        Me.txtPKOProductionYear.Name = "txtPKOProductionYear"
        Me.txtPKOProductionYear.Size = New System.Drawing.Size(110, 21)
        Me.txtPKOProductionYear.TabIndex = 425
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(167, 201)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(11, 13)
        Me.Label45.TabIndex = 450
        Me.Label45.Text = ":"
        '
        'txtMechanicalBreakDownYear
        '
        Me.txtMechanicalBreakDownYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMechanicalBreakDownYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMechanicalBreakDownYear.Location = New System.Drawing.Point(512, 107)
        Me.txtMechanicalBreakDownYear.MaxLength = 18
        Me.txtMechanicalBreakDownYear.Name = "txtMechanicalBreakDownYear"
        Me.txtMechanicalBreakDownYear.Size = New System.Drawing.Size(110, 21)
        Me.txtMechanicalBreakDownYear.TabIndex = 319
        '
        'lblTotalBreakDown
        '
        Me.lblTotalBreakDown.AutoSize = True
        Me.lblTotalBreakDown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBreakDown.ForeColor = System.Drawing.Color.Black
        Me.lblTotalBreakDown.Location = New System.Drawing.Point(6, 201)
        Me.lblTotalBreakDown.Name = "lblTotalBreakDown"
        Me.lblTotalBreakDown.Size = New System.Drawing.Size(109, 13)
        Me.lblTotalBreakDown.TabIndex = 449
        Me.lblTotalBreakDown.Text = "Total Break Down"
        '
        'lblPKOProductionYearTon
        '
        Me.lblPKOProductionYearTon.AutoSize = True
        Me.lblPKOProductionYearTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPKOProductionYearTon.ForeColor = System.Drawing.Color.Black
        Me.lblPKOProductionYearTon.Location = New System.Drawing.Point(623, 291)
        Me.lblPKOProductionYearTon.Name = "lblPKOProductionYearTon"
        Me.lblPKOProductionYearTon.Size = New System.Drawing.Size(34, 13)
        Me.lblPKOProductionYearTon.TabIndex = 427
        Me.lblPKOProductionYearTon.Text = "Tons"
        '
        'lblProcessingMonthHrs
        '
        Me.lblProcessingMonthHrs.AutoSize = True
        Me.lblProcessingMonthHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingMonthHrs.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingMonthHrs.Location = New System.Drawing.Point(460, 171)
        Me.lblProcessingMonthHrs.Name = "lblProcessingMonthHrs"
        Me.lblProcessingMonthHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblProcessingMonthHrs.TabIndex = 448
        Me.lblProcessingMonthHrs.Text = "Hrs"
        '
        'lblMechanicalYearHrs
        '
        Me.lblMechanicalYearHrs.AutoSize = True
        Me.lblMechanicalYearHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMechanicalYearHrs.ForeColor = System.Drawing.Color.Black
        Me.lblMechanicalYearHrs.Location = New System.Drawing.Point(626, 111)
        Me.lblMechanicalYearHrs.Name = "lblMechanicalYearHrs"
        Me.lblMechanicalYearHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblMechanicalYearHrs.TabIndex = 428
        Me.lblMechanicalYearHrs.Text = "Hrs"
        '
        'lblProcessingHrs
        '
        Me.lblProcessingHrs.AutoSize = True
        Me.lblProcessingHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingHrs.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingHrs.Location = New System.Drawing.Point(293, 172)
        Me.lblProcessingHrs.Name = "lblProcessingHrs"
        Me.lblProcessingHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblProcessingHrs.TabIndex = 447
        Me.lblProcessingHrs.Text = "Hrs"
        '
        'lblPKOProductionTon
        '
        Me.lblPKOProductionTon.AutoSize = True
        Me.lblPKOProductionTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPKOProductionTon.ForeColor = System.Drawing.Color.Black
        Me.lblPKOProductionTon.Location = New System.Drawing.Point(294, 292)
        Me.lblPKOProductionTon.Name = "lblPKOProductionTon"
        Me.lblPKOProductionTon.Size = New System.Drawing.Size(34, 13)
        Me.lblPKOProductionTon.TabIndex = 429
        Me.lblPKOProductionTon.Text = "Tons"
        '
        'lblProcessingYearHrs
        '
        Me.lblProcessingYearHrs.AutoSize = True
        Me.lblProcessingYearHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingYearHrs.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingYearHrs.Location = New System.Drawing.Point(625, 171)
        Me.lblProcessingYearHrs.Name = "lblProcessingYearHrs"
        Me.lblProcessingYearHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblProcessingYearHrs.TabIndex = 446
        Me.lblProcessingYearHrs.Text = "Hrs"
        '
        'lblMechanicalHrs
        '
        Me.lblMechanicalHrs.AutoSize = True
        Me.lblMechanicalHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMechanicalHrs.ForeColor = System.Drawing.Color.Black
        Me.lblMechanicalHrs.Location = New System.Drawing.Point(294, 112)
        Me.lblMechanicalHrs.Name = "lblMechanicalHrs"
        Me.lblMechanicalHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblMechanicalHrs.TabIndex = 430
        Me.lblMechanicalHrs.Text = "Hrs"
        '
        'txtProcessingBreakDownYear
        '
        Me.txtProcessingBreakDownYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingBreakDownYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingBreakDownYear.Location = New System.Drawing.Point(512, 167)
        Me.txtProcessingBreakDownYear.MaxLength = 18
        Me.txtProcessingBreakDownYear.Name = "txtProcessingBreakDownYear"
        Me.txtProcessingBreakDownYear.Size = New System.Drawing.Size(110, 21)
        Me.txtProcessingBreakDownYear.TabIndex = 325
        '
        'lblPKOProductionMonthTon
        '
        Me.lblPKOProductionMonthTon.AutoSize = True
        Me.lblPKOProductionMonthTon.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPKOProductionMonthTon.ForeColor = System.Drawing.Color.Black
        Me.lblPKOProductionMonthTon.Location = New System.Drawing.Point(458, 291)
        Me.lblPKOProductionMonthTon.Name = "lblPKOProductionMonthTon"
        Me.lblPKOProductionMonthTon.Size = New System.Drawing.Size(34, 13)
        Me.lblPKOProductionMonthTon.TabIndex = 431
        Me.lblPKOProductionMonthTon.Text = "Tons"
        '
        'txtProcessingBreakDownMonth
        '
        Me.txtProcessingBreakDownMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingBreakDownMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingBreakDownMonth.Location = New System.Drawing.Point(347, 167)
        Me.txtProcessingBreakDownMonth.MaxLength = 18
        Me.txtProcessingBreakDownMonth.Name = "txtProcessingBreakDownMonth"
        Me.txtProcessingBreakDownMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtProcessingBreakDownMonth.TabIndex = 324
        '
        'lblMechanicalMonthHrs
        '
        Me.lblMechanicalMonthHrs.AutoSize = True
        Me.lblMechanicalMonthHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMechanicalMonthHrs.ForeColor = System.Drawing.Color.Black
        Me.lblMechanicalMonthHrs.Location = New System.Drawing.Point(461, 111)
        Me.lblMechanicalMonthHrs.Name = "lblMechanicalMonthHrs"
        Me.lblMechanicalMonthHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblMechanicalMonthHrs.TabIndex = 432
        Me.lblMechanicalMonthHrs.Text = "Hrs"
        '
        'txtProcessingBreakDownToday
        '
        Me.txtProcessingBreakDownToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcessingBreakDownToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessingBreakDownToday.Location = New System.Drawing.Point(182, 167)
        Me.txtProcessingBreakDownToday.MaxLength = 18
        Me.txtProcessingBreakDownToday.Name = "txtProcessingBreakDownToday"
        Me.txtProcessingBreakDownToday.Size = New System.Drawing.Size(110, 21)
        Me.txtProcessingBreakDownToday.TabIndex = 323
        '
        'lblElectricalBreakDown
        '
        Me.lblElectricalBreakDown.AutoSize = True
        Me.lblElectricalBreakDown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElectricalBreakDown.ForeColor = System.Drawing.Color.Black
        Me.lblElectricalBreakDown.Location = New System.Drawing.Point(6, 141)
        Me.lblElectricalBreakDown.Name = "lblElectricalBreakDown"
        Me.lblElectricalBreakDown.Size = New System.Drawing.Size(132, 13)
        Me.lblElectricalBreakDown.TabIndex = 433
        Me.lblElectricalBreakDown.Text = "Electrical Break Down"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(167, 171)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(11, 13)
        Me.Label40.TabIndex = 442
        Me.Label40.Text = ":"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(167, 141)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(11, 13)
        Me.Label35.TabIndex = 434
        Me.Label35.Text = ":"
        '
        'lblProcessingBreakDown
        '
        Me.lblProcessingBreakDown.AutoSize = True
        Me.lblProcessingBreakDown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProcessingBreakDown.ForeColor = System.Drawing.Color.Black
        Me.lblProcessingBreakDown.Location = New System.Drawing.Point(6, 171)
        Me.lblProcessingBreakDown.Name = "lblProcessingBreakDown"
        Me.lblProcessingBreakDown.Size = New System.Drawing.Size(142, 13)
        Me.lblProcessingBreakDown.TabIndex = 441
        Me.lblProcessingBreakDown.Text = "Processing Break Down"
        '
        'txtElectricalBreakDownToday
        '
        Me.txtElectricalBreakDownToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElectricalBreakDownToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtElectricalBreakDownToday.Location = New System.Drawing.Point(182, 137)
        Me.txtElectricalBreakDownToday.MaxLength = 18
        Me.txtElectricalBreakDownToday.Name = "txtElectricalBreakDownToday"
        Me.txtElectricalBreakDownToday.Size = New System.Drawing.Size(110, 21)
        Me.txtElectricalBreakDownToday.TabIndex = 320
        '
        'lblElectricalMonthHrs
        '
        Me.lblElectricalMonthHrs.AutoSize = True
        Me.lblElectricalMonthHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElectricalMonthHrs.ForeColor = System.Drawing.Color.Black
        Me.lblElectricalMonthHrs.Location = New System.Drawing.Point(460, 141)
        Me.lblElectricalMonthHrs.Name = "lblElectricalMonthHrs"
        Me.lblElectricalMonthHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblElectricalMonthHrs.TabIndex = 440
        Me.lblElectricalMonthHrs.Text = "Hrs"
        '
        'txtElectricalBreakDownMonth
        '
        Me.txtElectricalBreakDownMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElectricalBreakDownMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtElectricalBreakDownMonth.Location = New System.Drawing.Point(347, 137)
        Me.txtElectricalBreakDownMonth.MaxLength = 18
        Me.txtElectricalBreakDownMonth.Name = "txtElectricalBreakDownMonth"
        Me.txtElectricalBreakDownMonth.Size = New System.Drawing.Size(110, 21)
        Me.txtElectricalBreakDownMonth.TabIndex = 321
        '
        'lblElectricalHrs
        '
        Me.lblElectricalHrs.AutoSize = True
        Me.lblElectricalHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElectricalHrs.ForeColor = System.Drawing.Color.Black
        Me.lblElectricalHrs.Location = New System.Drawing.Point(293, 142)
        Me.lblElectricalHrs.Name = "lblElectricalHrs"
        Me.lblElectricalHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblElectricalHrs.TabIndex = 439
        Me.lblElectricalHrs.Text = "Hrs"
        '
        'txtElectricalBreakDownYear
        '
        Me.txtElectricalBreakDownYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtElectricalBreakDownYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtElectricalBreakDownYear.Location = New System.Drawing.Point(512, 137)
        Me.txtElectricalBreakDownYear.MaxLength = 18
        Me.txtElectricalBreakDownYear.Name = "txtElectricalBreakDownYear"
        Me.txtElectricalBreakDownYear.Size = New System.Drawing.Size(110, 21)
        Me.txtElectricalBreakDownYear.TabIndex = 322
        '
        'lblElectricalYearHrs
        '
        Me.lblElectricalYearHrs.AutoSize = True
        Me.lblElectricalYearHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblElectricalYearHrs.ForeColor = System.Drawing.Color.Black
        Me.lblElectricalYearHrs.Location = New System.Drawing.Point(625, 141)
        Me.lblElectricalYearHrs.Name = "lblElectricalYearHrs"
        Me.lblElectricalYearHrs.Size = New System.Drawing.Size(26, 13)
        Me.lblElectricalYearHrs.TabIndex = 438
        Me.lblElectricalYearHrs.Text = "Hrs"
        '
        'tbPressInfo
        '
        Me.tbPressInfo.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tbPressInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tbPressInfo.Controls.Add(Me.Label42)
        Me.tbPressInfo.Controls.Add(Me.Label43)
        Me.tbPressInfo.Controls.Add(Me.Label39)
        Me.tbPressInfo.Controls.Add(Me.Label41)
        Me.tbPressInfo.Controls.Add(Me.lblUtiliStage2MonthPer)
        Me.tbPressInfo.Controls.Add(Me.lblUtilisStage1MonthPer)
        Me.tbPressInfo.Controls.Add(Me.Label36)
        Me.tbPressInfo.Controls.Add(Me.Label33)
        Me.tbPressInfo.Controls.Add(Me.Label32)
        Me.tbPressInfo.Controls.Add(Me.Label30)
        Me.tbPressInfo.Controls.Add(Me.Label28)
        Me.tbPressInfo.Controls.Add(Me.Label27)
        Me.tbPressInfo.Controls.Add(Me.lblUtilisationStage1)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage1)
        Me.tbPressInfo.Controls.Add(Me.lblTotalPHStage1)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage2Kg)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage1MonthKg)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage2MonthKg)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage1YrKg)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage2YrKg)
        Me.tbPressInfo.Controls.Add(Me.lblUtilisationStage2)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage2)
        Me.tbPressInfo.Controls.Add(Me.txtutilstage2yeartodate)
        Me.tbPressInfo.Controls.Add(Me.txtutilstage2monthtodate)
        Me.tbPressInfo.Controls.Add(Me.txtutilstage2)
        Me.tbPressInfo.Controls.Add(Me.Label83)
        Me.tbPressInfo.Controls.Add(Me.txtutilstage1yeartodate)
        Me.tbPressInfo.Controls.Add(Me.txtutilstage1monthtodate)
        Me.tbPressInfo.Controls.Add(Me.txtutilstage1today)
        Me.tbPressInfo.Controls.Add(Me.Label88)
        Me.tbPressInfo.Controls.Add(Me.lblUtilisation)
        Me.tbPressInfo.Controls.Add(Me.txtAPTStage2yeartodate)
        Me.tbPressInfo.Controls.Add(Me.txtAPTstage2monthtodae)
        Me.tbPressInfo.Controls.Add(Me.txtAPTstage2today)
        Me.tbPressInfo.Controls.Add(Me.Label93)
        Me.tbPressInfo.Controls.Add(Me.lblAvgPressStage1Kg)
        Me.tbPressInfo.Controls.Add(Me.txtAPTstage1yeartodate)
        Me.tbPressInfo.Controls.Add(Me.txtAPHstage1monthtodate)
        Me.tbPressInfo.Controls.Add(Me.txtAPTstage1today)
        Me.tbPressInfo.Controls.Add(Me.Label98)
        Me.tbPressInfo.Controls.Add(Me.lblAveragePressThroughput)
        Me.tbPressInfo.Controls.Add(Me.lblPressYear)
        Me.tbPressInfo.Controls.Add(Me.lblPressMonth)
        Me.tbPressInfo.Controls.Add(Me.lblPressToday)
        Me.tbPressInfo.Controls.Add(Me.txtStage2yearTodate)
        Me.tbPressInfo.Controls.Add(Me.txtTPHYearTodateStage1)
        Me.tbPressInfo.Controls.Add(Me.txtStage2monthTodate)
        Me.tbPressInfo.Controls.Add(Me.txtTPHMonthTodateStage1)
        Me.tbPressInfo.Controls.Add(Me.txtStage2TodayTPH)
        Me.tbPressInfo.Controls.Add(Me.txtTPHTodaystage1)
        Me.tbPressInfo.Controls.Add(Me.Label109)
        Me.tbPressInfo.Controls.Add(Me.lblTotalPHStage2)
        Me.tbPressInfo.Controls.Add(Me.Label111)
        Me.tbPressInfo.Controls.Add(Me.lblTotalPressHours)
        Me.tbPressInfo.Controls.Add(Me.GroupBox6)
        Me.tbPressInfo.Location = New System.Drawing.Point(4, 22)
        Me.tbPressInfo.Name = "tbPressInfo"
        Me.tbPressInfo.Size = New System.Drawing.Size(773, 453)
        Me.tbPressInfo.TabIndex = 3
        Me.tbPressInfo.Text = "Press Info"
        Me.tbPressInfo.UseVisualStyleBackColor = True
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.Black
        Me.Label42.Location = New System.Drawing.Point(706, 424)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(19, 13)
        Me.Label42.TabIndex = 679
        Me.Label42.Text = "%"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.Black
        Me.Label43.Location = New System.Drawing.Point(706, 399)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(19, 13)
        Me.Label43.TabIndex = 678
        Me.Label43.Text = "%"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Black
        Me.Label39.Location = New System.Drawing.Point(530, 424)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(19, 13)
        Me.Label39.TabIndex = 677
        Me.Label39.Text = "%"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.Black
        Me.Label41.Location = New System.Drawing.Point(530, 399)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(19, 13)
        Me.Label41.TabIndex = 676
        Me.Label41.Text = "%"
        '
        'lblUtiliStage2MonthPer
        '
        Me.lblUtiliStage2MonthPer.AutoSize = True
        Me.lblUtiliStage2MonthPer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtiliStage2MonthPer.ForeColor = System.Drawing.Color.Black
        Me.lblUtiliStage2MonthPer.Location = New System.Drawing.Point(363, 424)
        Me.lblUtiliStage2MonthPer.Name = "lblUtiliStage2MonthPer"
        Me.lblUtiliStage2MonthPer.Size = New System.Drawing.Size(19, 13)
        Me.lblUtiliStage2MonthPer.TabIndex = 675
        Me.lblUtiliStage2MonthPer.Text = "%"
        '
        'lblUtilisStage1MonthPer
        '
        Me.lblUtilisStage1MonthPer.AutoSize = True
        Me.lblUtilisStage1MonthPer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilisStage1MonthPer.ForeColor = System.Drawing.Color.Black
        Me.lblUtilisStage1MonthPer.Location = New System.Drawing.Point(363, 399)
        Me.lblUtilisStage1MonthPer.Name = "lblUtilisStage1MonthPer"
        Me.lblUtilisStage1MonthPer.Size = New System.Drawing.Size(19, 13)
        Me.lblUtilisStage1MonthPer.TabIndex = 674
        Me.lblUtilisStage1MonthPer.Text = "%"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(705, 324)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(26, 13)
        Me.Label36.TabIndex = 634
        Me.Label36.Text = "Hrs"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(705, 299)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(26, 13)
        Me.Label33.TabIndex = 633
        Me.Label33.Text = "Hrs"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(530, 324)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(26, 13)
        Me.Label32.TabIndex = 632
        Me.Label32.Text = "Hrs"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(532, 299)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(26, 13)
        Me.Label30.TabIndex = 631
        Me.Label30.Text = "Hrs"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(363, 324)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(26, 13)
        Me.Label28.TabIndex = 630
        Me.Label28.Text = "Hrs"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(362, 299)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(26, 13)
        Me.Label27.TabIndex = 629
        Me.Label27.Text = "Hrs"
        '
        'lblUtilisationStage1
        '
        Me.lblUtilisationStage1.AutoSize = True
        Me.lblUtilisationStage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilisationStage1.ForeColor = System.Drawing.Color.Black
        Me.lblUtilisationStage1.Location = New System.Drawing.Point(183, 399)
        Me.lblUtilisationStage1.Name = "lblUtilisationStage1"
        Me.lblUtilisationStage1.Size = New System.Drawing.Size(47, 13)
        Me.lblUtilisationStage1.TabIndex = 628
        Me.lblUtilisationStage1.Text = "Stage1"
        '
        'lblAvgPressStage1
        '
        Me.lblAvgPressStage1.AutoSize = True
        Me.lblAvgPressStage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage1.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage1.Location = New System.Drawing.Point(184, 349)
        Me.lblAvgPressStage1.Name = "lblAvgPressStage1"
        Me.lblAvgPressStage1.Size = New System.Drawing.Size(47, 13)
        Me.lblAvgPressStage1.TabIndex = 627
        Me.lblAvgPressStage1.Text = "Stage1"
        '
        'lblTotalPHStage1
        '
        Me.lblTotalPHStage1.AutoSize = True
        Me.lblTotalPHStage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPHStage1.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPHStage1.Location = New System.Drawing.Point(184, 299)
        Me.lblTotalPHStage1.Name = "lblTotalPHStage1"
        Me.lblTotalPHStage1.Size = New System.Drawing.Size(47, 13)
        Me.lblTotalPHStage1.TabIndex = 626
        Me.lblTotalPHStage1.Text = "Stage1"
        '
        'lblAvgPressStage2Kg
        '
        Me.lblAvgPressStage2Kg.AutoSize = True
        Me.lblAvgPressStage2Kg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage2Kg.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage2Kg.Location = New System.Drawing.Point(363, 374)
        Me.lblAvgPressStage2Kg.Name = "lblAvgPressStage2Kg"
        Me.lblAvgPressStage2Kg.Size = New System.Drawing.Size(40, 13)
        Me.lblAvgPressStage2Kg.TabIndex = 625
        Me.lblAvgPressStage2Kg.Text = "Kg/Hr"
        '
        'lblAvgPressStage1MonthKg
        '
        Me.lblAvgPressStage1MonthKg.AutoSize = True
        Me.lblAvgPressStage1MonthKg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage1MonthKg.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage1MonthKg.Location = New System.Drawing.Point(530, 349)
        Me.lblAvgPressStage1MonthKg.Name = "lblAvgPressStage1MonthKg"
        Me.lblAvgPressStage1MonthKg.Size = New System.Drawing.Size(40, 13)
        Me.lblAvgPressStage1MonthKg.TabIndex = 624
        Me.lblAvgPressStage1MonthKg.Text = "Kg/Hr"
        '
        'lblAvgPressStage2MonthKg
        '
        Me.lblAvgPressStage2MonthKg.AutoSize = True
        Me.lblAvgPressStage2MonthKg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage2MonthKg.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage2MonthKg.Location = New System.Drawing.Point(530, 374)
        Me.lblAvgPressStage2MonthKg.Name = "lblAvgPressStage2MonthKg"
        Me.lblAvgPressStage2MonthKg.Size = New System.Drawing.Size(40, 13)
        Me.lblAvgPressStage2MonthKg.TabIndex = 623
        Me.lblAvgPressStage2MonthKg.Text = "Kg/Hr"
        '
        'lblAvgPressStage1YrKg
        '
        Me.lblAvgPressStage1YrKg.AutoSize = True
        Me.lblAvgPressStage1YrKg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage1YrKg.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage1YrKg.Location = New System.Drawing.Point(706, 349)
        Me.lblAvgPressStage1YrKg.Name = "lblAvgPressStage1YrKg"
        Me.lblAvgPressStage1YrKg.Size = New System.Drawing.Size(40, 13)
        Me.lblAvgPressStage1YrKg.TabIndex = 622
        Me.lblAvgPressStage1YrKg.Text = "Kg/Hr"
        '
        'lblAvgPressStage2YrKg
        '
        Me.lblAvgPressStage2YrKg.AutoSize = True
        Me.lblAvgPressStage2YrKg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage2YrKg.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage2YrKg.Location = New System.Drawing.Point(706, 374)
        Me.lblAvgPressStage2YrKg.Name = "lblAvgPressStage2YrKg"
        Me.lblAvgPressStage2YrKg.Size = New System.Drawing.Size(40, 13)
        Me.lblAvgPressStage2YrKg.TabIndex = 621
        Me.lblAvgPressStage2YrKg.Text = "Kg/Hr"
        '
        'lblUtilisationStage2
        '
        Me.lblUtilisationStage2.AutoSize = True
        Me.lblUtilisationStage2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilisationStage2.ForeColor = System.Drawing.Color.Black
        Me.lblUtilisationStage2.Location = New System.Drawing.Point(183, 424)
        Me.lblUtilisationStage2.Name = "lblUtilisationStage2"
        Me.lblUtilisationStage2.Size = New System.Drawing.Size(47, 13)
        Me.lblUtilisationStage2.TabIndex = 615
        Me.lblUtilisationStage2.Text = "Stage2"
        '
        'lblAvgPressStage2
        '
        Me.lblAvgPressStage2.AutoSize = True
        Me.lblAvgPressStage2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage2.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage2.Location = New System.Drawing.Point(184, 374)
        Me.lblAvgPressStage2.Name = "lblAvgPressStage2"
        Me.lblAvgPressStage2.Size = New System.Drawing.Size(47, 13)
        Me.lblAvgPressStage2.TabIndex = 614
        Me.lblAvgPressStage2.Text = "Stage2"
        '
        'txtutilstage2yeartodate
        '
        Me.txtutilstage2yeartodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtutilstage2yeartodate.Enabled = False
        Me.txtutilstage2yeartodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilstage2yeartodate.Location = New System.Drawing.Point(592, 420)
        Me.txtutilstage2yeartodate.MaxLength = 18
        Me.txtutilstage2yeartodate.Name = "txtutilstage2yeartodate"
        Me.txtutilstage2yeartodate.Size = New System.Drawing.Size(110, 21)
        Me.txtutilstage2yeartodate.TabIndex = 612
        '
        'txtutilstage2monthtodate
        '
        Me.txtutilstage2monthtodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtutilstage2monthtodate.Enabled = False
        Me.txtutilstage2monthtodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilstage2monthtodate.Location = New System.Drawing.Point(418, 420)
        Me.txtutilstage2monthtodate.MaxLength = 18
        Me.txtutilstage2monthtodate.Name = "txtutilstage2monthtodate"
        Me.txtutilstage2monthtodate.Size = New System.Drawing.Size(110, 21)
        Me.txtutilstage2monthtodate.TabIndex = 611
        '
        'txtutilstage2
        '
        Me.txtutilstage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtutilstage2.Enabled = False
        Me.txtutilstage2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilstage2.Location = New System.Drawing.Point(250, 420)
        Me.txtutilstage2.MaxLength = 18
        Me.txtutilstage2.Name = "txtutilstage2"
        Me.txtutilstage2.Size = New System.Drawing.Size(110, 21)
        Me.txtutilstage2.TabIndex = 610
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label83.Location = New System.Drawing.Point(230, 424)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(11, 13)
        Me.Label83.TabIndex = 609
        Me.Label83.Text = ":"
        '
        'txtutilstage1yeartodate
        '
        Me.txtutilstage1yeartodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtutilstage1yeartodate.Enabled = False
        Me.txtutilstage1yeartodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilstage1yeartodate.Location = New System.Drawing.Point(592, 395)
        Me.txtutilstage1yeartodate.MaxLength = 18
        Me.txtutilstage1yeartodate.Name = "txtutilstage1yeartodate"
        Me.txtutilstage1yeartodate.Size = New System.Drawing.Size(110, 21)
        Me.txtutilstage1yeartodate.TabIndex = 607
        '
        'txtutilstage1monthtodate
        '
        Me.txtutilstage1monthtodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtutilstage1monthtodate.Enabled = False
        Me.txtutilstage1monthtodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilstage1monthtodate.Location = New System.Drawing.Point(418, 395)
        Me.txtutilstage1monthtodate.MaxLength = 18
        Me.txtutilstage1monthtodate.Name = "txtutilstage1monthtodate"
        Me.txtutilstage1monthtodate.Size = New System.Drawing.Size(110, 21)
        Me.txtutilstage1monthtodate.TabIndex = 606
        '
        'txtutilstage1today
        '
        Me.txtutilstage1today.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtutilstage1today.Enabled = False
        Me.txtutilstage1today.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtutilstage1today.Location = New System.Drawing.Point(250, 395)
        Me.txtutilstage1today.MaxLength = 18
        Me.txtutilstage1today.Name = "txtutilstage1today"
        Me.txtutilstage1today.Size = New System.Drawing.Size(110, 21)
        Me.txtutilstage1today.TabIndex = 605
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(230, 399)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(11, 13)
        Me.Label88.TabIndex = 604
        Me.Label88.Text = ":"
        '
        'lblUtilisation
        '
        Me.lblUtilisation.AutoSize = True
        Me.lblUtilisation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUtilisation.ForeColor = System.Drawing.Color.Black
        Me.lblUtilisation.Location = New System.Drawing.Point(22, 399)
        Me.lblUtilisation.Name = "lblUtilisation"
        Me.lblUtilisation.Size = New System.Drawing.Size(166, 13)
        Me.lblUtilisation.TabIndex = 603
        Me.lblUtilisation.Text = "Utilisation                          "
        '
        'txtAPTStage2yeartodate
        '
        Me.txtAPTStage2yeartodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPTStage2yeartodate.Enabled = False
        Me.txtAPTStage2yeartodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPTStage2yeartodate.Location = New System.Drawing.Point(592, 370)
        Me.txtAPTStage2yeartodate.MaxLength = 18
        Me.txtAPTStage2yeartodate.Name = "txtAPTStage2yeartodate"
        Me.txtAPTStage2yeartodate.Size = New System.Drawing.Size(110, 21)
        Me.txtAPTStage2yeartodate.TabIndex = 602
        '
        'txtAPTstage2monthtodae
        '
        Me.txtAPTstage2monthtodae.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPTstage2monthtodae.Enabled = False
        Me.txtAPTstage2monthtodae.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPTstage2monthtodae.Location = New System.Drawing.Point(418, 370)
        Me.txtAPTstage2monthtodae.MaxLength = 18
        Me.txtAPTstage2monthtodae.Name = "txtAPTstage2monthtodae"
        Me.txtAPTstage2monthtodae.Size = New System.Drawing.Size(110, 21)
        Me.txtAPTstage2monthtodae.TabIndex = 601
        '
        'txtAPTstage2today
        '
        Me.txtAPTstage2today.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPTstage2today.Enabled = False
        Me.txtAPTstage2today.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPTstage2today.Location = New System.Drawing.Point(250, 370)
        Me.txtAPTstage2today.MaxLength = 18
        Me.txtAPTstage2today.Name = "txtAPTstage2today"
        Me.txtAPTstage2today.Size = New System.Drawing.Size(110, 21)
        Me.txtAPTstage2today.TabIndex = 600
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label93.Location = New System.Drawing.Point(230, 374)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(11, 13)
        Me.Label93.TabIndex = 599
        Me.Label93.Text = ":"
        '
        'lblAvgPressStage1Kg
        '
        Me.lblAvgPressStage1Kg.AutoSize = True
        Me.lblAvgPressStage1Kg.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgPressStage1Kg.ForeColor = System.Drawing.Color.Black
        Me.lblAvgPressStage1Kg.Location = New System.Drawing.Point(363, 349)
        Me.lblAvgPressStage1Kg.Name = "lblAvgPressStage1Kg"
        Me.lblAvgPressStage1Kg.Size = New System.Drawing.Size(40, 13)
        Me.lblAvgPressStage1Kg.TabIndex = 598
        Me.lblAvgPressStage1Kg.Text = "Kg/Hr"
        '
        'txtAPTstage1yeartodate
        '
        Me.txtAPTstage1yeartodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPTstage1yeartodate.Enabled = False
        Me.txtAPTstage1yeartodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPTstage1yeartodate.Location = New System.Drawing.Point(592, 345)
        Me.txtAPTstage1yeartodate.MaxLength = 18
        Me.txtAPTstage1yeartodate.Name = "txtAPTstage1yeartodate"
        Me.txtAPTstage1yeartodate.Size = New System.Drawing.Size(110, 21)
        Me.txtAPTstage1yeartodate.TabIndex = 597
        '
        'txtAPHstage1monthtodate
        '
        Me.txtAPHstage1monthtodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPHstage1monthtodate.Enabled = False
        Me.txtAPHstage1monthtodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPHstage1monthtodate.Location = New System.Drawing.Point(418, 345)
        Me.txtAPHstage1monthtodate.MaxLength = 18
        Me.txtAPHstage1monthtodate.Name = "txtAPHstage1monthtodate"
        Me.txtAPHstage1monthtodate.Size = New System.Drawing.Size(110, 21)
        Me.txtAPHstage1monthtodate.TabIndex = 596
        '
        'txtAPTstage1today
        '
        Me.txtAPTstage1today.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAPTstage1today.Enabled = False
        Me.txtAPTstage1today.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAPTstage1today.Location = New System.Drawing.Point(250, 345)
        Me.txtAPTstage1today.MaxLength = 18
        Me.txtAPTstage1today.Name = "txtAPTstage1today"
        Me.txtAPTstage1today.Size = New System.Drawing.Size(110, 21)
        Me.txtAPTstage1today.TabIndex = 595
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(230, 349)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(11, 13)
        Me.Label98.TabIndex = 594
        Me.Label98.Text = ":"
        '
        'lblAveragePressThroughput
        '
        Me.lblAveragePressThroughput.AutoSize = True
        Me.lblAveragePressThroughput.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAveragePressThroughput.ForeColor = System.Drawing.Color.Black
        Me.lblAveragePressThroughput.Location = New System.Drawing.Point(22, 349)
        Me.lblAveragePressThroughput.Name = "lblAveragePressThroughput"
        Me.lblAveragePressThroughput.Size = New System.Drawing.Size(163, 13)
        Me.lblAveragePressThroughput.TabIndex = 593
        Me.lblAveragePressThroughput.Text = "Average Press Throughput "
        '
        'lblPressYear
        '
        Me.lblPressYear.AutoSize = True
        Me.lblPressYear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressYear.ForeColor = System.Drawing.Color.Black
        Me.lblPressYear.Location = New System.Drawing.Point(609, 273)
        Me.lblPressYear.Name = "lblPressYear"
        Me.lblPressYear.Size = New System.Drawing.Size(80, 13)
        Me.lblPressYear.TabIndex = 592
        Me.lblPressYear.Text = "Year To date"
        '
        'lblPressMonth
        '
        Me.lblPressMonth.AutoSize = True
        Me.lblPressMonth.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressMonth.ForeColor = System.Drawing.Color.Black
        Me.lblPressMonth.Location = New System.Drawing.Point(430, 273)
        Me.lblPressMonth.Name = "lblPressMonth"
        Me.lblPressMonth.Size = New System.Drawing.Size(88, 13)
        Me.lblPressMonth.TabIndex = 591
        Me.lblPressMonth.Text = "Month To date"
        '
        'lblPressToday
        '
        Me.lblPressToday.AutoSize = True
        Me.lblPressToday.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressToday.ForeColor = System.Drawing.Color.Black
        Me.lblPressToday.Location = New System.Drawing.Point(283, 273)
        Me.lblPressToday.Name = "lblPressToday"
        Me.lblPressToday.Size = New System.Drawing.Size(42, 13)
        Me.lblPressToday.TabIndex = 590
        Me.lblPressToday.Text = "Today"
        '
        'txtStage2yearTodate
        '
        Me.txtStage2yearTodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStage2yearTodate.Enabled = False
        Me.txtStage2yearTodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStage2yearTodate.Location = New System.Drawing.Point(592, 320)
        Me.txtStage2yearTodate.MaxLength = 18
        Me.txtStage2yearTodate.Name = "txtStage2yearTodate"
        Me.txtStage2yearTodate.Size = New System.Drawing.Size(110, 21)
        Me.txtStage2yearTodate.TabIndex = 583
        '
        'txtTPHYearTodateStage1
        '
        Me.txtTPHYearTodateStage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTPHYearTodateStage1.Enabled = False
        Me.txtTPHYearTodateStage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTPHYearTodateStage1.Location = New System.Drawing.Point(592, 295)
        Me.txtTPHYearTodateStage1.MaxLength = 18
        Me.txtTPHYearTodateStage1.Name = "txtTPHYearTodateStage1"
        Me.txtTPHYearTodateStage1.Size = New System.Drawing.Size(110, 21)
        Me.txtTPHYearTodateStage1.TabIndex = 582
        '
        'txtStage2monthTodate
        '
        Me.txtStage2monthTodate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStage2monthTodate.Enabled = False
        Me.txtStage2monthTodate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStage2monthTodate.Location = New System.Drawing.Point(418, 320)
        Me.txtStage2monthTodate.MaxLength = 18
        Me.txtStage2monthTodate.Name = "txtStage2monthTodate"
        Me.txtStage2monthTodate.Size = New System.Drawing.Size(110, 21)
        Me.txtStage2monthTodate.TabIndex = 581
        '
        'txtTPHMonthTodateStage1
        '
        Me.txtTPHMonthTodateStage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTPHMonthTodateStage1.Enabled = False
        Me.txtTPHMonthTodateStage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTPHMonthTodateStage1.Location = New System.Drawing.Point(418, 295)
        Me.txtTPHMonthTodateStage1.MaxLength = 18
        Me.txtTPHMonthTodateStage1.Name = "txtTPHMonthTodateStage1"
        Me.txtTPHMonthTodateStage1.Size = New System.Drawing.Size(110, 21)
        Me.txtTPHMonthTodateStage1.TabIndex = 580
        '
        'txtStage2TodayTPH
        '
        Me.txtStage2TodayTPH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStage2TodayTPH.Enabled = False
        Me.txtStage2TodayTPH.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStage2TodayTPH.Location = New System.Drawing.Point(250, 320)
        Me.txtStage2TodayTPH.MaxLength = 18
        Me.txtStage2TodayTPH.Name = "txtStage2TodayTPH"
        Me.txtStage2TodayTPH.Size = New System.Drawing.Size(110, 21)
        Me.txtStage2TodayTPH.TabIndex = 579
        '
        'txtTPHTodaystage1
        '
        Me.txtTPHTodaystage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTPHTodaystage1.Enabled = False
        Me.txtTPHTodaystage1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTPHTodaystage1.Location = New System.Drawing.Point(250, 295)
        Me.txtTPHTodaystage1.MaxLength = 18
        Me.txtTPHTodaystage1.Name = "txtTPHTodaystage1"
        Me.txtTPHTodaystage1.Size = New System.Drawing.Size(110, 21)
        Me.txtTPHTodaystage1.TabIndex = 578
        Me.txtTPHTodaystage1.TabStop = False
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label109.Location = New System.Drawing.Point(230, 324)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(11, 13)
        Me.Label109.TabIndex = 577
        Me.Label109.Text = ":"
        '
        'lblTotalPHStage2
        '
        Me.lblTotalPHStage2.AutoSize = True
        Me.lblTotalPHStage2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPHStage2.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPHStage2.Location = New System.Drawing.Point(183, 324)
        Me.lblTotalPHStage2.Name = "lblTotalPHStage2"
        Me.lblTotalPHStage2.Size = New System.Drawing.Size(47, 13)
        Me.lblTotalPHStage2.TabIndex = 576
        Me.lblTotalPHStage2.Text = "Stage2"
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.Location = New System.Drawing.Point(229, 299)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(11, 13)
        Me.Label111.TabIndex = 575
        Me.Label111.Text = ":"
        '
        'lblTotalPressHours
        '
        Me.lblTotalPressHours.AutoSize = True
        Me.lblTotalPressHours.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPressHours.ForeColor = System.Drawing.Color.Black
        Me.lblTotalPressHours.Location = New System.Drawing.Point(22, 299)
        Me.lblTotalPressHours.Name = "lblTotalPressHours"
        Me.lblTotalPressHours.Size = New System.Drawing.Size(111, 13)
        Me.lblTotalPressHours.TabIndex = 574
        Me.lblTotalPressHours.Text = "Total Press Hours "
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.lblPressNoDescp)
        Me.GroupBox6.Controls.Add(Me.btnPressNoLookup)
        Me.GroupBox6.Controls.Add(Me.ddlStage)
        Me.GroupBox6.Controls.Add(Me.lblTotalHoursPressHr)
        Me.GroupBox6.Controls.Add(Me.ddlScrewStatus)
        Me.GroupBox6.Controls.Add(Me.txtCapacity)
        Me.GroupBox6.Controls.Add(Me.lblCapacity)
        Me.GroupBox6.Controls.Add(Me.lblCakeProcessTons)
        Me.GroupBox6.Controls.Add(Me.Label77)
        Me.GroupBox6.Controls.Add(Me.lblAvgpresstpTons)
        Me.GroupBox6.Controls.Add(Me.txtCakeProcess)
        Me.GroupBox6.Controls.Add(Me.Label68)
        Me.GroupBox6.Controls.Add(Me.lblCakeProcess)
        Me.GroupBox6.Controls.Add(Me.txtAvgPressThroughput)
        Me.GroupBox6.Controls.Add(Me.Label79)
        Me.GroupBox6.Controls.Add(Me.lvlAvgpresstp)
        Me.GroupBox6.Controls.Add(Me.Label74)
        Me.GroupBox6.Controls.Add(Me.lblScrewStatus)
        Me.GroupBox6.Controls.Add(Me.txtOPHrs)
        Me.GroupBox6.Controls.Add(Me.Label72)
        Me.GroupBox6.Controls.Add(Me.lblOPHrs)
        Me.GroupBox6.Controls.Add(Me.btnResetPressinfo)
        Me.GroupBox6.Controls.Add(Me.btnAddPressInfo)
        Me.GroupBox6.Controls.Add(Me.txtTotalHoursPress)
        Me.GroupBox6.Controls.Add(Me.Label34)
        Me.GroupBox6.Controls.Add(Me.lblTotalHoursPress)
        Me.GroupBox6.Controls.Add(Me.dgPressInfo)
        Me.GroupBox6.Controls.Add(Me.txtPressNo)
        Me.GroupBox6.Controls.Add(Me.Label71)
        Me.GroupBox6.Controls.Add(Me.lblPressNo)
        Me.GroupBox6.Controls.Add(Me.txtAgeOfScrew)
        Me.GroupBox6.Controls.Add(Me.Label73)
        Me.GroupBox6.Controls.Add(Me.lblAgeOfscrew)
        Me.GroupBox6.Controls.Add(Me.Label75)
        Me.GroupBox6.Controls.Add(Me.lblStage)
        Me.GroupBox6.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(767, 261)
        Me.GroupBox6.TabIndex = 301
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Operating Hours"
        '
        'lblPressNoDescp
        '
        Me.lblPressNoDescp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressNoDescp.ForeColor = System.Drawing.Color.Black
        Me.lblPressNoDescp.Location = New System.Drawing.Point(444, 26)
        Me.lblPressNoDescp.Name = "lblPressNoDescp"
        Me.lblPressNoDescp.Size = New System.Drawing.Size(131, 29)
        Me.lblPressNoDescp.TabIndex = 602
        Me.lblPressNoDescp.Text = "Press NoDescp"
        '
        'btnPressNoLookup
        '
        Me.btnPressNoLookup.BackgroundImage = CType(resources.GetObject("btnPressNoLookup.BackgroundImage"), System.Drawing.Image)
        Me.btnPressNoLookup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPressNoLookup.FlatAppearance.BorderSize = 0
        Me.btnPressNoLookup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.btnPressNoLookup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPressNoLookup.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.btnPressNoLookup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPressNoLookup.Location = New System.Drawing.Point(404, 17)
        Me.btnPressNoLookup.Name = "btnPressNoLookup"
        Me.btnPressNoLookup.Size = New System.Drawing.Size(34, 26)
        Me.btnPressNoLookup.TabIndex = 303
        Me.btnPressNoLookup.TabStop = False
        Me.btnPressNoLookup.UseVisualStyleBackColor = True
        '
        'ddlStage
        '
        Me.ddlStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlStage.FormattingEnabled = True
        Me.ddlStage.Items.AddRange(New Object() {"Stage 1", "Stage 2"})
        Me.ddlStage.Location = New System.Drawing.Point(88, 23)
        Me.ddlStage.Name = "ddlStage"
        Me.ddlStage.Size = New System.Drawing.Size(87, 21)
        Me.ddlStage.TabIndex = 301
        '
        'lblTotalHoursPressHr
        '
        Me.lblTotalHoursPressHr.AutoSize = True
        Me.lblTotalHoursPressHr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHoursPressHr.ForeColor = System.Drawing.Color.Black
        Me.lblTotalHoursPressHr.Location = New System.Drawing.Point(211, 231)
        Me.lblTotalHoursPressHr.Name = "lblTotalHoursPressHr"
        Me.lblTotalHoursPressHr.Size = New System.Drawing.Size(26, 13)
        Me.lblTotalHoursPressHr.TabIndex = 599
        Me.lblTotalHoursPressHr.Text = "Hrs"
        '
        'ddlScrewStatus
        '
        Me.ddlScrewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ddlScrewStatus.FormattingEnabled = True
        Me.ddlScrewStatus.Items.AddRange(New Object() {"N", "R", "R1", "R2", "R3", "R4"})
        Me.ddlScrewStatus.Location = New System.Drawing.Point(668, 52)
        Me.ddlScrewStatus.Name = "ddlScrewStatus"
        Me.ddlScrewStatus.Size = New System.Drawing.Size(90, 21)
        Me.ddlScrewStatus.TabIndex = 307
        '
        'txtCapacity
        '
        Me.txtCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacity.Enabled = False
        Me.txtCapacity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacity.Location = New System.Drawing.Point(668, 24)
        Me.txtCapacity.MaxLength = 18
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(90, 21)
        Me.txtCapacity.TabIndex = 308
        '
        'lblCapacity
        '
        Me.lblCapacity.AutoSize = True
        Me.lblCapacity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacity.ForeColor = System.Drawing.Color.Black
        Me.lblCapacity.Location = New System.Drawing.Point(587, 30)
        Me.lblCapacity.Name = "lblCapacity"
        Me.lblCapacity.Size = New System.Drawing.Size(57, 13)
        Me.lblCapacity.TabIndex = 333
        Me.lblCapacity.Text = "Capacity"
        '
        'lblCakeProcessTons
        '
        Me.lblCakeProcessTons.AutoSize = True
        Me.lblCakeProcessTons.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCakeProcessTons.ForeColor = System.Drawing.Color.Black
        Me.lblCakeProcessTons.Location = New System.Drawing.Point(711, 230)
        Me.lblCakeProcessTons.Name = "lblCakeProcessTons"
        Me.lblCakeProcessTons.Size = New System.Drawing.Size(34, 13)
        Me.lblCakeProcessTons.TabIndex = 349
        Me.lblCakeProcessTons.Text = "Tons"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label77.Location = New System.Drawing.Point(654, 28)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(11, 13)
        Me.Label77.TabIndex = 334
        Me.Label77.Text = ":"
        '
        'lblAvgpresstpTons
        '
        Me.lblAvgpresstpTons.AutoSize = True
        Me.lblAvgpresstpTons.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvgpresstpTons.ForeColor = System.Drawing.Color.Black
        Me.lblAvgpresstpTons.Location = New System.Drawing.Point(441, 231)
        Me.lblAvgpresstpTons.Name = "lblAvgpresstpTons"
        Me.lblAvgpresstpTons.Size = New System.Drawing.Size(52, 13)
        Me.lblAvgpresstpTons.TabIndex = 348
        Me.lblAvgpresstpTons.Text = "Tons/Hr"
        '
        'txtCakeProcess
        '
        Me.txtCakeProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCakeProcess.Enabled = False
        Me.txtCakeProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCakeProcess.Location = New System.Drawing.Point(600, 229)
        Me.txtCakeProcess.MaxLength = 18
        Me.txtCakeProcess.Name = "txtCakeProcess"
        Me.txtCakeProcess.Size = New System.Drawing.Size(110, 21)
        Me.txtCakeProcess.TabIndex = 347
        Me.txtCakeProcess.TabStop = False
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(586, 231)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(11, 13)
        Me.Label68.TabIndex = 346
        Me.Label68.Text = ":"
        '
        'lblCakeProcess
        '
        Me.lblCakeProcess.AutoSize = True
        Me.lblCakeProcess.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCakeProcess.ForeColor = System.Drawing.Color.Black
        Me.lblCakeProcess.Location = New System.Drawing.Point(501, 231)
        Me.lblCakeProcess.Name = "lblCakeProcess"
        Me.lblCakeProcess.Size = New System.Drawing.Size(85, 13)
        Me.lblCakeProcess.TabIndex = 345
        Me.lblCakeProcess.Text = "Cake Process"
        '
        'txtAvgPressThroughput
        '
        Me.txtAvgPressThroughput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAvgPressThroughput.Enabled = False
        Me.txtAvgPressThroughput.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvgPressThroughput.Location = New System.Drawing.Point(325, 227)
        Me.txtAvgPressThroughput.MaxLength = 18
        Me.txtAvgPressThroughput.Name = "txtAvgPressThroughput"
        Me.txtAvgPressThroughput.Size = New System.Drawing.Size(110, 21)
        Me.txtAvgPressThroughput.TabIndex = 344
        Me.txtAvgPressThroughput.TabStop = False
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label79.Location = New System.Drawing.Point(311, 231)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(11, 13)
        Me.Label79.TabIndex = 343
        Me.Label79.Text = ":"
        '
        'lvlAvgpresstp
        '
        Me.lvlAvgpresstp.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvlAvgpresstp.ForeColor = System.Drawing.Color.Black
        Me.lvlAvgpresstp.Location = New System.Drawing.Point(236, 227)
        Me.lvlAvgpresstp.Name = "lvlAvgpresstp"
        Me.lvlAvgpresstp.Size = New System.Drawing.Size(83, 37)
        Me.lvlAvgpresstp.TabIndex = 342
        Me.lvlAvgpresstp.Text = "Avg. Press Throughput"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(654, 56)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(11, 13)
        Me.Label74.TabIndex = 337
        Me.Label74.Text = ":"
        '
        'lblScrewStatus
        '
        Me.lblScrewStatus.AutoSize = True
        Me.lblScrewStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScrewStatus.ForeColor = System.Drawing.Color.Black
        Me.lblScrewStatus.Location = New System.Drawing.Point(566, 56)
        Me.lblScrewStatus.Name = "lblScrewStatus"
        Me.lblScrewStatus.Size = New System.Drawing.Size(82, 13)
        Me.lblScrewStatus.TabIndex = 336
        Me.lblScrewStatus.Text = "Screw Status"
        '
        'txtOPHrs
        '
        Me.txtOPHrs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOPHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOPHrs.Location = New System.Drawing.Point(88, 52)
        Me.txtOPHrs.MaxLength = 18
        Me.txtOPHrs.Name = "txtOPHrs"
        Me.txtOPHrs.Size = New System.Drawing.Size(87, 21)
        Me.txtOPHrs.TabIndex = 304
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(74, 56)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(11, 13)
        Me.Label72.TabIndex = 331
        Me.Label72.Text = ":"
        '
        'lblOPHrs
        '
        Me.lblOPHrs.AutoSize = True
        Me.lblOPHrs.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOPHrs.ForeColor = System.Drawing.Color.Red
        Me.lblOPHrs.Location = New System.Drawing.Point(12, 56)
        Me.lblOPHrs.Name = "lblOPHrs"
        Me.lblOPHrs.Size = New System.Drawing.Size(50, 13)
        Me.lblOPHrs.TabIndex = 330
        Me.lblOPHrs.Text = "OP. Hrs"
        '
        'btnResetPressinfo
        '
        Me.btnResetPressinfo.BackgroundImage = CType(resources.GetObject("btnResetPressinfo.BackgroundImage"), System.Drawing.Image)
        Me.btnResetPressinfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnResetPressinfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetPressinfo.Image = CType(resources.GetObject("btnResetPressinfo.Image"), System.Drawing.Image)
        Me.btnResetPressinfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnResetPressinfo.Location = New System.Drawing.Point(668, 77)
        Me.btnResetPressinfo.Name = "btnResetPressinfo"
        Me.btnResetPressinfo.Size = New System.Drawing.Size(90, 25)
        Me.btnResetPressinfo.TabIndex = 310
        Me.btnResetPressinfo.Text = "Reset"
        Me.btnResetPressinfo.UseVisualStyleBackColor = True
        '
        'btnAddPressInfo
        '
        Me.btnAddPressInfo.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.btnAddPressInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddPressInfo.Image = CType(resources.GetObject("btnAddPressInfo.Image"), System.Drawing.Image)
        Me.btnAddPressInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAddPressInfo.Location = New System.Drawing.Point(570, 77)
        Me.btnAddPressInfo.Name = "btnAddPressInfo"
        Me.btnAddPressInfo.Size = New System.Drawing.Size(90, 25)
        Me.btnAddPressInfo.TabIndex = 309
        Me.btnAddPressInfo.Text = "Add"
        Me.btnAddPressInfo.UseVisualStyleBackColor = True
        '
        'txtTotalHoursPress
        '
        Me.txtTotalHoursPress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalHoursPress.Enabled = False
        Me.txtTotalHoursPress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalHoursPress.Location = New System.Drawing.Point(98, 229)
        Me.txtTotalHoursPress.MaxLength = 18
        Me.txtTotalHoursPress.Name = "txtTotalHoursPress"
        Me.txtTotalHoursPress.Size = New System.Drawing.Size(110, 21)
        Me.txtTotalHoursPress.TabIndex = 323
        Me.txtTotalHoursPress.TabStop = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(86, 233)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(11, 13)
        Me.Label34.TabIndex = 322
        Me.Label34.Text = ":"
        '
        'lblTotalHoursPress
        '
        Me.lblTotalHoursPress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHoursPress.ForeColor = System.Drawing.Color.Black
        Me.lblTotalHoursPress.Location = New System.Drawing.Point(14, 228)
        Me.lblTotalHoursPress.Name = "lblTotalHoursPress"
        Me.lblTotalHoursPress.Size = New System.Drawing.Size(73, 31)
        Me.lblTotalHoursPress.TabIndex = 321
        Me.lblTotalHoursPress.Text = "Total Hours Press"
        '
        'dgPressInfo
        '
        Me.dgPressInfo.AllowUserToAddRows = False
        Me.dgPressInfo.AllowUserToDeleteRows = False
        Me.dgPressInfo.AllowUserToResizeRows = False
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        Me.dgPressInfo.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgPressInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgPressInfo.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgPressInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgPressInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPressInfo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgPressInfo.ColumnHeadersHeight = 30
        Me.dgPressInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgMeStage, Me.dgMePressNo, Me.dgMePressNoDescp, Me.dgMeCapacity, Me.dgMeMeterFrom, Me.dgMeMeterTo, Me.dgMeOPHrs, Me.dgMeProductionLogPressID, Me.dgMeScrewAge, Me.dgMeMachineID, Me.dgMeScrewStatus})
        Me.dgPressInfo.ContextMenuStrip = Me.cmsPressInfo
        Me.dgPressInfo.EnableHeadersVisualStyles = False
        Me.dgPressInfo.GridColor = System.Drawing.Color.Gray
        Me.dgPressInfo.Location = New System.Drawing.Point(16, 108)
        Me.dgPressInfo.MultiSelect = False
        Me.dgPressInfo.Name = "dgPressInfo"
        Me.dgPressInfo.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPressInfo.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgPressInfo.RowHeadersVisible = False
        Me.dgPressInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPressInfo.Size = New System.Drawing.Size(737, 103)
        Me.dgPressInfo.TabIndex = 311
        '
        'dgMeStage
        '
        Me.dgMeStage.DataPropertyName = "Stage"
        Me.dgMeStage.HeaderText = "Stage"
        Me.dgMeStage.Name = "dgMeStage"
        Me.dgMeStage.ReadOnly = True
        Me.dgMeStage.Width = 60
        '
        'dgMePressNo
        '
        Me.dgMePressNo.DataPropertyName = "PressNo"
        Me.dgMePressNo.HeaderText = "Press No"
        Me.dgMePressNo.Name = "dgMePressNo"
        Me.dgMePressNo.ReadOnly = True
        '
        'dgMePressNoDescp
        '
        Me.dgMePressNoDescp.DataPropertyName = "PressNoDescp"
        Me.dgMePressNoDescp.HeaderText = "PressNoDescp"
        Me.dgMePressNoDescp.Name = "dgMePressNoDescp"
        Me.dgMePressNoDescp.ReadOnly = True
        Me.dgMePressNoDescp.Visible = False
        '
        'dgMeCapacity
        '
        Me.dgMeCapacity.DataPropertyName = "Capacity"
        Me.dgMeCapacity.HeaderText = "Capacity"
        Me.dgMeCapacity.Name = "dgMeCapacity"
        Me.dgMeCapacity.ReadOnly = True
        '
        'dgMeMeterFrom
        '
        Me.dgMeMeterFrom.DataPropertyName = "MeterFrom"
        Me.dgMeMeterFrom.HeaderText = "Meter From"
        Me.dgMeMeterFrom.Name = "dgMeMeterFrom"
        Me.dgMeMeterFrom.ReadOnly = True
        Me.dgMeMeterFrom.Visible = False
        '
        'dgMeMeterTo
        '
        Me.dgMeMeterTo.DataPropertyName = "MeterTo"
        Me.dgMeMeterTo.HeaderText = "Meter To"
        Me.dgMeMeterTo.Name = "dgMeMeterTo"
        Me.dgMeMeterTo.ReadOnly = True
        Me.dgMeMeterTo.Visible = False
        '
        'dgMeOPHrs
        '
        Me.dgMeOPHrs.DataPropertyName = "OPHrs"
        Me.dgMeOPHrs.HeaderText = "OP. Hrs"
        Me.dgMeOPHrs.Name = "dgMeOPHrs"
        Me.dgMeOPHrs.ReadOnly = True
        '
        'dgMeProductionLogPressID
        '
        Me.dgMeProductionLogPressID.DataPropertyName = "ProductionLogPressID"
        Me.dgMeProductionLogPressID.HeaderText = "ProductionLogPressID"
        Me.dgMeProductionLogPressID.Name = "dgMeProductionLogPressID"
        Me.dgMeProductionLogPressID.ReadOnly = True
        Me.dgMeProductionLogPressID.Visible = False
        '
        'dgMeScrewAge
        '
        Me.dgMeScrewAge.DataPropertyName = "ScrewAge"
        Me.dgMeScrewAge.HeaderText = "Age Of Screw (Hrs)"
        Me.dgMeScrewAge.Name = "dgMeScrewAge"
        Me.dgMeScrewAge.ReadOnly = True
        Me.dgMeScrewAge.Width = 150
        '
        'dgMeMachineID
        '
        Me.dgMeMachineID.DataPropertyName = "MachineID"
        Me.dgMeMachineID.HeaderText = "MachineID"
        Me.dgMeMachineID.Name = "dgMeMachineID"
        Me.dgMeMachineID.ReadOnly = True
        Me.dgMeMachineID.Visible = False
        '
        'dgMeScrewStatus
        '
        Me.dgMeScrewStatus.DataPropertyName = "ScrewStatus"
        Me.dgMeScrewStatus.HeaderText = "Screw Status"
        Me.dgMeScrewStatus.Name = "dgMeScrewStatus"
        Me.dgMeScrewStatus.ReadOnly = True
        Me.dgMeScrewStatus.Width = 120
        '
        'cmsPressInfo
        '
        Me.cmsPressInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem7, Me.ToolStripMenuItem8, Me.DeletePressInfo})
        Me.cmsPressInfo.Name = "cmsIPR"
        Me.cmsPressInfo.Size = New System.Drawing.Size(117, 70)
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem7.Text = "Add"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem8.Text = "Edit"
        '
        'DeletePressInfo
        '
        Me.DeletePressInfo.Name = "DeletePressInfo"
        Me.DeletePressInfo.Size = New System.Drawing.Size(116, 22)
        Me.DeletePressInfo.Text = "Delete"
        '
        'txtPressNo
        '
        Me.txtPressNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPressNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPressNo.Location = New System.Drawing.Point(314, 24)
        Me.txtPressNo.MaxLength = 50
        Me.txtPressNo.Name = "txtPressNo"
        Me.txtPressNo.Size = New System.Drawing.Size(79, 21)
        Me.txtPressNo.TabIndex = 302
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(300, 28)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(11, 13)
        Me.Label71.TabIndex = 227
        Me.Label71.Text = ":"
        '
        'lblPressNo
        '
        Me.lblPressNo.AutoSize = True
        Me.lblPressNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressNo.ForeColor = System.Drawing.Color.Red
        Me.lblPressNo.Location = New System.Drawing.Point(181, 25)
        Me.lblPressNo.Name = "lblPressNo"
        Me.lblPressNo.Size = New System.Drawing.Size(57, 13)
        Me.lblPressNo.TabIndex = 226
        Me.lblPressNo.Text = "Press No"
        '
        'txtAgeOfScrew
        '
        Me.txtAgeOfScrew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAgeOfScrew.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAgeOfScrew.Location = New System.Drawing.Point(314, 52)
        Me.txtAgeOfScrew.MaxLength = 18
        Me.txtAgeOfScrew.Name = "txtAgeOfScrew"
        Me.txtAgeOfScrew.Size = New System.Drawing.Size(79, 21)
        Me.txtAgeOfScrew.TabIndex = 306
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(299, 56)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(11, 13)
        Me.Label73.TabIndex = 224
        Me.Label73.Text = ":"
        '
        'lblAgeOfscrew
        '
        Me.lblAgeOfscrew.AutoSize = True
        Me.lblAgeOfscrew.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeOfscrew.ForeColor = System.Drawing.Color.Black
        Me.lblAgeOfscrew.Location = New System.Drawing.Point(181, 56)
        Me.lblAgeOfscrew.Name = "lblAgeOfscrew"
        Me.lblAgeOfscrew.Size = New System.Drawing.Size(116, 13)
        Me.lblAgeOfscrew.TabIndex = 223
        Me.lblAgeOfscrew.Text = "Age Of screw (Hrs)"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(74, 28)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(11, 13)
        Me.Label75.TabIndex = 221
        Me.Label75.Text = ":"
        '
        'lblStage
        '
        Me.lblStage.AutoSize = True
        Me.lblStage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStage.ForeColor = System.Drawing.Color.Red
        Me.lblStage.Location = New System.Drawing.Point(12, 25)
        Me.lblStage.Name = "lblStage"
        Me.lblStage.Size = New System.Drawing.Size(40, 13)
        Me.lblStage.TabIndex = 220
        Me.lblStage.Text = "Stage"
        '
        'tpPKOProductionView
        '
        Me.tpPKOProductionView.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.tpPKOProductionView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tpPKOProductionView.Controls.Add(Me.dgvPKOProductionLogView)
        Me.tpPKOProductionView.Controls.Add(Me.ExtendedPanel1)
        Me.tpPKOProductionView.Location = New System.Drawing.Point(4, 22)
        Me.tpPKOProductionView.Name = "tpPKOProductionView"
        Me.tpPKOProductionView.Size = New System.Drawing.Size(821, 605)
        Me.tpPKOProductionView.TabIndex = 1
        Me.tpPKOProductionView.Text = "View"
        Me.tpPKOProductionView.UseVisualStyleBackColor = True
        '
        'dgvPKOProductionLogView
        '
        Me.dgvPKOProductionLogView.AllowUserToAddRows = False
        Me.dgvPKOProductionLogView.AllowUserToDeleteRows = False
        Me.dgvPKOProductionLogView.AllowUserToResizeRows = False
        Me.dgvPKOProductionLogView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPKOProductionLogView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvPKOProductionLogView.CausesValidation = False
        Me.dgvPKOProductionLogView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPKOProductionLogView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPKOProductionLogView.ColumnHeadersHeight = 30
        Me.dgvPKOProductionLogView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dgclProductionlogDate, Me.KernelProcessedACT, Me.dgclTotalBD, Me.dgclEffectiveProcessingHours, Me.dgclPKOProductionLogID, Me.dgclCropYieldID, Me.dgclTotalHours, Me.dgclLossOfKernel, Me.dgclLossOfKernelMTD, Me.dgclLossOfKernelYTD, Me.dgclMechanicalBD, Me.dgclMechanicalBDMTD, Me.dgclMechanicalBDYTD, Me.dgclElectricalBD, Me.dgclElectricalBDMTD, Me.dgclElectricalBDYTD, Me.dgclProcessingBD, Me.dgclProcessingBDMTD, Me.dgclProcessingBDYTD, Me.dgclRemarks})
        Me.dgvPKOProductionLogView.ContextMenuStrip = Me.cmsPKOProductionLog
        Me.dgvPKOProductionLogView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPKOProductionLogView.EnableHeadersVisualStyles = False
        Me.dgvPKOProductionLogView.GridColor = System.Drawing.Color.Gray
        Me.dgvPKOProductionLogView.Location = New System.Drawing.Point(0, 105)
        Me.dgvPKOProductionLogView.MultiSelect = False
        Me.dgvPKOProductionLogView.Name = "dgvPKOProductionLogView"
        Me.dgvPKOProductionLogView.ReadOnly = True
        Me.dgvPKOProductionLogView.RowHeadersVisible = False
        Me.dgvPKOProductionLogView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPKOProductionLogView.Size = New System.Drawing.Size(821, 500)
        Me.dgvPKOProductionLogView.TabIndex = 453
        '
        'dgclProductionlogDate
        '
        Me.dgclProductionlogDate.DataPropertyName = "ProductionLogDate"
        DataGridViewCellStyle11.Format = "dd/MM/yyyy"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.dgclProductionlogDate.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgclProductionlogDate.HeaderText = "Date"
        Me.dgclProductionlogDate.Name = "dgclProductionlogDate"
        Me.dgclProductionlogDate.ReadOnly = True
        '
        'KernelProcessedACT
        '
        Me.KernelProcessedACT.DataPropertyName = "KernelProcessedACT"
        Me.KernelProcessedACT.HeaderText = "KernelProcessedACT"
        Me.KernelProcessedACT.Name = "KernelProcessedACT"
        Me.KernelProcessedACT.ReadOnly = True
        Me.KernelProcessedACT.Visible = False
        '
        'dgclTotalBD
        '
        Me.dgclTotalBD.DataPropertyName = "TotalBD"
        Me.dgclTotalBD.HeaderText = "TotalBD"
        Me.dgclTotalBD.Name = "dgclTotalBD"
        Me.dgclTotalBD.ReadOnly = True
        Me.dgclTotalBD.Visible = False
        '
        'dgclEffectiveProcessingHours
        '
        Me.dgclEffectiveProcessingHours.DataPropertyName = "EffectiveProcessingHours"
        Me.dgclEffectiveProcessingHours.HeaderText = "EffectiveProcessingHours"
        Me.dgclEffectiveProcessingHours.Name = "dgclEffectiveProcessingHours"
        Me.dgclEffectiveProcessingHours.ReadOnly = True
        Me.dgclEffectiveProcessingHours.Visible = False
        '
        'dgclPKOProductionLogID
        '
        Me.dgclPKOProductionLogID.DataPropertyName = "PKOProductionLogID"
        Me.dgclPKOProductionLogID.HeaderText = "PKOProductionLogID"
        Me.dgclPKOProductionLogID.Name = "dgclPKOProductionLogID"
        Me.dgclPKOProductionLogID.ReadOnly = True
        Me.dgclPKOProductionLogID.Visible = False
        '
        'dgclCropYieldID
        '
        Me.dgclCropYieldID.DataPropertyName = "CropYieldID"
        Me.dgclCropYieldID.HeaderText = "CropYieldID"
        Me.dgclCropYieldID.Name = "dgclCropYieldID"
        Me.dgclCropYieldID.ReadOnly = True
        Me.dgclCropYieldID.Visible = False
        '
        'dgclTotalHours
        '
        Me.dgclTotalHours.DataPropertyName = "TotalHours"
        Me.dgclTotalHours.HeaderText = "TotalHours"
        Me.dgclTotalHours.Name = "dgclTotalHours"
        Me.dgclTotalHours.ReadOnly = True
        Me.dgclTotalHours.Visible = False
        '
        'dgclLossOfKernel
        '
        Me.dgclLossOfKernel.DataPropertyName = "LossOfKernel"
        Me.dgclLossOfKernel.HeaderText = "LossOfKernel"
        Me.dgclLossOfKernel.Name = "dgclLossOfKernel"
        Me.dgclLossOfKernel.ReadOnly = True
        Me.dgclLossOfKernel.Visible = False
        '
        'dgclLossOfKernelMTD
        '
        Me.dgclLossOfKernelMTD.DataPropertyName = "LossOfKernelMTD"
        Me.dgclLossOfKernelMTD.HeaderText = "LossOfKernelMTD"
        Me.dgclLossOfKernelMTD.Name = "dgclLossOfKernelMTD"
        Me.dgclLossOfKernelMTD.ReadOnly = True
        Me.dgclLossOfKernelMTD.Visible = False
        '
        'dgclLossOfKernelYTD
        '
        Me.dgclLossOfKernelYTD.DataPropertyName = "LossOfKernelYTD"
        Me.dgclLossOfKernelYTD.HeaderText = "LossOfKernelYTD"
        Me.dgclLossOfKernelYTD.Name = "dgclLossOfKernelYTD"
        Me.dgclLossOfKernelYTD.ReadOnly = True
        Me.dgclLossOfKernelYTD.Visible = False
        '
        'dgclMechanicalBD
        '
        Me.dgclMechanicalBD.DataPropertyName = "MechanicalBD"
        Me.dgclMechanicalBD.HeaderText = "MechanicalBD"
        Me.dgclMechanicalBD.Name = "dgclMechanicalBD"
        Me.dgclMechanicalBD.ReadOnly = True
        Me.dgclMechanicalBD.Visible = False
        '
        'dgclMechanicalBDMTD
        '
        Me.dgclMechanicalBDMTD.DataPropertyName = "MechanicalBDMTD"
        Me.dgclMechanicalBDMTD.HeaderText = "MechanicalBDMTD"
        Me.dgclMechanicalBDMTD.Name = "dgclMechanicalBDMTD"
        Me.dgclMechanicalBDMTD.ReadOnly = True
        Me.dgclMechanicalBDMTD.Visible = False
        '
        'dgclMechanicalBDYTD
        '
        Me.dgclMechanicalBDYTD.DataPropertyName = "MechanicalBDYTD"
        Me.dgclMechanicalBDYTD.HeaderText = "MechanicalBDYTD"
        Me.dgclMechanicalBDYTD.Name = "dgclMechanicalBDYTD"
        Me.dgclMechanicalBDYTD.ReadOnly = True
        Me.dgclMechanicalBDYTD.Visible = False
        '
        'dgclElectricalBD
        '
        Me.dgclElectricalBD.DataPropertyName = "ElectricalBD"
        Me.dgclElectricalBD.HeaderText = "ElectricalBD"
        Me.dgclElectricalBD.Name = "dgclElectricalBD"
        Me.dgclElectricalBD.ReadOnly = True
        Me.dgclElectricalBD.Visible = False
        '
        'dgclElectricalBDMTD
        '
        Me.dgclElectricalBDMTD.DataPropertyName = "ElectricalBDMTD"
        Me.dgclElectricalBDMTD.HeaderText = "ElectricalBDMTD"
        Me.dgclElectricalBDMTD.Name = "dgclElectricalBDMTD"
        Me.dgclElectricalBDMTD.ReadOnly = True
        Me.dgclElectricalBDMTD.Visible = False
        '
        'dgclElectricalBDYTD
        '
        Me.dgclElectricalBDYTD.DataPropertyName = "ElectricalBDYTD"
        Me.dgclElectricalBDYTD.HeaderText = "ElectricalBDYTD"
        Me.dgclElectricalBDYTD.Name = "dgclElectricalBDYTD"
        Me.dgclElectricalBDYTD.ReadOnly = True
        Me.dgclElectricalBDYTD.Visible = False
        '
        'dgclProcessingBD
        '
        Me.dgclProcessingBD.DataPropertyName = "ProcessingBD"
        Me.dgclProcessingBD.HeaderText = "ProcessingBD"
        Me.dgclProcessingBD.Name = "dgclProcessingBD"
        Me.dgclProcessingBD.ReadOnly = True
        Me.dgclProcessingBD.Visible = False
        '
        'dgclProcessingBDMTD
        '
        Me.dgclProcessingBDMTD.DataPropertyName = "ProcessingBDMTD"
        Me.dgclProcessingBDMTD.HeaderText = "ProcessingBDMTD"
        Me.dgclProcessingBDMTD.Name = "dgclProcessingBDMTD"
        Me.dgclProcessingBDMTD.ReadOnly = True
        Me.dgclProcessingBDMTD.Visible = False
        '
        'dgclProcessingBDYTD
        '
        Me.dgclProcessingBDYTD.DataPropertyName = "ProcessingBDYTD"
        Me.dgclProcessingBDYTD.HeaderText = "ProcessingBDYTD"
        Me.dgclProcessingBDYTD.Name = "dgclProcessingBDYTD"
        Me.dgclProcessingBDYTD.ReadOnly = True
        Me.dgclProcessingBDYTD.Visible = False
        '
        'dgclRemarks
        '
        Me.dgclRemarks.DataPropertyName = "Remarks"
        Me.dgclRemarks.HeaderText = "Remarks"
        Me.dgclRemarks.Name = "dgclRemarks"
        Me.dgclRemarks.ReadOnly = True
        Me.dgclRemarks.Visible = False
        '
        'cmsPKOProductionLog
        '
        Me.cmsPKOProductionLog.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsPKOProductionLog.Name = "cmsIPR"
        Me.cmsPKOProductionLog.Size = New System.Drawing.Size(117, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = CType(resources.GetObject("AddToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ExtendedPanel1
        '
        Me.ExtendedPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ExtendedPanel1.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.ExtendedPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ExtendedPanel1.BorderColor = System.Drawing.Color.Gray
        Me.ExtendedPanel1.CaptionColorOne = System.Drawing.Color.White
        Me.ExtendedPanel1.CaptionColorTwo = System.Drawing.Color.FromArgb(CType(CType(182, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ExtendedPanel1.CaptionFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtendedPanel1.CaptionSize = 40
        Me.ExtendedPanel1.CaptionText = "Search PKO Production Log"
        Me.ExtendedPanel1.CaptionTextColor = System.Drawing.Color.Black
        Me.ExtendedPanel1.Controls.Add(Me.dtpPKOProdLogDateSearch)
        Me.ExtendedPanel1.Controls.Add(Me.Panel4)
        Me.ExtendedPanel1.Controls.Add(Me.lblSearchby)
        Me.ExtendedPanel1.Controls.Add(Me.Label166)
        Me.ExtendedPanel1.Controls.Add(Me.chkPKOLogDate)
        Me.ExtendedPanel1.Controls.Add(Me.btnSearch)
        Me.ExtendedPanel1.CornerStyle = Stepi.UI.CornerStyle.Normal
        Me.ExtendedPanel1.DirectionCtrlColor = System.Drawing.Color.DarkGray
        Me.ExtendedPanel1.DirectionCtrlHoverColor = System.Drawing.Color.Orange
        Me.ExtendedPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ExtendedPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ExtendedPanel1.Name = "ExtendedPanel1"
        Me.ExtendedPanel1.Size = New System.Drawing.Size(821, 105)
        Me.ExtendedPanel1.TabIndex = 416
        '
        'dtpPKOProdLogDateSearch
        '
        Me.dtpPKOProdLogDateSearch.CustomFormat = "dd/MM/yyyy"
        Me.dtpPKOProdLogDateSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPKOProdLogDateSearch.Location = New System.Drawing.Point(161, 73)
        Me.dtpPKOProdLogDateSearch.Name = "dtpPKOProdLogDateSearch"
        Me.dtpPKOProdLogDateSearch.Size = New System.Drawing.Size(168, 21)
        Me.dtpPKOProdLogDateSearch.TabIndex = 451
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.DataGridView2)
        Me.Panel4.Location = New System.Drawing.Point(0, 157)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1311, 425)
        Me.Panel4.TabIndex = 33
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(1304, 572)
        Me.DataGridView2.TabIndex = 31
        '
        'lblSearchby
        '
        Me.lblSearchby.AutoSize = True
        Me.lblSearchby.BackColor = System.Drawing.Color.Transparent
        Me.lblSearchby.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblSearchby.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblSearchby.ForeColor = System.Drawing.Color.DimGray
        Me.lblSearchby.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSearchby.Location = New System.Drawing.Point(2, 45)
        Me.lblSearchby.Name = "lblSearchby"
        Me.lblSearchby.Size = New System.Drawing.Size(72, 13)
        Me.lblSearchby.TabIndex = 69
        Me.lblSearchby.Text = "Search By"
        '
        'Label166
        '
        Me.Label166.AutoSize = True
        Me.Label166.BackColor = System.Drawing.Color.Transparent
        Me.Label166.Font = New System.Drawing.Font("Verdana", 9.0!)
        Me.Label166.ForeColor = System.Drawing.Color.Black
        Me.Label166.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label166.Location = New System.Drawing.Point(93, 45)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(12, 14)
        Me.Label166.TabIndex = 70
        Me.Label166.Text = ":"
        '
        'chkPKOLogDate
        '
        Me.chkPKOLogDate.AutoSize = True
        Me.chkPKOLogDate.Location = New System.Drawing.Point(161, 50)
        Me.chkPKOLogDate.Name = "chkPKOLogDate"
        Me.chkPKOLogDate.Size = New System.Drawing.Size(57, 17)
        Me.chkPKOLogDate.TabIndex = 450
        Me.chkPKOLogDate.Text = " Date"
        Me.chkPKOLogDate.UseVisualStyleBackColor = True
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
        Me.btnSearch.Location = New System.Drawing.Point(335, 70)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 25)
        Me.btnSearch.TabIndex = 452
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'PKOProductionLogFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImage = Global.BSP.My.Resources.Resources.panelbaground
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(829, 631)
        Me.Controls.Add(Me.tcPKOroductionLog)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "PKOProductionLogFrm"
        Me.Text = "PKOProductionLogFrm"
        Me.tcPKOroductionLog.ResumeLayout(False)
        Me.tpPKOProductionSave.ResumeLayout(False)
        Me.panCPO.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.tcPKOLog.ResumeLayout(False)
        Me.tbProduction.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gbShiftInformation.ResumeLayout(False)
        Me.gbShiftInformation.PerformLayout()
        CType(Me.dgvPKOLogShiftDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsShiftInformation.ResumeLayout(False)
        Me.tbProcessLog.ResumeLayout(False)
        Me.gplblProcessedKernel.ResumeLayout(False)
        Me.gplblProcessedKernel.PerformLayout()
        Me.gpReceivedKernel.ResumeLayout(False)
        Me.gpReceivedKernel.PerformLayout()
        CType(Me.dgvReceivedKernel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsKernelReceived.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tbProcessingInfo.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.tbPressInfo.ResumeLayout(False)
        Me.tbPressInfo.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.dgPressInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPressInfo.ResumeLayout(False)
        Me.tpPKOProductionView.ResumeLayout(False)
        CType(Me.dgvPKOProductionLogView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPKOProductionLog.ResumeLayout(False)
        Me.ExtendedPanel1.ResumeLayout(False)
        Me.ExtendedPanel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcPKOroductionLog As System.Windows.Forms.TabControl
    Friend WithEvents tpPKOProductionSave As System.Windows.Forms.TabPage
    Friend WithEvents panCPO As System.Windows.Forms.Panel
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents tcPKOLog As System.Windows.Forms.TabControl
    Friend WithEvents tbProduction As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gbShiftInformation As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label115 As System.Windows.Forms.Label
    Friend WithEvents lblYearTodateHrs As System.Windows.Forms.Label
    Friend WithEvents lblProMonthToDateHrs As System.Windows.Forms.Label
    Friend WithEvents lblTotalHoursHrs As System.Windows.Forms.Label
    Friend WithEvents txtYearTodateHrs As System.Windows.Forms.TextBox
    Friend WithEvents txtMonthTodateHrs As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalHours As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblYearTodate As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblProMonthToDate As System.Windows.Forms.Label
    Friend WithEvents lblTotalHours As System.Windows.Forms.Label
    Friend WithEvents txtKernelProcessed As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMandor As System.Windows.Forms.TextBox
    Friend WithEvents txtAssistant As System.Windows.Forms.TextBox
    Friend WithEvents lblKernelProcessed As System.Windows.Forms.Label
    Friend WithEvents lblStopTime As System.Windows.Forms.Label
    Friend WithEvents lblStartTime As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblMandore As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblAssistant As System.Windows.Forms.Label
    Friend WithEvents tbProcessLog As System.Windows.Forms.TabPage
    Friend WithEvents tbProcessingInfo As System.Windows.Forms.TabPage
    Friend WithEvents Label114 As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtLogRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblProcessingYearToDate As System.Windows.Forms.Label
    Friend WithEvents lblProcessingMonthToDate As System.Windows.Forms.Label
    Friend WithEvents lblProcessingToday As System.Windows.Forms.Label
    Friend WithEvents lblLossOnKernelMonthTon As System.Windows.Forms.Label
    Friend WithEvents lblKernelMonthTon As System.Windows.Forms.Label
    Friend WithEvents lblLossOnKernelTon As System.Windows.Forms.Label
    Friend WithEvents lblKernelProcessTon As System.Windows.Forms.Label
    Friend WithEvents lblLossOnKernelYearTon As System.Windows.Forms.Label
    Friend WithEvents lblKernelYearTon As System.Windows.Forms.Label
    Friend WithEvents txtLossOnKernelYear As System.Windows.Forms.TextBox
    Friend WithEvents txtKernelYear As System.Windows.Forms.TextBox
    Friend WithEvents txtLossOnKernelMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtKernelMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtLossOnKernelToday As System.Windows.Forms.TextBox
    Friend WithEvents txtKerneltoday As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents lblLossOnKernel As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents lblKernelProcess As System.Windows.Forms.Label
    Friend WithEvents tpPKOProductionView As System.Windows.Forms.TabPage
    Friend WithEvents dgvPKOProductionLogView As System.Windows.Forms.DataGridView
    Friend WithEvents ExtendedPanel1 As Stepi.UI.ExtendedPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblSearchby As System.Windows.Forms.Label
    Friend WithEvents Label166 As System.Windows.Forms.Label
    Friend WithEvents chkPKOLogDate As System.Windows.Forms.CheckBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents tbPressInfo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVarianceBudget As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblVariance As System.Windows.Forms.Label
    Friend WithEvents txtmonthtodatBudget As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblMonthToDate As System.Windows.Forms.Label
    Friend WithEvents txtBudget As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblBudget As System.Windows.Forms.Label
    Friend WithEvents lblTons As System.Windows.Forms.Label
    Friend WithEvents txtBFQty As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBFQty As System.Windows.Forms.Label
    Friend WithEvents gpReceivedKernel As System.Windows.Forms.GroupBox
    Friend WithEvents txtYearTodateRecKer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblYearTodateMt As System.Windows.Forms.Label
    Friend WithEvents txtqtyMtKerRecd As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblQtyMt As System.Windows.Forms.Label
    Friend WithEvents txtTodateMtRecKer As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblTodate As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents lbllocation As System.Windows.Forms.Label
    Friend WithEvents dgvReceivedKernel As System.Windows.Forms.DataGridView
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtTotalReceivedQtyKerRec As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTotalReceivedQty As System.Windows.Forms.Label
    Friend WithEvents lblMechanicalMonthHrs As System.Windows.Forms.Label
    Friend WithEvents lblPKOProductionMonthTon As System.Windows.Forms.Label
    Friend WithEvents lblMechanicalHrs As System.Windows.Forms.Label
    Friend WithEvents lblPKOProductionTon As System.Windows.Forms.Label
    Friend WithEvents lblMechanicalYearHrs As System.Windows.Forms.Label
    Friend WithEvents lblPKOProductionYearTon As System.Windows.Forms.Label
    Friend WithEvents txtMechanicalBreakDownYear As System.Windows.Forms.TextBox
    Friend WithEvents txtPKOProductionYear As System.Windows.Forms.TextBox
    Friend WithEvents txtMechanicalBreakDownMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtPKOProductionMonthTodate As System.Windows.Forms.TextBox
    Friend WithEvents txtMechanicalBreakDownToday As System.Windows.Forms.TextBox
    Friend WithEvents txtPKOProductionToday As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents lblMechanicalBreakDown As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents lblPKOProduction As System.Windows.Forms.Label
    Friend WithEvents lblThroughputMonthKgHr As System.Windows.Forms.Label
    Friend WithEvents lblThroughputKgHr As System.Windows.Forms.Label
    Friend WithEvents lblThroughputYearKgHr As System.Windows.Forms.Label
    Friend WithEvents txtThroughputYear As System.Windows.Forms.TextBox
    Friend WithEvents txtThroughputMonthTodate As System.Windows.Forms.TextBox
    Friend WithEvents txtThroughput As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents lblThroughput As System.Windows.Forms.Label
    Friend WithEvents lblEffectiveMonthHrs As System.Windows.Forms.Label
    Friend WithEvents lblEffectiveProcessingHrs As System.Windows.Forms.Label
    Friend WithEvents lblEffectiveYearHrs As System.Windows.Forms.Label
    Friend WithEvents txtEffectiveProcessingHoursYear As System.Windows.Forms.TextBox
    Friend WithEvents txtEffectiveProcessingHoursMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtEffectiveProcessingHoursToday As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents lblEffectiveProcessing As System.Windows.Forms.Label
    Friend WithEvents lblTotalMonthHrs As System.Windows.Forms.Label
    Friend WithEvents lblTotalBreakDownHrs As System.Windows.Forms.Label
    Friend WithEvents lblTotalYearsHrs As System.Windows.Forms.Label
    Friend WithEvents txtTotalBreakDownYear As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalBreakDownMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalBreakDownToday As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents lblTotalBreakDown As System.Windows.Forms.Label
    Friend WithEvents lblProcessingMonthHrs As System.Windows.Forms.Label
    Friend WithEvents lblProcessingHrs As System.Windows.Forms.Label
    Friend WithEvents lblProcessingYearHrs As System.Windows.Forms.Label
    Friend WithEvents txtProcessingBreakDownYear As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingBreakDownMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessingBreakDownToday As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents lblProcessingBreakDown As System.Windows.Forms.Label
    Friend WithEvents lblElectricalMonthHrs As System.Windows.Forms.Label
    Friend WithEvents lblElectricalHrs As System.Windows.Forms.Label
    Friend WithEvents lblElectricalYearHrs As System.Windows.Forms.Label
    Friend WithEvents txtElectricalBreakDownYear As System.Windows.Forms.TextBox
    Friend WithEvents txtElectricalBreakDownMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtElectricalBreakDownToday As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents lblElectricalBreakDown As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetPressinfo As System.Windows.Forms.Button
    Friend WithEvents btnAddPressInfo As System.Windows.Forms.Button
    Friend WithEvents txtTotalHoursPress As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents lblTotalHoursPress As System.Windows.Forms.Label
    Friend WithEvents dgPressInfo As System.Windows.Forms.DataGridView
    Friend WithEvents txtMeterFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents lblMeterFrom As System.Windows.Forms.Label
    Friend WithEvents txtPressNo As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents lblPressNo As System.Windows.Forms.Label
    Friend WithEvents txtAgeOfScrew As System.Windows.Forms.TextBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents lblAgeOfscrew As System.Windows.Forms.Label
    Friend WithEvents lblStage As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents lblScrewStatus As System.Windows.Forms.Label
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents lblCapacity As System.Windows.Forms.Label
    Friend WithEvents txtOPHrs As System.Windows.Forms.TextBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents lblOPHrs As System.Windows.Forms.Label
    Friend WithEvents txtMeterTo As System.Windows.Forms.TextBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents lblMeterTo As System.Windows.Forms.Label
    Friend WithEvents txtAvgPressThroughput As System.Windows.Forms.TextBox
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents lvlAvgpresstp As System.Windows.Forms.Label
    Friend WithEvents txtCakeProcess As System.Windows.Forms.TextBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents lblCakeProcess As System.Windows.Forms.Label
    Friend WithEvents lblCakeProcessTons As System.Windows.Forms.Label
    Friend WithEvents lblAvgpresstpTons As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAvgPressStage2Kg As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage1MonthKg As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage2MonthKg As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage1YrKg As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage2YrKg As System.Windows.Forms.Label
    Friend WithEvents lblUtilisationStage2 As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage2 As System.Windows.Forms.Label
    Friend WithEvents txtutilstage2yeartodate As System.Windows.Forms.TextBox
    Friend WithEvents txtutilstage2monthtodate As System.Windows.Forms.TextBox
    Friend WithEvents txtutilstage2 As System.Windows.Forms.TextBox
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents txtutilstage1yeartodate As System.Windows.Forms.TextBox
    Friend WithEvents txtutilstage1monthtodate As System.Windows.Forms.TextBox
    Friend WithEvents txtutilstage1today As System.Windows.Forms.TextBox
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents lblUtilisation As System.Windows.Forms.Label
    Friend WithEvents txtAPTStage2yeartodate As System.Windows.Forms.TextBox
    Friend WithEvents txtAPTstage2monthtodae As System.Windows.Forms.TextBox
    Friend WithEvents txtAPTstage2today As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage1Kg As System.Windows.Forms.Label
    Friend WithEvents txtAPTstage1yeartodate As System.Windows.Forms.TextBox
    Friend WithEvents txtAPHstage1monthtodate As System.Windows.Forms.TextBox
    Friend WithEvents txtAPTstage1today As System.Windows.Forms.TextBox
    Friend WithEvents Label98 As System.Windows.Forms.Label
    Friend WithEvents lblAveragePressThroughput As System.Windows.Forms.Label
    Friend WithEvents lblPressYear As System.Windows.Forms.Label
    Friend WithEvents lblPressMonth As System.Windows.Forms.Label
    Friend WithEvents lblPressToday As System.Windows.Forms.Label
    Friend WithEvents txtStage2yearTodate As System.Windows.Forms.TextBox
    Friend WithEvents txtTPHYearTodateStage1 As System.Windows.Forms.TextBox
    Friend WithEvents txtStage2monthTodate As System.Windows.Forms.TextBox
    Friend WithEvents txtTPHMonthTodateStage1 As System.Windows.Forms.TextBox
    Friend WithEvents txtStage2TodayTPH As System.Windows.Forms.TextBox
    Friend WithEvents txtTPHTodaystage1 As System.Windows.Forms.TextBox
    Friend WithEvents Label109 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPHStage2 As System.Windows.Forms.Label
    Friend WithEvents Label111 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPressHours As System.Windows.Forms.Label
    Friend WithEvents lblUtilisationStage1 As System.Windows.Forms.Label
    Friend WithEvents lblAvgPressStage1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalPHStage1 As System.Windows.Forms.Label
    Friend WithEvents dtPKOProductionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label99 As System.Windows.Forms.Label
    Friend WithEvents btnResetAll As System.Windows.Forms.Button
    Friend WithEvents btnSaveAll As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dtpPKOProdLogDateSearch As System.Windows.Forms.DateTimePicker
    Friend WithEvents ddlLoadingLocationKerRecd As System.Windows.Forms.ComboBox
    Friend WithEvents ddlScrewStatus As System.Windows.Forms.ComboBox
    Friend WithEvents txtKERYear As System.Windows.Forms.TextBox
    Friend WithEvents txtKERMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtKERToday As System.Windows.Forms.TextBox
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents lblKER As System.Windows.Forms.Label
    Friend WithEvents gplblProcessedKernel As System.Windows.Forms.GroupBox
    Friend WithEvents lblKernelReceived As System.Windows.Forms.Label
    Friend WithEvents lblKernelToday As System.Windows.Forms.Label
    Friend WithEvents lblKernelMonthToDate As System.Windows.Forms.Label
    Friend WithEvents lblKernelYearToDate As System.Windows.Forms.Label
    Friend WithEvents txtKernelProcessedYear As System.Windows.Forms.TextBox
    Friend WithEvents txtKernelProcessedMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtKernelProcessedToday As System.Windows.Forms.TextBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents lblTotalHoursPressHr As System.Windows.Forms.Label
    Friend WithEvents btnPressNoLookup As System.Windows.Forms.Button
    Friend WithEvents lblPressNoDescp As System.Windows.Forms.Label
    Friend WithEvents cmsPKOProductionLog As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ddlShift As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents btnResetShift As System.Windows.Forms.Button
    Friend WithEvents btnAddShift As System.Windows.Forms.Button
    Friend WithEvents dgvPKOLogShiftDetails As System.Windows.Forms.DataGridView
    Friend WithEvents cmsShiftInformation As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsKernelReceived As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPressInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtShiftHours As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtTotalShiftKernelProcessed As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblKernelProcessedtoday As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ddlStage As System.Windows.Forms.ComboBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents dgMeStage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMePressNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMePressNoDescp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeMeterFrom As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeMeterTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeOPHrs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeProductionLogPressID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeScrewAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeMachineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeScrewStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShift As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShiftAssistant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShiftMandore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShiftStartTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShiftStopTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShiftHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgShiftKernelProcessed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeLoadingLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeLoadingLocationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMeQtyKerRecd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgMePKOKERReceivedID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclKerRecdMonthTodate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclKerRecdYearToDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents lblOERPercentage As System.Windows.Forms.Label
    Friend WithEvents dgclProductionlogDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KernelProcessedACT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTotalBD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclEffectiveProcessingHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclPKOProductionLogID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclCropYieldID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclTotalHours As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLossOfKernel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLossOfKernelMTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclLossOfKernelYTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMechanicalBD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMechanicalBDMTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclMechanicalBDYTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclElectricalBD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclElectricalBDMTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclElectricalBDYTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProcessingBD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProcessingBDMTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclProcessingBDYTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgclRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblUtiliStage2MonthPer As System.Windows.Forms.Label
    Friend WithEvents lblUtilisStage1MonthPer As System.Windows.Forms.Label
    Friend WithEvents btnDeleteAll As System.Windows.Forms.Button
    Friend WithEvents DeletePressInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteShiftInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteKernelReceived As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtStartTime As System.Windows.Forms.TextBox
    Friend WithEvents txtStopTime As System.Windows.Forms.TextBox
End Class

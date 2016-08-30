Imports Production_BOL
Imports Production_PPT
Imports Common_BOL
Imports Common_PPT
Imports System.Data.SqlClient
Imports System.Globalization

Public Class PKOProductionLogFrm

    Dim lTotalOPHoursStage1 As String = "00:00"
    Dim lTotalOPHoursStage2 As String = "00:00"
    Dim lTotalOPHours As TimeSpan
    Dim lPKOProductionLogID As String = String.Empty
    Dim lProductionLogPressID As String = String.Empty
    Dim lTotalOPHoursMonth As String = String.Empty
    Dim lTotalOPHoursYear As String = String.Empty
    Dim dtKerRecd As New DataTable("todgKerRecd")
    Dim dtPressInfo As New DataTable("todgPressInfo")
    Dim rowMultipleEntryAddKerRecd, rowMultipleEntryPressInfo As DataRow
    Dim columnPressInfoAdd, ColumnKerRecdAdd As DataColumn
    Dim rowPressInfoAdd, rowKerRecdAdd As DataRow
    Dim lbtnAddKerRecd As String = String.Empty
    Dim lbtnAddPressInfo As String = String.Empty
    Dim lPKOKERReceivedID As String = String.Empty
    Dim lbtnAddShift As String = String.Empty
    Dim lMachineID As String = String.Empty
    Dim lbtnsaveall As String = String.Empty
    Dim lcropYieldID As String = String.Empty
    Dim lHrsStartTime As String
    Dim lminStartTime As String
    Dim lHrsStopTime As String
    Dim lminStopTime As String
    Dim ltotalHours As Integer
    Dim is2Decimal As Boolean
    Dim re2DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,15}(\.\d{0,2})?$")
    Dim is3Decimal As Boolean
    Dim re3DecimalPlaces As New System.Text.RegularExpressions.Regex("^\d{0,14}(\.\d{0,3})?$")
    Dim TimeValidation As New System.Text.RegularExpressions.Regex("^(([0]?[1-9]|1[0-2])(:)([0-5][0-9]))$")
    Dim isModifierKey As Boolean
    Dim lStage As String = String.Empty
    Dim lPressNo As String = String.Empty
    Dim lLoadingLocation As String = String.Empty
    Dim dtPKOShiftAdd As New DataTable("todgvPKOShiftAdd")
    Dim columnPKOShiftAdd As DataColumn
    Dim rowPKOShiftAdd As DataRow
    Dim lshift As String
    Private DecimalCheck As Boolean = False
    Dim ltrue As Boolean = False
    Private lTodateMtRecKer As Decimal = 0
    Private lYearTodateRecKer As Decimal = 0
    Private LoadMonthCount As Integer
    Private LoadYearCount As Integer
    Private lqtyMtKerRecd As Decimal = 0

    Dim lmonthValuehrs As String = "00:00"
    Dim lYearValue As String = "00:00"
    Private MonthCount As Integer
    Private YearCount As Integer
    Dim lShifthours As String = "00:00"
    Private lPrevHrs As String = "00:00"
    Private lPrevmechHrs As String = "00:00"
    Private lPrevElecHrs As String = "00:00"
    Private lPrevProcessHrs As String = "00:00"

    Dim lmonthValuehrsSumm As String = "00:00"
    Dim lYearValueSumm As String = "00:00"
    Private MonthCountSumm As Integer
    Private YearCountSumm As Integer
    Private lTotalHrs As Decimal
    Private stage2PressSummaryID, stage1PressSummaryID As String
    Private PrevStage1TPH As String = "00:00"
    Private PrevStage2TPH As String = "00:00"
    Private lKernelMonth As Decimal = 0
    Private lKernelYear As Decimal = 0
    Private lLossOnKernelMonth As Decimal = 0
    Private lLossOnKernelYear As Decimal = 0
    Dim lMechanicalBreakDownYear As String = "00:00"
    Dim lMechanicalBreakDownMonth As String = "00:00"
    Dim lElectricalBreakDownYear As String = "00:00"
    Dim lElectricalBreakDownMonth As String = "00:00"
    Dim lProcessingBreakDownYear As String = "00:00"
    Dim lProcessingBreakDownMonth As String = "00:00"
    Dim lEffectiveProcessingHoursYear As String = "00:00"
    Dim lEffectiveProcessingHoursMonth As String = "00:00"
    Dim lTotalBreakDownYear As String = "00:00"
    Dim lTotalBreakDownMonth As String = "00:00"
    Private KernelYearCount, KernelMonthCount As Integer
    Private lkernelPrevQty As Decimal

    Dim objUserLoginBOl As New Common_BOL.UserLoginBOL
    Dim PrivilegeError As String = String.Empty
    Dim lstageCountMonth, lstageCountYear As Integer
    Dim lPrevLossonKernel As Decimal
    Dim lDelete As Integer
    Dim DeleteMultientryPressInfo As New ArrayList
    Dim DeleteMultientryKernelReceived As New ArrayList
    Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionLogFrm))
    Shadows mdiparent As New MDIParent

    Private Sub Datefunction()

        'Dim Str As String = TimeOfDay.Hour
        'If Str < 10 Then
        '    Str = "0" + Str
        'End If
        'cmbStartHours.Text = Str
        'cmbStopHours.Text = Str

        'If TimeOfDay.Minute < 5 Then
        '    cmbStartMin.Text = "00"
        '    cmbStopMin.Text = "00"
        'ElseIf TimeOfDay.Minute >= 5 And TimeOfDay.Minute < 10 Then
        '    cmbStartMin.Text = "05"
        '    cmbStopMin.Text = "05"
        'ElseIf TimeOfDay.Minute >= 10 And TimeOfDay.Minute < 15 Then
        '    cmbStartMin.Text = "10"
        '    cmbStopMin.Text = "10"
        'ElseIf TimeOfDay.Minute >= 15 And TimeOfDay.Minute < 20 Then
        '    cmbStartMin.Text = "15"
        '    cmbStopMin.Text = "15"
        'ElseIf TimeOfDay.Minute >= 20 And TimeOfDay.Minute < 25 Then
        '    cmbStartMin.Text = "20"
        '    cmbStopMin.Text = "20"
        'ElseIf TimeOfDay.Minute >= 25 And TimeOfDay.Minute < 30 Then
        '    cmbStartMin.Text = "25"
        '    cmbStopMin.Text = "25"
        'ElseIf TimeOfDay.Minute >= 30 And TimeOfDay.Minute < 35 Then
        '    cmbStartMin.Text = "30"
        '    cmbStopMin.Text = "30"
        'ElseIf TimeOfDay.Minute >= 35 And TimeOfDay.Minute < 40 Then
        '    cmbStartMin.Text = "35"
        '    cmbStopMin.Text = "35"
        'ElseIf TimeOfDay.Minute >= 40 And TimeOfDay.Minute < 45 Then
        '    cmbStartMin.Text = "40"
        '    cmbStopMin.Text = "40"
        'ElseIf TimeOfDay.Minute >= 45 And TimeOfDay.Minute < 50 Then
        '    cmbStartMin.Text = "45"
        '    cmbStopMin.Text = "45"
        'ElseIf TimeOfDay.Minute >= 50 And TimeOfDay.Minute < 55 Then
        '    cmbStartMin.Text = "50"
        '    cmbStopMin.Text = "50"
        'ElseIf TimeOfDay.Minute >= 55 And TimeOfDay.Minute < 60 Then
        '    cmbStartMin.Text = "55"
        '    cmbStopMin.Text = "55"
        'End If

    End Sub


    Private Sub clear()

        txtAssistant.Text = String.Empty
        txtMandor.Text = String.Empty
        'ChkbxShift1.Checked = False
        'ChkbxShift2.Checked = False
        'ChkbxShift3.Checked = False
        txtBFQty.Text = String.Empty
        txtBFQty.Enabled = True
        txtKerneltoday.Text = ""
        txtKernelProcessed.Text = String.Empty
        txtKernelProcessedToday.Text = String.Empty
        txtLossOnKernelToday.Text = String.Empty
        txtElectricalBreakDownToday.Text = String.Empty
        txtMechanicalBreakDownToday.Text = String.Empty
        txtProcessingBreakDownToday.Text = String.Empty
        lPrevmechHrs = "00:00"
        lPrevElecHrs = "00:00"
        lPrevProcessHrs = "00:00"

        ClearReceivedKernelGB()
        ClearLogExpress()
        txtTotalHoursPress.Text = String.Empty
        txtAvgPressThroughput.Text = String.Empty
        txtCakeProcess.Text = String.Empty
        Datefunction()
        lbtnsaveall = "Save All"
        btnSaveAll.Enabled = True
        btnDeleteAll.Enabled = True
        If GlobalPPT.strLang = "en" Then
            btnSaveAll.Text = "Save All"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnSaveAll.Text = "Simpan Semua"
        End If
        ''btnSaveAll.Text = "Save All"
        dtPKOProductionDate.Enabled = True
        txtTotalReceivedQtyKerRec.Text = String.Empty
        'commented by suraya 12-09-12
        'dtPKOProductionDate.MaxDate = Date.Today


        'dtPKOProductionDate.MinDate = New DateTime(GlobalPPT.FiscalYearFromDate.Year, GlobalPPT.FiscalYearFromDate.Month, GlobalPPT.FiscalYearFromDate.Day)

        'dtpPKOProdLogDateSearch.MaxDate = Date.Today
        'Dim Fromdate As Date = GlobalPPT.FiscalYearFromDate.Date
       
        'If dgvPKOProductionLogView.RowCount <> 0 Then
        '    Dim ProdDate As Date
        '    ProdDate = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString()
        '    dtPKOProductionDate.MinDate = DateAdd(DateInterval.Day, 1, ProdDate)
        'Else
        '    dtPKOProductionDate.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'End If

        'dtpPKOProdLogDateSearch.MinDate = New DateTime(Fromdate.Year, Fromdate.Month, Fromdate.Day)
        'dtpPKOProdLogDateSearch.Value = Date.Today

        'add by suraya 12-09-12
        'dtPKOProductionDate.Format = DateTimePickerFormat.Custom 'edit
        'dtPKOProductionDate.CustomFormat = "dd/MM/yyyy"
        'GlobalBOL.SetDateTimePicker(Me.dtPKOProductionDate)

        'dtpPKOProdLogDateSearch.Format = DateTimePickerFormat.Custom
        'dtpPKOProdLogDateSearch.CustomFormat = "dd/MM/yyyy"
        'GlobalBOL.SetDateTimePicker(Me.dtpPKOProdLogDateSearch)


        txtLogRemarks.Text = String.Empty

        txtTotalHours.Text = String.Empty
        txtLossOnKernelToday.Text = String.Empty
        txtMechanicalBreakDownToday.Text = String.Empty
        txtElectricalBreakDownToday.Text = String.Empty
        txtProcessingBreakDownToday.Text = String.Empty
        txtTotalBreakDownToday.Text = String.Empty
        txtEffectiveProcessingHoursToday.Text = String.Empty

        txtMonthTodateHrs.Text = String.Empty
        txtYearTodateHrs.Text = String.Empty
        txtPKOProductionToday.Text = String.Empty
        txtPKOProductionMonthTodate.Text = String.Empty
        txtPKOProductionYear.Text = String.Empty

        txtLossOnKernelMonth.Text = String.Empty
        txtMechanicalBreakDownMonth.Text = String.Empty
        txtElectricalBreakDownMonth.Text = String.Empty
        txtProcessingBreakDownMonth.Text = String.Empty
        txtTotalBreakDownMonth.Text = String.Empty
        txtEffectiveProcessingHoursMonth.Text = String.Empty

        txtLossOnKernelYear.Text = String.Empty
        txtMechanicalBreakDownYear.Text = String.Empty
        txtElectricalBreakDownYear.Text = String.Empty
        txtProcessingBreakDownYear.Text = String.Empty
        txtTotalBreakDownYear.Text = String.Empty
        txtEffectiveProcessingHoursYear.Text = String.Empty
        txtTPHTodaystage1.Text = String.Empty
        txtStage2TodayTPH.Text = String.Empty
        txtAPTstage1today.Text = String.Empty
        txtAPTstage2today.Text = String.Empty
        txtutilstage1today.Text = String.Empty
        txtutilstage2.Text = String.Empty

        txtTotalHoursPress.Text = ""
        txtAvgPressThroughput.Text = ""
        txtCakeProcess.Text = ""
       
        chkPKOLogDate.Checked = False
        lPrevLossonKernel = 0

        ''Month

        txtTPHMonthTodateStage1.Text = String.Empty
        txtStage2monthTodate.Text = String.Empty
        txtAPHstage1monthtodate.Text = String.Empty
        txtAPTstage2monthtodae.Text = String.Empty
        txtutilstage1monthtodate.Text = String.Empty
        txtutilstage2monthtodate.Text = String.Empty

        ''year

        txtTPHYearTodateStage1.Text = String.Empty
        txtStage2yearTodate.Text = String.Empty
        txtAPTstage1yeartodate.Text = String.Empty
        txtAPTStage2yeartodate.Text = String.Empty
        txtutilstage1yeartodate.Text = String.Empty
        txtutilstage2yeartodate.Text = String.Empty

        '120912 suraya
        'dtPKOProductionDate.Value = Date.Today 
        tcPKOLog.SelectedIndex = 0
        ' tcPKOroductionLog.SelectedIndex = 0
        dtPKOProductionDate.Focus()
        txtTotalShiftKernelProcessed.Text = ""
        'GetMonthVaues()
        'GetYearVaues()
        'GetTodayVaues()
        GetPKOProductionLogPressOPHrsValue()
        GetTPHMonth()
        GetTPHYear()
        GetKernelStorageBFValue()

        If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            MsgBox(PrivilegeError)
        End If

    End Sub
    Private Sub ClearReceivedKernelGB()
        ddlLoadingLocationKerRecd.SelectedIndex = 0
        txtqtyMtKerRecd.Text = String.Empty
        lbtnAddKerRecd = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAdd.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAdd.Text = "Menambahkan"
        End If
        ''btnAdd.Text = "Add"
        txtTotalReceivedQtyKerRec.Text = ""

    End Sub
    Private Sub ClearShift()
        ddlShift.SelectedIndex = 0
        txtAssistant.Text = String.Empty
        txtMandor.Text = String.Empty
        txtKernelProcessed.Text = String.Empty
        txtShiftHours.Text = String.Empty
        txtStartTime.Text = String.Empty
        txtStopTime.Text = String.Empty
        lbtnAddShift = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAddShift.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddShift.Text = "Menambahkan"
        End If
        ''btnAddShift.Text = "Add"
    End Sub
    Private Sub ClearLogExpress()
        ddlStage.SelectedIndex = 0
        txtOPHrs.Text = String.Empty
        txtCapacity.Text = String.Empty
        txtAgeOfScrew.Text = String.Empty
        txtMeterFrom.Text = String.Empty
        ddlScrewStatus.SelectedIndex = 0
        txtPressNo.Text = String.Empty
        txtMeterTo.Text = String.Empty
        lblPressNoDescp.Text = String.Empty
        lMachineID = String.Empty
        lbtnAddPressInfo = "Add"
        If GlobalPPT.strLang = "en" Then
            btnAddPressInfo.Text = "Add"
        ElseIf GlobalPPT.strLang = "ms" Then
            btnAddPressInfo.Text = "Menambahkan"
        End If
        ''btnAddPressInfo.Text = "Add"
        PrevStage1TPH = "00:00"
        PrevStage2TPH = "00:00"

    End Sub

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
        End If
    End Sub

    Private Sub GetMonthVaues()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL

        Dim dsMonthValues As New DataSet
        objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value
        dsMonthValues = PKOProductionLogBOL.GetMonthValues(objPKOProductionLogPPT)

        If dsMonthValues.Tables(0).Rows.Count <> 0 And dsMonthValues IsNot Nothing Then
            lLossOnKernelMonth = Val(dsMonthValues.Tables(0).Rows(0).Item("MonthValuesLossOfKernel").ToString)
        End If
        If txtLossOnKernelMonth.Enabled = False Then
            If Val(txtLossOnKernelToday.Text) > 0 Then
                txtLossOnKernelMonth.Text = lLossOnKernelMonth + Val(txtLossOnKernelToday.Text) - lPrevLossonKernel
            Else
                txtLossOnKernelMonth.Text = lLossOnKernelMonth
            End If
        End If
      

        If dsMonthValues.Tables(1).Rows.Count <> 0 And dsMonthValues IsNot Nothing Then
            txtPKOProductionMonthTodate.Text = dsMonthValues.Tables(1).Rows(0).Item("MonthValuesQtyToday").ToString
        End If

        KernelMonthCount = dsMonthValues.Tables(23).Rows(0).Item("KernelMonthCount").ToString

        If KernelMonthCount = 0 Or (KernelMonthCount = 1 And lbtnsaveall <> "Save All") Then
            txtKernelProcessedMonth.Enabled = True
            txtKernelProcessedYear.Enabled = True
        Else
            txtKernelProcessedMonth.Enabled = False
            txtKernelProcessedYear.Enabled = False
        End If


        '   If txtKernelProcessedMonth.Enabled = False Then
        If dsMonthValues.Tables(2).Rows.Count <> 0 And dsMonthValues IsNot Nothing Then
            lKernelMonth = Val(dsMonthValues.Tables(2).Rows(0).Item("KernelProcessedACTMTD").ToString)
        End If
        If lKernelMonth <> 0 Then
            txtKernelProcessedMonth.Text = lKernelMonth
        End If
        '  End If
        lMechanicalBreakDownMonth = dsMonthValues.Tables(12).Rows(0).Item("MonthValuesMechanicalBD").ToString
        lMechanicalBreakDownMonth = ToModifyTime(lMechanicalBreakDownMonth)

        If lMechanicalBreakDownMonth <> "00:00" Then
            txtMechanicalBreakDownMonth.Text = lMechanicalBreakDownMonth
        End If
        lElectricalBreakDownMonth = dsMonthValues.Tables(17).Rows(0).Item("MonthValuesElectricalBD").ToString
        lElectricalBreakDownMonth = ToModifyTime(lElectricalBreakDownMonth)
        If lElectricalBreakDownMonth <> "00:00" Then
            txtElectricalBreakDownMonth.Text = lElectricalBreakDownMonth
        End If

        lProcessingBreakDownMonth = dsMonthValues.Tables(22).Rows(0).Item("MonthValuesProcessingBD").ToString
        lProcessingBreakDownMonth = ToModifyTime(lProcessingBreakDownMonth)
        If lProcessingBreakDownMonth <> "00:00" Then
            txtProcessingBreakDownMonth.Text = lProcessingBreakDownMonth
        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownMonth.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownMonth.Text
        End If
        If txtElectricalBreakDownMonth.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownMonth.Text
        End If
        If txtProcessingBreakDownMonth.Text <> "" Then
            lProcessBK = txtProcessingBreakDownMonth.Text
        End If


        lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If (txtMechanicalBreakDownMonth.Text <> "" Or txtElectricalBreakDownMonth.Text <> "" Or txtProcessingBreakDownMonth.Text <> "") Then
            txtTotalBreakDownMonth.Text = lBDCalculation
        Else
            txtTotalBreakDownMonth.Text = ""
        End If

        'lEffectiveProcessingHoursMonth = dsMonthValues.Tables(19).Rows(0).Item("MonthValuesEffectiveProcessingHours").ToString
        'lEffectiveProcessingHoursMonth = ToModifyTime(lEffectiveProcessingHoursMonth)
        'If txtEffectiveProcessingHoursToday.Text <> "" Then
        '    txtEffectiveProcessingHoursMonth.Text = ToaddHours(txtEffectiveProcessingHoursToday.Text, lEffectiveProcessingHoursMonth)
        'Else
        '    txtEffectiveProcessingHoursMonth.Text = lEffectiveProcessingHoursMonth
        'End If

        'lTotalBreakDownMonth = dsMonthValues.Tables(22).Rows(0).Item("MonthValuesTotalBDHours").ToString
        'lTotalBreakDownMonth = ToModifyTime(lTotalBreakDownMonth)
        'If txtTotalBreakDownToday.Text = "" Then
        '    txtTotalBreakDownMonth.Text = lTotalBreakDownMonth
        'End If



    End Sub

    Private Sub GetYearVaues()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        Dim dsYearValues As New DataSet
        objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value

        dsYearValues = PKOProductionLogBOL.GetYearValues(objPKOProductionLogPPT)

        If dsYearValues.Tables(0).Rows.Count <> 0 And dsYearValues IsNot Nothing And (Not dsYearValues.Tables(0).Rows(0).Item("YearValuesLossOfKernel") Is DBNull.Value) Then
            lLossOnKernelYear = dsYearValues.Tables(0).Rows(0).Item("YearValuesLossOfKernel").ToString
        End If
        If txtLossOnKernelMonth.Enabled = False Then
            If Val(txtLossOnKernelToday.Text) > 0 Then
                txtLossOnKernelYear.Text = lLossOnKernelYear + Val(txtLossOnKernelToday.Text) - lPrevLossonKernel
            ElseIf lLossOnKernelYear > 0 Then
                txtLossOnKernelYear.Text = lLossOnKernelYear
            End If
        End If

        If dsYearValues.Tables(1).Rows.Count <> 0 And dsYearValues IsNot Nothing Then
            txtPKOProductionYear.Text = dsYearValues.Tables(1).Rows(0).Item("YearValuesQtyToday").ToString
        End If
        ' If txtKernelProcessedYear.Enabled = False Then
        If dsYearValues.Tables(2).Rows.Count <> 0 And dsYearValues IsNot Nothing Then
            lKernelYear = Val(dsYearValues.Tables(2).Rows(0).Item("KernelProcessedACYTD").ToString)
        End If
        If Val(txtKernelProcessedToday.Text) >= 0 Then
            txtKernelProcessedYear.Text = lKernelYear + Val(txtKernelProcessedToday.Text) - lkernelPrevQty
        ElseIf lKernelYear >= 0 Then
            txtKernelProcessedYear.Text = lKernelYear
        End If
        ' End If
        lMechanicalBreakDownYear = dsYearValues.Tables(12).Rows(0).Item("YearValuesMechanicalBD").ToString
        lMechanicalBreakDownYear = ToModifyTime(lMechanicalBreakDownYear)

        If lMechanicalBreakDownYear <> "00:00" And txtMechanicalBreakDownYear.Enabled = False Then
            txtMechanicalBreakDownYear.Text = lMechanicalBreakDownYear
        End If
        lElectricalBreakDownYear = dsYearValues.Tables(17).Rows(0).Item("YearValuesElectricalBD").ToString
        lElectricalBreakDownYear = ToModifyTime(lElectricalBreakDownYear)
        If lElectricalBreakDownYear <> "00:00" And txtElectricalBreakDownYear.Enabled = False Then
            txtElectricalBreakDownYear.Text = lElectricalBreakDownYear
        End If

        lProcessingBreakDownYear = dsYearValues.Tables(22).Rows(0).Item("YearValuesProcessingBD").ToString
        lProcessingBreakDownYear = ToModifyTime(lProcessingBreakDownYear)
        If lProcessingBreakDownYear <> "00:00" And txtProcessingBreakDownYear.Enabled = False Then
            txtProcessingBreakDownYear.Text = lProcessingBreakDownYear
        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownYear.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownYear.Text
        End If
        If txtElectricalBreakDownYear.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownYear.Text
        End If
        If txtProcessingBreakDownYear.Text <> "" Then
            lProcessBK = txtProcessingBreakDownYear.Text
        End If


        lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If (txtMechanicalBreakDownYear.Text <> "" Or txtElectricalBreakDownYear.Text <> "" Or txtProcessingBreakDownYear.Text <> "") Then
            txtTotalBreakDownYear.Text = lBDCalculation
        Else
            txtTotalBreakDownYear.Text = ""
        End If


        'lEffectiveProcessingHoursYear = dsYearValues.Tables(19).Rows(0).Item("YearValuesEffectiveProcessingHours").ToString
        'lEffectiveProcessingHoursYear = ToModifyTime(lEffectiveProcessingHoursYear)
        'If txtEffectiveProcessingHoursToday.Text <> "" Then
        '    txtEffectiveProcessingHoursYear.Text = ToaddHours(txtEffectiveProcessingHoursToday.Text, lEffectiveProcessingHoursYear)
        'Else
        '    txtEffectiveProcessingHoursYear.Text = lEffectiveProcessingHoursYear
        'End If

        'lTotalBreakDownYear = dsYearValues.Tables(22).Rows(0).Item("YearValuesTotalBDHours").ToString
        'lTotalBreakDownYear = ToModifyTime(lTotalBreakDownYear)
        'If txtTotalBreakDownToday.Text = "" Then
        '    txtTotalBreakDownYear.Text = lTotalBreakDownYear
        'End If
        KernelYearCount = dsYearValues.Tables(23).Rows(0).Item("KernelYearCount").ToString

    End Sub

    Private Sub GetTotalReceivedQtyKerRec()
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            Dim lTotalReceivedQtyKerRec As Decimal = 0

            For Each objDataGridViewRow In dgvReceivedKernel.Rows

                If objDataGridViewRow.Cells("dgMeQtyKerRecd").Value.ToString <> String.Empty Then
                    lTotalReceivedQtyKerRec = lTotalReceivedQtyKerRec + Val(objDataGridViewRow.Cells("dgMeQtyKerRecd").Value.ToString())
                End If
            Next

            If lTotalReceivedQtyKerRec <> 0 Then
                txtTotalReceivedQtyKerRec.Text = lTotalReceivedQtyKerRec
            Else
                txtTotalReceivedQtyKerRec.Text = ""
            End If
            lTotalReceivedQtyKerRec = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Sub

    'Private Sub GetTodayVaues()

    '    Dim lBDCalculation, lMechaniclBD, lelectriclBD, lProcessBK As TimeSpan

    '    If txtMechanicalBreakDownToday.Text <> "" Then
    '        lMechaniclBD = TimeSpan.Parse(txtMechanicalBreakDownToday.Text)

    '    End If
    '    If txtElectricalBreakDownToday.Text <> "" Then
    '        lelectriclBD = TimeSpan.Parse(txtElectricalBreakDownToday.Text)
    '    End If
    '    If txtProcessingBreakDownToday.Text <> "" Then
    '        lProcessBK = TimeSpan.Parse(txtProcessingBreakDownToday.Text)
    '    End If
    '    'If txtTotalBreakDownToday.Text <> "" Then
    '    '    lProcessBK = TimeSpan.Parse(txtTotalBreakDownToday.Text)
    '    'End If

    '    lBDCalculation = lMechaniclBD + lelectriclBD + lProcessBK

    '    If (txtMechanicalBreakDownToday.Text <> "" Or txtElectricalBreakDownToday.Text <> "" Or txtProcessingBreakDownToday.Text <> "") Then
    '        txtTotalBreakDownToday.Text = Convert.ToString(lBDCalculation)
    '    End If

    '    If txtTotalHours.Text <> "" And txtTotalBreakDownToday.Text <> "" Then
    '        MsgBox("Total hours should be greater than Total BreakDown Hours")
    '        Exit Sub
    '    End If


    '    Dim lEffectiveHrs As TimeSpan
    '    If txtTotalHours.Text <> String.Empty And txtTotalBreakDownToday.Text <> String.Empty Then

    '        lEffectiveHrs = TimeSpan.Parse(txtTotalHours.Text) - TimeSpan.Parse(txtTotalBreakDownToday.Text)
    '        txtEffectiveProcessingHoursToday.Text = Convert.ToString(lEffectiveHrs)
    '    End If



    '    If Val(txtKerneltoday.Text) <> 0 And txtEffectiveProcessingHoursToday.Text <> "" Then
    '        txtThroughput.Text = Math.Round((Val(txtKerneltoday.Text) / Val(txtEffectiveProcessingHoursToday.Text)), 2)
    '    Else
    '        txtThroughput.Text = ""
    '    End If

    '    If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
    '        txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) / Val(txtKerneltoday.Text)), 2)
    '    Else
    '        txtKERToday.Text = ""
    '    End If




    'End Sub

    Private Sub GetKernelStorageBFValue()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        Dim dsKernel As New DataSet
        objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value

        dsKernel = PKOProductionLogBOL.GetKernelProductionStorage(objPKOProductionLogPPT)

        If dsKernel.Tables(0).Rows.Count <> 0 And dsKernel IsNot Nothing Then
            txtBFQty.Text = dsKernel.Tables(0).Rows(0).Item("BalanceBFQty").ToString
        Else
            txtBFQty.Text = ""
        End If


        If Val(dsKernel.Tables(1).Rows(0).Item("Monthcount").ToString) = 0 Or (Val(dsKernel.Tables(1).Rows(0).Item("Monthcount").ToString) = 1 And lbtnsaveall <> "Save All") Then
            txtBFQty.Enabled = True
        Else
            txtBFQty.Enabled = False
        End If



    End Sub


    Private Sub GetTPHMonth()

        'Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        'Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        'Dim dsTPH As New DataSet
        'objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value

        'dsTPH = PKOProductionLogBOL.GetPKOProductionLogPressMonthValue(objPKOProductionLogPPT)

        'If Convert.ToString(dsTPH.Tables(2).Rows(0).Item("MonthValuesHrsstage1").ToString) <> "" Then
        '    txtTPHMonthTodateStage1.Text = dsTPH.Tables(2).Rows(0).Item("MonthValuesHrsstage1").ToString
        'Else
        '    txtTPHMonthTodateStage1.Text = ""
        'End If
        'If Convert.ToString(dsTPH.Tables(5).Rows(0).Item("MonthValuesHrsstage2").ToString) <> "" Then
        '    txtStage2monthTodate.Text = dsTPH.Tables(5).Rows(0).Item("MonthValuesHrsstage2").ToString
        'Else
        '    txtStage2monthTodate.Text = ""
        'End If


    End Sub
    Private Sub GetTPHYear()

        'Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        'Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        'Dim dsTPH As New DataSet
        'objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value

        'dsTPH = PKOProductionLogBOL.GetPKOProductionLogPressYearValue(objPKOProductionLogPPT)

        'If Convert.ToString(dsTPH.Tables(3).Rows(0).Item("yearValuesHrsstage1").ToString) <> "" Then
        '    txtTPHYearTodateStage1.Text = dsTPH.Tables(3).Rows(0).Item("yearValuesHrsstage1").ToString
        'Else
        '    txtTPHYearTodateStage1.Text = ""
        'End If
        'If Convert.ToString(dsTPH.Tables(6).Rows(0).Item("yearValuesHrsstage2").ToString) <> "" Then
        '    txtStage2yearTodate.Text = dsTPH.Tables(6).Rows(0).Item("yearValuesHrsstage2").ToString
        'Else
        '    txtStage2yearTodate.Text = ""
        'End If


    End Sub
    Private Sub GetKernelReceivedLocation()

        Dim dt As New DataTable
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL

        dt = PKOProductionLogBOL.GetPKOProdLogLoadingLocation(objPKOProductionLogPPT)

        ' If dt.Rows.Count <> 0 And dt IsNot Nothing Then
        ddlLoadingLocationKerRecd.DataSource = dt
        ddlLoadingLocationKerRecd.DisplayMember = "Descp"
        ddlLoadingLocationKerRecd.ValueMember = "LoadingLocationID"

        Dim dr As DataRow = dt.NewRow()
        dr(1) = "--Select--"
        'dr(1) = "--Select--"
        'dr(0) = "--Select--"
        dt.Rows.InsertAt(dr, 0)

        ddlLoadingLocationKerRecd.SelectedIndex = 0
        '  End If



        'ElseIf dtLedgerType.Rows.Count <> 0 Then
        '    ddlLedgerType.DataSource = dtLedgerType
        '    ddlLedgerType.DisplayMember = "LedgerType"
        '    ddlLedgerType.ValueMember = "LedgerSetupID"

        '    Dim intRowCount As Integer
        '    intRowCount = ddlLedgerType.SelectedIndex

        '    If dtLedgerType IsNot Nothing And dtLedgerType.Rows.Count > 0 Then
        '        Dim dr As DataRow = dtLedgerType.NewRow()
        '        dr(0) = "--Select--"
        '        'dr(1) = "--Select--"
        '        dtLedgerType.Rows.InsertAt(dr, 0)
        '    End If

        '    ddlLedgerType.SelectedIndex = 0
    End Sub


    Private Sub GetPKOProductionTodayValues()



        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        Dim ds As New DataSet
        Dim dsToday As New DataSet
        objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value

        'ds = PKOProductionLogBOL.GetPKOProductionlogPKOMonthYearValue(objPKOProductionLogPPT)
        dsToday = PKOProductionLogBOL.GetPKOProductionlogPKOTodayValue(objPKOProductionLogPPT)



        If dsToday.Tables(0).Rows.Count <> 0 And dsToday IsNot Nothing Then
            If Not dsToday.Tables(0).Rows(0).Item("QtyToday") Is DBNull.Value Then
                txtPKOProductionToday.Text = dsToday.Tables(0).Rows(0).Item("QtyToday").ToString
            End If
        Else
            txtPKOProductionToday.Text = "0"
        End If
        'If ds.Tables(0).Rows.Count <> 0 And ds IsNot Nothing Then
        '    If Not ds.Tables(0).Rows(0).Item("MonthValuesQtyToday") Is DBNull.Value Then
        '        txtPKOProductionMonthTodate.Text = ds.Tables(0).Rows(0).Item("MonthValuesQtyToday").ToString
        '    End If

        'Else
        '    txtPKOProductionMonthTodate.Text = "0"
        'End If
        'If ds.Tables(1).Rows.Count <> 0 And ds IsNot Nothing Then
        '    If Not ds.Tables(1).Rows(0).Item("QtyYearToDate") Is DBNull.Value Then
        '        txtPKOProductionYear.Text = ds.Tables(1).Rows(0).Item("QtyYearToDate").ToString
        '    End If

        'Else
        '    txtPKOProductionYear.Text = "0"
        'End If


    End Sub

    Private Sub TPH()
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            txtTotalHoursPress.Text = ""
            For Each objDataGridViewRow In dgPressInfo.Rows
                If objDataGridViewRow.Cells("dgMestage").Value.ToString = "Stage 1" And objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString <> "" Then
                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString()
                    lTotalOPHoursStage1 = lTotalOPHoursStage1
                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = lTotalOPHoursStage1
                    strArr = Str.Split(":")
                    Str1 = lCominValue
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"

                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lTotalOPHoursStage1 = Strhrs + ":" + StrMin
                ElseIf objDataGridViewRow.Cells("dgMestage").Value.ToString = "Stage 2" And objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString <> "" Then

                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("dgMeOPHrs").Value.ToString()
                    lTotalOPHoursStage2 = lTotalOPHoursStage2
                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str1 = lTotalOPHoursStage2
                    strArr = Str1.Split(":")
                    Str = lCominValue
                    strArr1 = Str.Split(":")

                    Dim Lhrs, lmin As Integer

                    Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                    lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"


                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lTotalOPHoursStage2 = Strhrs + ":" + StrMin
                End If
            Next
            If lTotalOPHoursStage1 <> "00:00" Or lTotalOPHoursStage2 <> "00:00" Then

                Dim strArr(), strArr1() As String
                Dim Str, Str1 As String
                Str1 = lTotalOPHoursStage2
                strArr = Str1.Split(":")
                Str = lTotalOPHoursStage1
                strArr1 = Str.Split(":")

                Dim Lhrs, lmin As Integer

                Lhrs = Convert.ToInt16(strArr(0)) + Convert.ToInt16(strArr1(0))

                lmin = Convert.ToInt16(strArr1(1)) + Convert.ToInt16(strArr(1))

                If lmin >= 60 Then
                    lmin = lmin - 60
                    Lhrs = Lhrs + 1
                End If
                Dim Strhrs As String = "00"
                Dim StrMin As String = "00"



                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If
                txtTotalHoursPress.Text = Convert.ToString(Strhrs) + ":" + Convert.ToString(StrMin)
            End If
            lTotalOPHoursStage1 = "00:00"
            lTotalOPHoursStage2 = "00:00"

        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try

    End Sub

    Private Sub txtTotalHoursPress_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalHoursPress.TextChanged
        Dim lTotalOPHrs As Decimal
        If txtTotalHoursPress.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTotalHoursPress.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)
            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)
            lTotalOPHrs = Hrs + lmin
        End If

        If txtKerneltoday.Text <> String.Empty And lTotalOPHrs > 0 Then
            txtAvgPressThroughput.Text = Math.Round(Val(txtKerneltoday.Text) / lTotalOPHrs, 2)
        Else
            txtAvgPressThroughput.Text = ""
        End If

        If txtKerneltoday.Text <> String.Empty Then
            txtCakeProcess.Text = Val(txtKerneltoday.Text) - Val(txtPKOProductionToday.Text)
        Else
            txtCakeProcess.Text = ""
        End If

        If Convert.ToString(lTotalOPHoursStage1) <> "" And lTotalOPHoursStage1 <> "00:00" Then
            txtTPHTodaystage1.Text = Convert.ToString(lTotalOPHoursStage1)
        Else
            txtTPHTodaystage1.Text = ""
        End If

        If Convert.ToString(lTotalOPHoursStage2) <> "" And lTotalOPHoursStage2 <> "00:00" Then
            txtStage2TodayTPH.Text = Convert.ToString(lTotalOPHoursStage2)
        Else
            txtStage2TodayTPH.Text = ""
        End If

    End Sub

    Private Sub txtTPHMonthTodateStage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTPHMonthTodateStage1.Leave
        If txtTPHMonthTodateStage1.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtTPHMonthTodateStage1.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Hrs cant be greater than  24")
            '    txtTPHMonthTodateStage1.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtTPHMonthTodateStage1.Text = Hrs + ":" + Min
        End If
        summCalcMonthStage1()
        If txtTPHMonthTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "00:00" And txtTPHTodaystage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg5")
                ''MessageBox.Show("Press Info stage 1 Month To Date Hrs cant be lesser than Press Info stage 1 Total Hrs")
                ' txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
        If txtTPHYearTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtTPHMonthTodateStage1.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg6")
                ''MessageBox.Show("Press Info stage 1 Year To Date Hrs cant be lesser than Press Info stage 1 Month To Date Hrs")
                '  txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtTotalPressHoursMonthTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHMonthTodateStage1.TextChanged
        If txtTPHMonthTodateStage1.Text <> "" And txtTPHMonthTodateStage1.Enabled = True Then
            Dim Value As String = txtTPHMonthTodateStage1.Text
            Dim strlen As Integer
            strlen = Len(txtTPHMonthTodateStage1.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtTPHMonthTodateStage1.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please enter only numeric  values")
                    txtTPHMonthTodateStage1.Focus()
                    Exit Sub
                End If
            Next
            If Val(txtTPHMonthTodateStage1.Text) >= 744 Then
                DisplayInfoMessage("Msg120")
                '  MsgBox("Month To date Hrs cant be greater than 744 hrs")
                txtTPHMonthTodateStage1.Focus()
            End If

        End If
        If txtTPHMonthTodateStage1.Text = "" Then
            txtAPHstage1monthtodate.Text = ""
            txtutilstage1monthtodate.Text = ""
        End If

        If MonthCount >= 1 Then
            If txtTPHMonthTodateStage1.Enabled = False Then
                summCalcMonthStage1()
            End If
        End If

        If txtTPHMonthTodateStage1.Text = "00:00" Then
            txtTPHMonthTodateStage1.Text = ""
        End If

        If MonthCount <= 1 And txtTPHMonthTodateStage1.Text = "00:00" Then
            txtTPHMonthTodateStage1.Text = ""
        End If

    End Sub
    Private Sub summCalcMonthStage1()
        Dim lTPHMonthTodateStage1, lMonthTodateHrs As Decimal
        If txtTPHMonthTodateStage1.Text <> "00:00" And txtTPHMonthTodateStage1.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHMonthTodateStage1 = Hrs + lmin

        End If
        If txtEffectiveProcessingHoursMonth.Text <> "00:00" And txtEffectiveProcessingHoursMonth.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEffectiveProcessingHoursMonth.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lMonthTodateHrs = Hrs + lmin

        End If
        If Val(txtKernelMonth.Text) <> 0 And lTPHMonthTodateStage1 > 0 Then
            txtAPHstage1monthtodate.Text = Math.Round(Val(txtKernelMonth.Text) * 1000 / lTPHMonthTodateStage1, 2)
        Else
            txtAPHstage1monthtodate.Text = ""
        End If
        If lMonthTodateHrs > 0 And lTPHMonthTodateStage1 > 0 Then
            If ToCaculateTotalPress("Stage 1") <> 0 Then
                txtutilstage1monthtodate.Text = Math.Round(lTPHMonthTodateStage1 * 100 / (lMonthTodateHrs * (ToCaculateTotalPress("Stage 1") + lstageCountMonth)), 2)
            ElseIf lstageCountMonth <> 0 Then
                txtutilstage1monthtodate.Text = Math.Round(lTPHMonthTodateStage1 * 100 / (lMonthTodateHrs * lstageCountMonth), 2)
            End If
        Else
            txtutilstage1monthtodate.Text = ""
        End If
    End Sub
    Private Sub GetPKOProductionLogPressOPHrsValue()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL
        Dim ds As New DataSet
        objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value

        ds = PKOProductionLogBOL.GetPKOProductionLogPressOPHrsValue(objPKOProductionLogPPT)

        lTotalOPHoursMonth = ds.Tables(2).Rows(0).Item("MonthValuesOPPressHrs")

        lTotalOPHoursYear = ds.Tables(5).Rows(0).Item("YearValuesOPPressHrs")


    End Sub

    Private Sub txtStage2monthTodate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStage2monthTodate.Leave
        If txtStage2monthTodate.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtStage2monthTodate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtStage2monthTodate.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStage2monthTodate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtStage2monthTodate.Text = Hrs + ":" + Min

        End If
        summCalcMonthStage2()
        If txtStage2monthTodate.Text <> "" And txtStage2monthTodate.Text <> "00:00" And txtStage2TodayTPH.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg8")
                ''MessageBox.Show("Press Info stage 2 Month To Date Hrs cant be lesser than Press Info stage 2 Total Hrs")
                ' txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
        If txtStage2yearTodate.Text <> "" And txtStage2monthTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtStage2monthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg9")
                ''MessageBox.Show("Press Info stage 2 Year To Date Hrs cant be lesser than Press Info stage 2 Month To Date Hrs")
                '  txtMonthTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtStage2monthTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2monthTodate.TextChanged
        If txtStage2monthTodate.Text <> "" And txtStage2monthTodate.Enabled = True Then
            Dim Value As String = txtStage2monthTodate.Text
            Dim strlen As Integer
            strlen = Len(txtStage2monthTodate.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStage2monthTodate.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please enter only numeric  values")
                    txtStage2monthTodate.Focus()
                End If
            Next
            If Val(txtStage2monthTodate.Text) >= 744 Then
                DisplayInfoMessage("Msg120")
                '  MsgBox("Month To date Hrs cant be greater than 744 hrs")
                txtStage2monthTodate.Focus()
            End If

        End If
        If txtStage2monthTodate.Text = "" Then
            txtAPTstage2monthtodae.Text = ""
            txtutilstage2monthtodate.Text = ""
        End If
        If MonthCount >= 1 Then
            If txtStage2monthTodate.Enabled = False Then
                summCalcMonthStage2()
            End If
        End If

        If MonthCount <= 1 And txtStage2monthTodate.Text = "00:00" Then
            txtStage2monthTodate.Text = ""
        End If

    End Sub
    Private Sub summCalcMonthStage2()
        Dim lTPHMonthTodatestage2, lMonthTodateHrs As Decimal
        If txtStage2monthTodate.Text <> "00:00" And txtStage2monthTodate.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHMonthTodatestage2 = Hrs + lmin

        End If
        If txtEffectiveProcessingHoursMonth.Text <> "00:00" And txtEffectiveProcessingHoursMonth.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEffectiveProcessingHoursMonth.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lMonthTodateHrs = Hrs + lmin

        End If

        'If lTotalOPHoursMonth = "00:00" Then
        '    lTotalOPHoursMonth = txtTotalHoursPress.Text
        'End If

        'If lTotalOPHoursMonth <> "00:00" And lTotalOPHoursMonth <> "" Then
        '    Dim Hrs As Integer
        '    Dim Min As Integer
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = lTotalOPHoursMonth
        '    strArr = str.Split(":")
        '    Hrs = strArr(0)
        '    Min = strArr(1)

        '    Min = (Min / 60) *100
        '    Dim lmin As String
        '    lmin = "." + Convert.ToString(Min)

        '    llTotalOPHoursMonth = Hrs + lmin

        'End If
        If Val(txtKernelMonth.Text) <> 0 And lTPHMonthTodatestage2 > 0 Then
            'txtAPTstage2monthtodae.Text = Math.Round(Val(txtKernelMonth.Text) * 1000 / lTPHMonthTodatestage2, 2)

            txtAPTstage2monthtodae.Text = ((ConvertToDouble(txtKernelMonth.Text) - ConvertToDouble(txtPKOProductionMonthTodate.Text)) * 1000 / ConvertToDouble(txtStage2monthTodate.Text.Replace(":", ".")))
        Else
            txtAPTstage2monthtodae.Text = ""
        End If
        If lMonthTodateHrs > 0 And lTPHMonthTodatestage2 > 0 Then
            If ToCaculateTotalPress("Stage 2") <> 0 Then
                txtutilstage2monthtodate.Text = Math.Round(lTPHMonthTodatestage2 * 100 / (lMonthTodateHrs * (ToCaculateTotalPress("Stage 2") + lstageCountMonth)), 2)
            ElseIf lstageCountMonth <> 0 Then
                txtutilstage2monthtodate.Text = Math.Round(lTPHMonthTodatestage2 * 100 / (lMonthTodateHrs * lstageCountMonth), 2)
            End If
        Else
            txtutilstage2monthtodate.Text = ""
        End If
    End Sub

    Private Sub txtTPHYearTodateStage1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTPHYearTodateStage1.Leave
        If txtTPHYearTodateStage1.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtTPHYearTodateStage1.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtTPHYearTodateStage1.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then


                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtTPHYearTodateStage1.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtTPHYearTodateStage1.Text = Hrs + ":" + Min
        End If
        SummCalcstage1Year()
        If txtTPHYearTodateStage1.Text <> "" And txtTPHYearTodateStage1.Text <> "00:00" And txtTPHTodaystage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg10")
                ''MessageBox.Show("Press Info stage 1 Year To Date Hrs cant be lesser than Press Info stage 1 Total Hrs")
                'txtYearTodate.Focus()
                Exit Sub
            End If
        End If
        If txtTPHMonthTodateStage1.Text <> "" And txtTPHYearTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtTPHMonthTodateStage1.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg11")
                ''MessageBox.Show("Press Info stage 1 Year To Date Hrs cant be lesser than Press Info stage 1 Month To Date Hrs")
                ' txtYearTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub txtTotalPressHoursYearTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHYearTodateStage1.TextChanged
        If txtTPHYearTodateStage1.Text <> "" And txtTPHYearTodateStage1.Enabled = True Then
            Dim Value As String = txtTPHYearTodateStage1.Text
            Dim strlen As Integer
            strlen = Len(txtTPHYearTodateStage1.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtTPHYearTodateStage1.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please enter only numeric  values")
                    txtTPHYearTodateStage1.Focus()
                End If
            Next
            If Val(txtTPHYearTodateStage1.Text) >= 8760 Then
                DisplayInfoMessage("Msg121")
                txtTPHYearTodateStage1.Focus()
            End If

        End If
        If txtTPHYearTodateStage1.Text = "" Then
            txtAPTstage1yeartodate.Text = ""
            txtutilstage1yeartodate.Text = ""
        End If
        If YearCount >= 1 Then
            If txtTPHYearTodateStage1.Enabled = False Then
                SummCalcstage1Year()
            End If
        End If

        If txtTPHYearTodateStage1.Text = "00:00" Then
            txtTPHYearTodateStage1.Text = ""
        End If
        If MonthCount <= 1 And txtTPHYearTodateStage1.Text = "00:00" Then
            txtTPHYearTodateStage1.Text = ""
        End If

    End Sub
    Private Sub SummCalcstage1Year()
        Dim lTPHYearTodateStage1, lYearTodateHrs As Decimal
        If txtTPHYearTodateStage1.Text <> "00:00" And txtTPHYearTodateStage1.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHYearTodateStage1 = Hrs + lmin

        End If
        If txtEffectiveProcessingHoursYear.Text <> "00:00" And txtEffectiveProcessingHoursYear.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEffectiveProcessingHoursYear.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lYearTodateHrs = Hrs + lmin

        End If
        'If lTotalOPHoursYear = "00:00" Then
        '    lTotalOPHoursYear = txtTotalHoursPress.Text
        'End If

        'If lTotalOPHoursYear <> "00:00" And lTotalOPHoursYear <> "" Then
        '    Dim Hrs As Integer
        '    Dim Min As Integer
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = lTotalOPHoursYear
        '    strArr = str.Split(":")
        '    Hrs = strArr(0)
        '    Min = strArr(1)

        '    Min = (Min / 60) *100
        '    Dim lmin As String
        '    lmin = "." + Convert.ToString(Min)

        '    llTotalOPHoursYear = Hrs + lmin

        'End If
        If Val(txtKernelYear.Text) <> 0 And lTPHYearTodateStage1 > 0 Then
            txtAPTstage1yeartodate.Text = Math.Round(Val(txtKernelYear.Text) * 1000 / lTPHYearTodateStage1, 2)
        Else
            txtAPTstage1yeartodate.Text = ""
        End If
        If lYearTodateHrs > 0 And lTPHYearTodateStage1 > 0 Then
            If ToCaculateTotalPress("Stage 1") <> 0 Then
                txtutilstage1yeartodate.Text = Math.Round(lTPHYearTodateStage1 * 100 / (lYearTodateHrs * (ToCaculateTotalPress("Stage 1") + lstageCountYear)), 2)
            ElseIf lstageCountYear <> 0 Then
                txtutilstage1yeartodate.Text = Math.Round(lTPHYearTodateStage1 * 100 / (lYearTodateHrs * lstageCountYear), 2)
            End If
        Else
            txtutilstage1yeartodate.Text = ""
        End If
    End Sub
    Private Sub SummCalcstage2Year()
        Dim lTPHYearTodatestage2, lYearTodateHrs As Decimal
        If txtStage2yearTodate.Text <> "00:00" And txtStage2yearTodate.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lTPHYearTodatestage2 = Hrs + lmin

        End If
        If txtEffectiveProcessingHoursYear.Text <> "00:00" And txtEffectiveProcessingHoursYear.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEffectiveProcessingHoursYear.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            Min = strArr(1)

            Min = (Min / 60) * 100
            Dim lmin As String
            lmin = "." + Convert.ToString(Min)

            lYearTodateHrs = Hrs + lmin

        End If
        'If lTotalOPHoursYear <> "00:00" And lTotalOPHoursYear <> "" Then
        '    Dim Hrs As Integer
        '    Dim Min As Integer
        '    Dim str As String
        '    Dim strArr() As String
        '    'Dim count As Integer
        '    str = lTotalOPHoursYear
        '    strArr = str.Split(":")
        '    Hrs = strArr(0)
        '    Min = strArr(1)

        '    Min = (Min / 60) *100
        '    Dim lmin As String
        '    lmin = "." + Convert.ToString(Min)

        '    llTotalOPHoursYear = Hrs + lmin

        'End If
        If Val(txtKernelYear.Text) <> 0 And lTPHYearTodatestage2 > 0 Then
            'txtAPTStage2yeartodate.Text = Math.Round(Val(txtKernelYear.Text) * 1000 / lTPHYearTodatestage2, 2)

            txtAPTStage2yeartodate.Text = ((ConvertToDouble(txtKernelYear.Text) - ConvertToDouble(txtPKOProductionYear.Text)) * 1000 / ConvertToDouble(txtStage2yearTodate.Text.Replace(":", ".")))
        Else
            txtAPTStage2yeartodate.Text = ""
        End If
        If lYearTodateHrs > 0 And lTPHYearTodatestage2 > 0 Then
            If ToCaculateTotalPress("Stage 2") <> 0 Then
                txtutilstage2yeartodate.Text = Math.Round(lTPHYearTodatestage2 * 100 / (lYearTodateHrs * (ToCaculateTotalPress("Stage 2") + lstageCountYear)), 2)
            ElseIf lstageCountYear <> 0 Then
                txtutilstage2yeartodate.Text = Math.Round(lTPHYearTodatestage2 * 100 / (lYearTodateHrs * lstageCountYear), 2)
            End If
        Else
            txtutilstage2yeartodate.Text = ""
        End If
    End Sub

    Private Sub txtStage2yearTodate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStage2yearTodate.Leave
        If txtStage2yearTodate.Text <> "" And txtStage2yearTodate.Text <> "00:00" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtStage2yearTodate.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            'If Hrs > 24 Then
            '    MessageBox.Show("Breakdown Hrs cant be greater than  24")
            '    txtStage2yearTodate.Focus()
            '    Exit Sub
            'End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStage2yearTodate.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtStage2yearTodate.Text = Hrs + ":" + Min
        End If
        SummCalcstage2Year()
        If txtStage2yearTodate.Text <> "" And txtStage2yearTodate.Text <> "00:00" And txtStage2TodayTPH.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg12")
                ''MessageBox.Show("Press Info stage 2 Year To Date Hrs cant be lesser than Press Info stage 2 Total Hrs")
                'txtYearTodate.Focus()
                Exit Sub
            End If
        End If
        If txtStage2monthTodate.Text <> "" And txtStage2yearTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtStage2monthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg13")
                ''MessageBox.Show("Press Info stage 2 Year To Date Hrs cant be lesser than Press Info stage 2 Month To Date Hrs")
                ' txtYearTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub
    Private Sub txtStage2yearTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2yearTodate.TextChanged
        If txtStage2yearTodate.Text <> "" And txtStage2yearTodate.Enabled = True Then
            Dim Value As String = txtStage2yearTodate.Text
            Dim strlen As Integer
            strlen = Len(txtStage2yearTodate.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStage2yearTodate.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please enter only numeric  values")
                    txtStage2yearTodate.Focus()
                End If
            Next
            If Val(txtStage2yearTodate.Text) >= 8760 Then
                DisplayInfoMessage("Msg121")
                txtStage2yearTodate.Focus()
            End If


        End If
        If txtStage2yearTodate.Text = "" Then
            txtAPTStage2yeartodate.Text = ""
            txtutilstage2yeartodate.Text = ""
        End If
        If YearCount >= 1 Then
            If txtStage2yearTodate.Enabled = False Then
                SummCalcstage2Year()
            End If
        End If
        If MonthCount <= 1 And txtStage2yearTodate.Text = "00:00" Then
            txtStage2yearTodate.Text = ""
        End If
    End Sub

    Private Sub btnResetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetAll.Click
        clear()
        ClearReceivedKernelGB()
        ClearLogExpress()
        ClearGridView(dgvReceivedKernel)
        ClearGridView(dgPressInfo)
        ClearShift()
        ClearGridView(dgvPKOLogShiftDetails)
        GlobalPPT.IsRetainFocus = False
    End Sub

    Private Sub PKOProductionLogFrm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (dgvPKOLogShiftDetails.RowCount > 0 Or dgPressInfo.RowCount > 0 Or dgvReceivedKernel.RowCount > 0) And btnSaveAll.Enabled = True And GlobalPPT.IsButtonClose = False Then
            If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = False
            Else

                e.Cancel = True
                Me.Activate()
                GlobalPPT.IsRetainFocus = True
                mdiparent.strMenuID = "M91"

            End If
        End If
    End Sub


    Private Sub PKOProductionLogFrm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GlobalPPT.IsRetainFocus = False
        GlobalPPT.IsButtonClose = False
        'txtqtyMtKerRecd.ReadOnly = True 'Commented because they need to be able to edit the QTY.
        SetUICulture(GlobalPPT.strLang)
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
        GetCropYieldID()
        GetKernelReceivedLocation()
        ClearGridView(dgvReceivedKernel)
        ClearGridView(dgPressInfo)
        ClearGridView(dgvPKOLogShiftDetails)
        ClearShift()
        clear()

        '********** added on 25 march 2013
        GlobalBOL.SetDateTimePicker(Me.dtPKOProductionDate)
        GlobalBOL.SetDateTimePicker(Me.dtpPKOProdLogDateSearch)
        dtPKOProductionDate.Format = DateTimePickerFormat.Custom 'edit
        dtPKOProductionDate.CustomFormat = "dd/MM/yyyy"
        dtpPKOProdLogDateSearch.Format = DateTimePickerFormat.Custom
        dtpPKOProdLogDateSearch.CustomFormat = "dd/MM/yyyy"

        tcPKOroductionLog.SelectedIndex = 1
        If ddlLoadingLocationKerRecd.Items.Count = 0 Then
            DisplayInfoMessage("Msg14")
            ''MsgBox("No Records Available for Loading Location ,Please insert the Record in Production Loading Location")
        End If

        BindDataGrid()

    End Sub
    Private Sub SetUICulture(ByVal culture As String)
        ' get a reference to the ResourceManager for this form

        Try
            'set the culture as per the selection and 
            'load the appropriate strings for button, label, etc.
            System.Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(culture)

            ''lblDate.Text = rm.GetString("Date")
            ''lblSearchby.Text = rm.GetString("SearchBy")
            ''lblShift.Text = rm.GetString("Shift")
            ''lblAssistant.Text = rm.GetString("Assistant")
            ''lblMandore.Text = rm.GetString("Mandore")
            ''lblStartTime.Text = rm.GetString("StartTime")
            ''lblStopTime.Text = rm.GetString("StopTime")
            ''lblKernelProcessed.Text = rm.GetString("KernelProcessed")
            ''Label15.Text = rm.GetString("ShiftHrs")
            'dgvPKOLogShiftDetails.Columns("dgShift").HeaderText = rm.GetString("Shift")
            'dgvPKOLogShiftDetails.Columns("dgShiftAssistant").HeaderText = rm.GetString("Assistant")
            'dgvPKOLogShiftDetails.Columns("dgShiftMandore").HeaderText = rm.GetString("Mandore")
            'dgvPKOLogShiftDetails.Columns("dgShiftStartTime").HeaderText = rm.GetString("StartTime")
            'dgvPKOLogShiftDetails.Columns("dgShiftStopTime").HeaderText = rm.GetString("StopTime")
            'dgvPKOLogShiftDetails.Columns("dgShiftHours").HeaderText = rm.GetString("ShiftHrs")
            'dgvPKOLogShiftDetails.Columns("dgShiftKernelProcessed").HeaderText = rm.GetString("KernelProcessed")
            ''lblTotalHours.Text = rm.GetString("TotalShiftHours")
            ''lblMonthTodate.Text = rm.GetString("MonthtoDate")
            ''lblYearTodate.Text = rm.GetString("YearTodate")
            btnAddShift.Text = rm.GetString("Add")
            btnResetShift.Text = rm.GetString("Reset")


            ''lblBFQty.Text = rm.GetString("B/fQty")
            ''lblBudget.Text = rm.GetString("Budget")
            ''lblMonthToDate.Text = rm.GetString("MonthtoDate")
            ''lblVariance.Text = rm.GetString("Variance")
            ''lbllocation.Text = rm.GetString("Locationreceived")
            ''lblQtyMt.Text = rm.GetString("Quantity")
            ''lblTodate.Text = rm.GetString("Todate")
            ''lblYearTodateMt.Text = rm.GetString("Yeartodate1")
            ''lblTotalReceivedQty.Text = rm.GetString("TotalReceivedQty")
            btnAdd.Text = rm.GetString("Add")
            btnReset.Text = rm.GetString("Reset")

            'dgvReceivedKernel.Columns("dgMeLoadingLocation").HeaderText = rm.GetString("Locationreceived")
            'dgvReceivedKernel.Columns("dgMeQtyKerRecd").HeaderText = rm.GetString("Quantity")
            ''dgvReceivedKernel.Columns("dgMeqtyMntKerRecd").HeaderText = rm.GetString("Todate")
            ''dgvReceivedKernel.Columns("dgMeqtyYrKerRecd").HeaderText = rm.GetString("Yeartodate1")
            ''lblKernelReceived.Text = rm.GetString("Kernel")
            ''lblKernelToday.Text = rm.GetString("Today")
            ''lblKernelMonthToDate.Text = rm.GetString("MonthtoDate")
            ''lblKernelYearToDate.Text = rm.GetString("YearTodate")
            ''lblProcessingToday.Text = rm.GetString("Today")
            ''lblProcessingMonthToDate.Text = rm.GetString("MonthtoDate")
            ''lblProcessingYearToDate.Text = rm.GetString("YearTodate")
            ''lblKernelProcess.Text = rm.GetString("KernelProcessed")
            ''lblLossOnKernel.Text = rm.GetString("LossOnkernel")
            ''lblMechanicalBreakDown.Text = rm.GetString("MechanicalBreakDown")
            ''lblElectricalBreakDown.Text = rm.GetString("ElectricalBreakDown")
            ''lblProcessingBreakDown.Text = rm.GetString("ProcessingBreakDown")
            ''lblTotalBreakDown.Text = rm.GetString("TotalBreakDown")
            ''lblEffectiveProcessing.Text = rm.GetString("EffectiveProcessingHours")
            ''lblThroughput.Text = rm.GetString("Throughput")
            ''lblPKOProduction.Text = rm.GetString("PKOProduction")
            ''lblKER.Text = rm.GetString("OER")
            ''lblRemarks.Text = rm.GetString("Remarks")


            ''lblStage.Text = rm.GetString("Stage")
            ''lblOPHrs.Text = rm.GetString("OP.Hrs")
            ''lblMeterTo.Text = rm.GetString("MeterTo")
            ''lblAgeOfscrew.Text = rm.GetString("AgeOfscrew")
            ''lblMeterFrom.Text = rm.GetString("MeterForm")
            ''lblScrewStatus.Text = rm.GetString("ScrewDetails")
            ''lblPressNo.Text = rm.GetString("PressNo")
            ''lblCapacity.Text = rm.GetString("Capacity")

            btnAddPressInfo.Text = rm.GetString("Add")
            btnResetPressinfo.Text = rm.GetString("Reset")


            'dgPressInfo.Columns("dgMeStage").HeaderText = rm.GetString("Stage")
            'dgPressInfo.Columns("dgMeScrewAge").HeaderText = rm.GetString("AgeOfscrew")
            'dgPressInfo.Columns("dgMePressNo").HeaderText = rm.GetString("PressNo")
            'dgPressInfo.Columns("dgMeCapacity").HeaderText = rm.GetString("Capacity")
            'dgPressInfo.Columns("dgMeOPHrs").HeaderText = rm.GetString("OP.Hrs")
            'dgPressInfo.Columns("dgMeMeterFrom").HeaderText = rm.GetString("MeterForm")
            'dgPressInfo.Columns("dgMeMeterTo").HeaderText = rm.GetString("MeterTo")
            ''dgPressInfo.Columns("dgMeScrewStatus").HeaderText = rm.GetString("ScrewsStatus")


            ''lblTotalHoursPress.Text = rm.GetString("TotalHoursPress")
            ''lvlAvgpresstp.Text = rm.GetString("AveragePressthroughput")
            ''lblCakeProcess.Text = rm.GetString("Cakeprocess")
            ''lblPressToday.Text = rm.GetString("Today")
            ''lblPressMonth.Text = rm.GetString("MonthtoDate")
            ''lblPressYear.Text = rm.GetString("YearTodate")
            ''lblTotalPressHours.Text = rm.GetString("TotalPressHours")
            ''lblAveragePressThroughput.Text = rm.GetString("AveragePressthroughput")
            ''lblUtilisation.Text = rm.GetString("Utilization")

            ''lblTotalPHStage1.Text = rm.GetString("Stage1")
            ''lblTotalPHStage2.Text = rm.GetString("Stage2")
            ''lblAvgPressStage1.Text = rm.GetString("Stage1")
            ''lblAvgPressStage2.Text = rm.GetString("Stage2")
            ''lblUtilisationStage1.Text = rm.GetString("Stage1")
            ''lblUtilisationStage2.Text = rm.GetString("Stage2")



            btnSaveAll.Text = rm.GetString("SaveAll")
            btnResetAll.Text = rm.GetString("ResetAll")
            btnClose.Text = rm.GetString("Close")

            'chkPKOLogDate.Text = rm.GetString("Date")
            'dgvPKOProductionLogView.Columns("dgclProductionlogDate").HeaderText = rm.GetString("Date")
            btnSearch.Text = rm.GetString("Search")


        Catch
            'display a message if the culture is not supported
            MessageBox.Show("Locale '" & culture & "' isn't supported", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DisplayInfoMessage(ByVal lsResourceKey As String)
        '   Dim rm As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PKOProductionLogFrm))
        MsgBox(rm.GetString(lsResourceKey), Microsoft.VisualBasic.MsgBoxStyle.Information + Microsoft.VisualBasic.MsgBoxStyle.OkOnly, "BSP")
    End Sub

    Private Sub AddMultipleEntryDataReceivedKernel()

        Dim intRowcount As Integer = dtKerRecd.Rows.Count
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL

        Try

            If Me.ddlLoadingLocationKerRecd.Text = "--Select--" Then
                DisplayInfoMessage("Msg15")
                ''MessageBox.Show("This Field Required", "Loading Location")
                ddlLoadingLocationKerRecd.Focus()
                Exit Sub
            End If
            If Me.txtqtyMtKerRecd.Text = "" Then
                DisplayInfoMessage("Msg16")
                ''MessageBox.Show("This Field Required", "Qty")
                txtqtyMtKerRecd.Focus()
                Exit Sub
            End If
            If Val(txtqtyMtKerRecd.Text) > Val(txtTodateMtRecKer.Text) Then
                DisplayInfoMessage("Msg17")
                ''MessageBox.Show("Today Received Kernel should be lesser than Month Received Kernel", "BSP")
                txtTodateMtRecKer.Focus()
                Exit Sub
            End If
            If Val(txtqtyMtKerRecd.Text) > Val(txtYearTodateRecKer.Text) Then
                DisplayInfoMessage("Msg18")
                ''MessageBox.Show("Today Received Kernel should be lesser than Year Received Kernel", "BSP")
                txtYearTodateRecKer.Focus()
                Exit Sub
            End If
            If Val(txtTodateMtRecKer.Text) > Val(txtYearTodateRecKer.Text) Then
                DisplayInfoMessage("Msg19")
                ''MessageBox.Show("Month Received Kernel should be lesser than Year Received Kernel", "BSP")
                txtTodateMtRecKer.Focus()
                Exit Sub
            End If


            If Not LoadingLocationExist(ddlLoadingLocationKerRecd.Text) Then

                rowMultipleEntryAddKerRecd = dtKerRecd.NewRow()
                If intRowcount = 0 And lbtnAddKerRecd = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        ColumnKerRecdAdd = New DataColumn("PKOKERReceivedID", System.Type.[GetType]("System.String"))
                        dtKerRecd.Columns.Add(ColumnKerRecdAdd)
                        ColumnKerRecdAdd = New DataColumn("LoadingLocation", System.Type.[GetType]("System.String"))
                        dtKerRecd.Columns.Add(ColumnKerRecdAdd)
                        ColumnKerRecdAdd = New DataColumn("LoadingLocationID", System.Type.[GetType]("System.String"))
                        dtKerRecd.Columns.Add(ColumnKerRecdAdd)
                        ColumnKerRecdAdd = New DataColumn("QtyKerRecd", System.Type.[GetType]("System.String"))
                        dtKerRecd.Columns.Add(ColumnKerRecdAdd)
                        ColumnKerRecdAdd = New DataColumn("KerRecdMonthTodate", System.Type.[GetType]("System.String"))
                        dtKerRecd.Columns.Add(ColumnKerRecdAdd)
                        ColumnKerRecdAdd = New DataColumn("KerRecdYearTodate", System.Type.[GetType]("System.String"))
                        dtKerRecd.Columns.Add(ColumnKerRecdAdd)

                        rowMultipleEntryAddKerRecd("PKOKERReceivedID") = lPKOKERReceivedID
                        rowMultipleEntryAddKerRecd("LoadingLocation") = ddlLoadingLocationKerRecd.Text
                        rowMultipleEntryAddKerRecd("LoadingLocationID") = ddlLoadingLocationKerRecd.SelectedValue.ToString

                        rowMultipleEntryAddKerRecd("QtyKerRecd") = txtqtyMtKerRecd.Text
                        rowMultipleEntryAddKerRecd("KerRecdMonthTodate") = txtTodateMtRecKer.Text
                        rowMultipleEntryAddKerRecd("KerRecdYearTodate") = txtYearTodateRecKer.Text

                        dtKerRecd.Rows.InsertAt(rowMultipleEntryAddKerRecd, intRowcount)
                        dgvReceivedKernel.AutoGenerateColumns = False

                    Catch ex As Exception

                        'If lPKOKERReceivedID <> String.Empty Then
                        '    rowMultipleEntryAddKerRecd("PKOKERReceivedID") = lPKOKERReceivedID
                        'End If

                        rowMultipleEntryAddKerRecd("LoadingLocation") = ddlLoadingLocationKerRecd.Text
                        rowMultipleEntryAddKerRecd("LoadingLocationID") = ddlLoadingLocationKerRecd.SelectedValue.ToString

                        rowMultipleEntryAddKerRecd("QtyKerRecd") = txtqtyMtKerRecd.Text
                        rowMultipleEntryAddKerRecd("KerRecdMonthTodate") = txtTodateMtRecKer.Text
                        rowMultipleEntryAddKerRecd("KerRecdYearTodate") = txtYearTodateRecKer.Text


                        dtKerRecd.Rows.InsertAt(rowMultipleEntryAddKerRecd, intRowcount)
                        dgvReceivedKernel.AutoGenerateColumns = False
                    End Try

                Else


                    rowMultipleEntryAddKerRecd("LoadingLocation") = ddlLoadingLocationKerRecd.Text
                    rowMultipleEntryAddKerRecd("LoadingLocationID") = ddlLoadingLocationKerRecd.SelectedValue.ToString

                    rowMultipleEntryAddKerRecd("QtyKerRecd") = txtqtyMtKerRecd.Text
                    rowMultipleEntryAddKerRecd("KerRecdMonthTodate") = txtTodateMtRecKer.Text
                    rowMultipleEntryAddKerRecd("KerRecdYearTodate") = txtYearTodateRecKer.Text

                    dtKerRecd.Rows.InsertAt(rowMultipleEntryAddKerRecd, intRowcount)
                    dgvReceivedKernel.AutoGenerateColumns = False
                End If

                dgvReceivedKernel.DataSource = dtKerRecd
                dgvReceivedKernel.AutoGenerateColumns = False
                ClearReceivedKernelGB()
                ddlLoadingLocationKerRecd.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg20")
                ''MsgBox("Loading Location already Exixts")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub UpDateMultipleEntryDataReceivedKernel()

        'Dim intRowcount As Integer = dgvReceivedKernel.Rows.Count
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL

        Try

            If Me.ddlLoadingLocationKerRecd.Text = "--Select--" Then
                DisplayInfoMessage("Msg15")
                ''MessageBox.Show("This Field Required", "Loading Location")
                ddlLoadingLocationKerRecd.Focus()
                Exit Sub
            End If
            If Me.txtqtyMtKerRecd.Text = "" Then
                DisplayInfoMessage("Msg16")
                ''MessageBox.Show("This Field Required", "Qty")
                txtqtyMtKerRecd.Focus()
                Exit Sub
            End If
            If Val(txtqtyMtKerRecd.Text) > Val(txtTodateMtRecKer.Text) Then
                DisplayInfoMessage("Msg17")
                ''MessageBox.Show("Today Received Kernel should be lesser than Month Received Kernel", "BSP")
                txtTodateMtRecKer.Focus()
                Exit Sub
            End If
            If Val(txtqtyMtKerRecd.Text) > Val(txtYearTodateRecKer.Text) Then
                DisplayInfoMessage("Msg18")
                ''MessageBox.Show("Today Received Kernel should be lesser than Year Received Kernel", "BSP")
                txtYearTodateRecKer.Focus()
                Exit Sub
            End If
            If Val(txtTodateMtRecKer.Text) > Val(txtYearTodateRecKer.Text) Then
                DisplayInfoMessage("Msg19")
                ''MessageBox.Show("Month Received Kernel should be lesser than Year Received Kernel", "BSP")
                txtTodateMtRecKer.Focus()
                Exit Sub
            End If


            If lLoadingLocation = ddlLoadingLocationKerRecd.Text Then

                Dim intCount As Integer = dgvReceivedKernel.CurrentRow.Index
                If lPKOKERReceivedID <> String.Empty Then
                    dgvReceivedKernel.Rows(intCount).Cells("dgMePKOKERReceivedID").Value = lPKOKERReceivedID
                End If

                dgvReceivedKernel.Rows(intCount).Cells("dgmeLoadingLocation").Value = ddlLoadingLocationKerRecd.Text
                dgvReceivedKernel.Rows(intCount).Cells("dgmeLoadingLocationID").Value = ddlLoadingLocationKerRecd.SelectedValue.ToString
                dgvReceivedKernel.Rows(intCount).Cells("dgMeQtyKerRecd").Value = txtqtyMtKerRecd.Text
                dgvReceivedKernel.Rows(intCount).Cells("dgclKerRecdMonthTodate").Value = txtTodateMtRecKer.Text
                dgvReceivedKernel.Rows(intCount).Cells("dgclKerRecdYearTodate").Value = txtYearTodateRecKer.Text



                ClearReceivedKernelGB()
                ddlLoadingLocationKerRecd.SelectedIndex = 0
            ElseIf Not LoadingLocationExist(ddlLoadingLocationKerRecd.Text) Then
                Dim intCount As Integer = dgvReceivedKernel.CurrentRow.Index
                If lPKOKERReceivedID <> String.Empty Then
                    dgvReceivedKernel.Rows(intCount).Cells("dgMePKOKERReceivedID").Value = lPKOKERReceivedID
                End If

                dgvReceivedKernel.Rows(intCount).Cells("dgmeLoadingLocation").Value = ddlLoadingLocationKerRecd.Text
                dgvReceivedKernel.Rows(intCount).Cells("dgmeLoadingLocationID").Value = ddlLoadingLocationKerRecd.SelectedValue.ToString
                dgvReceivedKernel.Rows(intCount).Cells("dgMeQtyKerRecd").Value = txtqtyMtKerRecd.Text
                dgvReceivedKernel.Rows(intCount).Cells("dgclKerRecdMonthTodate").Value = txtTodateMtRecKer.Text
                dgvReceivedKernel.Rows(intCount).Cells("dgclKerRecdYearTodate").Value = txtYearTodateRecKer.Text

                ClearReceivedKernelGB()
                ddlLoadingLocationKerRecd.SelectedIndex = 0
            Else
                DisplayInfoMessage("Msg20")
                ''MsgBox("Loading Location Already Exists")
                ddlLoadingLocationKerRecd.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub AddMultipleEntryDataPressInfo()

        Dim intRowcount As Integer = dtPressInfo.Rows.Count
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL

        Try



            If Not StageExist(ddlStage.Text, lMachineID) Then

                rowMultipleEntryPressInfo = dtPressInfo.NewRow()
                If intRowcount = 0 And lbtnAddPressInfo = "Add" Then
                    Try

                        'Add the Data column to the datatable first time 
                        columnPressInfoAdd = New DataColumn("ProductionLogPressID", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("Stage", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("ScrewAge", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("MachineID", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("PressNo", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("PressNoDescp", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("MeterFrom", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("MeterTo", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("OPHrs", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("ScrewStatus", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)
                        columnPressInfoAdd = New DataColumn("Capacity", System.Type.[GetType]("System.String"))
                        dtPressInfo.Columns.Add(columnPressInfoAdd)


                        ' rowMultipleEntryPressInfo("ProductionLogPressID") = lProductionLogPressID
                        rowMultipleEntryPressInfo("Stage") = ddlStage.Text
                        rowMultipleEntryPressInfo("OPHrs") = txtOPHrs.Text
                        If txtPressNo.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("PressNo") = txtPressNo.Text
                            rowMultipleEntryPressInfo("MachineID") = lMachineID
                            rowMultipleEntryPressInfo("PressNoDescp") = lblPressNoDescp.Text
                        End If

                        If txtCapacity.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("Capacity") = txtCapacity.Text
                        End If


                        If ddlScrewStatus.Text <> "--Select--" Then
                            rowMultipleEntryPressInfo("ScrewStatus") = ddlScrewStatus.Text
                        End If
                        If txtAgeOfScrew.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("ScrewAge") = txtAgeOfScrew.Text
                        End If
                        If txtMeterFrom.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("MeterFrom") = txtMeterFrom.Text
                        End If

                        If txtMeterTo.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("MeterTo") = txtMeterTo.Text
                        End If

                        dtPressInfo.Rows.InsertAt(rowMultipleEntryPressInfo, intRowcount)
                        dgPressInfo.AutoGenerateColumns = False

                    Catch ex As Exception

                        ' rowMultipleEntryPressInfo("ProductionLogPressID") = lProductionLogPressID
                        rowMultipleEntryPressInfo("Stage") = ddlStage.Text
                        rowMultipleEntryPressInfo("OPHrs") = txtOPHrs.Text
                        If txtCapacity.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("Capacity") = txtCapacity.Text
                        End If
                        If txtPressNo.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("PressNo") = txtPressNo.Text
                            rowMultipleEntryPressInfo("MachineID") = lMachineID
                            rowMultipleEntryPressInfo("PressNoDescp") = lblPressNoDescp.Text
                        End If
                        If ddlScrewStatus.Text <> "--Select--" Then
                            rowMultipleEntryPressInfo("ScrewStatus") = ddlScrewStatus.Text
                        End If
                        If txtAgeOfScrew.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("ScrewAge") = txtAgeOfScrew.Text
                        End If
                        If txtMeterFrom.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("MeterFrom") = txtMeterFrom.Text
                        End If

                        If txtMeterTo.Text <> String.Empty Then
                            rowMultipleEntryPressInfo("MeterTo") = txtMeterTo.Text
                        End If

                        dtPressInfo.Rows.InsertAt(rowMultipleEntryPressInfo, intRowcount)
                        dgPressInfo.AutoGenerateColumns = False
                    End Try

                Else

                    ' rowMultipleEntryPressInfo("ProductionLogPressID") = lProductionLogPressID
                    rowMultipleEntryPressInfo("Stage") = ddlStage.Text
                    rowMultipleEntryPressInfo("OPHrs") = txtOPHrs.Text

                    If txtCapacity.Text <> String.Empty Then
                        rowMultipleEntryPressInfo("Capacity") = txtCapacity.Text
                    End If
                    If txtPressNo.Text <> String.Empty Then
                        rowMultipleEntryPressInfo("PressNo") = txtPressNo.Text
                        rowMultipleEntryPressInfo("MachineID") = lMachineID
                        rowMultipleEntryPressInfo("PressNoDescp") = lblPressNoDescp.Text
                    End If
                    If ddlScrewStatus.Text <> "--Select--" Then
                        rowMultipleEntryPressInfo("ScrewStatus") = ddlScrewStatus.Text
                    End If
                    If txtAgeOfScrew.Text <> String.Empty Then
                        rowMultipleEntryPressInfo("ScrewAge") = txtAgeOfScrew.Text
                    End If
                    If txtMeterFrom.Text <> String.Empty Then
                        rowMultipleEntryPressInfo("MeterFrom") = txtMeterFrom.Text
                    End If

                    If txtMeterTo.Text <> String.Empty Then
                        rowMultipleEntryPressInfo("MeterTo") = txtMeterTo.Text
                    End If

                    dtPressInfo.Rows.InsertAt(rowMultipleEntryPressInfo, intRowcount)
                    dgPressInfo.AutoGenerateColumns = False
                End If

                dgPressInfo.DataSource = dtPressInfo
                dgPressInfo.AutoGenerateColumns = False
                ClearLogExpress()
            Else
                DisplayInfoMessage("Msg21")
                ''MsgBox("Stage and Press No Already Exists")
                ddlScrewStatus.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ddlStage.Text = "Stage 1"
    End Sub

    Private Sub UpDateMultipleEntryDataPressInfo()

        '  Dim intRowcount As Integer = dgPressInfo.Rows.Count
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim ObjPKOProductionLogBOL As New PKOProductionLogBOL


        Try

            'If Me.ddlStage.Text = "--Select--" Then
            '    MessageBox.Show("This Field Required", "Stage")
            '    ddlStage.Focus()
            '    Exit Sub
            ''End If
            'If Me.txtPressNo.Text = "" Then
            '    MessageBox.Show("This Field Required", "Press No")
            '    txtPressNo.Focus()
            '    Exit Sub
            'End If

            If lStage = ddlStage.Text And lPressNo = lMachineID Then
                Dim intCount As Integer = dgPressInfo.CurrentRow.Index

                If lProductionLogPressID <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeProductionLogPressID").Value = lProductionLogPressID
                End If


                dgPressInfo.Rows(intCount).Cells("dgMeOPHrs").Value = txtOPHrs.Text
                dgPressInfo.Rows(intCount).Cells("dgMeStage").Value = ddlStage.Text
                If txtPressNo.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMePressNo").Value = txtPressNo.Text
                    dgPressInfo.Rows(intCount).Cells("dgMeMachineID").Value = lMachineID
                    dgPressInfo.Rows(intCount).Cells("dgMePressNoDescp").Value = lblPressNoDescp.Text
                End If
                If txtCapacity.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeCapacity").Value = txtCapacity.Text
                End If

                If ddlScrewStatus.Text <> "--Select--" Then
                    dgPressInfo.Rows(intCount).Cells("dgMeScrewStatus").Value = ddlScrewStatus.Text
                End If
                If txtAgeOfScrew.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeScrewAge").Value = txtAgeOfScrew.Text
                End If
                If txtMeterFrom.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeMeterFrom").Value = txtMeterFrom.Text
                End If

                If txtMeterTo.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeMeterTo").Value = txtMeterTo.Text
                End If
                ClearLogExpress()
            ElseIf Not StageExist(ddlStage.Text, lMachineID) Then
                Dim intCount As Integer = dgPressInfo.CurrentRow.Index

                If lProductionLogPressID <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeProductionLogPressID").Value = lProductionLogPressID
                End If


                dgPressInfo.Rows(intCount).Cells("dgMeOPHrs").Value = txtOPHrs.Text
                dgPressInfo.Rows(intCount).Cells("dgMeStage").Value = ddlStage.Text
                If txtPressNo.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMePressNo").Value = txtPressNo.Text
                    dgPressInfo.Rows(intCount).Cells("dgMeMachineID").Value = lMachineID
                    dgPressInfo.Rows(intCount).Cells("dgMePressNoDescp").Value = lblPressNoDescp.Text
                End If
                If txtCapacity.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeCapacity").Value = txtCapacity.Text
                End If
                If ddlScrewStatus.Text <> "--Select--" Then
                    dgPressInfo.Rows(intCount).Cells("dgMeScrewStatus").Value = ddlScrewStatus.Text
                End If
                If txtAgeOfScrew.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeScrewAge").Value = txtAgeOfScrew.Text
                End If
                If txtMeterFrom.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeMeterFrom").Value = txtMeterFrom.Text
                End If

                If txtMeterTo.Text <> String.Empty Then
                    dgPressInfo.Rows(intCount).Cells("dgMeMeterTo").Value = txtMeterTo.Text
                End If

                ClearLogExpress()
            Else
                DisplayInfoMessage("Msg21")
                ''MsgBox("Stage and Press No Already Exists")
                ddlScrewStatus.Focus()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ddlStage.Text = "Stage 1"
    End Sub


    Private Sub btnPressNoLookup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPressNoLookup.Click
        CPOProductionLogFrm.PressinfoType = "Press"
        Dim frmPressNo As New PressNoLookup
        frmPressNo.ShowDialog()
        If frmPressNo._lMachineID <> String.Empty Then
            Me.txtPressNo.Text = frmPressNo._lPressNo
            '  If frmPressNo._lCapacity <> 0 Then
            Me.txtCapacity.Text = frmPressNo._lCapacity
            'End If
            lMachineID = frmPressNo._lMachineID
            lblPressNoDescp.Text = frmPressNo._lMachineName
        End If
        CPOProductionLogFrm.PressinfoType = ""
    End Sub

    Private Sub txtPressNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPressNo.Leave
        If txtPressNo.Text.Trim() <> String.Empty Then
            Dim ds As New DataSet
            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            objPKOProductionLogPPT.PressNo = txtPressNo.Text.Trim()
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            ds = PKOProductionLogBOL.GetProductionPKOlogPressNo(objPKOProductionLogPPT, "YES", "Press")
            If ds.Tables(0).Rows.Count = 0 Then
                DisplayInfoMessage("Msg22")
                '' MessageBox.Show("Invalid Press No,Please Choose it from look up")
                txtPressNo.Text = String.Empty
                txtCapacity.Text = String.Empty
                lblPressNoDescp.Text = String.Empty
                lMachineID = String.Empty
                txtPressNo.Focus()
                Exit Sub
            Else

                If ds.Tables(0).Rows(0).Item("MachineCode").ToString() <> String.Empty Then
                    txtPressNo.Text = ds.Tables(0).Rows(0).Item("MachineCode")
                End If
                If ds.Tables(0).Rows(0).Item("MachineID").ToString() <> String.Empty Then
                    lMachineID = ds.Tables(0).Rows(0).Item("MachineID")
                End If
                If ds.Tables(0).Rows(0).Item("MachineName").ToString() <> String.Empty Then
                    lblPressNoDescp.Text = ds.Tables(0).Rows(0).Item("MachineName")
                End If
                If ds.Tables(0).Rows(0).Item("Capacity").ToString() <> String.Empty Then
                    txtCapacity.Text = ds.Tables(0).Rows(0).Item("Capacity")
                End If
            End If
        Else
            txtPressNo.Text = String.Empty
            txtCapacity.Text = String.Empty
            lblPressNoDescp.Text = String.Empty
            lMachineID = String.Empty
        End If
    End Sub
    Private Sub MultipleDateEntryValuesRecdKernel()

        If dgvReceivedKernel.RowCount > 0 Then

            ClearReceivedKernelGB()

            If GlobalPPT.strLang = "en" Then
                btnAdd.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAdd.Text = "Memperbarui"
            End If
            '' btnAdd.Text = "Update"
            lbtnAddKerRecd = "Update"


            If dgvReceivedKernel.SelectedRows(0).Cells("dgMePKOKERReceivedID").Value IsNot Nothing Or dgvReceivedKernel.SelectedRows(0).Cells("dgMePKOKERReceivedID").Value.ToString <> String.Empty Then
                Me.lPKOKERReceivedID = dgvReceivedKernel.SelectedRows(0).Cells("dgMePKOKERReceivedID").Value.ToString
            End If

            Me.ddlLoadingLocationKerRecd.Text = Me.dgvReceivedKernel.SelectedRows(0).Cells("dgMeLoadingLocation").Value.ToString
            lLoadingLocation = Me.dgvReceivedKernel.SelectedRows(0).Cells("dgMeLoadingLocation").Value.ToString
            Me.txtqtyMtKerRecd.Text = Me.dgvReceivedKernel.SelectedRows(0).Cells("dgMeQtyKerRecd").Value.ToString
            lqtyMtKerRecd = Me.dgvReceivedKernel.SelectedRows(0).Cells("dgMeQtyKerRecd").Value.ToString

            Me.txtTodateMtRecKer.Text = Me.dgvReceivedKernel.SelectedRows(0).Cells("dgclKerRecdMonthTodate").Value.ToString
            Me.txtYearTodateRecKer.Text = Me.dgvReceivedKernel.SelectedRows(0).Cells("dgclKerRecdYearToDate").Value.ToString
            ' KerRecdMonthYearValueSelect()
            If LoadMonthCount = True And lbtnsaveall <> "Save All" Then
                txtTodateMtRecKer.Enabled = True
            End If

            If lbtnsaveall <> "Save All" And LoadYearCount = True Then
                txtYearTodateRecKer.Enabled = True
            End If

        End If

    End Sub
    Private Sub MultipleDateEntryValuesPressInfo()

        If dgPressInfo.RowCount > 0 Then



            ClearLogExpress()
            If GlobalPPT.strLang = "en" Then
                btnAddPressInfo.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddPressInfo.Text = "Memperbarui"
            End If
            '' btnAddPressInfo.Text = "Update"
            lbtnAddPressInfo = "Update"

            If dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value IsNot Nothing Or dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value.ToString <> String.Empty Then
                Me.lProductionLogPressID = dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value.ToString
            End If


            Me.ddlStage.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeStage").Value.ToString
            lStage = Me.dgPressInfo.SelectedRows(0).Cells("dgMeStage").Value.ToString
            lPressNo = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMachineID").Value.ToString
            txtPressNo.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMePressNo").Value.ToString
            txtAgeOfScrew.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeScrewAge").Value.ToString
            lMachineID = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMachineID").Value.ToString
            txtCapacity.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeCapacity").Value.ToString
            lblPressNoDescp.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMePressNoDescp").Value.ToString
            txtOPHrs.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeOPHrs").Value.ToString

            If Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterFrom").Value.ToString <> String.Empty Then
                txtMeterFrom.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterFrom").Value.ToString
            End If

            If Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterTo").Value.ToString <> String.Empty Then
                txtMeterTo.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeMeterTo").Value.ToString
            End If
            If Me.dgPressInfo.SelectedRows(0).Cells("dgMeScrewStatus").Value.ToString <> "--Select--" Then
                ddlScrewStatus.Text = Me.dgPressInfo.SelectedRows(0).Cells("dgMeScrewStatus").Value.ToString
            End If



        End If

    End Sub

    Private Sub txtPressNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPressNo.KeyDown
        If e.KeyCode = 13 Then
            If txtPressNo.Text <> String.Empty Then
                txtOPHrs.Focus()
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If lbtnAddKerRecd <> "Update" Then
            AddMultipleEntryDataReceivedKernel()
        Else
            UpDateMultipleEntryDataReceivedKernel()
        End If
        GetTotalReceivedQtyKerRec()
        'If Val(txtTodateMtRecKer.Text) = 0 Then
        '    txtTodateMtRecKer.Enabled = True
        '    ' lblTodate.ForeColor = Color.Red
        'Else
        '    txtTodateMtRecKer.Enabled = False
        '    'lblTodate.ForeColor = Color.Black
        'End If

        'If Val(txtYearTodateRecKer.Text) = 0 Then
        '    txtYearTodateRecKer.Enabled = True
        '    ' lblYearTodateMt.ForeColor = Color.Red
        'Else
        '    txtYearTodateRecKer.Enabled = False
        '    ' lblYearTodateMt.ForeColor = Color.Black
        'End If

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearReceivedKernelGB()
        ddlLoadingLocationKerRecd.SelectedIndex = 0
        ddlLoadingLocationKerRecd.Focus()
    End Sub

    Private Sub btnAddPressInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPressInfo.Click
        If Me.txtPressNo.Text.Trim = "" Then
            DisplayInfoMessage("Msg23")
            ''MessageBox.Show("This Field Required", "Press No")
            txtPressNo.Focus()
            Exit Sub
        End If
        If Me.txtOPHrs.Text = "" Then
            DisplayInfoMessage("Msg24")
            ''MessageBox.Show("This Field Required", "Op. Hrs")
            txtOPHrs.Focus()
            Exit Sub
        End If


        If lbtnAddPressInfo <> "Update" Then
            AddMultipleEntryDataPressInfo()
        Else
            UpDateMultipleEntryDataPressInfo()
        End If
        TPH()
    End Sub


    Private Sub btnResetPressinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPressinfo.Click
        ClearLogExpress()
        ddlStage.Focus()
    End Sub

    Private Sub dgvReceivedKernel_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReceivedKernel.CellDoubleClick
        ClearReceivedKernelGB()
        MultipleDateEntryValuesRecdKernel()
    End Sub

    Private Sub dgPressInfo_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgPressInfo.CellDoubleClick
        ClearLogExpress()
        MultipleDateEntryValuesPressInfo()
    End Sub
    Private Function IsSaveValid()
        If dgvPKOLogShiftDetails.Rows.Count = 0 Then
            DisplayInfoMessage("Msg25")
            ''MsgBox("Please add the records in shift information")
            Return False
        End If

        If txtMonthTodateHrs.Text = "00:00" Or txtMonthTodateHrs.Text = "" Then
            DisplayInfoMessage("Msg26")
            ''MessageBox.Show("This field is required", "Hours Month to date")
            tcPKOLog.SelectedIndex = 0
            txtMonthTodateHrs.Focus()
            Return False
        End If

        If txtYearTodateHrs.Text = "00:00" Or txtYearTodateHrs.Text = "" Then
            DisplayInfoMessage("Msg27")
            ''MessageBox.Show("This field is required", "Hours Year to date")
            tcPKOLog.SelectedIndex = 0
            txtYearTodateHrs.Focus()
            Return False
        End If

        If txtMonthTodateHrs.Enabled = True Then
            If txtMonthTodateHrs.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtMonthTodateHrs.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTotalHours.Text
                strArrTotal = strTotal.Split(":")

                'If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg28")
                    ''MessageBox.Show("Month To Date Hrs cant be lesser than Total Hrs")
                    txtMonthTodateHrs.Focus()
                    Return False
                End If
            End If

        End If
        If txtYearTodateHrs.Enabled = True Then
            If txtYearTodateHrs.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtYearTodateHrs.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTotalHours.Text
                strArrTotal = strTotal.Split(":")

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtMonthTodateHrs.Text
                strArrMonth = strMonth.Split(":")

                'If strArr(0) < strArrTotal(0) Or (strArr(0) <= strArrTotal(0) And strArr(1) < strArrTotal(1)) Then
                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg29")
                    ''MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
                    txtYearTodateHrs.Focus()
                    Return False
                End If

                'If strArr(0) < strArrMonth(0) Or (strArr(0) <= strArrMonth(0) And strArr(1) < strArrMonth(1)) Then

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg30")
                    ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                    txtYearTodateHrs.Focus()
                    Return False
                End If
            End If
        End If

        If Val(txtBFQty.Text) = 0 Then
            DisplayInfoMessage("Msg31")
            ''MessageBox.Show("This field is required", "B/F Qty")
            tcPKOLog.SelectedIndex = 1
            txtBFQty.Focus()
            Return False
        End If


        If Val(txtKernelProcessedMonth.Text) = 0 Then
            DisplayInfoMessage("Msg32")
            ''MessageBox.Show("This field is required", "Kernel Processed Month to date")
            tcPKOLog.SelectedIndex = 1
            txtKernelProcessedMonth.Focus()
            Return False
        End If

        If Val(txtKernelProcessedYear.Text) = 0 Then
            DisplayInfoMessage("Msg33")
            ''MessageBox.Show("This field is required", "Kernel Processed Year to date")
            tcPKOLog.SelectedIndex = 1
            txtKernelProcessedYear.Focus()
            Return False
        End If
        Dim lBFCalc As Decimal
        lBFCalc = Val(txtBFQty.Text) + Val(txtTotalReceivedQtyKerRec.Text) - Val(txtKernelProcessedToday.Text)

        If lBFCalc < 0 Then
            DisplayInfoMessage("Msg34")
            ''MsgBox("Kernel Processed for the day cannot be greater than sum of Kernel B/F quantity and Kernel Recieved Quantity for the day.")
            Return False
        End If

        If txtYearTodateHrs.Text = "00:00" Then
            DisplayInfoMessage("Msg35")
            ''MessageBox.Show("This field is required", "Hours Year to date")
            tcPKOLog.SelectedIndex = 0
            txtYearTodateHrs.Focus()
            Return False
        End If

        If Val(txtLossOnKernelToday.Text) <> 0 Then
            If txtLossOnKernelMonth.Text = "" Then
                DisplayInfoMessage("Msg36")
                ''MessageBox.Show("This field is required", "Loss On Kernel Month")
                txtLossOnKernelMonth.Focus()
                Return False
            End If
            If txtLossOnKernelYear.Text = "" Then
                DisplayInfoMessage("Msg37")
                ''MessageBox.Show("This field is required", "Loss On Kernel year")
                txtLossOnKernelYear.Focus()
                Return False
            End If

            If Val(txtLossOnKernelToday.Text) > Val(txtLossOnKernelMonth.Text) Then
                DisplayInfoMessage("Msg38")
                ''MessageBox.Show("Loss Of Kernel Month to date Value should be greater than Loss Of Kernel today qty")
                txtLossOnKernelMonth.Focus()
                Return False
            End If
            If Val(txtLossOnKernelYear.Text) < Val(txtLossOnKernelToday.Text) Then
                DisplayInfoMessage("Msg39")
                ''MessageBox.Show("Loss Of Kernel Year to date Value should be greater than Loss Of Kernel today qty")
                txtLossOnKernelYear.Focus()
                Return False
            End If

            If Val(txtLossOnKernelYear.Text) < Val(txtLossOnKernelMonth.Text) Then
                DisplayInfoMessage("Msg40")
                ''MessageBox.Show("Loss Of Kernel Year to date Value should be greater than Loss Of Kernel month to date")
                txtLossOnKernelYear.Focus()
                Return False
            End If


        End If



        If Val(txtLossOnKernelToday.Text) > Val(txtKerneltoday.Text) Then
            DisplayInfoMessage("Msg101")
            '  MsgBox(" Today Loss on Kernel cant be greater than Kernel Production Today ")
            txtLossOnKernelToday.Focus()
            Return False
        End If
        If txtLossOnKernelMonth.Enabled = True Then
            If Val(txtLossOnKernelMonth.Text) > Val(txtKernelMonth.Text) Then
                DisplayInfoMessage("Msg102")
                '   MsgBox(" Month Loss on Kernel cant be greater than Kernel Production Month ")
                Return False
            End If

            If Val(txtLossOnKernelYear.Text) > Val(txtKernelYear.Text) Then
                DisplayInfoMessage("Msg103")
                '  MsgBox(" Year Loss on Kernel cant be greater than Kernel Production Year ")
                Return False
            End If
        End If



        If txtMechanicalBreakDownToday.Text <> "" And txtMechanicalBreakDownToday.Text <> "00:00" Then
            If txtMechanicalBreakDownMonth.Text = "" Then
                DisplayInfoMessage("Msg41")
                ''MessageBox.Show("This field is required", "Mechanical Breakdown Month")
                txtMechanicalBreakDownMonth.Focus()
                Return False
            End If

            If txtMechanicalBreakDownYear.Text = "" Then
                DisplayInfoMessage("Msg42")
                ''MessageBox.Show("This field is required", "Mechanical Breakdown year")
                txtMechanicalBreakDownYear.Focus()
                Return False
            End If

        End If
        If txtElectricalBreakDownToday.Text <> "" And txtElectricalBreakDownToday.Text <> "00:00" Then

            If txtElectricalBreakDownMonth.Text = "" Then
                DisplayInfoMessage("Msg43")
                ''MessageBox.Show("This field is required", "Electrical Breakdown Month")
                txtElectricalBreakDownMonth.Focus()
                Return False
            End If

            If txtElectricalBreakDownYear.Text = "" Then
                DisplayInfoMessage("Msg44")
                ''MessageBox.Show("This field is required", "Electrical Breakdown year")
                txtElectricalBreakDownYear.Focus()
                Return False
            End If


        End If
        If txtProcessingBreakDownToday.Text <> "" And txtProcessingBreakDownToday.Text <> "00:00" Then
            If txtProcessingBreakDownMonth.Text = "" Then
                DisplayInfoMessage("Msg45")
                ''MessageBox.Show("This field is required", "Processing Breakdown Month")
                txtProcessingBreakDownMonth.Focus()
                Return False
            End If

            If txtProcessingBreakDownYear.Text = "" Then
                DisplayInfoMessage("Msg46")
                ''MessageBox.Show("This field is required", "Processing Breakdown year")
                txtProcessingBreakDownYear.Focus()
                Return False
            End If
        End If


        If txtTotalHours.Text <> "" And txtTotalBreakDownToday.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtTotalHours.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTotalBreakDownToday.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg84")
                Return False
            End If
        End If


        If txtMonthTodateHrs.Enabled = True Then
            If txtMonthTodateHrs.Text <> "" And txtTotalBreakDownMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtMonthTodateHrs.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTotalBreakDownMonth.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg99")
                    Return False
                End If
            End If
        End If

        If txtYearTodateHrs.Enabled = True Then
            If txtYearTodateHrs.Text <> "" And txtTotalBreakDownYear.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtYearTodateHrs.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtTotalBreakDownYear.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg100")
                    Return False
                End If
            End If
        End If

        If txtMechanicalBreakDownMonth.Enabled = True Then
            If txtMechanicalBreakDownMonth.Text <> "" And txtMechanicalBreakDownToday.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtMechanicalBreakDownMonth.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtMechanicalBreakDownToday.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg47")
                    ''MessageBox.Show("Mechanical Breakdown Month To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                    txtMechanicalBreakDownMonth.Focus()
                    Return False
                End If
            End If

        End If
        If txtMechanicalBreakDownYear.Enabled = True Then
            If txtMechanicalBreakDownYear.Text <> "" And txtMechanicalBreakDownMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtMechanicalBreakDownYear.Text
                strArr = str.Split(":")
                If txtMechanicalBreakDownToday.Text <> "" Then
                    Dim strTotal As String
                    Dim strArrTotal() As String
                    strTotal = txtMechanicalBreakDownToday.Text
                    strArrTotal = strTotal.Split(":")

                    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                        DisplayInfoMessage("Msg48")
                        ''MessageBox.Show(" Mechanical Breakdown Year To Date Hrs cant be lesser than Mechanical Breakdown Today Hrs")
                        txtMechanicalBreakDownYear.Focus()
                        Return False
                    End If
                End If

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtMechanicalBreakDownMonth.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg49")
                    ''MessageBox.Show(" Mechanical Breakdown Year To Date Hrs cant be lesser than Mechanical Breakdown Month To Date Hrs")
                    txtMechanicalBreakDownYear.Focus()
                    Return False
                End If
            End If
        End If

        If txtElectricalBreakDownMonth.Enabled = True Then
            If txtElectricalBreakDownMonth.Text <> "" And txtElectricalBreakDownToday.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtElectricalBreakDownMonth.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtElectricalBreakDownToday.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg50")
                    ''MessageBox.Show("Electrical Breakdown Month To Date Hrs cant be lesser than Electrical Breakdown Today Hrs")
                    txtElectricalBreakDownMonth.Focus()
                    Return False
                End If
            End If

        End If
        If txtElectricalBreakDownYear.Enabled = True Then
            If txtElectricalBreakDownYear.Text <> "" And txtElectricalBreakDownMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtElectricalBreakDownYear.Text
                strArr = str.Split(":")
                If txtElectricalBreakDownToday.Text <> "" Then
                    Dim strTotal As String
                    Dim strArrTotal() As String
                    strTotal = txtElectricalBreakDownToday.Text
                    strArrTotal = strTotal.Split(":")

                    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                        DisplayInfoMessage("Msg51")
                        ''MessageBox.Show(" Electrical Breakdown Year To Date Hrs cant be lesser than Electrical Breakdown Today Hrs")
                        txtElectricalBreakDownYear.Focus()
                        Return False
                    End If
                End If

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtElectricalBreakDownMonth.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg52")
                    ''MessageBox.Show(" Electrical Breakdown Year To Date Hrs cant be lesser than Electrical Breakdown Month To Date Hrs")
                    txtElectricalBreakDownYear.Focus()
                    Return False
                End If
            End If
        End If

        If txtProcessingBreakDownMonth.Enabled = True Then
            If txtProcessingBreakDownMonth.Text <> "" And txtProcessingBreakDownToday.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                str = txtProcessingBreakDownMonth.Text
                strArr = str.Split(":")

                Dim strTotal As String
                Dim strArrTotal() As String
                strTotal = txtProcessingBreakDownToday.Text
                strArrTotal = strTotal.Split(":")

                If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                    DisplayInfoMessage("Msg53")
                    ''MessageBox.Show("Processing Breakdown Month To Date Hrs cant be lesser than Processing Breakdown Today Hrs")
                    txtProcessingBreakDownMonth.Focus()
                    Return False
                End If
            End If

        End If
        If txtProcessingBreakDownYear.Enabled = True Then
            If txtProcessingBreakDownYear.Text <> "" And txtProcessingBreakDownMonth.Text <> "" Then
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtProcessingBreakDownYear.Text
                strArr = str.Split(":")
                If txtProcessingBreakDownToday.Text <> "" Then
                    Dim strTotal As String
                    Dim strArrTotal() As String
                    strTotal = txtProcessingBreakDownToday.Text
                    strArrTotal = strTotal.Split(":")

                    If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                        DisplayInfoMessage("Msg54")
                        ''MessageBox.Show(" Processing Breakdown Year To Date Hrs cant be lesser than Processing Breakdown Today Hrs")
                        txtProcessingBreakDownYear.Focus()
                        Return False
                    End If
                End If

                Dim strMonth As String
                Dim strArrMonth() As String
                strMonth = txtProcessingBreakDownMonth.Text
                strArrMonth = strMonth.Split(":")

                If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                    DisplayInfoMessage("Msg55")
                    ''MessageBox.Show(" Processing Breakdown Year To Date Hrs cant be lesser than Processing Breakdown Month To Date Hrs")
                    txtProcessingBreakDownYear.Focus()
                    Return False
                End If
            End If
        End If
        If txtTPHTodaystage1.Text <> "" And txtTPHMonthTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtTPHMonthTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg56")
                ''MessageBox.Show(" Press Info stage 1 Month To Date Hrs cant be lesser than Press Info stage 1 Total Hrs")
                txtTPHMonthTodateStage1.Focus()
                txtTPHMonthTodateStage1.Enabled = True
                Return False
            End If
        End If

        If txtTPHTodaystage1.Text <> "" Then
            If txtTPHMonthTodateStage1.Text = "00:00" Or txtTPHMonthTodateStage1.Text = "" Then
                DisplayInfoMessage("Msg57")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 1")
                txtTPHMonthTodateStage1.Focus()
                Return False
            End If

            If txtTPHYearTodateStage1.Text = "00:00" Or txtTPHYearTodateStage1.Text = "" Then
                DisplayInfoMessage("Msg58")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 2")
                txtTPHYearTodateStage1.Focus()
                Return False
            End If

        End If

        If txtStage2TodayTPH.Text <> "" Then
            If txtStage2monthTodate.Text = "00:00" Or txtStage2monthTodate.Text = "" Then
                DisplayInfoMessage("Msg58")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 2")
                txtStage2monthTodate.Focus()
                Return False
            End If

            If txtStage2yearTodate.Text = "00:00" Or txtStage2yearTodate.Text = "" Then
                DisplayInfoMessage("Msg58")
                ''MessageBox.Show("This field is required", "Press Info Month To Date Line 2")
                txtStage2yearTodate.Focus()
                Return False
            End If

        End If

        If txtTPHTodaystage1.Text <> "" And txtTPHYearTodateStage1.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTPHYearTodateStage1.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTPHTodaystage1.Text
            strArrTotal = strTotal.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtTPHMonthTodateStage1.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg59")
                ''MessageBox.Show(" Press Info stage 1 Year To Date Hrs cant be lesser than Press Info stage 1 Total Hrs")
                txtTPHYearTodateStage1.Focus()
                txtTPHYearTodateStage1.Enabled = True
                Return False
            End If

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg60")
                ''MessageBox.Show(" Press Info stage 1 Year To Date Hrs cant be lesser than Press Info stage 1 Month To Date Hrs")
                txtTPHYearTodateStage1.Focus()
                txtTPHYearTodateStage1.Enabled = True
                Return False
            End If
        End If

        If txtStage2TodayTPH.Text <> "" And txtStage2monthTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            str = txtStage2monthTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg61")
                ''MessageBox.Show(" Press Info stage 2  Month To Date Hrs cant be lesser than Press Info stage 2 Total Hrs")
                txtStage2monthTodate.Focus()
                txtStage2monthTodate.Enabled = True
                Return False
            End If
        End If
        If txtStage2TodayTPH.Text <> "" And txtStage2yearTodate.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtStage2yearTodate.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtStage2TodayTPH.Text
            strArrTotal = strTotal.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtStage2monthTodate.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg62")
                ''MessageBox.Show(" Press Info stage 2 Year To Date Hrs cant be lesser than Press Info stage 2 Total Hrs")
                txtStage2yearTodate.Focus()
                txtStage2yearTodate.Enabled = True
                Return False
            End If

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg63")
                ''MessageBox.Show(" Press Info stage 2 Year To Date Hrs cant be lesser than Press Info stage 2 Month To Date Hrs")
                txtStage2yearTodate.Focus()
                txtStage2yearTodate.Enabled = True
                Return False
            End If
        End If


        If txtMonthTodateHrs.Enabled = True Then
            Dim strArr() As String
            Dim str As String
            str = txtMonthTodateHrs.Text
            strArr = str.Split(":")
            If CInt(strArr(0) >= 744) Then
                DisplayInfoMessage("Msg120")
                txtMonthTodateHrs.Focus()
                Return False
            End If
            str = txtYearTodateHrs.Text
            strArr = str.Split(":")
            If CInt(strArr(0) >= 8760) Then
                DisplayInfoMessage("Msg121")
                txtYearTodateHrs.Focus()
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub btnSaveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveAll.Click

        If lcropYieldID = String.Empty Then
            DisplayInfoMessage("Msg69")
            ''MsgBox("No Record in General.CropYield ")
            Exit Sub
        End If
        If Not IsSaveValid() Then Exit Sub
        'If MsgBox(rm.GetString("Msg621"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.OK Then
        '    Exit Sub
        'End If
        'If dgvPKOProductionLogView.CurrentRow.Index <> 0 Then
        '    MsgBox("User can update only Last record")
        '    Exit Sub
        'End If



        If lbtnsaveall <> "Update All" Then
            SaveDatas()
        Else
            UpDateDatas()
        End If

    End Sub

    Private Sub SaveDatas()

        Try




            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            With objPKOProductionLogPPT
                .ProductionLogDate = dtPKOProductionDate.Value

                Dim objDateisExixts As New Object

                objDateisExixts = PKOProductionLogBOL.DuplicatePKOProductionDate(objPKOProductionLogPPT)
                If objDateisExixts = 0 Then
                    DisplayInfoMessage("Msg64")
                    ''MsgBox("Record already exists for the Date , Please change the Date")
                    Exit Sub
                End If

                .TotalHours = txtTotalHours.Text
                .MonthToDateHrs = txtMonthTodateHrs.Text
                .YeartoDateHrs = txtYearTodateHrs.Text
                .BalanceKERBFQty = Val(txtBFQty.Text)
                .KernelProcessedACT = Val(txtKerneltoday.Text)
                .KernelProcessedACTMTD = Val(txtKernelProcessedMonth.Text)
                .KernelProcessedACTYT = Val(txtKernelProcessedYear.Text)
                .LossOfKernel = Val(txtLossOnKernelToday.Text)
                If txtMechanicalBreakDownToday.Text <> String.Empty Then
                    .MechanicalBD = txtMechanicalBreakDownToday.Text
                Else
                    .MechanicalBD = "00:00"
                End If

                If txtElectricalBreakDownToday.Text <> String.Empty Then
                    .ElectricalBD = txtElectricalBreakDownToday.Text
                Else
                    .ElectricalBD = "00:00"
                End If

                If txtProcessingBreakDownToday.Text <> String.Empty Then
                    .ProcessingBD = txtProcessingBreakDownToday.Text
                Else
                    .ProcessingBD = "00:00"
                End If

                If txtTotalBreakDownToday.Text <> String.Empty Then
                    .TotalBD = txtTotalBreakDownToday.Text
                Else
                    .TotalBD = "00:00"
                End If

                If txtEffectiveProcessingHoursToday.Text <> String.Empty Then
                    .EffectiveProcessingHours = txtEffectiveProcessingHoursToday.Text
                End If

                .Throughput = Val(txtThroughput.Text)
                .OER = Val(txtKERToday.Text)
                If txtLogRemarks.Text.Trim <> String.Empty Then
                    .Remarks = txtLogRemarks.Text.Trim
                End If
                .CropYieldID = lcropYieldID

                '' newly added on may 14 

                .LossOfKernelMTD = Val(txtLossOnKernelMonth.Text)

                If txtMechanicalBreakDownMonth.Text <> String.Empty Then
                    .MechanicalBDMTD = txtMechanicalBreakDownMonth.Text
                Else
                    .MechanicalBDMTD = "00:00"
                End If
                If txtElectricalBreakDownMonth.Text <> String.Empty Then
                    .ElectricalBDMTD = txtElectricalBreakDownMonth.Text
                Else
                    .ElectricalBDMTD = "00:00"
                End If
                If txtProcessingBreakDownMonth.Text <> String.Empty Then
                    .ProcessingBDMTD = txtProcessingBreakDownMonth.Text
                Else
                    .ProcessingBDMTD = "00:00"
                End If

                .LossOfKernelYTD = Val(txtLossOnKernelYear.Text)

                If txtMechanicalBreakDownYear.Text <> String.Empty Then
                    .MechanicalBDYTD = txtMechanicalBreakDownYear.Text
                Else
                    .MechanicalBDYTD = "00:00"
                End If
                If txtElectricalBreakDownYear.Text <> String.Empty Then
                    .ElectricalBDYTD = txtElectricalBreakDownYear.Text
                Else
                    .ElectricalBDYTD = "00:00"
                End If
                If txtProcessingBreakDownYear.Text <> String.Empty Then
                    .ProcessingBDYTD = txtProcessingBreakDownYear.Text
                Else
                    .ProcessingBDYTD = "00:00"
                End If

                Dim dsLog As New DataSet

                dsLog = PKOProductionLogBOL.SaveProductionPKOLog(objPKOProductionLogPPT)

                If dsLog.Tables(0).Rows.Count <> 0 And dsLog IsNot Nothing Then
                    lPKOProductionLogID = dsLog.Tables(0).Rows(0).Item("PKOProductionLogID").ToString
                End If
            End With
            If dgvPKOLogShiftDetails.RowCount <> 0 And lPKOProductionLogID <> String.Empty Then
                Dim ObjPKOProductionLogPPTMe As New PKOProductionLogPPT
                Dim ObjPKOProductionLogBOLMe As New PKOProductionLogBOL

                For Each DataGridViewRow In dgvPKOLogShiftDetails.Rows
                    With ObjPKOProductionLogPPTMe
                        .PKOProductionLogID = lPKOProductionLogID
                        If DataGridViewRow.Cells("dgShift").Value.ToString() = 1 Then
                            .Shift1 = DataGridViewRow.Cells("dgShift").Value.ToString()
                            .AssistantEmpID1 = DataGridViewRow.Cells("dgShiftAssistant").Value.ToString()
                            .MandoreEmpID1 = DataGridViewRow.Cells("dgShiftMandore").Value.ToString()
                            .Starttime1 = DataGridViewRow.Cells("dgShiftStarttime").Value.ToString()
                            .StopTime1 = DataGridViewRow.Cells("dgShiftStopTime").Value.ToString()
                            .KernelProcessedEST1 = DataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString()

                        ElseIf DataGridViewRow.Cells("dgShift").Value.ToString() = 2 Then
                            .Shift2 = DataGridViewRow.Cells("dgShift").Value.ToString()
                            .AssistantEmpID2 = DataGridViewRow.Cells("dgShiftAssistant").Value.ToString()
                            .MandoreEmpID2 = DataGridViewRow.Cells("dgShiftMandore").Value.ToString()
                            .Starttime2 = DataGridViewRow.Cells("dgShiftStarttime").Value.ToString()
                            .StopTime2 = DataGridViewRow.Cells("dgShiftStopTime").Value.ToString()
                            .KernelProcessedEST2 = DataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString()

                        ElseIf DataGridViewRow.Cells("dgShift").Value.ToString() = 3 Then
                            .Shift3 = DataGridViewRow.Cells("dgShift").Value.ToString()
                            .AssistantEmpID3 = DataGridViewRow.Cells("dgShiftAssistant").Value.ToString()
                            .MandoreEmpID3 = DataGridViewRow.Cells("dgShiftMandore").Value.ToString()
                            .Starttime3 = DataGridViewRow.Cells("dgShiftStarttime").Value.ToString()
                            .StopTime3 = DataGridViewRow.Cells("dgShiftStopTime").Value.ToString()
                            .KernelProcessedEST3 = DataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString()
                        End If

                    End With

                Next
                Dim dsShift As DataSet

                dsShift = PKOProductionLogBOL.SaveProductionPKOLogShift(ObjPKOProductionLogPPTMe)
            End If

            If dgvReceivedKernel.RowCount <> 0 And lPKOProductionLogID <> String.Empty Then

                For Each DataGridViewRow In dgvReceivedKernel.Rows
                    Dim ObjPKOProductionLogPPTMe As New PKOProductionLogPPT
                    Dim ObjPKOProductionLogBOLMe As New PKOProductionLogBOL
                    With ObjPKOProductionLogPPTMe
                        .PKOProductionLogID = lPKOProductionLogID
                        .LoadingLocationID = DataGridViewRow.Cells("dgmeLoadingLocationID").Value.ToString()
                        .KernelReceivedQty = IIf(DataGridViewRow.Cells("dgMeQtyKerRecd").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeQtyKerRecd").Value.ToString())
                        .KernelReceivedQtyTodate = DataGridViewRow.Cells("dgclKerRecdMonthTodate").Value.ToString()
                        .KernelReceivedQtyYearTodate = DataGridViewRow.Cells("dgclKerRecdYearTodate").Value.ToString()
                    End With
                    Dim dsKer As DataSet
                    dsKer = PKOProductionLogBOL.SaveProductionPKOKERReceived(ObjPKOProductionLogPPTMe)
                Next

            End If

            If dgPressInfo.RowCount <> 0 And lPKOProductionLogID <> String.Empty Then

                For Each DataGridViewRow In dgPressInfo.Rows
                    Dim ObjPKOProductionLogPPTMe As New PKOProductionLogPPT
                    Dim ObjPKOProductionLogBOLMe As New PKOProductionLogBOL
                    With ObjPKOProductionLogPPTMe
                        .PKOProductionLogID = lPKOProductionLogID
                        .StagePress = DataGridViewRow.Cells("dgmeStage").Value.ToString()
                        If DataGridViewRow.Cells("dgMeScrewAge").Value.ToString() <> "" Then
                            Dim lstr As String
                            lstr = DataGridViewRow.Cells("dgMeScrewAge").Value.ToString()
                            .ScrewAge = lstr.Replace(":", ".")
                        End If
                        .MachineID = DataGridViewRow.Cells("dgMeMachineID").Value.ToString()
                        .MeterFrom = IIf(DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString())
                        .MeterTo = IIf(DataGridViewRow.Cells("dgMeMeterTo").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterTo").Value.ToString())
                        .OPHrs = DataGridViewRow.Cells("dgmeOPHrs").Value.ToString()
                        .ScrewStatus = DataGridViewRow.Cells("dgmeScrewStatus").Value.ToString()
                        .PCage = ""
                    End With
                    Dim dsKer As DataSet
                    dsKer = PKOProductionLogBOL.SaveProductionPKOLogPress(ObjPKOProductionLogPPTMe)
                Next

            End If

            Dim ObjPKOProductionLogPPTMe2 As New PKOProductionLogPPT
            Dim ObjPKOProductionLogBOLMe2 As New PKOProductionLogBOL
            With ObjPKOProductionLogPPTMe2
                .PKOProductionLogID = lPKOProductionLogID
                .StagePress = "Stage 1"
                If txtTPHTodaystage1.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtTPHTodaystage1.Text.Trim
                End If

                If txtTPHMonthTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtTPHMonthTodateStage1.Text
                End If

                If txtTPHYearTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtTPHYearTodateStage1.Text
                End If

                .AvgPressThrToday = Val(txtAPTstage1today.Text)
                .AvgPressThrMTD = Val(txtAPHstage1monthtodate.Text)
                .AvgPressThrYTD = Val(txtAPTstage1yeartodate.Text)
                .UtilizationToday = Val(txtutilstage1today.Text)
                .UtilizationMTD = Val(txtutilstage1monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage1yeartodate.Text)
            End With
            Dim dsKerSumm As DataSet
            dsKerSumm = PKOProductionLogBOL.SavePKOProductionPressSummary(ObjPKOProductionLogPPTMe2)


            Dim ObjPKOProductionLogPPTMe1 As New PKOProductionLogPPT
            Dim ObjPKOProductionLogBOLMe1 As New PKOProductionLogBOL
            With ObjPKOProductionLogPPTMe1
                .PKOProductionLogID = lPKOProductionLogID
                .StagePress = "Stage 2"
                If txtStage2TodayTPH.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtStage2TodayTPH.Text.Trim
                End If

                If txtStage2monthTodate.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtStage2monthTodate.Text
                End If

                If txtStage2yearTodate.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtStage2yearTodate.Text
                End If


                .AvgPressThrToday = Val(txtAPTstage2today.Text)
                .AvgPressThrMTD = Val(txtAPTstage2monthtodae.Text)
                .AvgPressThrYTD = Val(txtAPTStage2yeartodate.Text)
                .UtilizationToday = Val(txtutilstage2.Text)
                .UtilizationMTD = Val(txtutilstage2monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage2yeartodate.Text)
            End With
            Dim dsKerSumm1 As DataSet
            dsKerSumm1 = PKOProductionLogBOL.SavePKOProductionPressSummary(ObjPKOProductionLogPPTMe1)


            clear()
            ClearLogExpress()
            ClearReceivedKernelGB()
            ClearGridView(dgvReceivedKernel)
            ClearGridView(dgPressInfo)
            ClearShift()
            ClearGridView(dgvPKOLogShiftDetails)
            DisplayInfoMessage("Msg65")
            ''MsgBox("Data Successfully Saved!")
            BindDataGrid()
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg66")
            ''MsgBox("Save Process Failed")

        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub UpDateDatas()

        Try

            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            With objPKOProductionLogPPT
                .PKOProductionLogID = lPKOProductionLogID
                .ProductionLogDate = dtPKOProductionDate.Value
                .CropYieldID = lcropYieldID

                'lHrsStartTime = cmbStartHours.Text
                'lminStartTime = cmbStartMin.Text

                'lHrsStopTime = cmbStopHours.Text
                'lminStopTime = cmbStopMin.Text

                .TotalHours = txtTotalHours.Text
                .MonthToDateHrs = txtMonthTodateHrs.Text
                .YeartoDateHrs = txtYearTodateHrs.Text
                .BalanceKERBFQty = Val(txtBFQty.Text)
                .KernelProcessedACT = Val(txtKerneltoday.Text)
                .KernelProcessedACTMTD = Val(txtKernelProcessedMonth.Text)
                .KernelProcessedACTYT = Val(txtKernelProcessedYear.Text)
                .LossOfKernel = Val(txtLossOnKernelToday.Text)
                If txtMechanicalBreakDownToday.Text <> String.Empty Then
                    .MechanicalBD = txtMechanicalBreakDownToday.Text
                Else
                    .MechanicalBD = "00:00"
                End If

                If txtElectricalBreakDownToday.Text <> String.Empty Then
                    .ElectricalBD = txtElectricalBreakDownToday.Text
                Else
                    .ElectricalBD = "00:00"
                End If

                If txtProcessingBreakDownToday.Text <> String.Empty Then
                    .ProcessingBD = txtProcessingBreakDownToday.Text
                Else
                    .ProcessingBD = "00:00"
                End If

                If txtTotalBreakDownToday.Text <> String.Empty Then
                    .TotalBD = txtTotalBreakDownToday.Text
                Else
                    .TotalBD = "00:00"
                End If

                If txtEffectiveProcessingHoursToday.Text <> String.Empty Then
                    .EffectiveProcessingHours = txtEffectiveProcessingHoursToday.Text
                End If

                .Throughput = Val(txtThroughput.Text)

                .OER = Val(txtKERToday.Text)
                If txtLogRemarks.Text.Trim <> String.Empty Then
                    .Remarks = txtLogRemarks.Text.Trim
                End If

                '' newly added on may 14 

                .LossOfKernelMTD = Val(txtLossOnKernelMonth.Text)


                If txtMechanicalBreakDownMonth.Text <> String.Empty Then
                    .MechanicalBDMTD = txtMechanicalBreakDownMonth.Text
                Else
                    .MechanicalBDMTD = "00:00"
                End If
                If txtElectricalBreakDownMonth.Text <> String.Empty Then
                    .ElectricalBDMTD = txtElectricalBreakDownMonth.Text
                Else
                    .ElectricalBDMTD = "00:00"
                End If
                If txtProcessingBreakDownMonth.Text <> String.Empty Then
                    .ProcessingBDMTD = txtProcessingBreakDownMonth.Text
                Else
                    .ProcessingBDMTD = "00:00"
                End If


                .LossOfKernelYTD = Val(txtLossOnKernelYear.Text)

                If txtMechanicalBreakDownYear.Text <> String.Empty Then
                    .MechanicalBDYTD = txtMechanicalBreakDownYear.Text
                Else
                    .MechanicalBDYTD = "00:00"
                End If
                If txtElectricalBreakDownYear.Text <> String.Empty Then
                    .ElectricalBDYTD = txtElectricalBreakDownYear.Text
                Else
                    .ElectricalBDYTD = "00:00"
                End If
                If txtProcessingBreakDownYear.Text <> String.Empty Then
                    .ProcessingBDYTD = txtProcessingBreakDownYear.Text
                Else
                    .ProcessingBDYTD = "00:00"
                End If



                Dim dsLog As New DataSet

                dsLog = objPKOProductionLogBOL.UpdateProductionPKOLog(objPKOProductionLogPPT)

                If dsLog.Tables(0).Rows.Count <> 0 And dsLog IsNot Nothing Then
                    lPKOProductionLogID = dsLog.Tables(0).Rows(0).Item("PKOProductionLogID").ToString
                End If
            End With

            If dgvPKOLogShiftDetails.RowCount <> 0 And lPKOProductionLogID <> String.Empty Then
                Dim ObjPKOProductionLogPPTMe As New PKOProductionLogPPT
                Dim ObjPKOProductionLogBOLMe As New PKOProductionLogBOL

                For Each DataGridViewRow In dgvPKOLogShiftDetails.Rows
                    With ObjPKOProductionLogPPTMe
                        .PKOProductionLogID = lPKOProductionLogID
                        If DataGridViewRow.Cells("dgShift").Value.ToString() = 1 Then
                            .Shift1 = DataGridViewRow.Cells("dgShift").Value.ToString()
                            .AssistantEmpID1 = DataGridViewRow.Cells("dgShiftAssistant").Value.ToString()
                            .MandoreEmpID1 = DataGridViewRow.Cells("dgShiftMandore").Value.ToString()
                            .Starttime1 = DataGridViewRow.Cells("dgShiftStarttime").Value.ToString()
                            .StopTime1 = DataGridViewRow.Cells("dgShiftStopTime").Value.ToString()
                            .KernelProcessedEST1 = DataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString()

                        ElseIf DataGridViewRow.Cells("dgShift").Value.ToString() = 2 Then
                            .Shift2 = DataGridViewRow.Cells("dgShift").Value.ToString()
                            .AssistantEmpID2 = DataGridViewRow.Cells("dgShiftAssistant").Value.ToString()
                            .MandoreEmpID2 = DataGridViewRow.Cells("dgShiftMandore").Value.ToString()
                            .Starttime2 = DataGridViewRow.Cells("dgShiftStarttime").Value.ToString()
                            .StopTime2 = DataGridViewRow.Cells("dgShiftStopTime").Value.ToString()
                            .KernelProcessedEST2 = DataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString()

                        ElseIf DataGridViewRow.Cells("dgShift").Value.ToString() = 3 Then
                            .Shift3 = DataGridViewRow.Cells("dgShift").Value.ToString()
                            .AssistantEmpID3 = DataGridViewRow.Cells("dgShiftAssistant").Value.ToString()
                            .MandoreEmpID3 = DataGridViewRow.Cells("dgShiftMandore").Value.ToString()
                            .Starttime3 = DataGridViewRow.Cells("dgShiftStarttime").Value.ToString()
                            .StopTime3 = DataGridViewRow.Cells("dgShiftStopTime").Value.ToString()
                            .KernelProcessedEST3 = DataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString()
                        End If
                    End With
                Next
                Dim dsShift As DataSet
                dsShift = ObjPKOProductionLogBOLMe.UpdateProductionPKOLogShift(ObjPKOProductionLogPPTMe)
            End If


            If dgvReceivedKernel.RowCount <> 0 And lPKOProductionLogID <> String.Empty Then

                For Each DataGridViewRow In dgvReceivedKernel.Rows
                    Dim ObjPKOProductionLogPPTMe As New PKOProductionLogPPT
                    Dim ObjPKOProductionLogBOLMe As New PKOProductionLogBOL
                    With ObjPKOProductionLogPPTMe
                        .PKOKERReceivedID = DataGridViewRow.Cells("dgMePKOKERReceivedID").Value.ToString()
                        .PKOProductionLogID = lPKOProductionLogID
                        .LoadingLocationID = DataGridViewRow.Cells("dgmeLoadingLocationID").Value.ToString()
                        .KernelReceivedQty = IIf(DataGridViewRow.Cells("dgMeQtyKerRecd").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeQtyKerRecd").Value.ToString())
                        .KernelReceivedQtyTodate = DataGridViewRow.Cells("dgclKerRecdMonthTodate").Value.ToString()
                        .KernelReceivedQtyYearTodate = DataGridViewRow.Cells("dgclKerRecdYearTodate").Value.ToString()

                    End With
                    Dim dsKer As DataSet
                    If ObjPKOProductionLogPPTMe.PKOKERReceivedID <> String.Empty Then
                        dsKer = ObjPKOProductionLogBOLMe.UpdateProductionPKOKERReceived(ObjPKOProductionLogPPTMe)
                    Else
                        dsKer = PKOProductionLogBOL.SaveProductionPKOKERReceived(ObjPKOProductionLogPPTMe)
                    End If

                Next

            End If

            If dgPressInfo.RowCount <> 0 And lPKOProductionLogID <> String.Empty Then

                For Each DataGridViewRow In dgPressInfo.Rows
                    Dim ObjPKOProductionLogPPTMe As New PKOProductionLogPPT
                    Dim ObjPKOProductionLogBOLMe As New PKOProductionLogBOL
                    With ObjPKOProductionLogPPTMe
                        .ProductionLogPressID = DataGridViewRow.Cells("dgMeProductionLogPressID").Value.ToString()
                        .PKOProductionLogID = lPKOProductionLogID
                        .StagePress = DataGridViewRow.Cells("dgmeStage").Value.ToString()
                        If DataGridViewRow.Cells("dgMeScrewAge").Value.ToString() <> "" Then
                            Dim lstr As String
                            lstr = DataGridViewRow.Cells("dgMeScrewAge").Value.ToString()
                            .ScrewAge = lstr.Replace(":", ".")
                        End If
                        .MachineID = DataGridViewRow.Cells("dgMeMachineID").Value.ToString()
                        .MeterFrom = IIf(DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterFrom").Value.ToString())
                        .MeterTo = IIf(DataGridViewRow.Cells("dgMeMeterTo").Value.ToString() = "", 0, DataGridViewRow.Cells("dgMeMeterTo").Value.ToString())
                        .OPHrs = DataGridViewRow.Cells("dgmeOPHrs").Value.ToString()
                        .ScrewStatus = DataGridViewRow.Cells("dgmeScrewStatus").Value.ToString()
                        .PCage = ""
                    End With
                    Dim dsKer As DataSet
                    If ObjPKOProductionLogPPTMe.ProductionLogPressID <> String.Empty Then
                        dsKer = ObjPKOProductionLogBOLMe.UpdateProductionPKOLogPress(ObjPKOProductionLogPPTMe)
                    Else
                        dsKer = PKOProductionLogBOL.SaveProductionPKOLogPress(ObjPKOProductionLogPPTMe)
                    End If

                Next

            End If

            Dim ObjPKOProductionLogPPTMe2 As New PKOProductionLogPPT
            Dim ObjPKOProductionLogBOLMe2 As New PKOProductionLogBOL
            With ObjPKOProductionLogPPTMe2
                .PKOProductionLogID = lPKOProductionLogID
                .StagePress = "Stage 1"
                If txtTPHTodaystage1.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtTPHTodaystage1.Text.Trim
                End If

                If txtTPHMonthTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtTPHMonthTodateStage1.Text
                End If

                If txtTPHYearTodateStage1.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtTPHYearTodateStage1.Text
                End If

                .AvgPressThrToday = Val(txtAPTstage1today.Text)
                .AvgPressThrMTD = Val(txtAPHstage1monthtodate.Text)
                .AvgPressThrYTD = Val(txtAPTstage1yeartodate.Text)
                .UtilizationToday = Val(txtutilstage1today.Text)
                .UtilizationMTD = Val(txtutilstage1monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage1yeartodate.Text)
                .PressSummaryID = stage1PressSummaryID


            End With
            Dim dsKerSumm As DataSet
            If ObjPKOProductionLogPPTMe2.PressSummaryID = "" Then
                dsKerSumm = PKOProductionLogBOL.SavePKOProductionPressSummary(ObjPKOProductionLogPPTMe2)
            Else
                dsKerSumm = ObjPKOProductionLogBOLMe2.UpdatePKOProductionPressSummary(ObjPKOProductionLogPPTMe2)
            End If


            Dim ObjPKOProductionLogPPTMe1 As New PKOProductionLogPPT
            Dim ObjPKOProductionLogBOLMe1 As New PKOProductionLogBOL
            With ObjPKOProductionLogPPTMe1
                .PKOProductionLogID = lPKOProductionLogID
                .StagePress = "Stage 2"
                If txtStage2TodayTPH.Text.Trim = "" Then
                    .TotalPressHrsToday = "00:00"
                Else
                    .TotalPressHrsToday = txtStage2TodayTPH.Text.Trim
                End If

                If txtStage2monthTodate.Text.Trim = "" Then
                    .TotalPressHrsMTD = "00:00"
                Else
                    .TotalPressHrsMTD = txtStage2monthTodate.Text
                End If

                If txtStage2yearTodate.Text.Trim = "" Then
                    .TotalPressHrsYTD = "00:00"
                Else
                    .TotalPressHrsYTD = txtStage2yearTodate.Text
                End If


                .AvgPressThrToday = Val(txtAPTstage2today.Text)
                .AvgPressThrMTD = Val(txtAPTstage2monthtodae.Text)
                .AvgPressThrYTD = Val(txtAPTStage2yeartodate.Text)
                .UtilizationToday = Val(txtutilstage2.Text)
                .UtilizationMTD = Val(txtutilstage2monthtodate.Text)
                .UtilizationYTD = Val(txtutilstage2yeartodate.Text)
                .PressSummaryID = stage2PressSummaryID

            End With
            Dim dsKerSumm1 As DataSet
            If ObjPKOProductionLogPPTMe1.PressSummaryID = "" Then
                dsKerSumm1 = PKOProductionLogBOL.SavePKOProductionPressSummary(ObjPKOProductionLogPPTMe1)
            Else
                dsKerSumm1 = ObjPKOProductionLogBOLMe1.UpdatePKOProductionPressSummary(ObjPKOProductionLogPPTMe1)
            End If
            DeleteMultiEntryRecordsKernelReceived()
            DeleteMultiEntryRecordsPressInfo()

            clear()
            ClearReceivedKernelGB()
            ClearLogExpress()
            ClearGridView(dgvReceivedKernel)
            ClearGridView(dgPressInfo)
            ClearShift()
            ClearGridView(dgvPKOLogShiftDetails)
            DisplayInfoMessage("Msg67")
            ''MsgBox("Data Successfully UpDated!")
            GlobalPPT.IsRetainFocus = False
        Catch ex As Exception
            DisplayInfoMessage("Msg68")
            ''MsgBox("Update Process Failed")

        End Try
        'If Not objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
        '    MsgBox(PrivilegeError)
        'End If
    End Sub

    Private Sub tcPKOroductionLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcPKOroductionLog.SelectedIndexChanged
        'If tcPKOroductionLog.SelectedIndex = 0 Then
        '    clear()
        '    ClearReceivedKernelGB()
        '    ClearLogExpress()
        '    ClearShift()
        '    GetKernelReceivedLocation()
        '    GetPKOProductionTodayValues()
        '    ClearGridView(dgvReceivedKernel)
        '    ClearGridView(dgvPKOLogShiftDetails)
        '    ClearGridView(dgPressInfo)
        '    tcPKOLog.SelectedIndex = 0
        'Else
        '    BindDataGrid()
        'End If
    End Sub


    Private Sub BindDataGrid()
        Try
            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            Dim ds As New DataTable

            With objPKOProductionLogPPT

                If chkPKOLogDate.Checked = True Then
                    dtpPKOProdLogDateSearch.Enabled = True
                    .lProductionLogDate = Format(Me.dtpPKOProdLogDateSearch.Value, "yyyy/MM/dd")
                Else
                    dtpPKOProdLogDateSearch.Enabled = False
                    .lProductionLogDate = "01/01/1900"

                End If
            End With

            ds = PKOProductionLogBOL.GetPKOProductionLog(objPKOProductionLogPPT)

            If ds.Rows.Count <> 0 And ds IsNot Nothing Then

                dgvPKOProductionLogView.AutoGenerateColumns = False
                Me.dgvPKOProductionLogView.DataSource = ds
            Else
                ClearGridView(dgvPKOProductionLogView) '''''clear the records from grid view
                ' lblView.Visible = True
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub GetCropYieldID()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT

        Dim ds As New DataSet


        ds = PKOProductionLogBOL.GetPKOProductionlogCropYieldID(objPKOProductionLogPPT)

        If ds.Tables(0).Rows.Count <> 0 And ds IsNot Nothing Then
            lcropYieldID = ds.Tables(0).Rows(0).Item("CropYieldID").ToString
        Else
            DisplayInfoMessage("Msg69")
            ''MsgBox("No Record in General.CropYield ", "CropYieldID")
        End If
    End Sub

    Private Sub txtLossOnKernelToday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLossOnKernelToday.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub


    Private Sub txtMechanicalBreakDownToday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMechanicalBreakDownToday.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMechanicalBreakDownToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMechanicalBreakDownToday.TextChanged

        If txtMechanicalBreakDownToday.Text <> "" Then
            Dim Value As String = txtMechanicalBreakDownToday.Text
            Dim strlen As Integer
            strlen = Len(txtMechanicalBreakDownToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMechanicalBreakDownToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    '' MsgBox("Please enter only numeric  values")
                    txtMechanicalBreakDownToday.Focus()
                End If

            Next
        End If

    End Sub

    Private Sub txtElectricalBreakDownToday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtElectricalBreakDownToday.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtElectricalBreakDownToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElectricalBreakDownToday.TextChanged

        If txtElectricalBreakDownToday.Text <> "" Then
            Dim Value As String = txtElectricalBreakDownToday.Text
            Dim strlen As Integer
            strlen = Len(txtElectricalBreakDownToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtElectricalBreakDownToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please enter only numeric  values")
                    txtElectricalBreakDownToday.Focus()
                End If
            Next
        End If

    End Sub

    Private Sub txtProcessingBreakDownToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessingBreakDownToday.TextChanged
        If txtProcessingBreakDownToday.Text <> "" Then
            Dim Value As String = txtProcessingBreakDownToday.Text
            Dim strlen As Integer
            strlen = Len(txtProcessingBreakDownToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtProcessingBreakDownToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    ''MsgBox("Please enter only numeric  values")
                    txtProcessingBreakDownToday.Focus()
                End If
            Next
        End If


    End Sub

    Private Sub TotalHoursCalculation()

        '''''For Hours''''''
        'Dim strTotalhrs As Integer
        'If Val(cmbStopHours.Text) > Val(cmbStartHours.Text) Then
        '    strTotalhrs = Val(cmbStopHours.Text) - Val(cmbStartHours.Text)
        'ElseIf Val(cmbStartHours.Text) > Val(cmbStopHours.Text) Then
        '    strTotalhrs = 24 - Val(cmbStartHours.Text) + Val(cmbStopHours.Text)
        'Else
        '    strTotalhrs = "0"
        '    If Val(cmbStopMin.Text) < Val(cmbStartMin.Text) Then
        '        strTotalhrs = 24
        '    End If
        'End If

        '''''For Mins''''''
        'Dim strTotalMins As String = 0
        'If Val(cmbStopMin.Text) > Val(cmbStartMin.Text) Then
        '    strTotalMins = Val(cmbStopMin.Text) - Val(cmbStartMin.Text)
        'ElseIf Val(cmbStartMin.Text) > Val(cmbStopMin.Text) Then
        '    strTotalMins = 60 - Val(cmbStartMin.Text) + Val(cmbStopMin.Text)
        '    strTotalhrs = strTotalhrs - 1
        '    'If strTotalhrs = 0 Then
        '    '    strTotalhrs = "23"
        '    'End If
        'End If
        'If strTotalMins = "5" Then
        '    strTotalMins = "05"
        'End If
        'Dim Strhr As String
        'If strTotalhrs < 10 Then
        '    Strhr = "0" + Convert.ToString(strTotalhrs)
        'Else
        '    Strhr = strTotalhrs
        'End If
        'If strTotalMins = "0" Or strTotalMins = "" Then
        '    strTotalMins = "00"
        'End If

        'txtShiftHours.Text = CStr(Strhr) + ":" + CStr(strTotalMins)


    End Sub
    Private Sub TotalHourShiftsKernelProcessedCalculation()

        Dim objDataGridViewRow As New DataGridViewRow

        Dim lKernelProcessed As Decimal = 0
        lShifthours = "00:00"
        For Each objDataGridViewRow In dgvPKOLogShiftDetails.Rows

            If objDataGridViewRow.Cells("dgShifthours").Value.ToString <> String.Empty Then
                Dim lCominValue As String = "00:00"
                lCominValue = objDataGridViewRow.Cells("dgShifthours").Value

                lShifthours = lShifthours
                'Dim ProcessHrs As String
                Dim strArr As String()
                Dim strArr1 As String()

                Dim Str, Str1 As String
                Str = lCominValue
                strArr = Str.Split(":")
                Str1 = lShifthours
                strArr1 = Str1.Split(":")

                Dim Lhrs, lmin As Integer
                Lhrs = CInt(strArr(0)) + CInt(strArr1(0))

                lmin = CInt(strArr(1)) + CInt(strArr1(1))

                If Lhrs > 24 Then
                    DisplayInfoMessage("Msg70")
                    ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                    Exit Sub
                ElseIf Lhrs = 24 And lmin > 0 Then
                    DisplayInfoMessage("Msg70")
                    ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                    Exit Sub
                Else
                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"

                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lShifthours = Strhrs + ":" + StrMin
                End If

            End If
        Next



        For Each objDataGridViewRow In dgvPKOLogShiftDetails.Rows

            If objDataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString <> String.Empty Then
                lKernelProcessed = lKernelProcessed + Val(objDataGridViewRow.Cells("dgShiftKernelProcessed").Value.ToString())
            End If
        Next

        txtTotalHours.Text = CStr(lShifthours)
        txtEffectiveProcessingHoursToday.Text = CStr(lShifthours)

        'If lKernelProcessed <> 0 Then
        '    txtKerneltoday.Text = lKernelProcessed
        '    txtKernelProcessedToday.Text = lKernelProcessed
        '    txtTotalShiftKernelProcessed.Text = lKernelProcessed
        'Else
        '    txtKerneltoday.Text = ""
        '    txtKernelProcessedToday.Text = ""
        '    txtTotalShiftKernelProcessed.Text = ""
        'End If
        txtKerneltoday.Text = lKernelProcessed
        txtKernelProcessedToday.Text = lKernelProcessed
        txtTotalShiftKernelProcessed.Text = lKernelProcessed
        If dgvPKOLogShiftDetails.Rows.Count = 0 Then
            txtKerneltoday.Text = ""
            txtKernelProcessedToday.Text = ""
        End If
        lKernelProcessed = 0
        lShifthours = "00:00"



    End Sub
    'Private Function TimeDisplay(ByVal time As Decimal)
    '    Dim lTime As String = ""
    '    Dim intMins As Double = 0
    '    Dim intHrs As Double = 0
    '    Dim intDiv As Double = 0
    '    Dim strDiv As String = 0
    '    Dim StrHrs As String = ""
    '    If time <> 0 Then

    '        intMins = time * 100
    '        intHrs = intMins / 100
    '        intHrs = Fix(intHrs)
    '        intDiv = intMins Mod 100
    '        intDiv = Fix(intDiv)
    '        strDiv = intDiv
    '        StrHrs = intHrs

    '        If (intDiv >= 60) Then
    '            intMins = intDiv - 60
    '            intHrs = intHrs + 1
    '            If intHrs < 10 Then
    '                StrHrs = "0" + Convert.ToString(intHrs)
    '            Else
    '                StrHrs = intHrs
    '            End If

    '            If intMins = 0 Then
    '                strDiv = "00"
    '            ElseIf intMins = "5" Then
    '                strDiv = "05"
    '            Else
    '                strDiv = intMins
    '            End If

    '            lTime = StrHrs.ToString + ":" + strDiv.ToString
    '        ElseIf intDiv.ToString.Length = 1 Then
    '            If intHrs < 10 Then
    '                StrHrs = "0" + Convert.ToString(intHrs)
    '            End If
    '            lTime = StrHrs.ToString + ":0" + intDiv.ToString
    '        Else
    '            If intHrs < 10 Then
    '                StrHrs = "0" + Convert.ToString(intHrs)
    '            End If

    '            lTime = StrHrs.ToString + ":" + intDiv.ToString
    '        End If
    '    End If
    '    Return lTime

    'End Function

    Private Sub cmbStartHours_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TotalHoursCalculation()
    End Sub

    Private Sub cmbStartMin_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TotalHoursCalculation()
    End Sub

    Private Sub cmbStopHours_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TotalHoursCalculation()
    End Sub

    Private Sub cmbStopMin_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TotalHoursCalculation()
    End Sub

    Private Sub txtKernelProcessed_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelProcessed.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKernelProcessed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelProcessed.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtqtyMtKerRecd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtqtyMtKerRecd.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtqtyMtKerRecd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqtyMtKerRecd.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtLossOnKernelToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLossOnKernelToday.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtMechanicalBreakDownToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMechanicalBreakDownToday.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtElectricalBreakDownToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtElectricalBreakDownToday.KeyDown
        ' KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtProcessingBreakDownToday_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProcessingBreakDownToday.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtProcessingBreakDownToday_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProcessingBreakDownToday.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub



    Private Sub txtAgeOfScrew_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAgeOfScrew.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtAgeOfScrew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAgeOfScrew.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMeterTo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeterTo.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMeterTo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeterTo.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMeterFrom_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMeterFrom.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMeterFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeterFrom.KeyPress
        ' KeyPress2Decimal(sender, e)
    End Sub

    Private Sub KeyPress3Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is3Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub KeyDown3Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If
        isModifierKey = False
        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.[Decimal]) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            is3Decimal = False
                            Return
                        End If

                        is3Decimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        is3Decimal = re3DecimalPlaces.IsMatch(text)

                End Select
            Else
                is3Decimal = False
                Return
            End If

        Else
            is3Decimal = True
        End If

    End Sub


    Private Sub KeyPress2Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isModifierKey Then
            e.Handled = True
            Return
        End If


        If is2Decimal = False Then
            ' Stop the character from being entered into the control since it is non-numerical.
            e.Handled = True
        Else
            e.Handled = False

        End If
    End Sub

    Private Sub KeyDown2Decimal(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.Modifiers And (Keys.Alt Or Keys.Insert Or Keys.Control Or Keys.Shift) Then
            isModifierKey = True
            Return
        End If
        isModifierKey = False
        If e.KeyCode <> Keys.Delete And e.KeyCode <> Keys.Back And e.KeyCode <> Keys.Shift Then

            Dim txtBox As TextBox = DirectCast(sender, TextBox)
            Dim text As String = String.Empty


            If (e.KeyCode >= Keys.NumPad0 And e.KeyCode <= Keys.NumPad9) OrElse (e.KeyCode >= Keys.D0 And e.KeyCode <= Keys.D9) OrElse (e.KeyCode = Keys.OemPeriod OrElse e.KeyCode = Keys.Decimal) Then
                Select Case e.KeyCode
                    'Case Keys.OemPeriod
                    '    isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                    Case Keys.[Decimal], Keys.OemPeriod
                        'digit from keypad? --> Keys.[Decimal]
                        'isDecimal = General.CheckIfNumericKey(e.KeyCode, txtBox.Text.Trim.Contains("."))

                        If txtBox.Text.Trim.Contains(".") Then
                            is2Decimal = False
                            Return
                        End If

                        is2Decimal = True
                        Return
                    Case Else

                        If (e.KeyCode >= Keys.D0) AndAlso (e.KeyCode <= Keys.D9) Then
                            'digit from top of keyboard?
                            'text = txtBox.Text.Trim & CChar(ChrW(e.KeyValue))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(ChrW(e.KeyValue)))
                        End If

                        If (e.KeyCode >= Keys.NumPad0) AndAlso (e.KeyCode <= Keys.NumPad9) Then
                            'digit from keypad?
                            'text = txtBox.Text.Trim & CChar(CChar(CStr(e.KeyValue)))
                            'If we insert a number between two numbers
                            text = txtBox.Text.Trim.Insert(txtBox.SelectionStart, CChar(CChar(CStr(e.KeyValue))))
                        End If

                        is2Decimal = re2DecimalPlaces.IsMatch(text)

                End Select
            Else
                is2Decimal = False
                Return
            End If

        Else
            is2Decimal = True
        End If

    End Sub

    Private Sub PKOProductionLogFrm_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If chkPKOLogDate.Checked = False Then
            DisplayInfoMessage("Msg71")
            ''MsgBox("Please Enter Criteria to Search!")
            BindDataGrid()
            Exit Sub
        Else
            BindDataGrid()
            If dgvPKOProductionLogView.RowCount = 0 Then
                DisplayInfoMessage("Msg72")
                ''MsgBox("No record(s) found matching your search criteria.")
            End If
        End If
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        tcPKOroductionLog.SelectedIndex = 0
        tcPKOLog.SelectedIndex = 0
    End Sub
    Private Sub UpdatePKOProductionLog()
        If dgvPKOProductionLogView.Rows.Count > 0 Then

            tcPKOroductionLog.SelectedIndex = 0
            tcPKOLog.SelectedIndex = 0
            dtPKOProductionDate.Enabled = False
            lbtnsaveall = "Update All"


            If GlobalPPT.strLang = "en" Then
                btnSaveAll.Text = "UpdateAll"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnSaveAll.Text = "Update Semua"
            End If
            If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
                If EditToolStripMenuItem.Enabled = True Then
                    btnSaveAll.Enabled = True
                End If
            End If

            ''btnSaveAll.Text = "Update All"
            lPrevHrs = "00:00"
            lPrevmechHrs = "00:00"
            lPrevElecHrs = "00:00"
            lPrevProcessHrs = "00:00"


            lPKOProductionLogID = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclPKOProductionLogID").Value.ToString
            lPrevLossonKernel = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclLossOfKernel").Value.ToString


            dtPKOProductionDate.Value = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString
            lPrevHrs = Me.dgvPKOProductionLogView.SelectedRows(0).Cells("dgclTotalHours").Value
            lkernelPrevQty = dgvPKOProductionLogView.SelectedRows(0).Cells("KernelProcessedACT").Value.ToString
            txtLossOnKernelToday.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclLossOfKernel").Value.ToString

            GetProductionLogShifts()
            GetPKOLogKernelReceived()
            GetTotalReceivedQtyKerRec()
            GetPKOLogPress()
            TotalHourShiftsKernelProcessedCalculation()
            lPrevmechHrs = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclMechanicalBD").Value.ToString
            lPrevElecHrs = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclElectricalBD").Value.ToString
            lPrevProcessHrs = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProcessingBD").Value.ToString

            txtMechanicalBreakDownToday.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclMechanicalBD").Value.ToString
            txtElectricalBreakDownToday.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclElectricalBD").Value.ToString
            txtProcessingBreakDownToday.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProcessingBD").Value.ToString
            txtTotalBreakDownToday.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclTotalBD").Value.ToString
            txtEffectiveProcessingHoursToday.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclEffectiveProcessingHours").Value.ToString

            txtLossOnKernelMonth.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclLossOfKernelMTD").Value.ToString
            txtMechanicalBreakDownMonth.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclMechanicalBDMTD").Value.ToString
            txtElectricalBreakDownMonth.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclElectricalBDMTD").Value.ToString
            txtProcessingBreakDownMonth.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProcessingBDMTD").Value.ToString

            txtLossOnKernelYear.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclLossOfKernelYTD").Value.ToString
            txtMechanicalBreakDownYear.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclMechanicalBDYTD").Value.ToString
            txtElectricalBreakDownYear.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclElectricalBDYTD").Value.ToString
            txtProcessingBreakDownYear.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProcessingBDYTD").Value.ToString



            'If txtLossOnKernelMonth.Enabled = False Then
            '    If Val(txtLossOnKernelToday.Text) > 0 Then
            '        txtLossOnKernelMonth.Text = lLossOnKernelMonth + Val(txtLossOnKernelToday.Text)
            '        txtLossOnKernelYear.Text = lLossOnKernelYear + Val(txtLossOnKernelToday.Text)
            '    Else
            '        txtLossOnKernelMonth.Text = lLossOnKernelMonth
            '        txtLossOnKernelYear.Text = lLossOnKernelYear
            '    End If
            'End If

            'If txtMechanicalBreakDownToday.Text <> "" And txtMechanicalBreakDownToday.Text <> "00:00" Then
            '    txtMechanicalBreakDownMonth.Text = ToaddHours(lMechanicalBreakDownMonth, txtMechanicalBreakDownToday.Text)
            '    txtMechanicalBreakDownYear.Text = ToaddHours(lMechanicalBreakDownMonth, txtMechanicalBreakDownToday.Text)
            'Else
            '    txtMechanicalBreakDownMonth.Text = lMechanicalBreakDownMonth
            '    txtMechanicalBreakDownYear.Text = lMechanicalBreakDownYear
            'End If

            'If txtElectricalBreakDownToday.Text <> "" And txtElectricalBreakDownToday.Text <> "00:00" Then
            '    txtElectricalBreakDownMonth.Text = ToaddHours(lElectricalBreakDownMonth, txtElectricalBreakDownToday.Text)
            '    txtElectricalBreakDownYear.Text = ToaddHours(lElectricalBreakDownMonth, txtElectricalBreakDownToday.Text)
            'Else
            '    txtElectricalBreakDownMonth.Text = lElectricalBreakDownMonth
            '    txtElectricalBreakDownYear.Text = lElectricalBreakDownYear
            'End If

            'If txtProcessingBreakDownToday.Text <> "" And txtProcessingBreakDownToday.Text <> "00:00" Then
            '    txtProcessingBreakDownMonth.Text = ToaddHours(lProcessingBreakDownMonth, txtProcessingBreakDownToday.Text)
            '    txtProcessingBreakDownYear.Text = ToaddHours(lProcessingBreakDownMonth, txtProcessingBreakDownToday.Text)
            'Else
            '    txtProcessingBreakDownMonth.Text = lProcessingBreakDownMonth
            '    txtProcessingBreakDownYear.Text = lProcessingBreakDownYear
            'End If

            'If txtTotalBreakDownToday.Text <> "" And txtTotalBreakDownToday.Text <> "00:00" Then
            '    txtTotalBreakDownMonth.Text = ToaddHours(lTotalBreakDownMonth, txtTotalBreakDownToday.Text)
            '    txtTotalBreakDownToday.Text = ToaddHours(lTotalBreakDownMonth, txtTotalBreakDownToday.Text)
            'Else
            '    txtTotalBreakDownMonth.Text = lTotalBreakDownMonth
            '    txtTotalBreakDownYear.Text = lTotalBreakDownYear
            'End If

            'If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then
            '    txtEffectiveProcessingHoursMonth.Text = ToaddHours(lEffectiveProcessingHoursMonth, txtEffectiveProcessingHoursToday.Text)
            '    txtEffectiveProcessingHoursYear.Text = ToaddHours(lEffectiveProcessingHoursMonth, txtEffectiveProcessingHoursToday.Text)
            'Else
            '    txtEffectiveProcessingHoursMonth.Text = lEffectiveProcessingHoursMonth
            '    txtEffectiveProcessingHoursYear.Text = lEffectiveProcessingHoursYear
            'End If
            Dim lEffectiveHrsDec As Decimal
            If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then

                Dim Hrs1 As Integer
                Dim Min1 As Integer
                Dim str3 As String
                Dim strArr3() As String
                'Dim count As Integer
                str3 = txtEffectiveProcessingHoursToday.Text
                strArr3 = str3.Split(":")
                Hrs1 = CInt(strArr3(0))
                Min1 = CInt(strArr3(1))

                Min1 = (Min1 / 60) * 100
                Dim lmin1 As String
                lmin1 = "." + Convert.ToString(Min1)

                lEffectiveHrsDec = Hrs1 + lmin1


            End If
            If Val(txtKerneltoday.Text) <> 0 And lEffectiveHrsDec > 0 Then
                txtThroughput.Text = Math.Round((Val(txtKerneltoday.Text) / lEffectiveHrsDec), 2)
            Else
                txtThroughput.Text = ""
            End If

            txtLogRemarks.Text = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclRemarks").Value.ToString

            TPH()

            summCalcMonthStage1()
            summCalcMonthStage2()
            SummCalcstage1Year()
            SummCalcstage2Year()

            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            Dim ds As New DataTable

            With objPKOProductionLogPPT
                .lProductionLogDate = "01/01/1900"
            End With

            ds = PKOProductionLogBOL.GetPKOProductionLog(objPKOProductionLogPPT)


            If dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString <> ds.Rows(0).Item("productionLogDate") Then
                btnSaveAll.Enabled = False
                btnDeleteAll.Enabled = False
                '  DisplayInfoMessage("msg177")
                DisplayInfoMessage("msg176")
            End If




        Else
            DisplayInfoMessage("Msg73")
            ''MessageBox.Show(" No Record to Edit", " Please Select a Record to Edit", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub
    Private Sub GetProductionLogShifts()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionBOL


        objPKOProductionLogPPT.PKOProductionLogID = lPKOProductionLogID

        Dim ds As New DataSet

        ds = PKOProductionLogBOL.GetPKOProductionLogShiftSelect(objPKOProductionLogPPT)

        If ds.Tables(0).Rows.Count <> 0 And ds IsNot Nothing Then

            Dim lTableCount As Integer = 0

            If ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 3
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString = String.Empty Then
                lTableCount = 2
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 2
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString = String.Empty Then
                lTableCount = 1
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 2
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString = String.Empty Then
                lTableCount = 1
            ElseIf ds.Tables(0).Rows(0).Item("Shift1").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift2").ToString = String.Empty And ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                lTableCount = 1
            End If


            Dim lintrowcount As Integer = 0
            Dim lShift1String, lShift2String, lShift3String As String
            lShift1String = "False"
            lShift2String = "False"
            lShift3String = "False"


            While (lTableCount > 0)

                Dim intRowcount As Integer = dtPKOShiftAdd.Rows.Count


                rowPKOShiftAdd = dtPKOShiftAdd.NewRow()

                If lintrowcount = 0 Then

                    Try
                        columnPKOShiftAdd = New DataColumn("Shift", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("Assistant", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("Mandore", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("StartTime", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("StopTime", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("ShiftHours", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("KernelProcessed", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)

                    Catch ex As Exception

                    End Try

                    If ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty Then

                        rowPKOShiftAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift1").ToString
                        rowPKOShiftAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID1").ToString
                        rowPKOShiftAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID1").ToString
                        rowPKOShiftAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        rowPKOShiftAdd("StopTime") = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            'For Hours

                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShifthours = strTotalhrs + ":" + strTotalMins
                        rowPKOShiftAdd("ShiftHours") = lShifthours

                        rowPKOShiftAdd("KernelProcessed") = ds.Tables(0).Rows(0).Item("KernelProcessedEST1").ToString
                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        lShift1String = "True"
                    ElseIf ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty Then
                        rowPKOShiftAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift2").ToString
                        rowPKOShiftAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID2").ToString
                        rowPKOShiftAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID2").ToString
                        rowPKOShiftAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        rowPKOShiftAdd("StopTime") = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            'For Hours

                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShifthours = strTotalhrs + ":" + strTotalMins
                        rowPKOShiftAdd("ShiftHours") = lShifthours
                        rowPKOShiftAdd("KernelProcessed") = ds.Tables(0).Rows(0).Item("KernelProcessedEST2").ToString
                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        lShift2String = "True"

                    ElseIf ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty Then
                        rowPKOShiftAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift3").ToString
                        rowPKOShiftAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID3").ToString
                        rowPKOShiftAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID3").ToString
                        rowPKOShiftAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        rowPKOShiftAdd("StopTime") = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShifthours = strTotalhrs + ":" + strTotalMins
                        rowPKOShiftAdd("ShiftHours") = lShifthours
                        rowPKOShiftAdd("KernelProcessed") = ds.Tables(0).Rows(0).Item("KernelProcessedEST3").ToString
                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        lShift3String = "True"
                    End If

                Else

                    If ds.Tables(0).Rows(0).Item("Shift1").ToString <> String.Empty And lShift1String <> "True" Then
                        rowPKOShiftAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift1").ToString
                        rowPKOShiftAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID1").ToString
                        rowPKOShiftAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID1").ToString
                        rowPKOShiftAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        rowPKOShiftAdd("StopTime") = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime1").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime1").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShifthours = strTotalhrs + ":" + strTotalMins
                        rowPKOShiftAdd("ShiftHours") = lShifthours

                        rowPKOShiftAdd("KernelProcessed") = ds.Tables(0).Rows(0).Item("KernelProcessedEST1").ToString
                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        lShift1String = "True"



                    ElseIf ds.Tables(0).Rows(0).Item("Shift2").ToString <> String.Empty And lShift2String <> "True" Then
                        rowPKOShiftAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift2").ToString
                        rowPKOShiftAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID2").ToString
                        rowPKOShiftAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID2").ToString
                        rowPKOShiftAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        rowPKOShiftAdd("StopTime") = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime2").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime2").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"
                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShifthours = strTotalhrs + ":" + strTotalMins
                        rowPKOShiftAdd("ShiftHours") = lShifthours

                        rowPKOShiftAdd("KernelProcessed") = ds.Tables(0).Rows(0).Item("KernelProcessedEST2").ToString
                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        lShift2String = "True"


                    ElseIf ds.Tables(0).Rows(0).Item("Shift3").ToString <> String.Empty And lShift3String <> "True" Then
                        rowPKOShiftAdd("Shift") = ds.Tables(0).Rows(0).Item("Shift3").ToString
                        rowPKOShiftAdd("Assistant") = ds.Tables(0).Rows(0).Item("AssistantEmpID3").ToString
                        rowPKOShiftAdd("Mandore") = ds.Tables(0).Rows(0).Item("MandoreEmpID3").ToString
                        rowPKOShiftAdd("StartTime") = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        rowPKOShiftAdd("StopTime") = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        Dim lShiftStartTime, lShiftStopTime As String
                        lShiftStartTime = ds.Tables(0).Rows(0).Item("StartTime3").ToString
                        lShiftStopTime = ds.Tables(0).Rows(0).Item("EndTime3").ToString
                        lShiftStartTime = lShiftStartTime.Replace("#", "")
                        lShiftStopTime = lShiftStopTime.Replace("#", "")

                        Dim strArr4(), strArr3() As String
                        Dim Str4, Str3 As String
                        Str4 = lShiftStopTime
                        strArr4 = Str4.Split(":")
                        Str3 = lShiftStartTime
                        strArr3 = Str3.Split(":")
                        Dim strTotalMins As String = 0
                        Dim strTotalhrs As String = String.Empty

                        If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                            strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                            If strTotalhrs < 0 Then
                                strTotalhrs = Val(strTotalhrs) + 24
                            End If
                        ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                            strTotalhrs = "24"
                        Else
                            strTotalhrs = "0"

                        End If

                        If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                            'For Mins
                            strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                            If Val(strTotalMins) < 0 Then
                                strTotalMins = Val(strTotalMins) + 60
                                strTotalhrs = Val(strTotalhrs) - 1
                            End If
                        Else
                            strTotalMins = "0"
                        End If


                        If Val(strTotalhrs) < 10 Then
                            strTotalhrs = "0" + strTotalhrs
                        End If
                        If Val(strTotalMins) < 10 Then
                            strTotalMins = "0" + strTotalMins
                        End If

                        ' If strTotalhrs <> Nothing Then
                        lShifthours = strTotalhrs + ":" + strTotalMins
                        rowPKOShiftAdd("ShiftHours") = lShifthours

                        rowPKOShiftAdd("KernelProcessed") = ds.Tables(0).Rows(0).Item("KernelProcessedEST3").ToString
                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        lShift3String = "True"
                    End If

                End If
                lintrowcount = lintrowcount + 1
                lTableCount = lTableCount - 1
            End While

            'txtKernelProcessedToday.Text = ds.Tables(0).Rows(0).Item("KernelProcessedEST1").ToString + ds.Tables(0).Rows(0).Item("KernelProcessedEST2").ToString + ds.Tables(0).Rows(0).Item("KernelProcessedEST3").ToString

            lbtnAddShift = "Add"

            With dgvPKOLogShiftDetails

                .AutoGenerateColumns = False
                .DataSource = dtPKOShiftAdd
                TotalHourShiftsKernelProcessedCalculation()

            End With

        End If

    End Sub

    Private Sub GetPKOLogKernelReceived()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionBOL

        objPKOProductionLogPPT.PKOProductionLogID = lPKOProductionLogID

        Dim dt As New DataTable

        dt = PKOProductionLogBOL.GetPKOProductionLogKerReceived(objPKOProductionLogPPT)

        If dt.Rows.Count <> 0 And dt IsNot Nothing Then
            dgvReceivedKernel.DataSource = dt
            dtKerRecd = dt
            dgvReceivedKernel.AutoGenerateColumns = False
        End If
    End Sub

    Private Sub GetPKOLogPress()

        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionBOL

        objPKOProductionLogPPT.PKOProductionLogID = lPKOProductionLogID

        Dim dt As New DataTable

        dt = PKOProductionLogBOL.GetPKOProductionLogPress(objPKOProductionLogPPT)

        If dt.Rows.Count <> 0 And dt IsNot Nothing Then
            dgPressInfo.DataSource = dt
            dtPressInfo = dt
            dgPressInfo.AutoGenerateColumns = False
        End If
    End Sub



    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        UpdatePKOProductionLog()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click

        If dgvPKOProductionLogView.RowCount > 0 Then


            Dim objPKOProductionLogPPT As New PKOProductionLogPPT
            Dim objPKOProductionLogBOL As New PKOProductionLogBOL
            Dim ds As New DataTable

            With objPKOProductionLogPPT
                .lProductionLogDate = "01/01/1900"
            End With

            ds = PKOProductionLogBOL.GetPKOProductionLog(objPKOProductionLogPPT)


            If dgvPKOProductionLogView.SelectedRows(0).Cells("dgclProductionlogDate").Value.ToString = ds.Rows(0).Item("productionLogDate") Then

                'Dim objPKOProductionLogPPT As New PKOProductionLogPPT
                'Dim objPKOProductionLogBOL As New PKOProductionLogBOL
                '  Dim dt As New DataTable
                If dgvPKOProductionLogView.Rows.Count > 0 Then
                    If MsgBox(rm.GetString("Msg74"), MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                        '' If MsgBox("You are about to Delete the selected record. Are you sure? If yes please click ""OK"" or click ""Cancel"".", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then	 lPKOProductionLogID = Me.dgvPKOProductionLogView.SelectedRows(0).Cells("dgclPKOProductionLogID").Value.ToString()
                        With objPKOProductionLogPPT
                            .PKOProductionLogID = dgvPKOProductionLogView.SelectedRows(0).Cells("dgclPKOProductionLogID").Value.ToString
                        End With
                        objPKOProductionLogBOL.DeleteProductionPKOLog(objPKOProductionLogPPT)
                        BindDataGrid()
                        DisplayInfoMessage("Msg75")
                        ''MsgBox("Data Successfully Deleted!")
                    End If
                Else
                    DisplayInfoMessage("Msg76")
                    ''MessageBox.Show(" No Record to Delete", " Please Select a Record to delete", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                DisplayInfoMessage("msg177")
                '  DisplayInfoMessage("msg176")
            End If
        End If

    End Sub

    Private Sub dgvPKOProductionLogView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKOProductionLogView.CellDoubleClick

        If objUserLoginBOl.Privilege(btnSaveAll, AddToolStripMenuItem, EditToolStripMenuItem, DeleteToolStripMenuItem, PrivilegeError) Then
            If EditToolStripMenuItem.Enabled = True Then
                UpdatePKOProductionLog()
            End If
        End If

    End Sub

    Private Sub dtPKOProductionDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtPKOProductionDate.ValueChanged

        GetPKOProductionTodayValues()

        GetKernelStorageBFValue()
        'GetMonthVaues()
        'GetYearVaues()
        'GetTodayVaues()
        GetPKOProductionLogPressOPHrsValue()
        GetTPHMonth()
        GetTPHYear()
        CPOGetMonthYearQtySumm("Stage 1")
        CPOGetMonthYearQtySumm("Stage 2")

    End Sub

    Private Sub txtKernelProcessed_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessed.TextChanged
        'If txtKernelProcessed.Text <> String.Empty Then
        '    txtKerneltoday.Text = txtKernelProcessed.Text
        '    txtKernelProcessedToday.Text = txtKernelProcessed.Text
        'Else
        '    txtKerneltoday.Text = 0
        '    txtKernelProcessedToday.Text = 0
        'End If
    End Sub
    Private Sub PKOGetMonthYearQty()

        Dim objPKOLogPPT As New PKOProductionLogPPT
        Dim dsProdQty As DataSet
        objPKOLogPPT.ProductionLogDate = dtPKOProductionDate.Value
        dsProdQty = PKOProductionLogBOL.PKOGetMonthYearQty(objPKOLogPPT)



        If dsProdQty.Tables(6).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs") Is DBNull.Value Then
                lmonthValuehrs = dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs")
                lmonthValuehrs = ToModifyTime(lmonthValuehrs)
            End If
        End If
        If dsProdQty.Tables(13).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs") Is DBNull.Value Then
                lYearValue = dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs")
                lYearValue = ToModifyTime(lYearValue)
            End If
        End If

        MonthCount = dsProdQty.Tables(14).Rows(0).Item("MonthCountHrs")
        YearCount = dsProdQty.Tables(15).Rows(0).Item("YearCountHrs")

        If MonthCount = 0 Or (MonthCount = 1 And lbtnsaveall <> "Save All") Then
            txtMonthTodateHrs.Enabled = True
            txtLossOnKernelMonth.Enabled = True
            txtElectricalBreakDownMonth.Enabled = True
            txtMechanicalBreakDownMonth.Enabled = True
            txtProcessingBreakDownMonth.Enabled = True

            txtLossOnKernelYear.Enabled = True
            txtElectricalBreakDownYear.Enabled = True
            txtMechanicalBreakDownYear.Enabled = True
            txtProcessingBreakDownYear.Enabled = True

        Else
            txtMonthTodateHrs.Enabled = False
            txtLossOnKernelMonth.Enabled = False
            txtElectricalBreakDownMonth.Enabled = False
            txtMechanicalBreakDownMonth.Enabled = False
            txtProcessingBreakDownMonth.Enabled = False

            txtLossOnKernelYear.Enabled = False
            txtElectricalBreakDownYear.Enabled = False
            txtMechanicalBreakDownYear.Enabled = False
            txtProcessingBreakDownYear.Enabled = False
        End If

        If YearCount = 0 Or (YearCount = 1 And lbtnsaveall <> "Save All") Then
            txtYearTodateHrs.Enabled = True
        Else
            txtYearTodateHrs.Enabled = False

        End If

    End Sub
    Private Sub txtTotalHours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalHours.TextChanged
        If txtTotalHours.Text <> "" Then
            PKOGetMonthYearQty()

            If lShifthours <> "00:00" And lmonthValuehrs <> "00:00" And MonthCount > 1 And lbtnsaveall = "Save All" Then
                txtMonthTodateHrs.Text = ToaddHours(lShifthours, lmonthValuehrs)
            ElseIf lShifthours <> "00:00" And lmonthValuehrs <> "00:00" And MonthCount > 1 And lbtnsaveall <> "Save All" Then
                txtMonthTodateHrs.Text = ToaddHours(lShifthours, lmonthValuehrs)
            ElseIf lmonthValuehrs <> "00:00" And MonthCount = 1 And lbtnsaveall <> "Save All" Then
                txtMonthTodateHrs.Text = lmonthValuehrs
                txtMonthTodateHrs.Enabled = True
            ElseIf lmonthValuehrs <> "00:00" And MonthCount = 1 And lbtnsaveall = "Save All" Then
                txtMonthTodateHrs.Text = ToaddHours(lShifthours, lmonthValuehrs)
                txtMonthTodateHrs.Enabled = False
            ElseIf lmonthValuehrs = "00:00" And MonthCount >= 1 Then
                txtMonthTodateHrs.Text = lShifthours
                txtMonthTodateHrs.Enabled = False
            Else
                txtMonthTodateHrs.Text = ""
                txtMonthTodateHrs.Enabled = True
            End If

            If lShifthours <> "00:00" And lYearValue <> "00:00" And YearCount > 1 And lbtnsaveall = "Save All" Then
                txtYearTodateHrs.Text = ToaddHours(lShifthours, lYearValue)
            ElseIf lShifthours <> "00:00" And lYearValue <> "00:00" And YearCount > 1 And lbtnsaveall <> "Save All" Then
                txtYearTodateHrs.Text = ToaddHours(lShifthours, lYearValue)
            ElseIf lYearValue <> "00:00" And YearCount = 1 And lbtnsaveall <> "Save All" Then
                txtYearTodateHrs.Text = lYearValue
                txtYearTodateHrs.Enabled = True
            ElseIf lYearValue <> "00:00" And YearCount = 1 And lbtnsaveall = "Save All" Then
                txtYearTodateHrs.Text = ToaddHours(lShifthours, lYearValue)
                txtYearTodateHrs.Enabled = False
            ElseIf lYearValue = "00:00" And YearCount >= 1 Then
                txtYearTodateHrs.Text = lShifthours
                txtYearTodateHrs.Enabled = False
            Else
                txtYearTodateHrs.Text = ""
                txtYearTodateHrs.Enabled = True
            End If

            If txtMechanicalBreakDownToday.Text = "" And txtElectricalBreakDownToday.Text = "" And txtProcessingBreakDownToday.Text = "" Then
                txtEffectiveProcessingHoursToday.Text = txtTotalHours.Text
            End If

        End If





    End Sub

    Private Function LoadingLocationExist(ByVal LoadingLocation As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvReceivedKernel.Rows
                If LoadingLocation = objDataGridViewRow.Cells("dgMeLoadingLocation").Value.ToString() Then
                    ddlLoadingLocationKerRecd.SelectedIndex = 0
                    ddlLoadingLocationKerRecd.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Function StageExist(ByVal Stage As String, ByVal PressNo As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgPressInfo.Rows
                If Stage = objDataGridViewRow.Cells("dgMeStage").Value.ToString() And PressNo = objDataGridViewRow.Cells("dgMeMachineID").Value.ToString() Then
                    ddlStage.SelectedIndex = 0
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub chkPKOLogDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPKOLogDate.CheckedChanged

        If chkPKOLogDate.Checked = True Then
            dtpPKOProdLogDateSearch.Enabled = True
        Else
            dtpPKOProdLogDateSearch.Enabled = False
        End If

    End Sub

    Private Sub dgvPKOProductionLogView_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvPKOProductionLogView.KeyDown
        If e.KeyCode = 13 Then
            UpdatePKOProductionLog()
        End If
    End Sub

    Private Sub btnAddShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddShift.Click

        If ddlShift.Text = "--Select--" Then
            DisplayInfoMessage("Msg77")
            '' MessageBox.Show("This Field is Required ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ddlShift.Focus()
            Exit Sub
        End If
        If txtStartTime.Text = "" Then
            DisplayInfoMessage("Msg188")
            ''MessageBox.Show("This field is required", "Lorry Processed")
            txtStartTime.Focus()
            Exit Sub
        End If
        If txtStopTime.Text = "" Then
            DisplayInfoMessage("Msg187")
            ''MessageBox.Show("This field is required", "FFB Processed")
            txtStopTime.Focus()
            Exit Sub
        End If


        If Val(txtKernelProcessed.Text) < 0 Then
            DisplayInfoMessage("Msg78")
            '' MessageBox.Show("This Field is Required", "Kernel Processed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKernelProcessed.Focus()
            Exit Sub
        End If


        Dim strArr7() As String
        Dim str7 As String
        str7 = txtStartTime.Text
        strArr7 = str7.Split(":")
        If CInt(strArr7(0)) >= 24 Then
            DisplayInfoMessage("Msg179")
            txtStartTime.Focus()
            Exit Sub
        End If

        str7 = txtStopTime.Text
        strArr7 = str7.Split(":")
        If CInt(strArr7(0)) >= 24 Then
            DisplayInfoMessage("Msg180")
            txtStartTime.Focus()
            Exit Sub
        End If

        If txtShiftHours.Text <> "" Then
            Dim strArr() As String
            Dim str As String
            str = txtShiftHours.Text
            strArr = str.Split(":")

            If CInt(strArr(0)) > 24 Or (CInt(strArr(0)) = 24 And CInt(strArr(1)) <> 0) Then
                DisplayInfoMessage("Msg178")
                txtStopTime.Focus()
                Exit Sub
            End If
        End If



        Dim lShiftHours As String = "00:00"
        lShiftHours = txtShiftHours.Text

        If dgvPKOLogShiftDetails.Rows.Count <> 0 And lbtnAddShift <> "Update" Then
            For Each objDataGridViewRow In dgvPKOLogShiftDetails.Rows
                If objDataGridViewRow.Cells("dgShifthours").Value.ToString <> String.Empty Then
                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("dgShifthours").Value.ToString()
                    lShiftHours = lShiftHours

                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String
                    Str = lShiftHours
                    strArr = Str.Split(":")
                    Str1 = lCominValue
                    strArr1 = Str1.Split(":")
                    Dim Lhrs, lmin As Integer


                    Lhrs = CInt(strArr(0)) + CInt(strArr1(0))

                    lmin = CInt(strArr(1)) + CInt(strArr1(1))


                    If Lhrs > 24 Then
                        DisplayInfoMessage("Msg80")
                        ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                        Exit Sub
                    ElseIf Lhrs = 24 And lmin > 0 Then
                        DisplayInfoMessage("Msg80")
                        ''MsgBox("Process Hrs Cant be greater than 24 hrs ")
                        Exit Sub
                    Else
                        If lmin >= 60 Then
                            lmin = lmin - 60
                            Lhrs = Lhrs + 1
                        End If
                        Dim Strhrs As String = "00"
                        Dim StrMin As String = "00"

                        If Lhrs < 10 Then
                            Strhrs = "0" + Convert.ToString(Lhrs)
                        Else
                            Strhrs = Lhrs
                        End If

                        If lmin < 10 Then
                            StrMin = "0" + Convert.ToString(lmin)
                        Else
                            StrMin = lmin
                        End If
                        lShiftHours = Strhrs + ":" + StrMin
                    End If
                End If
            Next
        ElseIf lbtnAddShift <> "Add" Then
            For Each objDataGridViewRow In dgvPKOLogShiftDetails.Rows
                If objDataGridViewRow.Cells("dgShifthours").Value.ToString <> String.Empty Then
                    Dim lCominValue As String
                    lCominValue = objDataGridViewRow.Cells("dgShifthours").Value.ToString()
                    lShiftHours = lShiftHours

                    'Dim ProcessHrs As String
                    Dim strArr(), strArr1() As String
                    Dim Str, Str1 As String

                    Str = lShiftHours
                    strArr = Str.Split(":")
                    Str1 = lCominValue
                    strArr1 = Str1.Split(":")

                    Dim Lhrs, lmin As Integer
                    Lhrs = CInt(strArr(0)) + CInt(strArr1(0))
                    lmin = CInt(strArr(1)) + CInt(strArr1(1))

                    If lmin >= 60 Then
                        lmin = lmin - 60
                        Lhrs = Lhrs + 1
                    End If
                    Dim Strhrs As String = "00"
                    Dim StrMin As String = "00"

                    If Lhrs < 10 Then
                        Strhrs = "0" + Convert.ToString(Lhrs)
                    Else
                        Strhrs = Lhrs
                    End If

                    If lmin < 10 Then
                        StrMin = "0" + Convert.ToString(lmin)
                    Else
                        StrMin = lmin
                    End If
                    lShiftHours = Strhrs + ":" + StrMin
                End If

            Next

            Dim strArr2(), strArr3() As String
            Dim Str2, Str3 As String
            Str2 = lShiftHours
            strArr2 = Str2.Split(":")
            Str3 = dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShifthours").Value.ToString
            strArr3 = Str3.Split(":")

            Dim Lhrs1, lmin1 As Integer

            Lhrs1 = strArr2(0) - strArr3(0)

            If strArr3(1) > strArr2(1) Then
                lmin1 = strArr3(1) - strArr2(1)
                Lhrs1 = Lhrs1 - 1
            ElseIf strArr3(1) < strArr2(1) Then
                lmin1 = strArr2(1) - strArr3(1)
            End If
            Dim Strhrs1 As String = "00"
            Dim StrMin1 As String = "00"

            If Lhrs1 > 24 Then
                DisplayInfoMessage("Msg81")
                ''MsgBox("Shift Hrs Cant be greater than 24 hrs ")
                Exit Sub
            ElseIf Lhrs1 = 24 And lmin1 > 0 Then
                DisplayInfoMessage("Msg81")
                ''MsgBox("Shift Hrs Cant be greater than 24 hrs ")
                Exit Sub
            Else
                If Lhrs1 < 10 Then
                    Strhrs1 = "0" + Convert.ToString(Lhrs1)
                Else
                    Strhrs1 = Lhrs1
                End If

                If lmin1 < 10 Then
                    StrMin1 = "0" + Convert.ToString(lmin1)
                Else
                    StrMin1 = lmin1
                End If

                lShiftHours = Strhrs1 + ":" + StrMin1
            End If
        Else
            lShiftHours = "00:00"

        End If


        If lbtnAddShift <> "Update" Then
            AddShiftMultipleEntry()
            TotalHourShiftsKernelProcessedCalculation()

        Else
            UpdateShiftMultipleEntry()
            TotalHourShiftsKernelProcessedCalculation()

        End If



    End Sub



    Private Sub AddShiftMultipleEntry()
        Try
            Dim objPKOLogPPT As New PKOProductionLogPPT
            Dim objPKOLogBOL As New PKOProductionLogBOL
            Dim intRowcount As Integer = dtPKOShiftAdd.Rows.Count

            'lHrsStartTime = cmbStartHours.Text
            'lminStartTime = cmbStartMin.Text
            'lHrsStopTime = cmbStopHours.Text
            'lminStopTime = cmbStopMin.Text

            Dim lStartTime As String
            Dim lStopTime As String
            lStartTime = txtStartTime.Text
            lStopTime = txtStopTime.Text


            If Not ShiftExist(ddlShift.Text) Then
                rowPKOShiftAdd = dtPKOShiftAdd.NewRow()

                If intRowcount = 0 And lbtnAddShift = "Add" Then
                    Try

                        columnPKOShiftAdd = New DataColumn("Shift", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("Assistant", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("Mandore", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("StartTime", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("StopTime", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("ShiftHours", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)
                        columnPKOShiftAdd = New DataColumn("KernelProcessed", System.Type.[GetType]("System.String"))
                        dtPKOShiftAdd.Columns.Add(columnPKOShiftAdd)

                        rowPKOShiftAdd("Shift") = Me.ddlShift.Text
                        rowPKOShiftAdd("Assistant") = Me.txtAssistant.Text
                        rowPKOShiftAdd("Mandore") = Me.txtMandor.Text
                        rowPKOShiftAdd("StartTime") = lStartTime
                        rowPKOShiftAdd("StopTime") = lStopTime
                        rowPKOShiftAdd("ShiftHours") = txtShiftHours.Text
                        rowPKOShiftAdd("KernelProcessed") = Me.txtKernelProcessed.Text

                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        ClearShift()
                        Datefunction()
                    Catch ex As Exception
                        rowPKOShiftAdd("Shift") = Me.ddlShift.Text
                        rowPKOShiftAdd("Assistant") = Me.txtAssistant.Text
                        rowPKOShiftAdd("Mandore") = Me.txtMandor.Text
                        rowPKOShiftAdd("StartTime") = lStartTime
                        rowPKOShiftAdd("StopTime") = lStopTime
                        rowPKOShiftAdd("ShiftHours") = txtShiftHours.Text
                        rowPKOShiftAdd("KernelProcessed") = Me.txtKernelProcessed.Text

                        dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                        ClearShift()
                        Datefunction()
                    End Try

                Else

                    rowPKOShiftAdd("Shift") = Me.ddlShift.Text
                    rowPKOShiftAdd("Assistant") = Me.txtAssistant.Text
                    rowPKOShiftAdd("Mandore") = Me.txtMandor.Text
                    rowPKOShiftAdd("StartTime") = lStartTime
                    rowPKOShiftAdd("StopTime") = lStopTime
                    rowPKOShiftAdd("ShiftHours") = txtShiftHours.Text
                    rowPKOShiftAdd("KernelProcessed") = Me.txtKernelProcessed.Text

                    dtPKOShiftAdd.Rows.InsertAt(rowPKOShiftAdd, intRowcount)
                    ClearShift()
                    Datefunction()
                End If

                lbtnAddShift = "Add"

                With dgvPKOLogShiftDetails
                    .AutoGenerateColumns = False
                    .DataSource = dtPKOShiftAdd

                End With
            Else
                DisplayInfoMessage("Msg82")
                ''MsgBox("Shift  already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
                ddlShift.Focus()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateShiftMultipleEntry()

        ' Dim intRowcount As Integer = dgvCPO.Rows.Count
        Dim objDispatchPPT As New DispatchPPT
        Dim ObjDispatchBOL As New DispatchBOL

        Try


            Dim objPKOLogPPT As New PKOProductionLogPPT
            Dim objPKOLogBOL As New PKOProductionLogBOL
            Dim intRowcount As Integer = dtPKOShiftAdd.Rows.Count

            'lHrsStartTime = cmbStartHours.Text
            'lminStartTime = cmbStartMin.Text

            'lHrsStopTime = cmbStopHours.Text
            'lminStopTime = cmbStopMin.Text
            Dim lStartTime As String
            Dim lStopTime As String
            lStartTime = txtStartTime.Text
            lStopTime = txtStopTime.Text

            'If lStartTime = lStopTime Then
            '    MsgBox("Start Time and Stop Time cannot be equal, Please the change the Time")
            '    Exit Sub
            'End If

            If lshift = ddlShift.Text Then
                Dim intCount As Integer = dgvPKOLogShiftDetails.CurrentRow.Index
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShift").Value = ddlShift.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftAssistant").Value = txtAssistant.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftMandore").Value = txtMandor.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftStarttime").Value = lStartTime
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftStopTime").Value = lStopTime
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftHours").Value = txtShiftHours.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftKernelProcessed").Value = txtKernelProcessed.Text

                ClearShift()
                Datefunction()
            ElseIf Not ShiftExist(ddlShift.Text) Then

                Dim intCount As Integer = dgvPKOLogShiftDetails.CurrentRow.Index
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShift").Value = ddlShift.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftAssistant").Value = txtAssistant.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftMandore").Value = txtMandor.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftStarttime").Value = lStartTime
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftStopTime").Value = lStopTime
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftHours").Value = txtShiftHours.Text
                dgvPKOLogShiftDetails.Rows(intCount).Cells("dgShiftKernelProcessed").Value = txtKernelProcessed.Text

                ClearShift()
                Datefunction()
            Else
                DisplayInfoMessage("Msg82")
                ''MsgBox("Shift already exist in the list", MsgBoxStyle.Critical, "BSP-Message")
                ddlShift.Focus()
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnResetShift_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetShift.Click
        ClearShift()
        Datefunction()
        ddlShift.Focus()

    End Sub

    Private Function ShiftExist(ByVal Shift As String) As Boolean
        Try
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In dgvPKOLogShiftDetails.Rows
                If Shift = objDataGridViewRow.Cells("dgShift").Value.ToString() Then
                    ddlLoadingLocationKerRecd.SelectedIndex = 0
                    ddlLoadingLocationKerRecd.Focus()
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message())
        End Try
    End Function

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        ClearLogExpress()
        ddlStage.Focus()
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        ClearLogExpress()
        MultipleDateEntryValuesPressInfo()
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        ClearReceivedKernelGB()
        ddlLoadingLocationKerRecd.Focus()
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        ClearReceivedKernelGB()
        MultipleDateEntryValuesRecdKernel()
    End Sub
    Private Sub MultipleDateEntryValuesShift()

        If dgvPKOLogShiftDetails.RowCount > 0 Then

            ClearShift()

            If GlobalPPT.strLang = "en" Then
                btnAddShift.Text = "Update"
            ElseIf GlobalPPT.strLang = "ms" Then
                btnAddShift.Text = "Memperbarui"
            End If
            ''btnAddShift.Text = "Update"
            lbtnAddShift = "Update"

            lshift = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShift").Value.ToString
            Me.ddlShift.Text = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShift").Value.ToString
            txtAssistant.Text = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShiftAssistant").Value.ToString
            txtMandor.Text = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShiftMandore").Value.ToString
            Dim lstartTime, lStoptime As String
            lstartTime = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShiftStartTime").Value.ToString
            lStoptime = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShiftStopTime").Value.ToString
            lstartTime = lstartTime.Replace("#", "")
            lstartTime = lstartTime.Substring(0, 5)
            txtStartTime.Text = lstartTime

            lStoptime = lStoptime.Replace("#", "")
            lStoptime = lStoptime.Substring(0, 5)
            txtStopTime.Text = lStoptime
            timeCalculation()

            Me.txtKernelProcessed.Text = Me.dgvPKOLogShiftDetails.SelectedRows(0).Cells("dgShiftKernelProcessed").Value.ToString

        End If

    End Sub
    Private Sub dgvPKOLogShiftDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPKOLogShiftDetails.CellDoubleClick
        ClearShift()
        MultipleDateEntryValuesShift()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        ClearShift()
        MultipleDateEntryValuesShift()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ClearShift()
        ddlShift.Focus()
    End Sub


    Private Sub txtMechanicalBreakDownToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMechanicalBreakDownToday.Leave
        If txtMechanicalBreakDownToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMechanicalBreakDownToday.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMechanicalBreakDownToday.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If Hrs > 24 Then
                DisplayInfoMessage("Msg83")
                ''MessageBox.Show("Breakdown Hrs cant be greater than  24")
                txtMechanicalBreakDownToday.Focus()
                Exit Sub
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMechanicalBreakDownToday.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMechanicalBreakDownToday.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMechanicalBreakDownToday.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMechanicalBreakDownToday.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMechanicalBreakDownToday.Text = Hrs + ":" + Min
        End If
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownToday.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownToday.Text
        End If
        If txtElectricalBreakDownToday.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownToday.Text
        End If
        If txtProcessingBreakDownToday.Text <> "" Then
            lProcessBK = txtProcessingBreakDownToday.Text
        End If


        lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If lBDCalculation <> "" Then
            Dim str As String
            Dim strArr() As String
            str = lBDCalculation
            strArr = str.Split(":")

            If strArr(0) > 24 Then
                DisplayInfoMessage("Msg83")
                ''MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
                txtMechanicalBreakDownToday.Focus()
                Exit Sub
            End If
        End If

        If (txtMechanicalBreakDownToday.Text <> "" Or txtElectricalBreakDownToday.Text <> "" Or txtProcessingBreakDownToday.Text <> "") Then
            txtTotalBreakDownToday.Text = lBDCalculation
        Else
            txtTotalBreakDownToday.Text = ""
        End If

        'If Val(txtTotalHours.Text) < Val(txtTotalBreakDownToday.Text) Then
        '    MsgBox("Total hours should be greater than Total BreakDown Hours")
        '    txtMechanicalBreakDownToday.Focus()
        '    Exit Sub
        'End If
        If txtTotalBreakDownToday.Text <> String.Empty And txtTotalBreakDownToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg84")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtMechanicalBreakDownToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg84")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtMechanicalBreakDownToday.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtTotalHours.Text <> String.Empty And txtTotalBreakDownToday.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtTotalHours.Text) - TimeSpan.Parse(txtTotalBreakDownToday.Text)
            '    txtEffectiveProcessingHoursToday.Text = Convert.ToString(lEffectiveHrs)
            'End If

            If txtTotalBreakDownToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTotalBreakDownToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer


                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If


                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEffectiveProcessingHoursToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" Or txtTotalHours.Text <> "00:00" Then
            txtEffectiveProcessingHoursToday.Text = txtTotalHours.Text
        Else
            txtEffectiveProcessingHoursToday.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEffectiveProcessingHoursToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If
        'If txtMechanicalBreakDownMonth .Enabled = False 
        '    If txtMechanicalBreakDownToday.Text <> "" And txtMechanicalBreakDownToday.Text <> "00:00" Then
        '        txtMechanicalBreakDownMonth.Text = ToaddHours(lMechanicalBreakDownMonth, txtMechanicalBreakDownToday.Text)
        '        txtMechanicalBreakDownYear.Text = ToaddHours(lMechanicalBreakDownYear, txtMechanicalBreakDownToday.Text)
        '    Else
        '        txtMechanicalBreakDownMonth.Text = lMechanicalBreakDownMonth
        '        txtMechanicalBreakDownYear.Text = lMechanicalBreakDownYear

        '    End If
        'End If
        If Val(txtKerneltoday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtThroughput.Text = Math.Round((Val(txtKerneltoday.Text) / lEffectiveHrsDec), 2)
        Else
            txtThroughput.Text = ""
        End If

        If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
            txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / Val(txtKerneltoday.Text)), 2)
        Else
            txtKERToday.Text = ""
        End If


    End Sub

    Private Sub txtElectricalBreakDownToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElectricalBreakDownToday.Leave
        If txtElectricalBreakDownToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtElectricalBreakDownToday.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtElectricalBreakDownToday.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If Hrs > 24 Then
                DisplayInfoMessage("Msg83")
                ''MessageBox.Show("Breakdown Hrs cant be greater than  24")
                txtElectricalBreakDownToday.Focus()
                Exit Sub
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtElectricalBreakDownToday.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtElectricalBreakDownToday.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtElectricalBreakDownToday.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtElectricalBreakDownToday.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtElectricalBreakDownToday.Text = Hrs + ":" + Min
        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownToday.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownToday.Text
        End If
        If txtElectricalBreakDownToday.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownToday.Text
        End If
        If txtProcessingBreakDownToday.Text <> "" Then
            lProcessBK = txtProcessingBreakDownToday.Text
        End If


        lBDCalculation = ToaddHours(lMechaniclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lelectriclBD)

        If lBDCalculation <> "" Then
            Dim str As String
            Dim strArr() As String
            str = lBDCalculation
            strArr = str.Split(":")

            If strArr(0) > 24 Then
                DisplayInfoMessage("Msg83")
                ''MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
                txtElectricalBreakDownToday.Focus()
                Exit Sub
            End If
        End If

        If (txtMechanicalBreakDownToday.Text <> "" Or txtElectricalBreakDownToday.Text <> "" Or txtProcessingBreakDownToday.Text <> "") Then
            txtTotalBreakDownToday.Text = lBDCalculation
        Else
            txtTotalBreakDownToday.Text = ""
        End If

        If txtTotalBreakDownToday.Text <> String.Empty And txtTotalBreakDownToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If



            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg84")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtElectricalBreakDownToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg84")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtElectricalBreakDownToday.Focus()
                Exit Sub
            End If

            '  Dim lEffectiveHrs As TimeSpan

            If txtTotalBreakDownToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTotalBreakDownToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If


                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEffectiveProcessingHoursToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" Or txtTotalHours.Text <> "00:00" Then
            txtEffectiveProcessingHoursToday.Text = txtTotalHours.Text
        Else
            txtEffectiveProcessingHoursToday.Text = "00:00"

        End If

        Dim lEffectiveHrsDec As Decimal
        If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEffectiveProcessingHoursToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = strArr3(0)
            Min1 = strArr3(1)

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If
        'If txtElectricalBreakDownMonth.Enabled = False Then
        '    If txtElectricalBreakDownToday.Text <> "" And txtElectricalBreakDownToday.Text <> "00:00" Then
        '        txtElectricalBreakDownMonth.Text = ToaddHours(lElectricalBreakDownMonth, txtElectricalBreakDownToday.Text)
        '        txtElectricalBreakDownYear.Text = ToaddHours(lElectricalBreakDownYear, txtElectricalBreakDownToday.Text)
        '    Else
        '        txtElectricalBreakDownMonth.Text = lElectricalBreakDownMonth
        '        txtElectricalBreakDownYear.Text = lElectricalBreakDownYear
        '    End If
        'End If

        If Val(txtKerneltoday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtThroughput.Text = Math.Round((Val(txtKerneltoday.Text) / lEffectiveHrsDec), 2)
        Else
            txtThroughput.Text = ""
        End If

        If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
            txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / Val(txtKerneltoday.Text)), 2)
        Else
            txtKERToday.Text = ""
        End If

    End Sub

    Private Sub txtProcessingBreakDownToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessingBreakDownToday.Leave
        If txtProcessingBreakDownToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtProcessingBreakDownToday.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtProcessingBreakDownToday.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If Hrs > 24 Then
                DisplayInfoMessage("Msg83")
                ''MessageBox.Show("Breakdown Hrs cant be greater than  24")
                txtProcessingBreakDownToday.Focus()
                Exit Sub
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtProcessingBreakDownToday.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtProcessingBreakDownToday.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtProcessingBreakDownToday.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtProcessingBreakDownToday.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtProcessingBreakDownToday.Text = Hrs + ":" + Min

        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownToday.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownToday.Text
        End If
        If txtElectricalBreakDownToday.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownToday.Text
        End If
        If txtProcessingBreakDownToday.Text <> "" Then
            lProcessBK = txtProcessingBreakDownToday.Text
        End If


        lBDCalculation = ToaddHours(lMechaniclBD, lelectriclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lProcessBK)

        If lBDCalculation <> "" Then
            Dim str As String
            Dim strArr() As String
            str = lBDCalculation
            strArr = str.Split(":")

            If strArr(0) > 24 Then
                DisplayInfoMessage("Msg83")
                ''MessageBox.Show("Breakdown Hrs cant be greater than 24 Hrs")
                txtProcessingBreakDownToday.Focus()
                Exit Sub
            End If
        End If

        If (txtMechanicalBreakDownToday.Text <> "" Or txtElectricalBreakDownToday.Text <> "" Or txtProcessingBreakDownToday.Text <> "") Then
            txtTotalBreakDownToday.Text = lBDCalculation
        Else
            txtTotalBreakDownToday.Text = ""
        End If


        If txtTotalBreakDownToday.Text <> String.Empty And txtTotalBreakDownToday.Text <> "00:00" And txtTotalHours.Text <> String.Empty And txtTotalHours.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtTotalHours.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownToday.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg84")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtProcessingBreakDownToday.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg84")
                ''MsgBox("BreakDown hours should be lesser than Total Shift hours")
                txtProcessingBreakDownToday.Focus()
                Exit Sub
            End If

            ' Dim lEffectiveHrs As TimeSpan

            If txtTotalBreakDownToday.Text <> String.Empty And txtTotalHours.Text <> String.Empty Then
                'Dim ProcessHrs As String
                Dim strArr4(), strArr3() As String
                Dim Str4, Str3 As String
                Str4 = txtTotalHours.Text
                strArr4 = Str4.Split(":")
                Str3 = txtTotalBreakDownToday.Text
                strArr3 = Str3.Split(":")

                Dim Lhrs2, lmin2 As Integer

                Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
                lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

                If lmin2 < 0 Then
                    lmin2 = lmin2 + 60
                    Lhrs2 = Lhrs2 - 1
                End If
                Dim Strhrs2 As String = "00"
                Dim StrMin2 As String = "00"


                If Lhrs2 < 10 Then
                    Strhrs2 = "0" + Convert.ToString(Lhrs2)
                Else
                    Strhrs2 = Lhrs2
                End If

                If lmin2 < 10 Then
                    StrMin2 = "0" + Convert.ToString(lmin2)
                Else
                    StrMin2 = lmin2
                End If

                txtEffectiveProcessingHoursToday.Text = Strhrs2 + ":" + StrMin2
            End If
        ElseIf txtTotalHours.Text <> "" Or txtTotalHours.Text <> "00:00" Then
            txtEffectiveProcessingHoursToday.Text = txtTotalHours.Text
        Else
            txtEffectiveProcessingHoursToday.Text = "00:00"

        End If

        Dim lEffectiveHrsDec As Decimal
        If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEffectiveProcessingHoursToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = strArr3(0)
            Min1 = strArr3(1)

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If
        'If txtProcessingBreakDownMonth.Enabled = False Then
        '    If txtProcessingBreakDownToday.Text <> "" And txtProcessingBreakDownToday.Text <> "00:00" Then
        '        txtProcessingBreakDownMonth.Text = ToaddHours(lProcessingBreakDownMonth, txtProcessingBreakDownToday.Text)
        '        txtProcessingBreakDownYear.Text = ToaddHours(lProcessingBreakDownYear, txtProcessingBreakDownToday.Text)
        '    Else
        '        txtProcessingBreakDownMonth.Text = lProcessingBreakDownMonth
        '        txtProcessingBreakDownYear.Text = lProcessingBreakDownYear
        '    End If
        'End If


        If Val(txtKerneltoday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtThroughput.Text = Math.Round((Val(txtKerneltoday.Text) / lEffectiveHrsDec), 2)
        Else
            txtThroughput.Text = ""
        End If


        If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
            txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / Val(txtKerneltoday.Text)), 2)
        Else
            txtKERToday.Text = ""
        End If


    End Sub

    Private Sub TotalBreakDown()
        Dim intMins As Double = 0
        Dim intHrs As Double = 0
        Dim intDiv As Double = 0
        Dim strDiv As String = 0
        Dim StrHrs As String = ""
        If txtTotalBreakDownToday.Text <> String.Empty Then

            intMins = txtTotalBreakDownToday.Text * 100
            'intMins = intMins - 40
            intHrs = intMins / 100
            intHrs = Fix(intHrs)
            intDiv = intMins Mod 100
            intDiv = Fix(intDiv)
            strDiv = intDiv
            StrHrs = intHrs
            'If intDiv <= 40 Then
            '    intDiv = intDiv + 40
            'End If
            If (intDiv >= 60) Then
                intMins = intDiv - 60
                intHrs = intHrs + 1
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                End If
                If intMins = 0 Then
                    strDiv = "00"
                ElseIf intMins = "5" Then
                    strDiv = "05"
                Else
                    strDiv = intMins
                End If

                txtTotalBreakDownToday.Text = StrHrs.ToString + "." + strDiv.ToString
            ElseIf intDiv.ToString.Length = 1 Then
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                End If
                txtTotalBreakDownToday.Text = StrHrs.ToString + ".0" + intDiv.ToString
            Else
                If intHrs < 10 Then
                    StrHrs = "0" + Convert.ToString(intHrs)
                End If

                txtTotalBreakDownToday.Text = StrHrs.ToString + "." + intDiv.ToString
            End If
        End If
    End Sub

    Private Sub txtKerneltoday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKerneltoday.TextChanged
        If Val(txtKerneltoday.Text) >= 0 And lKernelMonth = 0 Then
            txtKernelMonth.Text = Val(txtKerneltoday.Text)
        End If

        If Val(txtKerneltoday.Text) > 0 And lKernelYear = 0 Then
            txtKernelYear.Text = Val(txtKerneltoday.Text)
        End If

        If Val(txtKerneltoday.Text) > 0 Then
            txtKerneltoday.Text = Format(Val(txtKerneltoday.Text), "0.000")
        End If

        Dim lEffectiveHrsDec As Decimal
        If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" And txtEffectiveProcessingHoursToday.Text <> "" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEffectiveProcessingHoursToday.Text
            strArr3 = str3.Split(":")
            Hrs1 = strArr3(0)
            Min1 = strArr3(1)

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If

        If Val(txtKerneltoday.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtThroughput.Text = Math.Round((Val(txtKerneltoday.Text) / lEffectiveHrsDec), 2)
        Else
            txtThroughput.Text = ""
        End If

        If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
            'txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / (Val(txtKerneltoday.Text) - Val(txtLossOnKernelToday.Text))), 2)
            txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) / Val(txtKerneltoday.Text)) * 100, 2)
        Else
            txtKERToday.Text = ""
        End If




    End Sub

    Private Sub txtPKOProductionYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOProductionYear.TextChanged
        If Val(txtPKOProductionYear.Text) <> 0 And Val(txtKernelYear.Text) <> 0 Then
            txtKERYear.Text = Math.Round((Val(txtPKOProductionYear.Text) * 100 / (Val(txtKernelYear.Text) - Val(txtLossOnKernelYear.Text))), 2)
        Else
            txtKERYear.Text = ""
        End If
    End Sub

    Private Sub txtMonthTodateHrs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonthTodateHrs.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtMonthTodateHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonthTodateHrs.Leave
        If txtMonthTodateHrs.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtMonthTodateHrs.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMonthTodateHrs.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    '' MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMonthTodateHrs.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMonthTodateHrs.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMonthTodateHrs.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMonthTodateHrs.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtMonthTodateHrs.Text = Hrs + ":" + Min
        End If
        If txtMonthTodateHrs.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMonthTodateHrs.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTotalHours.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg85")
                ''MessageBox.Show("Month To Date Hrs cant be lesser than Total Hrs")
                ' txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
        If txtYearTodateHrs.Text <> "" And txtMonthTodateHrs.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodateHrs.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtMonthTodateHrs.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg86")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                '  txtMonthTodate.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtYearTodateHrs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYearTodateHrs.KeyPress
        'KeyPress2Decimal(sender, e)
    End Sub

    Private Sub txtYearTodateHrs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYearTodateHrs.Leave

        If txtYearTodateHrs.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodateHrs.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtYearTodateHrs.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtYearTodateHrs.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtYearTodateHrs.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtYearTodateHrs.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtYearTodateHrs.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtYearTodateHrs.Text = Hrs + ":" + Min
        End If
        If txtYearTodateHrs.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodateHrs.Text
            strArr = str.Split(":")

            Dim strTotal As String
            Dim strArrTotal() As String
            strTotal = txtTotalHours.Text
            strArrTotal = strTotal.Split(":")

            If Val(strArr(0)) < Val(strArrTotal(0)) Or (Val(strArr(0)) <= Val(strArrTotal(0)) And Val(strArr(1)) < Val(strArrTotal(1))) Then
                DisplayInfoMessage("Msg87")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Total Hrs")
                'txtYearTodate.Focus()
                Exit Sub
            End If
        End If
        If txtMonthTodateHrs.Text <> "" And txtYearTodateHrs.Text <> "" Then
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtYearTodateHrs.Text
            strArr = str.Split(":")

            Dim strMonth As String
            Dim strArrMonth() As String
            strMonth = txtMonthTodateHrs.Text
            strArrMonth = strMonth.Split(":")

            If Val(strArr(0)) < Val(strArrMonth(0)) Or (Val(strArr(0)) <= Val(strArrMonth(0)) And Val(strArr(1)) < Val(strArrMonth(1))) Then
                DisplayInfoMessage("Msg86")
                ''MessageBox.Show("Year To Date Hrs cant be lesser than Month To Date Hrs")
                ' txtYearTodate.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub GetQuantityForCorrespondigLocation()
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        objPKOProductionLogPPT.LoadingLocationID = ddlLoadingLocationKerRecd.SelectedValue
        Dim str As String = dtPKOProductionDate.Value.ToString("yyyy-MM-dd")
        Dim culture As IFormatProvider
        culture = New CultureInfo("en-US", True)
        'objPKOProductionLogPPT.ProductionLogDate = DateTime.Parse(str, culture, DateTimeStyles.NoCurrentDateDefault)
        objPKOProductionLogPPT.ProductionLogDate = Convert.ToDateTime(str)
        txtqtyMtKerRecd.Text = PKOProductionLogBOL.GetQuantityForCorrespondigLocation(objPKOProductionLogPPT)
    End Sub


    Private Sub txtMonthTodateHrs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonthTodateHrs.KeyDown
        'KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtYearTodateHrs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYearTodateHrs.KeyDown
        ' KeyDown2Decimal(sender, e)
    End Sub

    Private Sub txtMeterFrom_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterFrom.Leave
        If txtMeterFrom.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMeterFrom.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMeterFrom.Focus()
                Exit Sub
            End If

            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMeterFrom.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMeterFrom.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    '' MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMeterFrom.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMeterFrom.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg88")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtMeterFrom.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMeterFrom.Text = Hrs + ":" + Min
        End If

        If txtMeterFrom.Text <> String.Empty And txtMeterTo.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMeterTo.Text
            strArr = Str.Split(":")
            Str1 = txtMeterFrom.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr(0)) - CInt(strArr1(0))
            lmin = CInt(strArr(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs > 24 Then
                DisplayInfoMessage("Msg89")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterFrom.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg89")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterFrom.Focus()
            ElseIf Lhrs < 0 Then
                DisplayInfoMessage("Msg90")
                ''MsgBox("Meter To Value should be greater than Meter From")
                txtOPHrs.Text = ""
                txtMeterFrom.Focus()
            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtOPHrs.Text = Strhrs + ":" + StrMin
            End If
        Else
            txtOPHrs.Text = "00:00"

        End If
    End Sub

    Private Sub txtMeterTo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterTo.Leave
        If txtMeterTo.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMeterTo.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtMeterTo.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtMeterTo.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMeterTo.Focus()
                    Exit Sub
                End If



                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMeterTo.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMeterTo.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg88")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtMeterTo.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMeterTo.Text = Hrs + ":" + Min
        End If

        If txtMeterFrom.Text <> String.Empty And txtMeterTo.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr(), strArr1() As String
            Dim Str, Str1 As String
            Str = txtMeterTo.Text
            strArr = Str.Split(":")
            Str1 = txtMeterFrom.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr(0)) - CInt(strArr1(0))
            lmin = CInt(strArr(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            Dim Strhrs As String = "00"
            Dim StrMin As String = "00"

            If Lhrs > 24 Then
                DisplayInfoMessage("Msg89")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterTo.Focus()
            ElseIf Lhrs = 24 And lmin > 0 Then
                DisplayInfoMessage("Msg89")
                ''MsgBox("Operating Hrs Cant be greater than 24 hrs ")
                txtOPHrs.Text = ""
                txtMeterTo.Focus()
            ElseIf Lhrs < 0 Then
                DisplayInfoMessage("Msg90")
                ''MsgBox("Meter To Value should be greater than Meter From")
                txtOPHrs.Text = ""
                txtMeterTo.Focus()
            Else
                If Lhrs < 10 Then
                    Strhrs = "0" + Convert.ToString(Lhrs)
                Else
                    Strhrs = Lhrs
                End If

                If lmin < 10 Then
                    StrMin = "0" + Convert.ToString(lmin)
                Else
                    StrMin = lmin
                End If

                txtOPHrs.Text = Strhrs + ":" + StrMin
            End If
        Else
            txtOPHrs.Text = "00:00"

        End If

    End Sub

    'Private Sub OPhoursCalculation(ByVal lOPHrs As Decimal)

    '    Dim intMins As Double = 0
    '    Dim intHrs As Double = 0
    '    Dim intDiv As Double = 0
    '    Dim strDiv As String = 0



    '    intMins = lOPHrs * 100
    '    intMins = intMins - 40
    '    intHrs = intMins / 100
    '    intHrs = Fix(intHrs)

    '    intDiv = intMins Mod 100
    '    intDiv = Fix(intDiv)
    '    'If intDiv <= 40 Then
    '    '    intDiv = intDiv + 40
    '    'End If
    '    intDiv = Fix(intDiv)
    '    Dim StrHrs As String = String.Empty
    '    If intHrs < 10 Then
    '        StrHrs = "0" + Convert.ToString(intHrs)
    '    Else
    '        StrHrs = intHrs
    '    End If

    '    If (intDiv >= 60) Then
    '        intMins = intDiv - 60

    '        intHrs = intHrs + 1
    '        If intHrs < 10 Then
    '            StrHrs = "0" + Convert.ToString(intHrs)
    '        Else
    '            StrHrs = intHrs
    '        End If
    '        If intMins.ToString.Length = 1 Then
    '            txtOPHrs.Text = StrHrs.ToString + ".0" + intMins.ToString
    '        Else
    '            txtOPHrs.Text = StrHrs.ToString + "." + intMins.ToString
    '        End If
    '    ElseIf intDiv.ToString.Length = 1 Then
    '        txtOPHrs.Text = StrHrs.ToString + ".0" + intDiv.ToString
    '    Else
    '        txtOPHrs.Text = StrHrs.ToString + "." + intDiv.ToString
    '    End If

    'End Sub

    Private Sub txtKernelProcessedMonth_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelProcessedMonth.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKernelProcessedMonth_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessedMonth.Leave
        DecimalIdenCheck(txtKernelProcessedMonth)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg91")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtKernelProcessedMonth.Focus()
        End If
        DecimalCheck = False


        If Val(txtKernelProcessedToday.Text) >= 0 And Val(txtKernelProcessedMonth.Text) >= 0 Then
            If Val(txtKernelProcessedToday.Text) > Val(txtKernelProcessedMonth.Text) Then
                DisplayInfoMessage("Msg92")
                ''MessageBox.Show("Month to date Value should be greater than today qty")
                txtKernelProcessedMonth.Focus()
            End If

        End If


        If Val(txtKernelProcessedMonth.Text) <> 0 And Val(txtKernelProcessedYear.Text) <> 0 Then
            If Val(txtKernelProcessedYear.Text) < Val(txtKernelProcessedMonth.Text) Then
                DisplayInfoMessage("Msg93")
                ''MessageBox.Show("Year to date Value should be greater than month to date")
                txtKernelProcessedMonth.Focus()
            End If
        End If

        If txtKernelProcessedMonth.Text <> String.Empty Then
            txtKernelMonth.Text = txtKernelProcessedMonth.Text
        Else
            txtKernelMonth.Text = ""
        End If


    End Sub

    Private Sub txtKernelProcessedYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKernelProcessedYear.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtKernelProcessedYear_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessedYear.Leave
        DecimalIdenCheck(txtKernelProcessedYear)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtKernelProcessedYear.Focus()
        End If
        DecimalCheck = False


        If Val(txtKernelProcessedToday.Text) >= 0 And Val(txtKernelProcessedYear.Text) >= 0 Then
            If Val(txtKernelProcessedYear.Text) < Val(txtKernelProcessedToday.Text) Then
                DisplayInfoMessage("Msg95")
                ''MessageBox.Show("Year to date Value should be greater than today qty")
                txtKernelProcessedYear.Focus()
            End If

        End If

        If Val(txtKernelProcessedMonth.Text) <> 0 And Val(txtKernelProcessedYear.Text) <> 0 Then
            If Val(txtKernelProcessedYear.Text) < Val(txtKernelProcessedMonth.Text) Then
                DisplayInfoMessage("Msg96")
                ''MessageBox.Show("Year to date Value should be greater than month to date")
                txtKernelProcessedYear.Focus()
            End If
        End If

        If txtKernelProcessedYear.Text <> String.Empty Then
            txtKernelYear.Text = txtKernelProcessedYear.Text
        Else
            txtKernelYear.Text = ""
        End If
    End Sub

    'Private Sub MonthYearValueCheck()

    '    Dim objPKOProductionLogPPT As New PKOProductionLogPPT
    '    Dim objPKOProductionLogBOL As New PKOProductionLogBOL

    '    Dim dsMonthValues As New DataSet
    '    objPKOProductionLogPPT.ProductionLogDate = dtPKOProductionDate.Value
    '    dsMonthValues = PKOProductionLogBOL.PKOProductionlogPKOMonthYearValueSelect(objPKOProductionLogPPT)

    '    If dsMonthValues IsNot Nothing Then

    '        If dsMonthValues.Tables(4).Rows.Count <> 0 Then
    '            txtMonthTodateHrs.Text = dsMonthValues.Tables(4).Rows(0).Item("MonthToDateHrs").ToString
    '        End If
    '        If dsMonthValues.Tables(0).Rows.Count <> 0 Then
    '            txtTodateMtRecKer.Text = dsMonthValues.Tables(0).Rows(0).Item("KerTodate").ToString
    '        End If

    '        If dsMonthValues.Tables(1).Rows.Count <> 0 Then
    '            txtKernelProcessedMonth.Text = dsMonthValues.Tables(1).Rows(0).Item("KernelProcessedACTMTD").ToString
    '            txtKernelMonth.Text = dsMonthValues.Tables(1).Rows(0).Item("KernelProcessedACTMTD").ToString
    '        End If

    '        If dsMonthValues.Tables(10).Rows.Count <> 0 Then
    '            txtYearTodateHrs.Text = dsMonthValues.Tables(10).Rows(0).Item("YeartoDateHrs").ToString
    '        End If
    '        If dsMonthValues.Tables(7).Rows.Count <> 0 Then
    '            txtKernelYear.Text = dsMonthValues.Tables(7).Rows(0).Item("KernelProcessedACYTD").ToString
    '            txtKernelProcessedYear.Text = dsMonthValues.Tables(7).Rows(0).Item("KernelProcessedACYTD").ToString
    '        End If
    '        If dsMonthValues.Tables(6).Rows.Count <> 0 Then

    '            txtYearTodateRecKer.Text = dsMonthValues.Tables(6).Rows(0).Item("KerTodateYears").ToString
    '        End If
    '        If dsMonthValues.Tables(11).Rows.Count <> 0 Then
    '            txtBFQty.Text = dsMonthValues.Tables(11).Rows(0).Item("BalanceKERBFQty").ToString
    '        End If


    '        If txtBFQty.Text = "" Then
    '            txtBFQty.Enabled = True
    '            ' lblBFQty.ForeColor = Color.Red
    '        Else
    '            txtBFQty.Enabled = False
    '            ' lblBFQty.ForeColor = Color.Black
    '        End If


    '    End If


    '    If Val(txtTodateMtRecKer.Text) = 0 Then
    '        txtTodateMtRecKer.Enabled = True
    '        ' lblTodate.ForeColor = Color.Red
    '    Else
    '        txtTodateMtRecKer.Enabled = False
    '        ' lblTodate.ForeColor = Color.Black
    '    End If
    '    If txtMonthTodateHrs.Text <> "00:00" Then
    '        ' lblProMonthToDate.ForeColor = Color.Red
    '        txtMonthTodateHrs.Enabled = False
    '    Else
    '        ' lblProMonthToDate.ForeColor = Color.Black
    '        txtMonthTodateHrs.Enabled = True
    '    End If
    '    If Val(txtKernelProcessedMonth.Text) = 0 Then
    '        txtKernelProcessedMonth.Enabled = True
    '        'lblKernelMonthToDate.ForeColor = Color.Red
    '    Else
    '        txtKernelProcessedMonth.Enabled = False
    '        ' lblKernelMonthToDate.ForeColor = Color.Black
    '    End If

    '    If Val(txtKernelProcessedYear.Text) = 0 Then
    '        txtKernelProcessedYear.Enabled = True
    '        ' lblKernelYearToDate.ForeColor = Color.Red
    '    Else
    '        txtKernelProcessedYear.Enabled = False
    '        'lblKernelYearToDate.ForeColor = Color.Black
    '    End If
    '    'If Val(txtYearTodateRecKer.Text) = 0 Then
    '    '    txtYearTodateRecKer.Enabled = True
    '    '    ' lblYearTodateMt.ForeColor = Color.Red
    '    'Else
    '    '    txtYearTodateRecKer.Enabled = False
    '    '    '  lblYearTodateMt.ForeColor = Color.Black
    '    'End If
    '    If txtYearTodateHrs.Text <> "00:00" Then
    '        ' lblYearTodate.ForeColor = Color.Red
    '        txtYearTodateHrs.Enabled = False
    '    Else
    '        ' lblYearTodate.ForeColor = Color.Black
    '        txtYearTodateHrs.Enabled = True
    '    End If
    'End Sub

    Private Sub txtTodateMtRecKer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTodateMtRecKer.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtTodateMtRecKer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTodateMtRecKer.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtTodateMtRecKer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTodateMtRecKer.Leave
        DecimalIdenCheck(txtTodateMtRecKer)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtTodateMtRecKer.Focus()
        End If
        DecimalCheck = False

        'If Val(txtTodateMtRecKer.Text) <> 0 And Val(txtYearTodateRecKer.Text) <> 0 Then
        '    If Val(txtYearTodateRecKer.Text) < Val(txtTodateMtRecKer.Text) Then
        '        MessageBox.Show("Year to date Value should be greater than month to date")
        '        txtTodateMtRecKer.Focus()
        '    End If
        'End If
    End Sub

    Private Sub txtYearTodateRecKer_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYearTodateRecKer.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtYearTodateRecKer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYearTodateRecKer.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtYearTodateRecKer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYearTodateRecKer.Leave
        DecimalIdenCheck(txtYearTodateRecKer)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtYearTodateRecKer.Focus()
        End If
        DecimalCheck = False

        'If Val(txtTodateMtRecKer.Text) <> 0 And Val(txtYearTodateRecKer.Text) <> 0 Then
        '    If Val(txtYearTodateRecKer.Text) < Val(txtTodateMtRecKer.Text) Then
        '        MessageBox.Show("Year to date Value should be greater than month to date")
        '        txtTodateMtRecKer.Focus()
        '    End If

        'End If
    End Sub

    Private Sub txtKernelProcessedMonth_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelProcessedMonth.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtKernelProcessedYear_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtKernelProcessedYear.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub DecimalIdenCheck(ByVal ptxtbox As Object)
        Dim i As Integer
        i = ptxtbox.Text.IndexOf("."c)

        If i > 0 Then
            If ptxtbox.Text.Substring(i).Length = 1 Then
                DecimalCheck = True
            End If
        End If
    End Sub

    Private Sub txtKernelProcessed_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessed.Leave
        DecimalIdenCheck(txtKernelProcessed)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtKernelProcessed.Focus()
        End If
        DecimalCheck = False
    End Sub

    Private Sub txtqtyMtKerRecd_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtqtyMtKerRecd.Leave
        DecimalIdenCheck(txtqtyMtKerRecd)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtqtyMtKerRecd.Focus()
        End If
        DecimalCheck = False



        If txtqtyMtKerRecd.Text <> "" Then

            If lTodateMtRecKer > 0 And txtqtyMtKerRecd.Text <> "" And lbtnAddKerRecd = "Add" Then
                txtTodateMtRecKer.Text = lTodateMtRecKer + Val(txtqtyMtKerRecd.Text)
            ElseIf lTodateMtRecKer > 0 And txtqtyMtKerRecd.Text <> "" And lbtnAddKerRecd <> "Add" Then
                txtTodateMtRecKer.Text = lTodateMtRecKer + Val(txtqtyMtKerRecd.Text) - lqtyMtKerRecd
            ElseIf lbtnsaveall <> "Save All" And LoadMonthCount <= 1 And lTodateMtRecKer <> 0 Then
                txtTodateMtRecKer.Text = lTodateMtRecKer
            ElseIf lTodateMtRecKer = 0 And LoadMonthCount >= 1 Then
                txtTodateMtRecKer.Text = Val(txtqtyMtKerRecd.Text)
            ElseIf txtTodateMtRecKer.Text <> "" And txtTodateMtRecKer.Text <> "" Then
            ElseIf txtTodateMtRecKer.Enabled = False Then
                txtTodateMtRecKer.Text = ""
            End If


            If lYearTodateRecKer > 0 And txtqtyMtKerRecd.Text <> "" And lbtnAddKerRecd = "Add" Then
                txtYearTodateRecKer.Text = lYearTodateRecKer + Val(txtqtyMtKerRecd.Text)
            ElseIf lYearTodateRecKer > 0 And txtqtyMtKerRecd.Text <> "" And lbtnAddKerRecd <> "Add" Then
                txtYearTodateRecKer.Text = lYearTodateRecKer + Val(txtqtyMtKerRecd.Text) - lqtyMtKerRecd
            ElseIf lbtnsaveall <> "Save All" And LoadYearCount <= 1 And lYearTodateRecKer <> 0 Then
                txtYearTodateRecKer.Text = lYearTodateRecKer
            ElseIf lYearTodateRecKer = 0 And LoadYearCount >= 1 Then
                txtYearTodateRecKer.Text = Val(txtqtyMtKerRecd.Text)
            ElseIf txtTodateMtRecKer.Enabled = True And txtYearTodateRecKer.Text <> "" Then
            ElseIf txtTodateMtRecKer.Enabled = False Then
                txtYearTodateRecKer.Text = ""
            End If


        Else
            txtTodateMtRecKer.Text = ""
            txtYearTodateRecKer.Text = ""
        End If

    End Sub

    Private Sub txtLossOnKernelToday_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLossOnKernelToday.Leave
        DecimalIdenCheck(txtLossOnKernelToday)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtLossOnKernelToday.Focus()
        End If
        DecimalCheck = False

        If Val(txtLossOnKernelToday.Text) > Val(txtKerneltoday.Text) Then
            DisplayInfoMessage("Msg101")
            Exit Sub
        End If



        If txtLossOnKernelMonth.Enabled = False Then
            If Val(txtLossOnKernelToday.Text) > 0 Then
                txtLossOnKernelMonth.Text = lLossOnKernelMonth + Val(txtLossOnKernelToday.Text) - lPrevLossonKernel
                txtLossOnKernelYear.Text = lLossOnKernelYear + Val(txtLossOnKernelToday.Text) - lPrevLossonKernel
            Else
                txtLossOnKernelMonth.Text = ""
                txtLossOnKernelYear.Text = ""
            End If
        End If
    End Sub

    Private Sub txtBFQty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBFQty.KeyDown
        KeyDown3Decimal(sender, e)
    End Sub

    Private Sub txtBFQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBFQty.KeyPress
        KeyPress3Decimal(sender, e)
    End Sub

    Private Sub txtBFQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBFQty.Leave
        DecimalIdenCheck(txtBFQty)
        If DecimalCheck = True Then
            DisplayInfoMessage("Msg94")
            ''MsgBox("User Can enter only Whole Number or Decimal(Example: 10 (or) 10.500 ;Invalid Values 10.)")
            txtBFQty.Focus()
        End If
        DecimalCheck = False
    End Sub




    Private Sub txtTotalBreakDownToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalBreakDownToday.TextChanged
        If txtTotalBreakDownToday.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtTotalBreakDownToday.Text
            strArr = str.Split(":")


            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr(1).Length = 1 Then
                Min = "0" + strArr(1)
            Else
                Min = strArr(1)
            End If

            txtTotalBreakDownToday.Text = Hrs + ":" + Min
        Else
            txtTotalBreakDownToday.Text = ""
        End If
        MonthYearBreakdowncalculation()


    End Sub

    Private Sub txtEffectiveProcessingHoursToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEffectiveProcessingHoursToday.TextChanged
        If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtEffectiveProcessingHoursToday.Text
            strArr = str.Split(":")


            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr(1).Length = 1 Then
                Min = "0" + strArr(1)
            Else
                Min = strArr(1)
            End If

            txtEffectiveProcessingHoursToday.Text = Hrs + ":" + Min
        Else
            txtEffectiveProcessingHoursToday.Text = ""
        End If
        'If txtEffectiveProcessingHoursToday.Text <> "" And txtEffectiveProcessingHoursToday.Text <> "00:00" Then
        '    txtEffectiveProcessingHoursMonth.Text = ToaddHours(lEffectiveProcessingHoursMonth, txtEffectiveProcessingHoursToday.Text)
        '    txtEffectiveProcessingHoursYear.Text = ToaddHours(lEffectiveProcessingHoursYear, txtEffectiveProcessingHoursToday.Text)
        'Else
        '    txtEffectiveProcessingHoursMonth.Text = ""
        '    txtEffectiveProcessingHoursYear.Text = ""
        'End If
    End Sub

    Private Sub txtMonthTodateHrs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonthTodateHrs.TextChanged
        If txtMonthTodateHrs.Enabled = True Then
            If txtMonthTodateHrs.Text <> "" Then
                Dim Value As String = txtMonthTodateHrs.Text
                Dim strlen As Integer
                strlen = Len(txtMonthTodateHrs.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtMonthTodateHrs.Text = Value.Substring(0, strlen - 1)
                        txtMonthTodateHrs.Focus()
                    End If
                Next
            End If

            If Val(txtMonthTodateHrs.Text) >= 744 Then
                DisplayInfoMessage("Msg120")
                txtMonthTodateHrs.Focus()
            End If
        End If


    End Sub

    Private Sub txtYearTodateHrs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYearTodateHrs.TextChanged
        If txtYearTodateHrs.Enabled = True Then

            If txtYearTodateHrs.Text <> "" Then
                Dim Value As String = txtYearTodateHrs.Text
                Dim strlen As Integer
                strlen = Len(txtYearTodateHrs.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtYearTodateHrs.Text = Value.Substring(0, strlen - 1)
                        txtYearTodateHrs.Focus()
                    End If
                Next
            End If
            If Val(txtYearTodateHrs.Text) >= 8760 Then
                DisplayInfoMessage("Msg121")
                txtYearTodateHrs.Focus()
            End If
        End If
    End Sub

    Private Sub txtMeterFrom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterFrom.TextChanged
        If txtMeterFrom.Text <> "" Then
            Dim Value As String = txtMeterFrom.Text
            Dim strlen As Integer
            strlen = Len(txtMeterFrom.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMeterFrom.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    ''MsgBox("Please Enter numeric values only")
                    txtMeterFrom.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtMeterTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeterTo.TextChanged
        If txtMeterTo.Text <> "" Then
            Dim Value As String = txtMeterTo.Text
            Dim strlen As Integer
            strlen = Len(txtMeterTo.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMeterTo.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    ''MsgBox("Please Enter numeric values only")
                    txtMeterTo.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtOPHrs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOPHrs.Leave
        If txtOPHrs.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtOPHrs.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtOPHrs.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtOPHrs.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM format ")
                    txtOPHrs.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtOPHrs.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtOPHrs.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg88")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtOPHrs.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtOPHrs.Text = Hrs + ":" + Min
        End If
    End Sub

    Private Sub txtOPHrs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOPHrs.TextChanged
        If txtOPHrs.Text <> "" Then
            Dim Value As String = txtOPHrs.Text
            Dim strlen As Integer
            strlen = Len(txtOPHrs.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtOPHrs.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    ''MsgBox("Please Enter numeric values only")
                    txtOPHrs.Focus()
                End If
            Next
        End If
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If (dgvPKOLogShiftDetails.RowCount > 0 Or dgPressInfo.RowCount > 0 Or dgvReceivedKernel.RowCount > 0) And btnSaveAll.Enabled = True Then
            If MsgBox(rm.GetString("Msg98"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.OK Then
                GlobalPPT.IsRetainFocus = False
                GlobalPPT.IsButtonClose = True
                Me.Close()
            Else
                GlobalPPT.IsRetainFocus = True
                GlobalPPT.IsButtonClose = False
                Exit Sub
            End If
        Else
            Me.Close()
        End If

    End Sub

    Private Sub ddlLoadingLocationKerRecd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlLoadingLocationKerRecd.SelectedIndexChanged

        If ddlLoadingLocationKerRecd.SelectedIndex > 0 Then
            KerRecdMonthYearValueSelect()
            GetQuantityForCorrespondigLocation()
        Else
            txtqtyMtKerRecd.Text = ""
            txtTodateMtRecKer.Enabled = False
            txtYearTodateRecKer.Enabled = False
            txtTodateMtRecKer.Text = ""
            txtYearTodateRecKer.Text = ""
        End If

    End Sub

    Private Sub KerRecdMonthYearValueSelect()

        Dim ObjProductionKerRecd As New PKOProductionLogPPT
        LoadMonthCount = False
        ObjProductionKerRecd.LoadingLocationID = ddlLoadingLocationKerRecd.SelectedValue.ToString
        ObjProductionKerRecd.ProductionLogDate = dtPKOProductionDate.Value
        Dim dsKerRecd As New DataSet

        dsKerRecd = PKOProductionLogBOL.GetPKOProductionLogKerRecdMonthValueSelect(ObjProductionKerRecd)

        If dsKerRecd.Tables(0).Rows.Count <> 0 Then
            lTodateMtRecKer = Val(dsKerRecd.Tables(0).Rows(0).Item("KerRecdMonthTodate").ToString)
        End If
        LoadMonthCount = dsKerRecd.Tables(2).Rows(0).Item("LoadMonthCount").ToString


        If dsKerRecd.Tables(2).Rows.Count <> 0 Then
            lYearTodateRecKer = Val(dsKerRecd.Tables(1).Rows(0).Item("KerRecdYearTodate").ToString)

        End If
        LoadYearCount = dsKerRecd.Tables(3).Rows(0).Item("LoadYearCount").ToString

        If LoadMonthCount = 0 Or (LoadMonthCount = 1 And lbtnAddKerRecd <> "Add" And lbtnsaveall <> "Save All") Then
            txtTodateMtRecKer.Enabled = True
        Else
            txtTodateMtRecKer.Enabled = False
        End If

        If LoadYearCount = 0 Or (LoadYearCount = 1 And lbtnAddKerRecd <> "Add" And lbtnsaveall <> "Save All") Then
            txtYearTodateRecKer.Enabled = True
        Else
            txtYearTodateRecKer.Enabled = False
        End If


    End Sub

    Private Sub txtKernelMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelMonth.TextChanged
        If Val(txtKernelMonth.Text) > 0 Then
            txtKernelMonth.Text = Format(Val(txtKernelMonth.Text), "0.000")
        End If
        If Val(txtKernelMonth.Text) <> 0 And txtEffectiveProcessingHoursMonth.Text <> "00:00" And txtEffectiveProcessingHoursMonth.Text <> "" Then

            Dim Hrs As Integer
            Dim Min As Integer
            Dim Minstr As String
            Dim str As String
            Dim strArr() As String
            Dim Effect As Decimal
            str = txtEffectiveProcessingHoursMonth.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            If strArr(1) <> "00" Then
                Min = Math.Round(strArr(1) / 60, 2) * 100
            End If
            Minstr = "." + Convert.ToString(Min)

            Effect = Convert.ToString(Hrs) + Minstr
            txtThroughputMonthTodate.Text = Math.Round((Val(txtKernelMonth.Text) / Effect), 2)
        Else
            txtThroughputMonthTodate.Text = ""
        End If


        If Val(txtPKOProductionMonthTodate.Text) <> 0 And Val(txtKernelMonth.Text) <> 0 Then
            'txtKERMonth.Text = Math.Round((Val(txtPKOProductionMonthTodate.Text) * 100 / (Val(txtKernelMonth.Text) - Val(txtLossOnKernelMonth.Text))), 2)
            txtKERMonth.Text = Math.Round((Val(txtPKOProductionMonthTodate.Text) * 100 / (Val(txtKernelMonth.Text))), 2)
        Else
            txtKERMonth.Text = ""
        End If




    End Sub

    Private Sub txtKernelYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelYear.TextChanged
        If Val(txtKernelYear.Text) > 0 Then
            txtKernelYear.Text = Format(Val(txtKernelYear.Text), "0.000")
        End If
        If Val(txtKernelYear.Text) <> 0 And txtEffectiveProcessingHoursYear.Text <> "00:00" And txtEffectiveProcessingHoursYear.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim Minstr As String
            Dim str As String
            Dim strArr() As String
            Dim Effect As Decimal
            str = txtEffectiveProcessingHoursYear.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            If strArr(1) <> "00" Then
                Min = Math.Round(strArr(1) / 60, 2) * 100
            End If
            Minstr = "." + Convert.ToString(Min)

            Effect = Convert.ToString(Hrs) + Minstr
            txtThroughputYear.Text = Math.Round((Val(txtKernelYear.Text) / Effect), 2)
        Else
            txtThroughputYear.Text = ""
        End If

        If Val(txtPKOProductionYear.Text) <> 0 And Val(txtKernelYear.Text) <> 0 Then
            txtKERYear.Text = Math.Round((Val(txtPKOProductionYear.Text) * 100 / (Val(txtKernelYear.Text) - Val(txtLossOnKernelYear.Text))), 2)
        Else
            txtKERYear.Text = ""
        End If
    End Sub




    Private Function ToaddHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) + CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) + CInt(strArr3(1))

        If lmin2 >= 60 Then
            lmin2 = lmin2 - 60
            Lhrs2 = Lhrs2 + 1
        End If
        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If
        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function


    Private Function ToSubHours(ByVal Hours1 As String, ByVal Hours2 As String)
        Dim Calchrs As String
        Dim strArr4(), strArr3() As String
        Dim Str4, Str3 As String
        Str4 = Hours1
        strArr4 = Str4.Split(":")
        Str3 = Hours2
        strArr3 = Str3.Split(":")

        Dim Lhrs2, lmin2 As Integer

        Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
        lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

        If lmin2 < 0 Then
            lmin2 = lmin2 + 60
            Lhrs2 = Lhrs2 - 1
        End If

        Dim Strhrs2 As String = "00"
        Dim StrMin2 As String = "00"


        If Lhrs2 < 10 Then
            Strhrs2 = "0" + Convert.ToString(Lhrs2)
        Else
            Strhrs2 = Lhrs2
        End If

        If lmin2 < 10 Then
            StrMin2 = "0" + Convert.ToString(lmin2)
        Else
            StrMin2 = lmin2
        End If

        Calchrs = Strhrs2 + ":" + StrMin2
        Return Calchrs
    End Function

    Private Sub txtTPHTodaystage1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTPHTodaystage1.TextChanged
        If txtTPHTodaystage1.Text <> "" And dgPressInfo.RowCount > 0 Then
            CPOGetMonthYearQtySumm("Stage 1")
            If lTotalOPHoursStage1 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And lbtnsaveall = "Save All" Then
                txtTPHMonthTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lmonthValuehrsSumm)
            ElseIf lTotalOPHoursStage1 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And lbtnsaveall <> "Save All" Then
                txtTPHMonthTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lmonthValuehrsSumm)
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And lbtnsaveall <> "Save All" Then
                txtTPHMonthTodateStage1.Text = lmonthValuehrsSumm
                txtTPHMonthTodateStage1.Enabled = True
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And lbtnsaveall = "Save All" Then
                txtTPHMonthTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lmonthValuehrsSumm)
                txtTPHMonthTodateStage1.Enabled = False
            ElseIf lmonthValuehrsSumm = "00:00" And txtTPHMonthTodateStage1.Enabled = False Then
                txtTPHMonthTodateStage1.Text = lTotalOPHoursStage1
            ElseIf txtTPHMonthTodateStage1.Text <> String.Empty Then
            Else
                txtTPHMonthTodateStage1.Enabled = True
            End If

            If lTotalOPHoursStage1 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And lbtnsaveall = "Save All" Then
                txtTPHYearTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lYearValueSumm)
            ElseIf lTotalOPHoursStage1 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And lbtnsaveall <> "Save All" Then
                txtTPHYearTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lYearValueSumm)
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And lbtnsaveall <> "Save All" Then
                txtTPHYearTodateStage1.Text = lYearValueSumm
                txtTPHYearTodateStage1.Enabled = True
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And lbtnsaveall = "Save All" Then
                txtTPHYearTodateStage1.Text = ToaddHours(lTotalOPHoursStage1, lYearValueSumm)
                txtTPHYearTodateStage1.Enabled = False
            ElseIf lYearValueSumm = "00:00" And txtTPHYearTodateStage1.Enabled = False Then
                txtTPHYearTodateStage1.Text = lTotalOPHoursStage1
            ElseIf txtTPHYearTodateStage1.Text <> String.Empty Then
            Else
                txtTPHYearTodateStage1.Enabled = True
            End If
            Dim lTPHTodaystage1 As Decimal

            If txtTPHTodaystage1.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtTPHTodaystage1.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTPHTodaystage1 = Hrs + lmin
            End If

            If Val(txtKernelProcessedToday.Text) >= 0 And lTPHTodaystage1 > 0 Then
                txtAPTstage1today.Text = Math.Round(Val(txtKernelProcessedToday.Text) * 1000 / lTPHTodaystage1, 2)
            Else
                txtAPTstage1today.Text = ""
            End If

            If txtEffectiveProcessingHoursToday.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtEffectiveProcessingHoursToday.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTotalHrs = Hrs + lmin
            End If

            If lTotalHrs > 0 And lTPHTodaystage1 > 0 And (ToCaculateTotalPress("Stage 1") > 0) Then
                txtutilstage1today.Text = Math.Round(lTPHTodaystage1 * 100 / (lTotalHrs * ToCaculateTotalPress("Stage 1")), 2)
            Else
                txtutilstage1today.Text = ""
            End If
        Else
            txtAPTstage1today.Text = ""
            txtutilstage1today.Text = ""
        End If

        'If txtTPHTodaystage1.Text = "" Then
        '    txtTPHMonthTodateStage1.Enabled = False
        '    txtTPHYearTodateStage1.Enabled = False
        'End If

        'If txtStage2TodayTPH.Text = "" Then
        '    txtStage2monthTodate.Enabled = False
        '    txtStage2yearTodate.Enabled = False
        'End If

    End Sub

    Private Sub txtStage2TodayTPH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStage2TodayTPH.TextChanged
        If txtStage2TodayTPH.Text <> "" And dgPressInfo.RowCount > 0 Then
            CPOGetMonthYearQtySumm("Stage 2")
            If lTotalOPHoursStage2 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And lbtnsaveall = "Save All" Then
                txtStage2monthTodate.Text = ToaddHours(lTotalOPHoursStage2, lmonthValuehrsSumm)
            ElseIf lTotalOPHoursStage2 <> "00:00" And lmonthValuehrsSumm <> "00:00" And MonthCountSumm > 1 And lbtnsaveall <> "Save All" Then
                txtStage2monthTodate.Text = ToaddHours(lTotalOPHoursStage2, lmonthValuehrsSumm)
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And lbtnsaveall <> "Save All" Then
                txtStage2monthTodate.Text = lmonthValuehrsSumm
                txtStage2monthTodate.Enabled = True
            ElseIf lmonthValuehrsSumm <> "00:00" And MonthCountSumm = 1 And lbtnsaveall = "Save All" Then
                txtStage2monthTodate.Text = ToaddHours(lTotalOPHoursStage2, lmonthValuehrsSumm)
                txtStage2monthTodate.Enabled = False
            ElseIf lmonthValuehrsSumm = "00:00" And txtStage2monthTodate.Enabled = False Then
                txtStage2monthTodate.Text = lTotalOPHoursStage2

            ElseIf txtStage2monthTodate.Text <> String.Empty Then
            Else
                txtStage2monthTodate.Enabled = True
            End If

            If lTotalOPHoursStage2 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And lbtnsaveall = "Save All" Then
                txtStage2yearTodate.Text = ToaddHours(lTotalOPHoursStage2, lYearValueSumm)
            ElseIf lTotalOPHoursStage2 <> "00:00" And lYearValueSumm <> "00:00" And YearCountSumm > 1 And lbtnsaveall <> "Save All" Then
                txtStage2yearTodate.Text = ToaddHours(lTotalOPHoursStage2, lYearValueSumm)
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And lbtnsaveall <> "Save All" Then
                txtStage2yearTodate.Text = lYearValueSumm
                txtStage2yearTodate.Enabled = True
            ElseIf lYearValueSumm <> "00:00" And YearCountSumm = 1 And lbtnsaveall = "Save All" Then
                txtStage2yearTodate.Text = ToaddHours(lTotalOPHoursStage2, lYearValueSumm)
                txtStage2yearTodate.Enabled = False
            ElseIf lYearValueSumm = "00:00" And txtStage2yearTodate.Enabled = False Then
                txtStage2yearTodate.Text = lTotalOPHoursStage2
            ElseIf txtStage2yearTodate.Text <> String.Empty Then
            Else
                txtStage2yearTodate.Enabled = True
            End If
            Dim lTPHTodaystage2, lTotalHrs As Decimal

            If txtStage2TodayTPH.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtStage2TodayTPH.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTPHTodaystage2 = Hrs + lmin
            End If

            If txtEffectiveProcessingHoursToday.Text <> "" Then
                Dim Hrs As Integer
                Dim Min As Integer
                Dim str As String
                Dim strArr() As String
                'Dim count As Integer
                str = txtEffectiveProcessingHoursToday.Text
                strArr = str.Split(":")
                Hrs = strArr(0)
                Min = strArr(1)

                Min = (Min / 60) * 100
                Dim lmin As String
                lmin = "." + Convert.ToString(Min)

                lTotalHrs = Hrs + lmin


            End If
            If Val(txtKernelProcessedToday.Text) >= 0 And lTPHTodaystage2 > 0 Then
                'txtAPTstage2today.Text = Math.Round(Val(txtKernelProcessedToday.Text) * 1000 / lTPHTodaystage2, 2)
                txtAPTstage2today.Text = ((ConvertToDouble(txtKerneltoday.Text) - ConvertToDouble(txtPKOProductionToday.Text)) * 1000 / ConvertToDouble(txtStage2TodayTPH.Text.Replace(":", ".")))
            Else
                txtAPTstage2today.Text = ""
            End If

            If lTotalHrs > 0 And lTPHTodaystage2 > 0 And ToCaculateTotalPress("Stage 2") > 0 Then
                txtutilstage2.Text = Math.Round(lTPHTodaystage2 * 100 / (lTotalHrs * ToCaculateTotalPress("Stage 2")), 2)
            Else
                txtutilstage2.Text = ""
            End If
        Else
            txtAPTstage2today.Text = ""
            txtutilstage2.Text = ""
        End If

        'If txtStage2TodayTPH.Text = "" Then
        '    txtStage2monthTodate.Enabled = False
        '    txtStage2yearTodate.Enabled = False
        'End If
        'If txtTPHTodaystage1.Text = "" Then
        '    txtTPHMonthTodateStage1.Enabled = False
        '    txtTPHYearTodateStage1.Enabled = False
        'End If
    End Sub

    Private Function ToCaculateTotalPress(ByVal Line As String)
        Dim lPresstotal As Integer = 0
        For Each objDataGridViewRow In dgPressInfo.Rows

            If objDataGridViewRow.Cells("dgMeStage").Value.ToString = Line Then
                lPresstotal = lPresstotal + 1
            End If
        Next
        Return lPresstotal

    End Function

    Private Sub CPOGetMonthYearQtySumm(ByVal Stage As String)

        Dim objPKOLogPPT As New PKOProductionLogPPT
        Dim dsProdQty As DataSet
        objPKOLogPPT.ProductionLogDate = dtPKOProductionDate.Value
        objPKOLogPPT.StagePress = Stage
        dsProdQty = PKOProductionLogBOL.PKOGetMonthYearQtySumm(objPKOLogPPT)
        lmonthValuehrsSumm = "00:00"
        lYearValueSumm = "00:00"
        MonthCountSumm = 0
        YearCountSumm = 0
        ' lStage = Stage
        stage1PressSummaryID = ""
        stage1PressSummaryID = ""
        lstageCountMonth = dsProdQty.Tables(18).Rows(0).Item("StageMonthCount")
        lstageCountYear = dsProdQty.Tables(19).Rows(0).Item("StageYearCount")

        If dsProdQty.Tables(6).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs") Is DBNull.Value Then
                lmonthValuehrsSumm = dsProdQty.Tables(6).Rows(0).Item("MonthToDateHrs")
                lmonthValuehrsSumm = ToModifyTime(lmonthValuehrsSumm)
                If Stage = "Stage 1" Then
                    If txtTPHMonthTodateStage1.Enabled = False Then
                        txtTPHMonthTodateStage1.Text = lmonthValuehrsSumm
                    End If
                    ' summCalcMonthStage1()
                Else

                    If txtStage2monthTodate.Enabled = False Then
                        txtStage2monthTodate.Text = lmonthValuehrsSumm
                    End If
                    ' summCalcMonthStage2()
                End If
            End If
        End If
        If dsProdQty.Tables(13).Rows.Count <> 0 Then
            If Not dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs") Is DBNull.Value Then
                lYearValueSumm = dsProdQty.Tables(13).Rows(0).Item("YearToDateHrs")
                lYearValueSumm = ToModifyTime(lYearValueSumm)
                If Stage = "Stage 1" Then
                    If txtTPHYearTodateStage1.Enabled = False Then
                        txtTPHYearTodateStage1.Text = lYearValueSumm
                    End If
                    '  SummCalcstage1Year()
                Else
                    If txtStage2yearTodate.Enabled = False Then
                        txtStage2yearTodate.Text = lYearValueSumm
                    ElseIf txtStage2yearTodate.Enabled = True And lbtnsaveall <> "Save All" Then
                        txtStage2yearTodate.Text = lYearValueSumm
                    End If
                    ' SummCalcstage2Year()
                End If
            End If
        End If

        MonthCountSumm = dsProdQty.Tables(14).Rows(0).Item("MonthCountHrs")
        YearCountSumm = dsProdQty.Tables(15).Rows(0).Item("YearCountHrs")

        If dsProdQty.Tables(16).Rows.Count <> 0 Then
            stage1PressSummaryID = dsProdQty.Tables(16).Rows(0).Item("stage1PressSummaryID")
            PrevStage1TPH = dsProdQty.Tables(16).Rows(0).Item("Stage1TPH")
        End If
        If dsProdQty.Tables(17).Rows.Count <> 0 Then
            stage2PressSummaryID = dsProdQty.Tables(17).Rows(0).Item("stage2PressSummaryID")
            PrevStage2TPH = dsProdQty.Tables(17).Rows(0).Item("Stage2TPH")
        End If


        If MonthCount = 0 Or (MonthCount = 1 And lbtnsaveall <> "Save All") Then
            txtTPHMonthTodateStage1.Enabled = True
            txtTPHYearTodateStage1.Enabled = True
            txtStage2monthTodate.Enabled = True
            txtStage2yearTodate.Enabled = True
        Else
            txtTPHMonthTodateStage1.Enabled = False
            txtTPHYearTodateStage1.Enabled = False
            txtStage2monthTodate.Enabled = False
            txtStage2yearTodate.Enabled = False
        End If


    End Sub

    Private Sub txtKernelProcessedToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessedToday.TextChanged
        If txtKernelProcessedToday.Text <> "" Then
            GetMonthVaues()
            If Val(txtKernelProcessedToday.Text) >= 0 And lKernelMonth >= 0 And KernelMonthCount > 1 And lbtnsaveall = "Save All" Then
                txtKernelProcessedMonth.Text = lKernelMonth + Val(txtKernelProcessedToday.Text)
            ElseIf Val(txtKernelProcessedToday.Text) >= 0 And lKernelMonth >= 0 And KernelMonthCount > 1 And lbtnsaveall <> "Save All" Then
                txtKernelProcessedMonth.Text = lKernelMonth + Val(txtKernelProcessedToday.Text) - lkernelPrevQty
                txtKernelProcessedMonth.Enabled = False
            ElseIf lKernelMonth >= 0 And KernelMonthCount = 1 And lbtnsaveall <> "Save All" Then
                txtKernelProcessedMonth.Text = lKernelMonth
                txtKernelProcessedMonth.Enabled = True
            ElseIf lKernelMonth >= 0 And KernelMonthCount = 1 And lbtnsaveall = "Save All" Then
                txtKernelProcessedMonth.Text = lKernelMonth + Val(txtKernelProcessedToday.Text)
                txtKernelProcessedMonth.Enabled = False
            ElseIf lKernelMonth = 0 And KernelMonthCount >= 1 Then
                txtKernelProcessedMonth.Text = Val(txtKernelProcessedToday.Text)
                txtKernelProcessedMonth.Enabled = False
            Else
                txtKernelProcessedMonth.Text = ""
                txtKernelProcessedMonth.Enabled = True
            End If
            GetYearVaues()
            If Val(txtKernelProcessedToday.Text) >= 0 And lKernelYear >= 0 And KernelYearCount >= 1 And lbtnsaveall = "Save All" Then
                txtKernelProcessedYear.Text = lKernelYear + Val(txtKernelProcessedToday.Text)
            ElseIf Val(txtKernelProcessedToday.Text) >= 0 And lKernelYear >= 0 And KernelYearCount > 1 And lbtnsaveall <> "Save All" Then
                txtKernelProcessedYear.Text = lKernelYear + Val(txtKernelProcessedToday.Text) - lkernelPrevQty
                txtKernelProcessedYear.Enabled = False
            ElseIf lKernelYear >= 0 And KernelYearCount = 1 And lbtnsaveall <> "Save All" Then
                txtKernelProcessedYear.Text = lKernelYear
                txtKernelProcessedYear.Enabled = True
            ElseIf lKernelYear >= 0 And KernelYearCount = 1 And lbtnsaveall = "Save All" Then
                txtKernelProcessedYear.Text = lKernelYear + Val(txtKernelProcessedToday.Text)
                txtKernelProcessedYear.Enabled = False
            ElseIf lKernelYear = 0 And KernelYearCount >= 1 Then
                txtKernelProcessedYear.Text = Val(txtKernelProcessedToday.Text)
                txtKernelProcessedYear.Enabled = False
            Else
                txtKernelProcessedYear.Text = ""
                txtKernelProcessedYear.Enabled = True
            End If
        End If
        If txtKernelProcessedToday.Enabled = False And Val(txtKernelProcessedToday.Text) >= 0 Then
            txtKernelProcessedToday.Text = Format(Val(txtKernelProcessedToday.Text), "0.000")
        End If
    End Sub

    Private Sub tcPKOLog_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcPKOLog.SelectedIndexChanged
        GetPKOProductionTodayValues()
        If tcPKOLog.SelectedIndex >= 1 Then
            'GetMonthVaues()
            'GetYearVaues()

            If txtKernelProcessedMonth.Text <> "" Then
                txtKernelMonth.Text = Val(txtKernelProcessedMonth.Text)
            Else
                txtKernelMonth.Text = ""
            End If

            If txtKernelProcessedYear.Text <> "" Then
                txtKernelYear.Text = Val(txtKernelProcessedYear.Text)
            Else
                txtKernelYear.Text = ""
            End If

            PKOGetMonthYearQty()
            If MonthCount = 0 Or (MonthCount = 1 And lbtnsaveall <> "Save All") Then
                txtMonthTodateHrs.Enabled = True
                txtLossOnKernelMonth.Enabled = True
                txtElectricalBreakDownMonth.Enabled = True
                txtMechanicalBreakDownMonth.Enabled = True
                txtProcessingBreakDownMonth.Enabled = True

                txtLossOnKernelYear.Enabled = True
                txtElectricalBreakDownYear.Enabled = True
                txtMechanicalBreakDownYear.Enabled = True
                txtProcessingBreakDownYear.Enabled = True

            Else
                txtMonthTodateHrs.Enabled = False
                txtLossOnKernelMonth.Enabled = False
                txtElectricalBreakDownMonth.Enabled = False
                txtMechanicalBreakDownMonth.Enabled = False
                txtProcessingBreakDownMonth.Enabled = False

                txtLossOnKernelYear.Enabled = False
                txtElectricalBreakDownYear.Enabled = False
                txtMechanicalBreakDownYear.Enabled = False
                txtProcessingBreakDownYear.Enabled = False
            End If
            Dim lBDCalculation As String = "00:00"
            Dim lMechaniclBD As String = "00:00"
            Dim lelectriclBD As String = "00:00"
            Dim lProcessBK As String = "00:00"

            If txtMechanicalBreakDownYear.Text <> "" Then
                lMechaniclBD = txtMechanicalBreakDownYear.Text
            End If
            If txtElectricalBreakDownYear.Text <> "" Then
                lelectriclBD = txtElectricalBreakDownYear.Text
            End If
            If txtProcessingBreakDownYear.Text <> "" Then
                lProcessBK = txtProcessingBreakDownYear.Text
            End If


            lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
            lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

            If (txtMechanicalBreakDownYear.Text <> "" Or txtElectricalBreakDownYear.Text <> "" Or txtProcessingBreakDownYear.Text <> "") Then
                txtTotalBreakDownYear.Text = lBDCalculation
            Else
                txtTotalBreakDownYear.Text = ""
            End If

            summCalcMonthStage1()
            summCalcMonthStage2()
            SummCalcstage1Year()
            SummCalcstage2Year()

        End If
      
        ' MonthYearBreakdowncalculation()
        'If txtKernelYear.Enabled = False And Val(txtKernelYear.Text) > 0 Then
        '    txtKernelYear.Text = Format(Val(txtKernelYear.Text), "0.000")
        'End If

    End Sub

    Private Sub txtEffectiveProcessingHoursMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEffectiveProcessingHoursMonth.TextChanged
        If Val(txtKernelMonth.Text) <> 0 And txtEffectiveProcessingHoursMonth.Text <> "00:00" And txtEffectiveProcessingHoursMonth.Text <> "" Then

            Dim Hrs As Integer
            Dim Min As Integer
            Dim Minstr As String
            Dim str As String
            Dim strArr() As String
            Dim Effect As Decimal
            str = txtEffectiveProcessingHoursMonth.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            If strArr(1) <> "00" Then
                Min = Math.Round(strArr(1) / 60, 2) * 100
            End If
            Minstr = "." + Convert.ToString(Min)

            Effect = Convert.ToString(Hrs) + Minstr
            txtThroughputMonthTodate.Text = Math.Round((Val(txtKernelMonth.Text) / Effect), 2)
        Else
            txtThroughputMonthTodate.Text = ""
        End If

        If Val(txtPKOProductionMonthTodate.Text) <> 0 And Val(txtKernelMonth.Text) <> 0 Then
            txtKERMonth.Text = Math.Round((Val(txtPKOProductionMonthTodate.Text) * 100 / (Val(txtKernelMonth.Text) - Val(txtLossOnKernelMonth.Text))), 2)
        Else
            txtKERMonth.Text = ""
        End If


    End Sub

    Private Sub txtEffectiveProcessingHoursYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEffectiveProcessingHoursYear.TextChanged
        If Val(txtKernelYear.Text) <> 0 And txtEffectiveProcessingHoursYear.Text <> "00:00" And txtEffectiveProcessingHoursYear.Text <> "" Then
            Dim Hrs As Integer
            Dim Min As Integer
            Dim Minstr As String
            Dim str As String
            Dim strArr() As String
            Dim Effect As Decimal
            str = txtEffectiveProcessingHoursYear.Text
            strArr = str.Split(":")
            Hrs = strArr(0)
            If strArr(1) <> "00" Then
                Min = Math.Round(strArr(1) / 60, 2) * 100
            End If
            Minstr = "." + Convert.ToString(Min)

            Effect = Convert.ToString(Hrs) + Minstr
            txtThroughputYear.Text = Math.Round((Val(txtKernelYear.Text) / Effect), 2)
        Else
            txtThroughputYear.Text = 0
        End If

    End Sub

    Private Function ToModifyTime(ByVal ModifyTime As String)
        Dim Hrs As String = "00"
        Dim Min As String = "00"
        Dim str As String
        Dim strArr() As String
        str = ModifyTime
        strArr = str.Split(":")
        If strArr(0).Length = 1 Then
            Hrs = "0" + strArr(0)
        Else
            Hrs = strArr(0)
        End If
        Min = strArr(1)
        ModifyTime = Hrs + ":" + Min
        Return ModifyTime
    End Function

    Private Sub txtKernelProcessedMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessedMonth.TextChanged
        If txtKernelProcessedMonth.Enabled = False Or lbtnsaveall <> "Save All" Then
            txtKernelMonth.Text = txtKernelProcessedMonth.Text
        Else
            txtKernelMonth.Text = ""
        End If

        If txtKernelProcessedMonth.Enabled = False And Val(txtKernelProcessedMonth.Text) > 0 Then
            txtKernelProcessedMonth.Text = Format(Val(txtKernelProcessedMonth.Text), "0.000")
        End If

    End Sub

    Private Sub txtKernelProcessedYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKernelProcessedYear.TextChanged
        If txtKernelProcessedYear.Enabled = False Or lbtnsaveall <> "Save All" Then
            txtKernelYear.Text = txtKernelProcessedYear.Text
        Else
            txtKernelYear.Text = ""
        End If
        If txtKernelProcessedYear.Enabled = False And Val(txtKernelProcessedYear.Text) > 0 Then
            txtKernelProcessedYear.Text = Format(Val(txtKernelProcessedYear.Text), "0.000")
        End If
      
    End Sub

    Private Sub txtPKOProductionMonthTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOProductionMonthTodate.TextChanged
        If Val(txtPKOProductionMonthTodate.Text) <> 0 And Val(txtKernelMonth.Text) <> 0 Then
            txtKERMonth.Text = Math.Round((Val(txtPKOProductionMonthTodate.Text) * 100 / (Val(txtKernelMonth.Text) - Val(txtLossOnKernelMonth.Text))), 2)
        Else
            txtKERMonth.Text = 0
        End If
        If txtKERMonth.Enabled = False And Val(txtKERMonth.Text) > 0 Then
            txtKERMonth.Text = Format(Val(txtKERMonth.Text), "0.000")
        End If
    End Sub

    Private Sub txtKERToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKERToday.TextChanged
        If Val(txtKERToday.Text) > 0 Then
            txtKERToday.Text = Format(Val(txtKERToday.Text), "0.00")
        End If

    End Sub

    Private Sub txtKERMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKERMonth.TextChanged
        If Val(txtKERMonth.Text) > 0 Then
            txtKERMonth.Text = Format(Val(txtKERMonth.Text), "0.00")
        End If

    End Sub

    Private Sub txtKERYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKERYear.TextChanged
        If Val(txtKERYear.Text) > 0 Then
            txtKERYear.Text = Format(Val(txtKERYear.Text), "0.00")
        End If

    End Sub

    Private Sub txtTodateMtRecKer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTodateMtRecKer.TextChanged
        If Val(txtTodateMtRecKer.Text) = 0 Then
            txtTodateMtRecKer.Text = ""
        End If
    End Sub

    Private Sub txtYearTodateRecKer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtYearTodateRecKer.TextChanged
        If Val(txtYearTodateRecKer.Text) = 0 Then
            txtYearTodateRecKer.Text = ""
        End If
    End Sub

    Private Sub txtLossOnKernelToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLossOnKernelToday.TextChanged
        'If Val(txtLossOnKernelToday.Text) = 0 Then
        '    txtLossOnKernelToday.Text = ""
        'End If
        If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
            'txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / (Val(txtKerneltoday.Text) - Val(txtLossOnKernelToday.Text))), 2)
            txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) / Val(txtKerneltoday.Text)) * 100, 2)
        Else
            txtKERToday.Text = ""
        End If
    End Sub

    Private Sub txtLossOnKernelMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLossOnKernelMonth.Leave

        If Val(txtLossOnKernelMonth.Text) > Val(txtKernelMonth.Text) Then
            DisplayInfoMessage("Msg102")
            Exit Sub
        End If

    End Sub

    Private Sub txtLossOnKernelMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLossOnKernelMonth.TextChanged

        If Val(txtLossOnKernelMonth.Text) > 0 And txtLossOnKernelMonth.Enabled = False Then
            txtLossOnKernelMonth.Text = Format(Val(txtLossOnKernelMonth.Text), "0.000")
        End If

        If Val(txtPKOProductionMonthTodate.Text) <> 0 And Val(txtKernelMonth.Text) <> 0 Then
            txtKERMonth.Text = Math.Round((Val(txtPKOProductionMonthTodate.Text) * 100 / (Val(txtKernelMonth.Text) - Val(txtLossOnKernelMonth.Text))), 2)
        Else
            txtKERMonth.Text = ""
        End If

    End Sub

    Private Sub txtLossOnKernelYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLossOnKernelYear.Leave
        If Val(txtLossOnKernelYear.Text) > Val(txtKernelYear.Text) Then
            DisplayInfoMessage("Msg103")
            Exit Sub
        End If
    End Sub

    Private Sub txtLossOnKernelYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLossOnKernelYear.TextChanged
        If Val(txtLossOnKernelYear.Text) > 0 And txtLossOnKernelYear.Enabled = False Then
            txtLossOnKernelYear.Text = Format(Val(txtLossOnKernelYear.Text), "0.000")
        End If


        If Val(txtPKOProductionYear.Text) <> 0 And Val(txtKernelYear.Text) <> 0 Then
            txtKERYear.Text = Math.Round((Val(txtPKOProductionYear.Text) * 100 / (Val(txtKernelYear.Text) - Val(txtLossOnKernelYear.Text))), 2)
        Else
            txtKERYear.Text = ""
        End If

    End Sub

    Private Sub txtAgeOfScrew_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAgeOfScrew.Leave
        If txtAgeOfScrew.Text <> "" Then
            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtAgeOfScrew.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM format")
                txtAgeOfScrew.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            Else
                Hrs = strArr(0)
            End If



            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    '' MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                End If

                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                End If

                'If strArr(0) > 24 Or (strArr(0) = 24 And strArr(1) > 0) Then
                '    MessageBox.Show("Op Hrs cant be greater than 24 hrs")
                '    txtAgeOfScrew.Focus()
                '    Exit Sub

                'End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                ElseIf Len(strArr(1)) > 2 Then
                    DisplayInfoMessage("Msg88")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 100 ")
                    txtAgeOfScrew.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtAgeOfScrew.Text = Hrs + ":" + Min
        End If
    End Sub

    Private Sub txtAgeOfScrew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAgeOfScrew.TextChanged
        If txtAgeOfScrew.Text <> "" Then
            Dim Value As String = txtAgeOfScrew.Text
            Dim strlen As Integer
            strlen = Len(txtAgeOfScrew.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtAgeOfScrew.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    ''MsgBox("Please Enter numeric values only")
                    txtAgeOfScrew.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtMechanicalBreakDownMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMechanicalBreakDownMonth.Leave
        If txtMechanicalBreakDownMonth.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMechanicalBreakDownMonth.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMechanicalBreakDownMonth.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMechanicalBreakDownMonth.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMechanicalBreakDownMonth.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMechanicalBreakDownMonth.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    '' MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMechanicalBreakDownMonth.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMechanicalBreakDownMonth.Text = Hrs + ":" + Min
        End If
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownMonth.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownMonth.Text
        End If
        If txtElectricalBreakDownMonth.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownMonth.Text
        End If
        If txtProcessingBreakDownMonth.Text <> "" Then
            lProcessBK = txtProcessingBreakDownMonth.Text
        End If


        lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If (txtMechanicalBreakDownMonth.Text <> "" Or txtElectricalBreakDownMonth.Text <> "" Or txtProcessingBreakDownMonth.Text <> "") Then
            txtTotalBreakDownMonth.Text = lBDCalculation
        Else
            txtTotalBreakDownMonth.Text = ""
        End If

     
        If txtTotalBreakDownMonth.Text <> String.Empty And txtTotalBreakDownMonth.Text <> "00:00" And txtMonthTodateHrs.Text <> String.Empty And txtMonthTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer

            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If
            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg99")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                ' txtMechanicalBreakDownMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg99")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                ' txtMechanicalBreakDownMonth.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtTotalHours.Text <> String.Empty And txtTotalBreakDownMonth.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtTotalHours.Text) - TimeSpan.Parse(txtTotalBreakDownMonth.Text)
            '    txtEffectiveProcessingHoursMonth.Text = Convert.ToString(lEffectiveHrs)
        End If

        

    End Sub

    Private Sub txtMechanicalBreakDownMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMechanicalBreakDownMonth.TextChanged
        If txtMechanicalBreakDownMonth.Enabled = True Then
            If txtMechanicalBreakDownToday.Text <> "" Then
                Dim Value As String = txtMechanicalBreakDownMonth.Text
                Dim strlen As Integer
                strlen = Len(txtMechanicalBreakDownMonth.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtMechanicalBreakDownMonth.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg97")
                        ''MsgBox("Please enter only numeric  values")
                        txtMechanicalBreakDownMonth.Focus()
                    End If

                Next
            End If
        
        End If

    End Sub
    Private Sub MonthYearBreakdowncalculation()
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownMonth.Enabled = False Then
            If txtMechanicalBreakDownToday.Text <> "" And txtMechanicalBreakDownToday.Text <> "00:00" Then
                txtMechanicalBreakDownMonth.Text = ToaddHours(lMechanicalBreakDownMonth, txtMechanicalBreakDownToday.Text)
                txtMechanicalBreakDownYear.Text = ToaddHours(lMechanicalBreakDownYear, txtMechanicalBreakDownToday.Text)
            Else
                txtMechanicalBreakDownMonth.Text = lMechanicalBreakDownMonth
                txtMechanicalBreakDownYear.Text = lMechanicalBreakDownYear

            End If
        End If
        If txtElectricalBreakDownMonth.Enabled = False Then
            If txtElectricalBreakDownToday.Text <> "" And txtElectricalBreakDownToday.Text <> "00:00" Then
                txtElectricalBreakDownMonth.Text = ToaddHours(lElectricalBreakDownMonth, txtElectricalBreakDownToday.Text)
                txtElectricalBreakDownYear.Text = ToaddHours(lElectricalBreakDownYear, txtElectricalBreakDownToday.Text)
            Else
                txtElectricalBreakDownMonth.Text = lElectricalBreakDownMonth
                txtElectricalBreakDownYear.Text = lElectricalBreakDownYear

            End If
        End If

        If txtProcessingBreakDownMonth.Enabled = False Then
            If txtProcessingBreakDownToday.Text <> "" And txtProcessingBreakDownToday.Text <> "00:00" Then
                txtProcessingBreakDownMonth.Text = ToaddHours(lProcessingBreakDownMonth, txtProcessingBreakDownToday.Text)
                txtProcessingBreakDownYear.Text = ToaddHours(lProcessingBreakDownYear, txtProcessingBreakDownToday.Text)
            Else
                txtProcessingBreakDownMonth.Text = lProcessingBreakDownMonth
                txtProcessingBreakDownYear.Text = lProcessingBreakDownYear

            End If
        End If

        If txtMechanicalBreakDownMonth.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownMonth.Text
        End If
        If txtElectricalBreakDownMonth.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownMonth.Text
        End If
        If txtProcessingBreakDownMonth.Text <> "" Then
            lProcessBK = txtProcessingBreakDownMonth.Text
        End If


        lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If (txtMechanicalBreakDownMonth.Text <> "" Or txtElectricalBreakDownMonth.Text <> "" Or txtProcessingBreakDownMonth.Text <> "") Then
            txtTotalBreakDownMonth.Text = lBDCalculation
        Else
            txtTotalBreakDownMonth.Text = ""
        End If

        

        Dim lBDCalculationYr As String = "00:00"
        Dim lMechaniclBDYr As String = "00:00"
        Dim lelectriclBDYr As String = "00:00"
        Dim lProcessBKYr As String = "00:00"

        If txtMechanicalBreakDownYear.Text <> "" Then
            lMechaniclBDYr = txtMechanicalBreakDownYear.Text
        End If
        If txtElectricalBreakDownYear.Text <> "" Then
            lelectriclBDYr = txtElectricalBreakDownYear.Text
        End If
        If txtProcessingBreakDownYear.Text <> "" Then
            lProcessBKYr = txtProcessingBreakDownYear.Text
        End If


        lBDCalculationYr = ToaddHours(lMechaniclBDYr, lelectriclBDYr)
        lBDCalculationYr = ToaddHours(lBDCalculationYr, lProcessBKYr)


        If (txtMechanicalBreakDownYear.Text <> "" Or txtElectricalBreakDownYear.Text <> "" Or txtProcessingBreakDownYear.Text <> "") Then
            txtTotalBreakDownYear.Text = lBDCalculationYr
        Else
            txtTotalBreakDownYear.Text = ""
        End If
    End Sub

    Private Sub txtElectricalBreakDownMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtElectricalBreakDownMonth.Leave
        If txtElectricalBreakDownMonth.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtElectricalBreakDownMonth.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtElectricalBreakDownMonth.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtElectricalBreakDownMonth.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtElectricalBreakDownMonth.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtElectricalBreakDownMonth.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtElectricalBreakDownMonth.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtElectricalBreakDownMonth.Text = Hrs + ":" + Min
        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownMonth.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownMonth.Text
        End If
        If txtElectricalBreakDownMonth.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownMonth.Text
        End If
        If txtProcessingBreakDownMonth.Text <> "" Then
            lProcessBK = txtProcessingBreakDownMonth.Text
        End If


        lBDCalculation = ToaddHours(lMechaniclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lelectriclBD)

        If (txtMechanicalBreakDownMonth.Text <> "" Or txtElectricalBreakDownMonth.Text <> "" Or txtProcessingBreakDownMonth.Text <> "") Then
            txtTotalBreakDownMonth.Text = lBDCalculation
        Else
            txtTotalBreakDownMonth.Text = ""
        End If

        If txtTotalBreakDownMonth.Text <> String.Empty And txtTotalBreakDownMonth.Text <> "00:00" And txtMonthTodateHrs.Text <> String.Empty And txtMonthTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg99")
                ''MsgBox(" Month BreakDown hours should be lesser than Month To Date hours")
                '  txtElectricalBreakDownMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg99")
                ''MsgBox(" Month BreakDown hours should be lesser than Month To Date hours")
                ' txtElectricalBreakDownMonth.Focus()
                Exit Sub
            End If
        End If
        '  Dim lEffectiveHrs As TimeSpan

        

    End Sub

    Private Sub txtElectricalBreakDownMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElectricalBreakDownMonth.TextChanged
        If txtElectricalBreakDownMonth.Enabled = True Then
            If txtElectricalBreakDownMonth.Text <> "" Then
                Dim Value As String = txtElectricalBreakDownMonth.Text
                Dim strlen As Integer
                strlen = Len(txtElectricalBreakDownMonth.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtElectricalBreakDownMonth.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg97")
                        ''MsgBox("Please enter only numeric  values")
                        txtElectricalBreakDownMonth.Focus()
                    End If

                Next
            End If
       
        End If

    End Sub

    Private Sub txtProcessingBreakDownMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcessingBreakDownMonth.Leave
        If txtProcessingBreakDownMonth.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtProcessingBreakDownMonth.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtProcessingBreakDownMonth.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtProcessingBreakDownMonth.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtProcessingBreakDownMonth.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtProcessingBreakDownMonth.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtProcessingBreakDownMonth.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtProcessingBreakDownMonth.Text = Hrs + ":" + Min

        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownMonth.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownMonth.Text
        End If
        If txtElectricalBreakDownMonth.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownMonth.Text
        End If
        If txtProcessingBreakDownMonth.Text <> "" Then
            lProcessBK = txtProcessingBreakDownMonth.Text
        End If


        lBDCalculation = ToaddHours(lMechaniclBD, lelectriclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lProcessBK)


        If (txtMechanicalBreakDownMonth.Text <> "" Or txtElectricalBreakDownMonth.Text <> "" Or txtProcessingBreakDownMonth.Text <> "") Then
            txtTotalBreakDownMonth.Text = lBDCalculation
        Else
            txtTotalBreakDownMonth.Text = ""
        End If


        If txtTotalBreakDownMonth.Text <> String.Empty And txtTotalBreakDownMonth.Text <> "00:00" And txtMonthTodateHrs.Text <> String.Empty And txtMonthTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg99")
                '' MsgBox(" Month BreakDown hours should be lesser than Month To Date hours")
                '  txtProcessingBreakDownMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                ' MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                txtProcessingBreakDownMonth.Focus()
                Exit Sub
            End If
        End If
        ' Dim lEffectiveHrs As TimeSpan



    End Sub

    Private Sub txtProcessingBreakDownMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessingBreakDownMonth.TextChanged
        If txtProcessingBreakDownMonth.Enabled = True Then
            If txtProcessingBreakDownMonth.Text <> "" Then
                Dim Value As String = txtProcessingBreakDownMonth.Text
                Dim strlen As Integer
                strlen = Len(txtProcessingBreakDownMonth.Text)
                Dim allowedChars As String = "0123456789:"
                For i As Integer = Value.Length - 1 To 0 Step -1
                    If allowedChars.IndexOf(Value(i)) = -1 Then
                        txtProcessingBreakDownMonth.Text = Value.Substring(0, strlen - 1)
                        DisplayInfoMessage("Msg97")
                        ''MsgBox("Please enter only numeric  values")
                        txtProcessingBreakDownMonth.Focus()
                    End If

                Next
            End If
        End If

    End Sub

    Private Sub txtMechanicalBreakDownYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMechanicalBreakDownYear.Leave
        If txtMechanicalBreakDownYear.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtMechanicalBreakDownYear.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtMechanicalBreakDownYear.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtMechanicalBreakDownYear.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtMechanicalBreakDownYear.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    '' MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtMechanicalBreakDownYear.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtMechanicalBreakDownYear.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtMechanicalBreakDownYear.Text = Hrs + ":" + Min
        End If
        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownYear.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownYear.Text
        End If
        If txtElectricalBreakDownYear.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownYear.Text
        End If
        If txtProcessingBreakDownYear.Text <> "" Then
            lProcessBK = txtProcessingBreakDownYear.Text
        End If


        lBDCalculation = ToaddHours(lelectriclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lMechaniclBD)

        If (txtMechanicalBreakDownYear.Text <> "" Or txtElectricalBreakDownYear.Text <> "" Or txtProcessingBreakDownYear.Text <> "") Then
            txtTotalBreakDownYear.Text = lBDCalculation
        Else
            txtTotalBreakDownYear.Text = ""
        End If


        If txtTotalBreakDownYear.Text <> String.Empty And txtTotalBreakDownYear.Text <> "00:00" And txtYearTodateHrs.Text <> String.Empty And txtYearTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If


            If Lhrs < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                ' txtMechanicalBreakDownYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                '  txtMechanicalBreakDownYear.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtTotalHours.Text <> String.Empty And txtTotalBreakDownYear.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtTotalHours.Text) - TimeSpan.Parse(txtTotalBreakDownYear.Text)
            '    txtEffectiveProcessingHoursYear.Text = Convert.ToString(lEffectiveHrs)
        End If



    End Sub


    Private Sub txtMechanicalBreakDownYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMechanicalBreakDownYear.TextChanged
        If txtMechanicalBreakDownToday.Text <> "" And txtMechanicalBreakDownToday.Enabled = True Then
            Dim Value As String = txtMechanicalBreakDownToday.Text
            Dim strlen As Integer
            strlen = Len(txtMechanicalBreakDownToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtMechanicalBreakDownToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    ''MsgBox("Please enter only numeric  values")
                    txtMechanicalBreakDownToday.Focus()
                End If
            Next
        End If

    End Sub

    Private Sub txtElectricalBreakDownYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtElectricalBreakDownYear.Leave
        If txtElectricalBreakDownYear.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtElectricalBreakDownYear.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                ''MessageBox.Show("User Can enter only HH or HH:MM ")
                txtElectricalBreakDownYear.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    '' MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtElectricalBreakDownYear.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtElectricalBreakDownYear.Focus()
                    Exit Sub
                End If

                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtElectricalBreakDownYear.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtElectricalBreakDownYear.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtElectricalBreakDownYear.Text = Hrs + ":" + Min
        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownYear.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownYear.Text
        End If
        If txtElectricalBreakDownYear.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownYear.Text
        End If
        If txtProcessingBreakDownYear.Text <> "" Then
            lProcessBK = txtProcessingBreakDownYear.Text
        End If


        lBDCalculation = ToaddHours(lMechaniclBD, lProcessBK)
        lBDCalculation = ToaddHours(lBDCalculation, lelectriclBD)

        If (txtMechanicalBreakDownYear.Text <> "" Or txtElectricalBreakDownYear.Text <> "" Or txtProcessingBreakDownYear.Text <> "") Then
            txtTotalBreakDownYear.Text = lBDCalculation
        Else
            txtTotalBreakDownYear.Text = ""
        End If

        If txtTotalBreakDownYear.Text <> String.Empty And txtTotalBreakDownYear.Text <> "00:00" And txtYearTodateHrs.Text <> String.Empty And txtYearTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                ' txtElectricalBreakDownYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                ' txtElectricalBreakDownYear.Focus()
                Exit Sub
            End If
        End If
        '  Dim lEffectiveHrs As TimeSpan


    End Sub

    Private Sub txtElectricalBreakDownYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtElectricalBreakDownYear.TextChanged
        If txtElectricalBreakDownToday.Text <> "" And txtElectricalBreakDownToday.Enabled = True Then
            Dim Value As String = txtElectricalBreakDownToday.Text
            Dim strlen As Integer
            strlen = Len(txtElectricalBreakDownToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtElectricalBreakDownToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    ''MsgBox("Please enter only numeric  values")
                    txtElectricalBreakDownToday.Focus()
                End If

            Next
        End If
    End Sub

    Private Sub txtProcessingBreakDownYear_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProcessingBreakDownYear.Leave
        If txtProcessingBreakDownYear.Text <> "" Then


            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            'Dim count As Integer
            str = txtProcessingBreakDownYear.Text
            strArr = str.Split(":")

            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg1")
                '' MessageBox.Show("User Can enter only HH or HH:MM ")
                txtProcessingBreakDownYear.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If strArr.Count = 2 Then
                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg1")
                    ''MessageBox.Show("User Can enter only HH or HH:MM ")
                    txtProcessingBreakDownYear.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtProcessingBreakDownYear.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtProcessingBreakDownYear.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtProcessingBreakDownYear.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If
            txtProcessingBreakDownYear.Text = Hrs + ":" + Min

        End If

        Dim lBDCalculation As String = "00:00"
        Dim lMechaniclBD As String = "00:00"
        Dim lelectriclBD As String = "00:00"
        Dim lProcessBK As String = "00:00"

        If txtMechanicalBreakDownYear.Text <> "" Then
            lMechaniclBD = txtMechanicalBreakDownYear.Text
        End If
        If txtElectricalBreakDownYear.Text <> "" Then
            lelectriclBD = txtElectricalBreakDownYear.Text
        End If
        If txtProcessingBreakDownYear.Text <> "" Then
            lProcessBK = txtProcessingBreakDownYear.Text
        End If


        lBDCalculation = ToaddHours(lMechaniclBD, lelectriclBD)
        lBDCalculation = ToaddHours(lBDCalculation, lProcessBK)


        If (txtMechanicalBreakDownYear.Text <> "" Or txtElectricalBreakDownYear.Text <> "" Or txtProcessingBreakDownYear.Text <> "") Then
            txtTotalBreakDownYear.Text = lBDCalculation
        Else
            txtTotalBreakDownYear.Text = ""
        End If


        If txtTotalBreakDownYear.Text <> String.Empty And txtTotalBreakDownYear.Text <> "00:00" And txtYearTodateHrs.Text <> String.Empty And txtYearTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox(" Year BreakDown hours should be lesser than Year To Date hours")
                '  txtProcessingBreakDownYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                '   txtProcessingBreakDownYear.Focus()
                Exit Sub
            End If
        End If

        ' Dim lEffectiveHrs As TimeSpan

   


    End Sub

    Private Sub txtProcessingBreakDownYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProcessingBreakDownYear.TextChanged
        If txtProcessingBreakDownToday.Text <> "" And txtProcessingBreakDownToday.Enabled = True Then
            Dim Value As String = txtProcessingBreakDownToday.Text
            Dim strlen As Integer
            strlen = Len(txtProcessingBreakDownToday.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtProcessingBreakDownToday.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg97")
                    '' MsgBox("Please enter only numeric  values")
                    txtProcessingBreakDownToday.Focus()
                End If

            Next
        End If
    End Sub

    Private Sub txtTotalBreakDownMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalBreakDownMonth.TextChanged
        If txtTotalBreakDownMonth.Text <> String.Empty And txtTotalBreakDownMonth.Text <> "00:00" And txtMonthTodateHrs.Text <> String.Empty And txtMonthTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtMonthTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownMonth.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer



            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg99")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                '  txtMechanicalBreakDownMonth.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg99")
                ''MsgBox("Month BreakDown hours should be lesser than Month To Date hours")
                ' txtMechanicalBreakDownMonth.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtTotalHours.Text <> String.Empty And txtTotalBreakDownMonth.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtTotalHours.Text) - TimeSpan.Parse(txtTotalBreakDownMonth.Text)
            '    txtEffectiveProcessingHoursMonth.Text = Convert.ToString(lEffectiveHrs)
        End If


        If txtTotalBreakDownMonth.Text <> String.Empty And txtMonthTodateHrs.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr4(), strArr3() As String
            Dim Str4, Str3 As String
            Str4 = txtMonthTodateHrs.Text
            strArr4 = Str4.Split(":")
            Str3 = txtTotalBreakDownMonth.Text
            strArr3 = Str3.Split(":")

            Dim Lhrs2, lmin2 As Integer


            Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
            lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

            If lmin2 < 0 Then
                lmin2 = lmin2 + 60
                Lhrs2 = Lhrs2 - 1
            End If
            Dim Strhrs2 As String = "00"
            Dim StrMin2 As String = "00"


            If Lhrs2 < 10 Then
                Strhrs2 = "0" + Convert.ToString(Lhrs2)
            Else
                Strhrs2 = Lhrs2
            End If

            If lmin2 < 10 Then
                StrMin2 = "0" + Convert.ToString(lmin2)
            Else
                StrMin2 = lmin2
            End If

            txtEffectiveProcessingHoursMonth.Text = Strhrs2 + ":" + StrMin2
        ElseIf txtMonthTodateHrs.Text <> "" Or txtMonthTodateHrs.Text <> "00:00" Then
            txtEffectiveProcessingHoursMonth.Text = txtMonthTodateHrs.Text
        Else
            txtEffectiveProcessingHoursMonth.Text = "00:00"
        End If


        Dim lEffectiveHrsDec As Decimal
        If txtEffectiveProcessingHoursMonth.Text <> "" And txtEffectiveProcessingHoursMonth.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEffectiveProcessingHoursMonth.Text
            strArr3 = str3.Split(":")
            Hrs1 = CInt(strArr3(0))
            Min1 = CInt(strArr3(1))

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1
        End If

        If Val(txtKernelMonth.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtThroughputMonthTodate.Text = Math.Round((Val(txtKernelMonth.Text) / lEffectiveHrsDec), 2)
        Else
            txtThroughputMonthTodate.Text = ""
        End If

        If Val(txtPKOProductionMonthTodate.Text) <> 0 And Val(txtKernelMonth.Text) <> 0 Then
            txtKERMonth.Text = Math.Round((Val(txtPKOProductionMonthTodate.Text) * 100 / (Val(txtKernelMonth.Text) - Val(txtLossOnKernelMonth.Text))), 2)
        Else
            txtKERMonth.Text = ""
        End If

    End Sub

    Private Sub txtTotalBreakDownYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalBreakDownYear.TextChanged
        If txtTotalBreakDownYear.Text <> String.Empty And txtTotalBreakDownYear.Text <> "00:00" And txtYearTodateHrs.Text <> String.Empty And txtYearTodateHrs.Text <> "00:00" Then
            'Dim ProcessHrs As String
            Dim strArr2(), strArr1() As String
            Dim Str2, Str1 As String
            Str2 = txtYearTodateHrs.Text
            strArr2 = Str2.Split(":")
            Str1 = txtTotalBreakDownYear.Text
            strArr1 = Str1.Split(":")

            Dim Lhrs, lmin As Integer


            Lhrs = CInt(strArr2(0)) - CInt(strArr1(0))
            lmin = CInt(strArr2(1)) - CInt(strArr1(1))

            If lmin < 0 Then
                lmin = lmin + 60
                Lhrs = Lhrs - 1
            End If

            'Dim Strhrs As String = "00"
            'Dim StrMin As String = "00"

            If Lhrs < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                '  txtMechanicalBreakDownYear.Focus()
                Exit Sub
            ElseIf Lhrs = 0 And lmin < 0 Then
                DisplayInfoMessage("Msg100")
                ''MsgBox("Year BreakDown hours should be lesser than Year To Date hours")
                ' txtMechanicalBreakDownYear.Focus()
                Exit Sub
            End If

            'Dim lEffectiveHrs As TimeSpan
            'If txtTotalHours.Text <> String.Empty And txtTotalBreakDownYear.Text <> String.Empty Then
            '    lEffectiveHrs = TimeSpan.Parse(txtTotalHours.Text) - TimeSpan.Parse(txtTotalBreakDownYear.Text)
            '    txtEffectiveProcessingHoursYear.Text = Convert.ToString(lEffectiveHrs)
        End If
        If txtTotalBreakDownYear.Text <> String.Empty And txtYearTodateHrs.Text <> String.Empty Then
            'Dim ProcessHrs As String
            Dim strArr4(), strArr3() As String
            Dim Str4, Str3 As String
            Str4 = txtYearTodateHrs.Text
            strArr4 = Str4.Split(":")
            Str3 = txtTotalBreakDownYear.Text
            strArr3 = Str3.Split(":")

            Dim Lhrs2, lmin2 As Integer


            Lhrs2 = CInt(strArr4(0)) - CInt(strArr3(0))
            lmin2 = CInt(strArr4(1)) - CInt(strArr3(1))

            If lmin2 < 0 Then
                lmin2 = lmin2 + 60
                Lhrs2 = Lhrs2 - 1
            End If
            Dim Strhrs2 As String = "00"
            Dim StrMin2 As String = "00"


            If Lhrs2 < 10 Then
                Strhrs2 = "0" + Convert.ToString(Lhrs2)
            Else
                Strhrs2 = Lhrs2
            End If

            If lmin2 < 10 Then
                StrMin2 = "0" + Convert.ToString(lmin2)
            Else
                StrMin2 = lmin2
            End If

            txtEffectiveProcessingHoursYear.Text = Strhrs2 + ":" + StrMin2
        ElseIf txtYearTodateHrs.Text <> "" Or txtYearTodateHrs.Text <> "00:00" Then
            txtEffectiveProcessingHoursYear.Text = txtYearTodateHrs.Text
        Else
            txtEffectiveProcessingHoursYear.Text = "00:00"

        End If

        Dim lEffectiveHrsDec As Decimal
        If txtEffectiveProcessingHoursYear.Text <> "" And txtEffectiveProcessingHoursYear.Text <> "00:00" Then

            Dim Hrs1 As Integer
            Dim Min1 As Integer
            Dim str3 As String
            Dim strArr3() As String
            'Dim count As Integer
            str3 = txtEffectiveProcessingHoursYear.Text
            strArr3 = str3.Split(":")
            Hrs1 = strArr3(0)
            Min1 = strArr3(1)

            Min1 = (Min1 / 60) * 100
            Dim lmin1 As String
            lmin1 = "." + Convert.ToString(Min1)

            lEffectiveHrsDec = Hrs1 + lmin1


        End If



        If Val(txtKernelYear.Text) <> 0 And lEffectiveHrsDec > 0 Then

            txtThroughputYear.Text = Math.Round((Val(txtKernelYear.Text) / lEffectiveHrsDec), 2)
        Else
            txtThroughputYear.Text = ""
        End If


        If Val(txtPKOProductionYear.Text) <> 0 And Val(txtKernelYear.Text) <> 0 Then
            txtKERYear.Text = Math.Round((Val(txtPKOProductionYear.Text) * 100 / (Val(txtKernelYear.Text) - Val(txtLossOnKernelYear.Text))), 2)
        Else
            txtKERYear.Text = ""
        End If

    End Sub

    Private Sub txtAPTstage1today_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage1today.TextChanged
        If Val(txtAPTstage1today.Text) <> 0 Then
            txtAPTstage1today.Text = Format(Val(txtAPTstage1today.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPHstage1monthtodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPHstage1monthtodate.TextChanged
        If Val(txtAPHstage1monthtodate.Text) <> 0 Then
            txtAPHstage1monthtodate.Text = Format(Val(txtAPHstage1monthtodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage1yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage1yeartodate.TextChanged
        If Val(txtAPTstage1yeartodate.Text) <> 0 Then
            txtAPTstage1yeartodate.Text = Format(Val(txtAPTstage1yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage2today_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage2today.TextChanged
        If Val(txtAPTstage2today.Text) <> 0 Then
            txtAPTstage2today.Text = Format(Val(txtAPTstage2today.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTstage2monthtodae_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTstage2monthtodae.TextChanged
        If Val(txtAPTstage2monthtodae.Text) <> 0 Then
            txtAPTstage2monthtodae.Text = Format(Val(txtAPTstage2monthtodae.Text), "0.00")
        End If
    End Sub

    Private Sub txtAPTStage2yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAPTStage2yeartodate.TextChanged
        If Val(txtAPTStage2yeartodate.Text) <> 0 Then
            txtAPTStage2yeartodate.Text = Format(Val(txtAPTStage2yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage1today_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage1today.TextChanged
        If Val(txtutilstage1today.Text) <> 0 Then
            txtutilstage1today.Text = Format(Val(txtutilstage1today.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage1monthtodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage1monthtodate.TextChanged
        If Val(txtutilstage1monthtodate.Text) <> 0 Then
            txtutilstage1monthtodate.Text = Format(Val(txtutilstage1monthtodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage1yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage1yeartodate.TextChanged
        If Val(txtutilstage1yeartodate.Text) <> 0 Then
            txtutilstage1yeartodate.Text = Format(Val(txtutilstage1yeartodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage2.TextChanged
        If Val(txtutilstage2.Text) <> 0 Then
            txtutilstage2.Text = Format(Val(txtutilstage2.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage2monthtodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage2monthtodate.TextChanged
        If Val(txtutilstage2monthtodate.Text) <> 0 Then
            txtutilstage2monthtodate.Text = Format(Val(txtutilstage2monthtodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtutilstage2yeartodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtutilstage2yeartodate.TextChanged
        If Val(txtutilstage2yeartodate.Text) <> 0 Then
            txtutilstage2yeartodate.Text = Format(Val(txtutilstage2yeartodate.Text), "0.00")
        End If
    End Sub


    Private Sub txtThroughput_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtThroughput.TextChanged
        If Val(txtThroughput.Text) <> 0 Then
            txtThroughput.Text = Format(Val(txtThroughput.Text), "0.00")
        End If
    End Sub

    Private Sub txtThroughputMonthTodate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtThroughputMonthTodate.TextChanged
        If Val(txtThroughputMonthTodate.Text) <> 0 Then
            txtThroughputMonthTodate.Text = Format(Val(txtThroughputMonthTodate.Text), "0.00")
        End If
    End Sub

    Private Sub txtThroughputYear_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtThroughputYear.TextChanged
        If Val(txtThroughputYear.Text) <> 0 Then
            txtThroughputYear.Text = Format(Val(txtThroughputYear.Text), "0.00")
        End If
    End Sub

    Private Sub btnDeleteAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteAll.Click
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        Dim objPKOProductionLogBOL As New PKOProductionLogBOL

        objPKOProductionLogPPT.PKOProductionLogID = lPKOProductionLogID
        objPKOProductionLogBOL.DeleteProductionPKOLog(objPKOProductionLogPPT)
        BindDataGrid()
        clear()
        ClearReceivedKernelGB()
        ClearLogExpress()
        ClearGridView(dgvReceivedKernel)
        ClearGridView(dgPressInfo)
        ClearShift()
        ClearGridView(dgvPKOLogShiftDetails)



    End Sub


    Private Sub DeletePressInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePressInfo.Click
        If dgPressInfo.RowCount = 0 Then
            Exit Sub
        ElseIf dgPressInfo.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg911")
            Exit Sub
        Else
            DeleteMultientrydatagridPressInfo()
        End If
    End Sub
    Private Sub DeleteMultientrydatagridPressInfo()

        If Not dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value Is Nothing Then
            lProductionLogPressID = dgPressInfo.SelectedRows(0).Cells("dgMeProductionLogPressID").Value.ToString
        Else
            lProductionLogPressID = String.Empty
        End If

        lDelete = 0
        If lProductionLogPressID <> "" Then
            lDelete = DeleteMultientryPressInfo.Count

            DeleteMultientryPressInfo.Insert(lDelete, lProductionLogPressID)

            ' lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtPressInfo.Rows.Item(dgPressInfo.CurrentRow.Index)
        Dr.Delete()
        dtPressInfo.AcceptChanges()
        lProductionLogPressID = ""
        TPH()

    End Sub

    Private Sub DeleteMultiEntryRecordsPressInfo()
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        lDelete = DeleteMultientryPressInfo.Count

        While (lDelete > 0)

            objPKOProductionLogPPT.ProductionLogPressID = DeleteMultientryPressInfo(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = PKOProductionLogBOL.PKOProductionLogPressMultiEntryDelete(objPKOProductionLogPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub DeleteShiftInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteShiftInfo.Click
        If dgvPKOLogShiftDetails.RowCount = 0 Then

            Exit Sub
        ElseIf dgvPKOLogShiftDetails.RowCount = 1 Then
            DisplayInfoMessage("Msg911")
            Exit Sub
        Else

            DeleteMultientrydatagridShift()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridShift()

        Dim Dr As DataRow
        Dr = dtPKOShiftAdd.Rows.Item(dgvPKOLogShiftDetails.CurrentRow.Index)
        Dr.Delete()
        dtPKOShiftAdd.AcceptChanges()
        TotalHourShiftsKernelProcessedCalculation()
        ClearShift()
        Datefunction()

    End Sub

    Private Sub DeleteKernelReceived_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteKernelReceived.Click
        If dgPressInfo.RowCount = 0 Then
            Exit Sub
        ElseIf dgPressInfo.RowCount = 1 Then
            ''    MsgBox("You cannot delete the last detail/summary record. The master record requires at least one detail/summary record.  Please add a detail/summary record before deleting this record. You can also delete all detail/summary records including the corresponding master record using the Delete All button. This action cannot be undone.")
            DisplayInfoMessage("Msg911")
            Exit Sub
        Else
            DeleteMultientrydatagridKernelReceived()
        End If

    End Sub

    Private Sub DeleteMultientrydatagridKernelReceived()

        If Not dgvReceivedKernel.SelectedRows(0).Cells("dgMePKOKERReceivedID").Value Is Nothing Then
            lPKOKERReceivedID = dgvReceivedKernel.SelectedRows(0).Cells("dgMePKOKERReceivedID").Value.ToString
        Else
            lPKOKERReceivedID = String.Empty
        End If

        lDelete = 0
        If lProductionLogPressID <> "" Then
            lDelete = DeleteMultientryKernelReceived.Count

            DeleteMultientryKernelReceived.Insert(lDelete, lProductionLogPressID)

            ' lDelete = DeleteMultientry.Count
        End If
        Dim Dr As DataRow
        Dr = dtKerRecd.Rows.Item(dgvReceivedKernel.CurrentRow.Index)
        Dr.Delete()
        dtKerRecd.AcceptChanges()
        lPKOKERReceivedID = ""
        GetTotalReceivedQtyKerRec()
        ClearReceivedKernelGB()

    End Sub

    Private Sub DeleteMultiEntryRecordsKernelReceived()
        Dim objPKOProductionLogPPT As New PKOProductionLogPPT
        lDelete = DeleteMultientryKernelReceived.Count

        While (lDelete > 0)

            objPKOProductionLogPPT.ProductionLogPressID = DeleteMultientryKernelReceived(lDelete - 1)
            Dim IntProdTranshipDelete As New Integer
            IntProdTranshipDelete = PKOProductionLogBOL.PKOProductionKerRecdMultiEntryDelete(objPKOProductionLogPPT)
            lDelete = lDelete - 1

        End While



    End Sub

    Private Sub tcPKOroductionLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcPKOroductionLog.Click
        If tcPKOroductionLog.SelectedIndex = 1 Then
            If (dgvPKOLogShiftDetails.RowCount > 0 Or dgPressInfo.RowCount > 0 Or dgvReceivedKernel.RowCount > 0) And btnSaveAll.Enabled = True Then
                If MsgBox(rm.GetString("Msg631"), MsgBoxStyle.OkCancel) = Windows.Forms.DialogResult.Cancel Then
                    'tcCPOProductionLog.SelectedIndex = 0
                    tcPKOroductionLog.SelectedIndex = 0
                    tcPKOLog.SelectedIndex = 0
                    GlobalPPT.IsRetainFocus = False
                Else

                    clear()
                    ClearReceivedKernelGB()
                    ClearLogExpress()
                    ClearGridView(dgvReceivedKernel)
                    ClearGridView(dgPressInfo)
                    ClearShift()
                    ClearGridView(dgvPKOLogShiftDetails)
                    BindDataGrid()
                    tcPKOroductionLog.SelectedIndex = 1
                    BindDataGrid()
                End If
            Else
                BindDataGrid()
                clear()
                ClearReceivedKernelGB()
                ClearLogExpress()
                ClearGridView(dgvReceivedKernel)
                ClearGridView(dgPressInfo)
                ClearShift()
                ClearGridView(dgvPKOLogShiftDetails)
                BindDataGrid()

            End If
        Else
            BindDataGrid()
            clear()
            ClearReceivedKernelGB()
            ClearLogExpress()
            ClearGridView(dgvReceivedKernel)
            ClearGridView(dgPressInfo)
            ClearShift()
            ClearGridView(dgvPKOLogShiftDetails)
            BindDataGrid()

        End If
    End Sub

    Private Sub txtStartTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStartTime.Leave
        If txtStartTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtStartTime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg2")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtStartTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If

            If CInt(strArr(0)) >= 24 Then
                DisplayInfoMessage("Msg179")
                txtStartTime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg2")
                    '  MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtStartTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStartTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStartTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStartTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If
            End If

            txtStartTime.Text = Hrs + ":" + Min
        End If
        timeCalculation()
    End Sub

    Private Sub txtStartTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStartTime.TextChanged
        Dim Value As String = txtStartTime.Text
        Dim strlen As Integer
        If txtStartTime.Text <> "" Then
            strlen = Len(txtStartTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStartTime.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    txtStartTime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub txtStopTime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStopTime.Leave
        If txtStopTime.Text <> "" Then

            Dim Hrs As String = "00"
            Dim Min As String = "00"
            Dim str As String
            Dim strArr() As String
            str = txtStopTime.Text
            strArr = str.Split(":")


            If strArr.Count > 2 Then
                DisplayInfoMessage("Msg2")
                '' MessageBox.Show("User Can enter only HH or HH:MM format")
                txtStopTime.Focus()
                Exit Sub
            End If
            If strArr(0).Length = 1 Then
                Hrs = "0" + strArr(0)
            ElseIf strArr(0) <> "" Then
                Hrs = strArr(0)
            End If
            If CInt(strArr(0)) >= 24 Then
                DisplayInfoMessage("Msg180")
                txtStopTime.Focus()
                Exit Sub
            End If

            If strArr.Count = 2 Then

                If strArr(1).Length > 2 Then
                    DisplayInfoMessage("Msg2")
                    '  MessageBox.Show("User Can enter only HH or HH:MM format")
                    txtStopTime.Focus()
                    Exit Sub
                End If
                If strArr(1) = "" Then
                    DisplayInfoMessage("Msg2")
                    ''MessageBox.Show("User Can enter only :MM or HH:MM format,example. 10:30 not 10: ")
                    txtStopTime.Focus()
                    Exit Sub
                End If
                If Val(strArr(1)) >= 60 Then
                    DisplayInfoMessage("Msg3")
                    ''MessageBox.Show("Minutes Value Cant be greater than 59 ")
                    txtStopTime.Focus()
                    Exit Sub
                ElseIf strArr(1) <> "00" And strArr(1) <> "01" And strArr(1) <> "02" And strArr(1) <> "03" And strArr(1) <> "04" And strArr(1) <> "05" And strArr(1) <> "06" And strArr(1) <> "07" And strArr(1) <> "08" And strArr(1) <> "09" And strArr(1) < 10 Then
                    DisplayInfoMessage("Msg4")
                    ''MessageBox.Show("Minutes Value should be MM format ,example. 10 not 1 ")
                    txtStopTime.Focus()
                    Exit Sub
                Else
                    Min = strArr(1)
                End If


            End If

            txtStopTime.Text = Hrs + ":" + Min
        End If
        timeCalculation()
    End Sub

    Private Sub txtStopTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStopTime.TextChanged
        Dim Value As String = txtStopTime.Text
        Dim strlen As Integer
        If txtStopTime.Text <> "" Then
            strlen = Len(txtStopTime.Text)
            Dim allowedChars As String = "0123456789:"
            For i As Integer = Value.Length - 1 To 0 Step -1
                If allowedChars.IndexOf(Value(i)) = -1 Then
                    txtStopTime.Text = Value.Substring(0, strlen - 1)
                    DisplayInfoMessage("Msg7")
                    txtStopTime.Focus()
                End If
            Next
        End If
    End Sub

    Private Sub timeCalculation()
        If txtStartTime.Text <> "" And txtStopTime.Text <> "" Then
            Dim strArr4(), strArr3() As String
            Dim Str4, Str3 As String
            Str4 = txtStopTime.Text
            strArr4 = Str4.Split(":")
            Str3 = txtStartTime.Text
            strArr3 = Str3.Split(":")
            Dim strTotalMins As String = 0
            Dim strTotalhrs As String = String.Empty

            If Not Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) Then
                'For Hours

                strTotalhrs = Val(CInt(strArr4(0))) - Val(CInt(strArr3(0)))
                If strTotalhrs < 0 Then
                    strTotalhrs = Val(strTotalhrs) + 24
                End If
            ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) > Val(CInt(strArr3(1))) Then
                strTotalhrs = "0"
            ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) < Val(CInt(strArr3(1))) Then
                strTotalhrs = "24"
            ElseIf Val(CInt(strArr4(0))) = Val(CInt(strArr3(0))) And Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then
                strTotalhrs = "24"
            Else
                strTotalhrs = "0"
            End If

            If Not Val(CInt(strArr4(1))) = Val(CInt(strArr3(1))) Then

                'For Mins
                strTotalMins = Val(CInt(strArr4(1))) - Val(CInt(strArr3(1)))
                If Val(strTotalMins) < 0 Then
                    strTotalMins = Val(strTotalMins) + 60
                    strTotalhrs = Val(strTotalhrs) - 1
                End If
            Else
                strTotalMins = "0"
            End If


            If Val(strTotalhrs) < 10 Then
                strTotalhrs = "0" + strTotalhrs
            End If
            If Val(strTotalMins) < 10 Then
                strTotalMins = "0" + strTotalMins
            End If

            ' If strTotalhrs <> Nothing Then
            txtShiftHours.Text = strTotalhrs + ":" + strTotalMins
            lShifthours = txtShiftHours.Text
            'Else
            '    strTotalhrs = "00"
            '    txtShiftHrs.Text = strTotalhrs + ":" + strTotalMins
            '    lShiftHrs = Val(txtShiftHrs.Text)
            'End If


        End If


    End Sub

    Private Sub txtPKOProductionToday_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPKOProductionToday.TextChanged
        If Val(txtPKOProductionToday.Text) <> 0 And Val(txtKerneltoday.Text) <> 0 Then
            'txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / (Val(txtKerneltoday.Text) - Val(txtLossOnKernelToday.Text))), 2)
            txtKERToday.Text = Math.Round((Val(txtPKOProductionToday.Text) * 100 / Val(txtKerneltoday.Text)), 2)
        Else
            txtKERToday.Text = ""
        End If


    End Sub

End Class
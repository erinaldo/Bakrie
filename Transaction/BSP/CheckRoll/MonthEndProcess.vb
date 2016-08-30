Imports System.Data.SqlClient
Imports System.Globalization
Imports System.ComponentModel
Imports System.Resources
Imports System.Threading
Imports Common_BOL
Imports Common_PPT
Imports CheckRoll_BOL
Imports CheckRoll_DAL
Imports CheckRoll_PPT
Imports System.Configuration

#Region "################## MONTHLY PROCESSING SEQUENCE ######################"
'################## MONTHLY PROCESSING SEQUENCE######################3

'1. Get information of Daily Activity which are not distributed accordingly (SP: [Checkroll].[ActivityDistributeExists])
'2. Get information about reception data where "Checkroll.DailyReceiption" and "Checkroll.DailyReceptionForRubber" table is empty for current duration [Checkroll].[AttendanceHarvNoReceiptionExists]
'3. Process Attendance Summary with Team [Checkroll].[AttendSummaryWithTeamProcess] * to add DailyAttendanceMandor -- table: Checkroll.AttendanceSummary
'4. Process Distribusi Summary [Checkroll].[CRDistributionSummary] * table: Checkroll.DistributionSummary this is for Lain Only
'5. Process Distribusi Activity Summary [Checkroll].[CRDistributionActivitySummary] * table: Checkroll.DistributionActivitySummary this is for Lain Only
'6. Process Upload Salary [Checkroll].[UpLoadSalary] -- This procedure is to calculate basic pay based on attendacne code and number of working days- table: checkroll.salary
'7. Process KT Salary [Checkroll].[KTSalary] -- not being used in BSP
'8. Process Salary Overtime [Checkroll].[InsertSalaryOT]
'9. Process Salary Deduction and Allowance [Checkroll].[InsertAllDedSalary]
'10. Process Salary Advance [Checkroll].[InsertSalaryAdvance]
'Rubber Premi
'11. Get EstateType (eg: M or E) [STORE].[StoreIssueVoucherEstateType]
'12. If EstateType is not M (not a mill) then Process Salary Incentive [Checkroll].[InsertSalaryIncentive] -- SAI: change to add RUBBER , check on category KHL
'13. Process Salary Premi [Checkroll].[InsertSalaryPremi] -- SAI: add Daily Reception Rubber table
'14. Update Total Bruto and Deduction [Checkroll].[UpdateTotalBrutoAndDeduction] -- SAI: Check category KHL
'15. Process Tax Calculation  -- might include penalites, any calculation on Base Pay should be done here
'	-- Get Active employees [Checkroll].[GetActiveEmployee2] and LOOP THROUGH ALL THE ACTIVE EMPLOYEES -- SAI: check category not KT
'	--- Get Tax Income 
'		- GetGradeRange [Checkroll].[GetGradeRange] (returns tax calculation values for a specific employee for a specific month
'	--- Get Marital Status And Active Month IDs for the entire year [Checkroll].[GetMaritalStatusAndActMnth]
'		- this will return all ActiveMonthID's, Regular & Irregular Income, Accident Insurance, Salary, Tax, Deductions etc for each month (upto current month)
'	--- If THR is greater than zero and Category is not empty get taxable income [Checkroll].[Taxable_Income]
'		- this calculation will be done based on values returned from [Checkroll].[GetMaritalStatusAndActMnth]
' 	--- Do the final processing of salary [Checkroll].[SalaryProcessing] 
'16. Process Other Payment [Checkroll].[OtherPaymentDetails] -- table: Checkroll.OtherPaymentDetail
'17. Process on cost [Checkroll].[OnCostProcess] -- --SAI: Check stock description for rice, check for RUBBER, On cost is calculated based on Checkroll.OtherPaymentDetail and grouped by Gang
'18. Process on cost details [Checkroll].[OnCostProcessDet] -- SAI: this SP can be modified by using sum and group instead of cursors
'19. Insert records to Analysis Harvesting Cost table [Checkroll].[AnalyHarvestingCostInsert] -- SAI: used to generate report
'20. Process Checkroll Journal [Checkroll].[InsertCheckrollJournal] -- SAI: can be modified to use previous summary tables
'21. Update Task Monitor table when Monthly Processing is completed [General].[TaskMonitorUPDATE]
'22. Message box summary is displayed using SP - Checkroll. MonthlyProceessingAlert

'>>>>>>>>>>>>>>>>>>>>>>>>>>>!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
'For Premi Calculations:
'1. Premi is calculated from "DailyReceiptionWithTeam" screen 
'	- When the data is entered and saved it will call save method (SaveDailyReceiptionWithTeam)
'	- The method will call SP ([Checkroll].[DailyReceptionBlkHKPremiValueUpdateProcess]) for each employee

#End Region

Public Class MonthEndProcess
    Dim WorkerType As String
    Dim Status As String
    Dim StatusDate As DateTime
    Dim MaritalStatus As String
    Dim EmpCode As String
    Dim PTKP As Double
    Dim GradeINPWP As Double

    Dim GradeIRangeNPWP As Double
    Dim GradeIINPWP As Double
    Dim GradeIIRangeFromNPWP As Double
    Dim GradeIIRangeToNPWP As Double
    Dim GradeIIINPWP As Double
    Dim GradeIIIRangeFromNPWP As Double
    Dim GradeIIIRangeToNPWP As Double
    Dim GradeIVNPWP As Double
    Dim GradeIVRangeFromNPWP As Double
    Dim GradeIVRangeToNPWP As Double
    Dim GradeVNPWP As Double

    Dim GradeI As Double

    Dim GradeIRange As Double
    Dim GradeII As Double
    Dim GradeIIRangeFrom As Double
    Dim GradeIIRangeTo As Double
    Dim GradeIII As Double
    Dim GradeIIIRangeFrom As Double
    Dim GradeIIIRangeTo As Double
    Dim GradeIV As Double
    Dim GradeIVRangeFrom As Double
    Dim GradeIVRangeTo As Double
    Dim GradeV As Double
    Dim NPWP As String
    Dim DedAstek As Double
    Dim DedTaxEmployee As Double
    Dim DedTaxCompany As Double
    Dim DedAdvance As Double
    Dim DedOther As Double
    Dim TotalDed As Double
    Dim TotalNett As Double
    Dim TotalRoundUP As Double
    Dim JHTPercent As Double
    Dim JHT As Double
    Dim JKKAndJKMPercent As Double
    Dim JKKAndJKM As Double
    Dim BasicRate As Double
    Dim HIPMonthlyRate As Double
    Dim Category As String
    Dim JHTEmployerPercent As Double
    Dim JHTEmployer As Double
    Dim THR As Double

    Dim TaxExemptionWorker As Double
    Dim TaxExemptionHusbWife As Double
    Dim TaxExemptionChild As Double

    Dim ActiveMonth1Tax As Double
    Dim ActiveMonth2Tax As Double
    Dim ActiveMonth3Tax As Double
    Dim ActiveMonth4Tax As Double
    Dim ActiveMonth5Tax As Double
    Dim ActiveMonth6Tax As Double
    Dim ActiveMonth7Tax As Double
    Dim ActiveMonth8Tax As Double
    Dim ActiveMonth9Tax As Double
    Dim ActiveMonth10Tax As Double
    Dim ActiveMonth11Tax As Double
    Dim ActiveMonth12Tax As Double

    Dim ActiveMonth1Sal As Double
    Dim ActiveMonth2Sal As Double
    Dim ActiveMonth3Sal As Double
    Dim ActiveMonth4Sal As Double
    Dim ActiveMonth5Sal As Double
    Dim ActiveMonth6Sal As Double
    Dim ActiveMonth7Sal As Double
    Dim ActiveMonth8Sal As Double
    Dim ActiveMonth9Sal As Double
    Dim ActiveMonth10Sal As Double
    Dim ActiveMonth11Sal As Double
    Dim ActiveMonth12Sal As Double

    Dim ActiveMonthYearID1 As String
    Dim ActiveMonthYearID2 As String
    Dim ActiveMonthYearID3 As String
    Dim ActiveMonthYearID4 As String
    Dim ActiveMonthYearID5 As String
    Dim ActiveMonthYearID6 As String
    Dim ActiveMonthYearID7 As String
    Dim ActiveMonthYearID8 As String
    Dim ActiveMonthYearID9 As String
    Dim ActiveMonthYearID10 As String
    Dim ActiveMonthYearID11 As String
    Dim ActiveMonthYearID12 As String
    Dim DOJ As Integer
    'Dim EmpCode As String

    Dim Income_Regular1 As Double
    Dim Income_Regular2 As Double
    Dim Income_Regular3 As Double
    Dim Income_Regular4 As Double
    Dim Income_Regular5 As Double
    Dim Income_Regular6 As Double
    Dim Income_Regular7 As Double
    Dim Income_Regular8 As Double
    Dim Income_Regular9 As Double
    Dim Income_Regular10 As Double
    Dim Income_Regular11 As Double
    Dim Income_Regular12 As Double

    Dim Income_Irregular1 As Double
    Dim Income_Irregular2 As Double
    Dim Income_Irregular3 As Double
    Dim Income_Irregular4 As Double
    Dim Income_Irregular5 As Double
    Dim Income_Irregular6 As Double
    Dim Income_Irregular7 As Double
    Dim Income_Irregular8 As Double
    Dim Income_Irregular9 As Double
    Dim Income_Irregular10 As Double
    Dim Income_Irregular11 As Double
    Dim Income_Irregular12 As Double


    Dim Accident_Insurance1 As Double
    Dim Accident_Insurance2 As Double
    Dim Accident_Insurance3 As Double
    Dim Accident_Insurance4 As Double
    Dim Accident_Insurance5 As Double
    Dim Accident_Insurance6 As Double
    Dim Accident_Insurance7 As Double
    Dim Accident_Insurance8 As Double
    Dim Accident_Insurance9 As Double
    Dim Accident_Insurance10 As Double
    Dim Accident_Insurance11 As Double
    Dim Accident_Insurance12 As Double

    Dim Gross_Income_Regular1 As Double
    Dim Gross_Income_Regular2 As Double
    Dim Gross_Income_Regular3 As Double
    Dim Gross_Income_Regular4 As Double
    Dim Gross_Income_Regular5 As Double
    Dim Gross_Income_Regular6 As Double
    Dim Gross_Income_Regular7 As Double
    Dim Gross_Income_Regular8 As Double
    Dim Gross_Income_Regular9 As Double
    Dim Gross_Income_Regular10 As Double
    Dim Gross_Income_Regular11 As Double
    Dim Gross_Income_Regular12 As Double


    Dim Gross_Income_Irregular1 As Double
    Dim Gross_Income_Irregular2 As Double
    Dim Gross_Income_Irregular3 As Double
    Dim Gross_Income_Irregular4 As Double
    Dim Gross_Income_Irregular5 As Double
    Dim Gross_Income_Irregular6 As Double
    Dim Gross_Income_Irregular7 As Double
    Dim Gross_Income_Irregular8 As Double
    Dim Gross_Income_Irregular9 As Double
    Dim Gross_Income_Irregular10 As Double
    Dim Gross_Income_Irregular11 As Double
    Dim Gross_Income_Irregular12 As Double


    Dim Income_Regular_Annualised As Double
    Dim Income_Irregular_Annualised As Double
    Dim Functional_Allowance As Double
    Dim Luran_JHT_Pension As Double

    Dim Nett_Income_Regular1 As Double
    Dim Nett_Income_Regular2 As Double
    Dim Nett_Income_Regular3 As Double
    Dim Nett_Income_Regular4 As Double
    Dim Nett_Income_Regular5 As Double
    Dim Nett_Income_Regular6 As Double
    Dim Nett_Income_Regular7 As Double
    Dim Nett_Income_Regular8 As Double
    Dim Nett_Income_Regular9 As Double
    Dim Nett_Income_Regular10 As Double
    Dim Nett_Income_Regular11 As Double
    Dim Nett_Income_Regular12 As Double

    Dim Nett_Income_IRRegular1 As Double
    Dim Nett_Income_IRRegular2 As Double
    Dim Nett_Income_IRRegular3 As Double
    Dim Nett_Income_IRRegular4 As Double
    Dim Nett_Income_IRRegular5 As Double
    Dim Nett_Income_IRRegular6 As Double
    Dim Nett_Income_IRRegular7 As Double
    Dim Nett_Income_IRRegular8 As Double
    Dim Nett_Income_IRRegular9 As Double
    Dim Nett_Income_IRRegular10 As Double
    Dim Nett_Income_IRRegular11 As Double
    Dim Nett_Income_IRRegular12 As Double

    Dim PTKP_Tax_exempted_Income_Anual As Double

    Dim Taxable_Income_Regular1 As Double
    Dim Taxable_Income_Regular2 As Double
    Dim Taxable_Income_Regular3 As Double
    Dim Taxable_Income_Regular4 As Double
    Dim Taxable_Income_Regular5 As Double
    Dim Taxable_Income_Regular6 As Double
    Dim Taxable_Income_Regular7 As Double
    Dim Taxable_Income_Regular8 As Double
    Dim Taxable_Income_Regular9 As Double
    Dim Taxable_Income_Regular10 As Double
    Dim Taxable_Income_Regular11 As Double
    Dim Taxable_Income_Regular12 As Double

    Dim Taxable_Income_Irregular1 As Double
    Dim Taxable_Income_Irregular2 As Double
    Dim Taxable_Income_Irregular3 As Double
    Dim Taxable_Income_Irregular4 As Double
    Dim Taxable_Income_Irregular5 As Double
    Dim Taxable_Income_Irregular6 As Double
    Dim Taxable_Income_Irregular7 As Double
    Dim Taxable_Income_Irregular8 As Double
    Dim Taxable_Income_Irregular9 As Double
    Dim Taxable_Income_Irregular10 As Double
    Dim Taxable_Income_Irregular11 As Double
    Dim Taxable_Income_Irregular12 As Double

    Dim TaxImposedR1 As Double
    Dim TaxImposedR2 As Double
    Dim TaxImposedR3 As Double
    Dim TaxImposedR4 As Double
    Dim TaxImposedR5 As Double
    Dim TaxImposedR6 As Double
    Dim TaxImposedR7 As Double
    Dim TaxImposedR8 As Double
    Dim TaxImposedR9 As Double
    Dim TaxImposedR10 As Double
    Dim TaxImposedR11 As Double
    Dim TaxImposedR12 As Double

    Dim TaxImposedIR1 As Double
    Dim TaxImposedIR2 As Double
    Dim TaxImposedIR3 As Double
    Dim TaxImposedIR4 As Double
    Dim TaxImposedIR5 As Double
    Dim TaxImposedIR6 As Double
    Dim TaxImposedIR7 As Double
    Dim TaxImposedIR8 As Double
    Dim TaxImposedIR9 As Double
    Dim TaxImposedIR10 As Double
    Dim TaxImposedIR11 As Double
    Dim TaxImposedIR12 As Double

    Dim Sal1 As Integer
    Dim Sal2 As Integer
    Dim Sal3 As Integer
    Dim Sal4 As Integer
    Dim Sal5 As Integer
    Dim Sal6 As Integer
    Dim Sal7 As Integer
    Dim Sal8 As Integer
    Dim Sal9 As Integer
    Dim Sal10 As Integer
    Dim Sal11 As Integer
    Dim Sal12 As Integer



    Dim PPH_21_Diff1 As Double
    Dim PPH_21_Diff2 As Double
    Dim PPH_21_Diff3 As Double
    Dim PPH_21_Diff4 As Double
    Dim PPH_21_Diff5 As Double
    Dim PPH_21_Diff6 As Double
    Dim PPH_21_Diff7 As Double
    Dim PPH_21_Diff8 As Double
    Dim PPH_21_Diff9 As Double
    Dim PPH_21_Diff10 As Double
    Dim PPH_21_Diff11 As Double
    Dim PPH_21_Diff12 As Double



    Dim Tax_calculated_month1 As Double
    Dim Tax_calculated_month2 As Double
    Dim Tax_calculated_month3 As Double
    Dim Tax_calculated_month4 As Double
    Dim Tax_calculated_month5 As Double
    Dim Tax_calculated_month6 As Double
    Dim Tax_calculated_month7 As Double
    Dim Tax_calculated_month8 As Double
    Dim Tax_calculated_month9 As Double
    Dim Tax_calculated_month10 As Double
    Dim Tax_calculated_month11 As Double
    Dim Tax_calculated_month12 As Double
    Dim Tax_calculated_month As Double

    Dim Tax_Payable1 As Double
    Dim Tax_Payable2 As Double
    Dim Tax_Payable3 As Double
    Dim Tax_Payable4 As Double
    Dim Tax_Payable5 As Double
    Dim Tax_Payable6 As Double
    Dim Tax_Payable7 As Double
    Dim Tax_Payable8 As Double
    Dim Tax_Payable9 As Double
    Dim Tax_Payable10 As Double
    Dim Tax_Payable11 As Double
    Dim Tax_Payable12 As Double



    Dim TotalBasic1 As Double
    Dim TotalBasic2 As Double
    Dim TotalBasic3 As Double
    Dim TotalBasic4 As Double
    Dim TotalBasic5 As Double
    Dim TotalBasic6 As Double
    Dim TotalBasic7 As Double
    Dim TotalBasic8 As Double
    Dim TotalBasic9 As Double
    Dim TotalBasic10 As Double
    Dim TotalBasic11 As Double
    Dim TotalBasic12 As Double

    Dim HarinLainUpah1 As Double
    Dim HarinLainUpah2 As Double
    Dim HarinLainUpah3 As Double
    Dim HarinLainUpah4 As Double
    Dim HarinLainUpah5 As Double
    Dim HarinLainUpah6 As Double
    Dim HarinLainUpah7 As Double
    Dim HarinLainUpah8 As Double
    Dim HarinLainUpah9 As Double
    Dim HarinLainUpah10 As Double
    Dim HarinLainUpah11 As Double
    Dim HarinLainUpah12 As Double

    Dim TotalOTValue1 As Double
    Dim TotalOTValue2 As Double
    Dim TotalOTValue3 As Double
    Dim TotalOTValue4 As Double
    Dim TotalOTValue5 As Double
    Dim TotalOTValue6 As Double
    Dim TotalOTValue7 As Double
    Dim TotalOTValue8 As Double
    Dim TotalOTValue9 As Double
    Dim TotalOTValue10 As Double
    Dim TotalOTValue11 As Double
    Dim TotalOTValue12 As Double


    Dim Premi1 As Double
    Dim Premi2 As Double
    Dim Premi3 As Double
    Dim Premi4 As Double
    Dim Premi5 As Double
    Dim Premi6 As Double
    Dim Premi7 As Double
    Dim Premi8 As Double
    Dim Premi9 As Double
    Dim Premi10 As Double
    Dim Premi11 As Double
    Dim Premi12 As Double


    Dim HavPremi1 As Double
    Dim HavPremi2 As Double
    Dim HavPremi3 As Double
    Dim HavPremi4 As Double
    Dim HavPremi5 As Double
    Dim HavPremi6 As Double
    Dim HavPremi7 As Double
    Dim HavPremi8 As Double
    Dim HavPremi9 As Double
    Dim HavPremi10 As Double
    Dim HavPremi11 As Double
    Dim HavPremi12 As Double


    Dim MandorePremi1 As Double
    Dim MandorePremi2 As Double
    Dim MandorePremi3 As Double
    Dim MandorePremi4 As Double
    Dim MandorePremi5 As Double
    Dim MandorePremi6 As Double
    Dim MandorePremi7 As Double
    Dim MandorePremi8 As Double
    Dim MandorePremi9 As Double
    Dim MandorePremi10 As Double
    Dim MandorePremi11 As Double
    Dim MandorePremi12 As Double

    Dim KraniPremi1 As Double
    Dim KraniPremi2 As Double
    Dim KraniPremi3 As Double
    Dim KraniPremi4 As Double
    Dim KraniPremi5 As Double
    Dim KraniPremi6 As Double
    Dim KraniPremi7 As Double
    Dim KraniPremi8 As Double
    Dim KraniPremi9 As Double
    Dim KraniPremi10 As Double
    Dim KraniPremi11 As Double
    Dim KraniPremi12 As Double

    Dim DriverPremi1 As Double
    Dim DriverPremi2 As Double
    Dim DriverPremi3 As Double
    Dim DriverPremi4 As Double
    Dim DriverPremi5 As Double
    Dim DriverPremi6 As Double
    Dim DriverPremi7 As Double
    Dim DriverPremi8 As Double
    Dim DriverPremi9 As Double
    Dim DriverPremi10 As Double
    Dim DriverPremi11 As Double
    Dim DriverPremi12 As Double


    Dim AttincentiveRp1 As Double
    Dim AttincentiveRp2 As Double
    Dim AttincentiveRp3 As Double
    Dim AttincentiveRp4 As Double
    Dim AttincentiveRp5 As Double
    Dim AttincentiveRp6 As Double
    Dim AttincentiveRp7 As Double
    Dim AttincentiveRp8 As Double
    Dim AttincentiveRp9 As Double
    Dim AttincentiveRp10 As Double
    Dim AttincentiveRp11 As Double
    Dim AttincentiveRp12 As Double

    Dim Rapel As Double
    Dim Mandore As String
    'Dim WorkerType As String
    Dim Bonus As String
    Dim Others As String
    Dim THRNew As Double
    Dim TaxSalHisBasicSalary As Double
    Dim BasicSalary As Double

    Dim ARJan As Double
    Dim ARFeb As Double
    Dim ARMar As Double
    Dim ARAPr As Double
    Dim ARMay As Double
    Dim ARJun As Double
    Dim ARJul As Double
    Dim ARAug As Double
    Dim ARSep As Double
    Dim AROct As Double
    Dim ARNov As Double
    Dim ARDec As Double

    Dim AIJan As Double
    Dim AIFeb As Double
    Dim AIMar As Double
    Dim AIAPr As Double
    Dim AIMay As Double
    Dim AIJun As Double
    Dim AIJul As Double
    Dim AIAug As Double
    Dim AISep As Double
    Dim AIOct As Double
    Dim AINov As Double
    Dim AIDec As Double

    Dim AFJan As Double
    Dim AFFeb As Double
    Dim AFMar As Double
    Dim AFAPr As Double
    Dim AFMay As Double
    Dim AFJun As Double
    Dim AFJul As Double
    Dim AFAug As Double
    Dim AFSep As Double
    Dim AFOct As Double
    Dim AFNov As Double
    Dim AFDec As Double

    Dim ALurJan As Double
    Dim ALurFeb As Double
    Dim ALurMar As Double
    Dim ALurAPr As Double
    Dim ALurMay As Double
    Dim ALurJun As Double
    Dim ALurJul As Double
    Dim ALurAug As Double
    Dim ALurSep As Double
    Dim ALurOct As Double
    Dim ALurNov As Double
    Dim ALurDec As Double

    Dim RegIncJan As Double
    Dim RegIncFeb As Double
    Dim RegIncMar As Double
    Dim RegIncAPr As Double
    Dim RegIncMay As Double
    Dim RegIncJun As Double
    Dim RegIncJul As Double
    Dim RegIncAug As Double
    Dim RegIncSep As Double
    Dim RegIncOct As Double
    Dim RegIncNov As Double
    Dim RegIncDec As Double


    Dim Taxable_Income_TRegular1 As Double
    Dim Taxable_Income_TRegular2 As Double
    Dim Taxable_Income_TRegular3 As Double
    Dim Taxable_Income_TRegular4 As Double
    Dim Taxable_Income_TRegular5 As Double
    Dim Taxable_Income_TRegular6 As Double
    Dim Taxable_Income_TRegular7 As Double
    Dim Taxable_Income_TRegular8 As Double
    Dim Taxable_Income_TRegular9 As Double
    Dim Taxable_Income_TRegular10 As Double
    Dim Taxable_Income_TRegular11 As Double
    Dim Taxable_Income_TRegular12 As Double

    Dim Taxable_Income_IrTRegular1 As Double
    Dim Taxable_Income_IrTRegular2 As Double
    Dim Taxable_Income_IrTRegular3 As Double
    Dim Taxable_Income_IrTRegular4 As Double
    Dim Taxable_Income_IrTRegular5 As Double
    Dim Taxable_Income_IrTRegular6 As Double
    Dim Taxable_Income_IrTRegular7 As Double
    Dim Taxable_Income_IrTRegular8 As Double
    Dim Taxable_Income_IrTRegular9 As Double
    Dim Taxable_Income_IrTRegular10 As Double
    Dim Taxable_Income_IrTRegular11 As Double
    Dim Taxable_Income_IrTRegular12 As Double

    Private Sub MonthEndProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' get the start date and end date for the logged in Month
        StartDate.Value = GlobalPPT.FiscalYearFromDate
        EndDate.Value = GlobalPPT.FiscalYearToDate
        dtpDateProc.MinDate = GlobalPPT.FiscalYearFromDate
        dtpDateProc.MaxDate = GlobalPPT.FiscalYearToDate
        dtpDateProc.Value = GlobalPPT.FiscalYearToDate

        Thread.CurrentThread.CurrentCulture = Globalization.CultureInfo.InvariantCulture()

        LblStatus.Text = String.Empty
        LblStatus.Visible = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub btnProc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProc.Click
        btnProc.Enabled = False
        MonthlyProcess(1)
        btnProc.Enabled = True
    End Sub

    Dim Month As Integer
    Dim Year As Integer
    Private Sub GetActiveYearMonth(ByVal strEstateId As String, ByVal ModID As Integer)
        Dim obj As New EstateBOL
        Dim dsActive As New DataSet

        dsActive = obj.GetActiveYearMonth(strEstateId, ModID)
        If dsActive.Tables(0).Rows.Count > 0 Then

            Dim intAMonth As Integer = CType(dsActive.Tables(0).Rows(0).Item(1).ToString, Integer)
            Month = intAMonth

            Dim intActiveYear As Integer
            intActiveYear = CType(dsActive.Tables(0).Rows(0).Item(0).ToString, Integer)
            Year = intActiveYear
        End If
    End Sub

    Dim fMsg As ProgressingFrm            'create a new object for the message form

    ''' <summary>
    ''' this method perform the monthly process 'Added by sangar d on 28-Aug-12 to implement the monthly process in the month end closing process also.
    ''' </summary>
    ''' <param name="isOwnForm">if the param is 1 then this method is called from the same form. if the param value is 0 then this method is calling from the other form</param>
    ''' <remarks></remarks>
    Public Function MonthlyProcess(ByVal isOwnForm As Integer)
        Dim intProcessStoped As Integer = 0
        Dim intProcessCompleted As Integer = 1
        Dim threadPauseMillisecond = 500
        Dim currentActiveMonthYear As String
        currentActiveMonthYear = GlobalPPT.strActMthYearID
        Dim startTime As DateTime = DateTime.Now()

        Try

            If MsgBox("You are about to perform monthly processing. Do you want to proceed. If Yes, click ""OK"", otherwise click ""Cancel""", MsgBoxStyle.OkCancel) <> Windows.Forms.DialogResult.Cancel Then
                Try

                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    'Get information of Daily Activity which are not distributed accordingly (SP: [Checkroll].[ActivityDistributeExists])
                    Dim dtActivityDistributeExists As DataTable = ProcessBOL.ActivityDistributeExists()
                    If dtActivityDistributeExists.Rows.Count > 0 Then
                        If isOwnForm = 1 Then
                            gbDetail.Visible = True
                            dgvDistibutionDetails.Visible = True
                            dgvAttendanceHarvNoReceiptionDetails.Visible = False
                            dgvDistibutionDetails.DataSource = dtActivityDistributeExists

                        End If
                        If MsgBox("Some records in Activity Distribution not yet distributed properly." & Chr(13) & Chr(10) & "Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            MonthlyProcess = intProcessStoped
                            Exit Function
                        End If
                    End If
                    If ConfigurationManager.AppSettings.Item("OverwriteActiveMonthYear") = "1" Then
                        Dim tmpActiveMonthYearId As String
                        tmpActiveMonthYearId = InputBox("Please enter Active Month Year ID :")
                        If tmpActiveMonthYearId <> "" Then
                            GlobalPPT.strActMthYearID = tmpActiveMonthYearId
                        End If
                    End If
                    'get information about reception data where Checkroll.DailyReceiption is empty for current duration
                    Dim dtAttendanceHarvNoReceiptionExists As DataTable = ProcessBOL.AttendanceHarvNoReceiptionExists()
                    If dtAttendanceHarvNoReceiptionExists.Rows.Count > 0 Then
                        If isOwnForm = 1 Then
                            gbDetail.Visible = True
                            dgvDistibutionDetails.Visible = False
                            dgvAttendanceHarvNoReceiptionDetails.Visible = True
                            dgvAttendanceHarvNoReceiptionDetails.DataSource = dtAttendanceHarvNoReceiptionExists
                        End If
                        If MsgBox("Some Harvesting Attendance records have no FieldNo defined for Receiption." & Chr(13) & Chr(10) & "Do you want to continue?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            MonthlyProcess = intProcessStoped
                            Exit Function
                        End If
                    End If

                    Cursor = Cursors.WaitCursor

                    Application.DoEvents()
                    fMsg = New ProgressingFrm
                    fMsg.TopMost = True                'this is to make sure that the message form is displayed at the top of your windows and the users cannot do anything to it except waiting
                    fMsg.Show()                'use Show() instead of ShowDialog()

                    'create a new object for the message form
                    fMsg.pbWait.Minimum = 0
                    fMsg.pbWait.Maximum = 100
                    fMsg.pbWait.Value = 0
                    fMsg.lblMessage.Refresh()
                    fMsg.lblTitle.Refresh()
                    fMsg.lblTitle.Text = "Progress"
                    fMsg.lblTitle.Refresh()
                    fMsg.lblMessage.Refresh()

                    'Process Attendance Summary with Team
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Attendance Summary with Team"
                    fMsg.lblMessage.Refresh()
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    ProcessBOL.AttendSummaryWithTeamProcess()

                    'Process Distribusi Summary
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Distribusi Summary.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    DailyActivityDistributionWithTeam_DAL.CRDistributionSummary()

                    'Process Distribusi Activity Summary
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Distribusi Activity Summary.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    DailyActivityDistributionWithTeam_DAL.CRDistributionActivitySummary()


                    ' Process Upload Salary
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Upload Salary.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    'Below procedure takes care of Deleting records from Checkroll.Salary & inserting leave details etc to Checkroll.Salary table
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    ProcessBOL.UpLoadSalary(dtpDateProc.Value)

                    'Process KT Salary
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Rice Payment.."
                    fMsg.lblMessage.Refresh()
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    ProcessBOL.ProcessRiceValue()

                    'Process Salary Overtime
                    Application.DoEvents()
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Salary Overtime.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    ProcessBOL.InsertSalaryOT()


                    ' UPDATE CHANDRA FORM RATE SETUP CALCULATION
                    ' 01 06 2015 Chandra
                    'Procedure grabs data from Rate Setup Configurable, process and creates/updates allowance and deduction records.
                    ProcessDal.UpdateRateSetupAddConfigurable()

                    'Update Sai Transfers Data from Piece Rate to Allowance Deduction Code
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Piece Rate"
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    ProcessDal.TransferPieceRateToAllowance()

                    'Process Salary  Allowance and Deduction
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Salary Deduction.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    ProcessBOL.InsertAllDedSalary(StartDate.Value, EndDate.Value)

                    'Process Salary Advance
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Salary Advance.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    ProcessDal.InsertSalaryAdvance()

                    Dim psEstateType As String
                    'Get EstateType (eg: M for Mill and E for Estate)
                    psEstateType = Accounts_BOL.JournalBOL.EstateTypeSelect()

                    'If EstateType is not M (not a mill) then Process Salary Incentive
                    If psEstateType <> "M" Then
                        fMsg.pbWait.Value += 5
                        System.Threading.Thread.Sleep(threadPauseMillisecond)
                        fMsg.lblMessage.Refresh()
                        fMsg.lblMessage.Text = "Process Salary Incentive.."
                        fMsg.lblMessage.Refresh()
                        '=> => => => => => => => => => => => => => => => => => => => => => 
                        ProcessBOL.InsertSalaryIncentive()
                    End If

                    Application.DoEvents()


                    'Process Salary Premi
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Salary Premi.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    fMsg.pbWait.Value += 5
                    ProcessDal.InsertSalaryPremi()

                    'Begin Update Premi
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Process Update Premi.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()

                    GetActiveYearMonth(GlobalPPT.strEstateID, 6)
                    Dim yearMonth As String
                    yearMonth = Year & "-" & Month
                    Dim dt As New DataTable
                    dt = ProcessDal.GradeMonthDetailsSelectAll(yearMonth)

                    For Each dataRow As DataRow In dt.Rows
                        ProcessDal.PremiSalaryUpdate(dataRow.Item("Class"), yearMonth, dataRow.Item("EmpId"))
                    Next

                    ProcessDal.PremiMandorBesar()
                    ProcessDal.CalculatePremiGudang()


                    'End Update Premi




                    'Update Total Bruto and Deduction
                    Application.DoEvents()
                    fMsg.pbWait.Value += 5
                    ProcessDal.UpdateTotalBrutoAndDeduction()

                    'Added by nelson
                    fMsg.pbWait.Value += 5
                    System.Threading.Thread.Sleep(threadPauseMillisecond)
                    fMsg.lblMessage.Refresh()
                    fMsg.lblMessage.Text = "Processing Tax Calculation.."
                    fMsg.lblMessage.Refresh()
                    Application.DoEvents()

                    ' IMPORTANT >>> LOOP FOR ALL THE ACTIVE EMPLOYEES
                    UpdateSalary()



                    'Process Other Payment
                    fMsg.pbWait.Value += 5
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    fMsg.lblMessage.Text = "Processing Other Payment.."
                    fMsg.lblMessage.Refresh()
                    ProcessBOL.ProcessOtherPayment()


                    'Process on cost
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    fMsg.pbWait.Value += 5
                    fMsg.lblMessage.Text = "Processing On Cost Payment.."
                    fMsg.lblMessage.Refresh()
                    ProcessBOL.OnCostProcess()
                    '=> => => => => => => => => => => => => => => => => => => => => => 

                    'Process on cost details 
                    ProcessBOL.OnCostProcessDet()
                    fMsg.pbWait.Value += 10

                    'Insert records to Analysis Harvesting Cost table [Checkroll].[AnalyHarvestingCostInsert]
                    'Palani
                    'Also adds hk value to vehicle if charged in distribution
                    '=> => => => => => => => => => => => => => => => => => => => => => 
                    fMsg.lblMessage.Text = "Processing Harvesting Cost.."
                    fMsg.lblMessage.Refresh()
                    ProcessBOL.AnalyHarvestingCostInsert()
                    ProcessBOL.AnalyRubberCostInsert()
                    ProcessBOL.TransferCheckrollToVehicleCharge()
                    fMsg.pbWait.Value += 5
                    '=> => => => => => => => => => => => => => => => => => => => => => 


                    'CHECKROLL JOURNAL
                    fMsg.lblMessage.Text = "Processing Checkroll Journal.."
                    fMsg.lblMessage.Refresh()
                    ProcessBOL.CheckrollJournalInsert()
                    fMsg.pbWait.Value += 5
                    ' Jum'at, 1 Jan 2010, 14:59

                    'Transfer Allowance
                    fMsg.lblMessage.Text = "Processing Transfer Values to Allowance Codes"
                    fMsg.lblMessage.Refresh()
                    ProcessBOL.TransferSalaryToAllowance()

                    'fMsg.pbWait.Value += 5


                    fMsg.lblMessage.Text = "Processing Task Monitor Update for Monthly Process.."
                    fMsg.lblMessage.Refresh()
                    'Update Task Monitor table when Monthly Processing is completed 
                    CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("Y")
                    ' END Jum'at, 1 Jan 2010, 14:59

                    '----- Processing Average Bunch Weight Calculations
                    fMsg.pbWait.Value += 5
                    ' Jum'at, 1 Jan 2010, 14:59

                    LblStatus.Visible = False

                    fMsg.Close()

                    Cursor = Cursors.Default

                    MonthlyProcessingAlert(startTime)
                    If ConfigurationManager.AppSettings.Item("OverwriteActiveMonthYear") = "1" Then
                        GlobalPPT.strActMthYearID = currentActiveMonthYear
                    End If
                    MsgBox("Processing Done", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Information")
                Catch ex As Exception
                    If fMsg.Visible = True Then
                        fMsg.Close()
                    End If
                    MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End Try

                Cursor = Cursors.Default

            Else
                MonthlyProcess = intProcessStoped
                Exit Function
            End If
        Catch ex As Exception

        Finally
            'PCircle.Close()
        End Try

        MonthlyProcess = intProcessCompleted
    End Function


    Private Sub MonthlyProcessingAlert(ByVal processStartTime As DateTime)

        Dim oDSN As String = String.Empty 'BSPDSN
        Dim oDatabase As String = String.Empty
        Dim oUserName As String = String.Empty
        Dim oPwd As String = String.Empty

        oDSN = GlobalPPT.SelectedDB.DSN
        oUserName = GlobalPPT.SelectedDB.User
        oPwd = GlobalPPT.SelectedDB.Password
        oDatabase = GlobalPPT.SelectedDB.DBName

        Dim tblAdt As New Odbc.OdbcDataAdapter
        Dim ds As New DataSet
        Dim con As New Odbc.OdbcConnection
        Dim cmd As New Odbc.OdbcCommand
        Dim constr As String = " DSN=" & oDSN & ";UID=" & oUserName & "; pwd=" & oPwd & ";"

        con = New Odbc.OdbcConnection(constr)

        con.Open()

        cmd.Connection = con

        cmd.CommandText = "Checkroll.MonthlyProcessingAlert '" & GlobalPPT.strEstateID & "','" & GlobalPPT.strActMthYearID & "'"
        cmd.CommandType = CommandType.StoredProcedure

        tblAdt.SelectCommand = cmd
        tblAdt.Fill(ds, "MonthlyProcessingAlert;1")

        If ds.Tables(0).Rows.Count > 0 Then

            Dim endTime As DateTime = DateTime.Now()

            MessageBox.Show(ds.Tables(0).Rows(0).Item("SalaryZero") & " Employees - Net Salary = 0" & Chr(13) & Chr(10) & _
            ds.Tables(0).Rows(0).Item("SalNotProcessed") & " Active Employees - Salary Not Processed" & Chr(13) & Chr(10) & _
            "Please Update Employee [Status] in Employee Master" & Chr(13) & Chr(10) & "Total Processing Time in Minutes: " & DateDiff(DateInterval.Minute, processStartTime, endTime).ToString(), "Alert")

        End If

    End Sub

    'Added by nelson
    Private Sub UpdateSalary()
        Dim dtEmp As New DataTable()
        Dim dt As New DataTable()
        Dim dtAct As New DataTable()
        Dim dtTaxable_Income As New DataTable()
        Dim dtDedTax As New DataTable()

        'Get all Active employees for a given duration
        dtEmp = ProcessDal.GetActiveEmployee2()
        Dim b As Integer
        fMsg.lblMessage.Text = "Processing Tax Calculation - Getting Marital Status of Active Month."
        fMsg.lblMessage.Refresh()
        Dim i As Integer
        For Each rowEmp As DataRow In dtEmp.Rows
            fMsg.lblMessage.Text = "Processing Tax Calculation - Getting Tax Income for Employee Code:" + rowEmp("EmpCode").ToString()
            Debug.Print(i.ToString())
            i += 1
            fMsg.lblMessage.Refresh()
            GlobalPPT.EmpCode = rowEmp("EmpCode").ToString()

            CheckRollTaxTemp1PPT.Status = rowEmp("Status").ToString()
            If IsDate(rowEmp("StatusDate")) Then
                CheckRollTaxTemp1PPT.StatusDate = Convert.ToDateTime(rowEmp("StatusDate")).ToString("yyyyMMdd")
            Else
                CheckRollTaxTemp1PPT.StatusDate = rowEmp("StatusDate").ToString()
            End If
            MaritalStatus = rowEmp("MaritalStatus").ToString()
            GlobalPPT.WorkerType = rowEmp("WorkerType").ToString()
            GlobalPPT.Empid = rowEmp("Empid").ToString()

            'returns tax calculation values for a specific employee for a specific month
            dt = ProcessDal.GetGradeRange()

            ' the above SP (GetGradeRange()) result will always return 1 record.. no need for a loop, should check this later!!!!
            For Each row As DataRow In dt.Rows
                If row("TaxExemptionHusbWife").ToString() <> String.Empty Then
                    TaxExemptionHusbWife = CType(row("TaxExemptionHusbWife").ToString(), Double)
                Else
                    TaxExemptionHusbWife = 0
                End If

                If row("TaxExemptionChild").ToString() <> String.Empty Then
                    TaxExemptionChild = CType(row("TaxExemptionChild").ToString(), Double)
                Else
                    TaxExemptionChild = 0
                End If

                If row("TaxExemptionWorker").ToString() <> String.Empty Then
                    TaxExemptionWorker = CType(row("TaxExemptionWorker").ToString(), Double)
                Else
                    TaxExemptionWorker = 0
                End If

                If row("GradeI").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeI = CType(row("GradeI").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeI = 0
                End If

                If row("GradeII").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeII = CType(row("GradeII").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeII = 0
                End If

                If row("GradeIII").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIII = CType(row("GradeIII").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIII = 0
                End If

                If row("GradeIV").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIV = CType(row("GradeIV").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIV = 0
                End If

                If row("GradeV").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeV = CType(row("GradeV").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeV = 0
                End If

                If row("GradeIRange").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIRange = CType(row("GradeIRange").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIRange = 0
                End If

                If row("GradeIIRangeFrom").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIRangeFrom = CType(row("GradeIIRangeFrom").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIRangeFrom = 0
                End If

                If row("GradeIIRangeTo").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIRangeTo = CType(row("GradeIIRangeTo").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIRangeTo = 0
                End If

                If row("GradeIIIRangeFrom").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIIRangeFrom = CType(row("GradeIIIRangeFrom").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIIRangeFrom = 0
                End If

                If row("GradeIIIRangeTo").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIIRangeTo = CType(row("GradeIIIRangeTo").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIIRangeTo = 0
                End If

                If row("GradeIVRangeFrom").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIVRangeFrom = CType(row("GradeIVRangeFrom").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIVRangeFrom = 0
                End If

                If row("GradeIVRangeTo").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIVRangeTo = CType(row("GradeIVRangeTo").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIVRangeTo = 0
                End If

                If row("GradeINPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeINPWP = CType(row("GradeINPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeINPWP = 0
                End If

                If row("GradeIRangeNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIRangeNPWP = CType(row("GradeIRangeNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIRangeNPWP = 0
                End If

                If row("GradeIINPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIINPWP = CType(row("GradeIINPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIINPWP = 0
                End If

                If row("GradeIIRangeFromNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIRangeFromNPWP = CType(row("GradeIIRangeFromNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIRangeFromNPWP = 0
                End If

                If row("GradeIIRangeToNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIRangeToNPWP = CType(row("GradeIIRangeToNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIRangeToNPWP = 0
                End If

                If row("GradeIIINPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIINPWP = CType(row("GradeIIINPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIINPWP = 0
                End If

                If row("GradeIIIRangeFromNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIIRangeFromNPWP = CType(row("GradeIIIRangeFromNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIIRangeFromNPWP = 0
                End If

                If row("GradeIIIRangeToNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIIIRangeToNPWP = CType(row("GradeIIIRangeToNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIIIRangeToNPWP = 0
                End If

                If row("GradeIVNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIVNPWP = CType(row("GradeIVNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIVNPWP = 0
                End If


                If row("GradeIVRangeFromNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIVRangeFromNPWP = CType(row("GradeIVRangeFromNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIVRangeFromNPWP = 0
                End If


                If row("GradeIVRangeToNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeIVRangeToNPWP = CType(row("GradeIVRangeToNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeIVRangeToNPWP = 0
                End If


                If row("GradeVNPWP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.GradeVNPWP = CType(row("GradeVNPWP").ToString(), Double)
                Else
                    CheckRollTaxPPT.GradeVNPWP = 0
                End If


                If (row("PTKP").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.PTKP = CType(row("PTKP").ToString(), Double)
                Else
                    CheckRollTaxPPT.PTKP = 0
                End If

                If row("MaxAllowance").ToString() <> String.Empty Then
                    CheckRollTaxPPT.MaxAllowance = CType(row("MaxAllowance").ToString(), Double)
                Else
                    CheckRollTaxPPT.MaxAllowance = 0
                End If

                If row("FunctionalAllowanceP").ToString() <> String.Empty Then
                    CheckRollTaxPPT.FunctionalAllowanceP = CType(row("FunctionalAllowanceP").ToString(), Double)
                Else
                    CheckRollTaxPPT.FunctionalAllowanceP = 0
                End If

                CheckRollTaxPPT.EmpCode = row("EmpCode").ToString()
                GlobalPPT.Mandore = row("Mandore").ToString()

                If row("GradeI").ToString() <> String.Empty Then
                    GradeI = CType(row("GradeI").ToString(), Double)
                Else
                    GradeI = 0
                End If

                If row("GradeII").ToString() <> String.Empty Then
                    GradeII = CType(row("GradeII").ToString(), Double)
                Else
                    GradeII = 0
                End If

                If row("GradeIII").ToString() <> String.Empty Then
                    GradeIII = CType(row("GradeIII").ToString(), Double)
                Else
                    GradeIII = 0
                End If

                If row("GradeIV").ToString() <> String.Empty Then
                    GradeIV = CType(row("GradeIV").ToString(), Double)
                Else
                    GradeIV = 0
                End If

                If row("GradeV").ToString() <> String.Empty Then
                    GradeV = CType(row("GradeV").ToString(), Double)
                Else
                    GradeV = 0
                End If

                If row("GradeIRange").ToString() <> String.Empty Then
                    GradeIRange = CType(row("GradeIRange").ToString(), Double)
                Else
                    GradeIRange = 0
                End If

                If row("GradeIIRangeFrom").ToString() <> String.Empty Then
                    GradeIIRangeFrom = CType(row("GradeIIRangeFrom").ToString(), Double)
                Else
                    GradeIIRangeFrom = 0
                End If

                If row("GradeIIRangeTo").ToString() <> String.Empty Then
                    GradeIIRangeTo = CType(row("GradeIIRangeTo").ToString(), Double)
                Else
                    GradeIIRangeTo = 0
                End If

                If row("GradeIIIRangeFrom").ToString() <> String.Empty Then
                    GradeIIIRangeFrom = CType(row("GradeIIIRangeFrom").ToString(), Double)
                Else
                    GradeIIIRangeFrom = 0
                End If

                If row("GradeIIIRangeTo").ToString() <> String.Empty Then
                    GradeIIIRangeTo = CType(row("GradeIIIRangeTo").ToString(), Double)
                Else
                    GradeIIIRangeTo = 0
                End If

                If row("GradeIVRangeFrom").ToString() <> String.Empty Then
                    GradeIVRangeFrom = CType(row("GradeIVRangeFrom").ToString(), Double)
                Else
                    GradeIVRangeFrom = 0
                End If

                If row("GradeIVRangeTo").ToString() <> String.Empty Then
                    GradeIVRangeTo = CType(row("GradeIVRangeTo").ToString(), Double)
                Else
                    GradeIVRangeTo = 0
                End If

                If row("GradeINPWP").ToString() <> String.Empty Then
                    GradeINPWP = CType(row("GradeINPWP").ToString(), Double)
                Else
                    GradeINPWP = 0
                End If

                If row("GradeIINPWP").ToString() <> String.Empty Then
                    GradeIINPWP = CType(row("GradeIINPWP").ToString(), Double)
                Else
                    GradeIINPWP = 0
                End If

                If row("GradeIIINPWP").ToString() <> String.Empty Then
                    GradeIIINPWP = CType(row("GradeIIINPWP").ToString(), Double)
                Else
                    GradeIIINPWP = 0
                End If

                If row("GradeIVNPWP").ToString() <> String.Empty Then
                    GradeIVNPWP = CType(row("GradeIVNPWP").ToString(), Double)
                Else
                    GradeIVNPWP = 0
                End If

                If row("GradeVNPWP").ToString() <> String.Empty Then
                    GradeVNPWP = CType(row("GradeVNPWP").ToString(), Double)
                Else
                    GradeVNPWP = 0
                End If


                If row("GradeIRangeNPWP").ToString() <> String.Empty Then
                    GradeIRangeNPWP = CType(row("GradeIRangeNPWP").ToString(), Double)
                Else
                    GradeIRangeNPWP = 0
                End If

                If row("GradeIIRangeFromNPWP").ToString() <> String.Empty Then
                    GradeIIRangeFromNPWP = CType(row("GradeIIRangeFromNPWP").ToString(), Double)
                Else
                    GradeIIRangeFromNPWP = 0
                End If

                If row("GradeIIRangeToNPWP").ToString() <> String.Empty Then
                    GradeIIRangeToNPWP = CType(row("GradeIIRangeToNPWP").ToString(), Double)
                Else
                    GradeIIRangeToNPWP = 0
                End If

                If row("GradeIIIRangeFromNPWP").ToString() <> String.Empty Then
                    GradeIIIRangeFromNPWP = CType(row("GradeIIIRangeFromNPWP").ToString(), Double)
                Else
                    GradeIIIRangeFromNPWP = 0
                End If

                If row("GradeIIIRangeToNPWP").ToString() <> String.Empty Then
                    GradeIIIRangeToNPWP = CType(row("GradeIIIRangeToNPWP").ToString(), Double)
                Else
                    GradeIIIRangeToNPWP = 0
                End If

                If row("GradeIVRangeFromNPWP").ToString() <> String.Empty Then
                    GradeIVRangeFromNPWP = CType(row("GradeIVRangeFromNPWP").ToString(), Double)
                Else
                    GradeIVRangeFromNPWP = 0
                End If

                If row("GradeIVRangeToNPWP").ToString() <> String.Empty Then
                    GradeIVRangeToNPWP = CType(row("GradeIVRangeToNPWP").ToString(), Double)
                Else
                    GradeIVRangeToNPWP = 0
                End If

            Next

            ' following will return all ActiveMonthID's, Regular & Irregular Income, Accident Insurance, Salary, Tax, Deductions etc for 
            ' each month (upto current month)
            dtAct = ProcessDal.GetMaritalStatusAndActMnth()
            For Each rowAct As DataRow In dtAct.Rows
                CheckRollTaxPPT.ActiveMonthYearID1 = rowAct("ActiveMonthYearID1").ToString()
                CheckRollTaxPPT.ActiveMonthYearID2 = rowAct("ActiveMonthYearID2").ToString()
                CheckRollTaxPPT.ActiveMonthYearID3 = rowAct("ActiveMonthYearID3").ToString()
                CheckRollTaxPPT.ActiveMonthYearID4 = rowAct("ActiveMonthYearID4").ToString()
                CheckRollTaxPPT.ActiveMonthYearID5 = rowAct("ActiveMonthYearID5").ToString()
                CheckRollTaxPPT.ActiveMonthYearID6 = rowAct("ActiveMonthYearID6").ToString()
                CheckRollTaxPPT.ActiveMonthYearID7 = rowAct("ActiveMonthYearID7").ToString()
                CheckRollTaxPPT.ActiveMonthYearID8 = rowAct("ActiveMonthYearID8").ToString()
                CheckRollTaxPPT.ActiveMonthYearID9 = rowAct("ActiveMonthYearID9").ToString()
                CheckRollTaxPPT.ActiveMonthYearID10 = rowAct("ActiveMonthYearID10").ToString()
                CheckRollTaxPPT.ActiveMonthYearID11 = rowAct("ActiveMonthYearID11").ToString()
                CheckRollTaxPPT.ActiveMonthYearID12 = rowAct("ActiveMonthYearID12").ToString()

                If (rowAct("Income_Regular1").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular1 = CType(rowAct("Income_Regular1").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular1 = 0
                End If

                If (rowAct("Income_Regular2").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular2 = CType(rowAct("Income_Regular2").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular2 = 0
                End If

                If (rowAct("Income_Regular3").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular3 = CType(rowAct("Income_Regular3").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular3 = 0
                End If

                If (rowAct("Income_Regular4").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular4 = CType(rowAct("Income_Regular4").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular4 = 0
                End If

                If (rowAct("Income_Regular5").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular5 = CType(rowAct("Income_Regular5").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular5 = 0
                End If

                If (rowAct("Income_Regular6").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular6 = CType(rowAct("Income_Regular6").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular6 = 0
                End If

                If (rowAct("Income_Regular7").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular7 = CType(rowAct("Income_Regular7").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular7 = 0
                End If

                If (rowAct("Income_Regular8").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular8 = CType(rowAct("Income_Regular8").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular8 = 0
                End If
                If (rowAct("Income_Regular9").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular9 = CType(rowAct("Income_Regular9").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular9 = 0
                End If
                If (rowAct("Income_Regular10").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular10 = CType(rowAct("Income_Regular10").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular10 = 0
                End If
                If (rowAct("Income_Regular11").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular11 = CType(rowAct("Income_Regular11").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular11 = 0
                End If
                If (rowAct("Income_Regular12").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Regular12 = CType(rowAct("Income_Regular12").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Regular12 = 0
                End If

                Accident_Insurance1 = 0
                Accident_Insurance2 = 0
                Accident_Insurance3 = 0
                Accident_Insurance4 = 0
                Accident_Insurance5 = 0
                Accident_Insurance6 = 0
                Accident_Insurance7 = 0
                Accident_Insurance8 = 0
                Accident_Insurance9 = 0
                Accident_Insurance10 = 0
                Accident_Insurance11 = 0
                Accident_Insurance12 = 0

                If (rowAct("Accident_Insurance1").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance1 = CType(rowAct("Accident_Insurance1").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance1 = 0
                End If
                If (rowAct("Accident_Insurance2").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance2 = CType(rowAct("Accident_Insurance2").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance2 = 0
                End If
                If (rowAct("Accident_Insurance3").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance3 = CType(rowAct("Accident_Insurance3").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance3 = 0
                End If
                If (rowAct("Accident_Insurance4").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance4 = CType(rowAct("Accident_Insurance4").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance4 = 0
                End If
                If (rowAct("Accident_Insurance5").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance5 = CType(rowAct("Accident_Insurance5").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance5 = 0
                End If
                If (rowAct("Accident_Insurance6").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance6 = CType(rowAct("Accident_Insurance6").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance6 = 0
                End If
                If (rowAct("Accident_Insurance7").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance7 = CType(rowAct("Accident_Insurance7").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance7 = 0
                End If
                If (rowAct("Accident_Insurance8").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance8 = CType(rowAct("Accident_Insurance8").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance8 = 0
                End If
                If (rowAct("Accident_Insurance9").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance9 = CType(rowAct("Accident_Insurance9").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance9 = 0
                End If
                If (rowAct("Accident_Insurance10").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance10 = CType(rowAct("Accident_Insurance10").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance10 = 0
                End If

                If (rowAct("Accident_Insurance11").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance11 = CType(rowAct("Accident_Insurance11").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance11 = 0
                End If

                If (rowAct("Accident_Insurance12").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Accident_Insurance12 = CType(rowAct("Accident_Insurance12").ToString(), Double)
                Else
                    CheckRollTaxPPT.Accident_Insurance12 = 0
                End If

                If (rowAct("Income_Irregular1").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular1 = CType(rowAct("Income_Irregular1").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular1 = 0
                End If
                If (rowAct("Income_Irregular2").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular2 = CType(rowAct("Income_Irregular2").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular2 = 0
                End If
                If (rowAct("Income_Irregular3").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular3 = CType(rowAct("Income_Irregular3").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular3 = 0
                End If
                If (rowAct("Income_Irregular4").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular4 = CType(rowAct("Income_Irregular4").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular4 = 0
                End If
                If (rowAct("Income_Irregular5").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular5 = CType(rowAct("Income_Irregular5").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular5 = 0
                End If
                If (rowAct("Income_Irregular6").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular6 = CType(rowAct("Income_Irregular6").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular6 = 0
                End If
                If (rowAct("Income_Irregular7").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular7 = CType(rowAct("Income_Irregular7").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular7 = 0
                End If
                If (rowAct("Income_Irregular8").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular8 = CType(rowAct("Income_Irregular8").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular8 = 0
                End If
                If (rowAct("Income_Irregular9").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular9 = CType(rowAct("Income_Irregular9").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular9 = 0
                End If
                If (rowAct("Income_Irregular10").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular10 = CType(rowAct("Income_Irregular10").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular10 = 0
                End If
                If (rowAct("Income_Irregular11").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular11 = CType(rowAct("Income_Irregular11").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular11 = 0
                End If
                If (rowAct("Income_Irregular12").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Income_Irregular12 = CType(rowAct("Income_Irregular12").ToString(), Double)
                Else
                    CheckRollTaxPPT.Income_Irregular12 = 0
                End If


                If (rowAct("ActiveMonth1Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth1Sal = CType(rowAct("ActiveMonth1Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth1Sal = 0
                End If
                If (rowAct("ActiveMonth2Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth2Sal = CType(rowAct("ActiveMonth2Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth2Sal = 0
                End If
                If (rowAct("ActiveMonth3Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth3Sal = CType(rowAct("ActiveMonth3Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth3Sal = 0
                End If
                If (rowAct("ActiveMonth4Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth4Sal = CType(rowAct("ActiveMonth4Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth4Sal = 0
                End If
                If (rowAct("ActiveMonth5Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth5Sal = CType(rowAct("ActiveMonth5Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth5Sal = 0
                End If
                If (rowAct("ActiveMonth6Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth6Sal = CType(rowAct("ActiveMonth6Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth6Sal = 0
                End If
                If (rowAct("ActiveMonth7Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth7Sal = CType(rowAct("ActiveMonth7Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth7Sal = 0
                End If
                If (rowAct("ActiveMonth8Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth8Sal = CType(rowAct("ActiveMonth8Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth8Sal = 0
                End If
                If (rowAct("ActiveMonth9Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth9Sal = CType(rowAct("ActiveMonth9Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth9Sal = 0
                End If
                If (rowAct("ActiveMonth10Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth10Sal = CType(rowAct("ActiveMonth10Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth10Sal = 0
                End If
                If (rowAct("ActiveMonth11Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth11Sal = CType(rowAct("ActiveMonth11Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth11Sal = 0
                End If
                If (rowAct("ActiveMonth12Sal").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth12Sal = CType(rowAct("ActiveMonth12Sal").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth12Sal = 0
                End If


                If (rowAct("ActiveMonth1Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth1Tax = CType(rowAct("ActiveMonth1Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth1Tax = 0
                End If
                If (rowAct("ActiveMonth2Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth2Tax = CType(rowAct("ActiveMonth2Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth2Tax = 0
                End If
                If (rowAct("ActiveMonth3Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth3Tax = CType(rowAct("ActiveMonth3Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth3Tax = 0
                End If
                If (rowAct("ActiveMonth4Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth4Tax = CType(rowAct("ActiveMonth4Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth4Tax = 0
                End If
                If (rowAct("ActiveMonth5Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth5Tax = CType(rowAct("ActiveMonth5Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth5Tax = 0
                End If
                If (rowAct("ActiveMonth6Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth6Tax = CType(rowAct("ActiveMonth6Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth6Tax = 0
                End If
                If (rowAct("ActiveMonth7Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth7Tax = CType(rowAct("ActiveMonth7Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth7Tax = 0
                End If
                If (rowAct("ActiveMonth8Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth8Tax = CType(rowAct("ActiveMonth8Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth8Tax = 0
                End If
                If (rowAct("ActiveMonth9Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth9Tax = CType(rowAct("ActiveMonth9Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth9Tax = 0
                End If
                If (rowAct("ActiveMonth10Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth10Tax = CType(rowAct("ActiveMonth10Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth10Tax = 0
                End If
                If (rowAct("ActiveMonth11Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth11Tax = CType(rowAct("ActiveMonth11Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth11Tax = 0
                End If
                If (rowAct("ActiveMonth12Tax").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.ActiveMonth12Tax = CType(rowAct("ActiveMonth12Tax").ToString(), Double)
                Else
                    CheckRollTaxPPT.ActiveMonth12Tax = 0
                End If

                If (rowAct("Category").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.Category = rowAct("Category").ToString
                Else
                    CheckRollTaxPPT.Category = ""
                End If
                If (rowAct("JHTPercent").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.JHTPercent = CType(rowAct("JHTPercent").ToString(), Double)
                Else
                    CheckRollTaxPPT.JHTPercent = 0
                End If
                If (rowAct("HIPMonthlyRate").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.HIPMonthlyRate = CType(rowAct("HIPMonthlyRate").ToString(), Double)
                Else
                    CheckRollTaxPPT.HIPMonthlyRate = 0
                End If
                If (rowAct("NPWP").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.NPWP = rowAct("NPWP").ToString()
                Else
                    CheckRollTaxPPT.NPWP = ""
                End If

                If (rowAct("DedTaxCompany").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.DedTaxCompany = rowAct("DedTaxCompany").ToString()
                Else
                    CheckRollTaxPPT.DedTaxCompany = 0
                End If
                If (rowAct("DedAdvance").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.DedAdvance = rowAct("DedAdvance").ToString()
                Else
                    CheckRollTaxPPT.DedAdvance = 0
                End If
                If (rowAct("DedOther").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.DedOther = rowAct("DedOther").ToString()
                Else
                    CheckRollTaxPPT.DedOther = 0
                End If

                If (rowAct("TotalBruto").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.TotalBruto = rowAct("TotalBruto").ToString()
                Else
                    CheckRollTaxPPT.TotalBruto = 0
                End If

                If (rowAct("DedAstek").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.DedAstek = rowAct("DedAstek").ToString()
                Else
                    CheckRollTaxPPT.DedAstek = 0
                End If


                If (rowAct("THR").ToString() <> String.Empty) Then
                    CheckRollTaxPPT.THR = rowAct("THR").ToString()
                Else ' ADDED BY PALANI
                    CheckRollTaxPPT.THR = 0
                End If


                CheckRollTaxTemp1PPT.BasicRate = 0
                CheckRollTaxTemp1PPT.dDeductionCostMax = 0
                CheckRollTaxTemp1PPT.RiceDividerDays = 0

                If (rowAct("BasicRate").ToString() <> String.Empty) Then
                    CheckRollTaxTemp1PPT.BasicRate = CType(rowAct("BasicRate").ToString(), Double)
                Else
                    CheckRollTaxTemp1PPT.BasicRate = 0
                End If
                If (rowAct("dDeductionCostMax").ToString() <> String.Empty) Then
                    CheckRollTaxTemp1PPT.dDeductionCostMax = CType(rowAct("dDeductionCostMax").ToString(), Double)
                Else
                    CheckRollTaxTemp1PPT.dDeductionCostMax = 0
                End If
                If (rowAct("RiceDividerDays").ToString() <> String.Empty) Then
                    CheckRollTaxTemp1PPT.RiceDividerDays = CType(rowAct("RiceDividerDays").ToString(), Double)
                Else
                    CheckRollTaxTemp1PPT.RiceDividerDays = 0
                End If

            Next

            If CheckRollTaxPPT.THR > 0 Or CheckRollTaxPPT.Category <> String.Empty Then

                'If THR is greater than zero and Category is not empty get taxable income
                'this calculation will be done based on values returned from [Checkroll].[GetMaritalStatusAndActMnth]
                dtTaxable_Income = ProcessDal.GetTaxIncome()

                For Each rowTax As DataRow In dtTaxable_Income.Rows
                    If (rowTax("Taxable_Income_Regular1").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular1 = CType(rowTax("Taxable_Income_Regular1").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular1 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular2").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular2 = CType(rowTax("Taxable_Income_Regular2").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular2 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular3").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular3 = CType(rowTax("Taxable_Income_Regular3").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular3 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular4").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular4 = CType(rowTax("Taxable_Income_Regular4").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular4 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular5").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular5 = CType(rowTax("Taxable_Income_Regular5").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular5 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular6").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular6 = CType(rowTax("Taxable_Income_Regular6").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular6 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular7").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular7 = CType(rowTax("Taxable_Income_Regular7").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular7 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular8").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular8 = CType(rowTax("Taxable_Income_Regular8").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular8 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular9").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular9 = CType(rowTax("Taxable_Income_Regular9").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular9 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular10").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular10 = CType(rowTax("Taxable_Income_Regular10").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular10 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular11").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular11 = CType(rowTax("Taxable_Income_Regular11").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular11 = 0
                    End If
                    If (rowTax("Taxable_Income_Regular12").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Regular12 = CType(rowTax("Taxable_Income_Regular12").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Regular12 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular1").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular1 = CType(rowTax("Taxable_Income_IRRegular1").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular1 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular2").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular2 = CType(rowTax("Taxable_Income_IRRegular2").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular2 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular3").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular3 = CType(rowTax("Taxable_Income_IRRegular3").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular3 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular4").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular4 = CType(rowTax("Taxable_Income_IRRegular4").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular4 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular5").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular5 = CType(rowTax("Taxable_Income_IRRegular5").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular5 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular6").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular6 = CType(rowTax("Taxable_Income_IRRegular6").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular6 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular7").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular7 = CType(rowTax("Taxable_Income_IRRegular7").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular7 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular8").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular8 = CType(rowTax("Taxable_Income_IRRegular8").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular8 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular9").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular9 = CType(rowTax("Taxable_Income_IRRegular9").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular9 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular10").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular10 = CType(rowTax("Taxable_Income_IRRegular10").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular10 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular11").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular11 = CType(rowTax("Taxable_Income_IRRegular11").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular11 = 0
                    End If
                    If (rowTax("Taxable_Income_IRRegular12").ToString() <> String.Empty) Then
                        CheckRollTaxPPT.Taxable_Income_Irregular12 = CType(rowTax("Taxable_Income_IRRegular12").ToString(), Double)
                    Else
                        CheckRollTaxPPT.Taxable_Income_Irregular12 = 0
                    End If
                    'fMsg.lblMessage.Text = "Processing Tax Calculation - Getting Tax Income..."
                    'fMsg.lblMessage.Refresh()
                Next
                processs()

                'Do the final processing of salary
                dtDedTax = ProcessDal.GetDedTaxOfEmployee()

            End If
            dt.Dispose()
            dtAct.Dispose()
            dtDedTax.Dispose()
            dtTaxable_Income.Dispose()

        Next
        dtEmp.Dispose()

    End Sub
    'Added by nelson
    Public Sub processs()

        Taxable_Income_TRegular1 = 0
        Taxable_Income_TRegular2 = 0
        Taxable_Income_TRegular3 = 0
        Taxable_Income_TRegular4 = 0
        Taxable_Income_TRegular5 = 0
        Taxable_Income_TRegular6 = 0
        Taxable_Income_TRegular7 = 0
        Taxable_Income_TRegular8 = 0
        Taxable_Income_TRegular9 = 0
        Taxable_Income_TRegular10 = 0
        Taxable_Income_TRegular11 = 0
        Taxable_Income_TRegular12 = 0

        Taxable_Income_IrTRegular1 = 0
        Taxable_Income_IrTRegular2 = 0
        Taxable_Income_IrTRegular3 = 0
        Taxable_Income_IrTRegular4 = 0
        Taxable_Income_IrTRegular5 = 0
        Taxable_Income_IrTRegular6 = 0
        Taxable_Income_IrTRegular7 = 0
        Taxable_Income_IrTRegular8 = 0
        Taxable_Income_IrTRegular9 = 0
        Taxable_Income_IrTRegular10 = 0
        Taxable_Income_IrTRegular11 = 0
        Taxable_Income_IrTRegular12 = 0


        CheckRollTaxPPT.PPH_21_Regular1R1 = 0
        CheckRollTaxPPT.PPH_21_Regular2R1 = 0
        CheckRollTaxPPT.PPH_21_Regular3R1 = 0
        CheckRollTaxPPT.PPH_21_Regular4R1 = 0
        CheckRollTaxPPT.PPH_21_Regular5R1 = 0
        CheckRollTaxPPT.PPH_21_Regular6R1 = 0
        CheckRollTaxPPT.PPH_21_Regular7R1 = 0
        CheckRollTaxPPT.PPH_21_Regular8R1 = 0
        CheckRollTaxPPT.PPH_21_Regular9R1 = 0
        CheckRollTaxPPT.PPH_21_Regular10R1 = 0
        CheckRollTaxPPT.PPH_21_Regular11R1 = 0
        CheckRollTaxPPT.PPH_21_Regular12R1 = 0

        CheckRollTaxPPT.PPH_21_Regular1R2 = 0
        CheckRollTaxPPT.PPH_21_Regular2R2 = 0
        CheckRollTaxPPT.PPH_21_Regular3R2 = 0
        CheckRollTaxPPT.PPH_21_Regular4R2 = 0
        CheckRollTaxPPT.PPH_21_Regular5R2 = 0
        CheckRollTaxPPT.PPH_21_Regular6R2 = 0
        CheckRollTaxPPT.PPH_21_Regular7R2 = 0
        CheckRollTaxPPT.PPH_21_Regular8R2 = 0
        CheckRollTaxPPT.PPH_21_Regular9R2 = 0
        CheckRollTaxPPT.PPH_21_Regular10R2 = 0
        CheckRollTaxPPT.PPH_21_Regular11R2 = 0
        CheckRollTaxPPT.PPH_21_Regular12R2 = 0


        CheckRollTaxPPT.PPH_21_Regular1R3 = 0
        CheckRollTaxPPT.PPH_21_Regular2R3 = 0
        CheckRollTaxPPT.PPH_21_Regular3R3 = 0
        CheckRollTaxPPT.PPH_21_Regular4R3 = 0
        CheckRollTaxPPT.PPH_21_Regular5R3 = 0
        CheckRollTaxPPT.PPH_21_Regular6R3 = 0
        CheckRollTaxPPT.PPH_21_Regular7R3 = 0
        CheckRollTaxPPT.PPH_21_Regular8R3 = 0
        CheckRollTaxPPT.PPH_21_Regular9R3 = 0
        CheckRollTaxPPT.PPH_21_Regular10R3 = 0
        CheckRollTaxPPT.PPH_21_Regular11R3 = 0
        CheckRollTaxPPT.PPH_21_Regular12R3 = 0


        CheckRollTaxPPT.PPH_21_Regular1R4 = 0
        CheckRollTaxPPT.PPH_21_Regular2R4 = 0
        CheckRollTaxPPT.PPH_21_Regular3R4 = 0
        CheckRollTaxPPT.PPH_21_Regular4R4 = 0
        CheckRollTaxPPT.PPH_21_Regular5R4 = 0
        CheckRollTaxPPT.PPH_21_Regular6R4 = 0
        CheckRollTaxPPT.PPH_21_Regular7R4 = 0
        CheckRollTaxPPT.PPH_21_Regular8R4 = 0
        CheckRollTaxPPT.PPH_21_Regular9R4 = 0
        CheckRollTaxPPT.PPH_21_Regular10R4 = 0
        CheckRollTaxPPT.PPH_21_Regular11R4 = 0
        CheckRollTaxPPT.PPH_21_Regular12R4 = 0

        CheckRollTaxPPT.PPH_21_Regular1R5 = 0
        CheckRollTaxPPT.PPH_21_Regular2R5 = 0
        CheckRollTaxPPT.PPH_21_Regular3R5 = 0
        CheckRollTaxPPT.PPH_21_Regular4R5 = 0
        CheckRollTaxPPT.PPH_21_Regular5R5 = 0
        CheckRollTaxPPT.PPH_21_Regular6R5 = 0
        CheckRollTaxPPT.PPH_21_Regular7R5 = 0
        CheckRollTaxPPT.PPH_21_Regular8R5 = 0
        CheckRollTaxPPT.PPH_21_Regular9R5 = 0
        CheckRollTaxPPT.PPH_21_Regular10R5 = 0
        CheckRollTaxPPT.PPH_21_Regular11R5 = 0
        CheckRollTaxPPT.PPH_21_Regular12R5 = 0

        CheckRollTaxPPT.PPH_21_IRRegular1R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular2R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular3R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular4R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular5R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular6R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular7R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular8R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular9R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular10R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular11R1 = 0
        CheckRollTaxPPT.PPH_21_IRRegular12R1 = 0

        CheckRollTaxPPT.PPH_21_IRRegular1R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular2R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular3R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular4R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular5R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular6R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular7R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular8R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular9R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular10R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular11R2 = 0
        CheckRollTaxPPT.PPH_21_IRRegular12R2 = 0

        CheckRollTaxPPT.PPH_21_IRRegular1R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular2R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular3R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular4R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular5R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular6R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular7R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular8R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular9R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular10R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular11R3 = 0
        CheckRollTaxPPT.PPH_21_IRRegular12R3 = 0

        CheckRollTaxPPT.PPH_21_IRRegular1R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular2R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular3R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular4R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular5R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular6R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular7R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular8R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular9R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular10R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular11R4 = 0
        CheckRollTaxPPT.PPH_21_IRRegular12R4 = 0

        CheckRollTaxPPT.PPH_21_IRRegular1R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular2R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular3R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular4R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular5R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular6R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular7R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular8R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular9R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular10R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular11R5 = 0
        CheckRollTaxPPT.PPH_21_IRRegular12R5 = 0

        If CheckRollTaxPPT.NPWP <> "NO" Then

            Dim pph_regular1 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular1)
            CheckRollTaxPPT.PPH_21_Regular1R1 = pph_regular1.Range1
            CheckRollTaxPPT.PPH_21_Regular1R2 = pph_regular1.Range2
            CheckRollTaxPPT.PPH_21_Regular1R3 = pph_regular1.Range3
            CheckRollTaxPPT.PPH_21_Regular1R4 = pph_regular1.Range4
            CheckRollTaxPPT.PPH_21_Regular1R5 = pph_regular1.Range5

            Dim pph_regular2 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular2)
            CheckRollTaxPPT.PPH_21_Regular2R1 = pph_regular2.Range1
            CheckRollTaxPPT.PPH_21_Regular2R2 = pph_regular2.Range2
            CheckRollTaxPPT.PPH_21_Regular2R3 = pph_regular2.Range3
            CheckRollTaxPPT.PPH_21_Regular2R4 = pph_regular2.Range4
            CheckRollTaxPPT.PPH_21_Regular2R5 = pph_regular2.Range5

            Dim pph_regular3 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular3)
            CheckRollTaxPPT.PPH_21_Regular3R1 = pph_regular3.Range1
            CheckRollTaxPPT.PPH_21_Regular3R2 = pph_regular3.Range2
            CheckRollTaxPPT.PPH_21_Regular3R3 = pph_regular3.Range3
            CheckRollTaxPPT.PPH_21_Regular3R4 = pph_regular3.Range4
            CheckRollTaxPPT.PPH_21_Regular3R5 = pph_regular3.Range5

            Dim pph_regular4 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular4)
            CheckRollTaxPPT.PPH_21_Regular4R1 = pph_regular4.Range1
            CheckRollTaxPPT.PPH_21_Regular4R2 = pph_regular4.Range2
            CheckRollTaxPPT.PPH_21_Regular4R3 = pph_regular4.Range3
            CheckRollTaxPPT.PPH_21_Regular4R4 = pph_regular4.Range4
            CheckRollTaxPPT.PPH_21_Regular4R5 = pph_regular4.Range5

            Dim pph_regular5 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular5)
            CheckRollTaxPPT.PPH_21_Regular5R1 = pph_regular5.Range1
            CheckRollTaxPPT.PPH_21_Regular5R2 = pph_regular5.Range2
            CheckRollTaxPPT.PPH_21_Regular5R3 = pph_regular5.Range3
            CheckRollTaxPPT.PPH_21_Regular5R4 = pph_regular5.Range4
            CheckRollTaxPPT.PPH_21_Regular5R5 = pph_regular5.Range5

            Dim pph_regular6 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular6)
            CheckRollTaxPPT.PPH_21_Regular6R1 = pph_regular6.Range1
            CheckRollTaxPPT.PPH_21_Regular6R2 = pph_regular6.Range2
            CheckRollTaxPPT.PPH_21_Regular6R3 = pph_regular6.Range3
            CheckRollTaxPPT.PPH_21_Regular6R4 = pph_regular6.Range4
            CheckRollTaxPPT.PPH_21_Regular6R5 = pph_regular6.Range5

            Dim pph_regular7 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular7)
            CheckRollTaxPPT.PPH_21_Regular7R1 = pph_regular7.Range1
            CheckRollTaxPPT.PPH_21_Regular7R2 = pph_regular7.Range2
            CheckRollTaxPPT.PPH_21_Regular7R3 = pph_regular7.Range3
            CheckRollTaxPPT.PPH_21_Regular7R4 = pph_regular7.Range4
            CheckRollTaxPPT.PPH_21_Regular7R5 = pph_regular7.Range5

            Dim pph_regular8 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular8)
            CheckRollTaxPPT.PPH_21_Regular8R1 = pph_regular8.Range1
            CheckRollTaxPPT.PPH_21_Regular8R2 = pph_regular8.Range2
            CheckRollTaxPPT.PPH_21_Regular8R3 = pph_regular8.Range3
            CheckRollTaxPPT.PPH_21_Regular8R4 = pph_regular8.Range4
            CheckRollTaxPPT.PPH_21_Regular8R5 = pph_regular8.Range5

            Dim pph_regular9 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular9)
            CheckRollTaxPPT.PPH_21_Regular9R1 = pph_regular9.Range1
            CheckRollTaxPPT.PPH_21_Regular9R2 = pph_regular9.Range2
            CheckRollTaxPPT.PPH_21_Regular9R3 = pph_regular9.Range3
            CheckRollTaxPPT.PPH_21_Regular9R4 = pph_regular9.Range4
            CheckRollTaxPPT.PPH_21_Regular9R5 = pph_regular9.Range5

            Dim pph_regular10 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular10)
            CheckRollTaxPPT.PPH_21_Regular10R1 = pph_regular10.Range1
            CheckRollTaxPPT.PPH_21_Regular10R2 = pph_regular10.Range2
            CheckRollTaxPPT.PPH_21_Regular10R3 = pph_regular10.Range3
            CheckRollTaxPPT.PPH_21_Regular10R4 = pph_regular10.Range4
            CheckRollTaxPPT.PPH_21_Regular10R5 = pph_regular10.Range5

            Dim pph_regular11 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular11)
            CheckRollTaxPPT.PPH_21_Regular11R1 = pph_regular11.Range1
            CheckRollTaxPPT.PPH_21_Regular11R2 = pph_regular11.Range2
            CheckRollTaxPPT.PPH_21_Regular11R3 = pph_regular11.Range3
            CheckRollTaxPPT.PPH_21_Regular11R4 = pph_regular11.Range4
            CheckRollTaxPPT.PPH_21_Regular11R5 = pph_regular11.Range5

            Dim pph_regular12 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Regular12)
            CheckRollTaxPPT.PPH_21_Regular12R1 = pph_regular12.Range1
            CheckRollTaxPPT.PPH_21_Regular12R2 = pph_regular12.Range2
            CheckRollTaxPPT.PPH_21_Regular12R3 = pph_regular12.Range3
            CheckRollTaxPPT.PPH_21_Regular12R4 = pph_regular12.Range4
            CheckRollTaxPPT.PPH_21_Regular12R5 = pph_regular12.Range5

        Else

            Dim pph_regular1 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular1)
            CheckRollTaxPPT.PPH_21_Regular1R1 = pph_regular1.Range1
            CheckRollTaxPPT.PPH_21_Regular1R2 = pph_regular1.Range2
            CheckRollTaxPPT.PPH_21_Regular1R3 = pph_regular1.Range3
            CheckRollTaxPPT.PPH_21_Regular1R4 = pph_regular1.Range4
            CheckRollTaxPPT.PPH_21_Regular1R5 = pph_regular1.Range5

            Dim pph_regular2 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular2)
            CheckRollTaxPPT.PPH_21_Regular2R1 = pph_regular2.Range1
            CheckRollTaxPPT.PPH_21_Regular2R2 = pph_regular2.Range2
            CheckRollTaxPPT.PPH_21_Regular2R3 = pph_regular2.Range3
            CheckRollTaxPPT.PPH_21_Regular2R4 = pph_regular2.Range4
            CheckRollTaxPPT.PPH_21_Regular2R5 = pph_regular2.Range5

            Dim pph_regular3 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular3)
            CheckRollTaxPPT.PPH_21_Regular3R1 = pph_regular3.Range1
            CheckRollTaxPPT.PPH_21_Regular3R2 = pph_regular3.Range2
            CheckRollTaxPPT.PPH_21_Regular3R3 = pph_regular3.Range3
            CheckRollTaxPPT.PPH_21_Regular3R4 = pph_regular3.Range4
            CheckRollTaxPPT.PPH_21_Regular3R5 = pph_regular3.Range5

            Dim pph_regular4 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular4)
            CheckRollTaxPPT.PPH_21_Regular4R1 = pph_regular4.Range1
            CheckRollTaxPPT.PPH_21_Regular4R2 = pph_regular4.Range2
            CheckRollTaxPPT.PPH_21_Regular4R3 = pph_regular4.Range3
            CheckRollTaxPPT.PPH_21_Regular4R4 = pph_regular4.Range4
            CheckRollTaxPPT.PPH_21_Regular4R5 = pph_regular4.Range5

            Dim pph_regular5 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular5)
            CheckRollTaxPPT.PPH_21_Regular5R1 = pph_regular5.Range1
            CheckRollTaxPPT.PPH_21_Regular5R2 = pph_regular5.Range2
            CheckRollTaxPPT.PPH_21_Regular5R3 = pph_regular5.Range3
            CheckRollTaxPPT.PPH_21_Regular5R4 = pph_regular5.Range4
            CheckRollTaxPPT.PPH_21_Regular5R5 = pph_regular5.Range5

            Dim pph_regular6 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular6)
            CheckRollTaxPPT.PPH_21_Regular6R1 = pph_regular6.Range1
            CheckRollTaxPPT.PPH_21_Regular6R2 = pph_regular6.Range2
            CheckRollTaxPPT.PPH_21_Regular6R3 = pph_regular6.Range3
            CheckRollTaxPPT.PPH_21_Regular6R4 = pph_regular6.Range4
            CheckRollTaxPPT.PPH_21_Regular6R5 = pph_regular6.Range5

            Dim pph_regular7 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular7)
            CheckRollTaxPPT.PPH_21_Regular7R1 = pph_regular7.Range1
            CheckRollTaxPPT.PPH_21_Regular7R2 = pph_regular7.Range2
            CheckRollTaxPPT.PPH_21_Regular7R3 = pph_regular7.Range3
            CheckRollTaxPPT.PPH_21_Regular7R4 = pph_regular7.Range4
            CheckRollTaxPPT.PPH_21_Regular7R5 = pph_regular7.Range5

            Dim pph_regular8 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular8)
            CheckRollTaxPPT.PPH_21_Regular8R1 = pph_regular8.Range1
            CheckRollTaxPPT.PPH_21_Regular8R2 = pph_regular8.Range2
            CheckRollTaxPPT.PPH_21_Regular8R3 = pph_regular8.Range3
            CheckRollTaxPPT.PPH_21_Regular8R4 = pph_regular8.Range4
            CheckRollTaxPPT.PPH_21_Regular8R5 = pph_regular8.Range5

            Dim pph_regular9 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular9)
            CheckRollTaxPPT.PPH_21_Regular9R1 = pph_regular9.Range1
            CheckRollTaxPPT.PPH_21_Regular9R2 = pph_regular9.Range2
            CheckRollTaxPPT.PPH_21_Regular9R3 = pph_regular9.Range3
            CheckRollTaxPPT.PPH_21_Regular9R4 = pph_regular9.Range4
            CheckRollTaxPPT.PPH_21_Regular9R5 = pph_regular9.Range5

            Dim pph_regular10 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular10)
            CheckRollTaxPPT.PPH_21_Regular10R1 = pph_regular10.Range1
            CheckRollTaxPPT.PPH_21_Regular10R2 = pph_regular10.Range2
            CheckRollTaxPPT.PPH_21_Regular10R3 = pph_regular10.Range3
            CheckRollTaxPPT.PPH_21_Regular10R4 = pph_regular10.Range4
            CheckRollTaxPPT.PPH_21_Regular10R5 = pph_regular10.Range5

            Dim pph_regular11 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular11)
            CheckRollTaxPPT.PPH_21_Regular11R1 = pph_regular11.Range1
            CheckRollTaxPPT.PPH_21_Regular11R2 = pph_regular11.Range2
            CheckRollTaxPPT.PPH_21_Regular11R3 = pph_regular11.Range3
            CheckRollTaxPPT.PPH_21_Regular11R4 = pph_regular11.Range4
            CheckRollTaxPPT.PPH_21_Regular11R5 = pph_regular11.Range5

            Dim pph_regular12 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Regular12)
            CheckRollTaxPPT.PPH_21_Regular12R1 = pph_regular12.Range1
            CheckRollTaxPPT.PPH_21_Regular12R2 = pph_regular12.Range2
            CheckRollTaxPPT.PPH_21_Regular12R3 = pph_regular12.Range3
            CheckRollTaxPPT.PPH_21_Regular12R4 = pph_regular12.Range4
            CheckRollTaxPPT.PPH_21_Regular12R5 = pph_regular12.Range5


        End If

        '----------------------------------------------------------------------------------------------------------

        If CheckRollTaxPPT.NPWP <> "NO" Then


            Dim pph_irregular1 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular1)
            CheckRollTaxPPT.PPH_21_IRRegular1R1 = pph_irregular1.Range1
            CheckRollTaxPPT.PPH_21_IRRegular1R2 = pph_irregular1.Range2
            CheckRollTaxPPT.PPH_21_IRRegular1R3 = pph_irregular1.Range3
            CheckRollTaxPPT.PPH_21_IRRegular1R4 = pph_irregular1.Range4
            CheckRollTaxPPT.PPH_21_IRRegular1R5 = pph_irregular1.Range5

            Dim pph_irregular2 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular2)
            CheckRollTaxPPT.PPH_21_IRRegular2R1 = pph_irregular2.Range1
            CheckRollTaxPPT.PPH_21_IRRegular2R2 = pph_irregular2.Range2
            CheckRollTaxPPT.PPH_21_IRRegular2R3 = pph_irregular2.Range3
            CheckRollTaxPPT.PPH_21_IRRegular2R4 = pph_irregular2.Range4
            CheckRollTaxPPT.PPH_21_IRRegular2R5 = pph_irregular2.Range5

            Dim pph_irregular3 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular3)
            CheckRollTaxPPT.PPH_21_IRRegular3R1 = pph_irregular3.Range1
            CheckRollTaxPPT.PPH_21_IRRegular3R2 = pph_irregular3.Range2
            CheckRollTaxPPT.PPH_21_IRRegular3R3 = pph_irregular3.Range3
            CheckRollTaxPPT.PPH_21_IRRegular3R4 = pph_irregular3.Range4
            CheckRollTaxPPT.PPH_21_IRRegular3R5 = pph_irregular3.Range5

            Dim pph_irregular4 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular4)
            CheckRollTaxPPT.PPH_21_IRRegular4R1 = pph_irregular4.Range1
            CheckRollTaxPPT.PPH_21_IRRegular4R2 = pph_irregular4.Range2
            CheckRollTaxPPT.PPH_21_IRRegular4R3 = pph_irregular4.Range3
            CheckRollTaxPPT.PPH_21_IRRegular4R4 = pph_irregular4.Range4
            CheckRollTaxPPT.PPH_21_IRRegular4R5 = pph_irregular4.Range5

            Dim pph_irregular5 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular5)
            CheckRollTaxPPT.PPH_21_IRRegular5R1 = pph_irregular5.Range1
            CheckRollTaxPPT.PPH_21_IRRegular5R2 = pph_irregular5.Range2
            CheckRollTaxPPT.PPH_21_IRRegular5R3 = pph_irregular5.Range3
            CheckRollTaxPPT.PPH_21_IRRegular5R4 = pph_irregular5.Range4
            CheckRollTaxPPT.PPH_21_IRRegular5R5 = pph_irregular5.Range5

            Dim pph_irregular6 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular6)
            CheckRollTaxPPT.PPH_21_IRRegular6R1 = pph_irregular6.Range1
            CheckRollTaxPPT.PPH_21_IRRegular6R2 = pph_irregular6.Range2
            CheckRollTaxPPT.PPH_21_IRRegular6R3 = pph_irregular6.Range3
            CheckRollTaxPPT.PPH_21_IRRegular6R4 = pph_irregular6.Range4
            CheckRollTaxPPT.PPH_21_IRRegular6R5 = pph_irregular6.Range5

            Dim pph_irregular7 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular7)
            CheckRollTaxPPT.PPH_21_IRRegular7R1 = pph_irregular7.Range1
            CheckRollTaxPPT.PPH_21_IRRegular7R2 = pph_irregular7.Range2
            CheckRollTaxPPT.PPH_21_IRRegular7R3 = pph_irregular7.Range3
            CheckRollTaxPPT.PPH_21_IRRegular7R4 = pph_irregular7.Range4
            CheckRollTaxPPT.PPH_21_IRRegular7R5 = pph_irregular7.Range5

            Dim pph_irregular8 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular8)
            CheckRollTaxPPT.PPH_21_IRRegular8R1 = pph_irregular8.Range1
            CheckRollTaxPPT.PPH_21_IRRegular8R2 = pph_irregular8.Range2
            CheckRollTaxPPT.PPH_21_IRRegular8R3 = pph_irregular8.Range3
            CheckRollTaxPPT.PPH_21_IRRegular8R4 = pph_irregular8.Range4
            CheckRollTaxPPT.PPH_21_IRRegular8R5 = pph_irregular8.Range5

            Dim pph_irregular9 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular9)
            CheckRollTaxPPT.PPH_21_IRRegular9R1 = pph_irregular9.Range1
            CheckRollTaxPPT.PPH_21_IRRegular9R2 = pph_irregular9.Range2
            CheckRollTaxPPT.PPH_21_IRRegular9R3 = pph_irregular9.Range3
            CheckRollTaxPPT.PPH_21_IRRegular9R4 = pph_irregular9.Range4
            CheckRollTaxPPT.PPH_21_IRRegular9R5 = pph_irregular9.Range5

            Dim pph_irregular10 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular10)
            CheckRollTaxPPT.PPH_21_IRRegular10R1 = pph_irregular10.Range1
            CheckRollTaxPPT.PPH_21_IRRegular10R2 = pph_irregular10.Range2
            CheckRollTaxPPT.PPH_21_IRRegular10R3 = pph_irregular10.Range3
            CheckRollTaxPPT.PPH_21_IRRegular10R4 = pph_irregular10.Range4
            CheckRollTaxPPT.PPH_21_IRRegular10R5 = pph_irregular10.Range5

            Dim pph_irregular11 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular11)
            CheckRollTaxPPT.PPH_21_IRRegular11R1 = pph_irregular11.Range1
            CheckRollTaxPPT.PPH_21_IRRegular11R2 = pph_irregular11.Range2
            CheckRollTaxPPT.PPH_21_IRRegular11R3 = pph_irregular11.Range3
            CheckRollTaxPPT.PPH_21_IRRegular11R4 = pph_irregular11.Range4
            CheckRollTaxPPT.PPH_21_IRRegular11R5 = pph_irregular11.Range5

            Dim pph_irregular12 As PPHRange = CalculatePPH21(CheckRollTaxPPT.Taxable_Income_Irregular12)
            CheckRollTaxPPT.PPH_21_IRRegular12R1 = pph_irregular12.Range1
            CheckRollTaxPPT.PPH_21_IRRegular12R2 = pph_irregular12.Range2
            CheckRollTaxPPT.PPH_21_IRRegular12R3 = pph_irregular12.Range3
            CheckRollTaxPPT.PPH_21_IRRegular12R4 = pph_irregular12.Range4
            CheckRollTaxPPT.PPH_21_IRRegular12R5 = pph_irregular12.Range5

        Else

            Dim pph_irregular1 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular1)
            CheckRollTaxPPT.PPH_21_IRRegular1R1 = pph_irregular1.Range1
            CheckRollTaxPPT.PPH_21_IRRegular1R2 = pph_irregular1.Range2
            CheckRollTaxPPT.PPH_21_IRRegular1R3 = pph_irregular1.Range3
            CheckRollTaxPPT.PPH_21_IRRegular1R4 = pph_irregular1.Range4
            CheckRollTaxPPT.PPH_21_IRRegular1R5 = pph_irregular1.Range5

            Dim pph_irregular2 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular2)
            CheckRollTaxPPT.PPH_21_IRRegular2R1 = pph_irregular2.Range1
            CheckRollTaxPPT.PPH_21_IRRegular2R2 = pph_irregular2.Range2
            CheckRollTaxPPT.PPH_21_IRRegular2R3 = pph_irregular2.Range3
            CheckRollTaxPPT.PPH_21_IRRegular2R4 = pph_irregular2.Range4
            CheckRollTaxPPT.PPH_21_IRRegular2R5 = pph_irregular2.Range5

            Dim pph_irregular3 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular3)
            CheckRollTaxPPT.PPH_21_IRRegular3R1 = pph_irregular3.Range1
            CheckRollTaxPPT.PPH_21_IRRegular3R2 = pph_irregular3.Range2
            CheckRollTaxPPT.PPH_21_IRRegular3R3 = pph_irregular3.Range3
            CheckRollTaxPPT.PPH_21_IRRegular3R4 = pph_irregular3.Range4
            CheckRollTaxPPT.PPH_21_IRRegular3R5 = pph_irregular3.Range5

            Dim pph_irregular4 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular4)
            CheckRollTaxPPT.PPH_21_IRRegular4R1 = pph_irregular4.Range1
            CheckRollTaxPPT.PPH_21_IRRegular4R2 = pph_irregular4.Range2
            CheckRollTaxPPT.PPH_21_IRRegular4R3 = pph_irregular4.Range3
            CheckRollTaxPPT.PPH_21_IRRegular4R4 = pph_irregular4.Range4
            CheckRollTaxPPT.PPH_21_IRRegular4R5 = pph_irregular4.Range5

            Dim pph_irregular5 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular5)
            CheckRollTaxPPT.PPH_21_IRRegular5R1 = pph_irregular5.Range1
            CheckRollTaxPPT.PPH_21_IRRegular5R2 = pph_irregular5.Range2
            CheckRollTaxPPT.PPH_21_IRRegular5R3 = pph_irregular5.Range3
            CheckRollTaxPPT.PPH_21_IRRegular5R4 = pph_irregular5.Range4
            CheckRollTaxPPT.PPH_21_IRRegular5R5 = pph_irregular5.Range5

            Dim pph_irregular6 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular6)
            CheckRollTaxPPT.PPH_21_IRRegular6R1 = pph_irregular6.Range1
            CheckRollTaxPPT.PPH_21_IRRegular6R2 = pph_irregular6.Range2
            CheckRollTaxPPT.PPH_21_IRRegular6R3 = pph_irregular6.Range3
            CheckRollTaxPPT.PPH_21_IRRegular6R4 = pph_irregular6.Range4
            CheckRollTaxPPT.PPH_21_IRRegular6R5 = pph_irregular6.Range5

            Dim pph_irregular7 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular7)
            CheckRollTaxPPT.PPH_21_IRRegular7R1 = pph_irregular7.Range1
            CheckRollTaxPPT.PPH_21_IRRegular7R2 = pph_irregular7.Range2
            CheckRollTaxPPT.PPH_21_IRRegular7R3 = pph_irregular7.Range3
            CheckRollTaxPPT.PPH_21_IRRegular7R4 = pph_irregular7.Range4
            CheckRollTaxPPT.PPH_21_IRRegular7R5 = pph_irregular7.Range5

            Dim pph_irregular8 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular8)
            CheckRollTaxPPT.PPH_21_IRRegular8R1 = pph_irregular8.Range1
            CheckRollTaxPPT.PPH_21_IRRegular8R2 = pph_irregular8.Range2
            CheckRollTaxPPT.PPH_21_IRRegular8R3 = pph_irregular8.Range3
            CheckRollTaxPPT.PPH_21_IRRegular8R4 = pph_irregular8.Range4
            CheckRollTaxPPT.PPH_21_IRRegular8R5 = pph_irregular8.Range5

            Dim pph_irregular9 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular9)
            CheckRollTaxPPT.PPH_21_IRRegular9R1 = pph_irregular9.Range1
            CheckRollTaxPPT.PPH_21_IRRegular9R2 = pph_irregular9.Range2
            CheckRollTaxPPT.PPH_21_IRRegular9R3 = pph_irregular9.Range3
            CheckRollTaxPPT.PPH_21_IRRegular9R4 = pph_irregular9.Range4
            CheckRollTaxPPT.PPH_21_IRRegular9R5 = pph_irregular9.Range5

            Dim pph_irregular10 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular10)
            CheckRollTaxPPT.PPH_21_IRRegular10R1 = pph_irregular10.Range1
            CheckRollTaxPPT.PPH_21_IRRegular10R2 = pph_irregular10.Range2
            CheckRollTaxPPT.PPH_21_IRRegular10R3 = pph_irregular10.Range3
            CheckRollTaxPPT.PPH_21_IRRegular10R4 = pph_irregular10.Range4
            CheckRollTaxPPT.PPH_21_IRRegular10R5 = pph_irregular10.Range5

            Dim pph_irregular11 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular11)
            CheckRollTaxPPT.PPH_21_IRRegular11R1 = pph_irregular11.Range1
            CheckRollTaxPPT.PPH_21_IRRegular11R2 = pph_irregular11.Range2
            CheckRollTaxPPT.PPH_21_IRRegular11R3 = pph_irregular11.Range3
            CheckRollTaxPPT.PPH_21_IRRegular11R4 = pph_irregular11.Range4
            CheckRollTaxPPT.PPH_21_IRRegular11R5 = pph_irregular11.Range5

            Dim pph_irregular12 As PPHRange = CalculatePPH21_NPWP(CheckRollTaxPPT.Taxable_Income_Irregular12)
            CheckRollTaxPPT.PPH_21_IRRegular12R1 = pph_irregular12.Range1
            CheckRollTaxPPT.PPH_21_IRRegular12R2 = pph_irregular12.Range2
            CheckRollTaxPPT.PPH_21_IRRegular12R3 = pph_irregular12.Range3
            CheckRollTaxPPT.PPH_21_IRRegular12R4 = pph_irregular12.Range4
            CheckRollTaxPPT.PPH_21_IRRegular12R5 = pph_irregular12.Range5

        End If

    End Sub

    Function CalculatePPH21(ByVal TaxableIncome As Double) As PPHRange
        'function used for NON NPWP for Regular and Irregular Tax
        Dim _pphRange As New PPHRange
        _pphRange.Range4 = 0
        _pphRange.Range3 = 0
        _pphRange.Range2 = 0
        _pphRange.Range1 = 0

        If TaxableIncome >= GradeIVRangeFrom Then
            _pphRange.Range4 = ((TaxableIncome - GradeIVRangeFrom) * (GradeIV / 100)) + (GradeIRange * (GradeI / 100)) + ((GradeIIRangeTo - GradeIIRangeFrom) * (GradeII / 100)) + ((GradeIIIRangeTo - GradeIIIRangeFrom) * (GradeIII / 100))
        ElseIf TaxableIncome >= GradeIIIRangeFrom And TaxableIncome <= GradeIIIRangeTo Then
            _pphRange.Range3 = (GradeIRange * (GradeI / 100)) + ((GradeIIRangeTo - GradeIIRangeFrom) * (GradeII / 100)) + ((TaxableIncome - GradeIIIRangeFrom) * (GradeIII / 100))
        ElseIf TaxableIncome >= GradeIIRangeFrom And TaxableIncome <= GradeIIRangeTo Then
            _pphRange.Range2 = (GradeIRange * (GradeI / 100)) + ((TaxableIncome - GradeIIRangeFrom) * (GradeII / 100))
        ElseIf TaxableIncome <= GradeIIRangeFrom Then
            _pphRange.Range1 = TaxableIncome * (GradeI / 100)
        End If

        Return _pphRange

    End Function

    Function CalculatePPH21_NPWP(ByVal TaxableIncome As Double) As PPHRange
        'function used for NPWP for Regular and Irregular Tax

        Dim _pphRange As New PPHRange
        _pphRange.Range4 = 0
        _pphRange.Range3 = 0
        _pphRange.Range2 = 0
        _pphRange.Range1 = 0

        If TaxableIncome >= GradeIVRangeFromNPWP Then
            _pphRange.Range4 = ((TaxableIncome - GradeIVRangeFromNPWP) * (GradeIVNPWP / 100)) + (GradeIRangeNPWP * (GradeINPWP / 100)) + ((GradeIIRangeToNPWP - GradeIIRangeFromNPWP) * (GradeIINPWP / 100)) + ((GradeIIIRangeToNPWP - GradeIIIRangeFromNPWP) * (GradeIIINPWP / 100))
        ElseIf TaxableIncome >= GradeIIIRangeFromNPWP And TaxableIncome <= GradeIIIRangeToNPWP Then
            _pphRange.Range3 = (GradeIRangeNPWP * (GradeINPWP / 100)) + ((GradeIIRangeToNPWP - GradeIIRangeFromNPWP) * (GradeIINPWP / 100)) + ((TaxableIncome - GradeIIIRangeFromNPWP) * (GradeIIINPWP / 100))
        ElseIf TaxableIncome >= GradeIIRangeFromNPWP And TaxableIncome <= GradeIIRangeToNPWP Then
            _pphRange.Range2 = (GradeIRangeNPWP * (GradeINPWP / 100)) + ((TaxableIncome - GradeIIRangeFromNPWP) * (GradeIINPWP / 100))
        ElseIf TaxableIncome <= GradeIIRangeFromNPWP Then
            _pphRange.Range1 = TaxableIncome * (GradeINPWP / 100)
        End If

        Return _pphRange

    End Function

    Public Class PPHRange
        Public Range1 As Double
        Public Range2 As Double
        Public Range3 As Double
        Public Range4 As Double
        Public Range5 As Double
    End Class

    Private Sub Grp1_Enter(sender As System.Object, e As System.EventArgs) Handles Grp1.Enter

    End Sub
End Class
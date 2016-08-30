Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.ConfigurationSettings
Public Class CheckRollTaxTemp1PPT
#Region "Application Global Variables"
    Public Shared Empid As String
    Public Shared Status As String
    Public Shared StatusDate As String
    Public Shared BasicRate As Double
    Public Shared dDeductionCostMax As Double
    Public Shared RiceDividerDays As Double
    Public Shared Income_Regular1 As Double
    Public Shared Income_Regular2 As Double
    Public Shared Income_Regular3 As Double
    Public Shared Income_Regular4 As Double
    Public Shared Income_Regular5 As Double
    Public Shared Income_Regular6 As Double
    Public Shared Income_Regular7 As Double
    Public Shared Income_Regular8 As Double
    Public Shared Income_Regular9 As Double
    Public Shared Income_Regular10 As Double
    Public Shared Income_Regular11 As Double
    Public Shared Income_Regular12 As Double

    Public Shared Income_Irregular1 As Double
    Public Shared Income_Irregular2 As Double
    Public Shared Income_Irregular3 As Double
    Public Shared Income_Irregular4 As Double
    Public Shared Income_Irregular5 As Double
    Public Shared Income_Irregular6 As Double
    Public Shared Income_Irregular7 As Double
    Public Shared Income_Irregular8 As Double
    Public Shared Income_Irregular9 As Double
    Public Shared Income_Irregular10 As Double
    Public Shared Income_Irregular11 As Double
    Public Shared Income_Irregular12 As Double

    Public Shared Accident_Insurance1 As Double
    Public Shared Accident_Insurance2 As Double
    Public Shared Accident_Insurance3 As Double
    Public Shared Accident_Insurance4 As Double
    Public Shared Accident_Insurance5 As Double
    Public Shared Accident_Insurance6 As Double
    Public Shared Accident_Insurance7 As Double
    Public Shared Accident_Insurance8 As Double
    Public Shared Accident_Insurance9 As Double
    Public Shared Accident_Insurance10 As Double
    Public Shared Accident_Insurance11 As Double
    Public Shared Accident_Insurance12 As Double

    Public Shared ActiveMonth1Sal As Double
    Public Shared ActiveMonth2Sal As Double
    Public Shared ActiveMonth3Sal As Double
    Public Shared ActiveMonth4Sal As Double
    Public Shared ActiveMonth5Sal As Double
    Public Shared ActiveMonth6Sal As Double
    Public Shared ActiveMonth7Sal As Double
    Public Shared ActiveMonth8Sal As Double
    Public Shared ActiveMonth9Sal As Double
    Public Shared ActiveMonth10Sal As Double
    Public Shared ActiveMonth11Sal As Double
    Public Shared ActiveMonth12Sal As Double

    Public Shared ActiveMonth1Tax As Double
    Public Shared ActiveMonth2Tax As Double
    Public Shared ActiveMonth3Tax As Double
    Public Shared ActiveMonth4Tax As Double
    Public Shared ActiveMonth5Tax As Double
    Public Shared ActiveMonth6Tax As Double
    Public Shared ActiveMonth7Tax As Double
    Public Shared ActiveMonth8Tax As Double
    Public Shared ActiveMonth9Tax As Double
    Public Shared ActiveMonth10Tax As Double
    Public Shared ActiveMonth11Tax As Double
    Public Shared ActiveMonth12Tax As Double
    Public Shared PTKP As Double
    Public Shared Category As String
    Public Shared NPWP As String = String.Empty
    Public Shared JHTPercent As Double
    Public Shared HIPMonthlyRate As Double


    Public Shared Taxable_Income_Regular1 As Double
    Public Shared Taxable_Income_Regular2 As Double
    Public Shared Taxable_Income_Regular3 As Double
    Public Shared Taxable_Income_Regular4 As Double
    Public Shared Taxable_Income_Regular5 As Double
    Public Shared Taxable_Income_Regular6 As Double
    Public Shared Taxable_Income_Regular7 As Double
    Public Shared Taxable_Income_Regular8 As Double
    Public Shared Taxable_Income_Regular9 As Double
    Public Shared Taxable_Income_Regular10 As Double
    Public Shared Taxable_Income_Regular11 As Double
    Public Shared Taxable_Income_Regular12 As Double

    Public Shared Taxable_Income_Irregular1 As Double
    Public Shared Taxable_Income_Irregular2 As Double
    Public Shared Taxable_Income_Irregular3 As Double
    Public Shared Taxable_Income_Irregular4 As Double
    Public Shared Taxable_Income_Irregular5 As Double
    Public Shared Taxable_Income_Irregular6 As Double
    Public Shared Taxable_Income_Irregular7 As Double
    Public Shared Taxable_Income_Irregular8 As Double
    Public Shared Taxable_Income_Irregular9 As Double
    Public Shared Taxable_Income_Irregular10 As Double
    Public Shared Taxable_Income_Irregular11 As Double
    Public Shared Taxable_Income_Irregular12 As Double


    Public Shared EmpCode As String

    Public Shared GradeINPWP As Double

    Public Shared GradeIRangeNPWP As Double
    Public Shared GradeIINPWP As Double
    Public Shared GradeIIRangeFromNPWP As Double
    Public Shared GradeIIRangeToNPWP As Double
    Public Shared GradeIIINPWP As Double
    Public Shared GradeIIIRangeFromNPWP As Double
    Public Shared GradeIIIRangeToNPWP As Double
    Public Shared GradeIVNPWP As Double
    Public Shared GradeIVRangeFromNPWP As Double
    Public Shared GradeIVRangeToNPWP As Double
    Public Shared GradeVNPWP As Double

    Public Shared GradeI As Double

    Public Shared GradeIRange As Double
    Public Shared GradeII As Double
    Public Shared GradeIIRangeFrom As Double
    Public Shared GradeIIRangeTo As Double
    Public Shared GradeIII As Double
    Public Shared GradeIIIRangeFrom As Double
    Public Shared GradeIIIRangeTo As Double
    Public Shared GradeIV As Double
    Public Shared GradeIVRangeFrom As Double
    Public Shared GradeIVRangeTo As Double
    Public Shared GradeV As Double

    Public Shared THR As Double
    Public Shared DedTaxCompany As Double
    Public Shared DedAdvance As Double
    Public Shared DedOther As Double
    Public Shared TotalBruto As Double
    Public Shared DedAstek As Double
    Public Shared ActiveMonthYearID1 As String
    Public Shared ActiveMonthYearID2 As String
    Public Shared ActiveMonthYearID3 As String
    Public Shared ActiveMonthYearID4 As String
    Public Shared ActiveMonthYearID5 As String
    Public Shared ActiveMonthYearID6 As String
    Public Shared ActiveMonthYearID7 As String
    Public Shared ActiveMonthYearID8 As String
    Public Shared ActiveMonthYearID9 As String
    Public Shared ActiveMonthYearID10 As String
    Public Shared ActiveMonthYearID11 As String
    Public Shared ActiveMonthYearID12 As String


    Public Shared PPH_21_Regular1R1 As Double
    Public Shared PPH_21_Regular2R1 As Double
    Public Shared PPH_21_Regular3R1 As Double
    Public Shared PPH_21_Regular4R1 As Double
    Public Shared PPH_21_Regular5R1 As Double
    Public Shared PPH_21_Regular6R1 As Double
    Public Shared PPH_21_Regular7R1 As Double
    Public Shared PPH_21_Regular8R1 As Double
    Public Shared PPH_21_Regular9R1 As Double
    Public Shared PPH_21_Regular10R1 As Double
    Public Shared PPH_21_Regular11R1 As Double
    Public Shared PPH_21_Regular12R1 As Double

    Public Shared PPH_21_Regular1R2 As Double
    Public Shared PPH_21_Regular2R2 As Double
    Public Shared PPH_21_Regular3R2 As Double
    Public Shared PPH_21_Regular4R2 As Double
    Public Shared PPH_21_Regular5R2 As Double
    Public Shared PPH_21_Regular6R2 As Double
    Public Shared PPH_21_Regular7R2 As Double
    Public Shared PPH_21_Regular8R2 As Double
    Public Shared PPH_21_Regular9R2 As Double
    Public Shared PPH_21_Regular10R2 As Double
    Public Shared PPH_21_Regular11R2 As Double
    Public Shared PPH_21_Regular12R2 As Double


    Public Shared PPH_21_Regular1R3 As Double
    Public Shared PPH_21_Regular2R3 As Double
    Public Shared PPH_21_Regular3R3 As Double
    Public Shared PPH_21_Regular4R3 As Double
    Public Shared PPH_21_Regular5R3 As Double
    Public Shared PPH_21_Regular6R3 As Double
    Public Shared PPH_21_Regular7R3 As Double
    Public Shared PPH_21_Regular8R3 As Double
    Public Shared PPH_21_Regular9R3 As Double
    Public Shared PPH_21_Regular10R3 As Double
    Public Shared PPH_21_Regular11R3 As Double
    Public Shared PPH_21_Regular12R3 As Double


    Public Shared PPH_21_Regular1R4 As Double
    Public Shared PPH_21_Regular2R4 As Double
    Public Shared PPH_21_Regular3R4 As Double
    Public Shared PPH_21_Regular4R4 As Double
    Public Shared PPH_21_Regular5R4 As Double
    Public Shared PPH_21_Regular6R4 As Double
    Public Shared PPH_21_Regular7R4 As Double
    Public Shared PPH_21_Regular8R4 As Double
    Public Shared PPH_21_Regular9R4 As Double
    Public Shared PPH_21_Regular10R4 As Double
    Public Shared PPH_21_Regular11R4 As Double
    Public Shared PPH_21_Regular12R4 As Double


    Public Shared PPH_21_Regular1R5 As Double
    Public Shared PPH_21_Regular2R5 As Double
    Public Shared PPH_21_Regular3R5 As Double
    Public Shared PPH_21_Regular4R5 As Double
    Public Shared PPH_21_Regular5R5 As Double
    Public Shared PPH_21_Regular6R5 As Double
    Public Shared PPH_21_Regular7R5 As Double
    Public Shared PPH_21_Regular8R5 As Double
    Public Shared PPH_21_Regular9R5 As Double
    Public Shared PPH_21_Regular10R5 As Double
    Public Shared PPH_21_Regular11R5 As Double
    Public Shared PPH_21_Regular12R5 As Double




    Public Shared PPH_21_IRRegular1R1 As Double
    Public Shared PPH_21_IRRegular2R1 As Double
    Public Shared PPH_21_IRRegular3R1 As Double
    Public Shared PPH_21_IRRegular4R1 As Double
    Public Shared PPH_21_IRRegular5R1 As Double
    Public Shared PPH_21_IRRegular6R1 As Double
    Public Shared PPH_21_IRRegular7R1 As Double
    Public Shared PPH_21_IRRegular8R1 As Double
    Public Shared PPH_21_IRRegular9R1 As Double
    Public Shared PPH_21_IRRegular10R1 As Double
    Public Shared PPH_21_IRRegular11R1 As Double
    Public Shared PPH_21_IRRegular12R1 As Double

    Public Shared PPH_21_IRRegular1R2 As Double
    Public Shared PPH_21_IRRegular2R2 As Double
    Public Shared PPH_21_IRRegular3R2 As Double
    Public Shared PPH_21_IRRegular4R2 As Double
    Public Shared PPH_21_IRRegular5R2 As Double
    Public Shared PPH_21_IRRegular6R2 As Double
    Public Shared PPH_21_IRRegular7R2 As Double
    Public Shared PPH_21_IRRegular8R2 As Double
    Public Shared PPH_21_IRRegular9R2 As Double
    Public Shared PPH_21_IRRegular10R2 As Double
    Public Shared PPH_21_IRRegular11R2 As Double
    Public Shared PPH_21_IRRegular12R2 As Double


    Public Shared PPH_21_IRRegular1R3 As Double
    Public Shared PPH_21_IRRegular2R3 As Double
    Public Shared PPH_21_IRRegular3R3 As Double
    Public Shared PPH_21_IRRegular4R3 As Double
    Public Shared PPH_21_IRRegular5R3 As Double
    Public Shared PPH_21_IRRegular6R3 As Double
    Public Shared PPH_21_IRRegular7R3 As Double
    Public Shared PPH_21_IRRegular8R3 As Double
    Public Shared PPH_21_IRRegular9R3 As Double
    Public Shared PPH_21_IRRegular10R3 As Double
    Public Shared PPH_21_IRRegular11R3 As Double
    Public Shared PPH_21_IRRegular12R3 As Double


    Public Shared PPH_21_IRRegular1R4 As Double
    Public Shared PPH_21_IRRegular2R4 As Double
    Public Shared PPH_21_IRRegular3R4 As Double
    Public Shared PPH_21_IRRegular4R4 As Double
    Public Shared PPH_21_IRRegular5R4 As Double
    Public Shared PPH_21_IRRegular6R4 As Double
    Public Shared PPH_21_IRRegular7R4 As Double
    Public Shared PPH_21_IRRegular8R4 As Double
    Public Shared PPH_21_IRRegular9R4 As Double
    Public Shared PPH_21_IRRegular10R4 As Double
    Public Shared PPH_21_IRRegular11R4 As Double
    Public Shared PPH_21_IRRegular12R4 As Double



    Public Shared PPH_21_IRRegular1R5 As Double
    Public Shared PPH_21_IRRegular2R5 As Double
    Public Shared PPH_21_IRRegular3R5 As Double
    Public Shared PPH_21_IRRegular4R5 As Double
    Public Shared PPH_21_IRRegular5R5 As Double
    Public Shared PPH_21_IRRegular6R5 As Double
    Public Shared PPH_21_IRRegular7R5 As Double
    Public Shared PPH_21_IRRegular8R5 As Double
    Public Shared PPH_21_IRRegular9R5 As Double
    Public Shared PPH_21_IRRegular10R5 As Double
    Public Shared PPH_21_IRRegular11R5 As Double
    Public Shared PPH_21_IRRegular12R5 As Double

    Public Shared FunctionalAllowanceP As Double
    Public Shared MaxAllowance As Double
#End Region
End Class

'//////////////////////////////////////
'
' By Dadang Adi Hendradi
' Created: Kamis, 31 Dec 2009, 11:13
' Place  : Kuala Lumpur
'
'/////////////////////////////////////

Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports CheckRoll_DAL
Imports CheckRoll_BOL
Imports Common_PPT
Imports Common_BOL



Public Class CheckrollMonthEndClosing


    Dim WorkerType As String
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




    'Dim PPH_21_Regular1R1 As Double
    'Dim PPH_21_Regular2R1 As Double
    'Dim PPH_21_Regular3R1 As Double
    'Dim PPH_21_Regular4R1 As Double
    'Dim PPH_21_Regular5R1 As Double
    'Dim PPH_21_Regular6R1 As Double
    'Dim PPH_21_Regular7R1 As Double
    'Dim PPH_21_Regular8R1 As Double
    'Dim PPH_21_Regular9R1 As Double
    'Dim PPH_21_Regular10R1 As Double
    'Dim PPH_21_Regular11R1 As Double
    'Dim PPH_21_Regular12R1 As Double

    'Dim PPH_21_Regular1R2 As Double
    'Dim PPH_21_Regular2R2 As Double
    'Dim PPH_21_Regular3R2 As Double
    'Dim PPH_21_Regular4R2 As Double
    'Dim PPH_21_Regular5R2 As Double
    'Dim PPH_21_Regular6R2 As Double
    'Dim PPH_21_Regular7R2 As Double
    'Dim PPH_21_Regular8R2 As Double
    'Dim PPH_21_Regular9R2 As Double
    'Dim PPH_21_Regular10R2 As Double
    'Dim PPH_21_Regular11R2 As Double
    'Dim PPH_21_Regular12R2 As Double


    'Dim PPH_21_Regular1R3 As Double
    'Dim PPH_21_Regular2R3 As Double
    'Dim PPH_21_Regular3R3 As Double
    'Dim PPH_21_Regular4R3 As Double
    'Dim PPH_21_Regular5R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular6R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular7R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular8R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular9R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular10R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular11R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular12R3 As Double


    'Dim CheckRollTaxPPT.PPH_21_Regular1R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular2R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular3R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular4R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular5R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular6R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular7R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular8R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular9R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular10R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular11R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular12R4 As Double


    'Dim CheckRollTaxPPT.PPH_21_Regular1R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular2R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular3R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular4R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular5R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular6R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular7R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular8R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular9R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular10R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular11R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_Regular12R5 As Double







    'Dim CheckRollTaxPPT.PPH_21_IRRegular1R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular2R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular3R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular4R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular5R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular6R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular7R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular8R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular9R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular10R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular11R1 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular12R1 As Double

    'Dim CheckRollTaxPPT.PPH_21_IRRegular1R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular2R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular3R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular4R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular5R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular6R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular7R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular8R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular9R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular10R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular11R2 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular12R2 As Double


    'Dim CheckRollTaxPPT.PPH_21_IRRegular1R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular2R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular3R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular4R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular5R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular6R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular7R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular8R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular9R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular10R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular11R3 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular12R3 As Double


    'Dim CheckRollTaxPPT.PPH_21_IRRegular1R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular2R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular3R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular4R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular5R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular6R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular7R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular8R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular9R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular10R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular11R4 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular12R4 As Double



    'Dim CheckRollTaxPPT.PPH_21_IRRegular1R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular2R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular3R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular4R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular5R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular6R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular7R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular8R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular9R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular10R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular11R5 As Double
    'Dim CheckRollTaxPPT.PPH_21_IRRegular12R5 As Double

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



    ' Kamis, 07 Jan 2010, 13:45
    Private DTTaskMonitor As System.Data.DataTable = Nothing

    Private Sub CheckrollMonthEndClosing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetTaskMonitorData()
    End Sub

    Private Sub GetTaskMonitorData()
        ' Kamis, 07 Jan 2009, 13:37


        Try
            DTTaskMonitor = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CRTaskMonitorGET()

            dgvTaskMonitor.AutoGenerateColumns = False
            dgvTaskMonitor.DataSource = DTTaskMonitor

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Dim intMonthlyProcessCompleted As Integer = 1 'Calling monthly process from different class
    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        ' By Dadang Adi H


        ' Kamis, 07 Jan 2010, 13:46
        If DTTaskMonitor Is Nothing Then
            MessageBox.Show("There is no data in TaskMonitor." + vbCrLf + _
                            "Database problem", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        'Condition Added by sangar d on 29-Aug-12  inserted Monthly process in the month end closing process
        If (MonthEndProcess.MonthlyProcess(0) = intMonthlyProcessCompleted) Then
            Dim CheckrollTASK As String = Nothing
            Dim completed As String = Nothing

            Try
                Dim dtActivityDistributeExists As DataTable = ProcessBOL.ActivityDistributeExists()

                If dtActivityDistributeExists.Rows.Count > 0 Then
                    gbDetail.Visible = True
                    dgvDistibutionDetails.Visible = True
                    dgvAttendanceHarvNoReceiptionDetails.Visible = False
                    '  dgvDistibutionDetails.Columns("GangMasterID").Visible = False
                    dgvDistibutionDetails.DataSource = dtActivityDistributeExists
                    MsgBox("Some records in Activity Distribution not yet distributed properly.Month End Closing will be done only after distributed all the records """, MsgBoxStyle.OkOnly)
                    Return
                End If

                Dim dtAttendanceHarvNoReceiptionExists As DataTable = ProcessBOL.AttendanceHarvNoReceiptionExists()
                If dtAttendanceHarvNoReceiptionExists.Rows.Count > 0 Then
                    gbDetail.Visible = True
                    dgvDistibutionDetails.Visible = False
                    dgvAttendanceHarvNoReceiptionDetails.Visible = True
                    dgvAttendanceHarvNoReceiptionDetails.DataSource = dtAttendanceHarvNoReceiptionExists
                    MsgBox("Some Harvesting Attendance records have no Block defined for Receiption." & Chr(13) & Chr(10) & "Do you want to continue?", MsgBoxStyle.OkOnly)
                    Return
                End If

                If GlobalPPT.IntActiveMonth = 12 Then
                    Dim ds As DataSet
                    ds = CheckRoll_DAL.CheckrollMonthEndClosingDAL.CheckSPTGenerated()
                    If ds.Tables.Count > 0 Then

                        'If ds.Tables(0).Rows.Count > 0 Then
                        'If ds.Tables(0).Rows(0).Item("CountNoSPT21") > 0 Then
                        'MsgBox("Records for SPT Tahunan PPH PASAL 21 Report not created. Month End Closing can be done only after the SPT Tahunan PPH PASAL 21 Report for all the records done. """, MsgBoxStyle.OkOnly)
                        'Return
                        'End If
                        'End If
                    End If
                End If

        If DTTaskMonitor.Rows.Count > 0 Then

            For Each dr As DataRow In DTTaskMonitor.Rows

                CheckrollTASK = dr.Item("TASK").ToString()
                completed = dr.Item("Complete").ToString()

                If CheckrollTASK = "Checkroll monthly Processing" AndAlso completed = "N" Then
                    Exit For
                End If
            Next

            If CheckrollTASK = "Checkroll monthly Processing" AndAlso completed = "N" Then
                MessageBox.Show("Could not proceed with month end closing. Some of the tasks not completed!", _
                                "Checkroll Month End Closing", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Else

                If MessageBox.Show( _
                    "You are about to perform month end closing. Do you want to proceed. " + vbCrLf + _
                    "If Yes, click OK, otherwise click Cancel", _
                    "Checkroll Month End Closing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
                    Return
                End If
                '' modified by kumar on jul 6 2010

                Me.Cursor = Cursors.WaitCursor
                Try
                    'Progress Bar Start
                    Dim fMsg As New ProgressingFrm            'create a new object for the message form
                    fMsg.TopMost = True                'this is to make sure that the message form is displayed at the top of your windows and the users cannot do anything to it except waiting
                    'fMsg.RightToLeftLayout.
                    fMsg.Show()                'use Show() instead of ShowDialog()

                    fMsg.pbWait.Minimum = 0
                    fMsg.pbWait.Maximum = 100
                    fMsg.pbWait.Value = 0
                    fMsg.lblMessage.Refresh()
                    fMsg.lblTitle.Refresh()
                    ''  fMsg.lblTitle.Text = rm.GetString("Msg7")
                    fMsg.lblTitle.Text = "Progress"
                    'MessageBox.Show(fMsg.lblTitle.Text)
                    fMsg.lblTitle.Refresh()
                    fMsg.lblMessage.Refresh()
                    '
                    fMsg.lblMessage.Refresh()
                    ''   fMsg.lblMessage.Text = rm.GetString("Msg8")
                    'Commented on 20-07-2011 fMsg.lblMessage.Text = "Database Backup before Month end closing Progress..."

                    'Commented by sangar D on 28-Aug-2012 - Advised by ran team to imporove the application performance
                    'fMsg.lblMessage.Text = "Database Backup Progress..."
                    'fMsg.lblMessage.Refresh()
                    'fMsg.pbWait.Value += 25
                    'System.Threading.Thread.Sleep(2000)
                    'GlobalBOL.AutoBSPBackup("Before", 1)

                    fMsg.pbWait.Value += 50
                    System.Threading.Thread.Sleep(2000)


                    fMsg.lblMessage.Refresh()
                    '' fMsg.lblMessage.Text = rm.GetString("Msg9")
                    fMsg.lblMessage.Text = "Month End Closing Progress..."
                    fMsg.lblMessage.Refresh()


                    DoMonthEndClosing()


                    ''  fMsg.lblMessage.Text = rm.GetString("Msg10")
                    'Commented on 14-June-2011 - Only to backup db before month-end closing
                    'fMsg.lblMessage.Text = "Database Backup After Month end closing Progress..."
                    'fMsg.lblMessage.Refresh()

                    'Commented on 14-June-2011 - Only to backup db before month-end closing
                    'GlobalBOL.AutoBSPBackup("After", 1)



                    fMsg.pbWait.Value += 50
                    System.Threading.Thread.Sleep(2000)

                    fMsg.Close()
                    ''  DisplayInfoMessage("Msg5")
                    MsgBox("Month End Closing Completed")
                    MdiParent.Close()
                    Dim LoginFrmTest As New LoginFrm
                    LoginFrmTest.Show()


                    ' Jum'at, 01 Jan 2010, 22:11



                Catch ex As Exception
                    '' DisplayInfoMessage("Msg6")
                    MsgBox("Processing Failed")
                End Try
                ' PbTest.Visible = False
                Me.Cursor = Cursors.Default

            End If
        End If
            Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        End If
    End Sub

    Private Sub DoMonthEndClosing()
        ' By Dadang Adi H
        ' Jum'at, 01 Jan 2010, 22:11
        LblMsg.Visible = True
        LblMsg.Refresh()

        Cursor = Cursors.WaitCursor

        Dim FromDate As Date
        Dim ToDate As Date

        Try

            '////
            ' 1. Panggil Checkroll Monthly Processing
            FromDate = GlobalPPT.FiscalYearFromDate
            ToDate = GlobalPPT.FiscalYearToDate

            'ProcessDal.UpLoadSalary(ToDate)
            'ProcessDal.KTSalary()
            'ProcessDal.InsertSalaryOT()
            'ProcessDal.InsertAllDedSalary(FromDate, ToDate)
            'ProcessDal.InsertSalaryAdvance()

            'Dim psEstateType As String
            'psEstateType = Accounts_BOL.JournalBOL.EstateTypeSelect()
            'If psEstateType <> "M" Then
            '    ProcessDal.InsertSalaryIncentive()
            'End If
            'ProcessDal.InsertSalaryPremi()
            ''ProcessDal.UpdateCheckrollSalary()
            'UpdateSalary()


            '/////////
            ' 2. Panggil TaskMonitorUpdate
            'Calling General SP
            CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthlyProcessing("Y")

            '////
            ' 3. UPDATE ActiveMonthYear
            '    Current month = 'B', dan next month = 'A'
            ' Kamis, 31 Dec 2009, 11:47
            'Inserting records into ActiveMonthYear Table
            CheckrollMonthEndClosingDAL.CRUpdateActiveMonthYear()

            '//
            '
            ' 4. 
            ' Rabu, 06 Jan 2010, 15:42

            CheckrollMonthEndClosingDAL.TaskMonitorUpdateMonthEndClosing("Y")
            'Calling General SP
            '////
            ' 5. Call TaskMonitorInsert Store Procedure
            ' Rabu, 06 Jan 2010, 15:42
            ' TaskMonitorINSERT(@EstateID, @Modid)
            CheckrollMonthEndClosingDAL.TaskMonitorInsert()

            '////
            ' 6. Logout Application to Login screen as new application
            ' Kamis, 31 Dec 2009, 11:50
            'Cursor = Cursors.Default
            'LblMsg.Text = "Done."

            ''  MessageBox.Show("Checkroll Month End Closing Done.", "Checkroll", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Dim obj As New LoginFrm
            'obj.Show()
            'Me.ParentForm.Close()

        Catch ex As Exception
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    ''#####################################################
    ''Added by nelson
    ''Following Procedure is no more in USE
    'Private Sub UpdateSalary()
    '    Dim dtEmp As New DataTable()
    '    Dim dt As New DataTable()
    '    Dim dtAct As New DataTable()
    '    Dim dtTaxable_Income As New DataTable()
    '    Dim dtDedTax As New DataTable()
    '    dtEmp = ProcessDal.GetActiveEmployee()
    '    For Each rowEmp As DataRow In dtEmp.Rows
    '        GlobalPPT.EmpCode = rowEmp("EmpCode").ToString()
    '        MaritalStatus = rowEmp("MaritalStatus").ToString()
    '        GlobalPPT.WorkerType = rowEmp("WorkerType").ToString()
    '        GlobalPPT.Empid = rowEmp("Empid").ToString()


    '        dt = ProcessDal.GetGradeRange()
    '        For Each row As DataRow In dt.Rows
    '            TaxExemptionHusbWife = CType(row("TaxExemptionHusbWife").ToString(), Double)
    '            TaxExemptionChild = CType(row("TaxExemptionChild").ToString(), Double)
    '            TaxExemptionWorker = CType(row("TaxExemptionWorker").ToString(), Double)

    '            CheckRollTaxPPT.GradeI = CType(row("GradeI").ToString(), Double)
    '            CheckRollTaxPPT.GradeII = CType(row("GradeII").ToString(), Double)
    '            CheckRollTaxPPT.GradeIII = CType(row("GradeIII").ToString(), Double)
    '            CheckRollTaxPPT.GradeIV = CType(row("GradeIV").ToString(), Double)
    '            CheckRollTaxPPT.GradeV = CType(row("GradeV").ToString(), Double)
    '            CheckRollTaxPPT.GradeIRange = CType(row("GradeIRange").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIRangeFrom = CType(row("GradeIIRangeFrom").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIRangeTo = CType(row("GradeIIRangeTo").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIIRangeFrom = CType(row("GradeIIIRangeFrom").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIIRangeTo = CType(row("GradeIIIRangeTo").ToString(), Double)
    '            CheckRollTaxPPT.GradeIVRangeFrom = CType(row("GradeIVRangeFrom").ToString(), Double)
    '            CheckRollTaxPPT.GradeIVRangeTo = CType(row("GradeIVRangeTo").ToString(), Double)
    '            CheckRollTaxPPT.GradeINPWP = CType(row("GradeINPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIRangeNPWP = CType(row("GradeIRangeNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIINPWP = CType(row("GradeIINPWP").ToString(), Double)

    '            CheckRollTaxPPT.GradeIIRangeFromNPWP = CType(row("GradeIIRangeFromNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIRangeToNPWP = CType(row("GradeIIRangeToNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIINPWP = CType(row("GradeIIINPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIIRangeFromNPWP = CType(row("GradeIIIRangeFromNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIIIRangeToNPWP = CType(row("GradeIIIRangeToNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIVNPWP = CType(row("GradeIVNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIVRangeFromNPWP = CType(row("GradeIVRangeFromNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeIVRangeToNPWP = CType(row("GradeIVRangeToNPWP").ToString(), Double)
    '            CheckRollTaxPPT.GradeVNPWP = CType(row("GradeVNPWP").ToString(), Double)
    '            CheckRollTaxPPT.PTKP = CType(row("PTKP").ToString(), Double)

    '            CheckRollTaxPPT.MaxAllowance = CType(row("MaxAllowance").ToString(), Double)
    '            CheckRollTaxPPT.FunctionalAllowanceP = CType(row("FunctionalAllowanceP").ToString(), Double)

    '            CheckRollTaxPPT.EmpCode = row("EmpCode").ToString()
    '            'MaritalStatus = row("MaritalStatus").ToString()
    '            'WorkerType = row("WorkerType").ToString()
    '            GlobalPPT.Mandore = row("Mandore").ToString()



    '            GradeI = CType(row("GradeI").ToString(), Double)
    '            GradeII = CType(row("GradeII").ToString(), Double)
    '            GradeIII = CType(row("GradeIII").ToString(), Double)
    '            GradeIV = CType(row("GradeIV").ToString(), Double)
    '            GradeV = CType(row("GradeV").ToString(), Double)
    '            GradeIRange = CType(row("GradeIRange").ToString(), Double)
    '            GradeIIRangeFrom = CType(row("GradeIIRangeFrom").ToString(), Double)
    '            GradeIIRangeTo = CType(row("GradeIIRangeTo").ToString(), Double)
    '            GradeIIIRangeFrom = CType(row("GradeIIIRangeFrom").ToString(), Double)
    '            GradeIIIRangeTo = CType(row("GradeIIIRangeTo").ToString(), Double)
    '            GradeIVRangeFrom = CType(row("GradeIVRangeFrom").ToString(), Double)
    '            GradeIVRangeTo = CType(row("GradeIVRangeTo").ToString(), Double)
    '            GradeINPWP = CType(row("GradeINPWP").ToString(), Double)
    '            GradeIRangeNPWP = CType(row("GradeIRangeNPWP").ToString(), Double)
    '            GradeIINPWP = CType(row("GradeIINPWP").ToString(), Double)

    '            GradeIIRangeFromNPWP = CType(row("GradeIIRangeFromNPWP").ToString(), Double)
    '            GradeIIRangeToNPWP = CType(row("GradeIIRangeToNPWP").ToString(), Double)
    '            GradeIIINPWP = CType(row("GradeIIINPWP").ToString(), Double)
    '            GradeIIIRangeFromNPWP = CType(row("GradeIIIRangeFromNPWP").ToString(), Double)
    '            GradeIIIRangeToNPWP = CType(row("GradeIIIRangeToNPWP").ToString(), Double)
    '            GradeIVNPWP = CType(row("GradeIVNPWP").ToString(), Double)
    '            GradeIVRangeFromNPWP = CType(row("GradeIVRangeFromNPWP").ToString(), Double)
    '            GradeIVRangeToNPWP = CType(row("GradeIVRangeToNPWP").ToString(), Double)
    '            GradeVNPWP = CType(row("GradeVNPWP").ToString(), Double)

    '            '            ActiveMonth()
    '            ',Year,TaxExemptionChild,TaxExemptionHusbWife,TaxExemptionWorker,GradeI,GradeII,GradeIII,GradeIV,GradeV,
    '            'GradeIRange,GradeIIRangeFrom,GradeIIRangeTo,GradeIIIRangeFrom,GradeIIIRangeTo,GradeIVRangeFrom,GradeIVRangeTo,
    '            'GradeINPWP,GradeIRangeNPWP,GradeIINPWP,GradeIIRangeFromNPWP,GradeIIRangeToNPWP,GradeIIINPWP,GradeIIIRangeFromNPWP,GradeIIIRangeToNPWP
    '            ',GradeIVNPWP,GradeIVRangeFromNPWP,GradeIVRangeToNPWP,GradeVNPWP,PTKP
    '        Next


    '        dtAct = ProcessDal.GetMaritalStatusAndActMnth()
    '        For Each rowAct As DataRow In dtAct.Rows
    '            CheckRollTaxPPT.ActiveMonthYearID1 = rowAct("ActiveMonthYearID1").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID2 = rowAct("ActiveMonthYearID2").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID3 = rowAct("ActiveMonthYearID3").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID4 = rowAct("ActiveMonthYearID4").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID5 = rowAct("ActiveMonthYearID5").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID6 = rowAct("ActiveMonthYearID6").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID7 = rowAct("ActiveMonthYearID7").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID8 = rowAct("ActiveMonthYearID8").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID9 = rowAct("ActiveMonthYearID9").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID10 = rowAct("ActiveMonthYearID10").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID11 = rowAct("ActiveMonthYearID11").ToString()
    '            CheckRollTaxPPT.ActiveMonthYearID12 = rowAct("ActiveMonthYearID12").ToString()
    '            If (GlobalPPT.Empid = "01R1415") Then
    '                Dim a As Integer
    '                a = 1
    '            End If

    '            If (rowAct("Income_Regular1").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular1 = CType(rowAct("Income_Regular1").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular2").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular2 = CType(rowAct("Income_Regular2").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular3").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular3 = CType(rowAct("Income_Regular3").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular4").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular4 = CType(rowAct("Income_Regular4").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular5").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular5 = CType(rowAct("Income_Regular5").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular6").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular6 = CType(rowAct("Income_Regular6").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular7").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular7 = CType(rowAct("Income_Regular7").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular8").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular8 = CType(rowAct("Income_Regular8").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular9").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular9 = CType(rowAct("Income_Regular9").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular10").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular10 = CType(rowAct("Income_Regular10").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular11").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular11 = CType(rowAct("Income_Regular11").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Regular12").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Regular12 = CType(rowAct("Income_Regular12").ToString(), Double)
    '            End If

    '            Accident_Insurance1 = 0
    '            Accident_Insurance2 = 0
    '            Accident_Insurance3 = 0
    '            Accident_Insurance4 = 0
    '            Accident_Insurance5 = 0
    '            Accident_Insurance6 = 0
    '            Accident_Insurance7 = 0
    '            Accident_Insurance8 = 0
    '            Accident_Insurance9 = 0
    '            Accident_Insurance10 = 0
    '            Accident_Insurance11 = 0
    '            Accident_Insurance12 = 0

    '            If (rowAct("Accident_Insurance1").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance1 = CType(rowAct("Accident_Insurance1").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance2").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance2 = CType(rowAct("Accident_Insurance2").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance3").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance3 = CType(rowAct("Accident_Insurance3").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance4").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance4 = CType(rowAct("Accident_Insurance4").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance5").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance5 = CType(rowAct("Accident_Insurance5").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance6").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance6 = CType(rowAct("Accident_Insurance6").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance7").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance7 = CType(rowAct("Accident_Insurance7").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance8").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance8 = CType(rowAct("Accident_Insurance8").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance9").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance9 = CType(rowAct("Accident_Insurance9").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance10").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance10 = CType(rowAct("Accident_Insurance10").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance11").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance11 = CType(rowAct("Accident_Insurance11").ToString(), Double)
    '            End If
    '            If (rowAct("Accident_Insurance12").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Accident_Insurance12 = CType(rowAct("Accident_Insurance12").ToString(), Double)
    '            End If

    '            If (rowAct("Income_Irregular1").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular1 = CType(rowAct("Income_Irregular1").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular2").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular2 = CType(rowAct("Income_Irregular2").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular3").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular3 = CType(rowAct("Income_Irregular3").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular4").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular4 = CType(rowAct("Income_Irregular4").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular5").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular5 = CType(rowAct("Income_Irregular5").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular6").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular6 = CType(rowAct("Income_Irregular6").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular7").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular7 = CType(rowAct("Income_Irregular7").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular8").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular8 = CType(rowAct("Income_Irregular8").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular9").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular9 = CType(rowAct("Income_Irregular9").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular10").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular10 = CType(rowAct("Income_Irregular10").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular11").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular11 = CType(rowAct("Income_Irregular11").ToString(), Double)
    '            End If
    '            If (rowAct("Income_Irregular12").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Income_Irregular12 = CType(rowAct("Income_Irregular12").ToString(), Double)
    '            End If


    '            If (rowAct("ActiveMonth1Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth1Sal = CType(rowAct("ActiveMonth1Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth1Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth2Sal = CType(rowAct("ActiveMonth2Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth3Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth3Sal = CType(rowAct("ActiveMonth3Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth4Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth4Sal = CType(rowAct("ActiveMonth4Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth5Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth5Sal = CType(rowAct("ActiveMonth5Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth6Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth6Sal = CType(rowAct("ActiveMonth6Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth7Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth7Sal = CType(rowAct("ActiveMonth7Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth8Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth8Sal = CType(rowAct("ActiveMonth8Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth9Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth9Sal = CType(rowAct("ActiveMonth9Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth10Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth10Sal = CType(rowAct("ActiveMonth10Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth11Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth11Sal = CType(rowAct("ActiveMonth11Sal").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth12Sal").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth12Sal = CType(rowAct("ActiveMonth12Sal").ToString(), Double)
    '            End If


    '            If (rowAct("ActiveMonth1Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth1Tax = CType(rowAct("ActiveMonth1Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth1Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth2Tax = CType(rowAct("ActiveMonth2Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth3Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth3Tax = CType(rowAct("ActiveMonth3Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth4Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth4Tax = CType(rowAct("ActiveMonth4Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth5Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth5Tax = CType(rowAct("ActiveMonth5Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth6Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth6Tax = CType(rowAct("ActiveMonth6Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth7Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth7Tax = CType(rowAct("ActiveMonth7Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth8Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth8Tax = CType(rowAct("ActiveMonth8Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth9Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth9Tax = CType(rowAct("ActiveMonth9Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth10Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth10Tax = CType(rowAct("ActiveMonth10Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth11Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth11Tax = CType(rowAct("ActiveMonth11Tax").ToString(), Double)
    '            End If
    '            If (rowAct("ActiveMonth12Tax").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.ActiveMonth12Tax = CType(rowAct("ActiveMonth12Tax").ToString(), Double)
    '            End If

    '            If (rowAct("Category").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.Category = rowAct("Category").ToString
    '            End If
    '            If (rowAct("JHTPercent").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.JHTPercent = CType(rowAct("JHTPercent").ToString(), Double)
    '            End If
    '            If (rowAct("HIPMonthlyRate").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.HIPMonthlyRate = CType(rowAct("HIPMonthlyRate").ToString(), Double)
    '            End If
    '            If (rowAct("NPWP").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.NPWP = rowAct("NPWP").ToString()
    '            End If
    '            If (rowAct("DedTaxCompany").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.DedTaxCompany = rowAct("DedTaxCompany").ToString()
    '            End If
    '            If (rowAct("DedAdvance").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.DedAdvance = rowAct("DedAdvance").ToString()
    '            End If
    '            If (rowAct("DedOther").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.DedOther = rowAct("DedOther").ToString()
    '            End If

    '            If (rowAct("TotalBruto").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.TotalBruto = rowAct("TotalBruto").ToString()
    '            End If

    '            If (rowAct("DedAstek").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.DedAstek = rowAct("DedAstek").ToString()
    '            End If


    '            If (rowAct("THR").ToString() <> String.Empty) Then
    '                CheckRollTaxPPT.THR = rowAct("THR").ToString()
    '            End If
    '        Next

    '        If CheckRollTaxPPT.THR > 0 Or CheckRollTaxPPT.Category <> String.Empty Then


    '            dtTaxable_Income = ProcessDal.GetTaxIncome()

    '            For Each rowTax As DataRow In dtTaxable_Income.Rows
    '                If (rowTax("Taxable_Income_Regular1").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular1 = CType(rowTax("Taxable_Income_Regular1").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular2").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular2 = CType(rowTax("Taxable_Income_Regular2").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular3").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular3 = CType(rowTax("Taxable_Income_Regular3").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular4").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular4 = CType(rowTax("Taxable_Income_Regular4").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular5").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular5 = CType(rowTax("Taxable_Income_Regular5").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular6").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular6 = CType(rowTax("Taxable_Income_Regular6").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular7").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular7 = CType(rowTax("Taxable_Income_Regular7").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular8").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular8 = CType(rowTax("Taxable_Income_Regular8").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular9").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular9 = CType(rowTax("Taxable_Income_Regular9").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular10").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular10 = CType(rowTax("Taxable_Income_Regular10").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular11").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular11 = CType(rowTax("Taxable_Income_Regular11").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_Regular12").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Regular12 = CType(rowTax("Taxable_Income_Regular12").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular1").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular1 = CType(rowTax("Taxable_Income_IRRegular1").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular2").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular2 = CType(rowTax("Taxable_Income_IRRegular2").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular3").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular3 = CType(rowTax("Taxable_Income_IRRegular3").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular4").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular4 = CType(rowTax("Taxable_Income_IRRegular4").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular5").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular5 = CType(rowTax("Taxable_Income_IRRegular5").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular6").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular6 = CType(rowTax("Taxable_Income_IRRegular6").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular7").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular7 = CType(rowTax("Taxable_Income_IRRegular7").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular8").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular8 = CType(rowTax("Taxable_Income_IRRegular8").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular9").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular9 = CType(rowTax("Taxable_Income_IRRegular9").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular10").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular10 = CType(rowTax("Taxable_Income_IRRegular10").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular11").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular11 = CType(rowTax("Taxable_Income_IRRegular11").ToString(), Double)
    '                End If
    '                If (rowTax("Taxable_Income_IRRegular12").ToString() <> String.Empty) Then
    '                    CheckRollTaxPPT.Taxable_Income_Irregular12 = CType(rowTax("Taxable_Income_IRRegular12").ToString(), Double)
    '                End If

    '            Next
    '            processs()
    '            dtDedTax = ProcessDal.GetDedTaxOfEmployee()
    '        End If
    '        dt.Dispose()
    '        dtAct.Dispose()
    '        dtDedTax.Dispose()
    '        dtTaxable_Income.Dispose()

    '    Next
    '    dtEmp.Dispose()
    'End Sub

    ''Added by nelson
    ''Following Procedure is no more in USE
    'Public Sub processs()

    '    Taxable_Income_TRegular1 = 0
    '    Taxable_Income_TRegular2 = 0
    '    Taxable_Income_TRegular3 = 0
    '    Taxable_Income_TRegular4 = 0
    '    Taxable_Income_TRegular5 = 0
    '    Taxable_Income_TRegular6 = 0
    '    Taxable_Income_TRegular7 = 0
    '    Taxable_Income_TRegular8 = 0
    '    Taxable_Income_TRegular9 = 0
    '    Taxable_Income_TRegular10 = 0
    '    Taxable_Income_TRegular11 = 0
    '    Taxable_Income_TRegular12 = 0

    '    Taxable_Income_IrTRegular1 = 0
    '    Taxable_Income_IrTRegular2 = 0
    '    Taxable_Income_IrTRegular3 = 0
    '    Taxable_Income_IrTRegular4 = 0
    '    Taxable_Income_IrTRegular5 = 0
    '    Taxable_Income_IrTRegular6 = 0
    '    Taxable_Income_IrTRegular7 = 0
    '    Taxable_Income_IrTRegular8 = 0
    '    Taxable_Income_IrTRegular9 = 0
    '    Taxable_Income_IrTRegular10 = 0
    '    Taxable_Income_IrTRegular11 = 0
    '    Taxable_Income_IrTRegular12 = 0

    '    If CheckRollTaxPPT.NPWP = "NO" Then



    '        If (CheckRollTaxPPT.Taxable_Income_Regular1 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular1 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular1 <> 0 Then

    '            If (CheckRollTaxPPT.Taxable_Income_Regular1 - GradeIRange) > 0 Then

    '                Taxable_Income_TRegular1 = CheckRollTaxPPT.Taxable_Income_Regular1 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular1R1 = Taxable_Income_TRegular1 * (GradeI / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R1 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeI / 100)
    '            End If
    '        End If


    '        If (CheckRollTaxPPT.Taxable_Income_Regular2 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular2 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular2 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular2 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular2 = CheckRollTaxPPT.Taxable_Income_Regular2 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular2R1 = Taxable_Income_TRegular2 * (GradeI / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R1 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular3 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular3 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular3 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular3 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular3 = CheckRollTaxPPT.Taxable_Income_Regular3 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular3R1 = Taxable_Income_TRegular3 * (GradeI / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R1 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular4 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular4 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular4 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular4 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular4 = CheckRollTaxPPT.Taxable_Income_Regular4 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular4R1 = Taxable_Income_TRegular4 * (GradeI / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R1 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular5 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular5 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular5 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular5 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular5 = CheckRollTaxPPT.Taxable_Income_Regular5 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular5R1 = Taxable_Income_TRegular5 * (GradeI / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R1 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular6 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular6 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular6 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular6 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular6 = CheckRollTaxPPT.Taxable_Income_Regular6 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular6R1 = Taxable_Income_TRegular6 * (GradeI / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R1 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular7 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular7 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular7 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular7 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular7 = CheckRollTaxPPT.Taxable_Income_Regular7 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular7R1 = Taxable_Income_TRegular7 * (GradeI / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R1 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular8 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular8 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular8 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular8 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular8 = CheckRollTaxPPT.Taxable_Income_Regular8 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular8R1 = Taxable_Income_TRegular8 * (GradeI / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R1 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular9 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular9 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular9 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular9 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular9 = CheckRollTaxPPT.Taxable_Income_Regular9 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular9R1 = Taxable_Income_TRegular9 * (GradeI / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R1 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular10 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular10 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular10 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular10 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular10 = CheckRollTaxPPT.Taxable_Income_Regular10 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular10R1 = Taxable_Income_TRegular10 * (GradeI / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R1 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular11 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular11 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular11 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular11 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular1 = CheckRollTaxPPT.Taxable_Income_Regular11 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular11R1 = Taxable_Income_TRegular11 * (GradeI / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R1 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular12 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Regular12 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Regular12 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular12 - GradeIRange) > 0 Then
    '                Taxable_Income_TRegular12 = CheckRollTaxPPT.Taxable_Income_Regular12 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_Regular12R1 = Taxable_Income_TRegular12 * (GradeI / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R1 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeI / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular1 >= GradeIIRangeFrom And Taxable_Income_TRegular1 <= GradeIIRangeTo) Or (Taxable_Income_TRegular1 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIIRangeTo) > 0 Then

    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular1 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular1R2 = Taxable_Income_TRegular1 * (GradeII / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R2 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeII / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular2 >= GradeIIRangeFrom And Taxable_Income_TRegular2 <= GradeIIRangeTo) Or (Taxable_Income_TRegular2 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular2 = Taxable_Income_TRegular2 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular2R2 = Taxable_Income_TRegular2 * (GradeII / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R2 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeII / 100)
    '            End If
    '        End If
    '        If ((Taxable_Income_TRegular3 >= GradeIIRangeFrom And Taxable_Income_TRegular3 <= GradeIIRangeTo) Or (Taxable_Income_TRegular3 > 0)) Then
    '            If (Taxable_Income_TRegular3 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular3 = Taxable_Income_TRegular3 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular3R2 = Taxable_Income_TRegular3 * (GradeII / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R2 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular4 >= GradeIIRangeFrom And Taxable_Income_TRegular4 <= GradeIIRangeTo) Or (Taxable_Income_TRegular4 > 0)) Then
    '            If (Taxable_Income_TRegular4 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular4 = Taxable_Income_TRegular4 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular4R2 = Taxable_Income_TRegular4 * (GradeII / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R2 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular5 >= GradeIIRangeFrom And Taxable_Income_TRegular5 <= GradeIIRangeTo) Or (Taxable_Income_TRegular5 > 0)) Then
    '            If (Taxable_Income_TRegular5 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular5 = Taxable_Income_TRegular5 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular5R2 = Taxable_Income_TRegular5 * (GradeII / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R2 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular6 >= GradeIIRangeFrom And Taxable_Income_TRegular6 <= GradeIIRangeTo) Or (Taxable_Income_TRegular6 > 0)) Then
    '            If (Taxable_Income_TRegular6 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular6 = Taxable_Income_TRegular6 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular6R2 = Taxable_Income_TRegular6 * (GradeII / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R2 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular7 >= GradeIIRangeFrom And Taxable_Income_TRegular7 <= GradeIIRangeTo) Or (Taxable_Income_TRegular7 > 0)) Then
    '            If (Taxable_Income_TRegular7 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular7 = Taxable_Income_TRegular7 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular7R2 = Taxable_Income_TRegular7 * (GradeII / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R2 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular8 >= GradeIIRangeFrom And Taxable_Income_TRegular8 <= GradeIIRangeTo) Or (Taxable_Income_TRegular8 > 0)) Then
    '            If (Taxable_Income_TRegular8 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular8 = Taxable_Income_TRegular8 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular8R2 = Taxable_Income_TRegular8 * (GradeII / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R2 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular9 >= GradeIIRangeFrom And Taxable_Income_TRegular9 <= GradeIIRangeTo) Or (Taxable_Income_TRegular9 > 0)) Then
    '            If (Taxable_Income_TRegular9 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular9 = Taxable_Income_TRegular10 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular9R2 = Taxable_Income_TRegular9 * (GradeII / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R2 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular10 >= GradeIIRangeFrom And Taxable_Income_TRegular10 <= GradeIIRangeTo) Or (Taxable_Income_TRegular10 > 0)) Then
    '            If (Taxable_Income_TRegular10 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular10 = Taxable_Income_TRegular10 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular10R2 = Taxable_Income_TRegular10 * (GradeII / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R2 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular11 >= GradeIIRangeFrom And Taxable_Income_TRegular11 <= GradeIIRangeTo) Or (Taxable_Income_TRegular11 > 0)) Then

    '            If (Taxable_Income_TRegular11 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular11 = Taxable_Income_TRegular11 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular11R2 = Taxable_Income_TRegular11 * (GradeII / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R2 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular12 >= GradeIIRangeFrom And Taxable_Income_TRegular12 <= GradeIIRangeTo) Or (Taxable_Income_TRegular12 > 0)) Then
    '            If (Taxable_Income_TRegular12 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular12 = Taxable_Income_TRegular12 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular12R2 = Taxable_Income_TRegular12 * (GradeII / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R2 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeII / 100)
    '            End If
    '        End If





    '        If ((Taxable_Income_TRegular1 >= GradeIIIRangeFrom And Taxable_Income_TRegular1 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular1 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular1 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular1R3 = Taxable_Income_TRegular1 * (GradeIII / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R3 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular2 >= GradeIIIRangeFrom And Taxable_Income_TRegular2 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular2 > 0)) Then
    '            If (Taxable_Income_TRegular2 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular2 = Taxable_Income_TRegular2 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular2R3 = Taxable_Income_TRegular1 * (GradeIII / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R3 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeIII / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular3 >= GradeIIIRangeFrom And Taxable_Income_TRegular3 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular3 > 0)) Then
    '            If (Taxable_Income_TRegular3 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular3 = Taxable_Income_TRegular3 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular3R3 = Taxable_Income_TRegular3 * (GradeIII / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R3 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular4 >= GradeIIIRangeFrom And Taxable_Income_TRegular4 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular4 > 0)) Then
    '            If (Taxable_Income_TRegular4 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular4 = Taxable_Income_TRegular4 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular4R3 = Taxable_Income_TRegular4 * (GradeIII / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R3 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular5 >= GradeIIIRangeFrom And Taxable_Income_TRegular5 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular5 > 0)) Then
    '            If (Taxable_Income_TRegular5 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular5 = Taxable_Income_TRegular5 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular5R3 = Taxable_Income_TRegular5 * (GradeIII / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R3 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular6 >= GradeIIIRangeFrom And Taxable_Income_TRegular6 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular6 > 0)) Then
    '            If (Taxable_Income_TRegular6 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular6 = Taxable_Income_TRegular6 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular6R3 = Taxable_Income_TRegular6 * (GradeIII / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R3 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular7 >= GradeIIIRangeFrom And Taxable_Income_TRegular7 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular7 > 0)) Then
    '            If (Taxable_Income_TRegular7 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular7 = Taxable_Income_TRegular7 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular7R3 = Taxable_Income_TRegular7 * (GradeIII / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R3 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular8 >= GradeIIIRangeFrom And Taxable_Income_TRegular8 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular8 > 0)) Then
    '            If (Taxable_Income_TRegular8 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular8 = Taxable_Income_TRegular8 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular8R3 = Taxable_Income_TRegular8 * (GradeIII / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R3 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular9 >= GradeIIIRangeFrom And Taxable_Income_TRegular9 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular9 > 0)) Then
    '            If (Taxable_Income_TRegular9 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular9 = Taxable_Income_TRegular9 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular9R3 = Taxable_Income_TRegular9 * (GradeIII / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R3 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular10 >= GradeIIIRangeFrom And Taxable_Income_TRegular10 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular10 > 0)) Then
    '            If (Taxable_Income_TRegular10 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular10 = Taxable_Income_TRegular10 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular10R3 = Taxable_Income_TRegular10 * (GradeIII / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R3 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular11 >= GradeIIIRangeFrom And Taxable_Income_TRegular11 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular11 > 0)) Then
    '            If (Taxable_Income_TRegular11 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular11 = Taxable_Income_TRegular11 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular11R3 = Taxable_Income_TRegular11 * (GradeIII / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R3 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeIII / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular12 >= GradeIIIRangeFrom And Taxable_Income_TRegular12 <= GradeIIIRangeTo) Or (Taxable_Income_TRegular12 > 0)) Then
    '            If (Taxable_Income_TRegular12 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_TRegular12 = Taxable_Income_TRegular12 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular12R3 = Taxable_Income_TRegular12 * (GradeIII / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R3 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular1 >= GradeIVRangeFrom And Taxable_Income_TRegular1 <= GradeIVRangeTo) Or (Taxable_Income_TRegular1 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular1 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular1R4 = Taxable_Income_TRegular1 * (GradeIV / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R4 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeIV / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular2 >= GradeIVRangeFrom And Taxable_Income_TRegular2 <= GradeIVRangeTo) Or (Taxable_Income_TRegular2 > 0)) Then
    '            If (Taxable_Income_TRegular2 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular2 = Taxable_Income_TRegular2 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular2R4 = Taxable_Income_TRegular2 * (GradeIV / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R4 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular3 >= GradeIVRangeFrom And Taxable_Income_TRegular3 <= GradeIVRangeTo) Or (Taxable_Income_TRegular3 > 0)) Then
    '            If (Taxable_Income_TRegular3 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular3 = Taxable_Income_TRegular3 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular3R4 = Taxable_Income_TRegular3 * (GradeIV / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R4 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular4 >= GradeIVRangeFrom And Taxable_Income_TRegular4 <= GradeIVRangeTo) Or (Taxable_Income_TRegular4 > 0)) Then
    '            If (Taxable_Income_TRegular4 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular4 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular4R4 = Taxable_Income_TRegular4 * (GradeIV / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R4 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular5 >= GradeIVRangeFrom And Taxable_Income_TRegular5 <= GradeIVRangeTo) Or (Taxable_Income_TRegular5 > 0)) Then
    '            If (Taxable_Income_TRegular5 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular5 = Taxable_Income_TRegular5 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular5R4 = Taxable_Income_TRegular5 * (GradeIV / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R4 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular6 >= GradeIVRangeFrom And Taxable_Income_TRegular6 <= GradeIVRangeTo) Or (Taxable_Income_TRegular6 > 0)) Then
    '            If (Taxable_Income_TRegular6 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular6 = Taxable_Income_TRegular6 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular6R4 = Taxable_Income_TRegular6 * (GradeIV / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R4 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular7 >= GradeIVRangeFrom And Taxable_Income_TRegular7 <= GradeIVRangeTo) Or (Taxable_Income_TRegular7 > 0)) Then
    '            If (Taxable_Income_TRegular7 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular7 = Taxable_Income_TRegular7 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular7R4 = Taxable_Income_TRegular7 * (GradeIV / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R4 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular8 >= GradeIVRangeFrom And Taxable_Income_TRegular8 <= GradeIVRangeTo) Or (Taxable_Income_TRegular8 > 0)) Then
    '            If (Taxable_Income_TRegular8 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular8 = Taxable_Income_TRegular8 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular8R4 = Taxable_Income_TRegular8 * (GradeIV / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R4 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular9 >= GradeIVRangeFrom And Taxable_Income_TRegular9 <= GradeIVRangeTo) Or (Taxable_Income_TRegular9 > 0)) Then
    '            If (Taxable_Income_TRegular9 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular9 = Taxable_Income_TRegular9 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular9R4 = Taxable_Income_TRegular9 * (GradeIV / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R4 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular10 >= GradeIVRangeFrom And Taxable_Income_TRegular10 <= GradeIVRangeTo) Or (Taxable_Income_TRegular10 > 0)) Then
    '            If (Taxable_Income_TRegular10 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular10 = Taxable_Income_TRegular10 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular10R4 = Taxable_Income_TRegular10 * (GradeIV / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R4 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeIV / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular11 >= GradeIVRangeFrom And Taxable_Income_TRegular11 <= GradeIVRangeTo) Or (Taxable_Income_TRegular11 > 0)) Then
    '            If (Taxable_Income_TRegular11 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular11 = Taxable_Income_TRegular11 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular11R4 = Taxable_Income_TRegular11 * (GradeIV / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R4 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeIV / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular12 >= GradeIVRangeFrom And Taxable_Income_TRegular12 <= GradeIVRangeTo) Or (Taxable_Income_TRegular12 > 0)) Then
    '            If (Taxable_Income_TRegular12 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_TRegular12 = Taxable_Income_TRegular12 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_Regular12R4 = Taxable_Income_TRegular12 * (GradeIV / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R4 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeIV / 100)
    '            End If
    '        End If





    '        If (Taxable_Income_TRegular1 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular1R5 = Taxable_Income_TRegular1 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular2 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular2R5 = Taxable_Income_TRegular2 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular3 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular3R5 = Taxable_Income_TRegular3 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular4 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular4R5 = Taxable_Income_TRegular4 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular5 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular5R5 = Taxable_Income_TRegular5 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular6 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular6R5 = Taxable_Income_TRegular6 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular7 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular7R5 = Taxable_Income_TRegular7 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular8 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular8R5 = Taxable_Income_TRegular8 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular9 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular9R5 = Taxable_Income_TRegular9 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular10 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular10R5 = Taxable_Income_TRegular10 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular11 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular11R5 = Taxable_Income_TRegular11 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_TRegular12 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular12R5 = Taxable_Income_TRegular12 * (GradeV / 100)


    '        End If








    '    Else


    '        If (CheckRollTaxPPT.Taxable_Income_Regular1 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular1 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular1 <> 0 Then

    '            If (CheckRollTaxPPT.Taxable_Income_Regular1 - GradeIRangeNPWP) > 0 Then

    '                Taxable_Income_TRegular1 = CheckRollTaxPPT.Taxable_Income_Regular1 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular1R1 = Taxable_Income_TRegular1 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R1 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeINPWP / 100)
    '            End If
    '        End If


    '        If (CheckRollTaxPPT.Taxable_Income_Regular2 <= GradeIRangeNPWP Or Taxable_Income_Regular2 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular2 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular2 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular2 = CheckRollTaxPPT.Taxable_Income_Regular2 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular2R1 = Taxable_Income_TRegular2 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R1 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular3 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular3 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular3 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular3 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular3 = CheckRollTaxPPT.Taxable_Income_Regular3 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular3R1 = Taxable_Income_TRegular3 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R1 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular4 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular4 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular4 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular4 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular4 = CheckRollTaxPPT.Taxable_Income_Regular4 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular4R1 = Taxable_Income_TRegular4 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R1 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular5 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular5 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular5 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular5 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular5 = CheckRollTaxPPT.Taxable_Income_Regular5 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular5R1 = Taxable_Income_TRegular5 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R1 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular6 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular6 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular6 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular6 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular6 = CheckRollTaxPPT.Taxable_Income_Regular6 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular6R1 = Taxable_Income_TRegular6 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R1 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular7 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular7 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular7 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular7 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular7 = CheckRollTaxPPT.Taxable_Income_Regular7 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular7R1 = Taxable_Income_TRegular7 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R1 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular8 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular8 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular8 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular8 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular8 = CheckRollTaxPPT.Taxable_Income_Regular8 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular8R1 = Taxable_Income_TRegular8 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R1 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular9 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular9 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular9 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular9 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular9 = CheckRollTaxPPT.Taxable_Income_Regular9 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular9R1 = Taxable_Income_TRegular9 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R1 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular10 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular10 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular10 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular10 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular10 = CheckRollTaxPPT.Taxable_Income_Regular10 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular10R1 = Taxable_Income_TRegular10 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R1 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular11 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular11 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular11 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular11 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular1 = CheckRollTaxPPT.Taxable_Income_Regular11 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular11R1 = Taxable_Income_TRegular11 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R1 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Regular12 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Regular12 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Regular12 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Regular12 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_TRegular12 = CheckRollTaxPPT.Taxable_Income_Regular12 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_Regular12R1 = Taxable_Income_TRegular12 * (GradeINPWP / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R1 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeINPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular1 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular1 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular1 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIIRangeToNPWP) > 0 Then

    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular1 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular1R2 = Taxable_Income_TRegular1 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R2 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeIINPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular2 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular2 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular2 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular2 = Taxable_Income_TRegular2 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular2R2 = Taxable_Income_TRegular2 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R2 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeIINPWP / 100)
    '            End If
    '        End If
    '        If ((Taxable_Income_TRegular3 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular3 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular3 > 0)) Then
    '            If (Taxable_Income_TRegular3 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular3 = Taxable_Income_TRegular3 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular3R2 = Taxable_Income_TRegular3 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R2 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular4 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular4 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular4 > 0)) Then
    '            If (Taxable_Income_TRegular4 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular4 = Taxable_Income_TRegular4 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular4R2 = Taxable_Income_TRegular4 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R2 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular5 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular5 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular5 > 0)) Then
    '            If (Taxable_Income_TRegular5 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular5 = Taxable_Income_TRegular5 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular5R2 = Taxable_Income_TRegular5 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R2 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular6 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular6 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular6 > 0)) Then
    '            If (Taxable_Income_TRegular6 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular6 = Taxable_Income_TRegular6 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular6R2 = Taxable_Income_TRegular6 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R2 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular7 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular7 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular7 > 0)) Then
    '            If (Taxable_Income_TRegular7 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular7 = Taxable_Income_TRegular7 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular7R2 = Taxable_Income_TRegular7 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R2 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular8 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular8 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular8 > 0)) Then
    '            If (Taxable_Income_TRegular8 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular8 = Taxable_Income_TRegular8 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular8R2 = Taxable_Income_TRegular8 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R2 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular9 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular9 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular9 > 0)) Then
    '            If (Taxable_Income_TRegular9 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular9 = Taxable_Income_TRegular10 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular9R2 = Taxable_Income_TRegular9 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R2 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular10 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular10 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular10 > 0)) Then
    '            If (Taxable_Income_TRegular10 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular10 = Taxable_Income_TRegular10 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular10R2 = Taxable_Income_TRegular10 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R2 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular11 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular11 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular11 > 0)) Then

    '            If (Taxable_Income_TRegular11 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular11 = Taxable_Income_TRegular11 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular11R2 = Taxable_Income_TRegular11 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R2 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular12 >= GradeIIRangeFromNPWP And Taxable_Income_TRegular12 <= GradeIIRangeToNPWP) Or (Taxable_Income_TRegular12 > 0)) Then
    '            If (Taxable_Income_TRegular12 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular12 = Taxable_Income_TRegular12 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular12R2 = Taxable_Income_TRegular12 * (GradeIINPWP / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R2 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeIINPWP / 100)
    '            End If
    '        End If





    '        If ((Taxable_Income_TRegular1 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular1 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular1 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular1 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular1R3 = Taxable_Income_TRegular1 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R3 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular2 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular2 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular2 > 0)) Then
    '            If (Taxable_Income_TRegular2 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular2 = Taxable_Income_TRegular2 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular2R3 = Taxable_Income_TRegular1 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R3 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeIIINPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular3 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular3 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular3 > 0)) Then
    '            If (Taxable_Income_TRegular3 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular3 = Taxable_Income_TRegular3 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular3R3 = Taxable_Income_TRegular3 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R3 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular4 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular4 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular4 > 0)) Then
    '            If (Taxable_Income_TRegular4 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular4 = Taxable_Income_TRegular4 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular4R3 = Taxable_Income_TRegular4 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R3 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular5 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular5 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular5 > 0)) Then
    '            If (Taxable_Income_TRegular5 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular5 = Taxable_Income_TRegular5 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular5R3 = Taxable_Income_TRegular5 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R3 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular6 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular6 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular6 > 0)) Then
    '            If (Taxable_Income_TRegular6 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular6 = Taxable_Income_TRegular6 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular6R3 = Taxable_Income_TRegular6 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R3 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular7 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular7 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular7 > 0)) Then
    '            If (Taxable_Income_TRegular7 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular7 = Taxable_Income_TRegular7 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular7R3 = Taxable_Income_TRegular7 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R3 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular8 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular8 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular8 > 0)) Then
    '            If (Taxable_Income_TRegular8 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular8 = Taxable_Income_TRegular8 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular8R3 = Taxable_Income_TRegular8 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R3 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular9 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular9 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular9 > 0)) Then
    '            If (Taxable_Income_TRegular9 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular9 = Taxable_Income_TRegular9 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular9R3 = Taxable_Income_TRegular9 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R3 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular10 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular10 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular10 > 0)) Then
    '            If (Taxable_Income_TRegular10 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular10 = Taxable_Income_TRegular10 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular10R3 = Taxable_Income_TRegular10 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R3 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular11 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular11 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular11 > 0)) Then
    '            If (Taxable_Income_TRegular11 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular11 = Taxable_Income_TRegular11 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular11R3 = Taxable_Income_TRegular11 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R3 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeIIINPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular12 >= GradeIIIRangeFromNPWP And Taxable_Income_TRegular12 <= GradeIIIRangeToNPWP) Or (Taxable_Income_TRegular12 > 0)) Then
    '            If (Taxable_Income_TRegular12 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular12 = Taxable_Income_TRegular12 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular12R3 = Taxable_Income_TRegular12 * (GradeIIINPWP / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R3 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_TRegular1 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular1 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular1 > 0)) Then
    '            If (Taxable_Income_TRegular1 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular1 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular1R4 = Taxable_Income_TRegular1 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular1 > 0 Then

    '                    Taxable_Income_TRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular1R4 = CheckRollTaxPPT.Taxable_Income_Regular1 * (GradeIVNPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular2 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular2 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular2 > 0)) Then
    '            If (Taxable_Income_TRegular2 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular2 = Taxable_Income_TRegular2 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular2R4 = Taxable_Income_TRegular2 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular2 > 0 Then

    '                    Taxable_Income_TRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular2R4 = CheckRollTaxPPT.Taxable_Income_Regular2 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular3 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular3 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular3 > 0)) Then
    '            If (Taxable_Income_TRegular3 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular3 = Taxable_Income_TRegular3 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular3R4 = Taxable_Income_TRegular3 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular3 > 0 Then

    '                    Taxable_Income_TRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular3R4 = CheckRollTaxPPT.Taxable_Income_Regular3 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular4 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular4 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular4 > 0)) Then
    '            If (Taxable_Income_TRegular4 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular1 = Taxable_Income_TRegular4 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular4R4 = Taxable_Income_TRegular4 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular4 > 0 Then

    '                    Taxable_Income_TRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular4R4 = CheckRollTaxPPT.Taxable_Income_Regular4 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular5 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular5 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular5 > 0)) Then
    '            If (Taxable_Income_TRegular5 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular5 = Taxable_Income_TRegular5 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular5R4 = Taxable_Income_TRegular5 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular5 > 0 Then

    '                    Taxable_Income_TRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular5R4 = CheckRollTaxPPT.Taxable_Income_Regular5 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular6 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular6 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular6 > 0)) Then
    '            If (Taxable_Income_TRegular6 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular6 = Taxable_Income_TRegular6 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular6R4 = Taxable_Income_TRegular6 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular6 > 0 Then

    '                    Taxable_Income_TRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular6R4 = CheckRollTaxPPT.Taxable_Income_Regular6 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular7 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular7 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular7 > 0)) Then
    '            If (Taxable_Income_TRegular7 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular7 = Taxable_Income_TRegular7 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular7R4 = Taxable_Income_TRegular7 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular7 > 0 Then

    '                    Taxable_Income_TRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular7R4 = CheckRollTaxPPT.Taxable_Income_Regular7 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular8 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular8 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular8 > 0)) Then
    '            If (Taxable_Income_TRegular8 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular8 = Taxable_Income_TRegular8 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular8R4 = Taxable_Income_TRegular8 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular8 > 0 Then

    '                    Taxable_Income_TRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular8R4 = CheckRollTaxPPT.Taxable_Income_Regular8 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular9 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular9 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular9 > 0)) Then
    '            If (Taxable_Income_TRegular9 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular9 = Taxable_Income_TRegular9 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular9R4 = Taxable_Income_TRegular9 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular9 > 0 Then

    '                    Taxable_Income_TRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular9R4 = CheckRollTaxPPT.Taxable_Income_Regular9 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_TRegular10 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular10 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular10 > 0)) Then
    '            If (Taxable_Income_TRegular10 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular10 = Taxable_Income_TRegular10 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular10R4 = Taxable_Income_TRegular10 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular10 > 0 Then

    '                    Taxable_Income_TRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular10R4 = CheckRollTaxPPT.Taxable_Income_Regular10 * (GradeIVNPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular11 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular11 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular11 > 0)) Then
    '            If (Taxable_Income_TRegular11 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular11 = Taxable_Income_TRegular11 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular11R4 = Taxable_Income_TRegular11 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular11 > 0 Then

    '                    Taxable_Income_TRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular11R4 = CheckRollTaxPPT.Taxable_Income_Regular11 * (GradeIVNPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_TRegular12 >= GradeIVRangeFromNPWP And Taxable_Income_TRegular12 <= GradeIVRangeToNPWP) Or (Taxable_Income_TRegular12 > 0)) Then
    '            If (Taxable_Income_TRegular12 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_TRegular12 = Taxable_Income_TRegular12 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_Regular12R4 = Taxable_Income_TRegular12 * (GradeIVNPWP / 100)
    '                If Taxable_Income_TRegular12 > 0 Then

    '                    Taxable_Income_TRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_Regular12R4 = CheckRollTaxPPT.Taxable_Income_Regular12 * (GradeIVNPWP / 100)
    '            End If
    '        End If





    '        If (Taxable_Income_TRegular1 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular1R5 = Taxable_Income_TRegular1 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular2 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular2R5 = Taxable_Income_TRegular2 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular3 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular3R5 = Taxable_Income_TRegular3 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular4 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular4R5 = Taxable_Income_TRegular4 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular5 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular5R5 = Taxable_Income_TRegular5 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular6 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular6R5 = Taxable_Income_TRegular6 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular7 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular7R5 = Taxable_Income_TRegular7 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular8 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular8R5 = Taxable_Income_TRegular8 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular9 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular9R5 = Taxable_Income_TRegular9 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular10 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular10R5 = Taxable_Income_TRegular10 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular11 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular11R5 = Taxable_Income_TRegular11 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_TRegular12 > 0) Then

    '            CheckRollTaxPPT.PPH_21_Regular12R5 = Taxable_Income_TRegular12 * (GradeVNPWP / 100)


    '        End If


    '    End If

    '    'u----------------------------------------------------------------------------------------------------------



    '    If CheckRollTaxPPT.NPWP = "NO" Then
    '        If (CheckRollTaxPPT.Taxable_Income_Irregular1 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular1 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular1 <> 0 Then

    '            If (CheckRollTaxPPT.Taxable_Income_Irregular1 - GradeIRange) > 0 Then

    '                Taxable_Income_IrTRegular1 = CheckRollTaxPPT.Taxable_Income_Irregular1 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular1R1 = Taxable_Income_IrTRegular1 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R1 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeI / 100)
    '            End If
    '        End If


    '        If (CheckRollTaxPPT.Taxable_Income_Irregular2 <= GradeIRange Or Taxable_Income_Irregular2 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular2 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular2 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular2 = CheckRollTaxPPT.Taxable_Income_Irregular2 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular2R1 = Taxable_Income_IrTRegular2 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R1 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular3 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular3 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular3 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular3 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular3 = CheckRollTaxPPT.Taxable_Income_Irregular3 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular3R1 = Taxable_Income_IrTRegular3 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R1 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular4 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular4 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular4 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular4 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular4 = CheckRollTaxPPT.Taxable_Income_Irregular4 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular4R1 = Taxable_Income_IrTRegular4 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R1 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular5 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular5 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular5 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular5 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular5 = CheckRollTaxPPT.Taxable_Income_Irregular5 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular5R1 = Taxable_Income_IrTRegular5 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R1 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular6 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular6 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular6 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular6 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular6 = CheckRollTaxPPT.Taxable_Income_Irregular6 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular6R1 = Taxable_Income_IrTRegular6 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R1 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular7 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular7 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular7 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular7 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular7 = CheckRollTaxPPT.Taxable_Income_Irregular7 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular7R1 = Taxable_Income_IrTRegular7 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R1 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular8 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular8 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular8 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular8 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular8 = CheckRollTaxPPT.Taxable_Income_Irregular8 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular8R1 = Taxable_Income_IrTRegular8 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R1 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular9 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular9 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular9 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular9 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular9 = CheckRollTaxPPT.Taxable_Income_Irregular9 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular9R1 = Taxable_Income_IrTRegular9 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R1 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular10 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular10 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular10 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular10 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular10 = CheckRollTaxPPT.Taxable_Income_Irregular10 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular10R1 = Taxable_Income_IrTRegular10 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R1 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular11 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular11 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular11 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular11 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular1 = CheckRollTaxPPT.Taxable_Income_Irregular11 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular11R1 = Taxable_Income_IrTRegular11 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R1 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeI / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular12 <= GradeIRange Or CheckRollTaxPPT.Taxable_Income_Irregular12 >= GradeIRange) And CheckRollTaxPPT.Taxable_Income_Irregular12 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular12 - GradeIRange) > 0 Then
    '                Taxable_Income_IrTRegular12 = CheckRollTaxPPT.Taxable_Income_Irregular12 - GradeIRange
    '                CheckRollTaxPPT.PPH_21_IRRegular12R1 = Taxable_Income_IrTRegular12 * (GradeI / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R1 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeI / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular1 >= GradeIIRangeFrom And Taxable_Income_IrTRegular1 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular1 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIIRangeTo) > 0 Then

    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular1 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular1R2 = Taxable_Income_IrTRegular1 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R2 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeII / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular2 >= GradeIIRangeFrom And Taxable_Income_IrTRegular2 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular2 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular2 = Taxable_Income_IrTRegular2 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular2R2 = Taxable_Income_IrTRegular2 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R2 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeII / 100)
    '            End If
    '        End If
    '        If ((Taxable_Income_IrTRegular3 >= GradeIIRangeFrom And Taxable_Income_IrTRegular3 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular3 > 0)) Then
    '            If (Taxable_Income_IrTRegular3 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular3 = Taxable_Income_IrTRegular3 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular3R2 = Taxable_Income_IrTRegular3 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R2 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular4 >= GradeIIRangeFrom And Taxable_Income_IrTRegular4 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular4 > 0)) Then
    '            If (Taxable_Income_IrTRegular4 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular4 = Taxable_Income_IrTRegular4 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular4R2 = Taxable_Income_IrTRegular4 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R2 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular5 >= GradeIIRangeFrom And Taxable_Income_IrTRegular5 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular5 > 0)) Then
    '            If (Taxable_Income_IrTRegular5 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular5 = Taxable_Income_IrTRegular5 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular5R2 = Taxable_Income_IrTRegular5 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R2 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular6 >= GradeIIRangeFrom And Taxable_Income_IrTRegular6 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular6 > 0)) Then
    '            If (Taxable_Income_IrTRegular6 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular6 = Taxable_Income_IrTRegular6 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular6R2 = Taxable_Income_IrTRegular6 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R2 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular7 >= GradeIIRangeFrom And Taxable_Income_IrTRegular7 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular7 > 0)) Then
    '            If (Taxable_Income_IrTRegular7 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular7 = Taxable_Income_IrTRegular7 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular7R2 = Taxable_Income_IrTRegular7 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R2 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular8 >= GradeIIRangeFrom And Taxable_Income_IrTRegular8 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular8 > 0)) Then
    '            If (Taxable_Income_IrTRegular8 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular8 = Taxable_Income_IrTRegular8 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular8R2 = Taxable_Income_IrTRegular8 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R2 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular9 >= GradeIIRangeFrom And Taxable_Income_IrTRegular9 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular9 > 0)) Then
    '            If (Taxable_Income_IrTRegular9 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular9 = Taxable_Income_IrTRegular10 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular9R2 = Taxable_Income_IrTRegular9 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R2 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular10 >= GradeIIRangeFrom And Taxable_Income_IrTRegular10 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular10 > 0)) Then
    '            If (Taxable_Income_IrTRegular10 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular10 = Taxable_Income_IrTRegular10 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular10R2 = Taxable_Income_IrTRegular10 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R2 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular11 >= GradeIIRangeFrom And Taxable_Income_IrTRegular11 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular11 > 0)) Then

    '            If (Taxable_Income_IrTRegular11 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular11 = Taxable_Income_IrTRegular11 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular11R2 = Taxable_Income_IrTRegular11 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R2 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular12 >= GradeIIRangeFrom And Taxable_Income_IrTRegular12 <= GradeIIRangeTo) Or (Taxable_Income_IrTRegular12 > 0)) Then
    '            If (Taxable_Income_IrTRegular12 - GradeIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular12 = Taxable_Income_IrTRegular12 - GradeIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular12R2 = Taxable_Income_IrTRegular12 * (GradeII / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R2 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeII / 100)
    '            End If
    '        End If





    '        If ((Taxable_Income_IrTRegular1 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular1 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular1 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular1 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular1R3 = Taxable_Income_IrTRegular1 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R3 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular2 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular2 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular2 > 0)) Then
    '            If (Taxable_Income_IrTRegular2 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular2 = Taxable_Income_IrTRegular2 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular2R3 = Taxable_Income_IrTRegular1 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R3 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeIII / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular3 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular3 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular3 > 0)) Then
    '            If (Taxable_Income_IrTRegular3 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular3 = Taxable_Income_IrTRegular3 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular3R3 = Taxable_Income_IrTRegular3 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R3 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular4 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular4 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular4 > 0)) Then
    '            If (Taxable_Income_IrTRegular4 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular4 = Taxable_Income_IrTRegular4 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular4R3 = Taxable_Income_IrTRegular4 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R3 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular5 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular5 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular5 > 0)) Then
    '            If (Taxable_Income_IrTRegular5 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular5 = Taxable_Income_IrTRegular5 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular5R3 = Taxable_Income_IrTRegular5 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R3 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular6 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular6 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular6 > 0)) Then
    '            If (Taxable_Income_IrTRegular6 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular6 = Taxable_Income_IrTRegular6 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular6R3 = Taxable_Income_IrTRegular6 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R3 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular7 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular7 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular7 > 0)) Then
    '            If (Taxable_Income_IrTRegular7 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular7 = Taxable_Income_IrTRegular7 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular7R3 = Taxable_Income_IrTRegular7 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R3 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular8 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular8 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular8 > 0)) Then
    '            If (Taxable_Income_IrTRegular8 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular8 = Taxable_Income_IrTRegular8 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular8R3 = Taxable_Income_IrTRegular8 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R3 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular9 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular9 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular9 > 0)) Then
    '            If (Taxable_Income_IrTRegular9 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular9 = Taxable_Income_IrTRegular9 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular9R3 = Taxable_Income_IrTRegular9 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R3 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular10 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular10 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular10 > 0)) Then
    '            If (Taxable_Income_IrTRegular10 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular10 = Taxable_Income_IrTRegular10 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular10R3 = Taxable_Income_IrTRegular10 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R3 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular11 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular11 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular11 > 0)) Then
    '            If (Taxable_Income_IrTRegular11 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular11 = Taxable_Income_IrTRegular11 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular11R3 = Taxable_Income_IrTRegular11 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R3 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeIII / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular12 >= GradeIIIRangeFrom And Taxable_Income_IrTRegular12 <= GradeIIIRangeTo) Or (Taxable_Income_IrTRegular12 > 0)) Then
    '            If (Taxable_Income_IrTRegular12 - GradeIIIRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular12 = Taxable_Income_IrTRegular12 - GradeIIIRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular12R3 = Taxable_Income_IrTRegular12 * (GradeIII / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R3 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeIII / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular1 >= GradeIVRangeFrom And Taxable_Income_IrTRegular1 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular1 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular1 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular1R4 = Taxable_Income_IrTRegular1 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R4 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeIV / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular2 >= GradeIVRangeFrom And Taxable_Income_IrTRegular2 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular2 > 0)) Then
    '            If (Taxable_Income_IrTRegular2 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular2 = Taxable_Income_IrTRegular2 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular2R4 = Taxable_Income_IrTRegular2 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R4 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular3 >= GradeIVRangeFrom And Taxable_Income_IrTRegular3 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular3 > 0)) Then
    '            If (Taxable_Income_IrTRegular3 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular3 = Taxable_Income_IrTRegular3 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular3R4 = Taxable_Income_IrTRegular3 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R4 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular4 >= GradeIVRangeFrom And Taxable_Income_IrTRegular4 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular4 > 0)) Then
    '            If (Taxable_Income_IrTRegular4 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular4 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular4R4 = Taxable_Income_IrTRegular4 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R4 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular5 >= GradeIVRangeFrom And Taxable_Income_IrTRegular5 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular5 > 0)) Then
    '            If (Taxable_Income_IrTRegular5 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular5 = Taxable_Income_IrTRegular5 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular5R4 = Taxable_Income_IrTRegular5 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R4 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular6 >= GradeIVRangeFrom And Taxable_Income_IrTRegular6 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular6 > 0)) Then
    '            If (Taxable_Income_IrTRegular6 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular6 = Taxable_Income_IrTRegular6 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular6R4 = Taxable_Income_IrTRegular6 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R4 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular7 >= GradeIVRangeFrom And Taxable_Income_IrTRegular7 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular7 > 0)) Then
    '            If (Taxable_Income_IrTRegular7 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular7 = Taxable_Income_IrTRegular7 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular7R4 = Taxable_Income_IrTRegular7 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R4 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular8 >= GradeIVRangeFrom And Taxable_Income_IrTRegular8 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular8 > 0)) Then
    '            If (Taxable_Income_IrTRegular8 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular8 = Taxable_Income_IrTRegular8 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular8R4 = Taxable_Income_IrTRegular8 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R4 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular9 >= GradeIVRangeFrom And Taxable_Income_IrTRegular9 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular9 > 0)) Then
    '            If (Taxable_Income_IrTRegular9 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular9 = Taxable_Income_IrTRegular9 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular9R4 = Taxable_Income_IrTRegular9 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R4 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeIV / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular10 >= GradeIVRangeFrom And Taxable_Income_IrTRegular10 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular10 > 0)) Then
    '            If (Taxable_Income_IrTRegular10 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular10 = Taxable_Income_IrTRegular10 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular10R4 = Taxable_Income_IrTRegular10 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R4 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeIV / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular11 >= GradeIVRangeFrom And Taxable_Income_IrTRegular11 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular11 > 0)) Then
    '            If (Taxable_Income_IrTRegular11 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular11 = Taxable_Income_IrTRegular11 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular11R4 = Taxable_Income_IrTRegular11 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R4 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeIV / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular12 >= GradeIVRangeFrom And Taxable_Income_IrTRegular12 <= GradeIVRangeTo) Or (Taxable_Income_IrTRegular12 > 0)) Then
    '            If (Taxable_Income_IrTRegular12 - GradeIVRangeTo) > 0 Then
    '                Taxable_Income_IrTRegular12 = Taxable_Income_IrTRegular12 - GradeIVRangeTo
    '                CheckRollTaxPPT.PPH_21_IRRegular12R4 = Taxable_Income_IrTRegular12 * (GradeIV / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R4 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeIV / 100)
    '            End If
    '        End If





    '        If (Taxable_Income_IrTRegular1 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular1R5 = Taxable_Income_IrTRegular1 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular2 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular2R5 = Taxable_Income_IrTRegular2 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular3 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular3R5 = Taxable_Income_IrTRegular3 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular4 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular4R5 = Taxable_Income_IrTRegular4 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular5 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular5R5 = Taxable_Income_IrTRegular5 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular6 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular6R5 = Taxable_Income_IrTRegular6 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular7 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular7R5 = Taxable_Income_IrTRegular7 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular8 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular8R5 = Taxable_Income_IrTRegular8 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular9 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular9R5 = Taxable_Income_IrTRegular9 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular10 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular10R5 = Taxable_Income_IrTRegular10 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular11 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular11R5 = Taxable_Income_IrTRegular11 * (GradeV / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular12 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular12R5 = Taxable_Income_IrTRegular12 * (GradeV / 100)


    '        End If








    '    Else


    '        If (CheckRollTaxPPT.Taxable_Income_Irregular1 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular1 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular1 <> 0 Then

    '            If (CheckRollTaxPPT.Taxable_Income_Irregular1 - GradeIRangeNPWP) > 0 Then

    '                Taxable_Income_IrTRegular1 = CheckRollTaxPPT.Taxable_Income_Irregular1 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular1R1 = Taxable_Income_IrTRegular1 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R1 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeINPWP / 100)
    '            End If
    '        End If


    '        If (CheckRollTaxPPT.Taxable_Income_Irregular2 = GradeIRangeNPWP Or Taxable_Income_Irregular2 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular2 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular2 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular2 = CheckRollTaxPPT.Taxable_Income_Irregular2 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular2R1 = Taxable_Income_IrTRegular2 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R1 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular3 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular3 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular3 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular3 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular3 = CheckRollTaxPPT.Taxable_Income_Irregular3 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular3R1 = Taxable_Income_IrTRegular3 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R1 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular4 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular4 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular4 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular4 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular4 = CheckRollTaxPPT.Taxable_Income_Irregular4 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular4R1 = Taxable_Income_IrTRegular4 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R1 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular5 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular5 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular5 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular5 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular5 = CheckRollTaxPPT.Taxable_Income_Irregular5 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular5R1 = Taxable_Income_IrTRegular5 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R1 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular6 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular6 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular6 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular6 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular6 = CheckRollTaxPPT.Taxable_Income_Irregular6 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular6R1 = Taxable_Income_IrTRegular6 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R1 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular7 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular7 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular7 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular7 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular7 = CheckRollTaxPPT.Taxable_Income_Irregular7 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular7R1 = Taxable_Income_IrTRegular7 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R1 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular8 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular8 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular8 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular8 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular8 = CheckRollTaxPPT.Taxable_Income_Irregular8 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular8R1 = Taxable_Income_IrTRegular8 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R1 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular9 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular9 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular9 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular9 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular9 = CheckRollTaxPPT.Taxable_Income_Irregular9 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular9R1 = Taxable_Income_IrTRegular9 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R1 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular10 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular10 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular10 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular10 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular10 = CheckRollTaxPPT.Taxable_Income_Irregular10 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular10R1 = Taxable_Income_IrTRegular10 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R1 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular11 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular11 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular11 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular11 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular1 = CheckRollTaxPPT.Taxable_Income_Irregular11 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular11R1 = Taxable_Income_IrTRegular11 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R1 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeINPWP / 100)
    '            End If
    '        End If

    '        If (CheckRollTaxPPT.Taxable_Income_Irregular12 <= GradeIRangeNPWP Or CheckRollTaxPPT.Taxable_Income_Irregular12 >= GradeIRangeNPWP) And CheckRollTaxPPT.Taxable_Income_Irregular12 <> 0 Then
    '            If (CheckRollTaxPPT.Taxable_Income_Irregular12 - GradeIRangeNPWP) > 0 Then
    '                Taxable_Income_IrTRegular12 = CheckRollTaxPPT.Taxable_Income_Irregular12 - GradeIRangeNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular12R1 = Taxable_Income_IrTRegular12 * (GradeINPWP / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R1 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeINPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular1 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular1 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular1 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIIRangeToNPWP) > 0 Then

    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular1 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular1R2 = Taxable_Income_IrTRegular1 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R2 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeIINPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular2 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular2 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular2 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular2 = Taxable_Income_IrTRegular2 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular2R2 = Taxable_Income_IrTRegular2 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R2 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeIINPWP / 100)
    '            End If
    '        End If
    '        If ((Taxable_Income_IrTRegular3 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular3 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular3 > 0)) Then
    '            If (Taxable_Income_IrTRegular3 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular3 = Taxable_Income_IrTRegular3 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular3R2 = Taxable_Income_IrTRegular3 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R2 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular4 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular4 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular4 > 0)) Then
    '            If (Taxable_Income_IrTRegular4 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular4 = Taxable_Income_IrTRegular4 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular4R2 = Taxable_Income_IrTRegular4 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R2 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular5 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular5 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular5 > 0)) Then
    '            If (Taxable_Income_IrTRegular5 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular5 = Taxable_Income_IrTRegular5 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular5R2 = Taxable_Income_IrTRegular5 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R2 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular6 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular6 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular6 > 0)) Then
    '            If (Taxable_Income_IrTRegular6 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular6 = Taxable_Income_IrTRegular6 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular6R2 = Taxable_Income_IrTRegular6 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R2 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular7 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular7 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular7 > 0)) Then
    '            If (Taxable_Income_IrTRegular7 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular7 = Taxable_Income_IrTRegular7 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular7R2 = Taxable_Income_IrTRegular7 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R2 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular8 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular8 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular8 > 0)) Then
    '            If (Taxable_Income_IrTRegular8 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular8 = Taxable_Income_IrTRegular8 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular8R2 = Taxable_Income_IrTRegular8 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R2 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular9 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular9 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular9 > 0)) Then
    '            If (Taxable_Income_IrTRegular9 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular9 = Taxable_Income_IrTRegular10 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular9R2 = Taxable_Income_IrTRegular9 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R2 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular10 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular10 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular10 > 0)) Then
    '            If (Taxable_Income_IrTRegular10 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular10 = Taxable_Income_IrTRegular10 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular10R2 = Taxable_Income_IrTRegular10 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R2 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular11 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular11 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular11 > 0)) Then

    '            If (Taxable_Income_IrTRegular11 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular11 = Taxable_Income_IrTRegular11 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular11R2 = Taxable_Income_IrTRegular11 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R2 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular12 >= GradeIIRangeFromNPWP And Taxable_Income_IrTRegular12 <= GradeIIRangeToNPWP) Or (Taxable_Income_IrTRegular12 > 0)) Then
    '            If (Taxable_Income_IrTRegular12 - GradeIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular12 = Taxable_Income_IrTRegular12 - GradeIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular12R2 = Taxable_Income_IrTRegular12 * (GradeIINPWP / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R2 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeIINPWP / 100)
    '            End If
    '        End If





    '        If ((Taxable_Income_IrTRegular1 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular1 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular1 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular1 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular1R3 = Taxable_Income_IrTRegular1 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R3 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular2 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular2 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular2 > 0)) Then
    '            If (Taxable_Income_IrTRegular2 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular2 = Taxable_Income_IrTRegular2 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular2R3 = Taxable_Income_IrTRegular1 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R3 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeIIINPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular3 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular3 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular3 > 0)) Then
    '            If (Taxable_Income_IrTRegular3 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular3 = Taxable_Income_IrTRegular3 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular3R3 = Taxable_Income_IrTRegular3 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R3 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular4 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular4 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular4 > 0)) Then
    '            If (Taxable_Income_IrTRegular4 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular4 = Taxable_Income_IrTRegular4 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular4R3 = Taxable_Income_IrTRegular4 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R3 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular5 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular5 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular5 > 0)) Then
    '            If (Taxable_Income_IrTRegular5 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular5 = Taxable_Income_IrTRegular5 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular5R3 = Taxable_Income_IrTRegular5 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R3 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular6 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular6 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular6 > 0)) Then
    '            If (Taxable_Income_IrTRegular6 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular6 = Taxable_Income_IrTRegular6 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular6R3 = Taxable_Income_IrTRegular6 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R3 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular7 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular7 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular7 > 0)) Then
    '            If (Taxable_Income_IrTRegular7 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular7 = Taxable_Income_IrTRegular7 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular7R3 = Taxable_Income_IrTRegular7 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R3 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular8 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular8 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular8 > 0)) Then
    '            If (Taxable_Income_IrTRegular8 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular8 = Taxable_Income_IrTRegular8 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular8R3 = Taxable_Income_IrTRegular8 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R3 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular9 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular9 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular9 > 0)) Then
    '            If (Taxable_Income_IrTRegular9 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular9 = Taxable_Income_IrTRegular9 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular9R3 = Taxable_Income_IrTRegular9 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R3 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular10 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular10 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular10 > 0)) Then
    '            If (Taxable_Income_IrTRegular10 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular10 = Taxable_Income_IrTRegular10 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular10R3 = Taxable_Income_IrTRegular10 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R3 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular11 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular11 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular11 > 0)) Then
    '            If (Taxable_Income_IrTRegular11 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular11 = Taxable_Income_IrTRegular11 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular11R3 = Taxable_Income_IrTRegular11 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R3 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeIIINPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular12 >= GradeIIIRangeFromNPWP And Taxable_Income_IrTRegular12 <= GradeIIIRangeToNPWP) Or (Taxable_Income_IrTRegular12 > 0)) Then
    '            If (Taxable_Income_IrTRegular12 - GradeIIIRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular12 = Taxable_Income_IrTRegular12 - GradeIIIRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular12R3 = Taxable_Income_IrTRegular12 * (GradeIIINPWP / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R3 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeIIINPWP / 100)
    '            End If
    '        End If


    '        If ((Taxable_Income_IrTRegular1 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular1 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular1 > 0)) Then
    '            If (Taxable_Income_IrTRegular1 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular1 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular1R4 = Taxable_Income_IrTRegular1 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular1 > 0 Then

    '                    Taxable_Income_IrTRegular1 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular1R4 = CheckRollTaxPPT.Taxable_Income_Irregular1 * (GradeIVNPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular2 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular2 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular2 > 0)) Then
    '            If (Taxable_Income_IrTRegular2 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular2 = Taxable_Income_IrTRegular2 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular2R4 = Taxable_Income_IrTRegular2 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular2 > 0 Then

    '                    Taxable_Income_IrTRegular2 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular2R4 = CheckRollTaxPPT.Taxable_Income_Irregular2 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular3 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular3 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular3 > 0)) Then
    '            If (Taxable_Income_IrTRegular3 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular3 = Taxable_Income_IrTRegular3 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular3R4 = Taxable_Income_IrTRegular3 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular3 > 0 Then

    '                    Taxable_Income_IrTRegular3 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular3R4 = CheckRollTaxPPT.Taxable_Income_Irregular3 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular4 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular4 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular4 > 0)) Then
    '            If (Taxable_Income_IrTRegular4 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular1 = Taxable_Income_IrTRegular4 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular4R4 = Taxable_Income_IrTRegular4 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular4 > 0 Then

    '                    Taxable_Income_IrTRegular4 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular4R4 = CheckRollTaxPPT.Taxable_Income_Irregular4 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular5 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular5 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular5 > 0)) Then
    '            If (Taxable_Income_IrTRegular5 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular5 = Taxable_Income_IrTRegular5 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular5R4 = Taxable_Income_IrTRegular5 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular5 > 0 Then

    '                    Taxable_Income_IrTRegular5 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular5R4 = CheckRollTaxPPT.Taxable_Income_Irregular5 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular6 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular6 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular6 > 0)) Then
    '            If (Taxable_Income_IrTRegular6 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular6 = Taxable_Income_IrTRegular6 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular6R4 = Taxable_Income_IrTRegular6 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular6 > 0 Then

    '                    Taxable_Income_IrTRegular6 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular6R4 = CheckRollTaxPPT.Taxable_Income_Irregular6 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular7 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular7 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular7 > 0)) Then
    '            If (Taxable_Income_IrTRegular7 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular7 = Taxable_Income_IrTRegular7 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular7R4 = Taxable_Income_IrTRegular7 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular7 > 0 Then

    '                    Taxable_Income_IrTRegular7 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular7R4 = CheckRollTaxPPT.Taxable_Income_Irregular7 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular8 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular8 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular8 > 0)) Then
    '            If (Taxable_Income_IrTRegular8 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular8 = Taxable_Income_IrTRegular8 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular8R4 = Taxable_Income_IrTRegular8 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular8 > 0 Then

    '                    Taxable_Income_IrTRegular8 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular8R4 = CheckRollTaxPPT.Taxable_Income_Irregular8 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular9 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular9 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular9 > 0)) Then
    '            If (Taxable_Income_IrTRegular9 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular9 = Taxable_Income_IrTRegular9 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular9R4 = Taxable_Income_IrTRegular9 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular9 > 0 Then

    '                    Taxable_Income_IrTRegular9 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular9R4 = CheckRollTaxPPT.Taxable_Income_Irregular9 * (GradeIVNPWP / 100)
    '            End If
    '        End If



    '        If ((Taxable_Income_IrTRegular10 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular10 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular10 > 0)) Then
    '            If (Taxable_Income_IrTRegular10 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular10 = Taxable_Income_IrTRegular10 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular10R4 = Taxable_Income_IrTRegular10 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular10 > 0 Then

    '                    Taxable_Income_IrTRegular10 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular10R4 = CheckRollTaxPPT.Taxable_Income_Irregular10 * (GradeIVNPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular11 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular11 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular11 > 0)) Then
    '            If (Taxable_Income_IrTRegular11 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular11 = Taxable_Income_IrTRegular11 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular11R4 = Taxable_Income_IrTRegular11 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular11 > 0 Then

    '                    Taxable_Income_IrTRegular11 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular11R4 = CheckRollTaxPPT.Taxable_Income_Irregular11 * (GradeIVNPWP / 100)
    '            End If
    '        End If

    '        If ((Taxable_Income_IrTRegular12 >= GradeIVRangeFromNPWP And Taxable_Income_IrTRegular12 <= GradeIVRangeToNPWP) Or (Taxable_Income_IrTRegular12 > 0)) Then
    '            If (Taxable_Income_IrTRegular12 - GradeIVRangeToNPWP) > 0 Then
    '                Taxable_Income_IrTRegular12 = Taxable_Income_IrTRegular12 - GradeIVRangeToNPWP
    '                CheckRollTaxPPT.PPH_21_IRRegular12R4 = Taxable_Income_IrTRegular12 * (GradeIVNPWP / 100)
    '                If Taxable_Income_IrTRegular12 > 0 Then

    '                    Taxable_Income_IrTRegular12 = 0
    '                End If
    '            Else
    '                CheckRollTaxPPT.PPH_21_IRRegular12R4 = CheckRollTaxPPT.Taxable_Income_Irregular12 * (GradeIVNPWP / 100)
    '            End If
    '        End If





    '        If (Taxable_Income_IrTRegular1 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular1R5 = Taxable_Income_IrTRegular1 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular2 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular2R5 = Taxable_Income_IrTRegular2 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular3 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular3R5 = Taxable_Income_IrTRegular3 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular4 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular4R5 = Taxable_Income_IrTRegular4 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular5 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular5R5 = Taxable_Income_IrTRegular5 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular6 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular6R5 = Taxable_Income_IrTRegular6 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular7 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular7R5 = Taxable_Income_IrTRegular7 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular8 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular8R5 = Taxable_Income_IrTRegular8 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular9 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular9R5 = Taxable_Income_IrTRegular9 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular10 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular10R5 = Taxable_Income_IrTRegular10 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular11 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular11R5 = Taxable_Income_IrTRegular11 * (GradeVNPWP / 100)


    '        End If


    '        If (Taxable_Income_IrTRegular12 > 0) Then

    '            CheckRollTaxPPT.PPH_21_IRRegular12R5 = Taxable_Income_IrTRegular12 * (GradeVNPWP / 100)


    '        End If
    '    End If





    'End Sub
    ''#####################################################



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        ' Kamis, 7 Jan 2010, 13:24
        Me.Close()
    End Sub
End Class
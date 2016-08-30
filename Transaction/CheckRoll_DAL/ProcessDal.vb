'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 3 Sep 2009, 13:20
' Place     : Kuala Lumpur  
'
'Imports CheckRoll_PPT
'modified by nelson july 2010

Imports System.Data.SqlClient
Imports System.Configuration
Imports Common_DAL
Imports Common_PPT
Imports CheckRoll_PPT
Imports System.Windows.Forms

Public Class ProcessDal
    Public Shared Sub UpLoadSalary(ByVal SalaryProcDate As Date)
        ' by Dadang Adi
        ' Sabtu, 13 Mar 2010, 12:54
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter

        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
            params(4) = New SqlParameter("@SalaryProcDate", SalaryProcDate)
            objdb.ExecNonQuery("[Checkroll].[UpLoadSalary]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try

    End Sub

    Public Function GetFYearDate(ByVal IntMonth As Integer, ByVal IntYear As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@AMonth", IntMonth)
        Parms(1) = New SqlParameter("@AYear ", IntYear)
        'Parms(3) = New SqlParameter("@ModID", 3)

        ds = objdb.ExecQuery("[Checkroll].[FYearDateSelect]", Parms)
        Return ds
    End Function

    Public Shared Function InsertSalaryOT() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        dt = objdb.ExecQuery("[Checkroll].[InsertSalaryOT]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function ActivityDistributeExists() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        dt = objdb.ExecQuery("[Checkroll].[ActivityDistributeExists]", params).Tables(0)
        Return dt
    End Function
    'added by stanley@08-12-2011
    Public Shared Function AttendanceHarvNoReceiptionExists() As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@FromDT", GlobalPPT.FiscalYearFromDate)
        params(3) = New SqlParameter("@ToDT", GlobalPPT.FiscalYearToDate)
        dt = objdb.ExecQuery("[Checkroll].[AttendanceHarvNoReceiptionExists]", params).Tables(0)
        Return dt
    End Function
    'added by nelson
    Public Shared Function GetGradeRange() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@Empid", GlobalPPT.Empid)
        dt = objdb.ExecQuery("[Checkroll].[GetGradeRange]", params).Tables(0)
        Return dt
    End Function
    'added by nelson
    Public Shared Function GetActiveEmployee() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@Act_Mnth", GlobalPPT.IntActiveMonth)
        params(2) = New SqlParameter("@Act_Year", GlobalPPT.intActiveYear)

        dt = objdb.ExecQuery("[Checkroll].[GetActiveEmployee]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function GetActiveEmployee2() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@FrDate", GlobalPPT.FiscalYearFromDate)
        params(2) = New SqlParameter("@ToDate", GlobalPPT.FiscalYearToDate)

        dt = objdb.ExecQuery("[Checkroll].[GetActiveEmployee2]", params).Tables(0)
        Return dt
    End Function


    'added by nelson 
    Public Shared Function GetDedTaxOfEmployee() As DataTable
        Dim objdb As New SQLHelp
        Dim params(147) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@NPWP", CheckRollTaxPPT.NPWP)
        params(1) = New SqlParameter("@ActiveMonth", GlobalPPT.IntActiveMonth)
        params(2) = New SqlParameter("@year", GlobalPPT.intLoginYear)
        params(3) = New SqlParameter("@EmpCode", CheckRollTaxPPT.EmpCode)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        params(5) = New SqlParameter("@PPH_21_IRRegular1R1", CheckRollTaxPPT.PPH_21_IRRegular1R1)
        params(6) = New SqlParameter("@PPH_21_IRRegular2R1", CheckRollTaxPPT.PPH_21_IRRegular2R1)
        params(7) = New SqlParameter("@PPH_21_IRRegular3R1", CheckRollTaxPPT.PPH_21_IRRegular3R1)
        params(8) = New SqlParameter("@PPH_21_IRRegular4R1", CheckRollTaxPPT.PPH_21_IRRegular4R1)
        params(9) = New SqlParameter("@PPH_21_IRRegular5R1", CheckRollTaxPPT.PPH_21_IRRegular5R1)
        params(10) = New SqlParameter("@PPH_21_IRRegular6R1", CheckRollTaxPPT.PPH_21_IRRegular6R1)
        params(11) = New SqlParameter("@PPH_21_IRRegular7R1", CheckRollTaxPPT.PPH_21_IRRegular7R1)
        params(12) = New SqlParameter("@PPH_21_IRRegular8R1", CheckRollTaxPPT.PPH_21_IRRegular8R1)
        params(13) = New SqlParameter("@PPH_21_IRRegular9R1", CheckRollTaxPPT.PPH_21_IRRegular9R1)
        params(14) = New SqlParameter("@PPH_21_IRRegular10R1", CheckRollTaxPPT.PPH_21_IRRegular10R1)
        params(15) = New SqlParameter("@PPH_21_IRRegular11R1", CheckRollTaxPPT.PPH_21_IRRegular11R1)
        params(16) = New SqlParameter("@PPH_21_IRRegular12R1", CheckRollTaxPPT.PPH_21_IRRegular12R1)

        params(17) = New SqlParameter("@PPH_21_IRRegular1R2", CheckRollTaxPPT.PPH_21_IRRegular1R2)
        params(18) = New SqlParameter("@PPH_21_IRRegular2R2", CheckRollTaxPPT.PPH_21_IRRegular2R2)
        params(19) = New SqlParameter("@PPH_21_IRRegular3R2", CheckRollTaxPPT.PPH_21_IRRegular3R2)
        params(20) = New SqlParameter("@PPH_21_IRRegular4R2", CheckRollTaxPPT.PPH_21_IRRegular4R2)
        params(21) = New SqlParameter("@PPH_21_IRRegular5R2", CheckRollTaxPPT.PPH_21_IRRegular5R2)
        params(22) = New SqlParameter("@PPH_21_IRRegular6R2", CheckRollTaxPPT.PPH_21_IRRegular6R2)
        params(23) = New SqlParameter("@PPH_21_IRRegular7R2", CheckRollTaxPPT.PPH_21_IRRegular7R2)
        params(24) = New SqlParameter("@PPH_21_IRRegular8R2", CheckRollTaxPPT.PPH_21_IRRegular8R2)
        params(25) = New SqlParameter("@PPH_21_IRRegular9R2", CheckRollTaxPPT.PPH_21_IRRegular9R2)
        params(26) = New SqlParameter("@PPH_21_IRRegular10R2", CheckRollTaxPPT.PPH_21_IRRegular10R2)
        params(27) = New SqlParameter("@PPH_21_IRRegular11R2", CheckRollTaxPPT.PPH_21_IRRegular11R2)
        params(28) = New SqlParameter("@PPH_21_IRRegular12R2", CheckRollTaxPPT.PPH_21_IRRegular12R2)

        params(29) = New SqlParameter("@PPH_21_IRRegular1R3", CheckRollTaxPPT.PPH_21_IRRegular1R3)
        params(30) = New SqlParameter("@PPH_21_IRRegular2R3", CheckRollTaxPPT.PPH_21_IRRegular2R3)
        params(31) = New SqlParameter("@PPH_21_IRRegular3R3", CheckRollTaxPPT.PPH_21_IRRegular3R3)
        params(32) = New SqlParameter("@PPH_21_IRRegular4R3", CheckRollTaxPPT.PPH_21_IRRegular4R3)
        params(33) = New SqlParameter("@PPH_21_IRRegular5R3", CheckRollTaxPPT.PPH_21_IRRegular5R3)
        params(34) = New SqlParameter("@PPH_21_IRRegular6R3", CheckRollTaxPPT.PPH_21_IRRegular6R3)
        params(35) = New SqlParameter("@PPH_21_IRRegular7R3", CheckRollTaxPPT.PPH_21_IRRegular7R3)
        params(36) = New SqlParameter("@PPH_21_IRRegular8R3", CheckRollTaxPPT.PPH_21_IRRegular8R3)
        params(37) = New SqlParameter("@PPH_21_IRRegular9R3", CheckRollTaxPPT.PPH_21_IRRegular9R3)
        params(38) = New SqlParameter("@PPH_21_IRRegular10R3", CheckRollTaxPPT.PPH_21_IRRegular10R3)
        params(39) = New SqlParameter("@PPH_21_IRRegular11R3", CheckRollTaxPPT.PPH_21_IRRegular11R3)
        params(40) = New SqlParameter("@PPH_21_IRRegular12R3", CheckRollTaxPPT.PPH_21_IRRegular12R3)

        params(41) = New SqlParameter("@PPH_21_IRRegular1R4", CheckRollTaxPPT.PPH_21_IRRegular1R4)
        params(42) = New SqlParameter("@PPH_21_IRRegular2R4", CheckRollTaxPPT.PPH_21_IRRegular2R4)
        params(43) = New SqlParameter("@PPH_21_IRRegular3R4", CheckRollTaxPPT.PPH_21_IRRegular3R4)
        params(44) = New SqlParameter("@PPH_21_IRRegular4R4", CheckRollTaxPPT.PPH_21_IRRegular4R4)
        params(45) = New SqlParameter("@PPH_21_IRRegular5R4", CheckRollTaxPPT.PPH_21_IRRegular5R4)
        params(46) = New SqlParameter("@PPH_21_IRRegular6R4", CheckRollTaxPPT.PPH_21_IRRegular6R4)
        params(47) = New SqlParameter("@PPH_21_IRRegular7R4", CheckRollTaxPPT.PPH_21_IRRegular7R4)
        params(48) = New SqlParameter("@PPH_21_IRRegular8R4", CheckRollTaxPPT.PPH_21_IRRegular8R4)
        params(49) = New SqlParameter("@PPH_21_IRRegular9R4", CheckRollTaxPPT.PPH_21_IRRegular9R4)
        params(50) = New SqlParameter("@PPH_21_IRRegular10R4", CheckRollTaxPPT.PPH_21_IRRegular10R4)
        params(51) = New SqlParameter("@PPH_21_IRRegular11R4", CheckRollTaxPPT.PPH_21_IRRegular11R4)
        params(52) = New SqlParameter("@PPH_21_IRRegular12R4", CheckRollTaxPPT.PPH_21_IRRegular12R4)

        params(53) = New SqlParameter("@DedAdvance", CheckRollTaxPPT.DedAdvance)
        params(54) = New SqlParameter("@DedOther", CheckRollTaxPPT.DedOther)
        params(55) = New SqlParameter("@TotalBruto", CheckRollTaxPPT.TotalBruto)
        params(56) = New SqlParameter("@THR", CheckRollTaxPPT.THR)
        params(57) = New SqlParameter("@DedTaxCompany", CheckRollTaxPPT.DedTaxCompany)
        params(58) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(59) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(60) = New SqlParameter("@EmpID", GlobalPPT.Empid)

        params(61) = New SqlParameter("@ActiveMonthYearID1", CheckRollTaxPPT.ActiveMonthYearID1)
        params(62) = New SqlParameter("@ActiveMonthYearID2", CheckRollTaxPPT.ActiveMonthYearID2)
        params(63) = New SqlParameter("@ActiveMonthYearID3", CheckRollTaxPPT.ActiveMonthYearID3)
        params(64) = New SqlParameter("@ActiveMonthYearID4", CheckRollTaxPPT.ActiveMonthYearID4)
        params(65) = New SqlParameter("@ActiveMonthYearID5", CheckRollTaxPPT.ActiveMonthYearID5)
        params(66) = New SqlParameter("@ActiveMonthYearID6", CheckRollTaxPPT.ActiveMonthYearID6)
        params(67) = New SqlParameter("@ActiveMonthYearID7", CheckRollTaxPPT.ActiveMonthYearID7)
        params(68) = New SqlParameter("@ActiveMonthYearID8", CheckRollTaxPPT.ActiveMonthYearID8)
        params(69) = New SqlParameter("@ActiveMonthYearID9", CheckRollTaxPPT.ActiveMonthYearID9)
        params(70) = New SqlParameter("@ActiveMonthYearID10", CheckRollTaxPPT.ActiveMonthYearID10)
        params(71) = New SqlParameter("@ActiveMonthYearID11", CheckRollTaxPPT.ActiveMonthYearID11)
        params(72) = New SqlParameter("@ActiveMonthYearID12", CheckRollTaxPPT.ActiveMonthYearID12)


        params(73) = New SqlParameter("@PPH_21_IRRegular1R5", CheckRollTaxPPT.PPH_21_IRRegular1R5)
        params(74) = New SqlParameter("@PPH_21_IRRegular2R5", CheckRollTaxPPT.PPH_21_IRRegular2R5)
        params(75) = New SqlParameter("@PPH_21_IRRegular3R5", CheckRollTaxPPT.PPH_21_IRRegular3R5)
        params(76) = New SqlParameter("@PPH_21_IRRegular4R5", CheckRollTaxPPT.PPH_21_IRRegular4R5)
        params(77) = New SqlParameter("@PPH_21_IRRegular5R5", CheckRollTaxPPT.PPH_21_IRRegular5R5)
        params(78) = New SqlParameter("@PPH_21_IRRegular6R5", CheckRollTaxPPT.PPH_21_IRRegular6R5)
        params(79) = New SqlParameter("@PPH_21_IRRegular7R5", CheckRollTaxPPT.PPH_21_IRRegular7R5)
        params(80) = New SqlParameter("@PPH_21_IRRegular8R5", CheckRollTaxPPT.PPH_21_IRRegular8R5)
        params(81) = New SqlParameter("@PPH_21_IRRegular9R5", CheckRollTaxPPT.PPH_21_IRRegular9R5)
        params(82) = New SqlParameter("@PPH_21_IRRegular10R5", CheckRollTaxPPT.PPH_21_IRRegular10R5)
        params(83) = New SqlParameter("@PPH_21_IRRegular11R5", CheckRollTaxPPT.PPH_21_IRRegular11R5)
        params(84) = New SqlParameter("@PPH_21_IRRegular12R5", CheckRollTaxPPT.PPH_21_IRRegular12R5)

        params(85) = New SqlParameter("@PPH_21_Regular1R1", CheckRollTaxPPT.PPH_21_Regular1R1)
        params(86) = New SqlParameter("@PPH_21_Regular2R1", CheckRollTaxPPT.PPH_21_Regular2R1)
        params(87) = New SqlParameter("@PPH_21_Regular3R1", CheckRollTaxPPT.PPH_21_Regular3R1)
        params(88) = New SqlParameter("@PPH_21_Regular4R1", CheckRollTaxPPT.PPH_21_Regular4R1)
        params(89) = New SqlParameter("@PPH_21_Regular5R1", CheckRollTaxPPT.PPH_21_Regular5R1)
        params(90) = New SqlParameter("@PPH_21_Regular6R1", CheckRollTaxPPT.PPH_21_Regular6R1)
        params(91) = New SqlParameter("@PPH_21_Regular7R1", CheckRollTaxPPT.PPH_21_Regular7R1)
        params(92) = New SqlParameter("@PPH_21_Regular8R1", CheckRollTaxPPT.PPH_21_Regular8R1)
        params(93) = New SqlParameter("@PPH_21_Regular9R1", CheckRollTaxPPT.PPH_21_Regular9R1)
        params(94) = New SqlParameter("@PPH_21_Regular10R1", CheckRollTaxPPT.PPH_21_Regular10R1)
        params(95) = New SqlParameter("@PPH_21_Regular11R1", CheckRollTaxPPT.PPH_21_Regular11R1)
        params(96) = New SqlParameter("@PPH_21_Regular12R1", CheckRollTaxPPT.PPH_21_Regular12R1)

        params(97) = New SqlParameter("@PPH_21_Regular1R2", CheckRollTaxPPT.PPH_21_Regular1R2)
        params(98) = New SqlParameter("@PPH_21_Regular2R2", CheckRollTaxPPT.PPH_21_Regular2R2)
        params(99) = New SqlParameter("@PPH_21_Regular3R2", CheckRollTaxPPT.PPH_21_Regular3R2)
        params(100) = New SqlParameter("@PPH_21_Regular4R2", CheckRollTaxPPT.PPH_21_Regular4R2)
        params(101) = New SqlParameter("@PPH_21_Regular5R2", CheckRollTaxPPT.PPH_21_Regular5R2)
        params(102) = New SqlParameter("@PPH_21_Regular6R2", CheckRollTaxPPT.PPH_21_Regular6R2)
        params(103) = New SqlParameter("@PPH_21_Regular7R2", CheckRollTaxPPT.PPH_21_Regular7R2)
        params(104) = New SqlParameter("@PPH_21_Regular8R2", CheckRollTaxPPT.PPH_21_Regular8R2)
        params(105) = New SqlParameter("@PPH_21_Regular9R2", CheckRollTaxPPT.PPH_21_Regular9R2)
        params(106) = New SqlParameter("@PPH_21_Regular10R2", CheckRollTaxPPT.PPH_21_Regular10R2)
        params(107) = New SqlParameter("@PPH_21_Regular11R2", CheckRollTaxPPT.PPH_21_Regular11R2)
        params(108) = New SqlParameter("@PPH_21_Regular12R2", CheckRollTaxPPT.PPH_21_Regular12R2)

        params(109) = New SqlParameter("@PPH_21_Regular1R3", CheckRollTaxPPT.PPH_21_Regular1R3)
        params(110) = New SqlParameter("@PPH_21_Regular2R3", CheckRollTaxPPT.PPH_21_Regular2R3)
        params(111) = New SqlParameter("@PPH_21_Regular3R3", CheckRollTaxPPT.PPH_21_Regular3R3)
        params(112) = New SqlParameter("@PPH_21_Regular4R3", CheckRollTaxPPT.PPH_21_Regular4R3)
        params(113) = New SqlParameter("@PPH_21_Regular5R3", CheckRollTaxPPT.PPH_21_Regular5R3)
        params(114) = New SqlParameter("@PPH_21_Regular6R3", CheckRollTaxPPT.PPH_21_Regular6R3)
        params(115) = New SqlParameter("@PPH_21_Regular7R3", CheckRollTaxPPT.PPH_21_Regular7R3)
        params(116) = New SqlParameter("@PPH_21_Regular8R3", CheckRollTaxPPT.PPH_21_Regular8R3)
        params(117) = New SqlParameter("@PPH_21_Regular9R3", CheckRollTaxPPT.PPH_21_Regular9R3)
        params(118) = New SqlParameter("@PPH_21_Regular10R3", CheckRollTaxPPT.PPH_21_Regular10R3)
        params(119) = New SqlParameter("@PPH_21_Regular11R3", CheckRollTaxPPT.PPH_21_Regular11R3)
        params(120) = New SqlParameter("@PPH_21_Regular12R3", CheckRollTaxPPT.PPH_21_Regular12R3)

        params(121) = New SqlParameter("@PPH_21_Regular1R4", CheckRollTaxPPT.PPH_21_Regular1R4)
        params(122) = New SqlParameter("@PPH_21_Regular2R4", CheckRollTaxPPT.PPH_21_Regular2R4)
        params(123) = New SqlParameter("@PPH_21_Regular3R4", CheckRollTaxPPT.PPH_21_Regular3R4)
        params(124) = New SqlParameter("@PPH_21_Regular4R4", CheckRollTaxPPT.PPH_21_Regular4R4)
        params(125) = New SqlParameter("@PPH_21_Regular5R4", CheckRollTaxPPT.PPH_21_Regular5R4)
        params(126) = New SqlParameter("@PPH_21_Regular6R4", CheckRollTaxPPT.PPH_21_Regular6R4)
        params(127) = New SqlParameter("@PPH_21_Regular7R4", CheckRollTaxPPT.PPH_21_Regular7R4)
        params(128) = New SqlParameter("@PPH_21_Regular8R4", CheckRollTaxPPT.PPH_21_Regular8R4)
        params(129) = New SqlParameter("@PPH_21_Regular9R4", CheckRollTaxPPT.PPH_21_Regular9R4)
        params(130) = New SqlParameter("@PPH_21_Regular10R4", CheckRollTaxPPT.PPH_21_Regular10R4)
        params(131) = New SqlParameter("@PPH_21_Regular11R4", CheckRollTaxPPT.PPH_21_Regular11R4)
        params(132) = New SqlParameter("@PPH_21_Regular12R4", CheckRollTaxPPT.PPH_21_Regular12R4)


        params(133) = New SqlParameter("@PPH_21_Regular1R5", CheckRollTaxPPT.PPH_21_Regular1R5)
        params(134) = New SqlParameter("@PPH_21_Regular2R5", CheckRollTaxPPT.PPH_21_Regular2R5)
        params(135) = New SqlParameter("@PPH_21_Regular3R5", CheckRollTaxPPT.PPH_21_Regular3R5)
        params(136) = New SqlParameter("@PPH_21_Regular4R5", CheckRollTaxPPT.PPH_21_Regular4R5)
        params(137) = New SqlParameter("@PPH_21_Regular5R5", CheckRollTaxPPT.PPH_21_Regular5R5)
        params(138) = New SqlParameter("@PPH_21_Regular6R5", CheckRollTaxPPT.PPH_21_Regular6R5)
        params(139) = New SqlParameter("@PPH_21_Regular7R5", CheckRollTaxPPT.PPH_21_Regular7R5)
        params(140) = New SqlParameter("@PPH_21_Regular8R5", CheckRollTaxPPT.PPH_21_Regular8R5)
        params(141) = New SqlParameter("@PPH_21_Regular9R5", CheckRollTaxPPT.PPH_21_Regular9R5)
        params(142) = New SqlParameter("@PPH_21_Regular10R5", CheckRollTaxPPT.PPH_21_Regular10R5)
        params(143) = New SqlParameter("@PPH_21_Regular11R5", CheckRollTaxPPT.PPH_21_Regular11R5)
        params(144) = New SqlParameter("@PPH_21_Regular12R5", CheckRollTaxPPT.PPH_21_Regular12R5)

        params(145) = New SqlParameter("@FunctionalAllowanceP", CheckRollTaxPPT.FunctionalAllowanceP)
        params(146) = New SqlParameter("@MaxAllowance", CheckRollTaxPPT.MaxAllowance)
        params(147) = New SqlParameter("@DedAstek", CheckRollTaxPPT.DedAstek)
        dt = objdb.ExecQuery("[Checkroll].[SalaryProcessing]", params).Tables(0)
        Return dt
    End Function

    'added by nelson
    Public Shared Function GetTaxIncome() As DataTable
        Dim objdb As New SQLHelp
        Dim params(88) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@PTKP", CheckRollTaxPPT.PTKP)
        params(1) = New SqlParameter("@HIPMonthlyRate", CheckRollTaxPPT.HIPMonthlyRate)
        params(2) = New SqlParameter("@Category", CheckRollTaxPPT.Category)
        params(3) = New SqlParameter("@JHTPercent", CheckRollTaxPPT.JHTPercent)
        params(4) = New SqlParameter("@Income_Regular1", CheckRollTaxPPT.Income_Regular1)
        params(5) = New SqlParameter("@Income_Regular2", CheckRollTaxPPT.Income_Regular2)
        params(6) = New SqlParameter("@Income_Regular3", CheckRollTaxPPT.Income_Regular3)
        params(7) = New SqlParameter("@Income_Regular4", CheckRollTaxPPT.Income_Regular4)
        params(8) = New SqlParameter("@Income_Regular5", CheckRollTaxPPT.Income_Regular5)
        params(9) = New SqlParameter("@Income_Regular6", CheckRollTaxPPT.Income_Regular6)
        params(10) = New SqlParameter("@Income_Regular7", CheckRollTaxPPT.Income_Regular7)
        params(11) = New SqlParameter("@Income_Regular8", CheckRollTaxPPT.Income_Regular8)
        params(12) = New SqlParameter("@Income_Regular9", CheckRollTaxPPT.Income_Regular9)
        params(13) = New SqlParameter("@Income_Regular10", CheckRollTaxPPT.Income_Regular10)
        params(14) = New SqlParameter("@Income_Regular11", CheckRollTaxPPT.Income_Regular11)
        params(15) = New SqlParameter("@Income_Regular12", CheckRollTaxPPT.Income_Regular12)
        params(16) = New SqlParameter("@Income_Irregular1", CheckRollTaxPPT.Income_Irregular1)
        params(17) = New SqlParameter("@Income_Irregular2", CheckRollTaxPPT.Income_Irregular2)
        params(18) = New SqlParameter("@Income_Irregular3", CheckRollTaxPPT.Income_Irregular3)
        params(19) = New SqlParameter("@Income_Irregular4", CheckRollTaxPPT.Income_Irregular4)
        params(20) = New SqlParameter("@Income_Irregular5", CheckRollTaxPPT.Income_Irregular5)
        params(21) = New SqlParameter("@Income_Irregular6", CheckRollTaxPPT.Income_Irregular6)
        params(22) = New SqlParameter("@Income_Irregular7", CheckRollTaxPPT.Income_Irregular7)
        params(23) = New SqlParameter("@Income_Irregular8", CheckRollTaxPPT.Income_Irregular8)
        params(24) = New SqlParameter("@Income_Irregular9", CheckRollTaxPPT.Income_Irregular9)
        params(25) = New SqlParameter("@Income_Irregular10", CheckRollTaxPPT.Income_Irregular10)
        params(26) = New SqlParameter("@Income_Irregular11", CheckRollTaxPPT.Income_Irregular11)
        params(27) = New SqlParameter("@Income_Irregular12", CheckRollTaxPPT.Income_Irregular12)
        params(28) = New SqlParameter("@Accident_Insurance1", CheckRollTaxPPT.Accident_Insurance1)
        params(29) = New SqlParameter("@Accident_Insurance2", CheckRollTaxPPT.Accident_Insurance2)
        params(30) = New SqlParameter("@Accident_Insurance3", CheckRollTaxPPT.Accident_Insurance3)
        params(31) = New SqlParameter("@Accident_Insurance4", CheckRollTaxPPT.Accident_Insurance4)
        params(32) = New SqlParameter("@Accident_Insurance6", CheckRollTaxPPT.Accident_Insurance6)
        params(33) = New SqlParameter("@Accident_Insurance7", CheckRollTaxPPT.Accident_Insurance7)
        params(34) = New SqlParameter("@Accident_Insurance8", CheckRollTaxPPT.Accident_Insurance8)
        params(35) = New SqlParameter("@Accident_Insurance9", CheckRollTaxPPT.Accident_Insurance9)
        params(36) = New SqlParameter("@Accident_Insurance10", CheckRollTaxPPT.Accident_Insurance10)
        params(37) = New SqlParameter("@Accident_Insurance11", CheckRollTaxPPT.Accident_Insurance11)
        params(38) = New SqlParameter("@Accident_Insurance12", CheckRollTaxPPT.Accident_Insurance12)
        params(39) = New SqlParameter("@ActiveMonth1Sal", CheckRollTaxPPT.ActiveMonth1Sal)
        params(40) = New SqlParameter("@ActiveMonth2Sal", CheckRollTaxPPT.ActiveMonth2Sal)
        params(41) = New SqlParameter("@ActiveMonth3Sal", CheckRollTaxPPT.ActiveMonth3Sal)
        params(42) = New SqlParameter("@ActiveMonth4Sal", CheckRollTaxPPT.ActiveMonth4Sal)
        params(43) = New SqlParameter("@ActiveMonth5Sal", CheckRollTaxPPT.ActiveMonth5Sal)
        params(44) = New SqlParameter("@ActiveMonth6Sal", CheckRollTaxPPT.ActiveMonth6Sal)
        params(45) = New SqlParameter("@ActiveMonth7Sal", CheckRollTaxPPT.ActiveMonth7Sal)
        params(46) = New SqlParameter("@ActiveMonth8Sal", CheckRollTaxPPT.ActiveMonth8Sal)
        params(47) = New SqlParameter("@ActiveMonth9Sal", CheckRollTaxPPT.ActiveMonth9Sal)
        params(48) = New SqlParameter("@ActiveMonth10Sal", CheckRollTaxPPT.ActiveMonth10Sal)
        params(49) = New SqlParameter("@ActiveMonth11Sal", CheckRollTaxPPT.ActiveMonth11Sal)
        params(50) = New SqlParameter("@ActiveMonth12Sal", CheckRollTaxPPT.ActiveMonth12Sal)
        params(51) = New SqlParameter("@ActiveMonth1Tax", CheckRollTaxPPT.ActiveMonth1Tax)
        params(52) = New SqlParameter("@ActiveMonth2Tax", CheckRollTaxPPT.ActiveMonth2Tax)
        params(53) = New SqlParameter("@ActiveMonth3Tax", CheckRollTaxPPT.ActiveMonth3Tax)
        params(54) = New SqlParameter("@ActiveMonth4Tax", CheckRollTaxPPT.ActiveMonth4Tax)
        params(55) = New SqlParameter("@ActiveMonth5Tax", CheckRollTaxPPT.ActiveMonth5Tax)
        params(56) = New SqlParameter("@ActiveMonth6Tax", CheckRollTaxPPT.ActiveMonth6Tax)
        params(57) = New SqlParameter("@ActiveMonth7Tax", CheckRollTaxPPT.ActiveMonth7Tax)
        params(58) = New SqlParameter("@ActiveMonth8Tax", CheckRollTaxPPT.ActiveMonth8Tax)
        params(59) = New SqlParameter("@ActiveMonth9Tax", CheckRollTaxPPT.ActiveMonth9Tax)
        params(60) = New SqlParameter("@ActiveMonth10Tax", CheckRollTaxPPT.ActiveMonth10Tax)
        params(61) = New SqlParameter("@ActiveMonth11Tax", CheckRollTaxPPT.ActiveMonth11Tax)
        params(62) = New SqlParameter("@ActiveMonth12Tax", CheckRollTaxPPT.ActiveMonth12Tax)
        params(63) = New SqlParameter("@ActiveMonth", GlobalPPT.IntActiveMonth)
        params(64) = New SqlParameter("@Accident_Insurance5", CheckRollTaxPPT.Accident_Insurance5)
        params(65) = New SqlParameter("@FunctionalAllowanceP", CheckRollTaxPPT.FunctionalAllowanceP)
        params(66) = New SqlParameter("@MaxAllowance", CheckRollTaxPPT.MaxAllowance)
        params(67) = New SqlParameter("@Status", CheckRollTaxTemp1PPT.Status)
        params(68) = New SqlParameter("@StatusDate", CheckRollTaxTemp1PPT.StatusDate)
        params(69) = New SqlParameter("@dDeductionCostMax", CheckRollTaxTemp1PPT.dDeductionCostMax)
        params(70) = New SqlParameter("@RiceDividerDays", CheckRollTaxTemp1PPT.RiceDividerDays)
        params(71) = New SqlParameter("@BasicRate", CheckRollTaxTemp1PPT.BasicRate)

        params(72) = New SqlParameter("@ActiveMonthYearID1", CheckRollTaxPPT.ActiveMonthYearID1)
        params(73) = New SqlParameter("@ActiveMonthYearID2", CheckRollTaxPPT.ActiveMonthYearID2)
        params(74) = New SqlParameter("@ActiveMonthYearID3", CheckRollTaxPPT.ActiveMonthYearID3)
        params(75) = New SqlParameter("@ActiveMonthYearID4", CheckRollTaxPPT.ActiveMonthYearID4)
        params(76) = New SqlParameter("@ActiveMonthYearID5", CheckRollTaxPPT.ActiveMonthYearID5)
        params(77) = New SqlParameter("@ActiveMonthYearID6", CheckRollTaxPPT.ActiveMonthYearID6)
        params(78) = New SqlParameter("@ActiveMonthYearID7", CheckRollTaxPPT.ActiveMonthYearID7)
        params(79) = New SqlParameter("@ActiveMonthYearID8", CheckRollTaxPPT.ActiveMonthYearID8)
        params(80) = New SqlParameter("@ActiveMonthYearID9", CheckRollTaxPPT.ActiveMonthYearID9)
        params(81) = New SqlParameter("@ActiveMonthYearID10", CheckRollTaxPPT.ActiveMonthYearID10)
        params(82) = New SqlParameter("@ActiveMonthYearID11", CheckRollTaxPPT.ActiveMonthYearID11)
        params(83) = New SqlParameter("@ActiveMonthYearID12", CheckRollTaxPPT.ActiveMonthYearID12)
        params(84) = New SqlParameter("@year", GlobalPPT.intLoginYear)
        params(85) = New SqlParameter("@EmpCode", CheckRollTaxPPT.EmpCode)
        params(86) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        params(87) = New SqlParameter("@EmpID", GlobalPPT.Empid)

        'Palani
        params(88) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)


        dt = objdb.ExecQuery("[Checkroll].[Taxable_Income]", params).Tables(0)
        Return dt
    End Function


    'added by nelson
    Public Shared Function GetMaritalStatusAndActMnth() As DataTable
        Dim objdb As New SQLHelp
        Dim params(7) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@ActiveMonth", GlobalPPT.IntActiveMonth)
        params(3) = New SqlParameter("@Year", GlobalPPT.intActiveYear)
        params(4) = New SqlParameter("@EmpId", GlobalPPT.Empid)
        params(5) = New SqlParameter("@Mandore", GlobalPPT.Mandore)
        params(6) = New SqlParameter("@WorkerType", GlobalPPT.WorkerType)
        params(7) = New SqlParameter("@EmpCode", GlobalPPT.EmpCode)

        dt = objdb.ExecQuery("[Checkroll].[GetMaritalStatusAndActMnth]", params).Tables(0)
        Return dt
    End Function


    Public Shared Function InsertSalaryPremi() As Integer
        ' by Dadang Adi H
        ' Sabtu, 20 Mar 2010, 14:47

        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim Hasil As Integer

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)

        Hasil = objdb.ExecNonQuery("[Checkroll].[InsertSalaryPremi]", params)

        Return Hasil
    End Function

    Public Shared Sub UpdateRateSetupAddConfigurable()
        ' by Chandra
        ' 01 06 2015

        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)

        objdb.ExecNonQuery("[Checkroll].[UpdateRateSetupAddConfigurable]", params)
    End Sub

    Public Shared Sub UpdateTotalBrutoAndDeduction()
        ' by Palani
        ' 12 Feb 2010

        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)

        objdb.ExecNonQuery("[Checkroll].[UpdateTotalBrutoAndDeduction]", params)
    End Sub

    Public Shared Sub InsertAllDedSalary(ByVal StartDate As Date, ByVal Enddates As Date)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter

        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        params(3) = New SqlParameter("@StartDate", StartDate)
        params(4) = New SqlParameter("@EndDates", Enddates)
        objdb.ExecQuery("[Checkroll].[InsertAllDedSalary]", params)

    End Sub

    Public Shared Sub InsertSalaryAdvance()
        ' by Dadang Adi
        ' Sabtu, 13 Mar 2010, 12:54
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        'Dim dt As New DataTable
        Try

            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@User", GlobalPPT.strUserName)

            objdb.ExecNonQuery("[Checkroll].[InsertSalaryAdvance]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")

        End Try

    End Sub

    Public Shared Function GradeMonthDetailsSelectAll(yearMonth As String) As DataTable
        Dim obj As New SQLHelp
        Dim param(0) As SqlParameter
        param(0) = New SqlParameter("@DateRubber", yearMonth)
        Return obj.ExecQuery("[Checkroll].[GradeMonthDetailsSelectAll]", param).Tables(0)
    End Function

    Public Shared Sub PremiSalaryUpdate(classes As String, dates As String, empId As String)
        Try
            Dim obj As New SQLHelp
            Dim param(3) As SqlParameter
            param(0) = New SqlParameter("@Class", classes)
            param(1) = New SqlParameter("@Date", dates)
            param(2) = New SqlParameter("@EmpId", empId)
            param(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            obj.ExecQuery("[Checkroll].[PremiSalaryUpdate]", param)
        Catch ex As Exception

        End Try        
    End Sub

    Public Shared Function InsertSalaryIncentive() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        dt = objdb.ExecQuery("[Checkroll].[InsertSalaryIncentive]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function InsertSalaryUpdate() As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        dt = objdb.ExecQuery("[Checkroll].[InsertSalaryUpdate]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function KTSalary() As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
        dt = objdb.ExecQuery("[Checkroll].[KTSalary]", params).Tables(0)
        Return dt
    End Function

    'Public Shared Function UpdateCheckrollSalary() As Integer
    '    ' By Dadang Adi H
    '    ' Kamis, 31 Dec 2009, 09:52
    '    ' Place : Kuala Lumpur
    '    Dim adapter As New SQLHelp()
    '    Dim params(2) As SqlParameter
    '    Dim retValue As Integer

    '    params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    params(2) = New SqlParameter("@User", GlobalPPT.strUserName)

    '    Try
    '        retValue = adapter.ExecNonQuery("[Checkroll].[UpdateCheckrollSalary]", params)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try


    '    Return retValue
    'End Function

    Public Function GetInterfaceYearDistribusiCR() As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", 1)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Checkroll].[DistribusiMonthYearGET]", Parms)
        Return ds
    End Function

    Public Function GetInterfaceYearPPH21CR(ByVal IntYear As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Year", IntYear)
        ds = objdb.ExecQuery("[Checkroll].[GetInterfaceYearPPH21CR]", Parms)
        Return ds
    End Function
    'stanley@15-12-2011
    Public Function GetInterfaceYearPPH21CR_SPT(ByVal IntYear As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Year", IntYear)
        ds = objdb.ExecQuery("[Checkroll].[GetInterfaceYearPPH21CR_SPT]", Parms)
        Return ds
    End Function

    Public Function GetSPTForYear(ByVal IntYear As Integer) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Year", IntYear)
        ds = objdb.ExecQuery("[Checkroll].[GetSPTForYear]", Parms)
        Return ds
    End Function

    Public Function GetActiveMonthYear() As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", 1)
        ds = objdb.ExecQuery("[General].[ActiveYearMonthGET]", Parms)
        Return ds
    End Function

    Public Function GetSPTSeqNo(ByVal IntYear As Integer, ByVal EmpId As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Year", IntYear)
        Parms(2) = New SqlParameter("@EmpId", EmpId)
        ds = objdb.ExecQuery("[Checkroll].[GetSPTSeqNo]", Parms)
        Return ds
    End Function

    Public Shared Sub ProcessOtherPayment()
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[OtherPaymentDetails]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub

    Public Shared Sub OnCostProcess()
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[OnCostProcess]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub

    Public Shared Sub OnCostProcessDet()
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[OnCostProcessDet]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub

    Public Shared Sub AnalyHarvestingCostInsert()
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Try
            params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(1) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(2) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[AnalyHarvestingCostInsert]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub
    Public Shared Sub AnalyRubberCostInsert()
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Try
            params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(1) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(2) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[AnalyRubberCostInsert]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub
    Public Shared Sub AttendSummaryWithTeamProcess()
        'by Stanley on 24-06-2011
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter

        Try
            params(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            params(3) = New SqlParameter("@User", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[AttendSummaryWithTeamProcess]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try

    End Sub

    Public Shared Sub PremiMonthEndProcess()
        'by Naxim on 23-05-2013
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter

        Try
            params(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[DailyReceptionBlkHKPremiValueUpdateProcessMonthEndProcess]", params)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try

    End Sub


    Public Shared Sub CheckrollJournalInsert()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(4) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(5) = New SqlParameter("@ModID", 1)
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Checkroll].[InsertCheckrollJournal]", Parms)
    End Sub

    Public Shared Sub SPT21Insert(ByVal IntYear As Integer, ByVal Empid As String, ByVal SeqNo As Integer)
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Try
            params(0) = New SqlParameter("@Year", IntYear)
            params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(2) = New SqlParameter("@EmpId", Empid)
            params(3) = New SqlParameter("@SeqNo", SeqNo)
            params(4) = New SqlParameter("@Createdby", GlobalPPT.strUserName)
            objdb.ExecNonQuery("[Checkroll].[SPT21Insert]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub

    Public Shared Sub SPT21Delete(ByVal IntYear As Integer)
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Try
            params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(1) = New SqlParameter("@Year", IntYear)
            objdb.ExecNonQuery("[Checkroll].[SPT21Delete]", params)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message")
        End Try
    End Sub

    Public Shared Sub WeighbridgeAllocatedWeightUpdate()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Weighbridge].[WBAllocatedWeightUpdate]", Parms)
    End Sub

    Public Shared Sub ProcessRiceValue()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objdb.ExecQuery("[Checkroll].[ProcessRiceValue]", Parms)
    End Sub


    Public Shared Sub TransferPieceRateToAllowance()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        objdb.ExecQuery("[Checkroll].[TransferPieceRateToAllowance]", Parms)
    End Sub

    Public Shared Sub TransferSalaryToAllowance()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        objdb.ExecQuery("[Checkroll].[TransferSalaryToAllowance]", Parms)
    End Sub


    Public Shared Sub CalculatePremiGudang()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        objdb.ExecQuery("[Checkroll].[CalculatePremiGudang]", Parms)
    End Sub

    Public Shared Sub PremiMandorBesar()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        objdb.ExecQuery("[Checkroll].[CalculatePremiMandorBesar]", Parms)
    End Sub
    Public Shared Sub TransferCheckrollToVehicleCharge()
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@User", GlobalPPT.strUserName)
        objdb.ExecQuery("[Checkroll].[TransferCheckrollToVehicleCharge]", Parms)
    End Sub


End Class

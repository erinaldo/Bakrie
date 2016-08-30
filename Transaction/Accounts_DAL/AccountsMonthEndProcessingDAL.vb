Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL
Public Class AccountsMonthEndProcessingDAL

    Public Shared Function TaskConfigTaskCheckGet() As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        ds = objdb.ExecQuery("[Store].[TaskConfigTaskCheckGet]", Parms)
        Return ds

    End Function

    Public Shared Function TaskMonitorGet() As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", "6")
        ds = objdb.ExecQuery("[General].[TaskMonitorGet]", Parms)

        Return ds
    End Function
    Public Shared Function AccountsTaskMonitorStatusCheck() As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActivemonthyearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Accounts].[AccountsTaskMonitorStatusCheck]", Parms)
        Return ds
    End Function






    Public Shared Function AccountsTaskMonitorINSERT() As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", "6")
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(3) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(5) = New SqlParameter("@CreatedON", Date.Today)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ActivemonthyearID", GlobalPPT.strActMthYearID)
        Parms(9) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Accounts].[AccountsMonthEndClosing]", Parms)

        Return ds
    End Function


    Public Shared Function CalculatePettyCashCF(ByVal CashReconDate As Date) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(3) = New SqlParameter("@ActivemonthyearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@CashReconDate", CashReconDate)
        ds = objdb.ExecQuery("[Accounts].[PettyCashCFCalculation]", Parms)

        Return ds
    End Function
    Public Shared Function PettyCashCFDate() As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)

        ds = objdb.ExecQuery("[Accounts].[PettyCashCFDate]", Parms)

        Return ds
    End Function
    Public Shared Function PettyCashCFCashReconDate(ByVal Month As Integer, ByVal Year As Integer) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AMonth", Month)
        Parms(2) = New SqlParameter("@AYear", Year)
       
        ds = objdb.ExecQuery("[Accounts].[PettyCashCFCashReconDate]", Parms)

        Return ds
    End Function

    '' For Accounts Ledger Report

    Public Shared Function LedgerReport(ByVal LedgerType As String, ByVal Modid As Integer) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AMonth", GlobalPPT.IntLoginMonth)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@LedgerType", LedgerType)
        Parms(4) = New SqlParameter("@Modid", Modid)
        ds = objdb.ExecQuery("[Accounts].[LedgerReport]", Parms)
        Return ds
    End Function

    Public Shared Function LedgerReportCheck(ByVal Modid As Integer) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AMonth", GlobalPPT.IntLoginMonth)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@Modid", Modid)
        ds = objdb.ExecQuery("[Accounts].[LedgerReportCheck]", Parms)
        Return ds
    End Function


End Class

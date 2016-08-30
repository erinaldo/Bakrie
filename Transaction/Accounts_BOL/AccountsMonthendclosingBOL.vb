Imports Accounts_DAL
Public Class AccountsMonthendclosingBOL


    Public Shared Function TaskConfigTaskCheckGet() As DataSet

        Return AccountsMonthEndProcessingDAL.TaskConfigTaskCheckGet()

    End Function

    Public Shared Function TaskMonitorGet() As DataSet

        Return AccountsMonthEndProcessingDAL.TaskMonitorGet()

    End Function

    Public Shared Function AccountsTaskMonitorINSERT() As DataSet

        Return AccountsMonthEndProcessingDAL.AccountsTaskMonitorINSERT()

    End Function

    Public Shared Function AccountsTaskMonitorStatusCheck() As DataSet

        Return AccountsMonthEndProcessingDAL.AccountsTaskMonitorStatusCheck()

    End Function

    Public Shared Function CalculatePettyCashCF(ByVal CashReconDate As Date) As DataSet

        Return AccountsMonthEndProcessingDAL.CalculatePettyCashCF(CashReconDate)

    End Function
    Public Shared Function PettyCashCFDate() As DataSet

        Return AccountsMonthEndProcessingDAL.PettyCashCFDate()

    End Function

    Public Shared Function PettyCashCFCashReconDate(ByVal Month As Integer, ByVal Year As Integer) As DataSet

        Return AccountsMonthEndProcessingDAL.PettyCashCFCashReconDate(Month, Year)

    End Function

    Public Shared Function LedgerReport(ByVal LedgerType As String, ByVal Modid As Integer) As DataSet

        Return AccountsMonthEndProcessingDAL.LedgerReport(LedgerType, Modid)

    End Function
    Public Shared Function LedgerReportCheck(ByVal Modid As Integer) As DataSet

        Return AccountsMonthEndProcessingDAL.LedgerReportCheck(Modid)

    End Function

End Class

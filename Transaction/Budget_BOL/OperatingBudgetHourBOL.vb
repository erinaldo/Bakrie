Imports Budget_DAL
Imports Budget_PPT

Public Class OperatingBudgetHourBOL
    Public Shared Function OperatingBudgetByHoursInsert(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataSet
        Return OperatingBudgetHourDAL.OperatingBudgetByHoursInsert(oOperatingBudgetHourPPT)
    End Function
    Public Shared Function OperatingBudgetByHoursSelect() As DataTable
        Return OperatingBudgetHourDAL.OperatingBudgetByHoursSelect()
    End Function
    Public Shared Function OperatingBudgetByHoursSelect_MultipleEntry(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataTable
        Return OperatingBudgetHourDAL.OperatingBudgetByHoursSelect_MultipleEntry(oOperatingBudgetHourPPT)
    End Function
    Public Shared Function OperatingBudgetByHoursUpdate(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataSet
        Return OperatingBudgetHourDAL.OperatingBudgetByHoursUpdate(oOperatingBudgetHourPPT)
    End Function
    Public Shared Function OperatingHoursViewSearch(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataSet
        Return OperatingBudgetHourDAL.OperatingHoursViewSearch(oOperatingBudgetHourPPT)
    End Function
    Public Shared Function OperatingBudgetByHoursDelete(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As Integer
        Return OperatingBudgetHourDAL.OperatingBudgetByHoursDelete(oOperatingBudgetHourPPT)
    End Function
    Public Shared Function AcctlookupSearch(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT, ByVal IsDirect As String) As DataSet
        Return OperatingBudgetHourDAL.AcctlookupSearch(oOperatingBudgetHourPPT, IsDirect)
    End Function
End Class

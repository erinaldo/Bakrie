Imports Budget_DAL
Imports Budget_PPT
Public Class OperatingBudgetCostBOL

    Public Shared Function OperatingBudgetByCostInsert(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Return OperatingBudgetCostDAL.OperatingBudgetByCostInsert(oOperatingBudgetCostPPT)
    End Function

    Public Shared Function GetVHGroup(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT, ByVal IsDirect As String) As DataSet
        Return OperatingBudgetCostDAL.GetVHGroup(oOperatingBudgetCostPPT, IsDirect)
    End Function

    Public Shared Function OperatingBudgetByCostUpdate(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Return OperatingBudgetCostDAL.OperatingBudgetByCostUpdate(oOperatingBudgetCostPPT)
    End Function
    Public Shared Function OperatingBudgetByCostSelect() As DataTable
        Return OperatingBudgetCostDAL.OperatingBudgetByCostSelect()
    End Function
    Public Shared Function OperatingBudgetByCostDelete(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As Integer
        Return OperatingBudgetCostDAL.OperatingBudgetByCostDelete(oOperatingBudgetCostPPT)
    End Function
    Public Shared Function OperatingCostViewSearch(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Return OperatingBudgetCostDAL.OperatingCostViewSearch(oOperatingBudgetCostPPT)
    End Function
    Public Shared Function OperatingBudgetByCostSelect_MultipleEntry(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataTable
        Dim oOperatingBudgetCostDAL As New OperatingBudgetCostDAL
        Return oOperatingBudgetCostDAL.OperatingBudgetByCostSelect_MultipleEntry(oOperatingBudgetCostPPT)
    End Function

    Public Shared Function OperatingBudgetByCostDriverFill(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Return OperatingBudgetCostDAL.OperatingBudgetByCostDriverFill(oOperatingBudgetCostPPT)
    End Function
    Public Shared Function AcctlookupSearch(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT, ByVal IsDirect As String) As DataSet
        Return OperatingBudgetCostDAL.AcctlookupSearch(oOperatingBudgetCostPPT, IsDirect)
    End Function
End Class

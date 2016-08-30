Imports Budget_DAL
Imports Budget_PPT


Public Class YieldBudgetBOL

    Public Shared Function YieldBudgetYieldGet() As DataSet
        Return YieldBudgetDAL.YieldBudgetYieldGet()
    End Function
    Public Shared Function YieldBudgetHectFill(ByVal oYieldBudgetPPT As YieldBudgetPPT) As DataSet
        Return YieldBudgetDAL.YieldBudgetHectFill(oYieldBudgetPPT)
    End Function
End Class

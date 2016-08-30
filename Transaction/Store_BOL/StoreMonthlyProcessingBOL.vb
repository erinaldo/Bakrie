Imports Store_DAL
Imports Store_PPT

Public Class StoreMonthlyProcessingBOL

    Public Shared Function MonthlyProcessingDeleteAll(ByVal objStoreMonthlyProcessingPPT As StoreMonthlyProcessingPPT) As DataSet

        Return Store_DAL.StoreMonthlyProcessingDAL.MonthlyProcessingDeleteAll(objStoreMonthlyProcessingPPT)

    End Function


    Public Shared Function DoStoreMonthlyProcessing(ByVal objStoreMonthlyProcessingPPT As StoreMonthlyProcessingPPT) As DataSet

        Return StoreMonthlyProcessingDAL.DoStoreMonthlyProcessing(objStoreMonthlyProcessingPPT)

    End Function

    Public Shared Function TaskMonitorStatusGet(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Return StoreMonthlyProcessingDAL.TaskMonitorStatusGet(objStoreMonthEndClosingPPT)

    End Function

End Class

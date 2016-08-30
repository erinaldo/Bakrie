Imports Store_DAL
Imports Store_PPT

Public Class StoreMonthEndClosingBOL

    Public Shared Function DoStoreMonthEndClosing(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Return StoreMonthEndClosingDAL.DoStoreMonthEndClosing(objStoreMonthEndClosingPPT)

    End Function


    Public Shared Function StoreMonthEndClosing_UpdateStockMaster(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT, ByVal strNewActiveMonthYearID As String) As DataSet

        Return StoreMonthEndClosingDAL.StoreMonthEndClosing_UpdateStockMaster(objStoreMonthEndClosingPPT, strNewActiveMonthYearID)

    End Function


    Public Shared Function TaskConfigTaskCheckGet(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Return StoreMonthEndClosingDAL.TaskConfigTaskCheckGet(objStoreMonthEndClosingPPT)

    End Function

    Public Shared Function TaskMonitorGet(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Return StoreMonthEndClosingDAL.TaskMonitorGet(objStoreMonthEndClosingPPT)

    End Function

    Public Shared Function ApprovalCheck(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Return StoreMonthEndClosingDAL.ApprovalCheck(objStoreMonthEndClosingPPT)

    End Function

    Public Shared Function Taskmonitorupdate(ByVal objstoremonthendclosingppt As StoreMonthEndClosingPPT) As DataSet

        Return StoreMonthEndClosingDAL.TaskMonitorUpdate(objstoremonthendclosingppt)

    End Function

    ''Public Shared Function TaskMonitorInsert(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

    ''    Return StoreMonthEndClosingDAL.TaskMonitorInsert(objStoreMonthEndClosingPPT)

    ''End Function


End Class

Imports Store_BOL
Imports Store_PPT
Imports Store_DAL
Public Class StockAdjustmentBOL
    Public Function GetAdjustmentNo(ByVal objAdjustmentNo As StockAdjustmentPPT) As StockAdjustmentPPT
        Dim objAdjustmentData As New StockAdjustmentDAL
        Return objAdjustmentData.GetAdjustmentNo(objAdjustmentNo)
    End Function

    Public Function GetSAAutoNo() As String
        Dim objAdjustmentData As New StockAdjustmentDAL
        Return objAdjustmentData.GetSAAutoNop()
    End Function

    Public Function GetStockCode(ByVal objStkAdjustmentPPT As StockAdjustmentPPT) As DataSet
        Dim objStkAdjustDAL As New StockAdjustmentDAL
        ' Return objStockData
        Return objStkAdjustDAL.GetStockCode(objStkAdjustmentPPT)
    End Function

    Public Shared Function saveStockAdjustment(ByVal objStockAdjustment As StockAdjustmentPPT) As DataSet
        Return StockAdjustmentDAL.saveStockAdjustment(objStockAdjustment)
    End Function
    Public Shared Function AcctlookupSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet
        Return StockAdjustmentDAL.AcctlookupSearch(objStoreIssueVoucher, IsDirect)
    End Function
    Public Shared Function STAdjustStockIDDetailSelect(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataSet
        Return StockAdjustmentDAL.STAdjustStockIDDetailSelect(objStkAdjustPPT)
    End Function
    Public Function GetAdjustmentDetails(ByVal objAdjustmentPPT As StockAdjustmentPPT) As DataTable
        Dim objAdjustmentDAL As New StockAdjustmentDAL
        Return objAdjustmentDAL.GetAdjustmentDetails(objAdjustmentPPT)
    End Function
    Public Function GetAdjustDetailsInfo(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataTable
        Dim objStkAdjustData As New StockAdjustmentDAL
        Return objStkAdjustData.GetAdjustDetailsInfo(objStkAdjustPPT)
    End Function
    Public Function AdjustmentStockDetailGet(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataTable
        Dim objStkAdjustDAL As New StockAdjustmentDAL
        Return objStkAdjustDAL.AdjustmentStockDetailGet(objStkAdjustPPT)
    End Function
    Public Shared Function STALedgerAllModuleInsert(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As DataSet
        Return StockAdjustmentDAL.STALedgerAllModuleInsert(objStkAdjustApprovalPPT)
    End Function
    Public Shared Function STALedgerAllModuleUpdate(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As Integer
        Return StockAdjustmentDAL.STALedgerAllModuleUpdate(objStkAdjustApprovalPPT)
    End Function
    Public Shared Function STAdjustAvgPriceCalculate(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataSet
        Dim objStkAdjustDAL As New StockAdjustmentDAL
        Return objStkAdjustDAL.STAdjustAvgPriceCalculate(objStkAdjustPPT)
    End Function
    'Public Shared Function STAdjustAvgPriceCalculate(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataSet
    '    Dim objStkAdjustDAL As New StockAdjustmentDAL
    '    Return objStkAdjustDAL.STAdjustAvgPriceCalculate(objStkAdjustPPT)
    'End Function
    Public Shared Function STIssueJournalDetailInsert(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As DataSet
        Return StockAdjustmentDAL.STIssueJournalDetailInsert(objStkAdjustApprovalPPT)
    End Function
    Public Shared Function Update_Adjust(ByVal objAdjustUpdate As StockAdjustmentPPT) As DataSet
        Dim objAdjustData As New StockAdjustmentDAL
        Return objAdjustData.Update_Adjust(objAdjustUpdate)
    End Function
    Public Function Delete_AdjustDetail(ByVal objAdjustPPT As StockAdjustmentPPT) As Integer
        Dim objAdjustData As New StockAdjustmentDAL
        Return objAdjustData.Delete_AdjustDetail(objAdjustPPT)
    End Function
    Public Shared Function Update_AdjustApproval(ByVal objStkAdjustPPT As StockAdjustmentPPT) As Integer
        Dim objStkAdjustData As New StockAdjustmentDAL
        Return objStkAdjustData.Update_AdjustApproval(objStkAdjustPPT)
    End Function

    Public Function STARecordIsExist(ByVal objStockAdjustmentPPT As StockAdjustmentPPT) As Object

        Dim objStkAdjustData As New StockAdjustmentDAL
        Return objStkAdjustData.STARecordIsExist(objStockAdjustmentPPT)

    End Function

    Public Shared Function STAdjustmentDelete_N(ByVal objAdjustmentPPT As StockAdjustmentPPT) As Integer

        Return StockAdjustmentDAL.STAdjustmentDelete_N(objAdjustmentPPT)

    End Function

End Class

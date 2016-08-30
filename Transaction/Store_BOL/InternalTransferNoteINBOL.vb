Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient

Public Class InternalTransferNoteINBOL
    Public Function STITNInStockCodeGet(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STITNInStockCodeGet(objINTINPPT)
    End Function

    Public Function ITInNo_isExist(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.ITInNo_isExist(objINTINPPT)
    End Function

    Public Function STITNInSendLocGet(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STITNInSendLocGet(objINTINPPT)
    End Function

    Public Function AcctlookupSearch(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.AcctlookupSearch(objINTINPPT)
    End Function


    Public Function STInternalTransferInSelect(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STInternalTransferInSelect(objINTINPPT)
    End Function

    Public Function Save_STInternalTransferIn(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        'IPRNo_isExist(objIPRSave)
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Save_STInternalTransferIn(objINTINPPT)
    End Function

    Public Function Update_STInternalTransferIn(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Update_STInternalTransferIn(objINTINPPT)
    End Function

    Public Function Save_STITNInDetailsInsert(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Save_STITNInDetailsInsert(objINTINPPT)
    End Function

    Public Function Update_STITNInDetailsUpdate(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Update_STITNInDetailsUpdate(objINTINPPT)
    End Function

    Public Function ITNInDetails_Select(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.ITNInDetails_Select(objINTINPPT)
    End Function

    Public Function Delete_STInternalTransferIn(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Delete_STInternalTransferIn(objINTINPPT)
    End Function

    Public Function Update_STInternalTransferInApproval(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Update_STInternalTransferInApproval(objINTINPPT)
    End Function

    Public Function Save_LedgerAllModule(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Save_LedgerAllModule(objINTINPPT)
    End Function

    Public Function Update_LedgerAllModule(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.Update_LedgerAllModule(objINTINPPT)
    End Function

    Public Function ITNIn_Averageprice(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.ITNIn_Averageprice(objINTINPPT)
    End Function

    Public Function AC_JournalDetailInsert(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.AC_JournalDetailInsert(objINTINPPT)
    End Function

    Public Function ITNIn_StockDetailGet(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.ITNIn_StockDetailGet(objINTINPPT)
    End Function

    Public Function STITNInStockCodeGetNew(ByVal objINTINPPT As InternalTransferNoteINPPT, ByVal IsDirect As String) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STITNInStockCodeGetNew(objINTINPPT, IsDirect)
    End Function

    Public Function STStockDetailsSelect(ByVal objINTINPPT As InternalTransferNoteINPPT, ByVal IsDirect As String) As DataTable
        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STStockDetailsSelect(objINTINPPT, IsDirect)
    End Function

    Public Function STStockDetailsSelectDetails(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable

        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STStockDetailsSelectDetails(objINTINPPT)

    End Function

    Public Function ITNInRecordIsExisT(ByVal objINTINPPT As InternalTransferNoteINPPT) As Object

        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.ITNInRecordIsExist(objINTINPPT)

    End Function

    Public Shared Function STInternalTransferInDetailsDelete(ByVal objITNIN As InternalTransferNoteINPPT) As Integer

        Dim objINTINData As New InternalTransferNoteINDAL
        Return objINTINData.STInternalTransferInDetailsDelete(objITNIN)

    End Function


End Class

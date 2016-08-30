Imports Store_DAL
Imports Store_PPT

Public Class InternalTransferNoteOUTBOL
    Public Function GetITNOutNo(ByVal objITNOutNo) As DataTable
        Dim objITNOutNoData As New InternalTransferNoteOUTDAL
        Return objITNOutNoData.GetITNOutNo(objITNOutNo)
    End Function

    Public Function GetTNOutAutoNo() As String
        Dim objITNOutNoData As New InternalTransferNoteOUTDAL
        Return objITNOutNoData.GetTNOutAutoNo()
    End Function

    Public Function STITNOutStockCodeGet(ByVal objITNOut As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.STITNOutStockCodeGet(objITNOut)
    End Function

    Public Function STITNOutRecLocGet(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.STITNOutRecLocGet(objITNOutPPT)
    End Function


    Public Function AcctlookupSearch(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.AcctlookupSearch(objITNOutPPT)
    End Function


    Public Function Save_STInternalTransferOut(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        'IPRNo_isExist(objIPRSave)
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Save_STInternalTransferOut(objITNOutPPT)
    End Function
    Public Function Update_STInternalTransferOut(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Update_STInternalTransferOut(objITNOutPPT)
    End Function

    Public Function Save_STITNOutDetailsInsert(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Save_STITNOutDetailsInsert(objITNOutPPT)
    End Function
    Public Function Update_STITNOutDetails(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Update_STITNOutDetails(objITNOutPPT)
    End Function

    Public Function STInternalTransferOutSelect(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.STInternalTransferOutSelect(objITNOutPPT)
    End Function

    Public Function ITNOutDetails_Select(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.ITNOutDetails_Select(objITNOutPPT)
    End Function

    Public Function Delete_STInternalTransferOut(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Delete_STInternalTransferOut(objITNOutPPT)
    End Function

    Public Function Update_STInternalTransferOutApproval(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Update_STInternalTransferOutApproval(objITNOutPPT)
    End Function

    Public Function ITNOut_Averageprice(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.ITNOut_Averageprice(objITNOutPPT)
    End Function

    Public Function Save_LedgerAllModule(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Save_LedgerAllModule(objITNOutPPT)
    End Function

    Public Function Update_LedgerAllModule(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.Update_LedgerAllModule(objITNOutPPT)
    End Function


    Public Function ITNOut_StockDetailGet(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.ITNOut_StockDetailGet(objITNOutPPT)
    End Function

    Public Function AC_JournalDetailInsert(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.AC_JournalDetailInsert(objITNOutPPT)
    End Function

    Public Function ITNOutRecordIsExisT(ByVal objINTOutPPT As InternalTransferNoteOUTPPT) As Object
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.ITNOutRecordIsExist(objINTOutPPT)
    End Function

    Public Function STInternalTransferOutDetailSelect(ByVal objInternalTransferNoteOUTPPT As InternalTransferNoteOUTPPT) As DataSet
        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.STInternalTransferOutDetailSelect(objInternalTransferNoteOUTPPT)
    End Function

    Public Function STInternalTransferOutDetailsDelete(ByVal objITNOUT As InternalTransferNoteOUTPPT) As Integer

        Dim objINTOUTData As New InternalTransferNoteOUTDAL
        Return objINTOUTData.STInternalTransferOutDetailsDelete(objITNOUT)

    End Function

    Public Shared Function STInternalTransferOutDetailsTransferOutQtyCheck(ByVal StockID As String, ByVal RequestedTransferOutQty As Double) As Double

        Return InternalTransferNoteOUTDAL.STInternalTransferOutDetailsTransferOutQtyCheck(StockID, RequestedTransferOutQty)

    End Function

End Class


Imports Store_DAL
Imports Store_PPT

Public Class ReturnGoodsNoteBOL

    Public Shared Function GetRGNNo(ByVal objRGNPPT As ReturnGoodsNotePPT) As String

        Return ReturnGoodsNoteDAL.GetRGNNo(objRGNPPT)

    End Function

    Public Shared Function GetRGSAutoNo() As String
        Return ReturnGoodsNoteDAL.GetRGSAutoNo()
    End Function

    Public Shared Function RGNSIVGet(ByVal objRGNPPT As ReturnGoodsNotePPT, ByVal IsDirect As String) As DataSet

        Return ReturnGoodsNoteDAL.RGNSIVGet(objRGNPPT, IsDirect)

    End Function

    Public Shared Function RGNStockDetailsGet(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.RGNStockDetailsGet(objRGNPPT)

    End Function

    Public Shared Function STReturnGoodsNoteInsert(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STReturnGoodsNoteInsert(objRGNPPT)

    End Function

    Public Shared Function STReturnGoodsDetailsInsert(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STReturnGoodsDetailsInsert(objRGNPPT)

    End Function

    Public Shared Function STReturnGoodsNoteUpdate(ByVal objRGNPPT As ReturnGoodsNotePPT, ByVal IsStatusFromApproval As String) As DataSet

        Return ReturnGoodsNoteDAL.STReturnGoodsNoteUpdate(objRGNPPT, IsStatusFromApproval)

    End Function

    Public Shared Function STReturnGoodsDetailsUpdate(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STReturnGoodsDetailsUpdate(objRGNPPT)

    End Function

    Public Shared Function STRGNSearch(ByVal objRGNPPT As ReturnGoodsNotePPT, ByVal IsApproval As String) As DataSet

        Return ReturnGoodsNoteDAL.STRGNSearch(objRGNPPT, IsApproval)

    End Function

    Public Shared Function STRGNDetailsGet(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STRGNDetailsGet(objRGNPPT)

    End Function

    Public Shared Function STRGNDelete(ByVal objRGN As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STRGNDelete(objRGN)

    End Function

    Public Shared Function STStockDetailAvgPriceApproval(ByVal objRGN As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STStockDetailAvgPriceApproval(objRGN)

    End Function

    Public Shared Function STRGNLedgerAllModuleInsert(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As DataSet

        Return ReturnGoodsNoteDAL.STRGNLedgerAllModuleInsert(objRGNApprovalPPT)

    End Function

    Public Shared Function STRGNLedgerAllModuleUpdate(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As Integer

        Return ReturnGoodsNoteDAL.STRGNLedgerAllModuleUpdate(objRGNApprovalPPT)

    End Function

    Public Shared Function STRGNJournalDetailInsert(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As Integer

        Return ReturnGoodsNoteDAL.STRGNJournalDetailInsert(objRGNApprovalPPT)

    End Function

    Public Shared Function STRGNStockIDDetailSelect(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STRGNStockIDDetailSelect(objRGNPPT)

    End Function

    Public Shared Function STIssueDetailsReturnQtyUpdate(ByVal objRGNPPT As ReturnGoodsNotePPT) As Integer

        Return ReturnGoodsNoteDAL.STIssueDetailsReturnQtyUpdate(objRGNPPT)

    End Function
    Public Function RGNRecordIsExisT(ByVal objRGNPPT As ReturnGoodsNotePPT) As Object

        Dim objRGNData As New ReturnGoodsNoteDAL
        Return objRGNData.RGNRecordIsExist(objRGNPPT)

    End Function

    'Public Shared Function VHChargeDetailInsert(ByVal objRGNPPT As ReturnGoodsNoteApprovalPPT) As Integer

    '    Return ReturnGoodsNoteDAL.VHChargeDetailInsert(objRGNPPT)

    'End Function

    Public Shared Function STRGNOtherDetailsGet(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Return ReturnGoodsNoteDAL.STRGNOtherDetailsGet(objRGNPPT)

    End Function

    Public Shared Function VHChargeDetailInsert(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As Integer

        Return ReturnGoodsNoteDAL.VHChargeDetailInsert(objRGNApprovalPPT)

    End Function


    'Public Shared Function STRGNDetailDelete(ByVal objRGN As ReturnGoodsNotePPT) As DataSet

    '    Return ReturnGoodsNoteDAL.STRGNDetailDelete(objRGN)

    'End Function

    Public Shared Function STRGNDetailDelete(ByVal objRGN As ReturnGoodsNotePPT) As Integer

        Return ReturnGoodsNoteDAL.STRGNDetailDelete(objRGN)

    End Function

End Class

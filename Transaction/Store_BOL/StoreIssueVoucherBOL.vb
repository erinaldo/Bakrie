Imports Store_DAL
Imports Store_PPT
Imports System.Windows.Forms
Public Class StoreIssueVoucherBOL

    'Public Shared Function fillIssueBtachTotal(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As Object
    '    Return StoreIssueVoucherDAL.fillIssueBtachTotal(objStoreIssueVoucher)
    'End Function

    Public Shared Function fillSIVNo() As DataSet

        Return StoreIssueVoucherDAL.fillSIVNo()

    End Function

    Public Shared Function DeleteStoreIssueVoucher(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.DeleteStoreIssueVoucher(objStoreIssueVoucher)

    End Function

    Public Shared Function fillCategoryDesc(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.fillCategoryDesc(objStoreIssueVoucher)

    End Function

    Public Shared Function fillIssueBatchTotalDs(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.fillIssueBatchTotalDs(objStoreIssueVoucher)

    End Function

    Public Shared Function STIssueIsSIVNoExist(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.STIssueIsSIVNoExist(objStoreIssueVoucher)

    End Function

    Public Shared Function saveStoreIssueVoucher(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.saveStoreIssueVoucher(objStoreIssueVoucher)

    End Function

    Public Shared Function saveStoreIssueVoucherDetails(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.saveStoreIssueVoucherDetails(objStoreIssueVoucher)

    End Function

    Public Shared Function updateStoreIssueVoucherDetails(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.updateStoreIssueVoucherDetails(objStoreIssueVoucher)

    End Function

    Public Shared Function updateStoreIssueVoucher(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsStatusApproval As String) As DataSet

        Return StoreIssueVoucherDAL.updateStoreIssueVoucher(objStoreIssueVoucher, IsStatusApproval)

    End Function

    Public Shared Function STIssueBtachValueUpdate(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.STIssueBtachValueUpdate(objStoreIssueVoucher)

    End Function

    Public Shared Function IsContractNoExist(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.IsContractNoExist(objStoreIssueVoucher)

    End Function '

    Public Shared Function ContractIDSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.ContractIDSearch(objStoreIssueVoucher, IsDirect)

    End Function

    Public Shared Function SIVSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsApproval As String) As DataSet

        Return StoreIssueVoucherDAL.SIVSearch(objStoreIssueVoucher, IsApproval)

    End Function

    Public Shared Function TlookupSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.TlookupSearch(objStoreIssueVoucher, IsDirect)

    End Function

    ''Public Shared Function EstateTypeSelect() As String
    ''    Return StoreIssueVoucherDAL.EstateTypeSelect()
    ''End Function

    Public Shared Function AcctlookupSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.AcctlookupSearch(objStoreIssueVoucher, IsDirect)

    End Function

    Public Shared Function GetStockCategory(ByVal obStkCategory As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.GetStockCategory(obStkCategory)

    End Function

    Public Shared Function GetYOP(ByVal obYOP As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.GetYOP(obYOP)

    End Function

    Public Shared Function GetDIV(ByVal obDIV As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.GetDIV(obDIV, IsDirect)

    End Function

    Public Shared Function GetSubBlock(ByVal obSubBlock As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.GetSubBlock(obSubBlock, IsDirect)

    End Function

    Public Shared Function GetCropID(ByVal CropID As String) As DataSet

        Return StoreIssueVoucherDAL.GetCropID(CropID)

    End Function

    Public Shared Function GetStation(ByVal obStation As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.GetStation(obStation, IsDirect)

    End Function

    Public Shared Function GetVHNo(ByVal obVHNo As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.GetVHNo(obVHNo, IsDirect)

    End Function

    Public Shared Function VHNCategoryGet(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.VHNCategoryGet(objStoreIssueVoucher)

    End Function

    Public Shared Function GetVHDetailsCostCode(ByVal obVHDetailsCostCode As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.GetVHDetailsCostCode(obVHDetailsCostCode, IsDirect)

    End Function

    Public Shared Function GetSIVDetails(ByVal objSIV As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.GetSIVDetails(objSIV)

    End Function

    Public Shared Function STIssueAvgPriceGet(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.STIssueAvgPriceGet(objStoreIssueVoucher)

    End Function

    Public Shared Function STStockDetailAvgPriceApproval(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.STStockDetailAvgPriceApproval(objStoreIssueVoucher)

    End Function

    Public Shared Function STIssueLedgerAllModuleInsert(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As DataSet

        Return StoreIssueVoucherDAL.STIssueLedgerAllModuleInsert(objStockIssueVoucherApprovalPPT)

    End Function

    Public Shared Function STIssueLedgerAllModuleUpdate(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As Integer

        Return StoreIssueVoucherDAL.STIssueLedgerAllModuleUpdate(objStockIssueVoucherApprovalPPT)

    End Function

    Public Shared Function STIssueJournalDetailInsert(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As Integer

        Return StoreIssueVoucherDAL.STIssueJournalDetailInsert(objStockIssueVoucherApprovalPPT)

    End Function

    Public Shared Function STIssueStockIDDetailSelect(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.STIssueStockIDDetailSelect(objStoreIssueVoucher)

    End Function

    Public Shared Function VHChargeDetailInsert(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As Integer

        Return StoreIssueVoucherDAL.VHChargeDetailInsert(objStockIssueVoucherApprovalPPT)

    End Function

    'Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
    '    If grdname.Rows.Count <> 0 Then

    '        Dim objDataGridViewRow As New DataGridViewRow
    '        For Each objDataGridViewRow In grdname.Rows

    '            grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
    '        Next
    '        If grdname.Rows.Count = 1 Then
    '            grdname.Rows.RemoveAt(0)
    '        End If
    '    End If
    'End Sub

    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)

        If grdname.Rows.Count <> 0 Then
            Dim i As Integer = 0
            Dim J As Integer = 0
            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            i = grdname.Rows.Count
            For J = 0 To i - 1
                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
                'If grdname.Rows.Count - 1 Then
                '    grdname.Rows.RemoveAt(0)
                'End If
            Next
        End If

    End Sub

    Public Function SIVRecordIsExisT(ByVal objSIVPPT As StoreIssueVoucherPPT) As Object

        Dim objSIVDAL As New StoreIssueVoucherDAL
        Return objSIVDAL.SIVRecordIsExist(objSIVPPT)

    End Function

    Public Shared Function TaskMonitorUpdateOnSIVApproval(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As Object

        Return StoreIssueVoucherDAL.TaskMonitorUpdateOnSIVApproval(objStoreIssueVoucher)

    End Function

    Public Function StockCategorySearch(ByVal CategorySearch As String) As DataTable

        Return StoreIssueVoucherDAL.StockCategorySearch(CategorySearch)

    End Function

    Public Shared Function SIVSearchForReport(ByVal objSIV As StoreIssueVoucherPPT) As DataSet

        Return StoreIssueVoucherDAL.SIVSearchForReport(objSIV)

    End Function

    Public Shared Function STIssueDetailDelete(ByVal objSIV As StoreIssueVoucherPPT) As Integer

        Return StoreIssueVoucherDAL.STIssueDetailDelete(objSIV)

    End Function

    Public Shared Function STIssueDetailsIssuedQtyCheck(ByVal StockID As String, ByVal RequestedIssueQty As Double) As Double

        Return StoreIssueVoucherDAL.STIssueDetailsIssuedQtyCheck(StockID, RequestedIssueQty)

    End Function

    Public Shared Function STIssueDetailsOpenQtyCheck(ByVal StockID As String, ByVal SIVNo As String) As Double

        Return StoreIssueVoucherDAL.STIssueDetailsOpenQtyCheck(StockID, SIVNo)

    End Function
    Public Shared Function GetEquipment(ByVal obEquipment As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Return StoreIssueVoucherDAL.GetEquipment(obEquipment, IsDirect)

    End Function
End Class


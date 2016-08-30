Imports System.Data.SqlClient
Imports Store_DAL
Imports Store_PPT
Imports System.Windows.Forms

Public Class LocalPurchaseOrderBOL
    Public Function GetLPONO(ByVal objLPONo As LocalPurchaseOrderPPT) As LocalPurchaseOrderPPT
        Dim objLPOData As New LocalPurchaseOrderDAL
        Return objLPOData.GetLPONo(objLPONo)
    End Function
    Public Function GetPOAutoNo() As String
        Dim objLPOData As New LocalPurchaseOrderDAL
        Return objLPOData.GetPOAutoNo()
    End Function
    Public Function LPOApprovalGet(ByVal objLPOApprovalPPT As LocalPurchaseOrderApprovalPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderApprovalDAL
        Return objLPODAL.LPOApprovalGet(objLPOApprovalPPT)
    End Function
    Public Function GetStockCode(ByVal ObjLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.GetStockCode(ObjLPOPPT)
    End Function

    Public Function SearchSupplier(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.SearchSupplier(objLPOPPT)
    End Function
    Public Shared Function SaveSTLPO(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataSet
        Return LocalPurchaseOrderDAL.SaveSTLPO(objLPOPPT)
    End Function
    Public Function GetLPODetails(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.GetLPODetails(objLPOPPT)
    End Function
    Public Function GetLPOID(ByVal objLPOPPT As LocalPurchaseOrderPPT) As LocalPurchaseOrderPPT
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.GetLPOID(objLPOPPT)
    End Function
    Public Function GetLPODetailsInfo(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.GetLPODetailsInfo(objLPOPPT)
    End Function
    Public Function GetLPODetailsView(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.GetLPODetailsView(objLPOPPT)
    End Function
    Public Shared Function UpdateSTLPO(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataSet
        Return LocalPurchaseOrderDAL.UpdateSTLPO(objLPOPPT)
    End Function

    Public Shared Function SearchDgvLpoView(ByVal objLpoPpt As LocalPurchaseOrderPPT) As DataSet
        Return LocalPurchaseOrderDAL.SearchDgvLpoView(objLpoPpt)
    End Function
    Public Shared Function SaveSTLPODetails(ByVal objLpoPpt As LocalPurchaseOrderPPT) As DataSet
        Return LocalPurchaseOrderDAL.SaveSTLPODetails(objLpoPpt)
    End Function
    Public Shared Function UpdateSTLPODetails(ByVal objLpoPpt As LocalPurchaseOrderPPT) As DataSet
        Return LocalPurchaseOrderDAL.UpdateSTLPODetails(objLpoPpt)
    End Function
    Public Shared Sub ClearGridView(ByVal grdname As DataGridView)
        If grdname.Rows.Count <> 0 Then

            Dim objDataGridViewRow As New DataGridViewRow
            For Each objDataGridViewRow In grdname.Rows

                grdname.Rows.RemoveAt(grdname.Rows.Count - 1)
            Next
            If grdname.Rows.Count = 1 Then
                grdname.Rows.RemoveAt(0)
            End If
        End If
    End Sub
    Public Function Update_LPOApproval(ByVal objLPOPPT As LocalPurchaseOrderPPT) As Integer
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.Update_LPOApproval(objLPOPPT)
    End Function
    Public Function DeleteLPODetail(ByVal objLPOPPT As LocalPurchaseOrderPPT) As Integer
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.DeleteLPODetail(objLPOPPT)
    End Function

    Public Function LPORecordIsExisT(ByVal objLPOPPT As LocalPurchaseOrderPPT) As Object
        Dim objLPOData As New LocalPurchaseOrderDAL
        Return objLPOData.LPORecordIsExist(objLPOPPT)
    End Function

    Public Shared Function AcctlookupSearch(ByVal objLPOPPT As LocalPurchaseOrderPPT, ByVal IsDirect As String) As DataSet
        Return LocalPurchaseOrderDAL.AcctlookupSearch(objLPOPPT, IsDirect)
    End Function
    Public Function GetLPODetailsForReport(ByVal objLPOPPT As LocalPurchaseOrderPPT) As DataTable
        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.GetLPODetailsForReport(objLPOPPT)
    End Function

    Public Function DeleteMultiEntryLPO(ByVal ObjLPOPPT As LocalPurchaseOrderPPT) As Integer

        Dim objLPODAL As New LocalPurchaseOrderDAL
        Return objLPODAL.DeleteMultiEntryLPO(ObjLPOPPT)

    End Function


    Public Function StockCategorySearch(ByVal CategorySearch As String) As DataTable

        Return LocalPurchaseOrderDAL.StockCategorySearch(CategorySearch)

    End Function

End Class


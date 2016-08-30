Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class NonStockIPRApprovalDAL
    Public Function NonStockIPRApprovalGet(ByVal objNonStockIPRApprovalPPT As NonStockIPRApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(8) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@IPRdate", IIf(objNonStockIPRApprovalPPT.IPRdate <> Nothing, objNonStockIPRApprovalPPT.IPRdate, DBNull.Value))
        params(2) = New SqlParameter("@IPRNo", IIf(objNonStockIPRApprovalPPT.IPRNo <> "", objNonStockIPRApprovalPPT.IPRNo, DBNull.Value))
        params(3) = New SqlParameter("@DeliveredTo", IIf(objNonStockIPRApprovalPPT.DeliveredTo <> "", objNonStockIPRApprovalPPT.DeliveredTo, DBNull.Value))
        params(4) = New SqlParameter("@Classification", IIf(objNonStockIPRApprovalPPT.Classification <> "", objNonStockIPRApprovalPPT.Classification, DBNull.Value))
        params(5) = New SqlParameter("@RequiredFor", IIf(objNonStockIPRApprovalPPT.RequiredFor <> "", objNonStockIPRApprovalPPT.RequiredFor, DBNull.Value))
        params(6) = New SqlParameter("@STCategory", IIf(objNonStockIPRApprovalPPT.STCategory <> "", objNonStockIPRApprovalPPT.STCategory, DBNull.Value))
        params(7) = New SqlParameter("@MainStatus", IIf(objNonStockIPRApprovalPPT.MainStatus <> "", objNonStockIPRApprovalPPT.MainStatus, DBNull.Value))
        params(8) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Store].[STNonStockIPRApprovalSelect]", params).Tables(0)
        Return dt
    End Function
End Class

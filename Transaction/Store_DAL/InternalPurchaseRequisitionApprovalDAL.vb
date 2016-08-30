Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class InternalPurchaseRequisitionApprovalDAL
    Public Function IPRApprovalGet(ByVal objIPRApprovalPPT As InternalPurchaseRequisitionApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(8) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@IPRdate", IIf(objIPRApprovalPPT.IPRdate <> Nothing, objIPRApprovalPPT.IPRdate, DBNull.Value))
        params(2) = New SqlParameter("@IPRNo", IIf(objIPRApprovalPPT.IPRNo <> "", objIPRApprovalPPT.IPRNo, DBNull.Value))
        params(3) = New SqlParameter("@DeliveredTo", IIf(objIPRApprovalPPT.DeliveredTo <> "", objIPRApprovalPPT.DeliveredTo, DBNull.Value))
        params(4) = New SqlParameter("@Classification", IIf(objIPRApprovalPPT.Classification <> "", objIPRApprovalPPT.Classification, DBNull.Value))
        params(5) = New SqlParameter("@RequiredFor", IIf(objIPRApprovalPPT.RequiredFor <> "", objIPRApprovalPPT.RequiredFor, DBNull.Value))
        params(6) = New SqlParameter("@STCategory", IIf(objIPRApprovalPPT.STCategory <> "", objIPRApprovalPPT.STCategory, DBNull.Value))
        params(7) = New SqlParameter("@MainStatus", IIf(objIPRApprovalPPT.MainStatus <> "", objIPRApprovalPPT.MainStatus, DBNull.Value))
        params(8) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Store].[STIPRApprovalSelect]", params).Tables(0)
        Return dt
    End Function

    Public Function STIPRSelectForReport(ByVal objIPRApprovalPPT As InternalPurchaseRequisitionApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(8) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@IPRdate", IIf(objIPRApprovalPPT.IPRdate <> Nothing, objIPRApprovalPPT.IPRdate, DBNull.Value))
        params(2) = New SqlParameter("@IPRNo", IIf(objIPRApprovalPPT.IPRNo <> "", objIPRApprovalPPT.IPRNo, DBNull.Value))
        params(3) = New SqlParameter("@DeliveredTo", IIf(objIPRApprovalPPT.DeliveredTo <> "", objIPRApprovalPPT.DeliveredTo, DBNull.Value))
        params(4) = New SqlParameter("@Classification", IIf(objIPRApprovalPPT.Classification <> "", objIPRApprovalPPT.Classification, DBNull.Value))
        params(5) = New SqlParameter("@RequiredFor", IIf(objIPRApprovalPPT.RequiredFor <> "", objIPRApprovalPPT.RequiredFor, DBNull.Value))
        params(6) = New SqlParameter("@STCategory", IIf(objIPRApprovalPPT.STCategory <> "", objIPRApprovalPPT.STCategory, DBNull.Value))
        params(7) = New SqlParameter("@MainStatus", IIf(objIPRApprovalPPT.MainStatus <> "", objIPRApprovalPPT.MainStatus, DBNull.Value))
        params(8) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Store].[STIPRSelectForReport]", params).Tables(0)
        Return dt
    End Function

End Class

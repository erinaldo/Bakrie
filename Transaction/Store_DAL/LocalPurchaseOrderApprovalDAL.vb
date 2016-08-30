Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class LocalPurchaseOrderApprovalDAL
    Public Function LPOApprovalGet(ByVal objLPOApprovalPPT As LocalPurchaseOrderApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@LPONo", IIf(objLPOApprovalPPT.LPONo <> "", objLPOApprovalPPT.LPONo, DBNull.Value))
        params(2) = New SqlParameter("@MainStatus", IIf(objLPOApprovalPPT.MainStatus <> "", objLPOApprovalPPT.MainStatus, DBNull.Value))
        params(3) = New SqlParameter("@LPODate", IIf(objLPOApprovalPPT.LPODate <> Nothing, objLPOApprovalPPT.LPODate, DBNull.Value))
        dt = objdb.ExecQuery("[Store].[STLPOApprovalSelect]", params).Tables(0)
        Return dt
    End Function
End Class

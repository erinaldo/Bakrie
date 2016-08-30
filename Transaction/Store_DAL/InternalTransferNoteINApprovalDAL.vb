Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class InternalTransferNoteINApprovalDAL
    Public Function ITNInApprovalGet(ByVal objITNInApprovalPPT As InternalTransferNoteINApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@ITNDate", IIf(objITNInApprovalPPT.ITNDate <> Nothing, objITNInApprovalPPT.ITNDate, DBNull.Value))
        params(3) = New SqlParameter("@ItnInNo", IIf(objITNInApprovalPPT.ItnInNo <> "", objITNInApprovalPPT.ItnInNo, DBNull.Value))
        params(4) = New SqlParameter("@Status", IIf(objITNInApprovalPPT.Status <> "", objITNInApprovalPPT.Status, DBNull.Value))
        params(5) = New SqlParameter("@SenderLocation", IIf(objITNInApprovalPPT.SenderLocation <> String.Empty, objITNInApprovalPPT.SenderLocation, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STInternalTransferInSelect_N]", params).Tables(0)
        Return dt
    End Function

   
End Class

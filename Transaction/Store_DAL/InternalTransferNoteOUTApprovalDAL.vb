Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class InternalTransferNoteOUTApprovalDAL
    Public Function ITNOutApprovalGet(ByVal objITNOutApprovalPPT As InternalTransferNoteOUTApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@ITNDate", IIf(objITNOutApprovalPPT.ITNDate <> Nothing, objITNOutApprovalPPT.ITNDate, DBNull.Value))
        params(3) = New SqlParameter("@ItnOutNo", IIf(objITNOutApprovalPPT.ItnOutNo <> String.Empty, objITNOutApprovalPPT.ItnOutNo, DBNull.Value))
        params(4) = New SqlParameter("@Status", IIf(objITNOutApprovalPPT.Status <> String.Empty, objITNOutApprovalPPT.Status, DBNull.Value))
        params(5) = New SqlParameter("@ReceiverLocation", IIf(objITNOutApprovalPPT.ReceiverLocation <> String.Empty, objITNOutApprovalPPT.ReceiverLocation, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STInternalTransferOutSelect_N]", params).Tables(0)
        Return dt
    End Function
End Class

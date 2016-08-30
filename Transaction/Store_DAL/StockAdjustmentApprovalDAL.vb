Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class StockAdjustmentApprovalDAL
    Public Function StkAdjustApprovalGet(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@AdjustmentNo", IIf(objStkAdjustApprovalPPT.AdjustmentNo <> "", objStkAdjustApprovalPPT.AdjustmentNo, DBNull.Value))
        params(2) = New SqlParameter("@Status", IIf(objStkAdjustApprovalPPT.Status <> "", objStkAdjustApprovalPPT.Status, DBNull.Value))
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(4) = New SqlParameter("@AdjustmentDate", IIf(objStkAdjustApprovalPPT.AdjustmentDate <> Nothing, objStkAdjustApprovalPPT.AdjustmentDate, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STAdjustmentApprovalSelect]", params).Tables(0)
        Return dt
    End Function
End Class

Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient
Public Class StockAdjustmentApprovalBOL
    Public Function StkAdjustApprovalGet(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As DataTable
        Dim objStkAdjustApprovalDAL As New StockAdjustmentApprovalDAL
        Return objStkAdjustApprovalDAL.StkAdjustApprovalGet(objStkAdjustApprovalPPT)
    End Function
End Class

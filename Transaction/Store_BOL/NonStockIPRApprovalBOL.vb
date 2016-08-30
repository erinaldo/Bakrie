Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient

Public Class NonStockIPRApprovalBOL
    Public Function NonStockIPRApprovalGet(ByVal objNonStockIPRApprovalPPT As NonStockIPRApprovalPPT) As DataTable
        Dim objNonStockIPRApprovalDAL As New NonStockIPRApprovalDAL
        Return objNonStockIPRApprovalDAL.NonStockIPRApprovalGet(objNonStockIPRApprovalPPT)
    End Function
End Class

Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient
Public Class LocalPurchaseOrderApprovalBOL
    Public Function LPOApprovalGet(ByVal objLPOApprovalPPT As LocalPurchaseOrderApprovalPPT) As DataTable
        Dim objLPOApprovalDAL As New LocalPurchaseOrderApprovalDAL
        Return objLPOApprovalDAL.LPOApprovalGet(objLPOApprovalPPT)
    End Function
End Class

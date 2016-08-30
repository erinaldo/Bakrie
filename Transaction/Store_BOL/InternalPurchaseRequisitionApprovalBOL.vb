Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient
Public Class InternalPurchaseRequisitionApprovalBOL
    Public Function IPRApprovalGet(ByVal objIPRApprovalPPT As InternalPurchaseRequisitionApprovalPPT) As DataTable
        Dim objINTINData As New InternalPurchaseRequisitionApprovalDAL
        Return objINTINData.IPRApprovalGet(objIPRApprovalPPT)
    End Function

    Public Function STIPRSelectForReport(ByVal objIPRApprovalPPT As InternalPurchaseRequisitionApprovalPPT) As DataTable
        Dim objINTINData As New InternalPurchaseRequisitionApprovalDAL
        Return objINTINData.STIPRSelectForReport(objIPRApprovalPPT)
    End Function


End Class

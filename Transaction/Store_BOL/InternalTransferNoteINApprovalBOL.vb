Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient
Public Class InternalTransferNoteINApprovalBOL

    Public Function ITNInApprovalGet(ByVal objITNInApprovalPPT As InternalTransferNoteINApprovalPPT) As DataTable
        Dim objINTINApprovalData As New InternalTransferNoteINApprovalDAL
        Return objINTINApprovalData.ITNInApprovalGet(objITNInApprovalPPT)
    End Function

  

End Class

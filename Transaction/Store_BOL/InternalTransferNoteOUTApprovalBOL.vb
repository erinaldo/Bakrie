Imports Store_DAL
Imports Store_PPT
Imports System.Data.SqlClient
Public Class InternalTransferNoteOUTApprovalBOL
    Public Function ITNOutApprovalGet(ByVal objITNOutApprovalPPT As InternalTransferNoteOUTApprovalPPT) As DataTable
        Dim objINTOUTApprovalData As New InternalTransferNoteOUTApprovalDAL
        Return objINTOUTApprovalData.ITNOutApprovalGet(objITNOutApprovalPPT)
    End Function
End Class

Imports Accounts_BOL
Imports Accounts_DAL
Imports Accounts_PPT

Public Class PettyCashReceiptBOL
    Public Shared Function savePettyCashReceipt(ByVal objPettyCashPPT As PettyCashReceiptPPT) As DataSet
        Return PettyCashReceiptDAL.savePettyCashReceipt(objPettyCashPPT)
    End Function
    Public Function UpdateReceipt(ByVal objPettyCashPPT As PettyCashReceiptPPT, ByVal IsApproval As String) As Integer
        Dim objPettyCashDAL As New PettyCashReceiptDAL
        Return objPettyCashDAL.UpdateReceipt(objPettyCashPPT, IsApproval)
    End Function
    Public Function GetPettyCashDetails(ByVal objPettyCashPPT As PettyCashReceiptPPT) As DataTable
        Dim objPettyCashDAL As New PettyCashReceiptDAL
        Return objPettyCashDAL.GetPettyCashDetails(objPettyCashPPT)
    End Function
    'Public Function GetPettyCashDetailsInfo(ByVal objPettyCashPPT As PettyCashReceiptPPT) As DataTable
    '    Dim objPettyCashDAL As New PettyCashReceiptDAL
    '    Return objPettyCashDAL.GetPettyCashDetailsInfo()
    'End Function
    Public Function DuplicatePettycashReceiptCheck(ByVal objPettyCashPPT As PettyCashReceiptPPT) As Object
        Dim objPettyCashDAL As New PettyCashReceiptDAL
        Return objPettyCashDAL.DuplicatePettycashReceiptCheck(objPettyCashPPT)
    End Function
    Public Function DeletePettyCashDetail(ByVal objPettyCashPPT As PettyCashReceiptPPT) As Integer
        Dim objPettyCashDAL As New PettyCashReceiptDAL
        Return objPettyCashDAL.DeletePettyCashDetail(objPettyCashPPT)
    End Function
End Class

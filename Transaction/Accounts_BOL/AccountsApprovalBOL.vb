Imports Accounts_PPT
Imports Accounts_DAL

Public Class AccountsApprovalBOL
    Public Function ApprovalGetPettyCashPayment(ByVal objPettyPayment As AccountsApprovalPPT) As DataTable
        Dim objPettyCashPayment As New AccountsApprovalDAL
        Return objPettyCashPayment.ApprovalGetPettyCashPayment(objPettyPayment)
    End Function
    Public Function ApprovalGetPettyCashReceipt(ByVal objPettyReceipt As AccountsApprovalPPT) As DataTable
        Dim objPettyCashReceipt As New AccountsApprovalDAL
        Return objPettyCashReceipt.ApprovalGetPettyCashReceipt(objPettyReceipt)
    End Function
    Public Function ApprovalGetJournal(ByVal objjrnal As AccountsApprovalPPT) As DataTable
        Dim objJournal As New AccountsApprovalDAL
        Return objJournal.ApprovalGetJournal(objjrnal)
    End Function
    Public Function GetLedgerType(ByVal objLedgerType As AccountsApprovalPPT) As DataTable
        Dim objPettyCashReceipt As New AccountsApprovalDAL
        Return objPettyCashReceipt.GetLedgerType(objLedgerType)
    End Function
    Public Function LedgerNoSearch(ByVal objjrnal As AccountsApprovalPPT, ByVal IsDirect As String) As DataTable
        Return AccountsApprovalDAL.LedgerNoSearch(objjrnal, IsDirect)
    End Function

    ''For Approval

    Public Function JournalLedgerAllModuleInsert(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As DataSet
        Return AccountsApprovalDAL.JournalLedgerAllModuleInsert(objAccountsApprovalPPT)
    End Function
    Public Shared Function AccountsJournalDetailInsert(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Integer
        Return AccountsApprovalDAL.AccountsJournalDetailInsert(objAccountsApprovalPPT)
    End Function

    Public Shared Function AccountsVHChargeDetailInsert(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Integer
        Return AccountsApprovalDAL.AccountsVHChargeDetailInsert(objAccountsApprovalPPT)
    End Function

    Public Function GLLedgerCOAIDIsExist(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Object
        Dim objAccountsApprovalDAL As New AccountsApprovalDAL
        Return objAccountsApprovalDAL.GLLedgerCOAIDIsExist(objAccountsApprovalPPT)
    End Function
    Public Function JournalGLLedgerSelect(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As DataTable
        Dim objAccountsApprovalDAL As New AccountsApprovalDAL
        Return objAccountsApprovalDAL.JournalGLLedgerSelect(objAccountsApprovalPPT)
    End Function
    Public Shared Function JournalGLLedgerUpdate(ByVal objAccountsApprovalPPT As JournalPPT) As Integer
        Return AccountsApprovalDAL.JournalGLLedgerUpdate(objAccountsApprovalPPT)
    End Function
    Public Shared Function AccountsGLLedgerInsert(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Integer
        Return AccountsApprovalDAL.AccountsGLLedgerInsert(objAccountsApprovalPPT)
    End Function
    Public Shared Function AccountsGLSubInsert(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Integer
        Return AccountsApprovalDAL.AccountsGLSubInsert(objAccountsApprovalPPT)
    End Function
    Public Shared Function AccountsBlockMasterHistoryInsert(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Integer
        Return AccountsApprovalDAL.AccountsBlockMasterHistoryInsert(objAccountsApprovalPPT)
    End Function

    Public Function GLLedgerBlockIDIsExist(ByVal objAccountsApprovalPPT As JournalPPT) As Object
        Dim objAccountsApprovalDAL As New AccountsApprovalDAL
        Return objAccountsApprovalDAL.GLSubBlockIDIsExist(objAccountsApprovalPPT)
    End Function
    Public Function JournalGLSubSelect(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As DataTable
        Dim objAccountsApprovalDAL As New AccountsApprovalDAL
        Return objAccountsApprovalDAL.JournalGLSubSelect(objAccountsApprovalPPT)
    End Function
    Public Shared Function JournalGLSubUpdate(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As Integer
        Return AccountsApprovalDAL.JournalGLSubUpdate(objAccountsApprovalPPT)
    End Function

    Public Function GetPettyCashReceiptCOAID(ByVal objAccountsApprovalPPT As AccountsApprovalPPT) As DataTable
        Dim objPettyCashReceipt As New AccountsApprovalDAL
        Return objPettyCashReceipt.GetPettyCashReceiptCOAID(objAccountsApprovalPPT)
    End Function

End Class

Imports Accounts_PPT
Imports Accounts_DAL

Public Class JournalBOL

    Public Shared Function SaveJournal(ByVal objJournalPPT As JournalPPT) As DataSet
        Return JournalDAL.SaveJournal(objJournalPPT)
    End Function

    Public Shared Function UpDateJournal(ByVal objJournalPPT As JournalPPT) As DataSet
        Return JournalDAL.UpdateJournal(objJournalPPT)
    End Function

    Public Shared Function DeleteJournal(ByVal objJournalPPT As JournalPPT) As Integer
        Dim ObjJournalDAL As New JournalDAL
        Return ObjJournalDAL.DeleteJournal(objJournalPPT)
    End Function

    Public Shared Function GetJournal(ByVal objJournalPPT As JournalPPT) As DataTable
        Dim ObjJournalDAL As New JournalDAL
        Return ObjJournalDAL.GetJournal(objJournalPPT)
    End Function
    Public Shared Function GetMultipleEntryValue(ByVal objJournalPPT As JournalPPT) As DataTable
        Dim ObjJournalDAL As New JournalDAL
        Return ObjJournalDAL.GetMultipleEntryValue(objJournalPPT)
    End Function
    Public Shared Function GetCreditDebitAmount(ByVal objJournalPPT As JournalPPT) As DataSet
        Dim ObjJournalDAL As New JournalDAL
        Return ObjJournalDAL.GetCreditDebitAmount(objJournalPPT)
    End Function
    Public Function GetLedgerType(ByVal objJournalPPT As JournalPPT) As DataTable
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.GetLedgerType(objJournalPPT)
    End Function

    Public Function DuplicateJournalCheck(ByVal objJournalPPT As JournalPPT) As Object
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.DuplicateJournalCheck(objJournalPPT)
    End Function

    Public Function AcctlookupSearch(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.AcctlookupSearch(objJournalPPT, IsDirect)
    End Function

    Public Function LedgerNoSearch(ByVal objJournalPPT As JournalPPT) As DataSet
        Return JournalDAL.LedgerNoSearch(objJournalPPT)
    End Function

    Public Function ContractIDSearch(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.ContractIDSearch(objJournalPPT, IsDirect)
    End Function

    Public Function GetDIV(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.GetDIV(objJournalPPT, IsDirect)
    End Function

    Public Function GetYOP(ByVal objJournalPPT As JournalPPT) As DataSet
        Return JournalDAL.GetYOP(objJournalPPT)
    End Function

    Public Function GetSubBlock(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.GetSubBlock(objJournalPPT, IsDirect)
    End Function

    Public Function GetStation(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.GetStation(objJournalPPT, IsDirect)
    End Function

    Public Function GetVHNo(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.GetVHNo(objJournalPPT, IsDirect)
    End Function

    Public Function GetVHDetailsCostCode(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.GetVHDetailsCostCode(objJournalPPT, IsDirect)
    End Function

    Public Function TlookupSearch(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Return JournalDAL.TlookupSearch(objJournalPPT, IsDirect)
    End Function
    Public Shared Function EstateTypeSelect() As String
        Return JournalDAL.EstateTypeSelect()
    End Function

    '''Account Batch Entry
    Public Shared Function SaveAccountBatch(ByVal objLedgerBatch As JournalPPT) As Integer
        Return JournalDAL.SaveAccountBatch(objLedgerBatch)
    End Function

    Public Shared Function UpdateAccountBatch(ByVal objLedgerBatch As JournalPPT, ByVal IsApproval As String) As Integer
        Return JournalDAL.UpdateAccountBatch(objLedgerBatch, IsApproval)
    End Function

    Public Shared Function DeleteAccountBatch(ByVal objLedgerBatch As JournalPPT) As Integer
        Return JournalDAL.DeleteAccountBatch(objLedgerBatch)
    End Function
    ''For Approval

    Public Function JournalLedgerAllModuleInsert(ByVal objJournalPPT As JournalPPT) As DataSet
        Return JournalDAL.JournalLedgerAllModuleInsert(objJournalPPT)
    End Function
    Public Shared Function AccountsJournalDetailInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.AccountsJournalDetailInsert(objJournalPPT)
    End Function

    Public Shared Function AccountsVHChargeDetailInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.AccountsVHChargeDetailInsert(objJournalPPT)
    End Function

    Public Function GLLedgerCOAIDIsExist(ByVal objJournalPPT As JournalPPT) As Object
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.GLLedgerCOAIDIsExist(objJournalPPT)
    End Function
    Public Function VHChargedetailLocationEstateCodeSelect(ByVal objJournalPPT As JournalPPT) As DataSet
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.VHChargedetailLocationEstateCodeSelect(objJournalPPT)
    End Function
    Public Function JournalGLLedgerSelect(ByVal objJournalPPT As JournalPPT) As DataTable
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.JournalGLLedgerSelect(objJournalPPT)
    End Function
    Public Shared Function JournalGLLedgerUpdate(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.JournalGLLedgerUpdate(objJournalPPT)
    End Function
    Public Shared Function AccountsGLLedgerInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.AccountsGLLedgerInsert(objJournalPPT)
    End Function
    Public Shared Function AccountsGLSubInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.AccountsGLSubInsert(objJournalPPT)
    End Function
    Public Shared Function AccountsBlockMasterHistoryInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.AccountsBlockMasterHistoryInsert(objJournalPPT)
    End Function

    Public Function GLLedgerBlockIDIsExist(ByVal objJournalPPT As JournalPPT) As Object
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.GLSubBlockIDIsExist(objJournalPPT)
    End Function
    Public Function JournalGLSubSelect(ByVal objJournalPPT As JournalPPT) As DataTable
        Dim objJournalDAL As New JournalDAL
        Return objJournalDAL.JournalGLSubSelect(objJournalPPT)
    End Function
    Public Shared Function JournalGLSubUpdate(ByVal objJournalPPT As JournalPPT) As Integer
        Return JournalDAL.JournalGLSubUpdate(objJournalPPT)
    End Function


    '' Delete Multienty Journal Entry

    Public Shared Function DeleteMultiEntryJournal(ByVal objJournalPPT As JournalPPT) As Integer
        Dim ObjJournalDAL As New JournalDAL
        Return ObjJournalDAL.DeleteMultiEntryJournal(objJournalPPT)
    End Function

End Class

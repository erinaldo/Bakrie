Imports Accounts_DAL
Imports Accounts_PPT
Imports System.Data

Public Class LedgerSetupBOL

    Public Shared Function SaveLedgerSetup(ByVal objLedgerSetup As LedgerSetupPPT) As Integer
        Return Accounts_DAL.LedgerSetupDAL.saveLedgerSetup(objLedgerSetup)
    End Function

    Public Shared Function UpdateLedgerSetup(ByVal objLedgerSetup As LedgerSetupPPT) As Integer
        Return Accounts_DAL.LedgerSetupDAL.UpdateLedgerSetup(objLedgerSetup)
    End Function

    Public Shared Function BindDataGridView(ByVal objLedgerSetup As LedgerSetupPPT) As DataSet
        Return Accounts_DAL.LedgerSetupDAL.BindDataGridView(objLedgerSetup)
    End Function
    Public Shared Function DeleteLedgerSetup(ByVal objLedgerSetup As LedgerSetupPPT) As Integer
        Return Accounts_DAL.LedgerSetupDAL.DeleteLedgerSetup(objLedgerSetup)
    End Function
    Public Shared Function ChechDuplicateLedgerTypeExists(ByVal objLedgerSetup As LedgerSetupPPT) As Object
        Return Accounts_DAL.LedgerSetupDAL.ChechDuplicateLedgerTypeExists(objLedgerSetup)
    End Function

End Class

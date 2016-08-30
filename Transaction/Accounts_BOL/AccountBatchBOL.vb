Imports Accounts_DAL
Imports Accounts_PPT
Imports System.Data
Public Class AccountBatchBOL

    Public Shared Function SaveAccountBatch(ByVal objLedgerBatch As AccountBatchPPT) As Integer
        Return Accounts_DAL.AccountBatchDAL.SaveAccountBatch(objLedgerBatch)
    End Function

    Public Shared Function UpdateAccountBatch(ByVal objLedgerBatch As AccountBatchPPT) As Integer
        Return Accounts_DAL.AccountBatchDAL.UpdateAccountBatch(objLedgerBatch)
    End Function

    Public Shared Function BindDataGridView(ByVal objLedgerBatch As AccountBatchPPT) As DataSet
        Return Accounts_DAL.AccountBatchDAL.BindDataGridView(objLedgerBatch)
    End Function

    Public Shared Function DeleteAccountBatch(ByVal objLedgerBatch As AccountBatchPPT) As DataTable
        Return Accounts_DAL.AccountBatchDAL.DeleteAccountBatch(objLedgerBatch)
    End Function

    Public Shared Function ChechDuplicateLedgerTypeExists(ByVal objLedgerBatch As AccountBatchPPT) As DataTable
        Return Accounts_DAL.AccountBatchDAL.ChechDuplicateLedgerTypeExists(objLedgerBatch)
    End Function

    Public Shared Function LedgerTypeSearch(ByVal objLedgerBatch As AccountBatchPPT) As DataSet
        Return Accounts_DAL.AccountBatchDAL.LedgerTypeSearch(objLedgerBatch)
    End Function
End Class

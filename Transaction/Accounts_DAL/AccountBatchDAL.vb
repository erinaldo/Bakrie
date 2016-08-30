Imports Accounts_PPT
Imports System.Data.SqlClient
Imports Common_DAL
Imports Common_PPT


Public Class AccountBatchDAL
    Public Shared Function SaveAccountBatch(ByVal objAccountBatch As AccountBatchPPT) As Integer
        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@RecuringJournal", objAccountBatch.RecurringJournal)
        Parms(2) = New SqlParameter("@LedgerDescp", objAccountBatch.LedgerDescription)
        Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(7) = New SqlParameter("@LedgerSetupID", objAccountBatch.LedgerSetUpId)
        Parms(8) = New SqlParameter("@AccBatchID", objAccountBatch.AccBatchID)
        Parms(9) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(10) = New SqlParameter("@LedgerNo", objAccountBatch.LedgerNo)
        Parms(11) = New SqlParameter("@AccBatchTotal", objAccountBatch.AccBatchTotal)
        Parms(12) = New SqlParameter("@Approved", objAccountBatch.Approved)
        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[AccountBatchInsert]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function


    Public Shared Function UpdateAccountBatch(ByVal objAccountBatch As AccountBatchPPT) As Integer
        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerNo", objAccountBatch.LedgerNo)
        Parms(2) = New SqlParameter("@LedgerDescp", objAccountBatch.LedgerDescription)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(5) = New SqlParameter("@LedgerSetupID", objAccountBatch.LedgerSetUpId)
        Parms(6) = New SqlParameter("@AccBatchID", objAccountBatch.AccBatchID)
        Parms(7) = New SqlParameter("@ActiveMonthYearID", objAccountBatch.ActiveMonthYearID)
        Parms(8) = New SqlParameter("@RecuringJournal", objAccountBatch.RecurringJournal)
        Parms(9) = New SqlParameter("@AccBatchTotal", objAccountBatch.AccBatchTotal)
        Parms(10) = New SqlParameter("@Approved", objAccountBatch.Approved)
        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[AccountBatchUpdate]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function

    Public Shared Function DeleteAccountBatch(ByVal objAccountBatch As AccountBatchPPT) As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim dt As DataTable
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AccBatchID", objAccountBatch.AccBatchID)
        Parms(2) = New SqlParameter("@LedgerSetupID", objAccountBatch.LedgerSetUpId)

        dt = objSQLHelp.ExecQuery("[Accounts].[AccountBatchDelete]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function BindDataGridView(ByVal objAccountBatch As AccountBatchPPT) As DataSet
        Dim ds As New DataSet
        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerNo", objAccountBatch.LedgerNo)
        Parms(2) = New SqlParameter("@LedgerType", objAccountBatch.LedgerType)
        ds = objSQLHelp.ExecQuery("[Accounts].[AccountBatchSelect]", Parms)
        Return ds
    End Function

    Public Shared Function ChechDuplicateLedgerTypeExists(ByVal objAccountBatch As AccountBatchPPT) As DataTable

        Dim dt As DataTable
        Dim objSQLHelp As New SQLHelp
        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerNo", objAccountBatch.LedgerNo)
        If objAccountBatch.AccBatchID = String.Empty Then
            Parms(2) = New SqlParameter("@AccBatchID", DBNull.Value)
        End If
        dt = objSQLHelp.ExecQuery("[Accounts].[AccountBatchIsExist]", Parms).Tables(0)
        Return dt
    End Function


    Public Shared Function LedgerTypeSearch(ByVal objAccountBatch As AccountBatchPPT) As DataSet
        Dim ds As New DataSet
        Dim objSQLHelp As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerType", objAccountBatch.LedgerType)
        ds = objSQLHelp.ExecQuery("[Accounts].[AccountBatchSearchLedgerType]", Parms)
        Return ds
    End Function
End Class

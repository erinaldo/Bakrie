Imports Accounts_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class LedgerSetupDAL

    Public Shared Function SaveLedgerSetup(ByVal objLedgerSetup As LedgerSetupPPT) As Integer

        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(8) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerType", objLedgerSetup.Ledgertype)

        Parms(2) = New SqlParameter("@LedgerTypeDescp", objLedgerSetup.LedgerTypeDescp)
        Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)

        Parms(7) = New SqlParameter("@LedgerSetupID", objLedgerSetup.LedgerSetUpID)
        Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[LedgerSetupInsert]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If

    End Function


    Public Shared Function UpdateLedgerSetup(ByVal objLedgerSetup As LedgerSetupPPT) As Integer

        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerType", objLedgerSetup.Ledgertype)

        Parms(2) = New SqlParameter("@LedgerTypeDescp", objLedgerSetup.LedgerTypeDescp)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(5) = New SqlParameter("@LedgerSetupID", objLedgerSetup.LedgerSetUpID)
        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[LedgerSetupUpdate]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function

    Public Shared Function DeleteLedgerSetup(ByVal objLedgerSetup As LedgerSetupPPT) As Integer

        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerSetupID", objLedgerSetup.LedgerSetUpID)
        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[LedgerSetupDelete]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function

    Public Shared Function BindDataGridView(ByVal objLedgerSetup As LedgerSetupPPT) As DataSet

        Dim ds As New DataSet
        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
      

        ds = objSQLHelp.ExecQuery("[Accounts].[LedgerSetupSelectNew]", Parms)
        Return ds
    End Function

    Public Shared Function ChechDuplicateLedgerTypeExists(ByVal objLedgerSetup As LedgerSetupPPT) As Object


        Dim objSQLHelp As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerType", objLedgerSetup.Ledgertype)



        objExists = objSQLHelp.ExecuteScalar("[Accounts].[LedgerSetupIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
  
End Class

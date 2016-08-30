Imports System.Data.SqlClient
Imports Accounts_PPT
Imports Common_DAL
Imports Common_PPT

Public Class AccountsApprovalDAL

    Public Function ApprovalGetPettyCashPayment(ByVal ObjPettyCashPayment As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If ObjPettyCashPayment.VoucherNo <> String.Empty Then
            Parms(1) = New SqlParameter("@VoucherNo", ObjPettyCashPayment.VoucherNo)
        Else
            Parms(1) = New SqlParameter("@VoucherNo", DBNull.Value)
        End If

        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)


        dt = objdb.ExecQuery("[Accounts].[ApprovalPettyCashPaymentSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function ApprovalGetPettyCashReceipt(ByVal ObjPettyCashReceipt As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If ObjPettyCashReceipt.ReceiptNo <> String.Empty Then
            Parms(1) = New SqlParameter("@ReceiptNo", ObjPettyCashReceipt.ReceiptNo)
        Else
            Parms(1) = New SqlParameter("@ReceiptNo", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)


        dt = objdb.ExecQuery("[Accounts].[ApprovalPettyCashReceiptSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function ApprovalGetJournal(ByVal ObjJournal As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If ObjJournal.LedgerNo <> "" Then
            Parms(1) = New SqlParameter("@LedgerNo", ObjJournal.LedgerNo)
        Else
            Parms(1) = New SqlParameter("@LedgerNo", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        If ObjJournal.LedgerType <> "" Then
            Parms(3) = New SqlParameter("@LedgerType", ObjJournal.LedgerType)
        Else
            Parms(3) = New SqlParameter("@LedgerType", DBNull.Value)
        End If
        dt = objdb.ExecQuery("[Accounts].[ApprovalJournalSelect]", Parms).Tables(0)
        Return dt
    End Function
    Public Function GetLedgerType(ByVal ObjDistributionChargeCodeConfig As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Accounts].[JournalLedgerTypeValue]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function LedgerNoSearch(ByVal objJournal As AccountsApprovalPPT, ByVal IsDirect As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter

        If objJournal.LedgerNo <> "" Then
            Parms(0) = New SqlParameter("@LedgerNo", objJournal.LedgerNo)
        Else
            Parms(0) = New SqlParameter("@LedgerNo", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)

        dt = objdb.ExecQuery("[Accounts].[LedgerNoLookupSelect]", Parms).Tables(0)
        Return dt
    End Function


    ''''For Approval
    'Ledger All module Insert
    Public Shared Function JournalLedgerAllModuleInsert(ByVal objJournalPPT As AccountsApprovalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objJournalPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
        Parms(5) = New SqlParameter("@ModName", "ACCOUNTS")
        Parms(6) = New SqlParameter("@LedgerDate", objJournalPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objJournalPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", objJournalPPT.JournalDescp)
        Parms(9) = New SqlParameter("@BatchAmount", objJournalPPT.BatchTotal)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(15) = New SqlParameter("@LedgerNo", objJournalPPT.LedgerNo)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_Journal]", Parms)
        Return ds
    End Function
    '''JournalDetailInsert
    Public Shared Function AccountsJournalDetailInsert(ByVal objJournalPPT As AccountsApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(24) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@LedgerID", objJournalPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objJournalPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objJournalPPT.DC)
            Parms(6) = New SqlParameter("@Value", objJournalPPT.Value)
            Parms(7) = New SqlParameter("@DivID", IIf(objJournalPPT.DivID <> String.Empty, objJournalPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objJournalPPT.YOPID <> String.Empty, objJournalPPT.YOPID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objJournalPPT.VHID <> String.Empty, objJournalPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objJournalPPT.VHDetailcostCodeID <> String.Empty, objJournalPPT.VHDetailcostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objJournalPPT.T0 <> String.Empty, objJournalPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objJournalPPT.T1 <> String.Empty, objJournalPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objJournalPPT.T2 <> String.Empty, objJournalPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objJournalPPT.T3 <> String.Empty, objJournalPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objJournalPPT.T4 <> String.Empty, objJournalPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objJournalPPT.COADescp <> String.Empty, objJournalPPT.COADescp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objJournalPPT.Flag <> String.Empty, objJournalPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objJournalPPT.StationID <> String.Empty, objJournalPPT.StationID, DBNull.Value))

            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function

    ''VHChargeDetail Insert 

    Public Shared Function AccountsVHChargeDetailInsert(ByVal objJournalPPT As AccountsApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(18) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateCodeL", GlobalPPT.strEstateCode)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@VHWSCode", objJournalPPT.VHWScode)
            Parms(5) = New SqlParameter("@Value", objJournalPPT.Value)
            Parms(6) = New SqlParameter("@VHDetailCostCode", objJournalPPT.VHDetailCostCode)
            Parms(7) = New SqlParameter("@ModName", "ACCOUNTS")
            Parms(8) = New SqlParameter("@LedgerType", objJournalPPT.LedgerType)
            Parms(9) = New SqlParameter("@LedgerNo", objJournalPPT.LedgerNo)
            Parms(10) = New SqlParameter("@JDescp", objJournalPPT.JournalDescp)
            Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(12) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(14) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(15) = New SqlParameter("@Type", objJournalPPT.Type)
            Parms(16) = New SqlParameter("@UOMID", objJournalPPT.UOMID)
            Parms(17) = New SqlParameter("@QtyUsed", objJournalPPT.Qty)
            Parms(18) = New SqlParameter("@RefNo", objJournalPPT.RefNo)

            objdb.ExecNonQuery("[Vehicle].[JournalVhChargeDetailInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function
    '''GLLedger Insert, Update
    Public Function GLLedgerCOAIDIsExist(ByVal ObjJournalPPT As AccountsApprovalPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", ObjJournalPPT.COAID)
        Parms(2) = New SqlParameter("@Ayear", ObjJournalPPT.AYear)

        objExists = objdb.ExecuteScalar("[Accounts].[GLLedgerCOAIDIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function JournalGLLedgerSelect(ByVal ObjJournalPPT As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", ObjJournalPPT.COAID)
        Parms(2) = New SqlParameter("@AYear", ObjJournalPPT.AYear)
        dt = objdb.ExecQuery("[Accounts].[JournalGLLedgerSelect]", Parms).Tables(0)
        Return dt
    End Function


    Public Shared Function AccountsGLLedgerInsert(ByVal objJournalPPT As AccountsApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(11) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@COAID", objJournalPPT.COAID)
            Parms(5) = New SqlParameter("@Debit", IIf(objJournalPPT.Debit <> 0, objJournalPPT.Debit, DBNull.Value))
            Parms(6) = New SqlParameter("@Credit", IIf(objJournalPPT.Credit <> 0, objJournalPPT.Credit, DBNull.Value))
            Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(11) = New SqlParameter("@MonthValue", objJournalPPT.MonthCalculation)


            objdb.ExecNonQuery("[Accounts].[JournalGLLedgerInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function
    Public Shared Function JournalGLLedgerUpdate(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@GLLedgerID", DBNull.Value)
            Parms(1) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(2) = New SqlParameter("@MonthCalculation", objJournalPPT.MonthCalculation)
            Parms(3) = New SqlParameter("@UpdateDebitCalc", IIf(objJournalPPT.UpdateDebitCalc <> 0, objJournalPPT.UpdateDebitCalc, DBNull.Value))
            Parms(4) = New SqlParameter("@UpdateCreditCalc", IIf(objJournalPPT.UpdateCreditCalc <> 0, objJournalPPT.UpdateCreditCalc, DBNull.Value))
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(6) = New SqlParameter("@COAID", objJournalPPT.COAID)

            objdb.ExecNonQuery("[Accounts].[JournalGLLedgerUpdate]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function


    '''GLSub Insert

    Public Function GLSubBlockIDIsExist(ByVal ObjJournalPPT As JournalPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BlockID", ObjJournalPPT.BlockID)
        Parms(2) = New SqlParameter("@Ayear", ObjJournalPPT.AYear)
        Parms(3) = New SqlParameter("@DivID", ObjJournalPPT.DivID)
        Parms(4) = New SqlParameter("@COAID", ObjJournalPPT.COAID)


        objExists = objdb.ExecuteScalar("[Accounts].[GLSubBlockIDIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function JournalGLSubSelect(ByVal ObjJournalPPT As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BlockID", ObjJournalPPT.BlockID)
        Parms(2) = New SqlParameter("@AYear", ObjJournalPPT.AYear)
        dt = objdb.ExecQuery("[Accounts].[JournalGLSubSelect]", Parms).Tables(0)
        Return dt
    End Function


    Public Shared Function AccountsGLSubInsert(ByVal objJournalPPT As AccountsApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(14) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@COAID", objJournalPPT.COAID)
            Parms(5) = New SqlParameter("@Debit", IIf(objJournalPPT.Debit <> 0, objJournalPPT.Debit, DBNull.Value))
            Parms(6) = New SqlParameter("@Credit", IIf(objJournalPPT.Credit <> 0, objJournalPPT.Credit, DBNull.Value))
            Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(11) = New SqlParameter("@DivID", IIf(objJournalPPT.DivID <> String.Empty, objJournalPPT.DivID, DBNull.Value))
            Parms(12) = New SqlParameter("@YOPID", IIf(objJournalPPT.YOPID <> String.Empty, objJournalPPT.YOPID, DBNull.Value))
            Parms(13) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))
            Parms(14) = New SqlParameter("@MonthValue", objJournalPPT.MonthCalculation)
            objdb.ExecNonQuery("[Accounts].[JournalGLSubInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function

    Public Shared Function JournalGLSubUpdate(ByVal objJournalPPT As AccountsApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(5) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@GLSubID", objJournalPPT.GLSubID)
            Parms(1) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(2) = New SqlParameter("@MonthCalculation", objJournalPPT.MonthCalculation)
            Parms(3) = New SqlParameter("@UpdateDebitCalc", IIf(objJournalPPT.UpdateDebitCalc <> 0, objJournalPPT.UpdateDebitCalc, DBNull.Value))
            Parms(4) = New SqlParameter("@UpdateCreditCalc", IIf(objJournalPPT.UpdateCreditCalc <> 0, objJournalPPT.UpdateCreditCalc, DBNull.Value))
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today())

            objdb.ExecNonQuery("[Accounts].[JournalGLSubUpdate]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function
    '''BlockMasterHistoryInsert
    ''' 
    Public Shared Function AccountsBlockMasterHistoryInsert(ByVal objJournalPPT As AccountsApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(10) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(8) = New SqlParameter("@DivID", IIf(objJournalPPT.DivID <> String.Empty, objJournalPPT.DivID, DBNull.Value))
            Parms(9) = New SqlParameter("@YOPID", IIf(objJournalPPT.YOPID <> String.Empty, objJournalPPT.YOPID, DBNull.Value))
            Parms(10) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))


            objdb.ExecNonQuery("[Accounts].[BlockMasterHistoryInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function

    Public Function GetPettyCashReceiptCOAID(ByVal ObjDistributionChargeCodeConfig As AccountsApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Accounts].[PettyCashReceiptCOAIDSelect]", Parms).Tables(0)
        Return dt
    End Function
End Class

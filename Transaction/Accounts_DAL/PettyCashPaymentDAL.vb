Imports System.Data.SqlClient
Imports Accounts_PPT
Imports Common_DAL
Imports Common_PPT

Public Class PettyCashPaymentDAL
    Public Shared Function DeleteMultiEntryPettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PaymentID", ObjPettyCashPaymentPPT.PaymentID)

        rowsAffected = objdb.ExecNonQuery("[Accounts].[PettyCashPaymentMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function
    Public Shared Function SavePettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(26) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VoucherDate", ObjPettyCashPaymentPPT.VoucherDate)
        Parms(3) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)
        Parms(4) = New SqlParameter("@PayToID", ObjPettyCashPaymentPPT.PayToID)
        Parms(5) = New SqlParameter("@PayDescp", ObjPettyCashPaymentPPT.PayDescp)
        Parms(6) = New SqlParameter("@DiscrepancyTransaction", ObjPettyCashPaymentPPT.DiscrepancyTransaction)
        Parms(7) = New SqlParameter("@COAID", IIf(ObjPettyCashPaymentPPT.COAID <> String.Empty, ObjPettyCashPaymentPPT.COAID, DBNull.Value))
        Parms(8) = New SqlParameter("@T0", IIf(ObjPettyCashPaymentPPT.T0 <> String.Empty, ObjPettyCashPaymentPPT.T0, DBNull.Value))
        Parms(9) = New SqlParameter("@T1", IIf(ObjPettyCashPaymentPPT.T1 <> String.Empty, ObjPettyCashPaymentPPT.T1, DBNull.Value))
        Parms(10) = New SqlParameter("@T2", IIf(ObjPettyCashPaymentPPT.T2 <> String.Empty, ObjPettyCashPaymentPPT.T2, DBNull.Value))
        Parms(11) = New SqlParameter("@T3", IIf(ObjPettyCashPaymentPPT.T3 <> String.Empty, ObjPettyCashPaymentPPT.T3, DBNull.Value))
        Parms(12) = New SqlParameter("@T4", IIf(ObjPettyCashPaymentPPT.T4 <> String.Empty, ObjPettyCashPaymentPPT.T4, DBNull.Value))
        Parms(13) = New SqlParameter("@Amount", ObjPettyCashPaymentPPT.Amount)
        Parms(14) = New SqlParameter("@Remarks", ObjPettyCashPaymentPPT.Remarks)
        Parms(15) = New SqlParameter("@Approved", ObjPettyCashPaymentPPT.Approved)
        Parms(16) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(17) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(20) = New SqlParameter("@Qty", IIf(ObjPettyCashPaymentPPT.Qty <> 0, ObjPettyCashPaymentPPT.Qty, DBNull.Value))
        Parms(21) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(22) = New SqlParameter("@UOMID", IIf(ObjPettyCashPaymentPPT.UOMID <> String.Empty, ObjPettyCashPaymentPPT.UOMID, DBNull.Value))
        Parms(23) = New SqlParameter("@PaidTo", ObjPettyCashPaymentPPT.PaidTo)
        Parms(24) = New SqlParameter("@TransactionType", ObjPettyCashPaymentPPT.DC)
        Parms(25) = New SqlParameter("@VHID", ObjPettyCashPaymentPPT.VHID)
        Parms(26) = New SqlParameter("@VHDetailCostCodeId", ObjPettyCashPaymentPPT.VHDetailCostCodeID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentInsert]", Parms)
        Return ds

    End Function

    Public Shared Function UpdatePettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT, ByVal IsApproval As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(27) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VoucherDate", ObjPettyCashPaymentPPT.VoucherDate)
        Parms(3) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)
        Parms(4) = New SqlParameter("@PayToID", ObjPettyCashPaymentPPT.PayToID)
        Parms(5) = New SqlParameter("@PayDescp", ObjPettyCashPaymentPPT.PayDescp)
        Parms(6) = New SqlParameter("@DiscrepancyTransaction", ObjPettyCashPaymentPPT.DiscrepancyTransaction)
        Parms(7) = New SqlParameter("@COAID", IIf(ObjPettyCashPaymentPPT.COAID <> String.Empty, ObjPettyCashPaymentPPT.COAID, DBNull.Value))
        Parms(8) = New SqlParameter("@T0", IIf(ObjPettyCashPaymentPPT.T0 <> String.Empty, ObjPettyCashPaymentPPT.T0, DBNull.Value))
        Parms(9) = New SqlParameter("@T1", IIf(ObjPettyCashPaymentPPT.T1 <> String.Empty, ObjPettyCashPaymentPPT.T1, DBNull.Value))
        Parms(10) = New SqlParameter("@T2", IIf(ObjPettyCashPaymentPPT.T2 <> String.Empty, ObjPettyCashPaymentPPT.T2, DBNull.Value))
        Parms(11) = New SqlParameter("@T3", IIf(ObjPettyCashPaymentPPT.T3 <> String.Empty, ObjPettyCashPaymentPPT.T3, DBNull.Value))
        Parms(12) = New SqlParameter("@T4", IIf(ObjPettyCashPaymentPPT.T4 <> String.Empty, ObjPettyCashPaymentPPT.T4, DBNull.Value))
        Parms(13) = New SqlParameter("@Amount", ObjPettyCashPaymentPPT.Amount)
        Parms(14) = New SqlParameter("@Remarks", ObjPettyCashPaymentPPT.Remarks)
        Parms(15) = New SqlParameter("@Approved", ObjPettyCashPaymentPPT.Approved)
        Parms(16) = New SqlParameter("@Qty", IIf(ObjPettyCashPaymentPPT.Qty <> 0, ObjPettyCashPaymentPPT.Qty, DBNull.Value))
        Parms(17) = New SqlParameter("@PaymentID", ObjPettyCashPaymentPPT.PaymentID)
        Parms(18) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(19) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(20) = New SqlParameter("@IsApproval", IsApproval)
        Parms(21) = New SqlParameter("@RejectedReason", IIf(ObjPettyCashPaymentPPT.RejectedReason <> String.Empty, ObjPettyCashPaymentPPT.RejectedReason, DBNull.Value))
        Parms(22) = New SqlParameter("@UOMID", IIf(ObjPettyCashPaymentPPT.UOMID <> String.Empty, ObjPettyCashPaymentPPT.UOMID, DBNull.Value))
        Parms(23) = New SqlParameter("@ApprovalDate", IIf(ObjPettyCashPaymentPPT.ApprovalDate <> "1900/01/01", ObjPettyCashPaymentPPT.ApprovalDate, DBNull.Value))
        Parms(24) = New SqlParameter("@PaidTo", ObjPettyCashPaymentPPT.PaidTo)
        Parms(25) = New SqlParameter("@TransactionType", ObjPettyCashPaymentPPT.DC)
        Parms(26) = New SqlParameter("@VHID", ObjPettyCashPaymentPPT.VHID)
        Parms(27) = New SqlParameter("@VHDetailCostCodeId", ObjPettyCashPaymentPPT.VHDetailCostCodeID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentUpdate]", Parms)
        Return ds

    End Function


    Public Function DeletePettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)
        rowsAffected = objdb.ExecNonQuery("[Accounts].[PettyCashPaymentDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Function GetPettyCashPayment(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)
        Parms(2) = New SqlParameter("@VoucherDate", ObjPettyCashPaymentPPT.lVoucherDate)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@Status", ObjPettyCashPaymentPPT.Approved)


        dt = objdb.ExecQuery("[Accounts].[PettyCashPaymentSelect_New]", Parms).Tables(0)
        Return dt
    End Function
    Public Function GetValueMultipleEntry(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Accounts].[PettyCashPaymentSelect_MultipleEntry]", Parms).Tables(0)
        Return dt
    End Function


    Public Function DuplicatePettycashPaymentCheck(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
      Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)

        objExists = objdb.ExecuteScalar("[Accounts].[PettyCashPaymentIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Function GetPayToValue(ByVal ObjDistributionChargeCodeConfig As PettyCashPaymentPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[General].[PettyCashPaymentPaytoValue]", Parms).Tables(0)
        Return ds
    End Function

    Public Shared Function AcctlookupSearch(ByVal objPetttyCashPayment As PettyCashPaymentPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objPetttyCashPayment.COACode <> "" And objPetttyCashPayment.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objPetttyCashPayment.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objPetttyCashPayment.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objPetttyCashPayment.COACode <> "" And objPetttyCashPayment.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objPetttyCashPayment.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objPetttyCashPayment.COACode = "" And objPetttyCashPayment.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objPetttyCashPayment.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)

    End Function

    Public Shared Function TlookupSearch(ByVal objPetttyCashPayment As PettyCashPaymentPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)
        If objPetttyCashPayment.TDecide = "T0" Then
            If objPetttyCashPayment.T0Value <> "" And objPetttyCashPayment.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objPetttyCashPayment.T0Value <> "" And objPetttyCashPayment.T0Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objPetttyCashPayment.T0Value = "" And objPetttyCashPayment.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objPetttyCashPayment.TDecide = "T1" Then
            If objPetttyCashPayment.T1Value <> "" And objPetttyCashPayment.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objPetttyCashPayment.T1Value <> "" And objPetttyCashPayment.T1Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objPetttyCashPayment.T1Value = "" And objPetttyCashPayment.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objPetttyCashPayment.TDecide = "T2" Then
            If objPetttyCashPayment.T2Value <> "" And objPetttyCashPayment.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objPetttyCashPayment.T2Value <> "" And objPetttyCashPayment.T2Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objPetttyCashPayment.T2Value = "" And objPetttyCashPayment.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objPetttyCashPayment.TDecide = "T3" Then
            If objPetttyCashPayment.T3Value <> "" And objPetttyCashPayment.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objPetttyCashPayment.T3Value <> "" And objPetttyCashPayment.T3Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objPetttyCashPayment.T3Value = "" And objPetttyCashPayment.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objPetttyCashPayment.TDecide = "T4" Then
            If objPetttyCashPayment.T4Value <> "" And objPetttyCashPayment.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objPetttyCashPayment.T4Value <> "" And objPetttyCashPayment.T4Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", objPetttyCashPayment.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objPetttyCashPayment.T4Value = "" And objPetttyCashPayment.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objPetttyCashPayment.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objPetttyCashPayment.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        Return objdb.ExecQuery("[Store].[StoreIssueVoucherTAnalysisSelect]", Parms)
    End Function
    ''''For Approval

    Public Shared Function PCPLedgerAllModuleInsert(ByVal objPCPPPT As PettyCashPaymentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objPCPPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objPCPPPT.AMonth)
        Parms(5) = New SqlParameter("@ModName", "ACCOUNTS")
        Parms(6) = New SqlParameter("@LedgerDate", objPCPPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objPCPPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", IIf(objPCPPPT.Descp <> String.Empty, objPCPPPT.Descp, DBNull.Value))
        Parms(9) = New SqlParameter("@BatchAmount", DBNull.Value)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms)
        Return ds
    End Function

    Public Shared Function UOMLookupSearch(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        If ObjPettyCashPaymentPPT.UOM <> "" Then
            Parms(0) = New SqlParameter("@UOM", ObjPettyCashPaymentPPT.UOM)
        Else
            Parms(0) = New SqlParameter("@UOM", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@IsDirect", IsDirect)

        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentUOMSelect]", Parms)
        Return ds
    End Function
    Public Function GetPettyCashPaymentForReport(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VoucherNo", ObjPettyCashPaymentPPT.VoucherNo)
        Parms(2) = New SqlParameter("@VoucherDate", ObjPettyCashPaymentPPT.lVoucherDate)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@Status", ObjPettyCashPaymentPPT.Approved)


        dt = objdb.ExecQuery("[Accounts].[PettyCashPaymentSelectForReport]", Parms).Tables(0)
        Return dt

    End Function


    Public Shared Function PettyCashPaymentAmountCheck(ByVal ObjPettyCashPaymentPPT As PettyCashPaymentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentAmountCheck]", Parms)
        Return ds
    End Function

    '''Delete Multi entry Datagrid
    '''


End Class

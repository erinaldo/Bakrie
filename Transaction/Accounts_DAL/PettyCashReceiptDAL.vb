Imports System.Data.SqlClient
Imports Accounts_PPT
Imports Common_DAL
Imports Common_PPT
Public Class PettyCashReceiptDAL
    Public Shared Function savePettyCashReceipt(ByVal objPettyCashPPT As PettyCashReceiptPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(13) As SqlParameter
        ' Parms(0) = New SqlParameter("@STAdjustmentID", )
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@ReceiptDescp", objPettyCashPPT.ReceiptDesc)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@ReceiptNo", objPettyCashPPT.ReceiptNo)
        Parms(5) = New SqlParameter("@ReconcilationDate", objPettyCashPPT.ReconcilationDate)
        Parms(6) = New SqlParameter("@Amount", objPettyCashPPT.Amount)
        'Parms(6) = New SqlParameter("@Approved", objPettyCashPPT.a)
        Parms(7) = New SqlParameter("@ReceiptDate", objPettyCashPPT.ReceiptDate)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn ", Date.Today)
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(12) = New SqlParameter("@Approved", objPettyCashPPT.Approved)
        Parms(13) = New SqlParameter("@ReceivedFrom", objPettyCashPPT.ReceivedFrom)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[PettyCashReceiptInsert]", Parms)
        Return ds
    End Function
    Public Function GetPettyCashDetails(ByVal objPettyCashPPT As PettyCashReceiptPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        'If objIPRPPT.IPRNo <> "" Then

        params(0) = New SqlParameter("@ReceiptDate", IIf(objPettyCashPPT.ReceiptDate <> Nothing, objPettyCashPPT.ReceiptDate, DBNull.Value)) 'objIPRPPT.IPRdate)
        params(1) = New SqlParameter("@ReceiptNo", IIf(objPettyCashPPT.ReceiptNo <> "", objPettyCashPPT.ReceiptNo, DBNull.Value))
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(3) = New SqlParameter("@Status", objPettyCashPPT.Approved)

        dt = objdb.ExecQuery("[Accounts].[PettyCashViewSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function DeletePettyCashDetail(ByVal objPettyCashPPT As PettyCashReceiptPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Dim rowsAffected As Integer = 0
        Parms(0) = New SqlParameter("@ReceiptID", objPettyCashPPT.AccReceiptID)
        rowsAffected = objdb.ExecNonQuery("[Accounts].[PettyCashReceiptDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Function UpdateReceipt(ByVal objPettyCashPPT As PettyCashReceiptPPT, ByVal IsApproval As String) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ReceiptDescp", objPettyCashPPT.ReceiptDesc)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ReceiptNo", objPettyCashPPT.ReceiptNo)
        Parms(4) = New SqlParameter("@CashReconcilationDate", IIf(objPettyCashPPT.ReconcilationDate <> Nothing, objPettyCashPPT.ReconcilationDate, DBNull.Value))
        Parms(5) = New SqlParameter("@Amount", objPettyCashPPT.Amount)
        Parms(6) = New SqlParameter("@ReceiptDate", IIf(objPettyCashPPT.ReceiptDate <> Nothing, objPettyCashPPT.ReceiptDate, DBNull.Value))
        Parms(7) = New SqlParameter("@ReceiptID", objPettyCashPPT.AccReceiptID)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(9) = New SqlParameter("@Approved ", objPettyCashPPT.Approved)
        Parms(10) = New SqlParameter("@IsApproval ", IsApproval)
        Parms(11) = New SqlParameter("@RejectedReason ", IIf(objPettyCashPPT.RejectedReason <> "", objPettyCashPPT.RejectedReason, DBNull.Value))
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ReceivedFrom", objPettyCashPPT.ReceivedFrom)

        rowsAffected = objdb.ExecNonQuery("[Accounts].[PettyCashReceiptUpdate]", Parms)
        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function

    Public Function DuplicatePettycashReceiptCheck(ByVal objPettyCashPPT As PettyCashReceiptPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ReceiptNo", objPettyCashPPT.ReceiptNo)

        objExists = objdb.ExecuteScalar("[Accounts].[PettyCashRecieptIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

End Class

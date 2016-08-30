Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class StandardPinkSlipDAL
    Public Shared Function PinkSlipInsert(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim Param(9) As SqlParameter

        Param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Param(1) = New SqlParameter("@RefNo", oStandardPinkSlipPPT.RefNo)

        Param(2) = New SqlParameter("@DateRequest", oStandardPinkSlipPPT.DateRequest)
        'Param(2) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)

        'Param(4) = New SqlParameter("@RequestedAmt", oStandardPinkSlipPPT.RequestedAmt)
        If oStandardPinkSlipPPT.RejectedReason <> String.Empty Then
            Param(3) = New SqlParameter("@RejectedReason", oStandardPinkSlipPPT.RejectedReason)
        Else
            Param(3) = New SqlParameter("@RejectedReason", System.DBNull.Value)
        End If
        'Param(3) = New SqlParameter("@RejectedReason", oStandardPinkSlipPPT.Reason)
        Param(4) = New SqlParameter("@Status", oStandardPinkSlipPPT.Status)
        'Param(7) = New SqlParameter("@ApprovedAmt", oStandardPinkSlipPPT.RequestedAmt)

        Param(5) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Param(6) = New SqlParameter("@CreatedOn", Date.Today())
        Param(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(8) = New SqlParameter("@ModifiedOn", Date.Today())
        Param(9) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Budget].[PinkSlipInsert]", Param)
        Return ds
    End Function
    Public Shared Function PinkSlipDetailInsert(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim Param(12) As SqlParameter

        Param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Param(1) = New SqlParameter("@PinkSlipId ", oStandardPinkSlipPPT.PinkSlipId)
        'Param(2) = New SqlParameter("@DateRequest", oStandardPinkSlipPPT.DateRequest)
        Param(2) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)
        'Param(3) = New SqlParameter("@RefNo", oStandardPinkSlipPPT.RefNo)

        Param(3) = New SqlParameter("@RequestedAmt", oStandardPinkSlipPPT.RequestedAmt)
        Param(4) = New SqlParameter("@BudgetAmount", oStandardPinkSlipPPT.BudgetAmount)
        Param(5) = New SqlParameter("@ActualToDate", oStandardPinkSlipPPT.ActualToDate)
        Param(6) = New SqlParameter("@ApprovedAmt", oStandardPinkSlipPPT.RequestedAmt)
        Param(7) = New SqlParameter("@Reason", oStandardPinkSlipPPT.Reason)
        'Param(6) = New SqlParameter("@Status", oStandardPinkSlipPPT.Status)


        Param(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Param(9) = New SqlParameter("@CreatedOn", Date.Today())
        Param(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Param(12) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Budget].[PinkSlipDetailInsert]", Param)
        Return ds
    End Function

    Public Shared Function PinkSlipSelect(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(1) As SqlParameter
        'param(0) = New SqlParameter("@PinkSlipId ", oStandardPinkSlipPPT.PinkSlipId)
        'param(0) = New SqlParameter(" @RefNo", oStandardPinkSlipPPT.RefNo)
        'param(1) = New SqlParameter("@COACode", oStandardPinkSlipPPT.COACode)
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("BudgetYear", GlobalPPT.intLoginYear)
        dt = objdb.ExecQuery("[Budget].[PinkSlipSelect]", param).Tables(0)
        Return dt

    End Function

    Public Shared Function PinkSlipUpdate(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim param(6) As SqlParameter
        param(0) = New SqlParameter("@PinkSlipId", oStandardPinkSlipPPT.PinkSlipId)
        param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'param(1) = New SqlParameter("@RefNo", oStandardPinkSlipPPT.RefNo)
        param(2) = New SqlParameter("@DateRequest", oStandardPinkSlipPPT.DateRequest)
        'param(3) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)
        'param(4) = New SqlParameter("@RequestedAmt", oStandardPinkSlipPPT.RequestedAmt)
        'param(5) = New SqlParameter("@Reason", oStandardPinkSlipPPT.Reason)
        If oStandardPinkSlipPPT.RejectedReason <> String.Empty Then
            param(3) = New SqlParameter("@RejectedReason", oStandardPinkSlipPPT.RejectedReason)
        Else
            param(3) = New SqlParameter("@RejectedReason", System.DBNull.Value)
        End If
        If oStandardPinkSlipPPT.Status <> String.Empty Then
            param(4) = New SqlParameter("@Status", oStandardPinkSlipPPT.Status)
        Else
            param(4) = New SqlParameter("@Status", System.DBNull.Value)
        End If
        'param(5) = New SqlParameter("@Status", oStandardPinkSlipPPT.Status)
        'param(6) = New SqlParameter("@ApprovedAmt", oStandardPinkSlipPPT.ApprovedAmt)
        'param(9) = New SqlParameter("BDGYear", GlobalPPT.strActMthYearID)
        param(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(6) = New SqlParameter("@ModifiedOn", Date.Today())
      

        ds = objdb.ExecQuery("[Budget].[PinkSlipUpdate]", param)

        Return ds
    End Function
    Public Shared Function PinkSlipDetailUpdate(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(10) As SqlParameter
        param(0) = New SqlParameter("@PinkSlipDetailId", oStandardPinkSlipPPT.PinkSlipDetailId)
        param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(2) = New SqlParameter("@PinkSlipId", oStandardPinkSlipPPT.PinkSlipId)
        param(3) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)



        param(4) = New SqlParameter("@RequestedAmt", oStandardPinkSlipPPT.RequestedAmt)
        param(5) = New SqlParameter("@Reason", oStandardPinkSlipPPT.Reason)
        param(6) = New SqlParameter("@ApprovedAmt", oStandardPinkSlipPPT.RequestedAmt)
        param(7) = New SqlParameter("@BudgetAmount", oStandardPinkSlipPPT.BudgetAmount)
        param(8) = New SqlParameter("@ActualToDate", oStandardPinkSlipPPT.ActualToDate)
        param(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(10) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[PinkSlipDetailUpdate]", param)
        Return ds

    End Function
  

    Public Shared Function AcctlookupSearch(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oStandardPinkSlipPPT.COACode <> "" And oStandardPinkSlipPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oStandardPinkSlipPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oStandardPinkSlipPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oStandardPinkSlipPPT.COACode <> "" And oStandardPinkSlipPPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oStandardPinkSlipPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oStandardPinkSlipPPT.COACode = "" And oStandardPinkSlipPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oStandardPinkSlipPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Param(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Param)

    End Function

    Public Function GetPinkslipRefNo(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As StandardPinkSlipPPT
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Budget].[PinkSlipRefNoGET]", Parms)

        Dim PinkSlipPPT As StandardPinkSlipPPT = New StandardPinkSlipPPT
        If ds.Tables(0).Rows.Count <> 0 Then
            PinkSlipPPT.RefNo = ds.Tables(0).Rows(0).Item("PinkSlipRefNO").ToString.Trim
        End If
        Return PinkSlipPPT

    End Function


    Public Shared Function PinkSlipDelete(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As Integer
        Dim objdb As New SQLHelp
        Dim param(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        param(0) = New SqlParameter("@PinkSlipId ", oStandardPinkSlipPPT.PinkSlipId)

        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        rowsAffected = objdb.ExecNonQuery("[Budget].[PinkSlipDelete]", param)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Shared Function PinkSlipDetailDelete(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As Integer
        Dim objdb As New SQLHelp
        Dim param(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        param(0) = New SqlParameter("@PinkSlipDetailId ", oStandardPinkSlipPPT.PinkSlipDetailId)

        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        rowsAffected = objdb.ExecNonQuery("[Budget].[PinkSlipDetailDelete]", param)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Shared Function PinkSlipSearch(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT, ByVal IsApproval As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim param(4) As SqlParameter

        'param(0) = New SqlParameter("@RefNo", IIf(oStandardPinkSlipPPT.RefNo <> String.Empty, oStandardPinkSlipPPT.RefNo, DBNull.Value))

        If oStandardPinkSlipPPT.RefNo <> "" Then
            param(0) = New SqlParameter("@RefNo", oStandardPinkSlipPPT.RefNo)
        Else
            param(0) = New SqlParameter("@RefNo", DBNull.Value)
        End If
        If oStandardPinkSlipPPT.DateRequestIsChecked = True Then
            param(1) = New SqlParameter("@DateRequest", oStandardPinkSlipPPT.DateRequest)
        Else
            param(1) = New SqlParameter("@DateRequest", DBNull.Value)
        End If

        If oStandardPinkSlipPPT.Status = "SELECT ALL" Then
            param(2) = New SqlParameter("@Status", System.DBNull.Value)
        ElseIf oStandardPinkSlipPPT.Status = "" Then
            param(2) = New SqlParameter("@Status", "OPEN")
        Else
            param(2) = New SqlParameter("@Status", oStandardPinkSlipPPT.Status)
        End If
        param(3) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(4) = New SqlParameter("@IsApproval", IsApproval)
        'param(3) = New SqlParameter("@IsApproval", IsApproval)
        ds = objdb.ExecQuery("[Budget].[PinkSlipSearch]", param)
        Return ds

    End Function
    Public Shared Function PinkSlipCOACodeIsvalid(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@COACode", oStandardPinkSlipPPT.COACode)

        ds = objdb.ExecQuery("[Budget].[PinkSlipCOACodeIsvalid]", param)
        Return ds

    End Function
    Public Function GetValueMultipleEntry(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PinkSlipId", oStandardPinkSlipPPT.PinkSlipId)

        dt = objdb.ExecQuery("[Budget].[PinkSlipSelect_MultipleEntry]", Parms).Tables(0)
        Return dt
    End Function
    Public Shared Function PinkSlipBudgetedAmountGET(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        Dim dsPinkSlip As DataSet
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)
        params(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)

        dsPinkSlip = objdb.ExecQuery("[Budget].[PinkSlipBudgetedAmountGET]", params)
        If dsPinkSlip.Tables.Count > 0 Then
            dt = dsPinkSlip.Tables(0)
            Return dt
        Else
            dt = Nothing
            Return dt
        End If
    End Function
    Public Shared Function PinkSlipActualAmountGET(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        Dim dsPinkSlip As DataSet
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        If oStandardPinkSlipPPT.COAID <> "" Then
            params(1) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)
        Else
            params(1) = New SqlParameter("@COAID", DBNull.Value)
        End If
        'params(1) = New SqlParameter("@COAID", oStandardPinkSlipPPT.COAID)
        params(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)

        dsPinkSlip = objdb.ExecQuery("[Budget].[PinkSlipActualAmountGET]", params)
        If dsPinkSlip.Tables.Count > 0 Then
            dt = dsPinkSlip.Tables(0)
            Return dt
        Else
            dt = Nothing
            Return dt
        End If
    End Function

    Public Function Update_PinkSlipApproval(ByVal oStandardPinkSlipPPT As StandardPinkSlipPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Try

            Parms(0) = New SqlParameter("@PinkSlipId", oStandardPinkSlipPPT.PinkSlipId)
            Parms(1) = New SqlParameter("@PinkSlipDetailId", oStandardPinkSlipPPT.PinkSlipDetailId)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            'Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            ' Parms(3) = New SqlParameter("@IPRdate", objIPRPPT.IPRdate)
            Parms(3) = New SqlParameter("@Status", oStandardPinkSlipPPT.Status)
            'Parms(4) = New SqlParameter("@Remarks", objIPRPPT.Remarks)REJECTED
            If oStandardPinkSlipPPT.RejectedReason <> "" Then
                Parms(4) = New SqlParameter("@RejectedReason", oStandardPinkSlipPPT.RejectedReason)
            Else
                Parms(4) = New SqlParameter("@RejectedReason", DBNull.Value)
            End If
            If oStandardPinkSlipPPT.ApprovedAmt = 0 Then
                Parms(5) = New SqlParameter("@ApprovedAmt", DBNull.Value)
            Else
                Parms(5) = New SqlParameter("@ApprovedAmt", oStandardPinkSlipPPT.ApprovedAmt)
            End If
            Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@CreatedOn ", Date.Today)
            Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(9) = New SqlParameter("@ModifiedOn", Date.Today)

            rowsAffected = objdb.ExecNonQuery("[Budget].[PinkSlipApproval]", Parms)

            rowsAffected = 1
     
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function
End Class
  


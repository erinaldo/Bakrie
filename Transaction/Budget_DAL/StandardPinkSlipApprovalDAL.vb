Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class StandardPinkSlipApprovalDAL
    Public Shared Function PinkSlipApprovalSelect(ByVal oStandardPinkSlipApprovalPPT As StandardPinkSlipApprovalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(1) As SqlParameter
        'param(0) = New SqlParameter("@PinkSlipId ", oStandardPinkSlipPPT.PinkSlipId)
        'param(0) = New SqlParameter(" @RefNo", oStandardPinkSlipPPT.RefNo)
        'param(1) = New SqlParameter("@COACode", oStandardPinkSlipPPT.COACode)
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("BudgetYear", GlobalPPT.intLoginYear)
        dt = objdb.ExecQuery("[Budget].[PinkSlipApprovalSelect]", param).Tables(0)
        Return dt
    End Function
    Public Shared Function PinkSlipSearch(ByVal oStandardPinkSlipApprovalPPT As StandardPinkSlipApprovalPPT, ByVal IsApproval As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim param(4) As SqlParameter

        'param(0) = New SqlParameter("@RefNo", IIf(oStandardPinkSlipPPT.RefNo <> String.Empty, oStandardPinkSlipPPT.RefNo, DBNull.Value))

        If oStandardPinkSlipApprovalPPT.RefNo <> "" Then
            param(0) = New SqlParameter("@RefNo", oStandardPinkSlipApprovalPPT.RefNo)
        Else
            param(0) = New SqlParameter("@RefNo", DBNull.Value)
        End If
        If oStandardPinkSlipApprovalPPT.DateRequestIsChecked = True Then
            param(1) = New SqlParameter("@DateRequest", oStandardPinkSlipApprovalPPT.DateRequest)
        Else
            param(1) = New SqlParameter("@DateRequest", DBNull.Value)
        End If

        If oStandardPinkSlipApprovalPPT.Status = "SELECT ALL" Then
            param(2) = New SqlParameter("@Status", System.DBNull.Value)
        ElseIf oStandardPinkSlipApprovalPPT.Status = "" Then
            param(2) = New SqlParameter("@Status", "OPEN")
        Else
            param(2) = New SqlParameter("@Status", oStandardPinkSlipApprovalPPT.Status)
        End If
        param(3) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(4) = New SqlParameter("@IsApproval", IsApproval)
        'param(3) = New SqlParameter("@IsApproval", IsApproval)
        ds = objdb.ExecQuery("[Budget].[PinkSlipSearch]", param)
        Return ds

    End Function
End Class

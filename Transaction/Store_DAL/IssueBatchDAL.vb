Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL
Public Class IssueBatchDAL
    Public Shared Function saveIssueBatch(ByVal objIssueBatch As IssueBatchPPT) As Double
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueBatchID", objIssueBatch.STIssueBatchID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@BatchDate", objIssueBatch.BatchDate)
        Parms(4) = New SqlParameter("@SIVNo", objIssueBatch.SIVNo)
        Parms(5) = New SqlParameter("@BatchValue", objIssueBatch.BatchValue)
        Parms(6) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        rowsAffected = objdb.ExecNonQuery("[Store].[STIssueBatchInsert]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return rowsAffected
        End If
    End Function

    Public Shared Function UpdateIssueBatch(ByVal objIssueBatch As IssueBatchPPT) As Double
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueBatchID", objIssueBatch.STIssueBatchID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@BatchDate", objIssueBatch.BatchDate)
        Parms(4) = New SqlParameter("@SIVNo", objIssueBatch.SIVNo)
        Parms(5) = New SqlParameter("@BatchValue", objIssueBatch.BatchValue)
        Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@ModifiedOn", Date.Today())
        rowsAffected = objdb.ExecNonQuery("[Store].[STIssueBatchUpdate]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return rowsAffected
        End If
    End Function

    Public Shared Function LoaddgIssueBatch(ByVal objIssueBatch As IssueBatchPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueBatchEstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Store].[GetSTIssueBatchDetails]", Parms)
        Dim dt As DataTable
        dt = ds.Tables(0)
        Return dt
    End Function

    Public Shared Function IssueBatchSIVNOIsExist(ByVal objIssueBatch As IssueBatchPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim rowsAffected As Integer = 0
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@SIVNo", objIssueBatch.SIVNo)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Store].[STIssueVoucherBatchTotalSelect]", Parms)
        Return ds
    End Function

End Class

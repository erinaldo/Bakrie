Imports System.Data.SqlClient
Imports Store_PPT
Imports Common_DAL
Imports Common_PPT

Public Class IPRLogDAL
    Public Function GetIPRDetails(ByVal objIPRPPT As IPRLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@IPRdate", IIf(objIPRPPT.IPRdate <> Nothing, CType(objIPRPPT.IPRdate, String), DBNull.Value)) 'objIPRPPT.IPRdate)
        params(1) = New SqlParameter("@IPRNo", IIf(objIPRPPT.IPRNo <> "", objIPRPPT.IPRNo, DBNull.Value))
        params(2) = New SqlParameter("@Status", IIf(objIPRPPT.Status <> "", objIPRPPT.Status, DBNull.Value))
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Store].[IPRLogSearch]", params).Tables(0)
        Return dt
    End Function
End Class

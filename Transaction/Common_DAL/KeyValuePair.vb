Imports System.Data.SqlClient

Public Class KeyValuePair
    Public Shared Function GetKeyValuePair(ByVal keyName As String) As DataTable

        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@Keyname", keyName)

        Dim dt As New DataTable
        dt = objdb.ExecQuery("[dbo].[Keyvaluepairsselect]", Parms).Tables(0)
        Return dt

    End Function
End Class

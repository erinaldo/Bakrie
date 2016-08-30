Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class MaterialUsageReport_DAL

    Public Function GetInterfaceYear() As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[CheckRoll].[CheckRollRPTYearSelect]")
        Return ds
    End Function


End Class

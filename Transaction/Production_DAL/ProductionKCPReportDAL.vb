Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class ProductionKCPReportDAL


    Public Function GetInterfaceYear(ByVal objProductionKCPReportPPT As ProductionKCPReportPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[ProductionRPTYearSelect]")
        Return ds
    End Function


End Class

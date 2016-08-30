Imports System.Data.SqlClient
Imports Store_DAL
Imports Store_PPT
Imports Store_BOL
Public Class IPRLogBOL
    'Public Function IPRLogSearch(ByVal objIPRPPT As IPRLogPPT) As DataTable
    '    Dim objIPRData As New IPRLogData
    '    Return objIPRData.IPRLogSearch(objIPRPPT)
    'End Function
    Public Function GetIPRDetails(ByVal objIPRPPT As IPRLogPPT) As DataTable
        Dim objIPRData As New IPRLogDAL
        Return objIPRData.GetIPRDetails(objIPRPPT)
    End Function

End Class

Imports Store_DAL
Imports Store_PPT

Public Class SummaryReportsBOL
    Public Function GetInterfaceYear(ByVal objSummaryReportsPPT As SummaryReportsPPT) As DataSet
        Dim objSummaryReportsDAL As New SummaryReportsDAL
        Return objSummaryReportsDAL.GetInterfaceYear(objSummaryReportsPPT)
    End Function
    Public Function GetTaskComplete(ByVal objSummaryReportsPPT As SummaryReportsPPT) As DataSet
        Dim objSummaryReportsDAL As New SummaryReportsDAL
        Return objSummaryReportsDAL.GetTaskComplete(objSummaryReportsPPT)
    End Function
    Public Function GetFYearDate(ByVal objSummaryReportsPPT As SummaryReportsPPT) As DataSet
        Dim objSummaryReportsDAL As New SummaryReportsDAL
        Return objSummaryReportsDAL.GetFYearDate(objSummaryReportsPPT)
    End Function

End Class

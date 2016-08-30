Imports Vehicle_DAL
Imports Vehicle_PPT


Public Class DistribusiBiayaBengkelReportBOL

    Public Function GetInterfaceYear(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objDistribusiBiayaBengkelReportDAL As New DistribusiBiayaBengkelReportDAL
        Return objDistribusiBiayaBengkelReportDAL.GetInterfaceYear(objDistribusiBiayaBengkelReportPPT)
    End Function

    Public Function GetTaskComplete(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objDistribusiBiayaBengkelReportDAL As New DistribusiBiayaBengkelReportDAL
        Return objDistribusiBiayaBengkelReportDAL.GetTaskComplete(objDistribusiBiayaBengkelReportPPT)
    End Function
    Public Function ActiveMonthYearIDGet(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objDistribusiBiayaBengkelReportDAL As New DistribusiBiayaBengkelReportDAL
        Return objDistribusiBiayaBengkelReportDAL.ActiveMonthYearIDGet(objDistribusiBiayaBengkelReportPPT)
    End Function
    Public Function GetFYearDate(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objDistribusiBiayaBengkelReportDAL As New DistribusiBiayaBengkelReportDAL
        Return objDistribusiBiayaBengkelReportDAL.GetFYearDate(objDistribusiBiayaBengkelReportPPT)
    End Function
End Class

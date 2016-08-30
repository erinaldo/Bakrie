Imports Production_DAL
Imports Production_PPT
Public Class GradingReportBOL
    Public Shared Function GetInterfaceYear(ByVal objGradingReportPPT As GradingReportPPT) As DataSet
        Return GradingReportDAL.GetInterfaceYear(objGradingReportPPT)
    End Function
    Public Shared Function GetWBTicketNo(ByVal objGradingReportPPT As GradingReportPPT) As DataTable
        Return GradingReportDAL.GetWBTicketNo(objGradingReportPPT)
    End Function

End Class

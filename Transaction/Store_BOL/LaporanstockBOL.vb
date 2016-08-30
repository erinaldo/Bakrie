Imports Store_DAL
Imports Store_PPT
Public Class LaporanstockBOL
    Public Function GetInterfaceYear(ByVal objLaporanstockPPT As LaporanstockPPT) As DataSet
        Dim objLaporanstockDAL As New LaporanstockDAL
        Return objLaporanstockDAL.GetInterfaceYear(objLaporanstockPPT)
    End Function
    Public Function GetTaskComplete(ByVal objSummaryReportsPPT As LaporanstockPPT) As DataSet
        Dim objLaporanstockDAL As New LaporanstockDAL
        Return objLaporanstockDAL.GetTaskComplete(objSummaryReportsPPT)
    End Function
    Public Function GetFYearDate(ByVal objSummaryReportsPPT As LaporanstockPPT) As DataSet
        Dim objLaporanstockDAL As New LaporanstockDAL
        Return objLaporanstockDAL.GetFYearDate(objSummaryReportsPPT)
    End Function
End Class

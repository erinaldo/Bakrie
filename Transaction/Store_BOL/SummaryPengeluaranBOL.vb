Imports Store_DAL
Imports Store_PPT
Public Class SummaryPengeluaranBOL
    Public Function GetInterfaceYear(ByVal objSummaryPengeluaranPPT As SummaryPengeluaranPPT) As DataSet
        Dim objSummaryPengeluaranDAL As New SummaryPengeluaranDAL
        Return objSummaryPengeluaranDAL.GetInterfaceYear(objSummaryPengeluaranPPT)
    End Function
    Public Function GetTaskComplete(ByVal objSummaryPengeluaranPPT As SummaryPengeluaranPPT) As DataSet
        Dim objSummaryPengeluaranDAL As New SummaryPengeluaranDAL
        Return objSummaryPengeluaranDAL.GetTaskComplete(objSummaryPengeluaranPPT)
    End Function
    Public Function GetFYearDate(ByVal objSummaryPengeluaranPPT As SummaryPengeluaranPPT) As DataSet
        Dim objSummaryPengeluaranDAL As New SummaryPengeluaranDAL
        Return objSummaryPengeluaranDAL.GetFYearDate(objSummaryPengeluaranPPT)
    End Function
End Class

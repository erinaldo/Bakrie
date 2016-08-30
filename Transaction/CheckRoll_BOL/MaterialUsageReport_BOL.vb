Imports CheckRoll_DAL

Public Class MaterialUsageReport_BOL



    Public Function GetInterfaceYear() As DataSet
        Dim objMaterialUsageReportDAL As New MaterialUsageReport_DAL
        Return objMaterialUsageReportDAL.GetInterfaceYear()
    End Function
End Class

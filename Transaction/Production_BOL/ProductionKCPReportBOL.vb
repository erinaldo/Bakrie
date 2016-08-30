Imports Production_DAL
Imports Production_PPT

Public Class ProductionKCPReportBOL

   
    Public Function GetInterfaceYear(ByVal objProductionKCPReportPPT As ProductionKCPReportPPT) As DataSet
        Dim objProductionKCPReportDAL As New ProductionKCPReportDAL
        Return objProductionKCPReportDAL.GetInterfaceYear(objProductionKCPReportPPT)
    End Function
   

End Class

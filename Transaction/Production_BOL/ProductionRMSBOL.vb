Imports Production_DAL
Imports Production_PPT
Public Class ProductionRMSBOL
    Dim objDAL As New ProductionRMSDAL
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionRMSPPT) As List(Of ProductionRMSPPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Function FillTotalWetDry()
        Return objDAL.FillTotalWetDry()
    End Function
    Public Shared Function DeleteLastRMS(ByVal objLPOPPT As ProductionRMSPPT) As DataSet
        Return ProductionRMSDAL.DeleteLastRMS(objLPOPPT)
    End Function
End Class

Imports Production_DAL
Imports Production_PPT

Public Class ProductionRSSBOL
    Public Shared Function Save(ByVal objLPOPPT As ProductionRSSPPT) As DataSet
        Return ProductionRSSDAL.SaveProductionRSS(objLPOPPT)
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionRSSPPT) As List(Of ProductionRSSPPT)
        Dim objDAL As New ProductionRSSDAL
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastRSS(ByVal objLPOPPT As ProductionRSSPPT) As DataSet
        Return ProductionRSSDAL.DeleteLastRSS(objLPOPPT)
    End Function
End Class

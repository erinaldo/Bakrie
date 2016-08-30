Imports Production_DAL
Imports Production_PPT
Public Class ProductionLogCenexBOL
    Dim objDAL As New ProductionLogCenexDAL
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionLogCenexPPT) As List(Of ProductionLogCenexPPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastPLCNX(ByVal objLPOPPT As ProductionLogCenexPPT) As DataSet
        Return ProductionLogCenexDAL.DeleteLastPLCNX(objLPOPPT)
    End Function


End Class

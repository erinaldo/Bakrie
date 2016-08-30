Imports Production_DAL
Imports Production_PPT
Public Class ProductionLogBSRBOL
    Dim objDAL As New ProductionLogBSRDAL
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionLogBSRPPT) As List(Of ProductionLogBSRPPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastBSR(ByVal objLPOPPT As ProductionLogBSRPPT) As DataSet
        Return ProductionLogBSRDAL.DeleteLastBSR(objLPOPPT)
    End Function
End Class

Imports Production_DAL
Imports Production_PPT
Public Class ProductionQcdCenexBOL
    Dim objDAL As New ProductionQcdCenexDAL
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionQcdCenexPPT) As List(Of ProductionQcdCenexPPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastQCNX(ByVal objLPOPPT As ProductionQcdCenexPPT) As DataSet
        Return ProductionQcdCenexDAL.DeleteLastQCNX(objLPOPPT)
    End Function
End Class

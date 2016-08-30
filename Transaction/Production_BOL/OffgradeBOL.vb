Imports Production_DAL
Imports Production_PPT
Public Class OffgradeBOL
    Dim objDAL As New OffgradeDAL
    Public Function GetSearchResults(ByVal objLPOPPT As OffgradePPT) As List(Of OffgradePPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastOG(ByVal objLPOPPT As OffgradePPT) As DataSet
        Return OffgradeDAL.DeleteLastOG(objLPOPPT)
    End Function
End Class

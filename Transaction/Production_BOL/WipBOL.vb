Imports Production_DAL
Imports Production_PPT
Public Class WipBOL
    Dim objDAL As New WipDAL
    Public Function GetSearchResults(ByVal objLPOPPT As WipPPT) As List(Of WipPPT)
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastWIP(ByVal objLPOPPT As WipPPT) As DataSet
        Return WipDAL.DeleteLastWIP(objLPOPPT)
    End Function
End Class

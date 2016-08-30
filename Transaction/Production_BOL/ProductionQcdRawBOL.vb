Imports Production_DAL
Imports Production_PPT
Public Class ProductionQcdRawBOL
    Public Shared Function Save(ByVal objLPOPPT As ProductionQcdRawPPT) As DataSet
        Return ProductionQcdRawDAL.SaveProductionQcdRaw(objLPOPPT)
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionQcdRawPPT) As List(Of ProductionQcdRawPPT)
        Dim objDAL As New ProductionQcdRawDAL
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastQcdRaw(ByVal objLPOPPT As ProductionQcdRawPPT) As DataSet
        Return ProductionQcdRawDAL.DeleteLastQcdRaw(objLPOPPT)
    End Function
End Class

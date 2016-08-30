Imports Production_DAL
Imports Production_PPT
Public Class ProductionQcdOtherBOL
    Public Shared Function Save(ByVal objLPOPPT As ProductionQcdOtherPPT) As DataSet
        Return ProductionQcdOtherDAL.SaveProductionQcdOther(objLPOPPT)
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As ProductionQcdOtherPPT) As List(Of ProductionQcdOtherPPT)
        Dim objDAL As New ProductionQcdOtherDAL
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastQcdOther(ByVal objLPOPPT As ProductionQcdOtherPPT) As DataSet
        Return ProductionQcdOtherDAL.DeleteLastQcdOther(objLPOPPT)
    End Function
End Class

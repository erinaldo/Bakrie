Imports Production_DAL
Imports Production_PPT
Public Class ProductionBrownCreepBOL
    Public Shared Function Save(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As DataSet
        Return ProductionBrownCreepDAL.SaveProductionBrownCreep(objBrownCreepPPT)
    End Function
    Public Function GetSearchResults(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As List(Of ProductionBrownCreepPPT)
        Dim objDAL As New ProductionBrownCreepDAL
        Return objDAL.GetSearchResults(objBrownCreepPPT)
    End Function
    Public Shared Function DeleteLastRSS(ByVal objBrownCreepPPT As ProductionBrownCreepPPT) As DataSet
        Return ProductionBrownCreepDAL.DeleteLastBrownCreep(objBrownCreepPPT)
    End Function
End Class

Imports Production_DAL
Imports Production_PPT
Public Class ProductionSIRBOL
    Public Shared Function Save(ByVal objSIRPPT As ProductionSIRPPT) As DataSet
        Return ProductionSIRDAL.SaveProductionSIR(objSIRPPT)
    End Function
    Public Function GetSearchResults(ByVal objSIRPPT As ProductionSIRPPT) As List(Of ProductionSIRPPT)
        Dim objDAL As New ProductionSIRDAL
        Return objDAL.GetSearchResults(objSIRPPT)
    End Function
    Public Shared Function DeleteLastSIR(ByVal objSIRPPT As ProductionSIRPPT) As DataSet
        Return ProductionSIRDAL.DeleteLastSIR(objSIRPPT)
    End Function
End Class

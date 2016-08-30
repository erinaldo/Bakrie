Imports Production_DAL
Imports Production_PPT
Public Class ProductionTransferBOL
    Public Shared Function Save(ByVal objTransferPPT As ProductionTransferPPT) As DataSet
        Return ProductionTransferDAL.SaveProductionTransfer(objTransferPPT)
    End Function
    Public Function GetSearchResults(ByVal objTransferPPT As ProductionTransferPPT) As List(Of ProductionTransferPPT)
        Dim objDAL As New ProductionTransferDAL
        Return objDAL.GetSearchResults(objTransferPPT)
    End Function
    Public Shared Function DeleteLastTransfer(ByVal objTransferPPT As ProductionTransferPPT) As DataSet
        Return ProductionTransferDAL.DeleteLastTransfer(objTransferPPT)
    End Function
End Class

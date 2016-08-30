Imports WeighBridge_DAL
Imports WeighBridge_PPT

Public Class WBWeighingInOutRubberBOL

    Public Shared Function Save(ByVal objLPOPPT As WBWeighingInOutRubberPPT) As DataSet
        Return WBWeighingInOutRubberDAL.SaveWIORubber(objLPOPPT)
    End Function
    Public Function GetSearchResults(ByVal objLPOPPT As WBWeighingInOutRubberPPT) As List(Of WBWeighingInOutRubberPPT)
        Dim objDAL As New WBWeighingInOutRubberDAL
        Return objDAL.GetSearchResults(objLPOPPT)
    End Function
    Public Shared Function DeleteLastWIORubber(ByVal objLPOPPT As WBWeighingInOutRubberPPT) As DataSet
        Return WBWeighingInOutRubberDAL.DeleteLastWIORubber(objLPOPPT)
    End Function

End Class

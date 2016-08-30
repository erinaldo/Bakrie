Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class EstateGradingBOL
    Public Function Save_EstateGrading(ByVal objEGPPT As EstateGradingPPT) As Integer
        Dim objIPRData As New EstateGradingDAL
        Return objIPRData.Save_EstateGrading(objEGPPT)
    End Function
End Class
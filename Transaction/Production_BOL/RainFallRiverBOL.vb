Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
Public Class RainFallRiverBOL
    Public Shared Function saveRainFallRiverDetails(ByVal objRFRPPT As RainFallRiverPPT) As DataSet
        Return RainFallRiverDAL.saveRainFallRiverDetails(objRFRPPT)
    End Function
    Public Shared Function GetRainFallDetails(ByVal objRFRPPT As RainFallRiverPPT) As DataTable
        Dim objRFRDAL As New RainFallRiverDAL
        Return objRFRDAL.GetRainFallDetails(objRFRPPT)
    End Function
    Public Function Delete_RainFallDetail(ByVal objRFRPPT As RainFallRiverPPT) As Integer
        Dim objRFRDAL As New RainFallRiverDAL
        Return objRFRDAL.Delete_RainFallDetail(objRFRPPT)
    End Function
    Public Shared Function UpdateRainFallRiverDetails(ByVal objRFRPPT As RainFallRiverPPT) As DataSet
        Return RainFallRiverDAL.UpdateRainFallRiverDetails(objRFRPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objRFRPPT As RainFallRiverPPT) As Object
        Dim objRFRDAL As New RainFallRiverDAL
        Return objRFRDAL.DuplicateDateCheck(objRFRPPT)
    End Function
    Public Function DuplicateTimeCheck(ByVal objRFRPPT As RainFallRiverPPT) As Object
        Dim objRFRDAL As New RainFallRiverDAL
        Return objRFRDAL.DuplicateTimeCheck(objRFRPPT)
    End Function
End Class

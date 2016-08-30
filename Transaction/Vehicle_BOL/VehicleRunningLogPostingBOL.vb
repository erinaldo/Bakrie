Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class VehicleRunningLogPostingBOL

    Dim _VehicleRunningLogPostingDAL As VehicleRunningLogPostingDAL

    Public Function NonPostedVehicleRunningLogGet(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT) As DataSet
        _VehicleRunningLogPostingDAL = New VehicleRunningLogPostingDAL
        Return _VehicleRunningLogPostingDAL.NonPostedVehicleRunningLogGet(objVehicleRunningLogPostingPPT)
    End Function

    Public Function PostByIdOrPostAll(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT) As Integer
        _VehicleRunningLogPostingDAL = New VehicleRunningLogPostingDAL
        Return _VehicleRunningLogPostingDAL.PostByIdOrPostAll(objVehicleRunningLogPostingPPT)
    End Function

    Public Sub SaveOrUpdateVHRunningDetailExternal(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT)
        _VehicleRunningLogPostingDAL = New VehicleRunningLogPostingDAL
        _VehicleRunningLogPostingDAL.SaveOrUpdateVHRunningDetailExternal(objVehicleRunningLogPostingPPT)
    End Sub

    Public Sub VehicleProcessingWriteUp(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT)
        _VehicleRunningLogPostingDAL = New VehicleRunningLogPostingDAL
        _VehicleRunningLogPostingDAL.VehicleProcessingWriteUp(objVehicleRunningLogPostingPPT)
    End Sub


End Class

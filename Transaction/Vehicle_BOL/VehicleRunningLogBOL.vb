Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class VehicleRunningLogBOL

    Dim _VehicleRunningLogDAL As VehicleRunningLogDAL

    Function GetVehicleCodeForView(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As DataTable
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.VehicleCodeForViewGet(objVehicleRunningLogPPT)
    End Function

    Function LocationGet(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As DataTable
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.GetLocation(objVehicleRunningLogPPT)
    End Function

    Function GetBatchValueByVehicleCodeLog(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As DataSet
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.GetBatchValueByVehicleCode(objVehicleRunningLogPPT)
    End Function

    Function SaveVehicleRunningLog(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As Integer
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.VehicleRunningLogSave(objVehicleRunningLogPPT)
    End Function

    Function UpdateVehicleRunningLog(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As Integer
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.VehicleRunningLogUpdate(objVehicleRunningLogPPT)
    End Function

    Function GetRunningLodDetailsByIdDuringEdit(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As DataSet
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.GetRunningLodDetailsById(objVehicleRunningLogPPT)
    End Function

    Function DeleteVehicleRunningLog(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As Integer
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.VehicleRunningLogDelete(objVehicleRunningLogPPT)
    End Function

    Function DeleteVehicleRunningLogFromView(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As Integer
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.DeleteVehicleRunningLogFromView(objVehicleRunningLogPPT)
    End Function

    Public Function VHRunningLogRecordIsExist(ByVal objVehicleRunningLogPPT As VehicleRunningLogPPT) As Object
        _VehicleRunningLogDAL = New VehicleRunningLogDAL
        Return _VehicleRunningLogDAL.VHRunningLogRecordIsExist(objVehicleRunningLogPPT)
    End Function
End Class

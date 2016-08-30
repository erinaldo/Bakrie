Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class VehicleRunningBatchBOL
    Dim objVehicleRunningBatchDAL As VehicleRunningBatchDAL
    Function GetVehicleCodeList(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As DataSet
        objVehicleRunningBatchDAL = New VehicleRunningBatchDAL
        Return objVehicleRunningBatchDAL.GetVehicleCodeList(objVehicleRunningBatchPPT)
    End Function

    Function GetBatchDetailsVehicleCode(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As DataSet
        objVehicleRunningBatchDAL = New VehicleRunningBatchDAL
        Return objVehicleRunningBatchDAL.GetBatchDetailsVehicleCode(objVehicleRunningBatchPPT)
    End Function

    Function SaveVehicleRunningBatch(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As Integer
        objVehicleRunningBatchDAL = New VehicleRunningBatchDAL
        Return objVehicleRunningBatchDAL.SaveVehicleRunningBatch(objVehicleRunningBatchPPT)
    End Function

    Function UpdateVehicleRunningBatch(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As Integer
        objVehicleRunningBatchDAL = New VehicleRunningBatchDAL
        Return objVehicleRunningBatchDAL.UpdateVehicleRunningBatch(objVehicleRunningBatchPPT)
    End Function

    Function DeleteVehicleRunningBatch(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As Integer
        objVehicleRunningBatchDAL = New VehicleRunningBatchDAL
        Return objVehicleRunningBatchDAL.DeleteVehicleRunningBatch(objVehicleRunningBatchPPT)
    End Function

    Function GetVehicleRunningBatchDuringEdit(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As DataSet
        objVehicleRunningBatchDAL = New VehicleRunningBatchDAL
        Return objVehicleRunningBatchDAL.GetVehicleRunningBatchDuringEdit(objVehicleRunningBatchPPT)
    End Function

End Class

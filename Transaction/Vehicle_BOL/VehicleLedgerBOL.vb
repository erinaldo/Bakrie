Imports Vehicle_DAL
Imports Vehicle_PPT


Public Class VehicleLedgerBOL
    Public Function GetInterfaceYear(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objVehicleLedgerDAL As New VehicleLedgerDAL
        Return objVehicleLedgerDAL.GetInterfaceYear(objVehicleLedgerPPT)
    End Function

    Public Function GetTaskComplete(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objVehicleLedgerDAL As New VehicleLedgerDAL
        Return objVehicleLedgerDAL.GetTaskComplete(objVehicleLedgerPPT)
    End Function
    Public Function ActiveMonthYearIDGet(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objVehicleLedgerDAL As New VehicleLedgerDAL
        Return objVehicleLedgerDAL.ActiveMonthYearIDGet(objVehicleLedgerPPT)
    End Function
    Public Function GetFYearDate(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objVehicleLedgerDAL As New VehicleLedgerDAL
        Return objVehicleLedgerDAL.GetFYearDate(objVehicleLedgerPPT)
    End Function
End Class

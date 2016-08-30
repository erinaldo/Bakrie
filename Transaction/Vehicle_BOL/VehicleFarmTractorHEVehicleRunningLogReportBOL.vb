Imports Vehicle_DAL
Imports Vehicle_PPT
Public Class VehicleFarmTractorHEVehicleRunningLogReportBOL
    Public Function GetInterfaceYear(ByVal objVehicleFarmTractorHEVehicleRunningLogReportPPT As VehicleFarmTractorHEVehicleRunningLogReportPPT) As DataSet
        Dim objVehicleFarmTractorHEVehicleRunningLogReportDAL As New VehicleFarmTractorHEVehicleRunningLogReportDAL
        Return objVehicleFarmTractorHEVehicleRunningLogReportDAL.GetInterfaceYear(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
    End Function
    Public Function GetTaskComplete(ByVal objVehicleFarmTractorHEVehicleRunningLogReportPPT As VehicleFarmTractorHEVehicleRunningLogReportPPT) As DataSet
        Dim objVehicleFarmTractorHEVehicleRunningLogReportDAL As New VehicleFarmTractorHEVehicleRunningLogReportDAL
        Return objVehicleFarmTractorHEVehicleRunningLogReportDAL.GetTaskComplete(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
    End Function
    Public Function ActiveMonthYearIDGet(ByVal objVehicleFarmTractorHEVehicleRunningLogReportPPT As VehicleFarmTractorHEVehicleRunningLogReportPPT) As DataSet
        Dim objVehicleFarmTractorHEVehicleRunningLogReportDAL As New VehicleFarmTractorHEVehicleRunningLogReportDAL
        Return objVehicleFarmTractorHEVehicleRunningLogReportDAL.ActiveMonthYearIDGet(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
    End Function
    Public Function GetFYearDate(ByVal objVehicleFarmTractorHEVehicleRunningLogReportPPT As VehicleFarmTractorHEVehicleRunningLogReportPPT) As DataSet
        Dim objVehicleFarmTractorHEVehicleRunningLogReportDAL As New VehicleFarmTractorHEVehicleRunningLogReportDAL
        Return objVehicleFarmTractorHEVehicleRunningLogReportDAL.GetFYearDate(objVehicleFarmTractorHEVehicleRunningLogReportPPT)
    End Function
End Class

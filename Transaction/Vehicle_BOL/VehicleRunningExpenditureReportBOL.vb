Imports Vehicle_DAL
Imports Vehicle_PPT


Public Class VehicleRunningExpenditureReportBOL

    Public Function GetInterfaceYear(ByVal objVehicleRunningExpenditureReportPPT As VehicleRunningExpenditureReportPPT) As DataSet
        Dim objVehicleRunningExpenditureReportDAL As New VehicleRunningExpenditureReportDAL
        Return objVehicleRunningExpenditureReportDAL.GetInterfaceYear(objVehicleRunningExpenditureReportPPT)
    End Function

    Public Function GetTaskComplete(ByVal objVehicleRunningExpenditureReportPPT As VehicleRunningExpenditureReportPPT) As DataSet
        Dim objVehicleRunningExpenditureReportDAL As New VehicleRunningExpenditureReportDAL
        Return objVehicleRunningExpenditureReportDAL.GetTaskComplete(objVehicleRunningExpenditureReportPPT)
    End Function
    Public Function ActiveMonthYearIDGet(ByVal objVehicleRunningExpenditureReportPPT As VehicleRunningExpenditureReportPPT) As DataSet
        Dim objVehicleRunningExpenditureReportDAL As New VehicleRunningExpenditureReportDAL
        Return objVehicleRunningExpenditureReportDAL.ActiveMonthYearIDGet(objVehicleRunningExpenditureReportPPT)
    End Function
    Public Function GetFYearDate(ByVal objVehicleRunningExpenditureReportPPT As VehicleRunningExpenditureReportPPT) As DataSet
        Dim objVehicleRunningExpenditureReportDAL As New VehicleRunningExpenditureReportDAL
        Return objVehicleRunningExpenditureReportDAL.GetFYearDate(objVehicleRunningExpenditureReportPPT)
    End Function
End Class



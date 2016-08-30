Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class VehicleMonthlyProcessingBOL

    Dim _VehicleMonthlyProcessingDAL As VehicleMonthlyProcessingDAL

#Region "WorkshopLog"

    Public Function GetWorkshopCode() As DataSet
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        Return _VehicleMonthlyProcessingDAL.GetWorkshopCode()
    End Function

    

    Public Function GetTotalExpenditure(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) As DataSet
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        Return _VehicleMonthlyProcessingDAL.GetTotalExpenditure(_VehicleMonthlyProcessingEntity)
    End Function

    Public Function IsVehicleModuleRecordsApproved() As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        Return _VehicleMonthlyProcessingDAL.IsVehicleModuleRecordsApproved()
    End Function

    Public Sub SaveVHRunningCostSummary(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.SaveVHRunningCostSummary(_VehicleMonthlyProcessingEntity)
    End Sub

    Public Sub SaveWorkshopVHRunningDetail(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.SaveWorkshopVHRunningDetail(_VehicleMonthlyProcessingEntity)
    End Sub

    Public Sub SaveWorkshopLogProcessing(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.SaveWorkshopLogProcessing(_VehicleMonthlyProcessingEntity)
    End Sub

#End Region

#Region "VehicleDistribution"

    Public Function GetVehicleCode() As DataSet
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        Return _VehicleMonthlyProcessingDAL.GetVehicleCode()
    End Function

    Public Sub SaveVehicleVHRunningDetail(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.SaveVehicleVHRunningDetail(_VehicleMonthlyProcessingEntity)
    End Sub

    Public Sub SaveVehicleProcessing(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.SaveVehicleProcessing(_VehicleMonthlyProcessingEntity)
    End Sub

    

#End Region

    Public Shared Function TaskMonitorGet() As DataSet

        Return VehicleMonthlyProcessingDAL.TaskMonitorGet()

    End Function

    Public Shared Function TaskMonitorStatusGet(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) As DataSet

        Return VehicleMonthlyProcessingDAL.TaskMonitorStatusGet(_VehicleMonthlyProcessingEntity)

    End Function

    Public Sub SaveTaskMonitor(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.SaveTaskMonitor(_VehicleMonthlyProcessingEntity)
    End Sub

    Public Sub BeginBackupBSPDB(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.BeginBackupBSPDB(_VehicleMonthlyProcessingEntity)
    End Sub

    Public Sub MonthEndClosing()

        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.MonthEndClosing()

    End Sub

    Public Sub VehicleApprovalUpdate()

        _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
        _VehicleMonthlyProcessingDAL.VehicleApprovalUpdate()

    End Sub


    'Public Shared Function TaskConfigTaskCheckGet(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) As DataSet

    '    Return VehicleMonthlyProcessingDAL.TaskConfigTaskCheckGet(_VehicleMonthlyProcessingEntity)

    'End Function

    'Public Function NonPostedWorkshopLogGet(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) As DataSet
    '    _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
    '    Return _VehicleMonthlyProcessingDAL.NonPostedWorkshopLogGet(_VehicleMonthlyProcessingEntity)
    'End Function

    'Public Function PostByIdOrPostAllWorkshopLog(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) As Integer
    '    _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
    '    Return _VehicleMonthlyProcessingDAL.PostByIdOrPostAllWorkshopLog(_VehicleMonthlyProcessingEntity)
    'End Function

    'Public Sub SaveVehicleRunningDetail(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
    '    _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
    '    _VehicleMonthlyProcessingDAL.SaveVehicleRunningDetail(_VehicleMonthlyProcessingEntity)
    'End Sub

    'Public Sub SaveWorkshopLogVehicleProcessing(ByVal _VehicleMonthlyProcessingEntity As VehicleMonthlyProcessingPPT) 'As Integer
    '    _VehicleMonthlyProcessingDAL = New VehicleMonthlyProcessingDAL
    '    _VehicleMonthlyProcessingDAL.SaveWorkshopLogVehicleProcessing(_VehicleMonthlyProcessingEntity)
    'End Sub
End Class

Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class VehicleDistributionPostingBOL
    Public Function NonPostedVehicleDistributionGet() As DataSet
        Dim objVehicleDistributionPostingDAL As New VehicleDistributionPostingDAL
        Return objVehicleDistributionPostingDAL.NonPostedVehicleDistributionGet()
    End Function

    Public Function PostByIdOrPostAllVehicleDistribution(ByVal _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT) As Integer
        Dim objVehicleDistributionPostingDAL As New VehicleDistributionPostingDAL
        Return objVehicleDistributionPostingDAL.PostByIdOrPostAllVehicleDistribution(_VehicleDistributionPostingPPT)
    End Function
    Public Function SaveVehicleRunningDetail(ByVal _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT) As Integer
        Dim objVehicleDistributionPostingDAL As New VehicleDistributionPostingDAL
        Return objVehicleDistributionPostingDAL.SaveVehicleRunningDetail(_VehicleDistributionPostingPPT)
    End Function
    Public Function SaveVHDistributionVehicleProcessing(ByVal _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT) As Integer
        Dim objVehicleDistributionPostingDAL As New VehicleDistributionPostingDAL
        Return objVehicleDistributionPostingDAL.SaveVHDistributionVehicleProcessing(_VehicleDistributionPostingPPT)
    End Function
End Class

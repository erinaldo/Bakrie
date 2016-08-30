Imports Vehicle_PPT
Imports Vehicle_DAL


Public Class VehicleGeneralBOL
    Dim _VehicleGeneralData As VehicleGeneralDAL

    Function GetActiveMonthYear(ByVal _VehicleGeneralEntity As VehicleGeneralPPT) As DataSet
        _VehicleGeneralData = New VehicleGeneralDAL
        Return _VehicleGeneralData.GetActiveMonthYear(_VehicleGeneralEntity)
    End Function

    Function GetIsValidKey(ByVal _VehicleGeneralEntity As VehicleGeneralPPT) As Integer
        _VehicleGeneralData = New VehicleGeneralDAL
        Return _VehicleGeneralData.GetIsValidKey(_VehicleGeneralEntity)
    End Function

    Function IsVHWSCodeExist(ByVal _VehicleGeneralEntity As VehicleGeneralPPT) As Integer
        _VehicleGeneralData = New VehicleGeneralDAL
        Return _VehicleGeneralData.IsVHWSCodeExist(_VehicleGeneralEntity)
    End Function

End Class

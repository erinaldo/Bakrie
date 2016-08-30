Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class WorkshopLogPostingBOL
    Dim _WorkshopLogPostingDAL As WorkshopLogPostingDAL
    Public Function NonPostedWorkshopLogGet(ByVal _WorkshopLogPostingEntity As WorkshopLogPostingPPT) As DataSet
        _WorkshopLogPostingDAL = New WorkshopLogPostingDAL
        Return _WorkshopLogPostingDAL.NonPostedWorkshopLogGet(_WorkshopLogPostingEntity)
    End Function

    Public Function PostByIdOrPostAllWorkshopLog(ByVal _WorkshopLogPostingEntity As WorkshopLogPostingPPT) As Integer
        _WorkshopLogPostingDAL = New WorkshopLogPostingDAL
        Return _WorkshopLogPostingDAL.PostByIdOrPostAllWorkshopLog(_WorkshopLogPostingEntity)
    End Function

    Public Sub SaveVehicleRunningDetail(ByVal _WorkshopLogPostingEntity As WorkshopLogPostingPPT) 'As Integer
        _WorkshopLogPostingDAL = New WorkshopLogPostingDAL
        _WorkshopLogPostingDAL.SaveVehicleRunningDetail(_WorkshopLogPostingEntity)
    End Sub

    Public Sub SaveWorkshopLogVehicleProcessing(ByVal _WorkshopLogPostingEntity As WorkshopLogPostingPPT) 'As Integer
        _WorkshopLogPostingDAL = New WorkshopLogPostingDAL
        _WorkshopLogPostingDAL.SaveWorkshopLogVehicleProcessing(_WorkshopLogPostingEntity)
    End Sub
End Class

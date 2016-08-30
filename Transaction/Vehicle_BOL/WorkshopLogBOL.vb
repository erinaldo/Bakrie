Imports Vehicle_PPT
Imports Vehicle_DAL

Public Class WorkshopLogBOL
    Dim _WorkshopLogDAL As WorkshopLogDAL
#Region "Functions"

    Public Function GetWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataSet
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetWorkshopLog(_WorkshopLogPPT)
    End Function

    Public Function GetWorkshopLogDetails(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataSet
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetWorkshopLogDetails(_WorkshopLogPPT)
    End Function

    Public Function GetVHCode(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataTable
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetVHCode(_WorkshopLogPPT)
    End Function

    Public Function SaveWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.SaveWorkshopLog(_WorkshopLogPPT)
    End Function

    Public Function UpdateWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.UpdateWorkshopLog(_WorkshopLogPPT)
    End Function

    Public Function DeleteWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.DeleteWorkshopLog(_WorkshopLogPPT)
    End Function

    Public Function DeleteWorkshopLogFromView(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.DeleteWorkshopLogFromView(_WorkshopLogPPT)
    End Function

    Public Function GetWorkshopCodeForComboBox(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataTable
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetWorkshopCodeForComboBox(_WorkshopLogPPT)
    End Function

    Public Function GetWorkshopCode(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataTable
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetWorkshopCode(_WorkshopLogPPT)
    End Function

    Public Function GetIsValidKey(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetIsValidKey(_WorkshopLogPPT)
    End Function

    Public Function GetAccountDescription(ByVal _WorkshopLogPPT As WorkshopLogPPT) As String
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.GetAccountDescription(_WorkshopLogPPT)
    End Function

    Public Sub GetOperatorName(ByVal _WorkshopLogPPT As WorkshopLogPPT) 'As Object
        _WorkshopLogDAL = New WorkshopLogDAL
        'Return _WorkshopLogDAL.GetOperatorName(_WorkshopLogPPT)
        _WorkshopLogDAL.GetOperatorName(_WorkshopLogPPT)
    End Sub

    'Public Function GetActiveMonthYear(ByVal _WorkshopLogPPT As WorkshopLogPPT) As WorkshopLogCollection
    '_WorkshopLogDAL = New WorkshopLogDAL
    '    Return WorkshopLogDAL.GetActiveMonthYear(_WorkshopLogPPT)
    'End Function

#End Region

    Public Function WorkshopLogRecordIsExist(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Object
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.WorkshopLogRecordIsExist(_WorkshopLogPPT)
    End Function

    Public Function IsVHWSCodeExist(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer
        _WorkshopLogDAL = New WorkshopLogDAL
        Return _WorkshopLogDAL.IsVHWSCodeExist(_WorkshopLogPPT)
    End Function

End Class

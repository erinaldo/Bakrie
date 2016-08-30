Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class ImportAllowanceBOL
    Public Function Save(ppt As ImportAllowancePPT) As Boolean
        Dim obj As New ImportAllowanceDAL
        Return obj.Save(ppt)
    End Function

    Public Function GetExcel() As DataSet
        Dim obj As New ImportAllowanceDAL
        Return obj.GetExcel()
    End Function

    Public Function UpdateExcel(errorstring As String, empID As String, allowDedID As String) As Boolean
        Dim obj As New ImportAllowanceDAL
        obj.UpdateExcel(errorstring, empID, allowDedID)
    End Function

    Public Function UpdateExcels(objectVariable As IEnumerable(Of String))
        Dim obj As New ImportAllowanceDAL
        obj.UpdateExcels(objectVariable)
    End Function
End Class

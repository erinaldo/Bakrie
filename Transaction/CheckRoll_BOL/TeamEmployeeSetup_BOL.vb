Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class TeamEmployeeSetup_BOL
    Public Function TeamEmployeeModifySave(objTeamEmployee As TeamEmployeeSetup_PPT) As Boolean
        Dim objDAL = New TeamEmployeeSetup_DAL
        Return objDAL.TeamEmployeeModifySave(objTeamEmployee)
    End Function

    Public Function TeamHeaderUpdate(objTeamEmployee As TeamEmployeeSetup_PPT) As Boolean
        Dim objDAL = New TeamEmployeeSetup_DAL
        Return objDAL.TeamHeaderUpdate(objTeamEmployee)
    End Function

    Public Function EmployeeIsExistDailyAttendance(EmpID As String) As DataTable
        Dim objDAL = New TeamEmployeeSetup_DAL
        Return objDAL.EmployeeIsExistDailyAttendance(EmpID)
    End Function
End Class

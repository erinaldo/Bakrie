Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL

Public Class DailyActivityTeamBOL
    Public Shared Function DailyTeamActivitySelect() As DataTable
        Dim dt As DataTable
        dt = DailyActivityTeam_DAL.DailyTeamActivitySelect()
        Return dt
    End Function

    Public Shared Function DailyTeamActivityisExist(ByVal ddate As String) As DataTable
        Dim dt As New DataTable
        dt = DailyActivityTeam_DAL.DailyTeamActivityisExist(ddate)
        Return dt
    End Function

    Public Shared Function DailyAttendanceWithTeamSelect(ByVal TeamName As String, ByVal Rdate As String) As DataTable
        Dim dt As New DataTable
        dt = DailyActivityTeam_DAL.DailyAttendanceWithTeamSelect(TeamName, Rdate)
        Return dt
    End Function

    Public Shared Function CRDailyAttendanceNikSelect(ByVal EmpCode As String, ByVal Mandor As String, ByVal Status As String, ByVal EmpName As String, ByVal AttDate As Date) As DataTable
        Dim dt As New DataTable
        dt = DailyActivityTeam_DAL.CRDailyAttendanceNikSelect(EmpCode, Mandor, Status, EmpName, AttDate)
        Return dt
    End Function

    Public Shared Function Save(ByVal obj As DailyActivityTeam_DAL, ByRef dt As DataTable) As Integer
        Return obj.Update(dt)
    End Function

    Public Shared Function DailyTeamActivityIsSelected(ByVal DailyTeamActivityID As String, ByVal RDate As String) As DataTable
        Dim dt As New DataTable
        dt = DailyActivityTeam_DAL.DailyTeamActivityIsSelected(DailyTeamActivityID, RDate)
        Return dt
    End Function

    Public Shared Function DailyGangEmployeeSetupSelect(gangMasterID As String) As DataTable
        Dim obj As New DailyActivityTeam_DAL
        Return obj.DailyGangEmployeeSetupSelect(gangMasterID)
    End Function

    Public Shared Function DailyTeamActivityAutoInsert(ByVal DDate As Date) As DataTable
        Dim dt As New DataTable
        dt = DailyActivityTeam_DAL.DailyTeamActivityAutoInsert(DDate)
        Return dt
    End Function

    Public Shared Function DailyTeamActivityDelete(ByVal DailyTeamActivityID As String, ByVal ActivityCode As String, ByVal dtRdate As Date, ByVal OutputType As String) As DataTable
        Dim dt As New DataTable
        dt = DailyActivityTeam_DAL.DailyTeamActivityDelete(DailyTeamActivityID, ActivityCode, dtRdate, OutputType)
        Return dt
    End Function

    Public Shared Function AttSummaryWithTeamProcess()
        DailyActivityTeam_DAL.AttSummaryWithTeamProcess()
        Return 0
    End Function

    Public Shared Function UploadSalary(ByVal SalaryProcDate As Date)
        DailyActivityTeam_DAL.UploadSalary(SalaryProcDate)
        Return 0
    End Function
End Class

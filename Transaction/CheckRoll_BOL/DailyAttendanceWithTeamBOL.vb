Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL

Public Class DailyAttendanceWithTeamBOL
    Public Shared Function AttendSummaryWithTeam(ByVal Empid As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendanceWithTeam_DAL.AttendSummaryWithTeam(Empid) '<--- Prilaku sama dengan No team
        Return dt
    End Function

    Public Shared Function GetMaxOTHours(ByVal EmpCode As String, ByVal Rdate As Date) As DataTable
        Return DailyAttendanceWithTeam_DAL.GetMaxOTHours(EmpCode, Rdate)
    End Function

End Class

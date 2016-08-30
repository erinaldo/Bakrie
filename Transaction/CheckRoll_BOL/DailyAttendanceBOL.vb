Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL
Public Class DailyAttendanceBOL
    Public Shared Function CREstateSelect(ByVal EstateName As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CREstateSelect(EstateName)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNoTeamView(ByVal Rdate As String, ByVal EmpId As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.DailyAttendanceNoTeamView(Rdate, EmpId)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNoTeamIsExist(ByVal DailyReceptionID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.DailyAttendanceNoTeamIsExist(DailyReceptionID)
        Return dt
    End Function
    Public Shared Function CRKTView(ByVal EmpID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRKTView(EmpID)
        Return dt
    End Function
    Public Shared Function DailyActivityDistributionIsSelect(ByVal DailyReceptionDetID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.DailyActivityDistributionIsSelect(DailyReceptionDetID)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNoTeamViewAll(ByVal RDate As String, ByVal EmpNik As String, ByVal EmpName As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.DailyAttendanceNoTeamViewAll(RDate, EmpNik, EmpName)
        Return dt
    End Function
    Public Shared Function CRTAnalysisView(ByVal TAnalysisID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRTAnalysisView(TAnalysisID)
        Return dt
    End Function
    Public Shared Function CRDistributionSetupLookup(ByVal DistributionDescp As String, ByVal DistributionSetupID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRDistributionSetupLookup(DistributionDescp, DistributionSetupID)
        Return dt
    End Function
    Public Shared Function CRMVehicleSelect(ByVal VHID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRMVehicleSelect(VHID)
        Return dt
    End Function
    Public Shared Function CRPremiDriver(ByVal BlockID As String, ByVal AttendanceSetupID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRPremiDriver(BlockID, AttendanceSetupID)
        Return dt
    End Function
    Public Shared Function CRCOASelect(ByVal COACODE As String, ByVal ExpenditureAg As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRCOASelect(COACODE, ExpenditureAg)
        Return dt
    End Function
    Public Shared Function CRPHoliday(ByVal PHdate As Date) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.CRPHoliday(PHdate)
        Return dt
    End Function
    Public Shared Function AttendSummaryNoTeam(ByVal Empid As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.AttendSummaryNoTeam(Empid)
        Return dt
    End Function

    Public Shared Function ReceptionSummaryNoTeam(ByVal Empid As String, ByVal Blockid As String) As Integer
        'Dim dt As New DataTable
        ' Ahad, 29 Nov 2009, 19:06
        ' By Dadang
        ' Function ini dirubah jadi Integer bukan mengembalikan DataTable lagi
        Dim retValue As Integer

        'dt = DailyAttendance_DAL.ReceptionSummaryNoTeam(Empid, Blockid)
        retValue = DailyAttendance_DAL.ReceptionSummaryNoTeam(Empid, Blockid)
        Return retValue
    End Function

    Public Shared Function ReceptionSummaryTeam(ByVal MandorID As String, ByVal KraniID As String, ByVal Empid As String, ByVal Blockid As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.ReceptionSummaryTeam(MandorID, KraniID, Empid, Blockid)
        Return dt
    End Function
    Public Shared Function GetTeamName(ByVal MandorID As String, ByVal KraniID As String) As DataTable
        Dim dt As New DataTable
        dt = DailyAttendance_DAL.GetTeamName(MandorID, KraniID)
        Return dt
    End Function
End Class

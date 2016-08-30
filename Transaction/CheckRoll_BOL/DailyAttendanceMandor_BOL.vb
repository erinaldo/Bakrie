Imports CheckRoll_DAL
Imports CheckRoll_PPT

Public Class DailyAttendanceMandor_BOL

    Public Function AttendanceSetupSelect() As DataTable
        Dim objMandor As New DailyAttendanceMandor_DAL
        Return objMandor.AttendanceSetupSelect()
    End Function

    Public Function DailyAttendanceMandorGenerate(dates As Date) As DataTable
        Dim objMandor As New DailyAttendanceMandor_DAL
        Return objMandor.DailyAttendanceMandorGenerate(dates)
    End Function

    Public Function DailyAttendanceMandorBeforeInsert(dates As String) As Boolean
        Dim objMandor As New DailyAttendanceMandor_DAL
        Return objMandor.DailyAttendanceMandorBeforeInsert(dates)
    End Function

    Public Function DailyAttendanceMandorInsert(objMandor As DailyAttendanceMandor_PPT) As Boolean
        Dim obj As New DailyAttendanceMandor_DAL
        Return obj.DailyAttendanceMandorInsert(objMandor)
    End Function

    Public Function DailyAttendanceMandorViewSelect(dates As Date) As DataTable
        Dim obj As New DailyAttendanceMandor_DAL
        Return obj.DailyAttendanceMandorViewSelect(dates)
    End Function

    Public Function DailyAttendanceMandorDetailSelect(dates As DateTime) As DataTable
        Dim obj As New DailyAttendanceMandor_DAL
        Return obj.DailyAttendanceMandorDetailSelect(dates)
    End Function
End Class

Imports System.Data.SqlClient
Imports CheckRoll_PPT
Imports Common_DAL
Imports Common_PPT

Public Class DailyAttendanceMandor_DAL

    Public Function AttendanceSetupSelect() As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(3) As SqlParameter

        param(0) = New SqlParameter("@AttendanceSetupID", DBNull.Value)
        param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(2) = New SqlParameter("@AttendanceCode", "11")
        param(3) = New SqlParameter("@AttendType", DBNull.Value)

        dt = adap.ExecQuery("[Checkroll].[AttendanceSetupSelect]", param).Tables(0)
        Return dt
    End Function

    Public Function DailyAttendanceMandorGenerate(dates As Date) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@DDate", dates)
        dt = adap.ExecQuery("[Checkroll].[DailyAttendanceMandorGenerate]", param).Tables(0)
        Return dt
    End Function

    Public Function DailyAttendanceMandorInsert(objMandor As DailyAttendanceMandor_PPT) As Boolean
        Dim adap As New SQLHelp
        Dim param(12) As SqlParameter
        Try
            param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            param(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            param(2) = New SqlParameter("@RDate", objMandor.RDate)
            param(3) = New SqlParameter("@EmpID", objMandor.NIK)
            param(4) = New SqlParameter("@AttendanceSetupID", objMandor.AttID)
            param(5) = New SqlParameter("@DailyOT", objMandor.DailyOT)
            param(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            param(7) = New SqlParameter("@CreatedOn", DateTime.Now)
            param(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            param(9) = New SqlParameter("@ModifiedOn", DateTime.Now)
            param(10) = New SqlParameter("@KraniPremiKg", objMandor.KraniPremiKg)
            param(11) = New SqlParameter("@BlockId", objMandor.FieldNo)
            param(12) = New SqlParameter("@Tph", objMandor.TPHNo)

            adap.ExecQuery("[Checkroll].[DailyAttendanceMandorInsert]", param)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            Return False
        End Try        
    End Function

    Public Function DailyAttendanceMandorViewSelect(dates As Date) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If IsDate(dates) Then
            param(1) = New SqlParameter("@RDate", dates)
        Else
            param(1) = New SqlParameter("@RDate", DBNull.Value)
        End If

        dt = adap.ExecQuery("[Checkroll].[DailyAttendanceMandorViewSelect]", param).Tables(0)
        Return dt
    End Function

    Public Function DailyAttendanceMandorBeforeInsert(dates As String) As Boolean
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter
        Try
            param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            param(1) = New SqlParameter("@RDate", dates)

            adap.ExecQuery("[Checkroll].[DailyAttendanceMandorBeforeInsert]", param)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            Return False
        End Try
    End Function

    Public Function DailyAttendanceMandorDetailSelect(dates As DateTime) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@RDate", dates.ToString("yyy-MM-dd"))

        dt = adap.ExecQuery("[Checkroll].[DailyAttendanceMandorDetailSelect]", param).Tables(0)
        Return dt
    End Function


    Public Shared Sub UpdateOTValue(ByVal ID As String, ByVal TotalOTValue As Double)

        Dim params(1) As SqlParameter
        Dim adap As New SQLHelp
        
        params(0) = New SqlParameter("@ID", SqlDbType.Int)
        params(0).Value = ID


        params(1) = New SqlParameter("@TotalOT", SqlDbType.Decimal)
        params(1).Value = TotalOTValue

        adap.ExecQuery("[Checkroll].[DailyAttendanceMandorUpdateOTValue]", params)


    End Sub


    Public Shared Function GetGangDetailsByEmployee(ByVal EmpID As String, ByVal Rdate As DateTime) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(2) As SqlParameter

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@EmpID", EmpID)
        param(2) = New SqlParameter("@DDate", Rdate.ToString("yyy-MM-dd"))

        dt = adap.ExecQuery("[Checkroll].[GetGangDetailsByEmployee]", param).Tables(0)
        Return dt
    End Function

End Class

Imports CheckRoll_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class TeamEmployeeSetup_DAL
    Public Function TeamEmployeeModifySave(objTeamEmployee As TeamEmployeeSetup_PPT) As Boolean
        Try
            Dim objdb As New SQLHelp
            Dim params(9) As SqlParameter
            params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            params(2) = New SqlParameter("@GangMasterID", objTeamEmployee.GangMasterID)
            params(3) = New SqlParameter("@EmpID", objTeamEmployee.EmpID)
            params(4) = New SqlParameter("@MandorBesarID", objTeamEmployee.MandorBesarID)
            params(5) = New SqlParameter("@MandorID", objTeamEmployee.MandorID)
            params(6) = New SqlParameter("@KraniID", objTeamEmployee.KraniID)
            params(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            params(8) = New SqlParameter("@DDAte", objTeamEmployee.DailyDate)
            params(9) = New SqlParameter("@DailyTeamActivityID", objTeamEmployee.DailyTeamActivityID)
            objdb.ExecQuery("[Checkroll].[GangEmployeeSetupModify]", params)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function TeamHeaderUpdate(objTeamEmployee As TeamEmployeeSetup_PPT) As Boolean
        Try
            Dim obj As New SQLHelp
            Dim params(5) As SqlParameter
            params(0) = New SqlParameter("@MandorBesarID", objTeamEmployee.MandorBesarID)
            params(1) = New SqlParameter("@MandorID", objTeamEmployee.MandorID)
            params(2) = New SqlParameter("@KraniID", objTeamEmployee.KraniID)
            params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(4) = New SqlParameter("@DailyDate", objTeamEmployee.DailyDate)
            params(5) = New SqlParameter("@GangMasterID", objTeamEmployee.GangMasterID)
            obj.ExecQuery("[Checkroll].[DailyTeamGangMasterUpdate]", params)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return False
        End Try
    End Function

    Public Function EmployeeIsExistDailyAttendance(EmpID As String) As DataTable
        Try
            Dim obj As New SQLHelp
            Dim params(2) As SqlParameter
            Dim dt As New DataTable
            params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            params(1) = New SqlParameter("@EmpID", EmpID)
            params(2) = New SqlParameter("@RDate", DateTime.Now.ToString("yyy-MM-dd"))
            dt = obj.ExecQuery("[Checkroll].[EmployeeIsExistDailyAttendance]", params).Tables(0)
            Return dt
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            Return New DataTable()
        End Try
    End Function
End Class

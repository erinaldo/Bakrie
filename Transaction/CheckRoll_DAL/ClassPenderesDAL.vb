Imports CheckRoll_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT

Public Class ClassPenderesDAL

    Public Shared Function ClassPenderesEmployeeSelect(DateRubber As String) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@DateRubber", DateRubber)
        dt = adap.ExecQuery("[Checkroll].[CREmployeeByWorktypePenderes]", param).Tables(0)
        Return dt
    End Function

    Public Shared Function ClassPenderesMonthDetailSelect(GradeMonthId As String, DateRubber As String) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@GradeMonthId", GradeMonthId)
        param(1) = New SqlParameter("@DateRubber", DateRubber)
        dt = adap.ExecQuery("[Checkroll].[GradeMonthDetailsSelect]", param).Tables(0)
        Return dt
    End Function

    Public Shared Function ClassPenderesMonthSelectAll(month As String, year As String) As DataTable
        Dim dt As New DataTable
        Dim adap As New SQLHelp
        Dim param(1) As SqlParameter
        If month Is Nothing Then
            param(0) = New SqlParameter("@ZMonth", DBNull.Value)
        Else
            param(0) = New SqlParameter("@ZMonth", month)
        End If

        If year Is Nothing Then
            param(1) = New SqlParameter("@ZYear", DBNull.Value)
        Else
            param(1) = New SqlParameter("@ZYear", year)
        End If
        dt = adap.ExecQuery("[Checkroll].[GradeMonthSelect]", param).Tables(0)
        Return dt
    End Function

    Public Function ClassPenderesInsert(objClassPenderesPPT As ClassPenderesPPT) As DataTable
        Dim obj As New SQLHelp
        Try
            Dim param(2) As SqlParameter
            param(0) = New SqlParameter("@ZMonth", objClassPenderesPPT.ZMonth)
            param(1) = New SqlParameter("@ZYear", objClassPenderesPPT.ZYear)
            param(2) = New SqlParameter("@TotalBudget", objClassPenderesPPT.TotalBudget)
            Return obj.ExecQuery("[Checkroll].[GradeMonthInsert]", param).Tables(0)
        Catch ex As Exception
        End Try
    End Function

    Public Function ClassPenderesDetailsDelete(id As Integer) As Integer
        Dim obj As New SQLHelp
        Try
            Dim param(0) As SqlParameter
            param(0) = New SqlParameter("@GradeMonthID", id)
            obj.ExecQuery("[Checkroll].[GradeMonthDetailsDelete]", param)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ClassPenderesDetailInsert(objClassPenderesPPT As ClassPenderesDetailPPT) As Integer
        Dim obj As New SQLHelp
        Dim rowsAffected As Integer
        Try
            Dim param(2) As SqlParameter
            param(0) = New SqlParameter("@GradeMonthId", objClassPenderesPPT.GradeMonthId)
            param(1) = New SqlParameter("@EmpId", objClassPenderesPPT.EmpId)
            param(2) = New SqlParameter("@Class", objClassPenderesPPT.Classes)
            obj.ExecQuery("[Checkroll].[GradeMonthDetailsInsert]", param)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function SelectAllDataRubber(periode As Date) As DataTable
        Dim obj As New SQLHelp
        Dim rowsAffected As Integer
        Try
            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@month", periode.Month)
            param(1) = New SqlParameter("@year", periode.Year)
            Return obj.ExecQuery("[Checkroll].[GetAllDataEmployeRubber]", param).Tables(0)
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return Nothing
    End Function

    Public Function UpdateDailyReceptionForRubber(AttCode As String, DateRubber As DateTime, NIk As String,
                           DRRubberID As String, DailyReceiptionID As String, EstateCode As String,
                           Latex As Double, Drc As Double, CupLamp As Double, DRCCupLump As Double,
                           TreeLace As Double, DRCTreeLace As Double) As Boolean
        Try
            Dim adap As New SQLHelp
            Dim param(11) As SqlParameter
            param(0) = New SqlParameter("@AttCode", AttCode)
            param(1) = New SqlParameter("@DateRubber", DateRubber)
            param(2) = New SqlParameter("@NIk", NIk)
            param(3) = New SqlParameter("@DRRubberID", DRRubberID)
            param(4) = New SqlParameter("@DailyReceiptionID", DailyReceiptionID)
            param(5) = New SqlParameter("@EstateCode", EstateCode)
            param(6) = New SqlParameter("@Latex", Latex)
            param(7) = New SqlParameter("@Drc", Drc)
            param(8) = New SqlParameter("@CupLamp", CupLamp)
            param(9) = New SqlParameter("@DRCCupLump", DRCCupLump)
            param(10) = New SqlParameter("@TreeLace", TreeLace)
            param(11) = New SqlParameter("@DRCTreeLace", DRCTreeLace)
            adap.ExecQuery("[Checkroll].[UpdatePremiRubber]", param)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

End Class

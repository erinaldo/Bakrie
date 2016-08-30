Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class YearlyWorkingDaysDAL
    Public Shared Function YearlyWorkingDaysIsExist(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        'param(2) = New SqlParameter("@Month", oMonthlyWorkingDaysPPT.Month)
        dt = objdb.ExecQuery("[Budget].[YearlyWorkingDaysIsExist]", param).Tables(0)
        Return dt
    End Function
    Public Shared Function YearlyWorkingDaysNoOfDaysGET(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As YearlyWorkingDaysPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[YearlyWorkingDaysNoOfDaysGET]", Parms).Tables(0)
        Dim YearlyWorkingPPT As New YearlyWorkingDaysPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("Days").ToString <> "" Then
                YearlyWorkingPPT.Days = dt.Rows(0).Item("Days").ToString.Trim
            End If
            If dt.Rows(0).Item("PH").ToString <> "" Then
                YearlyWorkingPPT.PH = dt.Rows(0).Item("PH").ToString.Trim
            End If
            If dt.Rows(0).Item("Sundays").ToString <> "" Then
                YearlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim
            End If
            If dt.Rows(0).Item("Month").ToString <> "" Then
                YearlyWorkingPPT.Month = dt.Rows(0).Item("Month").ToString.Trim
            End If

            'MonthlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim

        End If
        Return YearlyWorkingPPT
    End Function

    Public Shared Function YearlyWorkingDaysInsert(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(14) As SqlParameter

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(2) = New SqlParameter("@Days", oYearlyWorkingDaysPPT.Days)
        param(3) = New SqlParameter("@Sundays", oYearlyWorkingDaysPPT.Sundays)
        param(4) = New SqlParameter("@PH", oYearlyWorkingDaysPPT.PH)
        param(5) = New SqlParameter("@AL", oYearlyWorkingDaysPPT.AL)
        param(6) = New SqlParameter("@SaL", oYearlyWorkingDaysPPT.SaL)
        param(7) = New SqlParameter("@SL", oYearlyWorkingDaysPPT.SL)
        param(8) = New SqlParameter("@RaindaysPerMonth", oYearlyWorkingDaysPPT.RaindaysPerMonth)
        param(9) = New SqlParameter("@RainDays", oYearlyWorkingDaysPPT.RainDays)
        param(10) = New SqlParameter("@TotalDays", oYearlyWorkingDaysPPT.TotalDays)

        param(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        param(12) = New SqlParameter("@CreatedOn", Date.Today())
        param(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(14) = New SqlParameter("@ModifiedOn", Date.Today())


        ds = objdb.ExecQuery("[Budget].[YearlyWorkingDaysInsert]", param)
        Return ds
    End Function
    Public Shared Function YearlyWorkingDaysSelect(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oYearlyWorkingDaysPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[YearlyWorkingDaysSelect]", Parms).Tables(0)

        Return dt
    End Function
    Public Shared Function YearlyWorkingDaysUpdate(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(12) As SqlParameter

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(2) = New SqlParameter("@Days", oYearlyWorkingDaysPPT.Days)
        param(3) = New SqlParameter("@Sundays", oYearlyWorkingDaysPPT.Sundays)
        param(4) = New SqlParameter("@PH", oYearlyWorkingDaysPPT.PH)
        param(5) = New SqlParameter("@AL", oYearlyWorkingDaysPPT.AL)
        param(6) = New SqlParameter("@SaL", oYearlyWorkingDaysPPT.SaL)
        param(7) = New SqlParameter("@SL", oYearlyWorkingDaysPPT.SL)
        param(8) = New SqlParameter("@RaindaysPerMonth", oYearlyWorkingDaysPPT.RaindaysPerMonth)
        param(9) = New SqlParameter("@RainDays", oYearlyWorkingDaysPPT.RainDays)
        param(10) = New SqlParameter("@TotalDays", oYearlyWorkingDaysPPT.TotalDays)

     
        param(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(12) = New SqlParameter("@ModifiedOn", Date.Today())


        ds = objdb.ExecQuery("[Budget].[YearlyWorkingDaysUpdate]", param)
        Return ds
    End Function
    Public Shared Function YearlyWorkingDaysDelete(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        ds = objdb.ExecQuery("[Budget].[YearlyWorkingDaysDelete]", Parms)

        Return ds

    End Function
End Class

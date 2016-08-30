Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT

Public Class MonthlyWorkingDaysDAL
    Public Shared Function isMonthYearExists(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(2) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(2) = New SqlParameter("@Month", oMonthlyWorkingDaysPPT.Month)
        dt = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysIsExist]", param).Tables(0)
        Return dt
    End Function
    Public Shared Function MonthlyWorkingDaysInsert(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(9) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(2) = New SqlParameter("@Month", oMonthlyWorkingDaysPPT.Month)

        param(3) = New SqlParameter("@Days", oMonthlyWorkingDaysPPT.Days)
        param(4) = New SqlParameter("@Sundays", oMonthlyWorkingDaysPPT.Sundays)
        If oMonthlyWorkingDaysPPT.PH <> 0 Then
            param(5) = New SqlParameter("@PH", oMonthlyWorkingDaysPPT.PH)
        Else
            param(5) = New SqlParameter("@PH", System.DBNull.Value)
        End If

        param(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        param(7) = New SqlParameter("@CreatedOn", Date.Today())
        param(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(9) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysInsert]", param)
        Return ds
    End Function
    Public Shared Function MonthlyWorkingDaysSelect(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oMonthlyWorkingDaysPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysSelect]", Parms).Tables(0)

        Return dt
    End Function
    Public Shared Function MonthlyWorkingDaysViewSelect(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oMonthlyWorkingDaysPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysViewSelect]", Parms).Tables(0)

        Return dt

    End Function
    Public Shared Function MonthlyWorkingDaysTotalCalculation(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As MonthlyWorkingDaysPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oMonthlyWorkingDaysPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysTotalCalculation]", Parms).Tables(0)
        Dim MonthlyWorkingPPT As New MonthlyWorkingDaysPPT
        If dt.Rows.Count <> 0 Then
            MonthlyWorkingPPT.Days = dt.Rows(0).Item("Days").ToString.Trim
            MonthlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim
            MonthlyWorkingPPT.PH = dt.Rows(0).Item("PH").ToString.Trim
        End If
        Return MonthlyWorkingPPT
    End Function
    Public Shared Function MonthlyWorkingDaysUpdate(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(7) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(2) = New SqlParameter("@Month", oMonthlyWorkingDaysPPT.Month)

        param(3) = New SqlParameter("@Days", oMonthlyWorkingDaysPPT.Days)
        param(4) = New SqlParameter("@Sundays", oMonthlyWorkingDaysPPT.Sundays)
        If oMonthlyWorkingDaysPPT.PH <> 0 Then
            param(5) = New SqlParameter("@PH", oMonthlyWorkingDaysPPT.PH)
        Else
            param(5) = New SqlParameter("@PH", System.DBNull.Value)
        End If

        param(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(7) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysUpdate]", param)
        Return ds
    End Function
    Public Shared Function MonthlyWorkingDaysDelete(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oMonthlyWorkingDaysPPT.BudgetYear)
        If oMonthlyWorkingDaysPPT.Month <> 0 Then
            Parms(2) = New SqlParameter("@Month", oMonthlyWorkingDaysPPT.Month)
        Else
            Parms(2) = New SqlParameter("@Month", System.DBNull.Value)
        End If


        ds = objdb.ExecQuery("[Budget].[MonthlyWorkingDaysDelete]", Parms)

        Return ds

    End Function
End Class

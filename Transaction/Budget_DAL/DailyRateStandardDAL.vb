Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class DailyRateStandardDAL
    Public Shared Function PlantationCurrentUMPSandIncreasePerDecGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[PlantationCurrentUMPSandIncreasePerDecGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("PlantationCurrentUMPS").ToString <> "" Then
                DailyRatePPT.PlantationCurrentUMPS = dt.Rows(0).Item("PlantationCurrentUMPS").ToString.Trim
            End If
            If dt.Rows(0).Item("PlantationIncreasePerDec").ToString <> "" Then
                DailyRatePPT.PlantationIncreasePerDec = dt.Rows(0).Item("PlantationIncreasePerDec").ToString.Trim
            End If
            'If dt.Rows(0).Item("Sundays").ToString <> "" Then
            '    YearlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim
            'End If
            'If dt.Rows(0).Item("Month").ToString <> "" Then
            '    YearlyWorkingPPT.Month = dt.Rows(0).Item("Month").ToString.Trim
            'End If

            'MonthlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim

        End If
        Return DailyRatePPT
    End Function
    Public Shared Function KeyValuePairAndMSCountGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[KeyValuePairAndMSCountGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("KeyValuePairs").ToString <> "" Then
                DailyRatePPT.KeyValuePairs = dt.Rows(0).Item("KeyValuePairs").ToString.Trim
            End If
            If dt.Rows(0).Item("RiceCount").ToString <> "" Then
                DailyRatePPT.RiceCount = dt.Rows(0).Item("RiceCount").ToString.Trim
            End If
            'If dt.Rows(0).Item("Sundays").ToString <> "" Then
            '    YearlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim
            'End If
            'If dt.Rows(0).Item("Month").ToString <> "" Then
            '    YearlyWorkingPPT.Month = dt.Rows(0).Item("Month").ToString.Trim
            'End If

            'MonthlyWorkingPPT.Sundays = dt.Rows(0).Item("Sundays").ToString.Trim

        End If
        Return DailyRatePPT
    End Function
    Public Shared Function RiceTotalGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[RiceTotalGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("Total").ToString <> "" Then
                DailyRatePPT.RiceKgs = dt.Rows(0).Item("Total").ToString.Trim
            End If
          

        End If
        Return DailyRatePPT
    End Function
    Public Shared Function TotalDaysGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[TotalDaysGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("TotalDays").ToString <> "" Then
                DailyRatePPT.WorkingDays = dt.Rows(0).Item("TotalDays").ToString.Trim
            End If


        End If
        Return DailyRatePPT
    End Function
    Public Shared Function RateInPrevYearBudgetGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oDailyRateStandardPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[RateInPrevYearBudgetGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("PrevYearBudget").ToString <> "" Then
                DailyRatePPT.PrevYearBudget = dt.Rows(0).Item("PrevYearBudget").ToString.Trim
            End If
        End If
        Return DailyRatePPT
    End Function
    Public Shared Function ExcRateUStoRPGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[ExcRateUStoRPGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("ExcRateUStoRP").ToString <> "" Then
                DailyRatePPT.ExcRateUStoRP = dt.Rows(0).Item("ExcRateUStoRP").ToString.Trim
            End If
        End If
        Return DailyRatePPT
    End Function
    Public Shared Function PrevYearExcRateUStoRPGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oDailyRateStandardPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[ExcRateUStoRPGET]", Parms).Tables(0)
        Dim DailyRatePPT As New DailyRateStandardPPT
        If dt.Rows.Count <> 0 Then
            If dt.Rows(0).Item("ExcRateUStoRP").ToString <> "" Then
                DailyRatePPT.ExcRateUStoRP = dt.Rows(0).Item("ExcRateUStoRP").ToString.Trim
            End If
        End If
        Return DailyRatePPT
    End Function
End Class

Imports Budget_PPT
Imports Budget_DAL
Public Class DailyRateStandardBOL
    Public Shared Function PlantationCurrentUMPSandIncreasePerDecGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.PlantationCurrentUMPSandIncreasePerDecGET(oDailyRateStandardPPT)
    End Function
    Public Shared Function KeyValuePairAndMSCountGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.KeyValuePairAndMSCountGET(oDailyRateStandardPPT)
    End Function
    Public Shared Function RiceTotalGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.RiceTotalGET(oDailyRateStandardPPT)
    End Function
    Public Shared Function TotalDaysGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.TotalDaysGET(oDailyRateStandardPPT)
    End Function
    Public Shared Function RateInPrevYearBudgetGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.RateInPrevYearBudgetGET(oDailyRateStandardPPT)
    End Function
    Public Shared Function ExcRateUStoRPGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.ExcRateUStoRPGET(oDailyRateStandardPPT)
    End Function
    Public Shared Function PrevYearExcRateUStoRPGET(ByVal oDailyRateStandardPPT As DailyRateStandardPPT) As DailyRateStandardPPT
        Return DailyRateStandardDAL.PrevYearExcRateUStoRPGET(oDailyRateStandardPPT)
    End Function
End Class

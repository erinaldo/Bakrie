Imports Budget_DAL
Imports Budget_PPT

Public Class MandayRateBOL
    Public Shared Function MandayRateInsert(ByVal oMandayRatePPT As MandayRatePPT) As DataSet
        Return MandayRateDAL.MandayRateInsert(oMandayRatePPT)
    End Function
    Public Shared Function MandayRateUpdate(ByVal oMandayRatePPT As MandayRatePPT) As DataSet
        Return MandayRateDAL.MandayRateUpdate(oMandayRatePPT)
    End Function
    Public Shared Function MandayRateYearIsExist(ByVal oMandayRatePPT As MandayRatePPT) As DataTable
        Return MandayRateDAL.MandayRateYearIsExist(oMandayRatePPT)
    End Function
    Public Shared Function MandayRateSelect(ByVal oMandayRatePPT As MandayRatePPT) As DataTable
        Return MandayRateDAL.MandayRateSelect(oMandayRatePPT)
    End Function
    Public Shared Function MandayRateDelete(ByVal oMandayRatePPT As MandayRatePPT) As DataSet
        Return MandayRateDAL.MandayRateDelete(oMandayRatePPT)
    End Function

End Class

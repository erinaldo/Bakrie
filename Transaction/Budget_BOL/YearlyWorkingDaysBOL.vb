Imports Budget_PPT
Imports Budget_DAL
Public Class YearlyWorkingDaysBOL
    Public Shared Function YearlyWorkingDaysIsExist(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataTable
        Return YearlyWorkingDaysDAL.YearlyWorkingDaysIsExist(oYearlyWorkingDaysPPT)
    End Function
    Public Shared Function YearlyWorkingDaysNoOfDaysGET(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As YearlyWorkingDaysPPT
        Return YearlyWorkingDaysDAL.YearlyWorkingDaysNoOfDaysGET(oYearlyWorkingDaysPPT)
    End Function
    Public Shared Function YearlyWorkingDaysInsert(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataSet
        Return YearlyWorkingDaysDAL.YearlyWorkingDaysInsert(oYearlyWorkingDaysPPT)
    End Function
    Public Shared Function YearlyWorkingDaysUpdate(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataSet
        Return YearlyWorkingDaysDAL.YearlyWorkingDaysUpdate(oYearlyWorkingDaysPPT)
    End Function
    Public Shared Function YearlyWorkingDaysSelect(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataTable
        Return YearlyWorkingDaysDAL.YearlyWorkingDaysSelect(oYearlyWorkingDaysPPT)
    End Function
    Public Shared Function YearlyWorkingDaysDelete(ByVal oYearlyWorkingDaysPPT As YearlyWorkingDaysPPT) As DataSet
        Return YearlyWorkingDaysDAL.YearlyWorkingDaysDelete(oYearlyWorkingDaysPPT)
    End Function
End Class

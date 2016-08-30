Imports Budget_DAL
Imports Budget_PPT
Public Class MonthlyWorkingDaysBOL
    Public Shared Function isMonthYearExists(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataTable
        Return MonthlyWorkingDaysDAL.isMonthYearExists(oMonthlyWorkingDaysPPT)
    End Function
    Public Shared Function MonthlyWorkingDaysInsert(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataSet
        Return MonthlyWorkingDaysDAL.MonthlyWorkingDaysInsert(oMonthlyWorkingDaysPPT)
    End Function
    Public Shared Function MonthlyWorkingDaysSelect(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataTable
        Return MonthlyWorkingDaysDAL.MonthlyWorkingDaysSelect(oMonthlyWorkingDaysPPT)
    End Function
    Public Shared Function MonthlyWorkingDaysViewSelect(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataTable
        Return MonthlyWorkingDaysDAL.MonthlyWorkingDaysViewSelect(oMonthlyWorkingDaysPPT)
    End Function
    Public Shared Function MonthlyWorkingDaysTotalCalculation(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As MonthlyWorkingDaysPPT
        Return MonthlyWorkingDaysDAL.MonthlyWorkingDaysTotalCalculation(oMonthlyWorkingDaysPPT)
    End Function
    Public Shared Function MonthlyWorkingDaysUpdate(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataSet
        Return MonthlyWorkingDaysDAL.MonthlyWorkingDaysUpdate(oMonthlyWorkingDaysPPT)
    End Function
    Public Shared Function MonthlyWorkingDaysDelete(ByVal oMonthlyWorkingDaysPPT As MonthlyWorkingDaysPPT) As DataSet
        Return MonthlyWorkingDaysDAL.MonthlyWorkingDaysDelete(oMonthlyWorkingDaysPPT)
    End Function
End Class

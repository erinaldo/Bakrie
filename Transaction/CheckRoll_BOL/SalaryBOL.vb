Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL
Public Class SalaryBOL
    Public Shared Function SalaryNikSelect(ByVal EstateID As String, ByVal Status As String) As DataTable
        Dim dt As New DataTable
        dt = Salary_DAL.SalaryNikSelect(EstateID, Status)
        Return dt
    End Function
    Public Shared Function CRSalaryFiscalYearSelect(ByVal Period As String) As DataTable
        Dim dt As New DataTable
        dt = Salary_DAL.CRSalaryFiscalYearSelect(Period)
        Return dt
    End Function
End Class

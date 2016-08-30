Imports Common_DAL
Imports System.Data.SqlClient
Imports Common_PPT


Public Class SalaryEmployee_DAL

    Public Shared Function GetSalaryEmployee(startDate As DateTime, finishDate As DateTime) As DataTable
        Dim obj As New SQLHelp
        Dim param(0) As SqlParameter
        param(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        Return obj.ExecQuery("[Checkroll].[SalaryEmployee]", param).Tables(0)
    End Function

    Public Shared Function GetSalaryEmployeeByMandorBesar(ByVal MandorBesarID As String) As DataTable
        Dim obj As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        param(1) = New SqlParameter("@MandorBesarID", MandorBesarID)
        Return obj.ExecQuery("[Checkroll].[SalaryEmployeeByMandorBesar]", param).Tables(0)
    End Function
    Public Shared Function GetSalaryEmployeeDetail(startDate As DateTime, finishDate As DateTime, empID As String) As DataTable
        Dim obj As New SQLHelp
        Dim param(1) As SqlParameter
        'param(0) = New SqlParameter("@StartDate", startDate.ToString("yyyy-MM-dd"))
        'param(1) = New SqlParameter("@FinishDate", finishDate.ToString("yyyy-MM-dd"))
        param(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        param(1) = New SqlParameter("@EmpID", empID)
        Return obj.ExecQuery("[Checkroll].[SalaryEmployeeDetail]", param).Tables(0)
    End Function

    'For Bonus SLip
    Public Shared Function GetBonusEmployee(startDate As DateTime, finishDate As DateTime) As DataTable
        Dim obj As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Return obj.ExecQuery("[Checkroll].[BonusEmployee]", param).Tables(0)
    End Function
    'For THR SLIP
    Public Shared Function GetTHREmployee(startDate As DateTime, finishDate As DateTime) As DataTable
        Dim obj As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Return obj.ExecQuery("[Checkroll].[THREmployee]", param).Tables(0)
    End Function
    Public Shared Function GetMandorBesar() As DataTable
        Dim obj As New SQLHelp
        Dim param(0) As SqlParameter
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Return obj.ExecQuery("[Checkroll].[GetMandorBesar]", param).Tables(0)
    End Function
End Class

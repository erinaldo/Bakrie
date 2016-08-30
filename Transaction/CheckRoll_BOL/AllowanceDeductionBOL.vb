'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 17 Nop 2009, 13:20
' Place     : Kebun
'
'Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL
Public Class AllowanceDeductionBOL
    Public Shared Function EmpAllowanceDeductionisSelect(ByVal EmpAllowDedID As String, ByVal Estateid As String) As DataTable
        Dim dt As New DataTable
        dt = AllowanceDeduction_Dal.EmpAllowanceDeductionisSelect(EmpAllowDedID)
        Return dt
    End Function
    Public Shared Function EmpAllowanceDeductionisView(ByVal StartDate As String, ByVal EndDate As String, ByVal EmpId As String, ByVal AllowDedID As String, ByVal Estateid As String) As DataTable
        Dim dt As New DataTable
        dt = AllowanceDeduction_Dal.EmpAllowanceDeductionisView(StartDate, EndDate, EmpId, AllowDedID)
        Return dt
    End Function
    Public Shared Function EmpAllowanceDeductionisExist(ByVal StartDate As String, ByVal EndDate As String, ByVal EmpId As String, ByVal Type As String, ByVal Estateid As String) As DataTable
        Dim dt As New DataTable
        dt = AllowanceDeduction_Dal.EmpAllowanceDeductionisExist(StartDate, EndDate, EmpId, Type)
        Return dt
    End Function
    Public Shared Function CRAllowanceDeductionSetupIsExist(ByVal AllowDedCode As String, ByVal Estateid As String) As DataTable
        Dim dt As New DataTable
        dt = AllowanceDeduction_Dal.CRAllowanceDeductionSetupIsExist(AllowDedCode)
        Return dt
    End Function
End Class

'////////
'
'
' Programmer: Agung Batricorsila
' Created   : Kamis, 3 Sep 2009, 13:20
' Place     : Kuala Lumpur  
'
'Imports CheckRoll_PPT

Imports System.Data.SqlClient
Imports System.Configuration
'Imports Common_DAL
'Imports Common_PPT
Imports CheckRoll_DAL
Public Class LookUpBOL
    'Allowance & Deduction Lookup
    Public Shared Function CRAllowanceDeductionSetupIsExist(ByVal AllowDedCode As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRAllowanceDeductionSetupIsExist(AllowDedCode)
        Return dt
    End Function
    'Attendance Lookup
    Public Shared Function CRAttendanceSetupSelect(ByVal AttendanceCode As String, ByVal AttendType As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRAttendanceSetupSelect(AttendanceCode, AttendType)
        Return dt
    End Function
    Public Shared Function CRDailyAttendanceEstateSelect(ByVal EstateDesc As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRDailyAttendanceEstateSelect(EstateDesc)
        Return dt
    End Function
    Public Shared Function CRPremiSetup(ByVal AttendanceSetupID As String, ByVal BlockID As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRPremiSetup(AttendanceSetupID, BlockID)
        Return dt
    End Function
    Public Shared Function CRSTCategoryIsExist(ByVal STCategoryID As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRSTCategoryIsExist(STCategoryID)
        Return dt
    End Function
    Public Shared Function CRSTCategoryIsSelect(ByVal StCategoryDescp As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRSTCategoryIsSelect(StCategoryDescp)
        Return dt
    End Function

    Public Shared Function STMasterIsExist( _
                                        ByVal STCategoryID As String, _
                                        ByVal StockCode As String, _
                                        ByVal StockDescp As String) As DataTable
        ' Modified by Dadang Adi Hendradi
        ' Senin, 23 Nov 2009, 00:57
        ' Adding StockDescp in parameters and where clause

        Dim dt As DataTable
        dt = Lookup_DAL.STMasterIsExist(STCategoryID, StockCode, StockDescp)
        Return dt
    End Function

    Public Shared Function CRSelectVehicle(ByVal VHWSCode As String, ByVal VHDescp As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRSelectVehicle(VHWSCode, VHDescp)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNikSelect(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String, ByVal AttDate As Date) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.DailyAttendanceNikSelect(Empcode, EmpName, Mandor, Status, AttDate)
        Return dt
    End Function
    Public Shared Function DailyAttendanceNikSelectNoTeam(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String, ByVal AttDate As Date) As DataTable
        Dim dt1 As New DataTable
        dt1 = Lookup_DAL.DailyAttendanceNikSelectNoTeam(Empcode, EmpName, Mandor, Status, AttDate)
        Return dt1
    End Function
    Public Shared Function CRDaNikSelectOnTeam(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRDaNikSelectOnTeam(Empcode, EmpName, Mandor, Status)
        Return dt
    End Function
    Public Shared Function CRStationSelect(ByVal StationDescp As String, ByVal StationCode As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRStationSelect(StationDescp, StationCode)
        Return dt
    End Function
    Public Shared Function CRSubBlockSelect(ByVal BlockName As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRSubBlockSelect(BlockName)
        Return dt
    End Function
    Public Shared Function CRDistributionSetupLookup(ByVal DistributionDescp As String, ByVal DistributionSetupID As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRDistributionSetupLookup(DistributionDescp, DistributionSetupID)
        Return dt
    End Function
    Public Shared Function CRTAnalisysCodeSelect(ByVal TACODEDESC As String, ByVal TAnalysisCode As String, ByVal TCode As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRTAnalisysCodeSelect(TACODEDESC, TAnalysisCode, TCode)
        Return dt
    End Function
    Public Shared Function GeneralEstateSelect() As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.GeneralEstateGet()
        Return dt
    End Function
    Public Shared Function CRGradeSelect(GradeID As String) As DataTable
        Dim dt As New DataTable
        dt = Lookup_DAL.CRGradeGet(GradeID)
        Return dt
    End Function
    Public Shared Function CRNikForAllowanceDeduction(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String, ByVal AttDate As Date) As DataTable
        Dim dt1 As New DataTable
        dt1 = Lookup_DAL.CRNikForAllowanceDeduction(Empcode, EmpName, Mandor, Status, AttDate)
        Return dt1
    End Function
End Class

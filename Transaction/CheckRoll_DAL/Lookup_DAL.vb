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
Imports Common_DAL
Imports Common_PPT
Public Class Lookup_DAL

    Public Shared Function EmpJobDescriptionSelect() As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Temp", DBNull.Value)
        dt = objdb.ExecQuery("[General].[EmpJobDescriptionSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function EmpJobDescriptionSelectLike(temp As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Temp", temp)
        dt = objdb.ExecQuery("[General].[EmpJobDescriptionSelect]", params).Tables(0)
        Return dt
    End Function

    'Allowance & Deduction Lookup
    Public Shared Function CRAllowanceDeductionSetupIsExist(ByVal AllowDedCode As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@AllowDedCode", AllowDedCode)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRAllowanceDeductionSetupIsExist]", params).Tables(0)
        Return dt
    End Function
    'Attendance lookup
    Public Shared Function CRAttendanceSetupSelect(ByVal AttendanceCode As String, ByVal AttendType As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@AttendanceCode", AttendanceCode)
        params(1) = New SqlParameter("@AttendType", AttendType)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRAttendanceSetupSelect]", params).Tables(0)
        Return dt
    End Function
    'Estate LookUp
    Public Shared Function CRDailyAttendanceEstateSelect(ByVal EstateDesc As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateDesc", EstateDesc)
        dt = objdb.ExecQuery("[Checkroll].[CRDailyAttendanceEstateSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function GeneralEstateGet() As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        dt = objdb.ExecQuery("[General].[EstateGet]").Tables(0)
        Return dt
    End Function

    Public Shared Function CRGradeGet(GradeName As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Param(1) As SqlParameter
        Param(0) = New SqlParameter("@GradeName", GradeName)
        Param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[GradeMasterSelect]", Param).Tables(0)
        Return dt
    End Function

    'PREMI LOOKUP
    Public Shared Function CRPremiSetup(ByVal AttendanceSetupID As String, ByVal BlockID As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@AttendanceSetupID", AttendanceSetupID)
        params(1) = New SqlParameter("@BlockID", BlockID)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRPremiSetup]", params).Tables(0)
        Return dt
    End Function
    'STOCK LOOKUP
    Public Shared Function CRSTCategoryIsExist(ByVal STCategoryID As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@STCategoryID", STCategoryID)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRSTCategoryIsExist]", params).Tables(0)
        Return dt
    End Function
    'STOCK LOOKUP
    Public Shared Function CRSTCategoryIsSelect(ByVal StCategoryDescp As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@StCategoryDescp", StCategoryDescp)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRSTCategoryIsSelect]", params).Tables(0)
        Return dt
    End Function

    'STOCK LOOKUP
    Public Shared Function STMasterIsExist( _
        ByVal STCategoryID As String, _
        ByVal StockCode As String, _
        ByVal StockDescp As String) As DataTable

        ' Modified by Dadang Adi Hendradi
        ' Senin, 23 Nov 2009, 00:57
        ' Adding StockDescp in parameters and where clause

        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As DataTable

        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@STCategoryID", STCategoryID)
        params(2) = New SqlParameter("@StockCode", StockCode)
        params(3) = New SqlParameter("@StockDescp", StockDescp)

        dt = objdb.ExecQuery("[Checkroll].[STMasterIsExist]", params).Tables(0)
        Return dt
    End Function

    'NIK LOOKUP
    Public Shared Function DailyAttendanceNikSelect(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String, ByVal AttDate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Empcode", Empcode)
        params(1) = New SqlParameter("@EmpName", EmpName)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@Mandor", Mandor)
        params(4) = New SqlParameter("@Status", Status)
        params(5) = New SqlParameter("@AttDate ", AttDate)
        dt = objdb.ExecQuery("[Checkroll].[CRDailyAttendanceNikSelect]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyAttendanceNikSelectByJobsID(ByVal Activity As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(0) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Activity", Activity)
        dt = objdb.ExecQuery("[Checkroll].[CRDailyAttendanceNikSelectByJobsID]", params).Tables(0)
        Return dt
    End Function

    Public Shared Function DailyAttendanceNikSelectNoTeam(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String, ByVal AttDate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt1 As New DataTable
        params(0) = New SqlParameter("@Empcode", Empcode)
        params(1) = New SqlParameter("@EmpName", EmpName)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@Mandor", Mandor)
        params(4) = New SqlParameter("@Status", Status)
        params(5) = New SqlParameter("@AttDate ", AttDate)
        dt1 = objdb.ExecQuery("[Checkroll].[CRDailyAttendanceNikSelectNoTeam]", params).Tables(0)

        Return dt1
    End Function
    Public Shared Function CRDaNikSelectOnTeam(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@Empcode", Empcode)
        params(1) = New SqlParameter("@EmpName", EmpName)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@Mandor", Mandor)
        params(4) = New SqlParameter("@Status", Status)
        dt = objdb.ExecQuery("[Checkroll].[CRDaNikSelectOnTeam]", params).Tables(0)

        Return dt
    End Function
    'VEHICLE LOOKUP
    Public Shared Function CRSelectVehicle(ByVal VHWSCode As String, ByVal VHDescp As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@VHWSCode", VHWSCode)
        params(1) = New SqlParameter("@VHDescp", VHDescp)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRSelectVehicle]", params).Tables(0)
        Return dt
    End Function
    'Station Lookup
    Public Shared Function CRStationSelect(ByVal StationDescp As String, ByVal StationCode As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@StationCode", StationCode)
        params(1) = New SqlParameter("@StationDescp", StationDescp)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRStationSelect]", params).Tables(0)
        Return dt
    End Function
    'Sub Block Loookup
    Public Shared Function CRSubBlockSelect(ByVal BlockName As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(1) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@BlockName", BlockName)
        params(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRSubBlockSelect]", params).Tables(0)
        Return dt
    End Function
    'Distribution Lookup
    Public Shared Function CRDistributionSetupLookup(ByVal DistributionDescp As String, ByVal DistributionSetupID As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@DistributionDescp", DistributionDescp)
        params(1) = New SqlParameter("@DistributionSetupID", DistributionSetupID)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Checkroll].[CRDistributionSetupLookup]", params).Tables(0)
        Return dt
    End Function
    'TANALYSYS Lookup
    Public Shared Function CRTAnalisysCodeSelect(ByVal TADesc As String, ByVal TAnalysisCode As String, ByVal TCode As String) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@TADesc", TADesc)
        params(1) = New SqlParameter("@TValue", TAnalysisCode)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@TCode", TCode)
        dt = objdb.ExecQuery("[Checkroll].[CRTAnalisysCodeSelect]", params).Tables(0)
        Return dt
    End Function
    'EmpAllowancePopup
    Public Shared Function CRNikForAllowanceDeduction(ByVal Empcode As String, ByVal EmpName As String, ByVal Mandor As String, ByVal Status As String, ByVal AttDate As Date) As DataTable
        Dim objdb As New SQLHelp
        Dim params(5) As SqlParameter
        Dim dt1 As New DataTable
        params(0) = New SqlParameter("@Empcode", Empcode)
        params(1) = New SqlParameter("@EmpName", EmpName)
        params(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(3) = New SqlParameter("@Mandor", Mandor)
        params(4) = New SqlParameter("@Status", Status)
        params(5) = New SqlParameter("@AttDate ", AttDate)
        dt1 = objdb.ExecQuery("[Checkroll].[CRNikForAllowanceDeduction]", params).Tables(0)

        Return dt1
    End Function
End Class

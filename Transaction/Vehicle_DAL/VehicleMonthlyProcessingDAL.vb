Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class VehicleMonthlyProcessingDAL

#Region "WorkshopLog"



#End Region

#Region "VehicleDistribution"



#End Region


    Dim objdb As New SQLHelp

#Region "Public Select Methods"

#Region "WorkshopLog"

    Public Function GetWorkshopCode() As DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Vehicle].[MECWorkshopLogSelect]", Parms)

    End Function

    Public Function GetTotalExpenditure(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) As DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)

        Return objdb.ExecQuery("[Vehicle].[MECTotalExpenditureByDetailCostCodeSELECT]", Parms)

    End Function

    Public Function IsVehicleModuleRecordsApproved() As Integer
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)

        Return objdb.ExecuteScalar("[Vehicle].[MECIsVehicleModuleRecordsApprovedSELECT]", Parms)

    End Function

    Public Sub SaveVHRunningCostSummary(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)

        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)
        Parms(3) = New SqlParameter("@VHDetailCostCode", _VehicleMonthlyProcessingPPT.psVHDetailCostCode)
        Parms(4) = New SqlParameter("@TotalExpenditure", _VehicleMonthlyProcessingPPT.pdTotalExpenditure)
        Parms(5) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[MECWorkshopLogVHRunningCostSummaryINSERT]", Parms)
    End Sub

    Public Sub SaveWorkshopVHRunningDetail(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)
        'Parms(3) = New SqlParameter("@VHDetailCostCode", _VehicleMonthlyProcessingPPT.psVHDetailCostCode)
        Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[MECWorkshopLogVHRunningDetailINSERT]", Parms)
    End Sub

    Public Sub SaveWorkshopLogProcessing(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)
        'Parms(3) = New SqlParameter("@TotalExpenditure", _VehicleMonthlyProcessingPPT.pdTotalExpenditure)
        Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[MECWorkshopLogProcessingINSERT]", Parms)
    End Sub


#End Region

#Region "VehicleDistribution"

    Public Function GetVehicleCode() As DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Vehicle].[MECVehicleDistributionSelect]", Parms)

    End Function

    Public Sub SaveVehicleVHRunningDetail(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)
        'Parms(3) = New SqlParameter("@VHDetailCostCode", _VehicleMonthlyProcessingPPT.psVHDetailCostCode)
        Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[MECVehicleVHRunningDetailINSERT]", Parms)
    End Sub

    Public Sub SaveVehicleProcessing(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _VehicleMonthlyProcessingPPT.psWorkVHID)
        'Parms(3) = New SqlParameter("@TotalExpenditure", _VehicleMonthlyProcessingPPT.pdTotalExpenditure)
        Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[MECVehicleDistributionProcessingINSERT]", Parms)
    End Sub

    'Public Shared Function TaskConfigTaskCheckGet(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) As DataSet

    '    Dim ds As New DataSet
    '    Dim objdb As New SQLHelp
    '    Dim Parms(0) As SqlParameter
    '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

    '    ds = objdb.ExecQuery("[Store].[TaskConfigTaskCheckGet]", Parms)

    '    Return ds

    'End Function

#End Region

    Public Shared Function TaskMonitorGet() As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", 3)
        'Parms(2) = New SqlParameter("@StoreModID", "2")
        ds = objdb.ExecQuery("[General].[TaskMonitorGet]", Parms)

        Return ds

    End Function

    Public Sub SaveTaskMonitor(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)

        Dim Parms(7) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(2) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(3) = New SqlParameter("@ModID", _VehicleMonthlyProcessingPPT.piId)
        Parms(4) = New SqlParameter("@Task", _VehicleMonthlyProcessingPPT.psTask)
        Parms(5) = New SqlParameter("@Complete", _VehicleMonthlyProcessingPPT.pcComplete)
        'Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        'Parms(7) = New SqlParameter("@CreatedOn", DateTime.Now)
        Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@ModifiedOn", DateTime.Now)

        objdb.ExecQuery("[General].[TaskMonitorUPDATE]", Parms)
    End Sub

    Public Shared Function TaskMonitorStatusGet(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", 3)
        Parms(2) = New SqlParameter("@Task", _VehicleMonthlyProcessingPPT.psTask)
        Parms(3) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(4) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)

        ds = objdb.ExecQuery("[General].[TaskMonitorStatusGet]", Parms)

        Return ds

    End Function

    Public Sub BeginBackupBSPDB(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT)
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@BeforeOrAfter", _VehicleMonthlyProcessingPPT.psTask)
        Parms(1) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(3) = New SqlParameter("@ModID", 3)

        objdb.ExecQuery("[General].[AutoBSPBackup]", Parms)
    End Sub

    Public Sub MonthEndClosing()

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(3) = New SqlParameter("@ModifiedOn", DateTime.Now)

        objdb.ExecQuery("[Vehicle].[MECVHWSMonthEndClosing]", Parms)
    End Sub

    Public Sub VehicleApprovalUpdate()

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[VehicleApprovalUpdate]", Parms)
    End Sub

    'Public Function NonPostedWorkshopLogGet(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) As DataSet
    '    Dim Parms(1) As SqlParameter

    '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    Return objdb.ExecQuery("[Vehicle].[NonPostedWorkshopLogGet]", Parms)

    'End Function

#End Region

#Region "Save Method"

    'Public Function PostByIdOrPostAllWorkshopLog(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) As Integer

    '    Dim Parms(3) As SqlParameter

    '    Parms(0) = New SqlParameter("@ID", _VehicleMonthlyProcessingPPT.piId)
    '    'Parms(0) = New SqlParameter("@PostingType", DbType.String, _VehicleMonthlyProcessingPPT.psPostingType)
    '    Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

    '    Return objdb.ExecuteScalar("[Vehicle].[PostNotPostedWorkshopLogUpdate]", Parms)
    'End Function

    'Public Function SaveVehicleRunningDetail(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) As DataSet

    '    Dim Parms(4) As SqlParameter

    '    'Parms(0) = New SqlParameter("@ID", DbType.Int32, _VehicleDistributionPostingEntity.piId)
    '    Parms(0) = New SqlParameter("@WorkShopCode", _VehicleMonthlyProcessingPPT.psWorkVHID)
    '    Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)
    '    Parms(4) = New SqlParameter("@LogDate", _VehicleMonthlyProcessingPPT.pdLogDateDT)

    '    Return objdb.ExecQuery("[Vehicle].[WorkshopLogVHRunningDetailINSERT]", Parms)
    'End Function

    'Public Function SaveWorkshopLogVehicleProcessing(ByVal _VehicleMonthlyProcessingPPT As VehicleMonthlyProcessingPPT) 'As Integer

    '    Dim Parms(1) As SqlParameter

    '    'Parms(0) = New SqlParameter("@EstateID", DbType.String, _VehicleMonthlyProcessingPPT.psEstateID)
    '    'Parms(0) = New SqlParameter("@WorkshopCode", DbType.String, _VehicleMonthlyProcessingPPT.psWorkVHID)
    '    'Parms(0) = New SqlParameter("@ActiveMonthYearID", DbType.String, _VehicleMonthlyProcessingPPT.psActiveMonthYearID)
    '    Parms(0) = New SqlParameter("@ID", _VehicleMonthlyProcessingPPT.piId)
    '    'Parms(0) = New SqlParameter("@IsPostAll", DbType.Boolean, _VehicleMonthlyProcessingPPT.pbIsPostAll)
    '    Parms(1) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

    '    Return objdb.ExecQuery("[Vehicle].[WorkshopLogVehicleProcessingINSERT]", Parms)
    'End Function

#End Region

End Class

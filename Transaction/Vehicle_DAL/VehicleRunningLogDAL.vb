Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class VehicleRunningLogDAL

    Dim objdb As New SQLHelp

    Function VehicleCodeForViewGet(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As DataTable

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", GetDataValue(_VehicleRunningLogPPT.psVHWSCode))
        Parms(1) = New SqlParameter("@LogDate", GetDataValue(_VehicleRunningLogPPT.pdLogDate))
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(4) = New SqlParameter("@SearchBy", GetDataValue(_VehicleRunningLogPPT.psSearchBy))

        Return objdb.ExecQuery("[Vehicle].[ViewVehicleCodeOnLogGET]", Parms).Tables(0)

    End Function

    Function GetLocation(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As DataTable

        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        Return objdb.ExecQuery("[Vehicle].[VehicleLogLocationGET]", Parms).Tables(0)

    End Function

    Function GetBatchValueByVehicleCode(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As DataSet

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", GetDataValue(_VehicleRunningLogPPT.psVHWSCode))
        'Since we are getting from Vehicle.VehicleRunningBatch we give the parameter name as @VHBatchDT
        Parms(1) = New SqlParameter("@LogDate", _VehicleRunningLogPPT.pdLogDate)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Vehicle].[VehicleRunningLogSelect]", Parms)

    End Function

    Function VehicleRunningLogSave(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Integer

        Dim Parms(31) As SqlParameter

        Parms(0) = New SqlParameter("@LogDate", GetDataValue(_VehicleRunningLogPPT.pdLogDate))
        Parms(1) = New SqlParameter("@VHWSCode", GetDataValue(_VehicleRunningLogPPT.psVHWSCode))
        Parms(2) = New SqlParameter("@ContractNumber", GetDataValue(_VehicleRunningLogPPT.psContractNo)) 'SqlDbType.VarChar
        Parms(3) = New SqlParameter("@DistributionSetupID", GetDataValue(_VehicleRunningLogPPT.psDistributionSetupID))
        Parms(4) = New SqlParameter("@StartKms", GetDataValue(_VehicleRunningLogPPT.piStartKms))

        Parms(5) = New SqlParameter("@EndKms", GetDataValue(_VehicleRunningLogPPT.piEndKms))
        Parms(6) = New SqlParameter("@TotalKM", GetDataValue(_VehicleRunningLogPPT.piTotalKm))

        Parms(7) = New SqlParameter("@StartTime", Convert.ToDateTime(Convert.ToString(_VehicleRunningLogPPT.pdStartTimeDT))) 'SqlDbType.Time
        Parms(8) = New SqlParameter("@EndTime", Convert.ToDateTime(Convert.ToString(_VehicleRunningLogPPT.pdEndTimeDT)))

        If _VehicleRunningLogPPT.psTotalHrs Is Nothing Then
            _VehicleRunningLogPPT.psTotalHrs = "00:00"
        End If
        Parms(9) = New SqlParameter("@TotalHrs", _VehicleRunningLogPPT.psTotalHrs)

        Parms(10) = New SqlParameter("@Shift", GetDataValue(_VehicleRunningLogPPT.pcShift)) 'SqlDbType.Char
        Parms(11) = New SqlParameter("@DivID", GetDataValue(_VehicleRunningLogPPT.psDivID))
        Parms(12) = New SqlParameter("@YOPID", GetDataValue(_VehicleRunningLogPPT.psYOPID))
        Parms(13) = New SqlParameter("@BlockID", GetDataValue(_VehicleRunningLogPPT.psBlockID))
        Parms(14) = New SqlParameter("@Activity", GetDataValue(_VehicleRunningLogPPT.psActivity))

        Parms(15) = New SqlParameter("@Status", GetDataValue(_VehicleRunningLogPPT.pcStatus))
        Parms(16) = New SqlParameter("@FFBDeliveryOrderNo", GetDataValue(_VehicleRunningLogPPT.psFFBDeliveryOrderNo))
        Parms(17) = New SqlParameter("@Bunches", GetDataValue(_VehicleRunningLogPPT.piBunches))
        Parms(18) = New SqlParameter("@ActualBunch", GetDataValue(_VehicleRunningLogPPT.piActualBunchesMill))
        Parms(19) = New SqlParameter("@CollectionPoint", GetDataValue(_VehicleRunningLogPPT.psCollectionPoint))

        Parms(20) = New SqlParameter("@MillWeight", GetDataValue(_VehicleRunningLogPPT.piMillWeight))
        Parms(21) = New SqlParameter("@DateHarvested", GetDataValue(_VehicleRunningLogPPT.pdDateHarvestedDT))
        Parms(22) = New SqlParameter("@DateCollected", GetDataValue(_VehicleRunningLogPPT.pdDateCollectedDT))
        Parms(23) = New SqlParameter("@DoubleHandledFFB", GetDataValue(_VehicleRunningLogPPT.psDoubleHandledFFB))
        Parms(24) = New SqlParameter("@WeighedBy", GetDataValue(_VehicleRunningLogPPT.psWeightedBy))

        Parms(25) = New SqlParameter("@DispatchedBy", GetDataValue(_VehicleRunningLogPPT.psDispatchedBy))
        Parms(26) = New SqlParameter("@Remarks", GetDataValue(_VehicleRunningLogPPT.psVHRLRemarks))
        Parms(27) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(28) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(29) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Parms(30) = New SqlParameter("@NIK", GetDataValue(_VehicleRunningLogPPT.NIK))
        Parms(31) = New SqlParameter("@DriverName", GetDataValue(_VehicleRunningLogPPT.DriverName))

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningLogINSERT]", Parms)

    End Function

    Function VehicleRunningLogUpdate(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Integer

        Dim Parms(31) As SqlParameter

        Parms(0) = New SqlParameter("@Id", GetDataValue(_VehicleRunningLogPPT.piID))
        Parms(1) = New SqlParameter("@LogDate", GetDataValue(_VehicleRunningLogPPT.pdLogDate))
        Parms(2) = New SqlParameter("@VHWSCode", GetDataValue(_VehicleRunningLogPPT.psVHWSCode))
        Parms(3) = New SqlParameter("@ContractNumber", GetDataValue(_VehicleRunningLogPPT.psContractNo))
        Parms(4) = New SqlParameter("@DistributionSetupID", GetDataValue(_VehicleRunningLogPPT.psDistributionSetupID))

        Parms(5) = New SqlParameter("@StartKms", GetDataValue(_VehicleRunningLogPPT.piStartKms))
        Parms(6) = New SqlParameter("@EndKms", GetDataValue(_VehicleRunningLogPPT.piEndKms))
        Parms(7) = New SqlParameter("@TotalKM", GetDataValue(_VehicleRunningLogPPT.piTotalKm))
        Parms(8) = New SqlParameter("@StartTime", Convert.ToDateTime(Convert.ToString(_VehicleRunningLogPPT.pdStartTimeDT))) 'SqlDbType.Time

        Parms(9) = New SqlParameter("@EndTime", Convert.ToDateTime(Convert.ToString(_VehicleRunningLogPPT.pdEndTimeDT)))
        If _VehicleRunningLogPPT.psTotalHrs Is Nothing Then
            _VehicleRunningLogPPT.psTotalHrs = "00:00"
        End If
        Parms(10) = New SqlParameter("@TotalHrs", _VehicleRunningLogPPT.psTotalHrs)
        Parms(11) = New SqlParameter("@Shift", GetDataValue(_VehicleRunningLogPPT.pcShift))
        Parms(12) = New SqlParameter("@DivID", GetDataValue(_VehicleRunningLogPPT.psDivID))
        Parms(13) = New SqlParameter("@YOPID", GetDataValue(_VehicleRunningLogPPT.psYOPID))
        Parms(14) = New SqlParameter("@BlockID", GetDataValue(_VehicleRunningLogPPT.psBlockID))

        Parms(15) = New SqlParameter("@Activity", GetDataValue(_VehicleRunningLogPPT.psActivity))
        Parms(16) = New SqlParameter("@Status", GetDataValue(_VehicleRunningLogPPT.pcStatus))
        Parms(17) = New SqlParameter("@FFBDeliveryOrderNo", GetDataValue(_VehicleRunningLogPPT.psFFBDeliveryOrderNo))
        Parms(18) = New SqlParameter("@Bunches", GetDataValue(_VehicleRunningLogPPT.piBunches))

        Parms(19) = New SqlParameter("@ActualBunch", GetDataValue(_VehicleRunningLogPPT.piActualBunchesMill))
        Parms(20) = New SqlParameter("@CollectionPoint", GetDataValue(_VehicleRunningLogPPT.psCollectionPoint))
        Parms(21) = New SqlParameter("@MillWeight", GetDataValue(_VehicleRunningLogPPT.piMillWeight))

        Parms(22) = New SqlParameter("@DateHarvested", GetDataValue(_VehicleRunningLogPPT.pdDateHarvestedDT))
        Parms(23) = New SqlParameter("@DateCollected", GetDataValue(_VehicleRunningLogPPT.pdDateCollectedDT))
        Parms(24) = New SqlParameter("@DoubleHandledFFB", GetDataValue(_VehicleRunningLogPPT.psDoubleHandledFFB))

        Parms(25) = New SqlParameter("@WeighedBy", GetDataValue(_VehicleRunningLogPPT.psWeightedBy))
        Parms(26) = New SqlParameter("@DispatchedBy", GetDataValue(_VehicleRunningLogPPT.psDispatchedBy))
        Parms(27) = New SqlParameter("@Remarks", GetDataValue(_VehicleRunningLogPPT.psVHRLRemarks))
        Parms(28) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(29) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Parms(30) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(31) = New SqlParameter("@ConcurrencyId", GetDataValue(_VehicleRunningLogPPT.piConcurrencyId))

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningLogUPDATE]", Parms)

    End Function

    Function GetRunningLodDetailsById(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As DataSet

        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@ID", _VehicleRunningLogPPT.piID)

        Return objdb.ExecQuery("[Vehicle].[VehicleRunningLogDuringEditGET]", Parms)

    End Function

    Function VehicleRunningLogDelete(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Integer
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@ID", _VehicleRunningLogPPT.piID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningLogDelete]", Parms)

    End Function

    Function DeleteVehicleRunningLogFromView(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Integer
        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", _VehicleRunningLogPPT.psVHWSCode)
        Parms(1) = New SqlParameter("@LogDate", _VehicleRunningLogPPT.pdLogDate)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningLogAllDELETE]", Parms)

    End Function

    Public Shared Function GetDataValue(ByVal o As Object) As Object

        If o Is Nothing OrElse String.Empty.Equals(o) Then
            Return DBNull.Value
        Else
            Return o
        End If

    End Function

    Public Function VHRunningLogRecordIsExist(ByVal _VehicleRunningLogPPT As VehicleRunningLogPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Vehicle].[VHRunningLogRecordIsExist]", Parms)
        Return objExists
    End Function

End Class

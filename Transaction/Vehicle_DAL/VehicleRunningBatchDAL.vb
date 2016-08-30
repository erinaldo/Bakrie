Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class VehicleRunningBatchDAL

    Dim objdb As New SQLHelp

    Function GetVehicleCodeList(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As DataSet

        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", If(String.IsNullOrEmpty(objVehicleRunningBatchPPT.psVHWSCode), String.Empty, objVehicleRunningBatchPPT.psVHWSCode))
        Parms(1) = New SqlParameter("@VHBatchDT", If(String.IsNullOrEmpty(objVehicleRunningBatchPPT.pdVHBatchDT), DateTime.MinValue, objVehicleRunningBatchPPT.pdVHBatchDT))
        Parms(2) = New SqlParameter("@EstateID", If(String.IsNullOrEmpty(objVehicleRunningBatchPPT.psEstateID), String.Empty, objVehicleRunningBatchPPT.psEstateID))
        Parms(3) = New SqlParameter("@ActiveMonthYearID", If(String.IsNullOrEmpty(objVehicleRunningBatchPPT.psActiveMonthYearID), String.Empty, objVehicleRunningBatchPPT.psActiveMonthYearID))
        Parms(4) = New SqlParameter("@SearchBy", objVehicleRunningBatchPPT.psSearchBy)

        Return objdb.ExecQuery("[Vehicle].[ViewVehicleCodeOnBatchGET]", Parms)

    End Function



    Function GetBatchDetailsVehicleCode(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As DataSet

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", GetDataValue(objVehicleRunningBatchPPT.psVHWSCode))
        Parms(1) = New SqlParameter("@EstateID", objVehicleRunningBatchPPT.psEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", objVehicleRunningBatchPPT.psActiveMonthYearID)

        Return objdb.ExecQuery("[Vehicle].[VehicleCodeDetailsGet]", Parms)

    End Function


    Function SaveVehicleRunningBatch(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As Integer

        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", objVehicleRunningBatchPPT.psVHWSCode) 'SqlDbType.NVarChar
        Parms(1) = New SqlParameter("@EstateID", objVehicleRunningBatchPPT.psEstateID) 'SqlDbType.NVarChar
        Parms(2) = New SqlParameter("@ActiveMonthYearID", objVehicleRunningBatchPPT.psActiveMonthYearID) 'SqlDbType.NVarChar
        Parms(3) = New SqlParameter("@VHBatchDT", objVehicleRunningBatchPPT.pdVHBatchDT) 'SqlDbType.DateTime
        Parms(4) = New SqlParameter("@VHBatchValue", objVehicleRunningBatchPPT.piVHBatchValue) 'SqlDbType.Decimal
        Parms(5) = New SqlParameter("@CreateBy", objVehicleRunningBatchPPT.psCreateBy) 'SqlDbType.NVarChar

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningBatchINSERT]", Parms)

    End Function


    Function UpdateVehicleRunningBatch(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As Integer

        Dim Parms(5) As SqlParameter

        Parms(0) = New SqlParameter("@ID", objVehicleRunningBatchPPT.piID)
        Parms(1) = New SqlParameter("@VHBatchValue", objVehicleRunningBatchPPT.piVHBatchValue) 'SqlDbType.Decimal
        Parms(2) = New SqlParameter("@ModifiedBy", objVehicleRunningBatchPPT.psCreateBy) 'SqlDbType.VarChar
        Parms(3) = New SqlParameter("@EstateID", objVehicleRunningBatchPPT.psEstateID) 'SqlDbType.NVarChar
        Parms(4) = New SqlParameter("@ActiveMonthYearID", objVehicleRunningBatchPPT.psActiveMonthYearID) 'SqlDbType.NVarChar
        Parms(5) = New SqlParameter("@ConcurrencyId", objVehicleRunningBatchPPT.piConcurrencyId) 'SqlDbType.Timestamp

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningBatchUPDATE]", Parms)

    End Function


    Function DeleteVehicleRunningBatch(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As Integer

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@ID", objVehicleRunningBatchPPT.piID)
        Parms(1) = New SqlParameter("@EstateID", objVehicleRunningBatchPPT.psEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", objVehicleRunningBatchPPT.psActiveMonthYearID)

        Return objdb.ExecuteScalar("[Vehicle].[VehicleRunningBatchDelete]", Parms)

    End Function

    Function GetVehicleRunningBatchDuringEdit(ByVal objVehicleRunningBatchPPT As VehicleRunningBatchPPT) As DataSet

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@ID", objVehicleRunningBatchPPT.piID)
        Parms(1) = New SqlParameter("@EstateID", objVehicleRunningBatchPPT.psEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", objVehicleRunningBatchPPT.psActiveMonthYearID)

        Return objdb.ExecQuery("[Vehicle].[VehicleRunningBatchDuringEditGET]", Parms)

    End Function

    Public Shared Function GetDataValue(ByVal o As Object) As Object
        If o Is Nothing OrElse [String].Empty.Equals(o) Then
            Return DBNull.Value
        Else
            Return o
        End If
    End Function

End Class

Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class WorkshopLogDAL

    Public Shared objdb As New SQLHelp

#Region "Business Validation"
    Public Function GetIsValidKey(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@FieldName", _WorkshopLogPPT.psFieldName)
        Parms(2) = New SqlParameter("@FieldValue", _WorkshopLogPPT.psFieldValue)

        Return objdb.ExecuteScalar("[Vehicle].[ForeignKeyValueIsExist]", Parms)

    End Function
#End Region

#Region "Public Select Methods"

    Public Function GetWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataSet

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@WorkVHID", IIf(String.IsNullOrEmpty(_WorkshopLogPPT.psWorkVHID), DBNull.Value, _WorkshopLogPPT.psWorkVHID))
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LogDate", _WorkshopLogPPT.pdLogDateDT)

        Return objdb.ExecQuery("[Vehicle].[WorkshopLogGET]", Parms)

    End Function

    Public Function GetWorkshopLogDetails(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataSet

        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@Id", _WorkshopLogPPT.piId)

        Return objdb.ExecQuery("[Vehicle].[WorkshopLogDetailsGET]", Parms)

    End Function

    Public Function GetWorkshopCode(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataTable

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@WorkVHID", IIf(_WorkshopLogPPT.psWorkVHID Is Nothing, DBNull.Value, _WorkshopLogPPT.psWorkVHID))
        Parms(1) = New SqlParameter("@LogDate", _WorkshopLogPPT.pdLogDateDT)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(4) = New SqlParameter("@SearchBy", IIf(_WorkshopLogPPT.psSearchBy Is Nothing, DBNull.Value, _WorkshopLogPPT.psSearchBy))

        Return objdb.ExecQuery("[Vehicle].[WorkshopNumbersGET]", Parms).Tables(0)

    End Function

    Public Function GetAccountDescription(ByVal _WorkshopLogPPT As WorkshopLogPPT) As String

        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@COACode", _WorkshopLogPPT.psCOAID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        Return objdb.ExecuteScalar("[Vehicle].[AccountDescriptionGET]", Parms)

    End Function

    Public Sub GetOperatorName(ByVal _WorkshopLogPPT As WorkshopLogPPT) 'As Object

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EmpCode", _WorkshopLogPPT.psEmpCode)
        Parms(2) = New SqlParameter("@EmpID", SqlDbType.NVarChar, 50)
        Parms(2).Direction = ParameterDirection.Output
        Parms(3) = New SqlParameter("@EmpName", SqlDbType.NVarChar, 50)
        Parms(3).Direction = ParameterDirection.Output

        'Return objdb.ExecQueryDataTable("[Vehicle].[OperatorNameGET]", Parms)
        objdb.ExecNonQuery("[Vehicle].[OperatorNameGET]", Parms)
        _WorkshopLogPPT.psEmpID = Parms(2).Value
        _WorkshopLogPPT.psEmpName = Parms(3).Value

    End Sub

    Public Function WorkshopLogRecordIsExist(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Vehicle].[WorkshopLogRecordIsExist]", Parms)
        Return objExists
    End Function


    Public Function GetVHCode(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataTable

        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _WorkshopLogPPT.psVHID)

        Return objdb.ExecQuery("[Vehicle].[IsVHCodeExist]", Parms).Tables(0)

    End Function

    Public Function IsVHWSCodeExist(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer

        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@VehicleType", _WorkshopLogPPT.psFieldName)
        Parms(1) = New SqlParameter("@VHWSCode", _WorkshopLogPPT.psFieldValue)

        Return objdb.ExecuteScalar("[Vehicle].[IsWSVHWSCodeExist]", Parms)

    End Function

#End Region

#Region "Save Method"

    Public Function SaveWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer

        Dim Parms(19) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@WorkshopCode", _WorkshopLogPPT.psWorkVHID)
        Parms(3) = New SqlParameter("@LogDate", _WorkshopLogPPT.pdLogDateDT)
        Parms(4) = New SqlParameter("@VehicleCode", _WorkshopLogPPT.psVHID)
        Parms(5) = New SqlParameter("@StartTime", Convert.ToDateTime(Convert.ToString(_WorkshopLogPPT.pdStartTimeDT))) ' 
        Parms(6) = New SqlParameter("@EndTime", Convert.ToDateTime(Convert.ToString(_WorkshopLogPPT.pdEndTimeDT))) '
        Parms(7) = New SqlParameter("@TotalHrs", _WorkshopLogPPT.pdTotalHrsDT) '
        Parms(8) = New SqlParameter("@Activity", _WorkshopLogPPT.psActivity)
        Parms(9) = New SqlParameter("@EmpID", GetDataValue(_WorkshopLogPPT.psEmpID))
        Parms(10) = New SqlParameter("@COAID", _WorkshopLogPPT.psCOAID)
        Parms(11) = New SqlParameter("@DivID", GetDataValue(_WorkshopLogPPT.psDivID))
        Parms(12) = New SqlParameter("@YOPID", GetDataValue(_WorkshopLogPPT.psYOPID))
        Parms(13) = New SqlParameter("@BlockID", GetDataValue(_WorkshopLogPPT.psBlockID))
        Parms(14) = New SqlParameter("@T0", GetDataValue(_WorkshopLogPPT.psT0))
        Parms(15) = New SqlParameter("@T1", GetDataValue(_WorkshopLogPPT.psT1))
        Parms(16) = New SqlParameter("@T2", GetDataValue(_WorkshopLogPPT.psT2))
        Parms(17) = New SqlParameter("@T3", GetDataValue(_WorkshopLogPPT.psT3))
        Parms(18) = New SqlParameter("@T4", GetDataValue(_WorkshopLogPPT.psT4))
        Parms(19) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName) '

        Return objdb.ExecuteScalar("[Vehicle].[WorkshopLogINSERT]", Parms)
    End Function

    Public Function UpdateWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer

        Dim Parms(19) As SqlParameter

        Parms(0) = New SqlParameter("@Id", _WorkshopLogPPT.piId)
        Parms(1) = New SqlParameter("@VehicleCode", _WorkshopLogPPT.psVHID)
        Parms(2) = New SqlParameter("@StartTime", Convert.ToDateTime(Convert.ToString(_WorkshopLogPPT.pdStartTimeDT))) ' 
        Parms(3) = New SqlParameter("@EndTime", Convert.ToDateTime(Convert.ToString(_WorkshopLogPPT.pdEndTimeDT))) '
        Parms(4) = New SqlParameter("@TotalHrs", _WorkshopLogPPT.pdTotalHrsDT) '
        Parms(5) = New SqlParameter("@Activity", _WorkshopLogPPT.psActivity)
        Parms(6) = New SqlParameter("@EmpID", GetDataValue(_WorkshopLogPPT.psEmpID))
        Parms(7) = New SqlParameter("@COAID", _WorkshopLogPPT.psCOAID)
        Parms(8) = New SqlParameter("@DivID", GetDataValue(_WorkshopLogPPT.psDivID))
        Parms(9) = New SqlParameter("@YOPID", GetDataValue(_WorkshopLogPPT.psYOPID))
        Parms(10) = New SqlParameter("@BlockID", GetDataValue(_WorkshopLogPPT.psBlockID))
        Parms(11) = New SqlParameter("@T0", GetDataValue(_WorkshopLogPPT.psT0))
        Parms(12) = New SqlParameter("@T1", GetDataValue(_WorkshopLogPPT.psT1))
        Parms(13) = New SqlParameter("@T2", GetDataValue(_WorkshopLogPPT.psT2))
        Parms(14) = New SqlParameter("@T3", GetDataValue(_WorkshopLogPPT.psT3))
        Parms(15) = New SqlParameter("@T4", GetDataValue(_WorkshopLogPPT.psT4))
        Parms(16) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(17) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(18) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(19) = New SqlParameter("@WorkshopCode", _WorkshopLogPPT.psWorkVHID)

        Return objdb.ExecuteScalar("[Vehicle].[WorkshopLogUPDATE]", Parms)
    End Function

#End Region

#Region "Delete Method"
    Public Function DeleteWorkshopLog(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@Id", _WorkshopLogPPT.piId)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecuteScalar("[Vehicle].[WorkshopLogDELETE]", Parms)

    End Function

    Public Function GetWorkshopCodeForComboBox(ByVal _WorkshopLogPPT As WorkshopLogPPT) As DataTable

        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Return objdb.ExecQuery("[Vehicle].[WorkshopCodeSelect]", Parms).Tables(0)

    End Function

    Public Function DeleteWorkshopLogFromView(ByVal _WorkshopLogPPT As WorkshopLogPPT) As Integer

        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@VHWSCode", _WorkshopLogPPT.psWorkVHID)
        Parms(3) = New SqlParameter("@LogDate", _WorkshopLogPPT.pdLogDateDT)
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecuteScalar("[Vehicle].[WorkshopLogAllDELETE]", Parms)

    End Function

    Public Function GetDataValue(ByVal o As Object) As Object

        If o Is Nothing OrElse String.Empty.Equals(o) Then
            Return DBNull.Value
        Else
            Return o
        End If

    End Function

#End Region

End Class

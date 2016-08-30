Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class VehicleGeneralDAL

    Dim objdb As New SQLHelp

    Public Function GetIsValidKey(ByVal objVehicleGeneralPPT As VehicleGeneralPPT) As Integer

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", objVehicleGeneralPPT.psEstateID)
        Parms(1) = New SqlParameter("@FieldName", objVehicleGeneralPPT.psFieldName)
        Parms(2) = New SqlParameter("@FieldValue", objVehicleGeneralPPT.psFieldValue)

        Return objdb.ExecuteScalar("[Vehicle].[ForeignKeyValueIsExist]", Parms)

    End Function

    Public Function IsVHWSCodeExist(ByVal objVehicleGeneralPPT As VehicleGeneralPPT) As Integer

        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", objVehicleGeneralPPT.psEstateID)
        Parms(1) = New SqlParameter("@VehicleType", objVehicleGeneralPPT.psFieldName)
        Parms(2) = New SqlParameter("@VHWSCode", objVehicleGeneralPPT.psFieldValue)

        Return objdb.ExecuteScalar("[Vehicle].[IsVHWSCodeExist]", Parms)

    End Function

    Public Function GetActiveMonthYear(ByVal objVehicleGeneralPPT As VehicleGeneralPPT) As DataSet

        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@ActiveMonthYearID", objVehicleGeneralPPT.psActiveMonthYearID)
        Parms(1) = New SqlParameter("@EstateID", objVehicleGeneralPPT.psEstateID)
        Parms(2) = New SqlParameter("@SchemaName", objVehicleGeneralPPT.PsSchemaName)
        Parms(3) = New SqlParameter("@TableName", objVehicleGeneralPPT.PsTableName)
        Parms(4) = New SqlParameter("@ColumnName", objVehicleGeneralPPT.PsColumnName)

        'Return objdb.ExecQuery("[Vehicle].[ActiveMonthYearGET]", Parms)
        Return objdb.ExecQuery("[dbo].[ActiveMonthYearGET]", Parms)

    End Function

End Class

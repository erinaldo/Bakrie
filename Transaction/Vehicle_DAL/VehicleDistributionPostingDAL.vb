Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient
Public Class VehicleDistributionPostingDAL

    Public Function NonPostedVehicleDistributionGet() As DataSet

        Dim Parms(1) As SqlParameter
        Dim objdb As New SQLHelp

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Vehicle].[NonPostedVehicleDistributionGet]", Parms)
    End Function


#Region "Save Method"
    Public Function PostByIdOrPostAllVehicleDistribution(ByVal _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT) As Integer
        Dim rowsAffected As Integer = 0
        'dbCommand = GetStoredProcCommand("[Vehicle].[PostNotPostedVehicleDistributionUpdate]")

        'AddInParameter(dbCommand, "@ID", DbType.Int32, _VehicleDistributionPostingEntity.piId)
        ''AddInParameter(dbCommand, "@PostingType", DbType.String, _VehicleDistributionPostingEntity.psPostingType)
        'AddInParameter(dbCommand, "@EstateID", DbType.String, _VehicleDistributionPostingEntity.psEstateID)
        'AddInParameter(dbCommand, "@ActiveMonthYearID", DbType.String, _VehicleDistributionPostingEntity.psActiveMonthYearID)
        'AddInParameter(dbCommand, "@ModifiedBy", DbType.String, _VehicleDistributionPostingEntity.psCreatedModifiedBy)

        'Return ExecuteScalar(dbCommand)
        Dim Parms(4) As SqlParameter
        Dim objdb As New SQLHelp
        'Parms(0) = New SqlParameter("@ID", _VehicleDistributionPostingPPT.piId)
        Parms(0) = New SqlParameter("@VHWSCode", _VehicleDistributionPostingPPT.psVHID)
        Parms(1) = New SqlParameter("@DistributionDT", _VehicleDistributionPostingPPT.pdDistributionDT)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(1) = New SqlParameter("@PostingType", _VehicleDistributionPostingPPT.psPostingType)
        rowsAffected = objdb.ExecNonQuery("[Vehicle].[PostNotPostedVehicleDistributionUpdate]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If


    End Function

    Public Function SaveVehicleRunningDetail(ByVal _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT) As Integer


        Dim rowsAffected As Integer = 0
        'dbCommand = GetStoredProcCommand("[Vehicle].[VHDistributionVHRunningDetailINSERT]")

        ''AddInParameter(dbCommand, "@ID", DbType.Int32, _VehicleDistributionPostingEntity.piId)
        'AddInParameter(dbCommand, "@VHWSCode", DbType.String, _VehicleDistributionPostingEntity.psVHID)
        'AddInParameter(dbCommand, "@EstateID", DbType.String, _VehicleDistributionPostingEntity.psEstateID)
        'AddInParameter(dbCommand, "@ActiveMonthYearID", DbType.String, _VehicleDistributionPostingEntity.psActiveMonthYearID)
        'AddInParameter(dbCommand, "@CreatedModifiedBy", DbType.String, _VehicleDistributionPostingEntity.psCreatedModifiedBy)
        'AddInParameter(dbCommand, "@LogDate", DbType.DateTime, _VehicleDistributionPostingEntity.pdDistributionDT)

        'ExecuteNonQuery(dbCommand)


        Dim Parms(5) As SqlParameter
        Dim objdb As New SQLHelp
        Parms(0) = New SqlParameter("@ID", _VehicleDistributionPostingPPT.piId)
        Parms(1) = New SqlParameter("@VHWSCode", _VehicleDistributionPostingPPT.psVHID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)
        Parms(5) = New SqlParameter("@LogDate", _VehicleDistributionPostingPPT.pdDistributionDT)
        rowsAffected = objdb.ExecNonQuery("[Vehicle].[VHDistributionVHRunningDetailINSERT]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function

    Public Function SaveVHDistributionVehicleProcessing(ByVal _VehicleDistributionPostingPPT As VehicleDistributionPostingPPT) As Integer

        Dim rowsAffected As Integer = 0


        'dbCommand = GetStoredProcCommand("[Vehicle].[VHDistributionVehicleProcessingINSERT]")
        'AddInParameter(dbCommand, "@ID", DbType.Int32, _VehicleDistributionPostingEntity.piId)
        'AddInParameter(dbCommand, "@CreatedModifiedBy", DbType.String, _VehicleDistributionPostingEntity.psCreatedModifiedBy)
        'ExecuteNonQuery(dbCommand)
        Dim Parms(1) As SqlParameter
        Dim objdb As New SQLHelp
        Parms(0) = New SqlParameter("@ID", _VehicleDistributionPostingPPT.piId)
        Parms(1) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)
        rowsAffected = objdb.ExecNonQuery("[Vehicle].[VHDistributionVehicleProcessingINSERT]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If

    End Function

#End Region
End Class

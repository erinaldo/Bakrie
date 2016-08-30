Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient

Public Class VehicleRunningLogPostingDAL

    Dim objdb As New SQLHelp

    Function NonPostedVehicleRunningLogGet(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT) As DataSet

        Dim Parms(1) As SqlParameter
        Dim ds As DataSet
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Vehicle].[NonPostedVehicleRunningLogGet]", Parms) '.Tables(0)
        Return ds

    End Function

    Function PostByIdOrPostAll(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT) As Integer

        Dim Parms(4) As SqlParameter

        'Parms(0) = New SqlParameter("@ID", objVehicleRunningLogPostingPPT.piId)
        'Parms(1) = New SqlParameter("@PostingType", objVehicleRunningLogPostingPPT.psPostingType)
        'Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Parms(0) = New SqlParameter("@LogDate", objVehicleRunningLogPostingPPT.pdLogDateDT)
        Parms(1) = New SqlParameter("@VHWSCode", objVehicleRunningLogPostingPPT.psVHWSCode)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@PostingType", objVehicleRunningLogPostingPPT.psPostingType)
        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecuteScalar("[Vehicle].[PostNotPostedVehicleRunningLogUpdate]", Parms)

    End Function


    Sub SaveOrUpdateVHRunningDetailExternal(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT)
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@VHWSCode", objVehicleRunningLogPostingPPT.psVHWSCode)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)
        'Parms(0) = New SqlParameter("@LogDate", DbType.DateTime, objVehicleRunningLogPostingPPT.pdLogDateDT)

        objdb.ExecQuery("[Vehicle].[VHRunningDetailExternalINSERT]", Parms)

    End Sub

    Sub VehicleProcessingWriteUp(ByVal objVehicleRunningLogPostingPPT As VehicleRunningLogPostingPPT)
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@Id", DbType.Int32, objVehicleRunningLogPostingPPT.piId)
        Parms(1) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)

        objdb.ExecQuery("[Vehicle].[VehicleProcessingWriteUpINSERT]", Parms)

    End Sub

End Class
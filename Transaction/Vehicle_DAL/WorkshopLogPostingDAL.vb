Imports Common_PPT
Imports Common_DAL
Imports Vehicle_PPT
Imports System.Data.SqlClient


Public Class WorkshopLogPostingDAL

    Dim objdb As New SQLHelp

#Region "Public Select Methods"

    Public Function NonPostedWorkshopLogGet(ByVal _WorkshopLogPostingPPT As WorkshopLogPostingPPT) As DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Vehicle].[NonPostedWorkshopLogGet]", Parms)

    End Function

#End Region

#Region "Save Method"

    Public Function PostByIdOrPostAllWorkshopLog(ByVal _WorkshopLogPostingPPT As WorkshopLogPostingPPT) As Integer

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@ID", _WorkshopLogPostingPPT.piId)
        'Parms(0) = New SqlParameter("@PostingType", DbType.String, _WorkshopLogPostingPPT.psPostingType)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecuteScalar("[Vehicle].[PostNotPostedWorkshopLogUpdate]", Parms)
    End Function

    Public Function SaveVehicleRunningDetail(ByVal _WorkshopLogPostingPPT As WorkshopLogPostingPPT) As DataSet

        Dim Parms(4) As SqlParameter

        'Parms(0) = New SqlParameter("@ID", DbType.Int32, _VehicleDistributionPostingEntity.piId)
        Parms(0) = New SqlParameter("@WorkShopCode", _WorkshopLogPostingPPT.psWorkVHID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@LogDate", _WorkshopLogPostingPPT.pdLogDateDT)

        Return objdb.ExecQuery("[Vehicle].[WorkshopLogVHRunningDetailINSERT]", Parms)
    End Function

    Public Function SaveWorkshopLogVehicleProcessing(ByVal _WorkshopLogPostingPPT As WorkshopLogPostingPPT) 'As Integer

        Dim Parms(1) As SqlParameter

        'Parms(0) = New SqlParameter("@EstateID", DbType.String, _WorkshopLogPostingPPT.psEstateID)
        'Parms(0) = New SqlParameter("@WorkshopCode", DbType.String, _WorkshopLogPostingPPT.psWorkVHID)
        'Parms(0) = New SqlParameter("@ActiveMonthYearID", DbType.String, _WorkshopLogPostingPPT.psActiveMonthYearID)
        Parms(0) = New SqlParameter("@ID", _WorkshopLogPostingPPT.piId)
        'Parms(0) = New SqlParameter("@IsPostAll", DbType.Boolean, _WorkshopLogPostingPPT.pbIsPostAll)
        Parms(1) = New SqlParameter("@CreatedModifiedBy", GlobalPPT.strUserName)

        Return objdb.ExecQuery("[Vehicle].[WorkshopLogVehicleProcessingINSERT]", Parms)
    End Function

#End Region

End Class

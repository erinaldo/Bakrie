Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT

Public Class StandardConfigurationDAL
    Public Shared Function InsertStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter

        Parms(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@ExcRateUStoRP", objPPT.ExcRateUStoRP)
        'Parms(4) = New SqlParameter("@MandayRateforKHP", objPPT.MandayRateforKHP)
        Parms(4) = New SqlParameter("@PlantingPalmPerHa", objPPT.PlantingPalmPerHa)
        'Parms(6) = New SqlParameter("@MandayRateforBHL", objPPT.MandayRateforBHL)
        Parms(5) = New SqlParameter("@ManuringPerHa", objPPT.ManuringPerHa)
        Parms(6) = New SqlParameter("@YearBaseRate", objPPT.YearBaseRate)
        Parms(7) = New SqlParameter("@PinkSlipPrefix", objPPT.PinkSlipPrefix)
        Parms(8) = New SqlParameter("@PinkSlipCommencingNo", objPPT.PinkSlipCommencingNo)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(12) = New SqlParameter("@ModifiedOn", Date.Today)

        Dim intResult As Integer = objdb.ExecNonQuery("[Budget].[StandardConfigurationInsert]", Parms)
        
        Return objPPT
    End Function
    'Public Shared Function InsertStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
    '    Dim objdb As New SQLHelp
    '    'Try
    '    Dim Parms(24) As SqlParameter

    '    Parms(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
    '    Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(2) = New SqlParameter("@BDGYear", GlobalPPT.intLoginYear)
    '    Parms(3) = New SqlParameter("@Period", objPPT.Period)
    '    Parms(4) = New SqlParameter("@Astek", objPPT.Astek)
    '    Parms(5) = New SqlParameter("@AstekP", objPPT.AstekP)
    '    Parms(6) = New SqlParameter("@Sundays", objPPT.Sundays)
    '    Parms(7) = New SqlParameter("@SundaysUnit", objPPT.SundaysUnit)
    '    Parms(8) = New SqlParameter("@SundaysRp", objPPT.SundaysRp)
    '    Parms(9) = New SqlParameter("@OtherDays", objPPT.OtherDays)
    '    Parms(10) = New SqlParameter("@OtherDaysUnit", objPPT.OtherDaysUnit)
    '    Parms(11) = New SqlParameter("@OtherDaysRp", objPPT.OtherDaysRp)
    '    Parms(12) = New SqlParameter("@LeaveCost", objPPT.LeaveCost)
    '    Parms(13) = New SqlParameter("@LeaveCostUnit", objPPT.LeaveCostUnit)
    '    Parms(14) = New SqlParameter("@LeaveCostRp", objPPT.LeaveCostRp)
    '    Parms(15) = New SqlParameter("@Rice", objPPT.Rice)
    '    Parms(16) = New SqlParameter("@RiceUnit", objPPT.RiceUnit)
    '    Parms(17) = New SqlParameter("@RiceRp", objPPT.RiceRp)
    '    Parms(18) = New SqlParameter("@THR", objPPT.THR)
    '    Parms(19) = New SqlParameter("@THRUnit", objPPT.THRUnit)
    '    Parms(20) = New SqlParameter("@THRRp", objPPT.THRRp)
    '    Parms(21) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
    '    Parms(22) = New SqlParameter("@CreatedOn", Date.Today)
    '    Parms(23) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    '    Parms(24) = New SqlParameter("@ModifiedOn", Date.Today)

    '    Dim intResult As Integer = objdb.ExecNonQuery("[Budget].[StandardHarvestingQuarterInsert]", Parms)

    '    Return objPPT

    'End Function

    Public Shared Function SelectAllStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        Parms(1) = New SqlParameter("@BudgetYear", objPPT.BudgetYear)

        dt = objdb.ExecQuery("[Budget].[StandardHarvestingQuarterSelectAll]", Parms).Tables(0)

        Return dt

    End Function
    'Public Shared Function IsPeriodExistStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As DataTable

    '    Dim objdb As New SQLHelp
    '    Dim datatable As New DataTable()
    '    Dim Parms(2) As SqlParameter
    '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(1) = New SqlParameter("@BDGYear", GlobalPPT.intLoginYear)
    '    Parms(2) = New SqlParameter("@Period", objPPT.Period)

    '    datatable = objdb.ExecQuery("[Budget].[StandardHarvestingQuarterIsExist]", Parms).Tables(0)


    '    Return datatable

    'End Function

    'Public Shared Function UpdateStandardHarvestingQuarter(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
    '    Dim objdb As New SQLHelp
    '    ' Try
    '    Dim Parms(22) As SqlParameter

    '    'Parms(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
    '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(1) = New SqlParameter("@BDGYear", GlobalPPT.intLoginYear)
    '    Parms(2) = New SqlParameter("@Period", objPPT.Period)
    '    Parms(3) = New SqlParameter("@Astek", objPPT.Astek)
    '    Parms(4) = New SqlParameter("@AstekP", objPPT.AstekP)
    '    Parms(5) = New SqlParameter("@Sundays", objPPT.Sundays)
    '    Parms(6) = New SqlParameter("@SundaysUnit", objPPT.SundaysUnit)
    '    Parms(7) = New SqlParameter("@SundaysRp", objPPT.SundaysRp)
    '    Parms(8) = New SqlParameter("@OtherDays", objPPT.OtherDays)
    '    Parms(9) = New SqlParameter("@OtherDaysUnit", objPPT.OtherDaysUnit)
    '    Parms(10) = New SqlParameter("@OtherDaysRp", objPPT.OtherDaysRp)
    '    Parms(11) = New SqlParameter("@LeaveCost", objPPT.LeaveCost)
    '    Parms(12) = New SqlParameter("@LeaveCostUnit", objPPT.LeaveCostUnit)
    '    Parms(13) = New SqlParameter("@LeaveCostRp", objPPT.LeaveCostRp)
    '    Parms(14) = New SqlParameter("@Rice", objPPT.Rice)
    '    Parms(15) = New SqlParameter("@RiceUnit", objPPT.RiceUnit)
    '    Parms(16) = New SqlParameter("@RiceRp", objPPT.RiceRp)
    '    Parms(17) = New SqlParameter("@THR", objPPT.THR)
    '    Parms(18) = New SqlParameter("@THRUnit", objPPT.THRUnit)
    '    Parms(19) = New SqlParameter("@THRRp", objPPT.THRRp)

    '    Parms(20) = New SqlParameter("@HarvestingQuarterID", objPPT.HarvestingQuarterID)

    '    Parms(21) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    '    Parms(22) = New SqlParameter("@ModifiedOn", Date.Today)

    '    Dim intResult As Integer = objdb.ExecNonQuery("[Budget].[StandardHarvestingQuarterUpdate]", Parms)
    '    'Catch ex As Exception
    '    'ManageException(ex, "RoleMasterDal", "UpdateRoleMaster")
    '    'End Try
    '    Return objPPT
    'End Function
    Public Shared Function IsYearExistStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(1) As SqlParameter
        'Parms(0) = New SqlParameter("@StandardConfigID", objPPT.StandardConfigID)
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)


        '  Try
        datatable = objdb.ExecQuery("[Budget].[StandardConfigIsExist]", Parms).Tables(0)

        'Catch ex As Exception
        'ManageException(ex, "RoleMasterDal", "SelectRoleName")
        ' End Try
        Return datatable

    End Function

    Public Shared Function UpdateStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As StandardConfigurationPPT
        Dim objdb As New SQLHelp
        Dim Parms(8) As SqlParameter

        'Parms(0) = New SqlParameter("@StandardConfigID", objPPT.StandardConfigID)
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Parms(2) = New SqlParameter("@ExcRateUStoRP", objPPT.ExcRateUStoRP)
        'Parms(4) = New SqlParameter("@MandayRateforKHP", objPPT.MandayRateforKHP)
        Parms(3) = New SqlParameter("@PlantingPalmPerHa", objPPT.PlantingPalmPerHa)
        'Parms(6) = New SqlParameter("@MandayRateforBHL", objPPT.MandayRateforBHL)
        Parms(4) = New SqlParameter("@ManuringPerHa", objPPT.ManuringPerHa)
        Parms(5) = New SqlParameter("@YearBaseRate", objPPT.YearBaseRate)
        Parms(6) = New SqlParameter("@PinkSlipPrefix", objPPT.PinkSlipPrefix)
        Parms(7) = New SqlParameter("@PinkSlipCommencingNo", objPPT.PinkSlipCommencingNo)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(9) = New SqlParameter("@ModifiedOn", Date.Today)

        Dim intResult As Integer = objdb.ExecNonQuery("[Budget].[StandardConfigUpdate]", Parms)

        Return objPPT
    End Function

    Public Shared Function DeleteStandardConfiguration(ByVal objPPT As StandardConfigurationPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim param(1) As SqlParameter
        Dim ds As New DataSet
        param(0) = New SqlParameter("@BudgetYear ", objPPT.BudgetYear)

        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)


        ds = objdb.ExecQuery("[Budget].[StandardConfigurationDelete]", param)
        Return ds
        'If rowsAffected <= 0 Then
        '    Return rowsAffected
        'End If

        'Return rowsAffected

    End Function
End Class

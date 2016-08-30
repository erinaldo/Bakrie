Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class StandardHarvestingCostDAL
    Public Shared Function StandardHarvestingInsert(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim Param(25) As SqlParameter


        Param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Param(2) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Param(3) = New SqlParameter("@Period", oStandardHarvestingCostPPT.Period)
        Param(4) = New SqlParameter("@YOPID", oStandardHarvestingCostPPT.YOPID)
        Param(5) = New SqlParameter("@NoofBunches", oStandardHarvestingCostPPT.NoofBunches)
        Param(6) = New SqlParameter("@NoOfHarvesterDays", oStandardHarvestingCostPPT.NoOfHarvesterDays)
        Param(7) = New SqlParameter("@CropInTon", oStandardHarvestingCostPPT.CropInTon)
        Param(8) = New SqlParameter("@LooseFruitPercent", oStandardHarvestingCostPPT.LooseFruitPercent)
        Param(9) = New SqlParameter("@LooseFruitTon", oStandardHarvestingCostPPT.LooseFruitTon)
        Param(10) = New SqlParameter("@NoOfHarvester", oStandardHarvestingCostPPT.NoOfHarvester)
        Param(11) = New SqlParameter("@HavesterPerHectrage ", oStandardHarvestingCostPPT.HavesterPerHectrage)
        Param(12) = New SqlParameter("@AvgNoBunchesPerDay ", oStandardHarvestingCostPPT.AvgNoBunchesPerDay)
        Param(13) = New SqlParameter("@Hectarage ", oStandardHarvestingCostPPT.Hectarage)
        Param(14) = New SqlParameter("@AvgBunchWeight ", oStandardHarvestingCostPPT.AvgBunchWeight)
        Param(15) = New SqlParameter("@BunchWeight ", oStandardHarvestingCostPPT.BunchWeight)
        Param(16) = New SqlParameter("@NormalDaysBase ", oStandardHarvestingCostPPT.NormalDaysBase)
        Param(17) = New SqlParameter("@NormalDaysPremi ", oStandardHarvestingCostPPT.NormalDaysPremi)
        Param(18) = New SqlParameter("@PremiumDaysPremi ", oStandardHarvestingCostPPT.PremiumDaysPremi)
        Param(19) = New SqlParameter("@LooseFruitKg ", oStandardHarvestingCostPPT.LooseFruitKg)
        Param(20) = New SqlParameter("@LooseFruitPremiIDR ", oStandardHarvestingCostPPT.LooseFruitPremiIDR)
        Param(21) = New SqlParameter("@TotalPay ", oStandardHarvestingCostPPT.TotalPay)
        Param(22) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Param(23) = New SqlParameter("@CreatedOn", Date.Today())
        Param(24) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(25) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[StandardHarvestingInsert]", Param)
        Return ds

    End Function


    Public Shared Function StandardHarvestingYOPGet() As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0

        Return objdb.ExecQuery("[Budget].[StandardHarvestingYOPGet]")
    End Function
    'Public Shared Function StandardHarvestingYOPIDGet(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet
    '    Dim objdb As New SQLHelp
    '    Dim rowsAffected As Integer = 0
    '    Dim param(0) As SqlParameter
    '    param(0) = New SqlParameter("@YOP", oStandardHarvestingCostPPT.YOP)

    '    Return objdb.ExecQuery("[Budget].[StandardHarvestingYOPIDGet]")
    'End Function

    Public Shared Function StandardHarvestingHectFill(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@YOPID", oStandardHarvestingCostPPT.YOPID)

        ds = objdb.ExecQuery("[Budget].[StandardHarvestingHectFill]", param)
        Return ds
    End Function

    Public Shared Function StandardHarvestingYOPSearch(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Param(3) As SqlParameter

        Param(0) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        If oStandardHarvestingCostPPT.YOP <> "" Then
            Param(2) = New SqlParameter("@YOP", oStandardHarvestingCostPPT.YOP)
        Else
            Param(2) = New SqlParameter("@YOP", DBNull.Value)
        End If
        If oStandardHarvestingCostPPT.Period <> "" Then
            Param(3) = New SqlParameter("@Period", oStandardHarvestingCostPPT.Period)
        Else
            Param(3) = New SqlParameter("@Period", DBNull.Value)
        End If


        Return objdb.ExecQuery("[Budget].[StandardHarvestingYOPSearch]", Param)
    End Function
    Public Shared Function StandardHarvestingCostSelect(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(1) As SqlParameter

        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("BudgetYear", GlobalPPT.intLoginYear)
        dt = objdb.ExecQuery("[Budget].[StandardHarvestingCostSelect]", param).Tables(0)
        Return dt
    End Function


    Public Shared Function StandardHarvestingUpdate(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim Param(24) As SqlParameter

        Param(0) = New SqlParameter("StandardHarvestingID", oStandardHarvestingCostPPT.StandardHarvestingID)
        Param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Param(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Param(3) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Param(4) = New SqlParameter("@Period", oStandardHarvestingCostPPT.Period)
        Param(5) = New SqlParameter("@YOPID", oStandardHarvestingCostPPT.YOPID)
        Param(6) = New SqlParameter("@NoofBunches", oStandardHarvestingCostPPT.NoofBunches)
        Param(7) = New SqlParameter("@NoOfHarvesterDays", oStandardHarvestingCostPPT.NoOfHarvesterDays)
        Param(8) = New SqlParameter("@CropInTon", oStandardHarvestingCostPPT.CropInTon)
        Param(9) = New SqlParameter("@LooseFruitPercent", oStandardHarvestingCostPPT.LooseFruitPercent)
        Param(10) = New SqlParameter("@LooseFruitTon", oStandardHarvestingCostPPT.LooseFruitTon)
        Param(11) = New SqlParameter("@NoOfHarvester", oStandardHarvestingCostPPT.NoOfHarvester)
        Param(12) = New SqlParameter("@HavesterPerHectrage ", oStandardHarvestingCostPPT.HavesterPerHectrage)
        Param(13) = New SqlParameter("@AvgNoBunchesPerDay ", oStandardHarvestingCostPPT.AvgNoBunchesPerDay)
        Param(14) = New SqlParameter("@Hectarage ", oStandardHarvestingCostPPT.Hectarage)
        Param(15) = New SqlParameter("@AvgBunchWeight ", oStandardHarvestingCostPPT.AvgBunchWeight)
        Param(16) = New SqlParameter("@BunchWeight ", oStandardHarvestingCostPPT.BunchWeight)
        Param(17) = New SqlParameter("@NormalDaysBase ", oStandardHarvestingCostPPT.NormalDaysBase)
        Param(18) = New SqlParameter("@NormalDaysPremi ", oStandardHarvestingCostPPT.NormalDaysPremi)
        Param(19) = New SqlParameter("@PremiumDaysPremi ", oStandardHarvestingCostPPT.PremiumDaysPremi)
        Param(20) = New SqlParameter("@LooseFruitKg ", oStandardHarvestingCostPPT.LooseFruitKg)
        Param(21) = New SqlParameter("@LooseFruitPremiIDR ", oStandardHarvestingCostPPT.LooseFruitPremiIDR)
        Param(22) = New SqlParameter("@TotalPay ", oStandardHarvestingCostPPT.TotalPay)
        'Param(22) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        'Param(23) = New SqlParameter("@CreatedOn", Date.Today())
        Param(23) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(24) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[StandardHarvestingUpdate]", Param)
        Return ds

    End Function


    Public Shared Function StandardHarvestingDelete(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As Integer
        Dim objdb As New SQLHelp
        Dim param(1) As SqlParameter
        Dim rowsAffected As Integer = 0
        param(0) = New SqlParameter("@StandardHarvestingID ", oStandardHarvestingCostPPT.StandardHarvestingID)

        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        rowsAffected = objdb.ExecNonQuery("[Budget].[StandardHarvestingDelete]", param)
        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function

    Public Function StandardHarvestingCostSelect_MultipleEntry(ByVal oStandardHarvestingCostPPT As StandardHarvestingCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Period", oStandardHarvestingCostPPT.Period)

        dt = objdb.ExecQuery("[Budget].[StandardHarvestingCostSelect_MultipleEntry]", Parms).Tables(0)
        Return dt
    End Function
End Class

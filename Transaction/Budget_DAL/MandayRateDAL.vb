Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class MandayRateDAL
    Public Shared Function MandayRateInsert(ByVal oMandayRatePPT As MandayRatePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim params(15) As SqlParameter

        params(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        params(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        params(2) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        params(3) = New SqlParameter("@PlantationCurrentUMPS", oMandayRatePPT.PlantationCurrentUMPS)
        params(4) = New SqlParameter("@LocalWageCurrentUMPS", oMandayRatePPT.LocalWageCurrentUMPS)
        params(5) = New SqlParameter("@Percentage", oMandayRatePPT.Percentage)
        params(6) = New SqlParameter("@PlantationAssGovtIncrease", oMandayRatePPT.PlantationAssGovtIncrease)
        params(7) = New SqlParameter("@LocalAssGovtIncrease", oMandayRatePPT.LocalAssGovtIncrease)
        params(8) = New SqlParameter("@PlantationNetCash", oMandayRatePPT.PlantationNetCash)
        params(9) = New SqlParameter("@LocalNetCash", oMandayRatePPT.LocalNetCash)
        params(10) = New SqlParameter("@PlantationDifferential", oMandayRatePPT.PlantationDifferential)
        params(11) = New SqlParameter("@LocalDifferential", oMandayRatePPT.LocalDifferential)
        params(12) = New SqlParameter("@PlantationIncreasePerDec", oMandayRatePPT.PlantationIncreasePerDec)
        params(13) = New SqlParameter("@LocalIncreasePerDec", oMandayRatePPT.LocalIncreasePerDec)
        params(14) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        'params(15) = New SqlParameter("@CreatedOn", Date.Today)
        params(15) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'params(17) = New SqlParameter("@ModifiedOn", Date.Today)

        ds = objdb.ExecQuery("[Budget].[MandayRateInsert]", params)
        Return ds
    End Function
    Public Shared Function MandayRateYearIsExist(ByVal oMandayRatePPT As MandayRatePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(1) As SqlParameter

        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[MandayRateYearIsExist]", param).Tables(0)

        Return dt
    End Function

    Public Shared Function MandayRateSelect(ByVal oMandayRatePPT As MandayRatePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[MandayRateSelect]", Parms).Tables(0)

        Return dt

    End Function
    Public Shared Function MandayRateUpdate(ByVal oMandayRatePPT As MandayRatePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim params(14) As SqlParameter


        params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        params(2) = New SqlParameter("@PlantationCurrentUMPS", oMandayRatePPT.PlantationCurrentUMPS)
        params(3) = New SqlParameter("@LocalWageCurrentUMPS", oMandayRatePPT.LocalWageCurrentUMPS)
        params(4) = New SqlParameter("@Percentage", oMandayRatePPT.Percentage)
        params(5) = New SqlParameter("@PlantationAssGovtIncrease", oMandayRatePPT.PlantationAssGovtIncrease)
        params(6) = New SqlParameter("@LocalAssGovtIncrease", oMandayRatePPT.LocalAssGovtIncrease)
        params(7) = New SqlParameter("@PlantationNetCash", oMandayRatePPT.PlantationNetCash)
        params(8) = New SqlParameter("@LocalNetCash", oMandayRatePPT.LocalNetCash)
        params(9) = New SqlParameter("@PlantationDifferential", oMandayRatePPT.PlantationDifferential)
        params(10) = New SqlParameter("@LocalDifferential", oMandayRatePPT.LocalDifferential)
        params(11) = New SqlParameter("@PlantationIncreasePerDec", oMandayRatePPT.PlantationIncreasePerDec)
        params(12) = New SqlParameter("@LocalIncreasePerDec", oMandayRatePPT.LocalIncreasePerDec)

        params(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        params(14) = New SqlParameter("@ModifiedOn", Date.Today)

        ds = objdb.ExecQuery("[Budget].[MandayRateUpdate]", params)
        Return ds
    End Function
    Public Shared Function MandayRateDelete(ByVal oMandayRatePPT As MandayRatePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        ds = objdb.ExecQuery("[Budget].[MandayRateDelete]", Parms)

        Return ds

    End Function
End Class

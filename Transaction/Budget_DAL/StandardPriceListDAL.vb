Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT
Public Class StandardPriceListDAL
    Public Shared Function InsertStandardPriceList(ByVal objPPT As StandardPriceListPPT) As StandardPriceListPPT
        Dim objdb As New SQLHelp
        'Try
        Dim Parms(17) As SqlParameter

        Parms(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@Type", objPPT.Type)
        'Parms(4) = New SqlParameter("@StockID", objPPT.StockID)
        'Parms(5) = New SqlParameter("@COAID", objPPT.COAID)
        Parms(4) = New SqlParameter("@UOMId", objPPT.UOMId)
        Parms(5) = New SqlParameter("@Remarks", objPPT.Remarks)
        Parms(6) = New SqlParameter("@PrimeCost", objPPT.PrimeCost)
        Parms(7) = New SqlParameter("@OnCost", objPPT.OnCost)
        Parms(8) = New SqlParameter("@TotalCost", objPPT.TotalCost)
        Parms(9) = New SqlParameter("@DisplayInUSD", objPPT.DisplayInUSD)
        Parms(10) = New SqlParameter("@LastYearCostIDR", objPPT.LastYearCostIDR)
        Parms(11) = New SqlParameter("@LastYearCostUSD", objPPT.LastYearCostUSD)
        Parms(12) = New SqlParameter("@PercentDiffUSD", objPPT.PercentDiffUSD)
        Parms(13) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(14) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(15) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(16) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(17) = New SqlParameter("@Descp", objPPT.Descp)
        ' Parms(18) = New SqlParameter("@StandardPriceListID", objPPT.StandardPriceListID)
        Dim intResult As Integer = objdb.ExecNonQuery("[Budget].[StandardPriceListInsert]", Parms)
        'Catch ex As Exception
        ' ManageException(ex, "RoleMasterDAL", "RoleMasterInsert"))
        'End Try
        Return objPPT
    End Function

    Public Shared Function SelectExchangeRateStandardPriceList() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        datatable = objdb.ExecQuery("[Budget].[StandardPriceListExchangeRateSelect]", Parms).Tables(0)

        Return datatable

    End Function
    Public Shared Function SelectUOMStandardPriceList() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        ' Dim Parms(0) As SqlParameter

        ' Parms(0) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        datatable = objdb.ExecQuery("[Budget].[StandardPriceListUOMSelect]").Tables(0)

        Return datatable

    End Function
    Public Shared Function SelectDescStandardPriceList() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()
        ' Dim Parms(0) As SqlParameter

        ' Parms(0) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        datatable = objdb.ExecQuery("[Budget].[StandardPriceListDescSelect]").Tables(0)

        Return datatable

    End Function

    Public Shared Function SelectAllStandardPriceList() As DataTable
        Dim objdb As New SQLHelp
        Dim datatable As New DataTable()

        datatable = objdb.ExecQuery("[Budget].[StandardPriceListSelectAll]").Tables(0)

        Return datatable

    End Function
    Public Shared Function UpdateStandardPriceList(ByVal objPPT As StandardPriceListPPT) As StandardPriceListPPT
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter

        Parms(0) = New SqlParameter("@StandardPriceListID", objPPT.StandardPriceListID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@Type", objPPT.Type)
        ' Parms(4) = New SqlParameter("@DescID", objPPT.d)
        Parms(4) = New SqlParameter("@Descp", objPPT.Descp)
        Parms(5) = New SqlParameter("@UOMId", objPPT.UOMId)
        Parms(6) = New SqlParameter("@Remarks", objPPT.Remarks)
        Parms(7) = New SqlParameter("@PrimeCost", objPPT.PrimeCost)
        Parms(8) = New SqlParameter("@OnCost", objPPT.OnCost)
        Parms(9) = New SqlParameter("@TotalCost", objPPT.TotalCost)
        Parms(10) = New SqlParameter("@DisplayInUSD", objPPT.DisplayInUSD)
        Parms(11) = New SqlParameter("@LastYearCostIDR", objPPT.LastYearCostIDR)
        Parms(12) = New SqlParameter("@LastYearCostUSD", objPPT.LastYearCostUSD)
        Parms(13) = New SqlParameter("@PercentDiffUSD", objPPT.PercentDiffUSD)
        Parms(14) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(15) = New SqlParameter("@ModifiedOn", Date.Today)

        Dim intResult As Integer = objdb.ExecNonQuery("[Budget].[StandardPriceListUpdate]", Parms)

        Return objPPT
    End Function
End Class

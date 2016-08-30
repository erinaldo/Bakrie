Imports System.Data.SqlClient
Imports Budget_PPT
Imports Common_DAL
Imports Common_PPT

Public Class ExpenditureBudgetByAgeOfPlantingDAL

    Public Shared Function RoundedUpValueGET(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)

        dt = objdb.ExecQuery("[Budget].[RoundedUpValueGET]", Parms).Tables(0)

        Return dt
    End Function

    Public Shared Function AcctlookupSearch(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oExpenditureBudgetByAgeOfPlantingPPT.COACode <> "" And oExpenditureBudgetByAgeOfPlantingPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oExpenditureBudgetByAgeOfPlantingPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oExpenditureBudgetByAgeOfPlantingPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oExpenditureBudgetByAgeOfPlantingPPT.COACode <> "" And oExpenditureBudgetByAgeOfPlantingPPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oExpenditureBudgetByAgeOfPlantingPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oExpenditureBudgetByAgeOfPlantingPPT.COACode = "" And oExpenditureBudgetByAgeOfPlantingPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oExpenditureBudgetByAgeOfPlantingPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Param(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Param)

    End Function

    Public Shared Function UOMLookupSearch(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        If oExpenditureBudgetByAgeOfPlantingPPT.CalcUOM <> "" Then
            Parms(0) = New SqlParameter("@UOM", oExpenditureBudgetByAgeOfPlantingPPT.CalcUOM)
        Else
            Parms(0) = New SqlParameter("@UOM", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@IsDirect", IsDirect)

        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentUOMSelect]", Parms)
        Return ds
    End Function
    Public Shared Function UOMLookupSearch1(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        If oExpenditureBudgetByAgeOfPlantingPPT.QtyUOM <> "" Then
            Parms(0) = New SqlParameter("@UOM", oExpenditureBudgetByAgeOfPlantingPPT.QtyUOM)
        Else
            Parms(0) = New SqlParameter("@UOM", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@IsDirect", IsDirect)

        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentUOMSelect]", Parms)
        Return ds
    End Function
    Public Shared Function UOMLookupSearch2(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        If oExpenditureBudgetByAgeOfPlantingPPT.OtherUOM <> "" Then
            Parms(0) = New SqlParameter("@UOM", oExpenditureBudgetByAgeOfPlantingPPT.OtherUOM)
        Else
            Parms(0) = New SqlParameter("@UOM", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@IsDirect", IsDirect)

        ds = objdb.ExecQuery("[Accounts].[PettyCashPaymentUOMSelect]", Parms)
        Return ds
    End Function

    Public Shared Function MaterialCheck(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        If oExpenditureBudgetByAgeOfPlantingPPT.StockCode <> "" Then
            Parms(0) = New SqlParameter("@StockCode", oExpenditureBudgetByAgeOfPlantingPPT.StockCode)
        Else
            Parms(0) = New SqlParameter("@StockCode", DBNull.Value)
        End If

        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        ds = objdb.ExecQuery("[Budget].[MaterialCheck]", Parms)
        Return ds
    End Function


    Public Shared Function ExpenditureBudgetByAgeOfPlantingMainInsert(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Params(16) As SqlParameter
        Params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Params(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        'ExpenditureBudgetbyageofplanting
        Params(2) = New SqlParameter("@AgeOfPlanting", oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting)
        Params(3) = New SqlParameter("@Yearofplanting", oExpenditureBudgetByAgeOfPlantingPPT.Yearofplanting)
        Params(4) = New SqlParameter("@COAID", oExpenditureBudgetByAgeOfPlantingPPT.COAID)
        Params(5) = New SqlParameter("@MDaysRound", oExpenditureBudgetByAgeOfPlantingPPT.MDaysRound)
        Params(6) = New SqlParameter("@Labour", oExpenditureBudgetByAgeOfPlantingPPT.Labour)
        Params(7) = New SqlParameter("@Material", oExpenditureBudgetByAgeOfPlantingPPT.Material)
        Params(8) = New SqlParameter("@Other", oExpenditureBudgetByAgeOfPlantingPPT.Other)
        Params(9) = New SqlParameter("@Total", oExpenditureBudgetByAgeOfPlantingPPT.Total)
        Params(10) = New SqlParameter("@Rounds", oExpenditureBudgetByAgeOfPlantingPPT.Rounds)
        Params(11) = New SqlParameter("@RpPerHect", oExpenditureBudgetByAgeOfPlantingPPT.RpPerHect)


        Params(12) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Params(13) = New SqlParameter("@CreatedOn", Date.Today)
        Params(14) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Params(15) = New SqlParameter("@ModifiedOn", Date.Today)
        Params(16) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Budget].[ExpenditureBudgetByAgeOfPlantingInsert]", Params)
        Return ds
    End Function

    Public Shared Function EBBAOPMaterialInsert(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Params(14) As SqlParameter
        Params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Params(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Params(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        Params(3) = New SqlParameter("@StandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID)
        Params(4) = New SqlParameter("@Calc", oExpenditureBudgetByAgeOfPlantingPPT.Calc)
        Params(5) = New SqlParameter("@CalcUOMID", oExpenditureBudgetByAgeOfPlantingPPT.CalcUOMID)
        Params(6) = New SqlParameter("@Qty", oExpenditureBudgetByAgeOfPlantingPPT.Qty)
        Params(7) = New SqlParameter("@QtyUOMID", oExpenditureBudgetByAgeOfPlantingPPT.QtyUOMID)
        Params(8) = New SqlParameter("@UnitPrice", oExpenditureBudgetByAgeOfPlantingPPT.UnitPrice)
        Params(9) = New SqlParameter("@Cost", oExpenditureBudgetByAgeOfPlantingPPT.Cost)

        Params(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Params(11) = New SqlParameter("@CreatedOn", Date.Today)
        Params(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Params(13) = New SqlParameter("@ModifiedOn", Date.Today)
        Params(14) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Budget].[EBBAOPMaterialInsert]", Params)
        Return ds
    End Function

    Public Shared Function EBBAOPOtherInsert(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Params(13) As SqlParameter
        Params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Params(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Params(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)

        Params(3) = New SqlParameter("@StandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.OtherStandardPriceListID)
        Params(4) = New SqlParameter("@OtherActivity", oExpenditureBudgetByAgeOfPlantingPPT.OtherActivity)
        Params(5) = New SqlParameter("@OtherUOMID", oExpenditureBudgetByAgeOfPlantingPPT.OtherUOMID)
        Params(6) = New SqlParameter("@OtherQty", oExpenditureBudgetByAgeOfPlantingPPT.OtherQty)

        Params(7) = New SqlParameter("@UnitPrice", oExpenditureBudgetByAgeOfPlantingPPT.UnitPrice)
        Params(8) = New SqlParameter("@Cost", oExpenditureBudgetByAgeOfPlantingPPT.Cost)


        Params(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Params(10) = New SqlParameter("@CreatedOn", Date.Today)
        Params(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Params(12) = New SqlParameter("@ModifiedOn", Date.Today)
        Params(13) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        ds = objdb.ExecQuery("[Budget].[EBBAOPOtherInsert]", Params)
        Return ds
    End Function
    Public Shared Function ExpenditureBudgetByAgeOfPlantingMainUpdate(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Params(14) As SqlParameter
        Params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Params(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Params(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        Params(3) = New SqlParameter("@AgeOfPlanting", oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting)
        Params(4) = New SqlParameter("@Yearofplanting", oExpenditureBudgetByAgeOfPlantingPPT.Yearofplanting)
        Params(5) = New SqlParameter("@COAID", oExpenditureBudgetByAgeOfPlantingPPT.COAID)
        Params(6) = New SqlParameter("@MDaysRound", oExpenditureBudgetByAgeOfPlantingPPT.MDaysRound)
        Params(7) = New SqlParameter("@Labour", oExpenditureBudgetByAgeOfPlantingPPT.Labour)
        Params(8) = New SqlParameter("@Material", oExpenditureBudgetByAgeOfPlantingPPT.Material)
        Params(9) = New SqlParameter("@Other", oExpenditureBudgetByAgeOfPlantingPPT.Other)
        Params(10) = New SqlParameter("@Total", oExpenditureBudgetByAgeOfPlantingPPT.Total)
        Params(11) = New SqlParameter("@Rounds", oExpenditureBudgetByAgeOfPlantingPPT.Rounds)
        Params(12) = New SqlParameter("@RpPerHect", oExpenditureBudgetByAgeOfPlantingPPT.RpPerHect)
        Params(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Params(14) = New SqlParameter("@ModifiedOn", Date.Today)


        ds = objdb.ExecQuery("[Budget].[ExpenditureBudgetByAgeOfPlantingUpdate]", Params)
        Return ds
    End Function

    Public Shared Function EBBAOPMaterialUpdate(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Params(12) As SqlParameter
        Params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Params(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Params(2) = New SqlParameter("@EBBAOPMaterialID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPMaterialID)

        Params(3) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        Params(4) = New SqlParameter("@StandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID)
        Params(5) = New SqlParameter("@Calc", oExpenditureBudgetByAgeOfPlantingPPT.Calc)
        Params(6) = New SqlParameter("@CalcUOMID", oExpenditureBudgetByAgeOfPlantingPPT.CalcUOMID)
        Params(7) = New SqlParameter("@Qty", oExpenditureBudgetByAgeOfPlantingPPT.Qty)
        Params(8) = New SqlParameter("@QtyUOMID", oExpenditureBudgetByAgeOfPlantingPPT.QtyUOMID)
        Params(9) = New SqlParameter("@UnitPrice", oExpenditureBudgetByAgeOfPlantingPPT.UnitPrice)
        Params(10) = New SqlParameter("@Cost", oExpenditureBudgetByAgeOfPlantingPPT.Cost)

        Params(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Params(12) = New SqlParameter("@ModifiedOn", Date.Today)


        ds = objdb.ExecQuery("[Budget].[EBBAOPMaterialUpdate]", Params)
        Return ds
    End Function

    Public Shared Function EBBAOPOtherUpdate(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Params(11) As SqlParameter
        Params(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Params(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Params(2) = New SqlParameter("@EBBAOPOtherID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPOtherID)

        Params(3) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)

        Params(4) = New SqlParameter("@StandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.OtherStandardPriceListID)
        Params(5) = New SqlParameter("@OtherActivity", oExpenditureBudgetByAgeOfPlantingPPT.OtherActivity)
        Params(6) = New SqlParameter("@OtherUOMID", oExpenditureBudgetByAgeOfPlantingPPT.OtherUOMID)
        Params(7) = New SqlParameter("@OtherQty", oExpenditureBudgetByAgeOfPlantingPPT.OtherQty)
        Params(8) = New SqlParameter("@UnitPrice", oExpenditureBudgetByAgeOfPlantingPPT.UnitPrice)
        Params(9) = New SqlParameter("@Cost", oExpenditureBudgetByAgeOfPlantingPPT.Cost)

      
        Params(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Params(11) = New SqlParameter("@ModifiedOn", Date.Today)


        ds = objdb.ExecQuery("[Budget].[EBBAOPOtherUpdate]", Params)
        Return ds
    End Function

    Public Shared Function StandardPriceListStockLoopUPSelect(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(3) As SqlParameter

        If oExpenditureBudgetByAgeOfPlantingPPT.Descp = String.Empty Then
            param(0) = New SqlParameter("@Descp", System.DBNull.Value)
        Else
            param(0) = New SqlParameter("@Descp", oExpenditureBudgetByAgeOfPlantingPPT.Descp)

        End If

        If oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear = Nothing Then
            param(1) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        Else
            param(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        End If

        param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        param(3) = New SqlParameter("@IsDirect", oExpenditureBudgetByAgeOfPlantingPPT.IsDirect)

        ds = objdb.ExecQuery("[Budget].[StandardPriceListStockLoopUPSelect]", param)

        Return ds

    End Function

    Public Shared Function FillViewGrid(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        If oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting = "" Then
            Parms(2) = New SqlParameter("@AgeOfPlanting", System.DBNull.Value)
        Else
            Parms(2) = New SqlParameter("@AgeOfPlanting", oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting)

        End If
      
        dt = objdb.ExecQuery("[Budget].[EBBAOPView]", Parms).Tables(0)

        Return dt
    End Function
    Public Shared Function FillMainGrid(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@AgeOfPlanting", oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting)
        dt = objdb.ExecQuery("[Budget].[EBBAOPSelectMain]", Parms).Tables(0)

        Return dt
    End Function

    Public Shared Function MaterialGridFill(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        dt = objdb.ExecQuery("[Budget].[MaterialGridFill]", Parms).Tables(0)

        Return dt
    End Function

    Public Shared Function OtherGridFill(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        dt = objdb.ExecQuery("[Budget].[OtherGridFill]", Parms).Tables(0)

        Return dt
    End Function
    Public Shared Function EBBAOPViewDelete(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        ds = objdb.ExecQuery("[Budget].[EBBAOPViewDelete]", Parms)

        Return ds

    End Function
    '''Delete Multi entry Datagrid
    '''
    Public Shared Function EBBAOPOtherDelete(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As Integer
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        Parms(3) = New SqlParameter("@EBBAOPOtherID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPOtherID)
        'Parms(4) = New SqlParameter("@OtherStandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID)


        rowsAffected = objdb.ExecNonQuery("[Budget].[EBBAOPOtherDelete]", Parms)
        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function
    Public Shared Function EBBAOPMaterialDelete(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As Integer
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@EBBAOPID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPID)
        Parms(3) = New SqlParameter("@EBBAOPMaterialID", oExpenditureBudgetByAgeOfPlantingPPT.EBBAOPMaterialID)
        'Parms(4) = New SqlParameter("@OtherStandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID)


        rowsAffected = objdb.ExecNonQuery("[Budget].[EBBAOPMaterialDelete]", Parms)
        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function
          
    Public Shared Function ExpenditureBudgetByAgeOfPlantingIsExist(ByVal oExpenditureBudgetByAgeOfPlantingPPT As ExpenditureBudgetByAgeOfPlantingPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BudgetYear", oExpenditureBudgetByAgeOfPlantingPPT.BudgetYear)
        Parms(2) = New SqlParameter("@AgeOfPlanting", oExpenditureBudgetByAgeOfPlantingPPT.AgeOfPlanting)
        Parms(3) = New SqlParameter("@StandardPriceListID", oExpenditureBudgetByAgeOfPlantingPPT.StandardPriceListID)

        Parms(4) = New SqlParameter("@COAID", oExpenditureBudgetByAgeOfPlantingPPT.COAID)
        ds = objdb.ExecQuery("[Budget].[EBBAOPIfExists]", Parms)

        Return ds

    End Function
    'Public Function DeleteMultiEntryJournal(ByVal ObjJournalPPT As JournalPPT) As Integer
    '    Dim objdb As New SQLHelp
    '    Dim Parms(1) As SqlParameter
    '    Dim rowsAffected As Integer = 0

    '    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(1) = New SqlParameter("@AccJournalID", ObjJournalPPT.AccJournalID)

    '    rowsAffected = objdb.ExecNonQuery("[Accounts].[AccJournalMultiEntryDelete]", Parms)

    '    If rowsAffected <= 0 Then
    '        Return rowsAffected
    '    End If
    '    Return rowsAffected
    'End Function
End Class

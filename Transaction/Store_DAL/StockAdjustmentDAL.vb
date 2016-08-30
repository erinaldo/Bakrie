Imports System.Data.SqlClient
Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Public Class StockAdjustmentDAL
    Public Function GetStockCode(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@StockID", objStkAdjustPPT.stockID)
        ds = objdb.ExecQuery("[Store].[LPOStockCode]", Parms)
        Return ds
    End Function
    Public Function STAdjustAvgPriceCalculate(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@StockId", objStkAdjustPPT.stockID)
        'Parms(3) = New SqlParameter("@STAdjustmentId", objStkAdjustPPT.STAdjustmentID) '@IssuedQty
        Parms(3) = New SqlParameter("@Qty", objStkAdjustPPT.AdjQty)
        Parms(4) = New SqlParameter("@TransType", objStkAdjustPPT.TransType)
        Parms(5) = New SqlParameter("@ID", objStkAdjustPPT.STAdjustmentID)
        Parms(6) = New SqlParameter("@Value", objStkAdjustPPT.AdjValue)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailAvgPriceAdjustApproval]", Parms)
        Return ds
    End Function
    Public Shared Function STALedgerAllModuleInsert(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objStkAdjustApprovalPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objStkAdjustApprovalPPT.AMonth)
        Parms(5) = New SqlParameter("@ModName", "STORE")
        Parms(6) = New SqlParameter("@LedgerDate", objStkAdjustApprovalPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objStkAdjustApprovalPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", IIf(objStkAdjustApprovalPPT.Descp <> String.Empty, objStkAdjustApprovalPPT.Descp, DBNull.Value))
        Parms(9) = New SqlParameter("@BatchAmount", DBNull.Value)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms)
        Return ds
    End Function
    Public Shared Function STALedgerAllModuleUpdate(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Dim intLedgerAllModuleRowsAffected As Integer = 0
        Parms(0) = New SqlParameter("@LedgerID", objStkAdjustApprovalPPT.LedgerID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@DC", objStkAdjustApprovalPPT.DC)
        Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        objdb.ExecNonQuery("[Accounts].[LedgerAllModuleUpdate_N]", Parms)
        intLedgerAllModuleRowsAffected = 1
        Return intLedgerAllModuleRowsAffected
    End Function
    Public Shared Function STAdjustStockIDDetailSelect(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@StockId", objStkAdjustPPT.stockID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STAdjustStockIDDetailSelect]", Parms)
        Return ds

    End Function
    Public Function GetAdjustmentNo(ByVal objAdjustmentNo As StockAdjustmentPPT) As StockAdjustmentPPT
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[STAdjustmentNoGet]", Parms)
        Dim clsUser As StockAdjustmentPPT = New StockAdjustmentPPT
        For Each dr As DataRow In ds.Tables(0).Rows
            clsUser.AdjustmentNo = IIf(IsDBNull(dr("NewAdjustNo")), "", dr("NewAdjustNo"))
        Next
        Return clsUser
    End Function

    Public Function GetSAAutoNop() As String
        Dim obj As New SQLHelp
        Dim ds As New DataSet
        Dim param() As SqlParameter
        ds = obj.ExecQuery("[Store].[SAAutoNo]", param)
        For Each dr As DataRow In ds.Tables(0).Rows
            Return dr("SANo").ToString()
        Next
    End Function

    Public Shared Function STIssueJournalDetailInsert(ByVal objStkAdjustApprovalPPT As StockAdjustmentApprovalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(24) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objStkAdjustApprovalPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objStkAdjustApprovalPPT.AMonth)
        Parms(3) = New SqlParameter("@LedgerID", objStkAdjustApprovalPPT.LedgerID)
        Parms(4) = New SqlParameter("@COAID", objStkAdjustApprovalPPT.COAID)
        Parms(5) = New SqlParameter("@DC", objStkAdjustApprovalPPT.DC)
        Parms(6) = New SqlParameter("@Value", objStkAdjustApprovalPPT.Value)
        Parms(7) = New SqlParameter("@DivID", IIf(objStkAdjustApprovalPPT.DivID <> String.Empty, objStkAdjustApprovalPPT.DivID, DBNull.Value))
        Parms(8) = New SqlParameter("@YOPID", IIf(objStkAdjustApprovalPPT.YopID <> String.Empty, objStkAdjustApprovalPPT.YopID, DBNull.Value))
        Parms(9) = New SqlParameter("@BlockID", IIf(objStkAdjustApprovalPPT.BlockID <> String.Empty, objStkAdjustApprovalPPT.BlockID, DBNull.Value))
        Parms(10) = New SqlParameter("@VHID", IIf(objStkAdjustApprovalPPT.VHID <> String.Empty, objStkAdjustApprovalPPT.VHID, DBNull.Value))
        Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objStkAdjustApprovalPPT.VHDetailCostCodeID <> String.Empty, objStkAdjustApprovalPPT.VHDetailCostCodeID, DBNull.Value))
        Parms(12) = New SqlParameter("@T0", IIf(objStkAdjustApprovalPPT.T0analysisID <> String.Empty, objStkAdjustApprovalPPT.T0analysisID, DBNull.Value))
        Parms(13) = New SqlParameter("@T1", IIf(objStkAdjustApprovalPPT.T1analysisID <> String.Empty, objStkAdjustApprovalPPT.T1analysisID, DBNull.Value))
        Parms(14) = New SqlParameter("@T2", IIf(objStkAdjustApprovalPPT.T2analysisID <> String.Empty, objStkAdjustApprovalPPT.T2analysisID, DBNull.Value))
        Parms(15) = New SqlParameter("@T3", IIf(objStkAdjustApprovalPPT.T3analysisID <> String.Empty, objStkAdjustApprovalPPT.T3analysisID, DBNull.Value))
        Parms(16) = New SqlParameter("@T4", IIf(objStkAdjustApprovalPPT.T4analysisID <> String.Empty, objStkAdjustApprovalPPT.T4analysisID, DBNull.Value))
        Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(21) = New SqlParameter("@Descp", IIf(objStkAdjustApprovalPPT.JournalDetDescp <> String.Empty, objStkAdjustApprovalPPT.JournalDetDescp, DBNull.Value))
        Parms(22) = New SqlParameter("@Flag", IIf(objStkAdjustApprovalPPT.Flag <> String.Empty, objStkAdjustApprovalPPT.Flag, DBNull.Value))
        Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(24) = New SqlParameter("@StationID", IIf(objStkAdjustApprovalPPT.StationID <> String.Empty, objStkAdjustApprovalPPT.StationID, DBNull.Value))


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[JournalDetailInsert_N]", Parms)
        Return ds
    End Function
    Public Shared Function AcctlookupSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        If objStoreIssueVoucher.COACode <> "" And objStoreIssueVoucher.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objStoreIssueVoucher.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objStoreIssueVoucher.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@IsDirect", "NO")
        ElseIf objStoreIssueVoucher.COACode <> "" And objStoreIssueVoucher.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objStoreIssueVoucher.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@IsDirect", "NO")
        ElseIf objStoreIssueVoucher.COACode = "" And objStoreIssueVoucher.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objStoreIssueVoucher.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@IsDirect", "NO")
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@IsDirect", "NO")
        End If
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)
    End Function
    Public Shared Function saveStockAdjustment(ByVal objStockAdjustmentPPT As StockAdjustmentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(24) As SqlParameter

        ' Parms(0) = New SqlParameter("@STAdjustmentID", )
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@AdjustmentNo", objStockAdjustmentPPT.AdjustmentNo)
        Parms(4) = New SqlParameter("@AdjustmentDate", objStockAdjustmentPPT.AdjustmentDate)
        Parms(5) = New SqlParameter("@stockID", objStockAdjustmentPPT.stockID)
        Parms(6) = New SqlParameter("@Status", objStockAdjustmentPPT.Status)
        Parms(7) = New SqlParameter("@RejectedReason", IIf(objStockAdjustmentPPT.RejectedReason <> String.Empty, objStockAdjustmentPPT.RejectedReason, DBNull.Value))
        Parms(8) = New SqlParameter("@AdjQty", objStockAdjustmentPPT.AdjQty)
        Parms(9) = New SqlParameter("@AdjValue", objStockAdjustmentPPT.AdjValue)
        Parms(10) = New SqlParameter("@COAID", IIf(objStockAdjustmentPPT.COAID <> String.Empty, objStockAdjustmentPPT.COAID, DBNull.Value))
        Parms(11) = New SqlParameter("@DIVID", IIf(objStockAdjustmentPPT.DivID <> String.Empty, objStockAdjustmentPPT.DivID, DBNull.Value))
        Parms(12) = New SqlParameter("@YOPID", IIf(objStockAdjustmentPPT.YopID <> String.Empty, objStockAdjustmentPPT.YopID, DBNull.Value))
        Parms(13) = New SqlParameter("@BlockID", IIf(objStockAdjustmentPPT.BlockID <> String.Empty, objStockAdjustmentPPT.BlockID, DBNull.Value))
        Parms(14) = New SqlParameter("@T0", IIf(objStockAdjustmentPPT.T0analysisID <> String.Empty, objStockAdjustmentPPT.T0analysisID, DBNull.Value))
        Parms(15) = New SqlParameter("@T1", IIf(objStockAdjustmentPPT.T1analysisID <> String.Empty, objStockAdjustmentPPT.T1analysisID, DBNull.Value))
        Parms(16) = New SqlParameter("@T2", IIf(objStockAdjustmentPPT.T2analysisID <> String.Empty, objStockAdjustmentPPT.T2analysisID, DBNull.Value))
        Parms(17) = New SqlParameter("@T3", IIf(objStockAdjustmentPPT.T3analysisID <> String.Empty, objStockAdjustmentPPT.T3analysisID, DBNull.Value))
        Parms(18) = New SqlParameter("@T4", IIf(objStockAdjustmentPPT.T4analysisID <> String.Empty, objStockAdjustmentPPT.T4analysisID, DBNull.Value))

        Parms(19) = New SqlParameter("@Remarks", IIf(objStockAdjustmentPPT.Remarks <> String.Empty, objStockAdjustmentPPT.Remarks, DBNull.Value))
        ' Parms(21) = New SqlParameter("@ConcurrencyId", String.Empty)
        Parms(20) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(21) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(22) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(23) = New SqlParameter("@ModifiedOn", Date.Today())

        Parms(24) = New SqlParameter("@BeritaAcaraAudit", objStockAdjustmentPPT.BeritaAcaraAudit)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STAdjustmentInsert]", Parms)
        Return ds
    End Function
    Public Function Delete_AdjustmentDetail(ByVal objAdjustmentPPT As StockAdjustmentPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STAdjustmentID", objAdjustmentPPT.STAdjustmentID)
        'Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(11) = New SqlParameter("@ModifiedOn", Date.Today)

        rowsAffected = objdb.ExecNonQuery("[Store].[STAdjustmentDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function

    Public Function Delete_AdjustDetail(ByVal objAdjustPPT As StockAdjustmentPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AdjustmentNo", objAdjustPPT.AdjustmentNo)
        'Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        'Parms(11) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(3) = New SqlParameter("@ModifiedOn", Date.Today())

        rowsAffected = objdb.ExecNonQuery("[Store].[STAdjustmentDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected

    End Function

    Public Function AdjustmentStockDetailGet(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataTable
        'Dim objdb As New SQLHelp
        'Dim params(2) As SqlParameter
        'Dim dt As New DataTable
        'params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'params(2) = New SqlParameter("@StockId", objStkAdjustPPT.stockID)

        'dt = objdb.ExecQuery("[Store].[STAdjustmentStockDetailsGet]", params).Tables(0)
        'Return dt
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter
        If objStkAdjustPPT.stockID <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@StockCode", objStkAdjustPPT.stockID) 'Textbox value
            Parms(3) = New SqlParameter("@Stockcodesearch", DBNull.Value) 'Textbox value
            Parms(4) = New SqlParameter("@StockDescsearch", DBNull.Value)

        ElseIf objStkAdjustPPT.stockCode = String.Empty And objStkAdjustPPT.stockDescription = String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@StockCode", DBNull.Value)
            Parms(3) = New SqlParameter("@Stockcodesearch", DBNull.Value) 'Textbox value
            Parms(4) = New SqlParameter("@StockDescsearch", DBNull.Value) 'Textbox value
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@Stockcodesearch", objStkAdjustPPT.stockCode) 'Textbox value
            Parms(3) = New SqlParameter("@StockDescsearch", objStkAdjustPPT.stockDescription) 'Textbox value
            Parms(4) = New SqlParameter("@StockCode", DBNull.Value)

        End If
        dt = objdb.ExecQuery("[Store].[STStockDetailsGet]", Parms).Tables(0)
        Return dt

    End Function
    Public Function Update_Adjust(ByVal objAdjustUpdate As StockAdjustmentPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(21) As SqlParameter
        Dim rowsAffected As Integer = 0
        'Dim datetime As Date = System.DateTime.Today

        Parms(0) = New SqlParameter("@STAdjustmentID", objAdjustUpdate.STAdjustmentID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@AdjustmentDate", objAdjustUpdate.AdjustmentDate)
        'Parms(4) = New SqlParameter("@StockCode", objAdjustUpdate.stockCode)
        Parms(4) = New SqlParameter("@StockID", objAdjustUpdate.stockID)
        Parms(5) = New SqlParameter("@Status", objAdjustUpdate.Status)
        Parms(6) = New SqlParameter("@RejectedReason", IIf(objAdjustUpdate.RejectedReason <> String.Empty, objAdjustUpdate.RejectedReason, DBNull.Value))
        Parms(7) = New SqlParameter("@Qty", objAdjustUpdate.AdjQty)
        Parms(8) = New SqlParameter("@AdjValue", objAdjustUpdate.AdjValue)
        Parms(9) = New SqlParameter("@COAID", IIf(objAdjustUpdate.COAID <> String.Empty, objAdjustUpdate.COAID, DBNull.Value))
        Parms(10) = New SqlParameter("@DIVID", IIf(objAdjustUpdate.DivID <> String.Empty, objAdjustUpdate.DivID, DBNull.Value))
        Parms(11) = New SqlParameter("@YOPID", IIf(objAdjustUpdate.YopID <> String.Empty, objAdjustUpdate.YopID, DBNull.Value))
        Parms(12) = New SqlParameter("@BlockID", IIf(objAdjustUpdate.BlockID <> String.Empty, objAdjustUpdate.BlockID, DBNull.Value))
        Parms(13) = New SqlParameter("@T0", IIf(objAdjustUpdate.T0analysisID <> String.Empty, objAdjustUpdate.T0analysisID, DBNull.Value))
        Parms(14) = New SqlParameter("@T1", IIf(objAdjustUpdate.T1analysisID <> String.Empty, objAdjustUpdate.T1analysisID, DBNull.Value))
        Parms(15) = New SqlParameter("@T2", IIf(objAdjustUpdate.T2analysisID <> String.Empty, objAdjustUpdate.T2analysisID, DBNull.Value))
        Parms(16) = New SqlParameter("@T3", IIf(objAdjustUpdate.T3analysisID <> String.Empty, objAdjustUpdate.T3analysisID, DBNull.Value))
        Parms(17) = New SqlParameter("@T4", IIf(objAdjustUpdate.T4analysisID <> String.Empty, objAdjustUpdate.T4analysisID, DBNull.Value))
        Parms(18) = New SqlParameter("@Remarks", IIf(objAdjustUpdate.Remarks <> String.Empty, objAdjustUpdate.Remarks, DBNull.Value))
        Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(20) = New SqlParameter("@ModifiedOn", DateTime.Today)
        'Parms(21) = New SqlParameter("@Estatecode", GlobalPPT.strEstateCode)
        Parms(21) = New SqlParameter("@AdjustmentNo", objAdjustUpdate.AdjustmentNo)
        ' Parms(22) = New SqlParameter("@StockId", objAdjustUpdate.stockID)
        rowsAffected = objdb.ExecNonQuery("[Store].[STAdjustmentUpdate]", Parms)

        'If rowsAffected <= 0 Then
        '    Return rowsAffected
        'End If
        'Return rowsAffected
    End Function

    Public Function GetAdjustmentDetails(ByVal objAdjustmentPPT As StockAdjustmentPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(4) As SqlParameter
        Dim dt As New DataTable
        'If objIPRPPT.IPRNo <> "" Then

        params(0) = New SqlParameter("@AdjustmentDate", IIf(objAdjustmentPPT.AdjustmentDate <> Nothing, objAdjustmentPPT.AdjustmentDate, DBNull.Value)) 'objIPRPPT.IPRdate)
        params(1) = New SqlParameter("@AdjustmentNo", IIf(objAdjustmentPPT.AdjustmentNo <> "", objAdjustmentPPT.AdjustmentNo, DBNull.Value))
        params(2) = New SqlParameter("@Status", objAdjustmentPPT.Status)
        params(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' params(5) = New SqlParameter("@STAdjustmentID", objAdjustmentPPT.STAdjustmentID)
        dt = objdb.ExecQuery("[Store].[AdjustmentViewSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function GetAdjustDetailsInfo(ByVal objStkAdjustPPT As StockAdjustmentPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@AdjustmentNo", objStkAdjustPPT.AdjustmentNo)
        params(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        dt = objdb.ExecQuery("[Store].[GetAdjustAddInfo]", params).Tables(0)
        Return dt
    End Function
    Public Function Update_AdjustApproval(ByVal objStkAdjustPPT As StockAdjustmentPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@STAdjustmentID", objStkAdjustPPT.STAdjustmentID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@Adjustmentdate", objStkAdjustPPT.AdjustmentDate)
        Parms(4) = New SqlParameter("@Status", objStkAdjustPPT.Status)
        Parms(5) = New SqlParameter("@Remarks", IIf(objStkAdjustPPT.Remarks <> String.Empty, objStkAdjustPPT.Remarks, DBNull.Value))
        Parms(6) = New SqlParameter("@RejectedReason", IIf(objStkAdjustPPT.RejectedReason <> String.Empty, objStkAdjustPPT.RejectedReason, DBNull.Value))
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn ", Date.Today)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)

        rowsAffected = objdb.ExecNonQuery("[Store].[STAdjustApproval]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    Public Function STARecordIsExist(ByVal objStockAdjustmentPPT As StockAdjustmentPPT) As Object

        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STAdjustmentRecordIsExist]", Parms)

        Return objExists

    End Function

    Public Shared Function STAdjustmentDelete_N(ByVal objAdjustmentPPT As StockAdjustmentPPT) As Integer


        Dim objdb As New SQLHelp

        Dim intSTARowsAffected As Integer = 0

        Try

            Dim Parms(1) As SqlParameter
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STAdjustmentID", objAdjustmentPPT.STAdjustmentID)
           
            intSTARowsAffected = objdb.ExecNonQuery("[Store].[STAdjustmentDelete_N]", Parms)
            intSTARowsAffected = 1

        Catch ex As Exception
            intSTARowsAffected = 0
        End Try
        Return intSTARowsAffected


    End Function
 

End Class

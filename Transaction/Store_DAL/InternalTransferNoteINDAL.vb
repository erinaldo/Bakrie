Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class InternalTransferNoteINDAL
    Public Function STITNInStockCodeGet(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter
        If objINTINPPT.StockID <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@StockCode", objINTINPPT.StockID) 'Textbox value
            Parms(3) = New SqlParameter("@Stockcodesearch", DBNull.Value) 'Textbox value
            Parms(4) = New SqlParameter("@StockDescsearch", DBNull.Value)

        ElseIf objINTINPPT.StockCode = String.Empty And objINTINPPT.StockDesc = String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@StockCode", DBNull.Value)
            Parms(3) = New SqlParameter("@Stockcodesearch", DBNull.Value) 'Textbox value
            Parms(4) = New SqlParameter("@StockDescsearch", DBNull.Value) 'Textbox value
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@Stockcodesearch", objINTINPPT.StockCode) 'Textbox value
            Parms(3) = New SqlParameter("@StockDescsearch", objINTINPPT.StockDesc) 'Textbox value
            Parms(4) = New SqlParameter("@StockCode", DBNull.Value)

        End If
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailsGet]", Parms)
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
        End If
        Return dt
    End Function

    Public Function STITNInSendLocGet(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter

        If objINTINPPT.SendersLocation <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", objINTINPPT.SendersLocation) 'searching in sender location text leave.
            Parms(2) = New SqlParameter("@SenderLocationSearch", DBNull.Value) 'lookup search
        ElseIf objINTINPPT.SendersLocationSearch <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", DBNull.Value)
            Parms(2) = New SqlParameter("@SenderLocationSearch", objINTINPPT.SendersLocationSearch)
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", DBNull.Value)
            Parms(2) = New SqlParameter("@SenderLocationSearch", DBNull.Value)
        End If
        dt = objdb.ExecQuery("[Store].[STInternalTransferInSendLocGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function AcctlookupSearch(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@Accountcode", objINTINPPT.COACode)
        Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", "YES")
        dt = objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function ITInNo_isExist(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ItnInNo", objINTINPPT.ItnInNo)

        dt = objdb.ExecQuery("[Store].[STInternalTransferInIsExist]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Save_STInternalTransferIn(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ItnInNo", objINTINPPT.ItnInNo)
        Parms(3) = New SqlParameter("@ITNDate", objINTINPPT.ITNDate)
        Parms(4) = New SqlParameter("@Remarks", objINTINPPT.Remarks)
        Parms(5) = New SqlParameter("@SendersLocationID", IIf(objINTINPPT.SendersLocation <> String.Empty, objINTINPPT.SendersLocation, DBNull.Value))
        Parms(6) = New SqlParameter("@Status", objINTINPPT.Status)
        Parms(7) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today)

        Parms(12) = New SqlParameter("@OperatorName", objINTINPPT.OperatorName)
        Parms(13) = New SqlParameter("@TransportDate", objINTINPPT.TransportDate)
        Parms(14) = New SqlParameter("@VehicleNo", objINTINPPT.VehicleNo)
        Parms(15) = New SqlParameter("@MRCNo", objINTINPPT.MRCNo)

        dt = objdb.ExecQuery("[Store].[STInternalTransferInInsert]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Update_STInternalTransferIn(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@ItnInNo", objINTINPPT.ItnInNo)
            Parms(4) = New SqlParameter("@ITNDate", objINTINPPT.ITNDate)
            Parms(5) = New SqlParameter("@SendersLocationID", IIf(objINTINPPT.SendersLocation <> String.Empty, objINTINPPT.SendersLocation, DBNull.Value)) '"") 'objINTINPPT.SendersLocation)
            Parms(6) = New SqlParameter("@Remarks", objINTINPPT.Remarks)
            Parms(7) = New SqlParameter("@Status", objINTINPPT.Status)
            Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferInUpdate]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Save_STITNInDetailsInsert(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@StockID", objINTINPPT.StockID)
            Parms(4) = New SqlParameter("@PartNo", objINTINPPT.PartNo)
            Parms(5) = New SqlParameter("@AvailQty", objINTINPPT.AvailQty)
            Parms(6) = New SqlParameter("@UnitPrice", objINTINPPT.UnitPrice)
            Parms(7) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(8) = New SqlParameter("@COAID", objINTINPPT.COAID)
            Parms(9) = New SqlParameter("@TransferInQty", objINTINPPT.TransferInQty)
            Parms(10) = New SqlParameter("@TransferInValue", objINTINPPT.TransferInValue)
            Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(12) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(14) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferInDetailsInsert]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Update_STITNInDetailsUpdate(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)
            Parms(1) = New SqlParameter("@STInternalTransferInDetailsID", objINTINPPT.STInternalTransferInDetailsID)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(4) = New SqlParameter("@StockID", objINTINPPT.StockID)
            Parms(5) = New SqlParameter("@PartNo", objINTINPPT.PartNo)
            Parms(6) = New SqlParameter("@AvailQty", objINTINPPT.AvailQty)
            Parms(7) = New SqlParameter("@UnitPrice", objINTINPPT.UnitPrice)
            Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(9) = New SqlParameter("@COAID", objINTINPPT.COAID)
            Parms(10) = New SqlParameter("@TransferInQty", objINTINPPT.TransferInQty)
            Parms(11) = New SqlParameter("@TransferInValue", objINTINPPT.TransferInValue)
            Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(13) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferInDetailsUpdate]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function STInternalTransferInSelect(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ITNDate", IIf(objINTINPPT.ITNDate <> Nothing, objINTINPPT.ITNDate, DBNull.Value))
        Parms(3) = New SqlParameter("@ItnInNo", IIf(objINTINPPT.ItnInNo <> String.Empty, objINTINPPT.ItnInNo, DBNull.Value))
        If objINTINPPT.Status = "SELECT ALL" Then
            Parms(4) = New SqlParameter("@Status", DBNull.Value)
        Else
            Parms(4) = New SqlParameter("@Status", objINTINPPT.Status)
        End If
        'Parms(4) = New SqlParameter("@Status", IIf(objINTINPPT.Status <> String.Empty, objINTINPPT.Status, DBNull.Value))
        Parms(5) = New SqlParameter("@SenderLocation", IIf(objINTINPPT.SendersLocation <> String.Empty, objINTINPPT.SendersLocation, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STInternalTransferInSelect_N]", Parms).Tables(0)
        Return dt
    End Function

    Public Function ITNInDetails_Select(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)

        dt = objdb.ExecQuery("[Store].[STInternalTransferInDetailsSelect_N]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Delete_STInternalTransferIn(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())
            objdb.ExecNonQuery("[Store].[STInternalTransferInDelete]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Update_STInternalTransferInApproval(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferInID", objINTINPPT.STInternalTransferInID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@Status", objINTINPPT.Status)
            Parms(4) = New SqlParameter("@RejectedReason", objINTINPPT.RejectedReason)
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferInApproval]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Save_LedgerAllModule(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(4) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(5) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(6) = New SqlParameter("@ModName", "STORE")
        Parms(7) = New SqlParameter("@LedgerDate", objINTINPPT.ITNDate)
        Parms(8) = New SqlParameter("@LedgerType", "STORE-ITNIN")
        Parms(9) = New SqlParameter("@Descp", objINTINPPT.Remarks)
        Parms(10) = New SqlParameter("@BatchAmount", objINTINPPT.TransferInValue)
        Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(14) = New SqlParameter("@ModifiedOn", Date.Today)

        dt = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms).Tables(0)
      
        Return dt
    End Function

    Public Function Update_LedgerAllModule(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsaffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@LedgerID", objINTINPPT.LedgerID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@DC", "D")
            Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)
            objdb.ExecQuery("[Accounts].[LedgerAllModuleUpdate_N]", Parms)
            rowsaffected = 1
        Catch ex As Exception
            rowsaffected = 0
        End Try
        Return rowsaffected
    End Function

    Public Function ITNIn_Averageprice(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(6) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@ID", objINTINPPT.STInternalTransferInID)
        params(3) = New SqlParameter("@StockId", objINTINPPT.StockID)
        params(4) = New SqlParameter("@Qty", objINTINPPT.TransferInQty)
        params(5) = New SqlParameter("@Value", objINTINPPT.TransferInValue)
        params(6) = New SqlParameter("@TransType", "ITNIN")

        dt = objdb.ExecQuery("[Store].[STStockDetailAvgPriceApproval_Raja]", params).Tables(0)
        Return dt
    End Function

    Public Function AC_JournalDetailInsert(ByVal objINTINPPT As InternalTransferNoteINPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(24) As SqlParameter
        Try

            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
            Parms(2) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
            Parms(3) = New SqlParameter("@LedgerID", objINTINPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objINTINPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objINTINPPT.DC)
            Parms(6) = New SqlParameter("@Value", objINTINPPT.value)
            Parms(7) = New SqlParameter("@DivID", IIf(objINTINPPT.DivID <> String.Empty, objINTINPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objINTINPPT.YopID <> String.Empty, objINTINPPT.YopID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objINTINPPT.BlockID <> String.Empty, objINTINPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objINTINPPT.VHID <> String.Empty, objINTINPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objINTINPPT.VHDetailCostCodeID <> String.Empty, objINTINPPT.VHDetailCostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objINTINPPT.T0 <> String.Empty, objINTINPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objINTINPPT.T1 <> String.Empty, objINTINPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objINTINPPT.T2 <> String.Empty, objINTINPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objINTINPPT.T3 <> String.Empty, objINTINPPT.T3, DBNull.Value))
            'Parms(13) = New SqlParameter("@T1", IIf(objINTINPPT.T1 <> String.Empty, objINTINPPT.T1, DBNull.Value))
            'Parms(14) = New SqlParameter("@T2", IIf(objINTINPPT.T2 <> String.Empty, objINTINPPT.T2, DBNull.Value))
            'Parms(15) = New SqlParameter("@T3", IIf(objINTINPPT.T3 <> String.Empty, objINTINPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objINTINPPT.T4 <> String.Empty, objINTINPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objINTINPPT.JournalDetDescp <> String.Empty, objINTINPPT.JournalDetDescp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objINTINPPT.Flag <> String.Empty, objINTINPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objINTINPPT.StationID <> String.Empty, objINTINPPT.StationID, DBNull.Value))
            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function ITNIn_StockDetailGet(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@StockId", objINTINPPT.StockID)

        dt = objdb.ExecQuery("[Store].[STInternalTransferInStockDetailsGet]", params).Tables(0)
        Return dt
    End Function

    Public Function STITNInStockCodeGetNew(ByVal objINTINPPT As InternalTransferNoteINPPT, ByVal IsDirect As String) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(6) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockCode", IIf(objINTINPPT.StockCode <> String.Empty, objINTINPPT.StockCode, DBNull.Value))
        Parms(3) = New SqlParameter("@StockDesc", IIf(objINTINPPT.StockDesc <> String.Empty, objINTINPPT.StockDesc, DBNull.Value))
        Parms(4) = New SqlParameter("@PartNo", IIf(objINTINPPT.PartNo <> String.Empty, objINTINPPT.PartNo, DBNull.Value))
        Parms(5) = New SqlParameter("@STCategoryID", IIf(objINTINPPT.STCategoryID <> String.Empty, objINTINPPT.STCategoryID, DBNull.Value))
        Parms(6) = New SqlParameter("@IsDirect", IsDirect)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailsGetNew]", Parms)
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
        End If
        Return dt
    End Function

    Public Function STStockDetailsSelect(ByVal objINTINPPT As InternalTransferNoteINPPT, ByVal IsDirect As String) As DataTable

        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(6) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockCode", IIf(objINTINPPT.StockCode <> String.Empty, objINTINPPT.StockCode, DBNull.Value))
        Parms(3) = New SqlParameter("@StockDesc", IIf(objINTINPPT.StockDesc <> String.Empty, objINTINPPT.StockDesc, DBNull.Value))
        Parms(4) = New SqlParameter("@PartNo", IIf(objINTINPPT.PartNo <> String.Empty, objINTINPPT.PartNo, DBNull.Value))
        Parms(5) = New SqlParameter("@STCategoryID", IIf(objINTINPPT.STCategoryID <> String.Empty, objINTINPPT.STCategoryID, DBNull.Value))
        Parms(6) = New SqlParameter("@IsDirect", IsDirect)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailsSelect]", Parms)

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
        End If

        Return dt

    End Function

    Public Function STStockDetailsSelectDetails(ByVal objINTINPPT As InternalTransferNoteINPPT) As DataTable

        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", objINTINPPT.StockID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailsSelectDetails]", Parms)

        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
        End If

        Return dt

    End Function

    Public Function ITNInRecordIsExist(ByVal objINTINPPT As InternalTransferNoteINPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STInternalTransferInRecordIsExist]", Parms)
        Return objExists
    End Function

    Public Function STInternalTransferInDetailsDelete(ByVal objITNIN As InternalTransferNoteINPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intITNINRowsAffected As Integer = 0

        Try

            Dim Parms(1) As SqlParameter

            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            Parms(1) = New SqlParameter("@STInternalTransferInDetailsID", objITNIN.STInternalTransferInDetailsID)

            objdb.ExecNonQuery("[Store].[STInternalTransferInDetailsDelete]", Parms)
            intITNINRowsAffected = 1
        Catch ex As Exception
            intITNINRowsAffected = 0
        End Try
        Return intITNINRowsAffected


    End Function

End Class

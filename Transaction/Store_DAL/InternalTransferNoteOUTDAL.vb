Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class InternalTransferNoteOUTDAL
    Public Function GetITNOutNo(ByVal objITNOutNo As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        dt = objdb.ExecQuery("[Store].[STITNOUTNoGet]", Parms).Tables(0)
        ' objdb.ExecQuery("[Store].[STITNOUTNoGet] ", Parms)
        'Dim _objITNOutNo As InternalTransferNoteOUTDAL = New InternalTransferNoteOUTDAL
        'For Each dr As DataRow In ds.Tables(0).Rows
        '    _objITNOutNo.IPRNo = IIf(IsDBNull(dr("NewITNOUTNo")), "", dr("NewITNOUTNo"))
        'Next
        Return dt
    End Function

    Public Function GetTNOutAutoNo() As String
        Dim obj As New SQLHelp
        Dim ds As New DataSet
        Dim param() As SqlParameter
        ds = obj.ExecQuery("[Store].[TNOutAutoNo]", param)
        For Each dr As DataRow In ds.Tables(0).Rows
            Return dr("TNOutNo").ToString()
        Next
    End Function

    Public Function STITNOutStockCodeGet(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(4) As SqlParameter
        If objITNOutPPT.StockID <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@StockCode", objITNOutPPT.StockID) 'Textbox value
            Parms(3) = New SqlParameter("@Stockcodesearch", DBNull.Value) 'Textbox value
            Parms(4) = New SqlParameter("@StockDescsearch", DBNull.Value)

        ElseIf objITNOutPPT.StockCode = String.Empty And objITNOutPPT.StockDesc = String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@StockCode", DBNull.Value)
            Parms(3) = New SqlParameter("@Stockcodesearch", DBNull.Value) 'Textbox value
            Parms(4) = New SqlParameter("@StockDescsearch", DBNull.Value) 'Textbox value
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(2) = New SqlParameter("@Stockcodesearch", objITNOutPPT.StockCode) 'Textbox value
            Parms(3) = New SqlParameter("@StockDescsearch", objITNOutPPT.StockDesc) 'Textbox value
            Parms(4) = New SqlParameter("@StockCode", DBNull.Value)
        End If
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STInternalTransferOutStockDetailsGet]", Parms)
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
        End If
        Return dt
    End Function

    Public Function STITNOutRecLocGet(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(2) As SqlParameter

        If objITNOutPPT.ReceivedLocation <> String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", objITNOutPPT.ReceivedLocation) 'searching in sender location text leave.
            Parms(2) = New SqlParameter("@SenderLocationSearch", DBNull.Value) 'lookup search
        ElseIf objITNOutPPT.ReceivedLocationSearch = String.Empty Then
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", DBNull.Value)
            Parms(2) = New SqlParameter("@SenderLocationSearch", DBNull.Value)
        Else
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@SenderLocation", DBNull.Value)
            Parms(2) = New SqlParameter("@SenderLocationSearch", objITNOutPPT.ReceivedLocationSearch)
        End If
        dt = objdb.ExecQuery("[Store].[STInternalTransferInSendLocGet]", Parms).Tables(0)
        Return dt
    End Function

    Public Function AcctlookupSearch(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@Accountcode", objITNOutPPT.COACode)
        Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", "YES")
        dt = objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Save_STInternalTransferOut(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim dt As New DataTable
        Dim objdb As New SQLHelp
        Dim Parms(16) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ItnOutNo", objITNOutPPT.ItnOutNo)
        Parms(3) = New SqlParameter("@ITNDate", objITNOutPPT.ITNDate)
        Parms(4) = New SqlParameter("@Remarks", objITNOutPPT.Remarks)
        Parms(5) = New SqlParameter("@ReceiverLocationID", objITNOutPPT.ReceivedLocation)
        Parms(6) = New SqlParameter("@Status", objITNOutPPT.Status)
        Parms(7) = New SqlParameter("@RejectedReason", IIf(objITNOutPPT.RejectedReason <> String.Empty, objITNOutPPT.RejectedReason, DBNull.Value))
        Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today)

        Parms(13) = New SqlParameter("@OperatorName", objITNOutPPT.OperatorName)
        Parms(14) = New SqlParameter("@TransportDate", objITNOutPPT.TransportDate)
        Parms(15) = New SqlParameter("@VehicleNo", objITNOutPPT.VehicleNo)
        Parms(16) = New SqlParameter("@MRCNo", objITNOutPPT.MRCNo)

        dt = objdb.ExecQuery("[Store].[STInternalTransferOutInsert]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Update_STInternalTransferOut(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferOutID", objITNOutPPT.STInternalTransferOutID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@ItnOutNo", objITNOutPPT.ItnOutNo)
            Parms(4) = New SqlParameter("@ITNDate", objITNOutPPT.ITNDate)
            Parms(5) = New SqlParameter("@Remarks", objITNOutPPT.Remarks)
            Parms(6) = New SqlParameter("@ReceiverLocationID", objITNOutPPT.ReceivedLocation)
            Parms(7) = New SqlParameter("@Status", objITNOutPPT.Status)
            Parms(8) = New SqlParameter("@RejectedReason", objITNOutPPT.RejectedReason)
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferOutUpdate]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Save_STITNOutDetailsInsert(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferOutID", objITNOutPPT.STInternalTransferOutID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@StockID", objITNOutPPT.StockID)
            Parms(4) = New SqlParameter("@PartNo", objITNOutPPT.PartNo)
            Parms(5) = New SqlParameter("@AvailQty", objITNOutPPT.AvailQty)
            Parms(6) = New SqlParameter("@UnitPrice", objITNOutPPT.UnitPrice)
            Parms(7) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(8) = New SqlParameter("@COAID", objITNOutPPT.COAID)
            Parms(9) = New SqlParameter("@TransferOutQty", objITNOutPPT.TransferOutQty)
            Parms(10) = New SqlParameter("@TransferOutValue", objITNOutPPT.TransferOutValue)
            Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(12) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(14) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferOutDetailsInsert]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function Update_STITNOutDetails(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferOutID", objITNOutPPT.STInternalTransferOutID)
            Parms(1) = New SqlParameter("@STInternalTransferOutDetailsID", objITNOutPPT.STInternalTransferOutDetailsID)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(4) = New SqlParameter("@StockID", objITNOutPPT.StockID)
            Parms(5) = New SqlParameter("@PartNo", objITNOutPPT.PartNo)
            Parms(6) = New SqlParameter("@AvailQty", objITNOutPPT.AvailQty)
            Parms(7) = New SqlParameter("@UnitPrice", objITNOutPPT.UnitPrice)
            Parms(8) = New SqlParameter("@COAID", objITNOutPPT.COAID)
            Parms(9) = New SqlParameter("@TransferOutQty", objITNOutPPT.TransferOutQty)
            Parms(10) = New SqlParameter("@TransferOutValue", objITNOutPPT.TransferOutValue)
            Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(12) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferOutDetailsUpdate]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function STInternalTransferOutSelect(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ITNDate", IIf(objITNOutPPT.ITNDate <> Nothing, objITNOutPPT.ITNDate, DBNull.Value))
        Parms(3) = New SqlParameter("@ItnOutNo", IIf(objITNOutPPT.ItnOutNo <> String.Empty, objITNOutPPT.ItnOutNo, DBNull.Value))
        Parms(4) = New SqlParameter("@Status", IIf(objITNOutPPT.Status <> String.Empty, objITNOutPPT.Status, DBNull.Value))
        Parms(5) = New SqlParameter("@ReceiverLocation", IIf(objITNOutPPT.ReceivedLocation <> String.Empty, objITNOutPPT.ReceivedLocation, DBNull.Value))

        dt = objdb.ExecQuery("[Store].[STInternalTransferOutSelect_N]", Parms).Tables(0)
        Return dt
    End Function

    Public Function ITNOutDetails_Select(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STInternalTransferOutID", objITNOutPPT.STInternalTransferOutID)

        dt = objdb.ExecQuery("[Store].[STInternalTransferOutDetailsSelect_N]", Parms).Tables(0)
        Return dt
    End Function

    Public Function Delete_STInternalTransferOut(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer

        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STInternalTransferOutID", objITNOutPPT.STInternalTransferOutID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())

            objdb.ExecNonQuery("[Store].[STInternalTransferOutDelete]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Function Update_STInternalTransferOutApproval(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STInternalTransferOutID", objITNOutPPT.STInternalTransferOutID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@Status", objITNOutPPT.Status)
            Parms(4) = New SqlParameter("@RejectedReason", objITNOutPPT.RejectedReason)
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STInternalTransferOutApproval]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function ITNOut_Averageprice(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(6) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@ID", objITNOutPPT.STInternalTransferOutID)
        params(3) = New SqlParameter("@StockId", objITNOutPPT.StockID)
        params(4) = New SqlParameter("@Qty", objITNOutPPT.TransferOutQty)
        params(5) = New SqlParameter("@Value", objITNOutPPT.TransferOutValue)
        params(6) = New SqlParameter("@TransType", "ITNOUT")
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailAvgPriceApproval_Raja]", params)
        If Not ds Is Nothing Then
            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If
        End If
        Return dt
    End Function

    Public Function Save_LedgerAllModule(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
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
        Parms(7) = New SqlParameter("@LedgerDate", objITNOutPPT.ITNDate)
        Parms(8) = New SqlParameter("@LedgerType", "STORE-ITNOUT")
        Parms(9) = New SqlParameter("@Descp", objITNOutPPT.Remarks)
        Parms(10) = New SqlParameter("@BatchAmount", objITNOutPPT.TransferOutValue)
        Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(14) = New SqlParameter("@ModifiedOn", Date.Today)

        dt = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms).Tables(0)

        Return dt
    End Function

    Public Function Update_LedgerAllModule(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim rowaffected As Integer
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@LedgerID", objITNOutPPT.LedgerID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@DC", "D")
            Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@CreatedOn", Date.Today)
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecQuery("[Accounts].[LedgerAllModuleUpdate_N]", Parms)
            rowaffected = 1
        Catch ex As Exception
            rowaffected = 0
        End Try
        Return rowaffected
    End Function

    Public Function ITNOut_StockDetailGet(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable
        params(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@StockId", objITNOutPPT.StockID)

        dt = objdb.ExecQuery("[Store].[STInternalTransferInStockDetailsGet]", params).Tables(0)
        Return dt
    End Function

    Public Function AC_JournalDetailInsert(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Integer
        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim Parms(24) As SqlParameter
        Try

            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
            Parms(2) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
            Parms(3) = New SqlParameter("@LedgerID", objITNOutPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objITNOutPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objITNOutPPT.DC)
            Parms(6) = New SqlParameter("@Value", objITNOutPPT.value)
            Parms(7) = New SqlParameter("@DivID", IIf(objITNOutPPT.DivID <> String.Empty, objITNOutPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objITNOutPPT.YopID <> String.Empty, objITNOutPPT.YopID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objITNOutPPT.BlockID <> String.Empty, objITNOutPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objITNOutPPT.VHID <> String.Empty, objITNOutPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objITNOutPPT.VHDetailCostCodeID <> String.Empty, objITNOutPPT.VHDetailCostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objITNOutPPT.T0 <> String.Empty, objITNOutPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objITNOutPPT.T1 <> String.Empty, objITNOutPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objITNOutPPT.T2 <> String.Empty, objITNOutPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objITNOutPPT.T3 <> String.Empty, objITNOutPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objITNOutPPT.T4 <> String.Empty, objITNOutPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objITNOutPPT.JournalDetDescp <> String.Empty, objITNOutPPT.JournalDetDescp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objITNOutPPT.Flag <> String.Empty, objITNOutPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objITNOutPPT.StationID <> String.Empty, objITNOutPPT.StationID, DBNull.Value))

            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            rowsAffected = 1
        Catch e As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected
    End Function

    Public Function ITNOutRecordIsExist(ByVal objITNOutPPT As InternalTransferNoteOUTPPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STInternalTransferOutRecordIsExist]", Parms)
        Return objExists
    End Function


    Public Function STInternalTransferOutDetailSelect(ByVal objInternalTransferNoteOUTPPT As InternalTransferNoteOUTPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@StockId", objInternalTransferNoteOUTPPT.StockID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@STInternalTransferOutDetailsID", objInternalTransferNoteOUTPPT.STInternalTransferOutDetailsID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STInternalTransferOutDetailSelect]", Parms)
        Return ds

    End Function

    Public Function STInternalTransferOutDetailsDelete(ByVal objITNOUT As InternalTransferNoteOUTPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intITNINRowsAffected As Integer = 0

        Try

            Dim Parms(1) As SqlParameter

            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@STInternalTransferOutDetailsID", objITNOUT.STInternalTransferOutDetailsID)

            objdb.ExecNonQuery("[Store].[STInternalTransferOutDetailsDelete]", Parms)
            intITNINRowsAffected = 1
        Catch ex As Exception
            intITNINRowsAffected = 0
        End Try
        Return intITNINRowsAffected


    End Function


    Public Shared Function STInternalTransferOutDetailsTransferOutQtyCheck(ByVal StockID As String, ByVal RequestedTransferOutQty As Double) As Double

        Dim objdb As New SQLHelp
        Dim TransferOutQty As Integer = 0



        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", StockID)
        Parms(3) = New SqlParameter("@RequestedTransferOutQty", RequestedTransferOutQty)

        TransferOutQty = objdb.ExecuteScalar("[Store].[STInternalTransferOutDetailsTransferOutQtyCheck]", Parms)

        Return TransferOutQty

    End Function


End Class

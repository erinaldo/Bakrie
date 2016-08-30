Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class ReturnGoodsNoteDAL

    Public Shared Function GetRGNNo(ByVal objRGNPPT As ReturnGoodsNotePPT) As String
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim strRGNNo As String = String.Empty
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[STRGNNoGet]", Parms)
        If ds.Tables(0).Rows.Count > 0 Then
            strRGNNo = ds.Tables(0).Rows(0).Item("NewRGNNo")
        End If

        Return strRGNNo

    End Function


    Public Shared Function GetRGSAutoNo() As String
        Dim obj As New SQLHelp
        Dim ds As New DataSet
        Dim param() As SqlParameter
        ds = obj.ExecQuery("[Store].[RTSAutoNo]", param)
        For Each dr As DataRow In ds.Tables(0).Rows
            Return dr("RGSNo").ToString()
        Next
    End Function

    Public Shared Function RGNSIVGet(ByVal objRGNPPT As ReturnGoodsNotePPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter

        If objRGNPPT.SIVNO <> String.Empty Then
            Parms(0) = New SqlParameter("@SIVNO", objRGNPPT.SIVNO)
        Else
            Parms(0) = New SqlParameter("@SIVNO", DBNull.Value)
        End If
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID) '@ActiveMonthYearID
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)

        Return objdb.ExecQuery("[Store].[STRGNSIVGet]", Parms)

    End Function

    Public Shared Function RGNStockDetailsGet(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(5) As SqlParameter

        If objRGNPPT.STIssueID <> "" Then
            Parms(0) = New SqlParameter("@STIssueId", objRGNPPT.STIssueID)
        Else
            Parms(0) = New SqlParameter("@STIssueId", String.Empty)
        End If
        If objRGNPPT.StockCode <> "" Then
            Parms(1) = New SqlParameter("@StockCode", objRGNPPT.StockCode)
        Else
            Parms(1) = New SqlParameter("@StockCode", String.Empty)
        End If
        If objRGNPPT.StockDesc <> "" Then
            Parms(2) = New SqlParameter("@StockDesc", objRGNPPT.StockDesc)
        Else
            Parms(2) = New SqlParameter("@StockDesc", String.Empty)
        End If
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        If objRGNPPT.PartNo <> "" Then
            Parms(5) = New SqlParameter("@PartNo", objRGNPPT.PartNo)
        Else
            Parms(5) = New SqlParameter("@PartNo", String.Empty)
        End If

        Return objdb.ExecQuery("[Store].[STRGNStockDetailsGet]", Parms)

    End Function

    Public Shared Function STReturnGoodsNoteInsert(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(12) As SqlParameter
        If objRGNPPT.STIssueID <> "" Then
            Parms(0) = New SqlParameter("@STIssueId", objRGNPPT.STIssueID)
        Else
            Parms(0) = New SqlParameter("@STIssueId", String.Empty)
        End If
        Parms(1) = New SqlParameter("@ActiveMonthyearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@RGNDate", objRGNPPT.RGNDate)
        Parms(3) = New SqlParameter("@RGNNo", objRGNPPT.RGNNo)
        Parms(4) = New SqlParameter("@Status", objRGNPPT.Status)

        If objRGNPPT.RejectedStatus <> String.Empty Then
            Parms(5) = New SqlParameter("@RejectedStatus", objRGNPPT.RejectedStatus)
        Else
            Parms(5) = New SqlParameter("@RejectedStatus", DBNull.Value)
        End If
        If objRGNPPT.Remarks <> String.Empty Then
            Parms(6) = New SqlParameter("@Remarks", objRGNPPT.Remarks)
        Else
            Parms(6) = New SqlParameter("@Remarks", DBNull.Value)
        End If

        Parms(7) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(12) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        ds = objdb.ExecQuery("[Store].[STReturnGoodsNoteInsert]", Parms)

        Return ds

    End Function

    Public Shared Function STReturnGoodsDetailsInsert(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@STReturnGoodsNoteID", objRGNPPT.STReturnGoodsNoteID)
        Parms(1) = New SqlParameter("@ActiveMonthyearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", objRGNPPT.StockID)
        Parms(3) = New SqlParameter("@Unit", objRGNPPT.Unit)
        Parms(4) = New SqlParameter("@IssueQty", objRGNPPT.IssueQty)
        Parms(5) = New SqlParameter("@IssueValue", objRGNPPT.IssueValue)
        'Parms(5) = New SqlParameter("@IssueValue", 1)
        Parms(6) = New SqlParameter("@ReturnQty", objRGNPPT.ReturnQty)
        'Parms(7) = New SqlParameter("@ReturnedValue", objRGNPPT.ReturnedValue)
        Parms(7) = New SqlParameter("@ReturnedValue", 1)
        Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(13) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(14) = New SqlParameter("@STIssueDetailsID", objRGNPPT.STIssueDetailsID)

        Return objdb.ExecQuery("[Store].[STReturnGoodsDetailsInsert]", Parms)

    End Function

    Public Shared Function STReturnGoodsNoteUpdate(ByVal objRGNPPT As ReturnGoodsNotePPT, ByVal IsStatusFromApproval As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(11) As SqlParameter
        If objRGNPPT.STIssueID <> "" Then
            Parms(0) = New SqlParameter("@STIssueId", objRGNPPT.STIssueID)
        Else
            Parms(0) = New SqlParameter("@STIssueId", String.Empty)
        End If
        Parms(1) = New SqlParameter("@ActiveMonthyearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@RGNDate", objRGNPPT.RGNDate)
        Parms(3) = New SqlParameter("@RGNNo", objRGNPPT.RGNNo)
        If objRGNPPT.Status <> String.Empty Then
            Parms(4) = New SqlParameter("@Status", objRGNPPT.Status)
        Else
            Parms(4) = New SqlParameter("@Status", DBNull.Value)
        End If
        If objRGNPPT.RejectedStatus <> String.Empty Then
            Parms(5) = New SqlParameter("@RejectedStatus", objRGNPPT.RejectedStatus)
        Else
            Parms(5) = New SqlParameter("@RejectedStatus", DBNull.Value)
        End If
        If objRGNPPT.Remarks <> String.Empty Then
            Parms(6) = New SqlParameter("@Remarks", objRGNPPT.Remarks)
        Else
            Parms(6) = New SqlParameter("@Remarks", DBNull.Value)
        End If
        Parms(7) = New SqlParameter("@STReturnGoodsNoteID", objRGNPPT.STReturnGoodsNoteID)
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(11) = New SqlParameter("@IsStatusFromApproval", IsStatusFromApproval)

        Return objdb.ExecQuery("[Store].[STReturnGoodsNoteUpdate]", Parms)

    End Function

    Public Shared Function STReturnGoodsDetailsUpdate(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@STReturnGoodsNoteID", objRGNPPT.STReturnGoodsNoteID)
        Parms(1) = New SqlParameter("@ActiveMonthyearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", objRGNPPT.StockID)
        Parms(3) = New SqlParameter("@Unit", objRGNPPT.Unit)
        Parms(4) = New SqlParameter("@IssueQty", objRGNPPT.IssueQty)
        Parms(5) = New SqlParameter("@IssueValue", objRGNPPT.IssueValue)
        'Parms(5) = New SqlParameter("@IssueValue", 1)
        Parms(6) = New SqlParameter("@ReturnQty", objRGNPPT.ReturnQty)
        'Parms(7) = New SqlParameter("@ReturnedValue", objRGNPPT.ReturnedValue)
        Parms(7) = New SqlParameter("@ReturnedValue", 1)
        Parms(8) = New SqlParameter("@STReturnGoodsDetailsID", objRGNPPT.STReturnGoodsDetailsID)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(12) = New SqlParameter("@STIssueDetailsID", objRGNPPT.STIssueDetailsID)

        Return objdb.ExecQuery("[Store].[STReturnGoodsDetailsUpdate]", Parms)

    End Function

    Public Shared Function STRGNSearch(ByVal objRGN As ReturnGoodsNotePPT, ByVal IsApproval As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@SIVNO", IIf(objRGN.SIVNO <> String.Empty, objRGN.SIVNO, DBNull.Value))
        Parms(1) = New SqlParameter("@RGNNo", IIf(objRGN.RGNNo <> String.Empty, objRGN.RGNNo, DBNull.Value))
        If objRGN.RGNDateIsChecked = True Then
            Parms(2) = New SqlParameter("@RGNDate", objRGN.RGNDate)
        Else
            Parms(2) = New SqlParameter("@RGNDate", DBNull.Value)
        End If
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If objRGN.Status = "SELECT ALL" Then
            Parms(4) = New SqlParameter("@Status", System.DBNull.Value)
        ElseIf objRGN.Status = "" Then
            Parms(4) = New SqlParameter("@Status", "OPEN")
        Else
            Parms(4) = New SqlParameter("@Status", objRGN.Status)
        End If
        Parms(5) = New SqlParameter("@IsApproval", IsApproval)
        Parms(6) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Store].[STRGNSearch]", Parms)

        Return ds

    End Function

    Public Shared Function STRGNDetailsGet(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        If objRGNPPT.STReturnGoodsNoteID <> "" Then
            Parms(0) = New SqlParameter("@STReturnGoodsNoteID", objRGNPPT.STReturnGoodsNoteID)
        Else
            Parms(0) = New SqlParameter("@STReturnGoodsNoteID", String.Empty)
        End If
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Store].[STRGNDetailsGet]", Parms)

    End Function

    Public Shared Function STRGNDelete(ByVal objRGN As ReturnGoodsNotePPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@STReturnGoodsNoteID", objRGN.STReturnGoodsNoteID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Store].[STRGNDelete]", Parms)

        Return ds

    End Function

    Public Shared Function STStockDetailAvgPriceApproval(ByVal objRGN As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@StockId", objRGN.StockID)
        Parms(3) = New SqlParameter("@ID", objRGN.STReturnGoodsNoteID)
        Parms(4) = New SqlParameter("@Qty", objRGN.ReturnQty)
        Parms(5) = New SqlParameter("@Value", 0) '
        Parms(6) = New SqlParameter("@TransType", "RGN")
        Parms(7) = New SqlParameter("@ReceivedPrice", 0) 'pass this value in emdn approval only
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailAvgPriceApproval]", Parms)

        Return ds

    End Function

    Public Shared Function STRGNLedgerAllModuleInsert(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objRGNApprovalPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objRGNApprovalPPT.AMonth)
        Parms(5) = New SqlParameter("@ModName", "STORE")
        Parms(6) = New SqlParameter("@LedgerDate", objRGNApprovalPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objRGNApprovalPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", IIf(objRGNApprovalPPT.Descp <> String.Empty, objRGNApprovalPPT.Descp, DBNull.Value))
        Parms(9) = New SqlParameter("@BatchAmount", DBNull.Value)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet

        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms)

        Return ds

    End Function

    Public Shared Function STRGNLedgerAllModuleUpdate(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Dim intLedgerAllModuleRowsAffected As Integer = 0
        Try
            Parms(0) = New SqlParameter("@LedgerID", objRGNApprovalPPT.LedgerID)
            Parms(1) = New SqlParameter("@DC", objRGNApprovalPPT.DC)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", Date.Today())
            objdb.ExecNonQuery("[Accounts].[LedgerAllModuleUpdate_N]", Parms)
            intLedgerAllModuleRowsAffected = 1
        Catch ex As Exception
            intLedgerAllModuleRowsAffected = 0
        End Try
        Return intLedgerAllModuleRowsAffected

    End Function

    Public Shared Function STRGNJournalDetailInsert(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(24) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objRGNApprovalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objRGNApprovalPPT.AMonth)
            Parms(3) = New SqlParameter("@LedgerID", objRGNApprovalPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objRGNApprovalPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objRGNApprovalPPT.DC)
            Parms(6) = New SqlParameter("@Value", objRGNApprovalPPT.Value)
            Parms(7) = New SqlParameter("@DivID", IIf(objRGNApprovalPPT.DivID <> String.Empty, objRGNApprovalPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objRGNApprovalPPT.YopID <> String.Empty, objRGNApprovalPPT.YopID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objRGNApprovalPPT.BlockID <> String.Empty, objRGNApprovalPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objRGNApprovalPPT.VHID <> String.Empty, objRGNApprovalPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objRGNApprovalPPT.VHDetailCostCodeID <> String.Empty, objRGNApprovalPPT.VHDetailCostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objRGNApprovalPPT.T0 <> String.Empty, objRGNApprovalPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objRGNApprovalPPT.T1 <> String.Empty, objRGNApprovalPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objRGNApprovalPPT.T2 <> String.Empty, objRGNApprovalPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objRGNApprovalPPT.T3 <> String.Empty, objRGNApprovalPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objRGNApprovalPPT.T4 <> String.Empty, objRGNApprovalPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objRGNApprovalPPT.Descp <> String.Empty, objRGNApprovalPPT.Descp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objRGNApprovalPPT.Flag <> String.Empty, objRGNApprovalPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objRGNApprovalPPT.StationID <> String.Empty, objRGNApprovalPPT.StationID, DBNull.Value))
            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected

    End Function

    Public Shared Function STRGNStockIDDetailSelect(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@StockId", objRGNPPT.StockID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@STReturnGoodsDetailsID", objRGNPPT.STReturnGoodsDetailsID)
        Parms(4) = New SqlParameter("@ReturnQty", objRGNPPT.ReturnQty)
        Dim ds As New DataSet

        ds = objdb.ExecQuery("[Store].[STRGNStockIDDetailSelect]", Parms)

        Return ds

    End Function

    Public Shared Function STIssueDetailsReturnQtyUpdate(ByVal objRGNPPT As ReturnGoodsNotePPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim intSTIssueDetailsRowsAffected As Integer = 0

        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@StockID", objRGNPPT.StockID)
            Parms(2) = New SqlParameter("@ReturnQty", objRGNPPT.ReturnQty)
            Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            'Parms(4) = New SqlParameter("@STIssueID", objRGNPPT.STIssueID)
            Parms(4) = New SqlParameter("@STIssueDetailsID", objRGNPPT.STIssueDetailsID)

            objdb.ExecNonQuery("[Store].[STIssueDetailsReturnQtyUpdate]", Parms)
            intSTIssueDetailsRowsAffected = 1

        Catch ex As Exception
            intSTIssueDetailsRowsAffected = 0
        End Try

        Return intSTIssueDetailsRowsAffected

    End Function

    Public Function RGNRecordIsExist(ByVal objRGNPPT As ReturnGoodsNotePPT) As Object
        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STRGNIsExist]", Parms)
        Return objExists
    End Function

    

    Public Shared Function STRGNOtherDetailsGet(ByVal objRGNPPT As ReturnGoodsNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim ds As New DataSet


        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@StockID", objRGNPPT.StockID)
        Parms(2) = New SqlParameter("@ReturnQty", objRGNPPT.ReturnQty)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@STIssueID", objRGNPPT.STIssueID)

        ds = objdb.ExecQuery("[Store].[STRGNOtherDetailsGet]", Parms)
        Return ds

    End Function

    Public Shared Function VHChargeDetailInsert(ByVal objRGNApprovalPPT As ReturnGoodsNoteApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(18) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateCodeL", objRGNApprovalPPT.EstateCodeL)
            Parms(1) = New SqlParameter("@VHWSCode", objRGNApprovalPPT.VHWSCode)
            Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(3) = New SqlParameter("@VHDetailCostCode", objRGNApprovalPPT.VHDetailCostCode)
            Parms(4) = New SqlParameter("@Type", objRGNApprovalPPT.Type)
            Parms(5) = New SqlParameter("@ModName", "Store")
            Parms(6) = New SqlParameter("@AYear", objRGNApprovalPPT.AYear)
            Parms(7) = New SqlParameter("@AMonth", objRGNApprovalPPT.AMonth)
            Parms(8) = New SqlParameter("@Value", -(objRGNApprovalPPT.Value))
            Parms(9) = New SqlParameter("@JDescp", objRGNApprovalPPT.Descp)
            Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(14) = New SqlParameter("@LedgerNo", objRGNApprovalPPT.LedgerNo)
            Parms(15) = New SqlParameter("@LedgerType", objRGNApprovalPPT.LedgerType)
            Parms(16) = New SqlParameter("@UOMID", objRGNApprovalPPT.UOMID)
            Parms(17) = New SqlParameter("@QtyUsed", objRGNApprovalPPT.Qty)
            Parms(18) = New SqlParameter("@RefNo", objRGNApprovalPPT.RefNo)
            objdb.ExecNonQuery("[Vehicle].[VHChargeDetailInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected

    End Function

    'Public Shared Function STRGNDetailDelete(ByVal objRGN As ReturnGoodsNotePPT) As DataSet

    '    Dim objdb As New SQLHelp
    '    Dim intRGNRowsAffected As Integer = 0
    '    Dim ds As New DataSet


    '    Dim Parms(5) As SqlParameter
    '    Parms(0) = New SqlParameter("@STReturnGoodsNoteID", objRGN.STReturnGoodsNoteID)
    '    Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    '    Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    '    Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())
    '    Parms(5) = New SqlParameter("@STReturnGoodsDetailsID", objRGN.STReturnGoodsDetailsID)

    '    ds = objdb.ExecQuery("[Store].[STRGNDetailDelete]", Parms)
    '    Return ds

    'End Function


    Public Shared Function STRGNDetailDelete(ByVal objRGN As ReturnGoodsNotePPT) As Integer

        Dim objdb As New SQLHelp
        Dim intRGNRowsAffected As Integer = 0

        Try

            Dim Parms(5) As SqlParameter
            Parms(0) = New SqlParameter("@STReturnGoodsNoteID", objRGN.STReturnGoodsNoteID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(5) = New SqlParameter("@STReturnGoodsDetailsID", objRGN.STReturnGoodsDetailsID)

            objdb.ExecNonQuery("[Store].[STRGNDetailDelete]", Parms)
            intRGNRowsAffected = 1
        Catch ex As Exception
            intRGNRowsAffected = 0
        End Try
        Return intRGNRowsAffected


    End Function




End Class



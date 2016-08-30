Imports Store_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class EstateMillDeliverNoteApprovalDAL

    Public Shared Function STMillDeliveryUpdateApproval(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer

        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STEstMillDeliveryID", objEMDNPPT.STEstMillDeliveryID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            'Parms(3) = New SqlParameter("@LPOorIPR", IIf(objEMDNPPT.IPRNo <> "", objEMDNPPT.IPRNo, objEMDNPPT.LPONo))
            'Parms(4) = New SqlParameter("@IDNNo", objEMDNPPT.IDNNO)
            'Parms(5) = New SqlParameter("@IDNDate", objEMDNPPT.IDNDate)
            'Parms(6) = New SqlParameter("@GRNNo", objEMDNPPT.GRNNo)
            'Parms(7) = New SqlParameter("@PONo", objEMDNPPT.PONo)
            'Parms(8) = New SqlParameter("@STLPOID", IIf(objEMDNPPT.STLPOID <> "", objEMDNPPT.LPONo, DBNull.Value)) 'objEMDNPPT.STLPOID)
            'Parms(9) = New SqlParameter("@STIPRID", IIf(objEMDNPPT.STIPRID <> "", objEMDNPPT.STIPRID, DBNull.Value))
            'Parms(10) = New SqlParameter("@DeliverySource", objEMDNPPT.DeliverySource)
            'Parms(11) = New SqlParameter("@Remarks", objEMDNPPT.Remarks)
            'Parms(12) = New SqlParameter("@SupplierID", objEMDNPPT.SupplierID)
            Parms(3) = New SqlParameter("@Status", objEMDNPPT.Status)
            Parms(4) = New SqlParameter("@RejectedReason", IIf(objEMDNPPT.RejectedReason <> "", objEMDNPPT.RejectedReason, DBNull.Value))
            'Parms(15) = New SqlParameter("@OperatorName", objEMDNPPT.OperatorName)
            'Parms(16) = New SqlParameter("@TransportDate", objEMDNPPT.TransportDate)
            'Parms(17) = New SqlParameter("@VehicleNo", objEMDNPPT.VehicleNo)
            Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)

            objdb.ExecNonQuery("[Store].[STMillDeliveryUpdateApproval]", Parms)

            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Shared Function STIPRDetailUpdateForEMDNApproval_Old(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@StockID", objEMDNPPT.StockID)
        Parms(1) = New SqlParameter("@STIPRDetID", IIf(objEMDNPPT.STIPRDetID <> "", objEMDNPPT.STIPRDetID, DBNull.Value))
        Parms(2) = New SqlParameter("@STEstMillDeliveryDetID", objEMDNPPT.STEstMillDeliveryDetID)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)
        ds = objdb.ExecQuery("[Store].[STIPRDetailUpdateForEMDNApproval_Old]", Parms)
        Return ds

    End Function

    Public Shared Function STIPRUpdateForEMDNApproval(ByVal objIPRPPT As InternalPurchaseRequisitionApprovalPPT) As Integer

        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@MainStatus", objIPRPPT.MainStatus)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STIPRID", IIf(objIPRPPT.STIPRID <> "", objIPRPPT.STIPRID, DBNull.Value))
            Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today)
            objdb.ExecNonQuery("[Store].[STIPRUpdateForEMDNApproval]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Shared Function STStockDetailAvgPriceApproval(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@StockId", objEMDN.StockID)
        Parms(3) = New SqlParameter("@ID", objEMDN.STEstMillDeliveryID)
        Parms(4) = New SqlParameter("@Qty", objEMDN.ReceivedQty)
        Parms(5) = New SqlParameter("@Value", objEMDN.TotalPrice)
        Parms(6) = New SqlParameter("@TransType", "IDN") '
        Parms(7) = New SqlParameter("@ReceivedPrice", objEMDN.ReceivedPrice)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailAvgPriceApproval]", Parms)
        Return ds

    End Function

    Public Shared Function STIDNLedgerAllModuleInsert(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objEMDNApprovalPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objEMDNApprovalPPT.AMonth)
        Parms(5) = New SqlParameter("@ModName", "STORE")
        Parms(6) = New SqlParameter("@LedgerDate", objEMDNApprovalPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objEMDNApprovalPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", IIf(objEMDNApprovalPPT.Descp <> String.Empty, objEMDNApprovalPPT.Descp, DBNull.Value))
        Parms(9) = New SqlParameter("@BatchAmount", DBNull.Value)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms)
        Return ds

    End Function


    Public Shared Function STIDNLedgerAllModuleUpdate(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Dim intLedgerAllModuleRowsAffected As Integer = 0
        Try
            Parms(0) = New SqlParameter("@LedgerID", objEMDNApprovalPPT.LedgerID)
            Parms(1) = New SqlParameter("@DC", objEMDNApprovalPPT.DC)
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

    Public Shared Function STIDNJournalDetailInsert(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(24) As SqlParameter
        Dim intjournalRowsAffected As Integer
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objEMDNApprovalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objEMDNApprovalPPT.AMonth)
            Parms(3) = New SqlParameter("@LedgerID", objEMDNApprovalPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objEMDNApprovalPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objEMDNApprovalPPT.DC)
            Parms(6) = New SqlParameter("@Value", objEMDNApprovalPPT.Value)
            Parms(7) = New SqlParameter("@DivID", IIf(objEMDNApprovalPPT.DivID <> String.Empty, objEMDNApprovalPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objEMDNApprovalPPT.YopID <> String.Empty, objEMDNApprovalPPT.YopID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objEMDNApprovalPPT.BlockID <> String.Empty, objEMDNApprovalPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objEMDNApprovalPPT.VHID <> String.Empty, objEMDNApprovalPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objEMDNApprovalPPT.VHDetailCostCodeID <> String.Empty, objEMDNApprovalPPT.VHDetailCostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objEMDNApprovalPPT.T0 <> String.Empty, objEMDNApprovalPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objEMDNApprovalPPT.T1 <> String.Empty, objEMDNApprovalPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objEMDNApprovalPPT.T2 <> String.Empty, objEMDNApprovalPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objEMDNApprovalPPT.T3 <> String.Empty, objEMDNApprovalPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objEMDNApprovalPPT.T4 <> String.Empty, objEMDNApprovalPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objEMDNApprovalPPT.Descp <> String.Empty, objEMDNApprovalPPT.Descp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objEMDNApprovalPPT.Flag <> String.Empty, objEMDNApprovalPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objEMDNApprovalPPT.StationID <> String.Empty, objEMDNApprovalPPT.StationID, DBNull.Value))
            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected

    End Function

    Public Shared Function STIDNStockIDDetailSelect(ByVal objEMDNApprovalPPT As EstMillDeliveryNoteApprovalPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@StockId", objEMDNApprovalPPT.StockId)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@STEstMillDeliveryDetID", objEMDNApprovalPPT.STEstMillDeliveryDetID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIDNStockIDDetailSelect]", Parms)
        Return ds

    End Function

    Public Shared Function STLPODetailUpdateForEMDNApproval(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer

        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STLPOID", objEMDNPPT.STLPOID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STEstMillDeliveryID", IIf(objEMDNPPT.STEstMillDeliveryID <> "", objEMDNPPT.STEstMillDeliveryID, DBNull.Value))
            Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today)
            objdb.ExecNonQuery("[Store].[STLPODetailUpdateForEMDNApproval]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Shared Function STIPRDetailUpdateForEMDNApproval(ByVal objEMDNPPT As EstateMillDeliveryNotePPT) As Integer

        Dim rowsAffected As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(5) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@STIPRID", objEMDNPPT.STIPRID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STEstMillDeliveryID", IIf(objEMDNPPT.STEstMillDeliveryID <> "", objEMDNPPT.STEstMillDeliveryID, DBNull.Value))
            Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today)
            objdb.ExecNonQuery("[Store].[STIPRDetailUpdateForEMDNApproval]", Parms)
            rowsAffected = 1
        Catch ex As Exception
            rowsAffected = 0
        End Try
        Return rowsAffected

    End Function

    Public Shared Function StockDetailConsignmentUpdateforEMDNApproval(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@StockId", objEMDN.StockCode) 'Stock Code
        Parms(3) = New SqlParameter("@ID", objEMDN.STEstMillDeliveryID)
        Parms(4) = New SqlParameter("@Qty", objEMDN.ReceivedQty)
        Parms(5) = New SqlParameter("@Value", objEMDN.TotalPrice)
        Parms(6) = New SqlParameter("@TransType", "IDN") '
        Parms(7) = New SqlParameter("@ReceivedPrice", objEMDN.ReceivedPrice)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[StockDetailConsignmentUpdateforEMDNApproval]", Parms)
        Return ds

    End Function

    Public Shared Function StockDetailConsignmentAvailCheck(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@STEstMillDeliveryID", objEMDN.STEstMillDeliveryID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[StockDetailConsignmentAvailCheck]", Parms)
        Return ds

    End Function

    Public Shared Function StockDetailConsignmentQtyCheck(ByVal objEMDN As EstateMillDeliveryNotePPT) As Integer

        Dim BalQty As Integer = 0
        Dim objdb As New SQLHelp
        Dim dt As New DataTable

        Dim Parms(2) As SqlParameter



        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@StockCode", objEMDN.StockCode) 'Stock Code
        ''Parms(2) = New SqlParameter("@StockId", objEMDN.StockID) 'Stock ID
        ''Parms(3) = New SqlParameter("@Qty", objEMDN.ReceivedQty)

        BalQty = objdb.ExecuteScalar("[Store].[StockDetailConsignmentQtyCheck]", Parms)
        Return BalQty

    End Function

    Public Shared Function LPOSupplierNameGet(ByVal objEMDN As EstateMillDeliveryNotePPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@LPONo", objEMDN.LPONo)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STLPOSupplierNameGet]", Parms)
        Return ds

    End Function

    Public Shared Function IDNLPOT0Select() As DataTable

        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Store].[IDNLPOT0Select]", Parms).Tables(0)
        Return dt
    End Function

End Class


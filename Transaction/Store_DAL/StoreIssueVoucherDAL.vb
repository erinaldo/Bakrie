Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class StoreIssueVoucherDAL

    'Public Shared Function fillIssueBtachTotal(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As Object
    '    Dim objdb As New SQLHelp
    '    Dim Parms(1) As SqlParameter
    '    Parms(0) = New SqlParameter("@SIVNo", objStoreIssueVoucher.SIVNO)
    '    Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    '    Return objdb.ExecuteScalar("[Store].[STIssueVoucherBatchTotalSelect]", Parms)
    'End Function

    Public Shared Function fillIssueBatchTotalDs(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@SIVNo", objStoreIssueVoucher.SIVNO)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Store].[STIssueVoucherBatchTotalSelect]", Parms)

    End Function

    Public Shared Function fillCategoryDesc(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@STCategoryID", objStoreIssueVoucher.STCategoryID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[STCategoryDescpSelect]", Parms)
        Return ds

    End Function

    Public Shared Function fillSIVNo() As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Store].[STIssueVoucherSIVNoFill]", Parms)

    End Function

    Public Shared Function saveStoreIssueVoucher(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueBatchID", DBNull.Value)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@SIVDate", objStoreIssueVoucher.SIVDate)
        Parms(4) = New SqlParameter("@SIVNO", objStoreIssueVoucher.SIVNO)
        If objStoreIssueVoucher.ContractID = String.Empty Then
            Parms(5) = New SqlParameter("@ContractID", System.DBNull.Value)
        Else
            Parms(5) = New SqlParameter("@ContractID", objStoreIssueVoucher.ContractID)
        End If

        Parms(6) = New SqlParameter("@Status", objStoreIssueVoucher.Status)
        Parms(7) = New SqlParameter("@Remarks", objStoreIssueVoucher.Remarks)
        Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today())
        ''Parms(13) = New SqlParameter("@STIssueID", String.Empty)
        ''Parms(14) = New SqlParameter("@ConcurrencyId", String.Empty)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueInsert]", Parms)
        Return ds

    End Function

    Public Shared Function saveStoreIssueVoucherDetails(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(26) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueID", objStoreIssueVoucher.STIssueID) 'whether STIssueID value should be taken from text box or grid?
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@StockID", objStoreIssueVoucher.StockID)
        Parms(4) = New SqlParameter("@IssuedQty", objStoreIssueVoucher.IssuedQty)
        Parms(5) = New SqlParameter("@UsedFor", objStoreIssueVoucher.usedFor)
        Parms(6) = New SqlParameter("@COAID", objStoreIssueVoucher.COAID)
        Parms(7) = New SqlParameter("@T0", objStoreIssueVoucher.T0)
        If objStoreIssueVoucher.T1 <> String.Empty Then
            Parms(8) = New SqlParameter("@T1", objStoreIssueVoucher.T1)
        Else
            Parms(8) = New SqlParameter("@T1", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.T2 <> String.Empty Then
            Parms(9) = New SqlParameter("@T2", objStoreIssueVoucher.T2)
        Else
            Parms(9) = New SqlParameter("@T2", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.T3 <> String.Empty Then
            Parms(10) = New SqlParameter("@T3", objStoreIssueVoucher.T3)
        Else
            Parms(10) = New SqlParameter("@T3", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.T4 <> String.Empty Then
            Parms(11) = New SqlParameter("@T4", objStoreIssueVoucher.T4)
        Else
            Parms(11) = New SqlParameter("@T4", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.DivID <> String.Empty Then
            Parms(12) = New SqlParameter("@DivID", objStoreIssueVoucher.DivID)
        Else
            Parms(12) = New SqlParameter("@DivID", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.YOPID <> String.Empty Then
            Parms(13) = New SqlParameter("@YOPid", objStoreIssueVoucher.YOPID)
        Else
            Parms(13) = New SqlParameter("@YOPid", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.BlockID <> String.Empty Then
            Parms(14) = New SqlParameter("@BlockID", objStoreIssueVoucher.BlockID)
        Else
            Parms(14) = New SqlParameter("@BlockID", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.StationID <> String.Empty Then
            Parms(15) = New SqlParameter("@StationID", objStoreIssueVoucher.StationID)
        Else
            Parms(15) = New SqlParameter("@StationID", System.DBNull.Value)
        End If

        If objStoreIssueVoucher.VHID <> String.Empty Then
            Parms(16) = New SqlParameter("@VHID", objStoreIssueVoucher.VHID)
        Else
            Parms(16) = New SqlParameter("@VHID", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.ODOReading.ToString() <> String.Empty Then
            Parms(17) = New SqlParameter("@ODOReading", objStoreIssueVoucher.ODOReading)
        Else
            Parms(17) = New SqlParameter("@ODOReading", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.VHDetailCostCodeID <> String.Empty Then
            Parms(18) = New SqlParameter("@VHDetailCostCodeID", objStoreIssueVoucher.VHDetailCostCodeID)
        Else
            Parms(18) = New SqlParameter("@VHDetailCostCodeID", System.DBNull.Value)
        End If

        Parms(19) = New SqlParameter("@IssueUnitPrice", objStoreIssueVoucher.IssueUnitPrice)
        Parms(20) = New SqlParameter("@IssuedValue", objStoreIssueVoucher.IssuedValue)

        Parms(21) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(22) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(23) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(24) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(25) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(26) = New SqlParameter("@AvailableQty", objStoreIssueVoucher.AvailQty)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueDetailsInsert]", Parms)
        Return ds

    End Function

    Public Shared Function updateStoreIssueVoucher(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsStatusApproval As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueBatchID", DBNull.Value)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@SIVDate", objStoreIssueVoucher.SIVDate)
        Parms(4) = New SqlParameter("@SIVNO", objStoreIssueVoucher.SIVNO)
        If objStoreIssueVoucher.ContractID = String.Empty Then
            Parms(5) = New SqlParameter("@ContractID", System.DBNull.Value)
        Else
            Parms(5) = New SqlParameter("@ContractID", objStoreIssueVoucher.ContractID)
        End If
        Parms(6) = New SqlParameter("@Status", objStoreIssueVoucher.Status)
        If objStoreIssueVoucher.Remarks <> String.Empty Then
            Parms(7) = New SqlParameter("@Remarks ", objStoreIssueVoucher.Remarks)
        Else
            Parms(7) = New SqlParameter("@Remarks ", DBNull.Value)
        End If

        Parms(8) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@STIssueID", objStoreIssueVoucher.STIssueID) '- "must be passed as where clause param"
        Parms(12) = New SqlParameter("@RejectedReason", IIf(objStoreIssueVoucher.RejectedReason <> String.Empty, objStoreIssueVoucher.RejectedReason, DBNull.Value))
        Parms(13) = New SqlParameter("@IsStatusApproval", IsStatusApproval)
        ''Parms(14) = New SqlParameter("@ConcurrencyId", String.Empty)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueUpdate]", Parms)
        Return ds

    End Function

    Public Shared Function updateStoreIssueVoucherDetails(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(25) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueDetailsID", objStoreIssueVoucher.STIssueDetailsID)
        Parms(1) = New SqlParameter("@STIssueID", objStoreIssueVoucher.STIssueID)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@StockID", objStoreIssueVoucher.StockID)
        Parms(5) = New SqlParameter("@IssuedQty", objStoreIssueVoucher.IssuedQty)
        Parms(6) = New SqlParameter("@UsedFor", objStoreIssueVoucher.usedFor)
        Parms(7) = New SqlParameter("@COAID", objStoreIssueVoucher.COAID)
        Parms(8) = New SqlParameter("@T0", objStoreIssueVoucher.T0)
        If objStoreIssueVoucher.T1 <> String.Empty Then
            Parms(9) = New SqlParameter("@T1", objStoreIssueVoucher.T1)
        Else
            Parms(9) = New SqlParameter("@T1", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.T2 <> String.Empty Then
            Parms(10) = New SqlParameter("@T2", objStoreIssueVoucher.T2)
        Else
            Parms(10) = New SqlParameter("@T2", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.T3 <> String.Empty Then
            Parms(11) = New SqlParameter("@T3", objStoreIssueVoucher.T3)
        Else
            Parms(11) = New SqlParameter("@T3", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.T4 <> String.Empty Then
            Parms(12) = New SqlParameter("@T4", objStoreIssueVoucher.T4)
        Else
            Parms(12) = New SqlParameter("@T4", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.DivID <> String.Empty Then
            Parms(13) = New SqlParameter("@DivID", objStoreIssueVoucher.DivID)
        Else
            Parms(13) = New SqlParameter("@DivID", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.YOPID <> String.Empty Then
            Parms(14) = New SqlParameter("@YOPid", objStoreIssueVoucher.YOPID)
        Else
            Parms(14) = New SqlParameter("@YOPid", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.BlockID <> String.Empty Then
            Parms(15) = New SqlParameter("@BlockID", objStoreIssueVoucher.BlockID)
        Else
            Parms(15) = New SqlParameter("@BlockID", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.StationID <> String.Empty Then
            Parms(16) = New SqlParameter("@StationID", objStoreIssueVoucher.StationID)
        Else
            Parms(16) = New SqlParameter("@StationID", System.DBNull.Value)
        End If

        If objStoreIssueVoucher.VHID <> String.Empty Then
            Parms(17) = New SqlParameter("@VHID", objStoreIssueVoucher.VHID)
        Else
            Parms(17) = New SqlParameter("@VHID", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.ODOReading.ToString() <> String.Empty Then
            Parms(18) = New SqlParameter("@ODOReading", objStoreIssueVoucher.ODOReading)
        Else
            Parms(18) = New SqlParameter("@ODOReading", System.DBNull.Value)
        End If
        If objStoreIssueVoucher.VHDetailCostCodeID <> String.Empty Then
            Parms(19) = New SqlParameter("@VHDetailCostCodeID", objStoreIssueVoucher.VHDetailCostCodeID)
        Else
            Parms(19) = New SqlParameter("@VHDetailCostCodeID", System.DBNull.Value)
        End If
        Parms(20) = New SqlParameter("@IssueUnitPrice", objStoreIssueVoucher.IssueUnitPrice)
        Parms(21) = New SqlParameter("@IssuedValue", objStoreIssueVoucher.IssuedValue)
        Parms(22) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(23) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(24) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(25) = New SqlParameter("@AvailableQty", objStoreIssueVoucher.AvailQty)
        ''Parms(14) = New SqlParameter("@ConcurrencyId", String.Empty)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueDetailsUpdate]", Parms)
        Return ds

    End Function

    Public Shared Function DeleteStoreIssueVoucher(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueID", objStoreIssueVoucher.STIssueID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())
        ds = objdb.ExecQuery("[Store].[DeleteStoreIssueVoucher]", Parms)
        Return ds

    End Function

    Public Shared Function STIssueBtachValueUpdate(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@STIssueBatchID", objStoreIssueVoucher.STIssueBatchID)
        Parms(1) = New SqlParameter("@QtyIssued", objStoreIssueVoucher.IssuedQty)
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@SIVNo", objStoreIssueVoucher.SIVNO)
        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(5) = New SqlParameter("@IssueBatchTotal", objStoreIssueVoucher.IssueBatchTotal)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueBtachValueUpdate]", Parms)
        Return ds

    End Function

    Public Shared Function SIVSearch(ByVal objSIV As StoreIssueVoucherPPT, ByVal IsApproval As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(6) As SqlParameter
        'If objSIV.BViewSIVDate = True Then
        Parms(0) = New SqlParameter("@SIVNO", IIf(objSIV.SIVNOSearch <> String.Empty, objSIV.SIVNOSearch, DBNull.Value))
        Parms(1) = New SqlParameter("@ContractNo", IIf(objSIV.ConttractNoSearch <> String.Empty, objSIV.ConttractNoSearch, DBNull.Value))
        'Parms(2) = New SqlParameter("@Remarks", objSIV.RemarksSearch)
        If objSIV.BViewSIVDate = True Then
            Parms(2) = New SqlParameter("@SIVDate", IIf(objSIV.SIVDateSearch <> Nothing, objSIV.SIVDateSearch, DBNull.Value))
        Else
            Parms(2) = New SqlParameter("@SIVDate", DBNull.Value)
        End If

        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If objSIV.StatusSearch = "SELECT ALL" Then
            Parms(4) = New SqlParameter("@Status", System.DBNull.Value)
        ElseIf objSIV.StatusSearch = "" Then
            Parms(4) = New SqlParameter("@Status", "OPEN")
        Else
            Parms(4) = New SqlParameter("@Status", objSIV.StatusSearch)
        End If
        Parms(5) = New SqlParameter("@IsApproval", IsApproval)
        Parms(6) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Store].[SearchSIV]", Parms)

    End Function

    Public Shared Function GetSIVDetails(ByVal objSIV As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet
        Parms(0) = New SqlParameter("@STIssueID", objSIV.STIssueID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Store].[GetSIVDetails]", Parms)
        Return ds

    End Function

    ''Public Shared Function EstateTypeSelect() As String

    ''    Dim objdb As New SQLHelp
    ''    Dim Parms(0) As SqlParameter
    ''    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    ''    Dim ds As New DataSet
    ''    ds = objdb.ExecQuery("[STORE].[StoreIssueVoucherEstateType]", Parms)
    ''    Dim strEstateType As String
    ''    strEstateType = ds.Tables(0).Rows(0).Item("TYPE").ToString()
    ''    Return strEstateType
    ''End Function

    Public Shared Function ContractIDSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(3) As SqlParameter

        If objStoreIssueVoucher.ContractNo <> "" Then
            Parms(0) = New SqlParameter("@ContractNo", objStoreIssueVoucher.ContractNo)
        Else
            Parms(0) = New SqlParameter("@ContractNo", DBNull.Value)
        End If
        If objStoreIssueVoucher.ContractName <> "" Then
            Parms(1) = New SqlParameter("@ContractName", objStoreIssueVoucher.ContractName)
        Else
            Parms(1) = New SqlParameter("@ContractName", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[StoreIssueVoucherContractIDSelect]", Parms)
        Return ds

    End Function

    Public Shared Function AcctlookupSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objStoreIssueVoucher.COACode <> "" And objStoreIssueVoucher.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objStoreIssueVoucher.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objStoreIssueVoucher.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objStoreIssueVoucher.COACode <> "" And objStoreIssueVoucher.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objStoreIssueVoucher.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objStoreIssueVoucher.COACode = "" And objStoreIssueVoucher.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objStoreIssueVoucher.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)

    End Function

    Public Shared Function GetDIV(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim ds As New DataSet
        Parms(0) = New SqlParameter("@Div", IIf(objStoreIssueVoucher.Div <> String.Empty, objStoreIssueVoucher.Div, DBNull.Value))
        Parms(1) = New SqlParameter("@DivName", IIf(objStoreIssueVoucher.DivName <> String.Empty, objStoreIssueVoucher.DivName, DBNull.Value))
        Parms(2) = New SqlParameter("@IsDirect", IsDirect)
        Parms(3) = New SqlParameter("@BlockID", IIf(objStoreIssueVoucher.BlockID <> String.Empty, objStoreIssueVoucher.BlockID, DBNull.Value))
        Parms(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[STORE].[DivisionGet]", Parms)
        Return ds

    End Function

    Public Shared Function TlookupSearch(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)
        If objStoreIssueVoucher.TDecide = "T0" Then
            If objStoreIssueVoucher.T0Value <> "" And objStoreIssueVoucher.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objStoreIssueVoucher.T0Value <> "" And objStoreIssueVoucher.T0Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objStoreIssueVoucher.T0Value = "" And objStoreIssueVoucher.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        ElseIf objStoreIssueVoucher.TDecide = "T1" Then
            If objStoreIssueVoucher.T1Value <> "" And objStoreIssueVoucher.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objStoreIssueVoucher.T1Value <> "" And objStoreIssueVoucher.T1Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objStoreIssueVoucher.T1Value = "" And objStoreIssueVoucher.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        ElseIf objStoreIssueVoucher.TDecide = "T2" Then
            If objStoreIssueVoucher.T2Value <> "" And objStoreIssueVoucher.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objStoreIssueVoucher.T2Value <> "" And objStoreIssueVoucher.T2Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objStoreIssueVoucher.T2Value = "" And objStoreIssueVoucher.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        ElseIf objStoreIssueVoucher.TDecide = "T3" Then
            If objStoreIssueVoucher.T3Value <> "" And objStoreIssueVoucher.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objStoreIssueVoucher.T3Value <> "" And objStoreIssueVoucher.T3Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objStoreIssueVoucher.T3Value = "" And objStoreIssueVoucher.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        ElseIf objStoreIssueVoucher.TDecide = "T4" Then
            If objStoreIssueVoucher.T4Value <> "" And objStoreIssueVoucher.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objStoreIssueVoucher.T4Value <> "" And objStoreIssueVoucher.T4Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", objStoreIssueVoucher.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objStoreIssueVoucher.T4Value = "" And objStoreIssueVoucher.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objStoreIssueVoucher.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objStoreIssueVoucher.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        Return objdb.ExecQuery("[Store].[StoreIssueVoucherTAnalysisSelect]", Parms)

    End Function

    Public Shared Function GetStockCategory(ByVal obStkCategory As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[GetStockCategory]", Parms)
        Return ds

    End Function

    Public Shared Function GetYOP(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        If objStoreIssueVoucher.YOP <> "" And objStoreIssueVoucher.YOPName <> "" Then
            Parms(0) = New SqlParameter("@YOP", objStoreIssueVoucher.YOP)
            Parms(1) = New SqlParameter("@YOPName", objStoreIssueVoucher.YOPName)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objStoreIssueVoucher.YOP <> "" And objStoreIssueVoucher.YOPName = "" Then
            Parms(0) = New SqlParameter("@YOP", objStoreIssueVoucher.YOP)
            Parms(1) = New SqlParameter("@YOPName", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objStoreIssueVoucher.YOP = "" And objStoreIssueVoucher.YOPName <> "" Then
            Parms(0) = New SqlParameter("@YOP", DBNull.Value)
            Parms(1) = New SqlParameter("@YOPName", objStoreIssueVoucher.YOPName)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@YOP", DBNull.Value)
            Parms(1) = New SqlParameter("@YOPName", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If        
        Return objdb.ExecQuery("[STORE].[GetYOP]", Parms)

    End Function

    Public Shared Function GetCropID(ByVal CropID As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter

        Parms(0) = New SqlParameter("@Keyname", CropID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[dbo].[Keyvaluepairsselect]", Parms)
        Return ds

    End Function

    Public Shared Function GetSubBlock(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter

        If objStoreIssueVoucher.Div <> "" Then
            Parms(0) = New SqlParameter("@Div", objStoreIssueVoucher.Div)
        Else
            Parms(0) = New SqlParameter("@Div", DBNull.Value)
        End If
        If objStoreIssueVoucher.YOP <> "" Then
            Parms(1) = New SqlParameter("@YOP", objStoreIssueVoucher.YOP)
        Else
            Parms(1) = New SqlParameter("@YOP", DBNull.Value)
        End If
        If objStoreIssueVoucher.BlockName <> "" Then
            Parms(2) = New SqlParameter("@BlockName", objStoreIssueVoucher.BlockName)
        Else
            Parms(2) = New SqlParameter("@BlockName", DBNull.Value)
        End If
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)        
        If PsGETBlockStatusByExpenditureAG(objStoreIssueVoucher.BlockStatus) <> String.Empty Then
            Parms(5) = New SqlParameter("@BlockStatus", PsGETBlockStatusByExpenditureAG(objStoreIssueVoucher.BlockStatus))
        Else
            Parms(5) = New SqlParameter("@BlockStatus", DBNull.Value)
        End If
        Parms(6) = New SqlParameter("@CropID", objStoreIssueVoucher.CropID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[BlockMasterGet]", Parms)
        Return ds

    End Function

    'Public Shared Function PsGETBlockStatusByExpenditureAG(ByVal ExpenditureAG As String) As String

    '    Select Case ExpenditureAG
    '        Case "Newplanting"
    '            PsGETBlockStatusByExpenditureAG = "Immature"
    '        Case "Nursery"
    '            PsGETBlockStatusByExpenditureAG = "Nursery"
    '        Case "Matured"
    '            PsGETBlockStatusByExpenditureAG = "Matured"
    '        Case "Immature"
    '            PsGETBlockStatusByExpenditureAG = "Replanting"
    '        Case "MILL"
    '            PsGETBlockStatusByExpenditureAG = "MILL"
    '        Case "KCP"
    '            PsGETBlockStatusByExpenditureAG = "KCP"
    '        Case "CES"
    '            PsGETBlockStatusByExpenditureAG = "CES"
    '        Case "Operating"
    '            PsGETBlockStatusByExpenditureAG = "Operating"
    '        Case Else
    '            PsGETBlockStatusByExpenditureAG = String.Empty
    '    End Select

    'End Function

    Public Shared Function PsGETBlockStatusByExpenditureAG(ByVal ExpenditureAG As String) As String
        Dim BlockStatusByExpenditureAG As String = String.Empty

        Select Case ExpenditureAG.ToUpper.Trim
            Case "NEWPLANTING"
                PsGETBlockStatusByExpenditureAG = "Immature"
            Case "NURSERY"
                PsGETBlockStatusByExpenditureAG = "Nursery"
            Case "MATURED"
                PsGETBlockStatusByExpenditureAG = "Matured"
            Case "IMMATURE"
                PsGETBlockStatusByExpenditureAG = "Immature"
            Case "MILL"
                PsGETBlockStatusByExpenditureAG = "MILL"
            Case "KCP"
                PsGETBlockStatusByExpenditureAG = "KCP"
            Case "CES"
                PsGETBlockStatusByExpenditureAG = "CES"
            Case "OPERATING"
                PsGETBlockStatusByExpenditureAG = "Operating"
            Case Else
                PsGETBlockStatusByExpenditureAG = String.Empty
        End Select


    End Function
    Public Shared Function GetStation(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        If objStoreIssueVoucher.Stationcode <> String.Empty Then
            Parms(0) = New SqlParameter("@StationCode", objStoreIssueVoucher.Stationcode)
        Else
            Parms(0) = New SqlParameter("@StationCode", DBNull.Value)
        End If
        If objStoreIssueVoucher.StationDesc <> String.Empty Then
            Parms(1) = New SqlParameter("@StationDescp", objStoreIssueVoucher.StationDesc)
        Else
            Parms(1) = New SqlParameter("@StationDescp", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[Store].[ProductionStationGet]", Parms)

    End Function

    Public Shared Function GetVHNo(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@VHWSCode", IIf(objStoreIssueVoucher.VHWSCode <> String.Empty, objStoreIssueVoucher.VHWSCode, DBNull.Value))
        Parms(1) = New SqlParameter("@VHDescp", IIf(objStoreIssueVoucher.VHDesc <> String.Empty, objStoreIssueVoucher.VHDesc, DBNull.Value))
        Parms(2) = New SqlParameter("@VHCategoryID", IIf(objStoreIssueVoucher.VHCategoryID <> String.Empty, objStoreIssueVoucher.VHCategoryID, DBNull.Value))
        Parms(3) = New SqlParameter("@Type", IIf(objStoreIssueVoucher.Type <> String.Empty, objStoreIssueVoucher.Type, DBNull.Value))
        Parms(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(5) = New SqlParameter("@IsDirect", IsDirect)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[VHNMasterVHNoGet]", Parms)
        Return ds

    End Function

    Public Shared Function VHNCategoryGet(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[VHNCategoryGet]", Parms)
        Return ds

    End Function

    Public Shared Function GetVHDetailsCostCode(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@VHDetailCostCode", IIf(objStoreIssueVoucher.VHDetailCostCode <> String.Empty, objStoreIssueVoucher.VHDetailCostCode, DBNull.Value))
        Parms(1) = New SqlParameter("@VHDescp", IIf(objStoreIssueVoucher.VHDetailCostDesc <> String.Empty, objStoreIssueVoucher.VHDetailCostDesc, DBNull.Value))
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Parms(4) = New SqlParameter("@Type", IIf(objStoreIssueVoucher.Type <> String.Empty, objStoreIssueVoucher.Type, DBNull.Value))
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[VHDetailsCostCodeGet]", Parms)
        Return ds

    End Function

    Public Shared Function IsContractNoExist(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        If objStoreIssueVoucher.ContractID <> "" Then
            Parms(0) = New SqlParameter("@ContractID", objStoreIssueVoucher.ContractID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ContractNo", objStoreIssueVoucher.ContractNo)
        Else
            Parms(0) = New SqlParameter("@ContractID", System.DBNull.Value)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ContractNo", objStoreIssueVoucher.ContractNo)
        End If

        Return objdb.ExecQuery("[Store].[STIssueContractNOIsExist]", Parms)

    End Function

    Public Shared Function STIssueIsSIVNoExist(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        If objStoreIssueVoucher.SIVNO <> "" Then
            Parms(0) = New SqlParameter("@SIVNO", objStoreIssueVoucher.SIVNO)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        End If
        Return objdb.ExecQuery("[Store].[STIssueIsSIVNoExist]", Parms)

    End Function

    Public Shared Function STIssueAvgPriceGet(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@StockId", objStoreIssueVoucher.StockID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueAvgPriceGet]", Parms)
        Return ds

    End Function

    Public Shared Function STStockDetailAvgPriceApproval(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@StockId", objStoreIssueVoucher.StockID)
        Parms(3) = New SqlParameter("@ID", objStoreIssueVoucher.STIssueID) '@STIssueID
        Parms(4) = New SqlParameter("@Qty", objStoreIssueVoucher.IssuedQty) '
        Parms(5) = New SqlParameter("@Value", 0) '
        Parms(6) = New SqlParameter("@TransType", "SIV")
        Parms(7) = New SqlParameter("@ReceivedPrice", 0) 'pass this value in emdn approval only
        'Parms(8) = New SqlParameter("@DetailsID", objStoreIssueVoucher.STIssueDetailsID) '@STIssueDetailsID
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STStockDetailAvgPriceApproval]", Parms)
        Return ds

    End Function

    Public Shared Function STIssueLedgerAllModuleInsert(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objStockIssueVoucherApprovalPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objStockIssueVoucherApprovalPPT.AMonth)
        Parms(5) = New SqlParameter("@ModName", "STORE")
        Parms(6) = New SqlParameter("@LedgerDate", objStockIssueVoucherApprovalPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objStockIssueVoucherApprovalPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", IIf(objStockIssueVoucherApprovalPPT.Descp <> String.Empty, objStockIssueVoucherApprovalPPT.Descp, DBNull.Value))
        Parms(9) = New SqlParameter("@BatchAmount", DBNull.Value)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_N]", Parms)
        Return ds

    End Function

    Public Shared Function STIssueLedgerAllModuleUpdate(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Dim intLedgerAllModuleRowsAffected As Integer = 0
        Try
            Parms(0) = New SqlParameter("@LedgerID", objStockIssueVoucherApprovalPPT.LedgerID)
            Parms(1) = New SqlParameter("@DC", objStockIssueVoucherApprovalPPT.DC)
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

    Public Shared Function STIssueJournalDetailInsert(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(24) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objStockIssueVoucherApprovalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objStockIssueVoucherApprovalPPT.AMonth)
            Parms(3) = New SqlParameter("@LedgerID", objStockIssueVoucherApprovalPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objStockIssueVoucherApprovalPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objStockIssueVoucherApprovalPPT.DC)
            Parms(6) = New SqlParameter("@Value", objStockIssueVoucherApprovalPPT.Value)
            Parms(7) = New SqlParameter("@DivID", IIf(objStockIssueVoucherApprovalPPT.DivID <> String.Empty, objStockIssueVoucherApprovalPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objStockIssueVoucherApprovalPPT.YopID <> String.Empty, objStockIssueVoucherApprovalPPT.YopID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objStockIssueVoucherApprovalPPT.BlockID <> String.Empty, objStockIssueVoucherApprovalPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objStockIssueVoucherApprovalPPT.VHID <> String.Empty, objStockIssueVoucherApprovalPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objStockIssueVoucherApprovalPPT.VHDetailCostCodeID <> String.Empty, objStockIssueVoucherApprovalPPT.VHDetailCostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objStockIssueVoucherApprovalPPT.T0 <> String.Empty, objStockIssueVoucherApprovalPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objStockIssueVoucherApprovalPPT.T1 <> String.Empty, objStockIssueVoucherApprovalPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objStockIssueVoucherApprovalPPT.T2 <> String.Empty, objStockIssueVoucherApprovalPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objStockIssueVoucherApprovalPPT.T3 <> String.Empty, objStockIssueVoucherApprovalPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objStockIssueVoucherApprovalPPT.T4 <> String.Empty, objStockIssueVoucherApprovalPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objStockIssueVoucherApprovalPPT.JournalDetDescp <> String.Empty, objStockIssueVoucherApprovalPPT.JournalDetDescp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objStockIssueVoucherApprovalPPT.Flag <> String.Empty, objStockIssueVoucherApprovalPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objStockIssueVoucherApprovalPPT.StationID <> String.Empty, objStockIssueVoucherApprovalPPT.StationID, DBNull.Value))
            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected

    End Function

    Public Shared Function STIssueStockIDDetailSelect(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@StockId", objStoreIssueVoucher.StockID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@STIssueDetailsID", objStoreIssueVoucher.STIssueDetailsID)
        Parms(4) = New SqlParameter("@IssuedQty", objStoreIssueVoucher.IssuedQty)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[STIssueStockIDDetailSelect]", Parms)
        Return ds

    End Function

    Public Shared Function VHChargeDetailInsert(ByVal objStockIssueVoucherApprovalPPT As StockIssueVoucherApprovalPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(18) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateCodeL", objStockIssueVoucherApprovalPPT.EstateCodeL)
            Parms(1) = New SqlParameter("@VHWSCode", objStockIssueVoucherApprovalPPT.VHWSCode)
            Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(3) = New SqlParameter("@VHDetailCostCode", objStockIssueVoucherApprovalPPT.VHDetailCostCode)
            Parms(4) = New SqlParameter("@Type", objStockIssueVoucherApprovalPPT.Type)
            Parms(5) = New SqlParameter("@ModName", "Store")
            Parms(6) = New SqlParameter("@AYear", objStockIssueVoucherApprovalPPT.AYear)
            Parms(7) = New SqlParameter("@AMonth", objStockIssueVoucherApprovalPPT.AMonth)
            Parms(8) = New SqlParameter("@Value", objStockIssueVoucherApprovalPPT.Value)
            Parms(9) = New SqlParameter("@JDescp", objStockIssueVoucherApprovalPPT.Descp)
            Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(14) = New SqlParameter("@LedgerNo", objStockIssueVoucherApprovalPPT.LedgerNo)
            Parms(15) = New SqlParameter("@LedgerType", objStockIssueVoucherApprovalPPT.LedgerType)
            Parms(16) = New SqlParameter("@UOMID", objStockIssueVoucherApprovalPPT.UOMID)
            Parms(17) = New SqlParameter("@QtyUsed", objStockIssueVoucherApprovalPPT.Qty)
            Parms(18) = New SqlParameter("@RefNo", objStockIssueVoucherApprovalPPT.RefNo)
            objdb.ExecNonQuery("[Vehicle].[VHChargeDetailInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected

    End Function

    Public Function SIVRecordIsExist(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As Object

        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        objExists = objdb.ExecuteScalar("[Store].[STIssueRecordIsExist]", Parms)
        Return objExists

    End Function

    Public Shared Function TaskMonitorUpdateOnSIVApproval(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT) As Object

        Dim objdb As New SQLHelp
        Dim objExists As Object
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ModID", 2)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())
        objExists = objdb.ExecuteScalar("[Store].[TaskMonitorUpdateOnSIVApproval]", Parms)
        Return objExists

    End Function

    Public Shared Function StockCategorySearch(ByVal CategorySearch As String) As DataTable

        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@STCategoryDescp", CategorySearch)
        Dim dt As DataTable
        dt = objdb.ExecQuery("[Store].[STCategorySearchAndSelectForSIV]", Parms).Tables(0)
        'Dim strResult As String = dt.Rows(0).Item("STCategoryCode").ToString()
        'Dim strResult1 As String = dt.Rows(0).Item("STCategoryID").ToString()
        Return dt

    End Function

    Public Shared Function SIVSearchForReport(ByVal objSIV As StoreIssueVoucherPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        'If objSIV.BViewSIVDate = True Then
        Parms(0) = New SqlParameter("@SIVNO", IIf(objSIV.SIVNOSearch <> String.Empty, objSIV.SIVNOSearch, DBNull.Value))
        'Parms(1) = New SqlParameter("@ContractNo", IIf(objSIV.ConttractNoSearch <> String.Empty, objSIV.ConttractNoSearch, DBNull.Value))
        'Parms(2) = New SqlParameter("@Remarks", objSIV.RemarksSearch)
        If objSIV.BViewSIVDate = True Then
            Parms(1) = New SqlParameter("@SIVDate", IIf(objSIV.SIVDateSearch <> Nothing, objSIV.SIVDateSearch, DBNull.Value))
        Else
            Parms(1) = New SqlParameter("@SIVDate", DBNull.Value)
        End If

        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
       
        Parms(3) = New SqlParameter("@Status", DBNull.Value)


        Parms(4) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Store].[SearchSIVForReport]", Parms)

    End Function

    Public Shared Function STIssueDetailDelete(ByVal objSIV As StoreIssueVoucherPPT) As Integer

        Dim objdb As New SQLHelp
        Dim intSIVRowsAffected As Integer = 0

        Try

            Dim Parms(3) As SqlParameter
            Parms(0) = New SqlParameter("@STIssueID", objSIV.STIssueID)
            Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
            Parms(3) = New SqlParameter("@STIssueDetailsID", objSIV.STIssueDetailsID)

            objdb.ExecNonQuery("[Store].[STIssueDetailsDelete]", Parms)
            intSIVRowsAffected = 1
        Catch ex As Exception
            intSIVRowsAffected = 0
        End Try
        Return intSIVRowsAffected


    End Function

    Public Shared Function STIssueDetailsIssuedQtyCheck(ByVal StockID As String, ByVal RequestedIssueQty As Double) As Double

        Dim objdb As New SQLHelp
        Dim IssuedQty As Integer = 0

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", StockID)
        Parms(3) = New SqlParameter("@RequestedIssueQty", RequestedIssueQty)

        IssuedQty = objdb.ExecuteScalar("[Store].[STIssueDetailsIssuedQtyCheck]", Parms)

        Return IssuedQty

    End Function

    Public Shared Function STIssueDetailsOpenQtyCheck(ByVal StockID As String, ByVal SIVNo As String) As Double

        Dim objdb As New SQLHelp
        Dim IssuedQty As Double = 0

        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@StockID", StockID)
        Parms(3) = New SqlParameter("@SIVNo", SIVNo)

        IssuedQty = objdb.ExecuteScalar("[Store].[STIssueDetailsOpenQtyCheck]", Parms)

        Return IssuedQty

    End Function
    Public Shared Function GetEquipment(ByVal objStoreIssueVoucher As StoreIssueVoucherPPT, ByVal IsDirect As String) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        If objStoreIssueVoucher.MachineCode <> String.Empty Then
            Parms(0) = New SqlParameter("@MachineCode", objStoreIssueVoucher.MachineCode)
        Else
            Parms(0) = New SqlParameter("@MachineCode", DBNull.Value)
        End If
        If objStoreIssueVoucher.MachineName <> String.Empty Then
            Parms(1) = New SqlParameter("@MachineName", objStoreIssueVoucher.MachineName)
        Else
            Parms(1) = New SqlParameter("@MachineName", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[Store].[GetEquipment]", Parms)

    End Function


    Public Shared Function TAnalysis_CRTAnalisysSelect( _
        ByVal TAnalisysID As String, _
        ByVal TAnalisysCode As String, _
        ByVal TValue As String) As DataTable

        ' Selasa, 22 Sep 2009, 06:21
        ' Selasa, 20 Oct 2009, 12:51 -> use SQLHelp
        Dim DT As DataTable
        Dim params(3) As SqlParameter
        Dim adapter As New Common_DAL.SQLHelp

        params(0) = New SqlParameter("@EstateID", SqlDbType.NVarChar)
        params(0).Value = GlobalPPT.strEstateID

        params(1) = New SqlParameter("@TAnalisysID", SqlDbType.NVarChar)
        params(1).Value = TAnalisysID

        params(2) = New SqlParameter("@TAnalisysCode", SqlDbType.NVarChar)
        params(2).Value = TAnalisysCode

        params(3) = New SqlParameter("@TValue", SqlDbType.NVarChar)
        params(3).Value = TValue


        DT = adapter.ExecQuery("Checkroll.CRTAnalysisSelect", params).Tables(0)

        Return DT
    End Function
End Class


Imports System.Data.SqlClient
Imports Accounts_PPT
Imports Common_DAL
Imports Common_PPT

Public Class JournalDAL



    Public Shared Function SaveJournal(ByVal ObjJournalPPT As JournalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(26) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@AccBatchID", ObjJournalPPT.AccBatchID)
        Parms(3) = New SqlParameter("@LedgerSetupID", ObjJournalPPT.LedgerSetupID)
        Parms(4) = New SqlParameter("@JDate", ObjJournalPPT.JournalDate)
        Parms(5) = New SqlParameter("@ContractID", IIf(ObjJournalPPT.ContractID <> String.Empty, ObjJournalPPT.ContractID, DBNull.Value))
        Parms(6) = New SqlParameter("@JDescp", ObjJournalPPT.JournalDescp)
        Parms(7) = New SqlParameter("@COAID", ObjJournalPPT.COAID)
        Parms(8) = New SqlParameter("@DivID", IIf(ObjJournalPPT.DivID <> String.Empty, ObjJournalPPT.DivID, DBNull.Value))
        Parms(9) = New SqlParameter("@YOPID", IIf(ObjJournalPPT.YOPID <> String.Empty, ObjJournalPPT.YOPID, DBNull.Value))
        Parms(10) = New SqlParameter("@BlockID", IIf(ObjJournalPPT.BlockID <> String.Empty, ObjJournalPPT.BlockID, DBNull.Value))
        Parms(11) = New SqlParameter("@VHID", IIf(ObjJournalPPT.VHID <> String.Empty, ObjJournalPPT.VHID, DBNull.Value))
        Parms(12) = New SqlParameter("@VHDetailCostCodeID", IIf(ObjJournalPPT.VHDetailcostCodeID <> String.Empty, ObjJournalPPT.VHDetailcostCodeID, DBNull.Value))
        Parms(13) = New SqlParameter("@StationID", IIf(ObjJournalPPT.StationID <> String.Empty, ObjJournalPPT.StationID, DBNull.Value))
        Parms(14) = New SqlParameter("@T0", IIf(ObjJournalPPT.T0 <> String.Empty, ObjJournalPPT.T0, DBNull.Value))
        Parms(15) = New SqlParameter("@T1", IIf(ObjJournalPPT.T1 <> String.Empty, ObjJournalPPT.T1, DBNull.Value))
        Parms(16) = New SqlParameter("@T2", IIf(ObjJournalPPT.T2 <> String.Empty, ObjJournalPPT.T2, DBNull.Value))
        Parms(17) = New SqlParameter("@T3", IIf(ObjJournalPPT.T3 <> String.Empty, ObjJournalPPT.T3, DBNull.Value))
        Parms(18) = New SqlParameter("@T4", IIf(ObjJournalPPT.T4 <> String.Empty, ObjJournalPPT.T4, DBNull.Value))
        Parms(19) = New SqlParameter("@Debit", IIf(ObjJournalPPT.Debit <> 0, ObjJournalPPT.Debit, DBNull.Value))
        Parms(20) = New SqlParameter("@Credit", IIf(ObjJournalPPT.Credit <> 0, ObjJournalPPT.Credit, DBNull.Value))
        Parms(21) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(22) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(23) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(24) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(25) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(26) = New SqlParameter("@Description", ObjJournalPPT.Description)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[AccJournalInsert]", Parms)
        Return ds

    End Function

    Public Shared Function UpdateJournal(ByVal ObjJournalPPT As JournalPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(24) As SqlParameter

        Parms(0) = New SqlParameter("@AccJournalID", ObjJournalPPT.AccJournalID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@AccBatchID", ObjJournalPPT.AccBatchID)
        Parms(4) = New SqlParameter("@LedgerSetupID", ObjJournalPPT.LedgerSetupID)
        Parms(5) = New SqlParameter("@JDate", ObjJournalPPT.JournalDate)
        Parms(6) = New SqlParameter("@ContractID", IIf(ObjJournalPPT.ContractID <> String.Empty, ObjJournalPPT.ContractID, DBNull.Value))
        Parms(7) = New SqlParameter("@JDescp", ObjJournalPPT.JournalDescp)
        Parms(8) = New SqlParameter("@COAID", ObjJournalPPT.COAID)
        Parms(9) = New SqlParameter("@DivID", IIf(ObjJournalPPT.DivID <> String.Empty, ObjJournalPPT.DivID, DBNull.Value))
        Parms(10) = New SqlParameter("@YOPID", IIf(ObjJournalPPT.YOPID <> String.Empty, ObjJournalPPT.YOPID, DBNull.Value))
        Parms(11) = New SqlParameter("@BlockID", IIf(ObjJournalPPT.BlockID <> String.Empty, ObjJournalPPT.BlockID, DBNull.Value))
        Parms(12) = New SqlParameter("@VHID", IIf(ObjJournalPPT.VHID <> String.Empty, ObjJournalPPT.VHID, DBNull.Value))
        Parms(13) = New SqlParameter("@VHDetailCostCodeID", IIf(ObjJournalPPT.VHDetailcostCodeID <> String.Empty, ObjJournalPPT.VHDetailcostCodeID, DBNull.Value))
        Parms(14) = New SqlParameter("@StationID", IIf(ObjJournalPPT.StationID <> String.Empty, ObjJournalPPT.StationID, DBNull.Value))
        Parms(15) = New SqlParameter("@T0", IIf(ObjJournalPPT.T0 <> String.Empty, ObjJournalPPT.T0, DBNull.Value))
        Parms(16) = New SqlParameter("@T1", IIf(ObjJournalPPT.T1 <> String.Empty, ObjJournalPPT.T1, DBNull.Value))
        Parms(17) = New SqlParameter("@T2", IIf(ObjJournalPPT.T2 <> String.Empty, ObjJournalPPT.T2, DBNull.Value))
        Parms(18) = New SqlParameter("@T3", IIf(ObjJournalPPT.T3 <> String.Empty, ObjJournalPPT.T3, DBNull.Value))
        Parms(19) = New SqlParameter("@T4", IIf(ObjJournalPPT.T4 <> String.Empty, ObjJournalPPT.T4, DBNull.Value))
        Parms(20) = New SqlParameter("@Debit", IIf(ObjJournalPPT.Debit <> 0, ObjJournalPPT.Debit, DBNull.Value))
        Parms(21) = New SqlParameter("@Credit", IIf(ObjJournalPPT.Credit <> 0, ObjJournalPPT.Credit, DBNull.Value))
        Parms(22) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(23) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(24) = New SqlParameter("@Description", ObjJournalPPT.Description)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[AccJournalUpdate]", Parms)
        Return ds

    End Function


    Public Function DeleteJournal(ByVal ObjJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AccBatchID", ObjJournalPPT.AccBatchID)
        Parms(2) = New SqlParameter("@activeMonthyearID", GlobalPPT.strActMthYearID)


        rowsAffected = objdb.ExecNonQuery("[Accounts].[AccJournalDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function

    Public Function GetJournal(ByVal ObjJournalPPT As JournalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Ledgerno", ObjJournalPPT.LedgerNo)
        Parms(2) = New SqlParameter("@JDate", ObjJournalPPT.lJournalDate)
        Parms(3) = New SqlParameter("@LedgerType", ObjJournalPPT.LedgerType)
        Parms(4) = New SqlParameter("@activeMonthyearID", GlobalPPT.strActMthYearID)
        Parms(5) = New SqlParameter("@Status", ObjJournalPPT.Status)


        dt = objdb.ExecQuery("[Accounts].[AccJournalSelect_New]", Parms).Tables(0)
        Return dt
    End Function
    Public Function GetMultipleEntryValue(ByVal ObjJournalPPT As JournalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter

        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AccBatchID", ObjJournalPPT.AccBatchID)
        Parms(2) = New SqlParameter("@activeMonthyearID", GlobalPPT.strActMthYearID)

        dt = objdb.ExecQuery("[Accounts].[AccJournalMultiEntrySelect]", Parms).Tables(0)
        Return dt
    End Function

    Public Function GetLedgerType(ByVal ObjDistributionChargeCodeConfig As JournalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)


        ds = objdb.ExecQuery("[Accounts].[JournalLedgerTypeValue]", Parms).Tables(0)
        Return ds
    End Function
    Public Function GetCreditDebitAmount(ByVal ObjJournalPPT As JournalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("LedgerNo", ObjJournalPPT.LedgerNo)
        ds = objdb.ExecQuery("[Accounts].[AccJournalCreditDebitAmount]", Parms)
        Return ds
    End Function
    Public Function DuplicateJournalCheck(ByVal ObjJournalPPT As JournalPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerNo", ObjJournalPPT.LedgerNo)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        objExists = objdb.ExecuteScalar("[Accounts].[AccJournalIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Shared Function AcctlookupSearch(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        If objJournalPPT.COACode <> "" And objJournalPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", objJournalPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", objJournalPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objJournalPPT.COACode <> "" And objJournalPPT.COADescp = "" Then
            Parms(0) = New SqlParameter("@Accountcode", objJournalPPT.COACode)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf objJournalPPT.COACode = "" And objJournalPPT.COADescp <> "" Then
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", objJournalPPT.COADescp)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Parms(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Parms)
    End Function

    Public Shared Function LedgerNoSearch(ByVal objJournal As JournalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(1) As SqlParameter

        Parms(0) = New SqlParameter("@LedgerNo", objJournal.LedgerNo)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        Return objdb.ExecQuery("[Accounts].[JournalLedgerNoSelect]", Parms)

    End Function

    Public Shared Function ContractIDSearch(ByVal objJournal As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(3) As SqlParameter

        If objJournal.ContractNo <> "" Then
            Parms(0) = New SqlParameter("@ContractNo", objJournal.ContractNo)
        Else
            Parms(0) = New SqlParameter("@ContractNo", DBNull.Value)
        End If
        If objJournal.ContractName <> "" Then
            Parms(1) = New SqlParameter("@ContractName", objJournal.ContractName)
        Else
            Parms(1) = New SqlParameter("@ContractName", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[StoreIssueVoucherContractIDSelect]", Parms)
        Return ds
    End Function
    Public Shared Function EstateTypeSelect() As String

        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[STORE].[StoreIssueVoucherEstateType]", Parms)
        Dim strEstateType As String
        strEstateType = ds.Tables(0).Rows(0).Item("TYPE").ToString()
        Return strEstateType
    End Function

    Public Shared Function GetDIV(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim ds As New DataSet
        Parms(0) = New SqlParameter("@Div", IIf(objJournalPPT.Div <> String.Empty, objJournalPPT.Div, DBNull.Value))
        Parms(1) = New SqlParameter("@DivName", IIf(objJournalPPT.DivName <> String.Empty, objJournalPPT.DivName, DBNull.Value))
        Parms(2) = New SqlParameter("@IsDirect", IsDirect)
        Parms(3) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))
        Parms(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[STORE].[DivisionGet]", Parms)
        Return ds
    End Function


    Public Shared Function GetYOP(ByVal ObjJournalPPT As JournalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        If ObjJournalPPT.YOP <> "" And ObjJournalPPT.YOPName <> "" Then
            Parms(0) = New SqlParameter("@YOP", ObjJournalPPT.YOP)
            Parms(1) = New SqlParameter("@YOPName", ObjJournalPPT.YOPName)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf ObjJournalPPT.YOP <> "" And ObjJournalPPT.YOPName = "" Then
            Parms(0) = New SqlParameter("@YOP", ObjJournalPPT.YOP)
            Parms(1) = New SqlParameter("@YOPName", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf ObjJournalPPT.YOP = "" And ObjJournalPPT.YOPName <> "" Then
            Parms(0) = New SqlParameter("@YOP", DBNull.Value)
            Parms(1) = New SqlParameter("@YOPName", ObjJournalPPT.YOPName)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Parms(0) = New SqlParameter("@YOP", DBNull.Value)
            Parms(1) = New SqlParameter("@YOPName", DBNull.Value)
            Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Return objdb.ExecQuery("[STORE].[GetYOP]", Parms)
    End Function

    Public Shared Function GetSubBlock(ByVal ObjJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter

        If ObjJournalPPT.Div <> "" Then
            Parms(0) = New SqlParameter("@Div", ObjJournalPPT.Div)
        Else
            Parms(0) = New SqlParameter("@Div", DBNull.Value)
        End If
        If ObjJournalPPT.YOP <> "" Then
            Parms(1) = New SqlParameter("@YOP", ObjJournalPPT.YOP)
        Else
            Parms(1) = New SqlParameter("@YOP", DBNull.Value)
        End If
        If ObjJournalPPT.SubBlock <> "" Then
            Parms(2) = New SqlParameter("@BlockName", ObjJournalPPT.SubBlock)
        Else
            Parms(2) = New SqlParameter("@BlockName", DBNull.Value)
        End If
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)
        If ObjJournalPPT.BlockStatus <> "" Then
            Parms(5) = New SqlParameter("@BlockStatus", ObjJournalPPT.BlockStatus)
        Else
            Parms(5) = New SqlParameter("@BlockStatus", DBNull.Value)
        End If
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[BlockMasterGet]", Parms)
        Return ds

    End Function

    Public Shared Function GetStation(ByVal ObjJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        If ObjJournalPPT.StationCode <> String.Empty Then
            Parms(0) = New SqlParameter("@StationCode", ObjJournalPPT.StationCode)
        Else
            Parms(0) = New SqlParameter("@StationCode", DBNull.Value)
        End If
        If ObjJournalPPT.StationDesc <> String.Empty Then
            Parms(1) = New SqlParameter("@StationDescp", ObjJournalPPT.StationDesc)
        Else
            Parms(1) = New SqlParameter("@StationDescp", DBNull.Value)
        End If
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[Store].[ProductionStationGet]", Parms)
    End Function

    Public Shared Function GetVHNo(ByVal ObjJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@VHWSCode", IIf(ObjJournalPPT.VHWScode <> String.Empty, ObjJournalPPT.VHWScode, DBNull.Value))
        Parms(1) = New SqlParameter("@VHDescp", IIf(ObjJournalPPT.VHDesc <> String.Empty, ObjJournalPPT.VHDesc, DBNull.Value))
        Parms(2) = New SqlParameter("@VHCategoryID", IIf(ObjJournalPPT.VHCategoryID <> String.Empty, ObjJournalPPT.VHCategoryID, DBNull.Value))
        Parms(3) = New SqlParameter("@Type", IIf(ObjJournalPPT.Type <> String.Empty, ObjJournalPPT.Type, DBNull.Value))
        Parms(4) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(5) = New SqlParameter("@IsDirect", IsDirect)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[VHNMasterVHNoGet]", Parms)
        Return ds
    End Function

    Public Shared Function GetVHDetailsCostCode(ByVal ObjJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@VHDetailCostCode", IIf(ObjJournalPPT.VHDetailCostCode <> String.Empty, ObjJournalPPT.VHDetailCostCode, DBNull.Value))
        Parms(1) = New SqlParameter("@VHDescp", IIf(ObjJournalPPT.VHDetailCostDescp <> String.Empty, ObjJournalPPT.VHDetailCostDescp, DBNull.Value))
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Parms(4) = New SqlParameter("@Type", IIf(ObjJournalPPT.Type <> String.Empty, ObjJournalPPT.Type, DBNull.Value))
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Store].[VHDetailsCostCodeGet]", Parms)
        Return ds
    End Function

    Public Shared Function TlookupSearch(ByVal objJournalPPT As JournalPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(4) = New SqlParameter("@IsDirect", IsDirect)
        If objJournalPPT.TDecide = "T0" Then
            If objJournalPPT.T0Value <> "" And objJournalPPT.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objJournalPPT.T0Value <> "" And objJournalPPT.T0Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T0Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objJournalPPT.T0Value = "" And objJournalPPT.T0Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T0Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objJournalPPT.TDecide = "T1" Then
            If objJournalPPT.T1Value <> "" And objJournalPPT.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objJournalPPT.T1Value <> "" And objJournalPPT.T1Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T1Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objJournalPPT.T1Value = "" And objJournalPPT.T1Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T1Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objJournalPPT.TDecide = "T2" Then
            If objJournalPPT.T2Value <> "" And objJournalPPT.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objJournalPPT.T2Value <> "" And objJournalPPT.T2Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T2Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objJournalPPT.T2Value = "" And objJournalPPT.T2Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T2Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objJournalPPT.TDecide = "T3" Then
            If objJournalPPT.T3Value <> "" And objJournalPPT.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objJournalPPT.T3Value <> "" And objJournalPPT.T3Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T3Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objJournalPPT.T3Value = "" And objJournalPPT.T3Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T3Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        If objJournalPPT.TDecide = "T4" Then
            If objJournalPPT.T4Value <> "" And objJournalPPT.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            ElseIf objJournalPPT.T4Value <> "" And objJournalPPT.T4Desc = "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", objJournalPPT.T4Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

            ElseIf objJournalPPT.T4Value = "" And objJournalPPT.T4Desc <> "" Then
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", objJournalPPT.T4Desc)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Else
                Parms(0) = New SqlParameter("@TAnalysisCode", objJournalPPT.TDecide)
                Parms(1) = New SqlParameter("@TValue", DBNull.Value)
                Parms(2) = New SqlParameter("@TAnalysisDescp", DBNull.Value)
                Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            End If
        End If
        Return objdb.ExecQuery("[Store].[StoreIssueVoucherTAnalysisSelect]", Parms)
    End Function

    '''' Account Batch Entry Details

    Public Shared Function SaveAccountBatch(ByVal objAccountBatch As JournalPPT) As Integer

        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(15) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@RecuringJournal", objAccountBatch.RecurringJournal)

        Parms(2) = New SqlParameter("@LedgerDescp", objAccountBatch.JournalDescp)
        Parms(3) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(5) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(6) = New SqlParameter("@ModifiedOn", Date.Today)

        Parms(7) = New SqlParameter("@LedgerSetupID", objAccountBatch.LedgerSetUpId)
        Parms(8) = New SqlParameter("@AccBatchID", objAccountBatch.AccBatchID)
        Parms(9) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(10) = New SqlParameter("@LedgerNo", objAccountBatch.LedgerNo)
        Parms(11) = New SqlParameter("@AccBatchTotal", objAccountBatch.BatchTotal)
        Parms(12) = New SqlParameter("@Approved", objAccountBatch.Status)
        Parms(13) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(14) = New SqlParameter("@Jdate", objAccountBatch.JournalDate)
        Parms(15) = New SqlParameter("@RejectedReason", IIf(objAccountBatch.RejectedReason <> String.Empty, objAccountBatch.RejectedReason, DBNull.Value))




        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[AccountBatchInsert]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function

    Public Shared Function UpdateAccountBatch(ByVal objAccountBatch As JournalPPT, ByVal IsApproval As String) As Integer

        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@LedgerNo", objAccountBatch.LedgerNo)

        Parms(2) = New SqlParameter("@LedgerDescp", objAccountBatch.JournalDescp)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(5) = New SqlParameter("@LedgerSetupID", objAccountBatch.LedgerSetupID)

        Parms(6) = New SqlParameter("@AccBatchID", objAccountBatch.AccBatchID)
        Parms(7) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(8) = New SqlParameter("@RecuringJournal", objAccountBatch.RecurringJournal)
        Parms(9) = New SqlParameter("@AccBatchTotal", objAccountBatch.BatchTotal)

        Parms(10) = New SqlParameter("@Approved", objAccountBatch.Status)
        Parms(11) = New SqlParameter("@Jdate", objAccountBatch.JournalDate)
        Parms(12) = New SqlParameter("@IsApproval", IsApproval)
        Parms(13) = New SqlParameter("@RejectedReason", IIf(objAccountBatch.RejectedReason <> String.Empty, objAccountBatch.RejectedReason, DBNull.Value))


        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[AccountBatchUpdate]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function
    Public Shared Function DeleteAccountBatch(ByVal objAccountBatch As JournalPPT) As Integer

        Dim objSQLHelp As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AccBatchID", objAccountBatch.AccBatchID)
        rowsAffected = objSQLHelp.ExecNonQuery("[Accounts].[AccountBatchDelete]", Parms)
        If rowsAffected = 0 Then
            Return rowsAffected
        Else
            Return 1
        End If
    End Function

    ''''For Approval
    'Ledger All module Insert
    Public Shared Function JournalLedgerAllModuleInsert(ByVal objJournalPPT As JournalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(14) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AYear", objJournalPPT.AYear)
        Parms(4) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
        Parms(5) = New SqlParameter("@ModName", "ACCOUNTS")
        Parms(6) = New SqlParameter("@LedgerDate", objJournalPPT.LedgerDate)
        Parms(7) = New SqlParameter("@LedgerType", objJournalPPT.LedgerType)
        Parms(8) = New SqlParameter("@Descp", objJournalPPT.JournalDescp)
        Parms(9) = New SqlParameter("@BatchAmount", objJournalPPT.BatchTotal)
        Parms(10) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(15) = New SqlParameter("@LedgerNo", objJournalPPT.LedgerNo)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Accounts].[LedgerAllModuleInsert_Journal]", Parms)
        Return ds
    End Function
    '''JournalDetailInsert
    Public Shared Function AccountsJournalDetailInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(24) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@LedgerID", objJournalPPT.LedgerID)
            Parms(4) = New SqlParameter("@COAID", objJournalPPT.COAID)
            Parms(5) = New SqlParameter("@DC", objJournalPPT.DC)
            Parms(6) = New SqlParameter("@Value", objJournalPPT.Value)
            Parms(7) = New SqlParameter("@DivID", IIf(objJournalPPT.DivID <> String.Empty, objJournalPPT.DivID, DBNull.Value))
            Parms(8) = New SqlParameter("@YOPID", IIf(objJournalPPT.YOPID <> String.Empty, objJournalPPT.YOPID, DBNull.Value))
            Parms(9) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))
            Parms(10) = New SqlParameter("@VHID", IIf(objJournalPPT.VHID <> String.Empty, objJournalPPT.VHID, DBNull.Value))
            Parms(11) = New SqlParameter("@VHDetailCostCodeID", IIf(objJournalPPT.VHDetailcostCodeID <> String.Empty, objJournalPPT.VHDetailcostCodeID, DBNull.Value))
            Parms(12) = New SqlParameter("@T0", IIf(objJournalPPT.T0 <> String.Empty, objJournalPPT.T0, DBNull.Value))
            Parms(13) = New SqlParameter("@T1", IIf(objJournalPPT.T1 <> String.Empty, objJournalPPT.T1, DBNull.Value))
            Parms(14) = New SqlParameter("@T2", IIf(objJournalPPT.T2 <> String.Empty, objJournalPPT.T2, DBNull.Value))
            Parms(15) = New SqlParameter("@T3", IIf(objJournalPPT.T3 <> String.Empty, objJournalPPT.T3, DBNull.Value))
            Parms(16) = New SqlParameter("@T4", IIf(objJournalPPT.T4 <> String.Empty, objJournalPPT.T4, DBNull.Value))
            Parms(17) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(18) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(19) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(20) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(21) = New SqlParameter("@Descp", IIf(objJournalPPT.COADescp <> String.Empty, objJournalPPT.COADescp, DBNull.Value))
            Parms(22) = New SqlParameter("@Flag", IIf(objJournalPPT.Flag <> String.Empty, objJournalPPT.Flag, DBNull.Value))
            Parms(23) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(24) = New SqlParameter("@StationID", IIf(objJournalPPT.StationID <> String.Empty, objJournalPPT.StationID, DBNull.Value))

            objdb.ExecNonQuery("[Accounts].[JournalDetailInsert_N]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function

    ''VHChargeDetail Insert 

    Public Shared Function AccountsVHChargeDetailInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(18) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateCodeL", objJournalPPT.EstateCodeL)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@VHWSCode", objJournalPPT.VHWScode)
            Parms(5) = New SqlParameter("@Value", objJournalPPT.Value)
            Parms(6) = New SqlParameter("@VHDetailCostCode", objJournalPPT.VHDetailCostCode)
            Parms(7) = New SqlParameter("@ModName", "ACCOUNTS")
            Parms(8) = New SqlParameter("@LedgerType", objJournalPPT.LedgerType)
            Parms(9) = New SqlParameter("@LedgerNo", objJournalPPT.LedgerNo)
            Parms(10) = New SqlParameter("@JDescp", objJournalPPT.JournalDescp)
            Parms(11) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(12) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(13) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(14) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(15) = New SqlParameter("@Type", objJournalPPT.Type)
            Parms(16) = New SqlParameter("@UOMID", objJournalPPT.UOMID)
            Parms(17) = New SqlParameter("@QtyUsed", objJournalPPT.Qty)
            Parms(18) = New SqlParameter("@RefNo", objJournalPPT.RefNo)

            objdb.ExecNonQuery("[Vehicle].[JournalVhChargeDetailInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function
    '''GLLedger Insert, Update
    Public Function GLLedgerCOAIDIsExist(ByVal ObjJournalPPT As JournalPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", ObjJournalPPT.COAID)
        Parms(2) = New SqlParameter("@Ayear", ObjJournalPPT.AYear)

        objExists = objdb.ExecuteScalar("[Accounts].[GLLedgerCOAIDIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function JournalGLLedgerSelect(ByVal ObjJournalPPT As JournalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@COAID", ObjJournalPPT.COAID)
        Parms(2) = New SqlParameter("@AYear", ObjJournalPPT.AYear)
        dt = objdb.ExecQuery("[Accounts].[JournalGLLedgerSelect]", Parms).Tables(0)
        Return dt
    End Function


    Public Shared Function AccountsGLLedgerInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(11) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@COAID", objJournalPPT.COAID)
            Parms(5) = New SqlParameter("@Debit", IIf(objJournalPPT.Debit <> 0, objJournalPPT.Debit, DBNull.Value))
            Parms(6) = New SqlParameter("@Credit", IIf(objJournalPPT.Credit <> 0, objJournalPPT.Credit, DBNull.Value))
            Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(11) = New SqlParameter("@MonthValue", objJournalPPT.MonthCalculation)


            objdb.ExecNonQuery("[Accounts].[JournalGLLedgerInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function
    Public Shared Function JournalGLLedgerUpdate(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(6) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(2) = New SqlParameter("@MonthCalculation", objJournalPPT.MonthCalculation)
            Parms(3) = New SqlParameter("@UpdateDebitCalc", IIf(objJournalPPT.UpdateDebitCalc <> 0, objJournalPPT.UpdateDebitCalc, DBNull.Value))
            Parms(4) = New SqlParameter("@UpdateCreditCalc", IIf(objJournalPPT.UpdateCreditCalc <> 0, objJournalPPT.UpdateCreditCalc, DBNull.Value))
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(6) = New SqlParameter("@COAID", objJournalPPT.COAID)

            objdb.ExecNonQuery("[Accounts].[JournalGLLedgerUpdate]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function



    '''GLSub Insert

    Public Function GLSubBlockIDIsExist(ByVal ObjJournalPPT As JournalPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BlockID", ObjJournalPPT.BlockID)
        Parms(2) = New SqlParameter("@Ayear", ObjJournalPPT.AYear)
        Parms(3) = New SqlParameter("@YOPID", ObjJournalPPT.YOPID)
        Parms(4) = New SqlParameter("@COAID", ObjJournalPPT.COAID)


        objExists = objdb.ExecuteScalar("[Accounts].[GLSubBlockIDIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    Public Function JournalGLSubSelect(ByVal ObjJournalPPT As JournalPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@BlockID", ObjJournalPPT.BlockID)
        Parms(2) = New SqlParameter("@AYear", ObjJournalPPT.AYear)
        Parms(3) = New SqlParameter("@YOPID", ObjJournalPPT.YOPID)


        dt = objdb.ExecQuery("[Accounts].[JournalGLSubSelect]", Parms).Tables(0)
        Return dt
    End Function
    Public Function VHChargedetailLocationEstateCodeSelect(ByVal ObjJournalPPT As JournalPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@VHWScode", ObjJournalPPT.VHWScode)

        ds = objdb.ExecQuery("[Accounts].[VHChargedetailLocationEstateCodeSelect]", Parms)
        Return ds
    End Function

    Public Shared Function AccountsGLSubInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(14) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@COAID", objJournalPPT.COAID)
            Parms(5) = New SqlParameter("@Debit", IIf(objJournalPPT.Debit <> 0, objJournalPPT.Debit, DBNull.Value))
            Parms(6) = New SqlParameter("@Credit", IIf(objJournalPPT.Credit <> 0, objJournalPPT.Credit, DBNull.Value))
            Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(11) = New SqlParameter("@DivID", IIf(objJournalPPT.DivID <> String.Empty, objJournalPPT.DivID, DBNull.Value))
            Parms(12) = New SqlParameter("@YOPID", IIf(objJournalPPT.YOPID <> String.Empty, objJournalPPT.YOPID, DBNull.Value))
            Parms(13) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))
            Parms(14) = New SqlParameter("@MonthValue", objJournalPPT.MonthCalculation)
            objdb.ExecNonQuery("[Accounts].[JournalGLSubInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function

    Public Shared Function JournalGLSubUpdate(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(8) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(2) = New SqlParameter("@MonthCalculation", objJournalPPT.MonthCalculation)
            Parms(3) = New SqlParameter("@UpdateDebitCalc", IIf(objJournalPPT.UpdateDebitCalc <> 0, objJournalPPT.UpdateDebitCalc, DBNull.Value))
            Parms(4) = New SqlParameter("@UpdateCreditCalc", IIf(objJournalPPT.UpdateCreditCalc <> 0, objJournalPPT.UpdateCreditCalc, DBNull.Value))
            Parms(5) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(6) = New SqlParameter("@BlockID", objJournalPPT.BlockID)
            Parms(7) = New SqlParameter("@YOPID", objJournalPPT.YOPID)
            Parms(8) = New SqlParameter("@COAID", objJournalPPT.COAID)

            objdb.ExecNonQuery("[Accounts].[JournalGLSubUpdate]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function
    '''BlockMasterHistoryInsert
    ''' 
    Public Shared Function AccountsBlockMasterHistoryInsert(ByVal objJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim intjournalRowsAffected As Integer = 0
        Dim Parms(10) As SqlParameter
        Try
            Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
            Parms(1) = New SqlParameter("@AYear", objJournalPPT.AYear)
            Parms(2) = New SqlParameter("@AMonth", objJournalPPT.Amonth)
            Parms(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
            Parms(4) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
            Parms(5) = New SqlParameter("@CreatedOn", Date.Today())
            Parms(6) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
            Parms(7) = New SqlParameter("@ModifiedOn", Date.Today())
            Parms(8) = New SqlParameter("@DivID", IIf(objJournalPPT.DivID <> String.Empty, objJournalPPT.DivID, DBNull.Value))
            Parms(9) = New SqlParameter("@YOPID", IIf(objJournalPPT.YOPID <> String.Empty, objJournalPPT.YOPID, DBNull.Value))
            Parms(10) = New SqlParameter("@BlockID", IIf(objJournalPPT.BlockID <> String.Empty, objJournalPPT.BlockID, DBNull.Value))


            objdb.ExecNonQuery("[Accounts].[BlockMasterHistoryInsert]", Parms)
            intjournalRowsAffected = 1
        Catch ex As Exception
            intjournalRowsAffected = 0
        End Try
        Return intjournalRowsAffected
    End Function


    '''Delete Multi entry Datagrid
    ''' 
    Public Function DeleteMultiEntryJournal(ByVal ObjJournalPPT As JournalPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AccJournalID", ObjJournalPPT.AccJournalID)

        rowsAffected = objdb.ExecNonQuery("[Accounts].[AccJournalMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function


End Class

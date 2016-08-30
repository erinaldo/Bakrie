Imports Budget_PPT
Imports Common_PPT
Imports Common_DAL
Imports System.Data.SqlClient
Public Class OperatingBudgetCostDAL

    Public Shared Function OperatingBudgetByCostInsert(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Param(41) As SqlParameter
        Param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Param(2) = New SqlParameter("@BudgetYear", oOperatingBudgetCostPPT.BudgetYear)
        Param(3) = New SqlParameter("@VHDetailCostCodeID", oOperatingBudgetCostPPT.VHDetailCostCodeID)
        Param(4) = New SqlParameter("@VHID", oOperatingBudgetCostPPT.VHID)
        Param(5) = New SqlParameter("@COAID", oOperatingBudgetCostPPT.COAID)
        Param(6) = New SqlParameter("@SubDesc", oOperatingBudgetCostPPT.SubDesc)
        Param(7) = New SqlParameter("@IDR", oOperatingBudgetCostPPT.IDR)
        Param(8) = New SqlParameter("@Percentage", oOperatingBudgetCostPPT.Percentage)
        Param(9) = New SqlParameter("@Unit", oOperatingBudgetCostPPT.Unit)
        Param(10) = New SqlParameter("@Day", oOperatingBudgetCostPPT.Day)
        Param(11) = New SqlParameter("@Qty", oOperatingBudgetCostPPT.Qty)
        Param(12) = New SqlParameter("@Month", oOperatingBudgetCostPPT.Month)

        Param(13) = New SqlParameter("@BudgetJan", oOperatingBudgetCostPPT.BudgetJan)
        Param(14) = New SqlParameter("@BudgetFeb", oOperatingBudgetCostPPT.BudgetFeb)
        Param(15) = New SqlParameter("@BudgetMar", oOperatingBudgetCostPPT.BudgetMar)
        Param(16) = New SqlParameter("@BudgetApr", oOperatingBudgetCostPPT.BudgetApr)
        Param(17) = New SqlParameter("@BudgetMay", oOperatingBudgetCostPPT.BudgetMay)
        Param(18) = New SqlParameter("@BudgetJun", oOperatingBudgetCostPPT.BudgetJun)
        Param(19) = New SqlParameter("@BudgetJul", oOperatingBudgetCostPPT.BudgetJul)
        Param(20) = New SqlParameter("@BudgetAug", oOperatingBudgetCostPPT.BudgetAug)
        Param(21) = New SqlParameter("@BudgetSep", oOperatingBudgetCostPPT.BudgetSep)
        Param(22) = New SqlParameter("@BudgetOct", oOperatingBudgetCostPPT.BudgetOct)
        Param(23) = New SqlParameter("@BudgetNov", oOperatingBudgetCostPPT.BudgetNov)
        Param(24) = New SqlParameter("@BudgetDec", oOperatingBudgetCostPPT.BudgetDec)

        Param(25) = New SqlParameter("@RevJan", oOperatingBudgetCostPPT.RevJan)
        Param(26) = New SqlParameter("@RevFeb", oOperatingBudgetCostPPT.RevFeb)
        Param(27) = New SqlParameter("@RevMar", oOperatingBudgetCostPPT.RevMar)
        Param(28) = New SqlParameter("@RevApr", oOperatingBudgetCostPPT.RevApr)
        Param(29) = New SqlParameter("@RevMay", oOperatingBudgetCostPPT.RevMay)
        Param(30) = New SqlParameter("@RevJun", oOperatingBudgetCostPPT.RevJun)
        Param(31) = New SqlParameter("@RevJul", oOperatingBudgetCostPPT.RevJul)
        Param(32) = New SqlParameter("@RevAug", oOperatingBudgetCostPPT.RevAug)
        Param(33) = New SqlParameter("@RevSep", oOperatingBudgetCostPPT.RevSep)
        Param(34) = New SqlParameter("@RevOct", oOperatingBudgetCostPPT.RevOct)
        Param(35) = New SqlParameter("@RevNov", oOperatingBudgetCostPPT.RevNov)
        Param(36) = New SqlParameter("@RevDec", oOperatingBudgetCostPPT.RevDec)
        Param(37) = New SqlParameter("@BudgetTotal", oOperatingBudgetCostPPT.BudgetTotal)
        'Param(38) = New SqlParameter("@Status", oOperatingBudgetCostPPT.Status)

        Param(38) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Param(39) = New SqlParameter("@CreatedOn", Date.Today())
        Param(40) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(41) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[OperatingBudgetByCostInsert]", Param)
        Return ds
    End Function


    Public Shared Function GetVHGroup(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        'Parms(0) = New SqlParameter("@COACode", IIf(oOperatingBudgetCostPPT.VHWSCode <> String.Empty, oOperatingBudgetCostPPT.VHWSCode, DBNull.Value))
        Parms(0) = New SqlParameter("@COADescp", IIf(oOperatingBudgetCostPPT.COADescp <> String.Empty, oOperatingBudgetCostPPT.COADescp, DBNull.Value))
        'Parms(1) = New SqlParameter("@COAID", IIf(oOperatingBudgetCostPPT.COAID <> String.Empty, oOperatingBudgetCostPPT.COAID, DBNull.Value))
        Parms(1) = New SqlParameter("@COAGroup", IIf(oOperatingBudgetCostPPT.COACode <> String.Empty, oOperatingBudgetCostPPT.COACode, DBNull.Value))
        Parms(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(3) = New SqlParameter("@IsDirect", IsDirect)
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Budget].[OperatingBudgetCostVHGroupSelect]", Parms)
        Return ds
    End Function

    Public Shared Function OperatingBudgetByCostUpdate(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Param(41) As SqlParameter
        Param(0) = New SqlParameter("@OperatingBudgetByCostID", oOperatingBudgetCostPPT.OperatingBudgetByCostID)
        Param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Param(2) = New SqlParameter("@BudgetYear", oOperatingBudgetCostPPT.BudgetYear)
        Param(3) = New SqlParameter("@VHDetailCostCodeID", oOperatingBudgetCostPPT.VHDetailCostCodeID)
        Param(4) = New SqlParameter("@VHID", oOperatingBudgetCostPPT.VHID)
        Param(5) = New SqlParameter("@COAID", oOperatingBudgetCostPPT.COAID)
        Param(6) = New SqlParameter("@SubDesc", oOperatingBudgetCostPPT.SubDesc)
        Param(7) = New SqlParameter("@IDR", oOperatingBudgetCostPPT.IDR)
        Param(8) = New SqlParameter("@Percentage", oOperatingBudgetCostPPT.Percentage)
        Param(9) = New SqlParameter("@Unit", oOperatingBudgetCostPPT.Unit)
        Param(10) = New SqlParameter("@Day", oOperatingBudgetCostPPT.Day)
        Param(11) = New SqlParameter("@Qty", oOperatingBudgetCostPPT.Qty)
        Param(12) = New SqlParameter("@Month", oOperatingBudgetCostPPT.Month)

        Param(13) = New SqlParameter("@BudgetJan", oOperatingBudgetCostPPT.BudgetJan)
        Param(14) = New SqlParameter("@BudgetFeb", oOperatingBudgetCostPPT.BudgetFeb)
        Param(15) = New SqlParameter("@BudgetMar", oOperatingBudgetCostPPT.BudgetMar)
        Param(16) = New SqlParameter("@BudgetApr", oOperatingBudgetCostPPT.BudgetApr)
        Param(17) = New SqlParameter("@BudgetMay", oOperatingBudgetCostPPT.BudgetMay)
        Param(18) = New SqlParameter("@BudgetJun", oOperatingBudgetCostPPT.BudgetJun)
        Param(19) = New SqlParameter("@BudgetJul", oOperatingBudgetCostPPT.BudgetJul)
        Param(20) = New SqlParameter("@BudgetAug", oOperatingBudgetCostPPT.BudgetAug)
        Param(21) = New SqlParameter("@BudgetSep", oOperatingBudgetCostPPT.BudgetSep)
        Param(22) = New SqlParameter("@BudgetOct", oOperatingBudgetCostPPT.BudgetOct)
        Param(23) = New SqlParameter("@BudgetNov", oOperatingBudgetCostPPT.BudgetNov)
        Param(24) = New SqlParameter("@BudgetDec", oOperatingBudgetCostPPT.BudgetDec)

        Param(25) = New SqlParameter("@RevJan", oOperatingBudgetCostPPT.RevJan)
        Param(26) = New SqlParameter("@RevFeb", oOperatingBudgetCostPPT.RevFeb)
        Param(27) = New SqlParameter("@RevMar", oOperatingBudgetCostPPT.RevMar)
        Param(28) = New SqlParameter("@RevApr", oOperatingBudgetCostPPT.RevApr)
        Param(29) = New SqlParameter("@RevMay", oOperatingBudgetCostPPT.RevMay)
        Param(30) = New SqlParameter("@RevJun", oOperatingBudgetCostPPT.RevJun)
        Param(31) = New SqlParameter("@RevJul", oOperatingBudgetCostPPT.RevJul)
        Param(32) = New SqlParameter("@RevAug", oOperatingBudgetCostPPT.RevAug)
        Param(33) = New SqlParameter("@RevSep", oOperatingBudgetCostPPT.RevSep)
        Param(34) = New SqlParameter("@RevOct", oOperatingBudgetCostPPT.RevOct)
        Param(35) = New SqlParameter("@RevNov", oOperatingBudgetCostPPT.RevNov)
        Param(36) = New SqlParameter("@RevDec", oOperatingBudgetCostPPT.RevDec)
        Param(37) = New SqlParameter("@BudgetTotal", oOperatingBudgetCostPPT.BudgetTotal)
        Param(38) = New SqlParameter("@Status", oOperatingBudgetCostPPT.Status)
        Param(39) = New SqlParameter("VersionNo", oOperatingBudgetCostPPT.VersionNo)
        Param(40) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(41) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[OperatingBudgetByCostUpdate]", Param)
        Return ds
    End Function
    Public Shared Function OperatingBudgetByCostSelect() As DataTable
        Dim dt As New DataTable
        Dim Objdb As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("BudgetYear", GlobalPPT.intLoginYear)
        dt = Objdb.ExecQuery("[Budget].[OperatingBudgetByCostSelect]", param).Tables(0)
        Return dt

    End Function
    Public Shared Function OperatingBudgetByCostDelete(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As Integer
        Dim objdb As New SQLHelp
        Dim param(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        param(0) = New SqlParameter("@OperatingBudgetByCostID ", oOperatingBudgetCostPPT.OperatingBudgetByCostID)

        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        rowsAffected = objdb.ExecNonQuery("[Budget].[OperatingBudgetByCostDelete]", param)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Shared Function OperatingCostViewSearch(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(2) As SqlParameter
        If oOperatingBudgetCostPPT.COACode <> "" Then
            param(0) = New SqlParameter("@COACode", oOperatingBudgetCostPPT.COACode)
        Else
            param(0) = New SqlParameter("@COACode", DBNull.Value)
        End If
        If oOperatingBudgetCostPPT.VHNo <> "" Then
            param(1) = New SqlParameter("@VHNo", oOperatingBudgetCostPPT.VHNo)
        Else
            param(1) = New SqlParameter("@VHNo", DBNull.Value)
        End If
       
        param(2) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Budget].[OperatingCostViewSearch]", param)
        Return ds
    End Function
    Public Function OperatingBudgetByCostSelect_MultipleEntry(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim dt As New DataTable

        Parms(0) = New SqlParameter("@VHNo", oOperatingBudgetCostPPT.VHNo)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)


        dt = objdb.ExecQuery("[Budget].[OperatingBudgetByCostSelect_MultipleEntry]", Parms).Tables(0)
        Return dt
    End Function

    Public Shared Function OperatingBudgetByCostDriverFill(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet

        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@VHID", oOperatingBudgetCostPPT.VHID)

        ds = objdb.ExecQuery("[Budget].[OperatingBudgetByCostDriverFill]", param)
        Return ds
    End Function
    Public Shared Function AcctlookupSearch(ByVal oOperatingBudgetCostPPT As OperatingBudgetCostPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oOperatingBudgetCostPPT.COACode <> "" And oOperatingBudgetCostPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oOperatingBudgetCostPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oOperatingBudgetCostPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oOperatingBudgetCostPPT.COACode <> "" And oOperatingBudgetCostPPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oOperatingBudgetCostPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oOperatingBudgetCostPPT.COACode = "" And oOperatingBudgetCostPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oOperatingBudgetCostPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Param(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Param)

    End Function
End Class

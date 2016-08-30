Imports System.Data.SqlClient
Imports Common_PPT
Imports Budget_PPT
Imports Common_DAL

Public Class CapitalExpenditureDAL
    Public Shared Function CapitalExpendCOACodeIsvalid(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@COACode", oCapitalExpenditurePPT.COACode)

        ds = objdb.ExecQuery("[Budget].[AdminExpendCOACodeIsvalid]", param)
        Return ds
    End Function
    Public Shared Function AcctlookupSearch(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oCapitalExpenditurePPT.COACode <> "" And oCapitalExpenditurePPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oCapitalExpenditurePPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oCapitalExpenditurePPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oCapitalExpenditurePPT.COACode <> "" And oCapitalExpenditurePPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oCapitalExpenditurePPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oCapitalExpenditurePPT.COACode = "" And oCapitalExpenditurePPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oCapitalExpenditurePPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Param(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Param)
    End Function

    Public Shared Function CapitalExpenditureInsert(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim param(53) As SqlParameter
        Dim ds As New DataSet
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        param(2) = New SqlParameter("@BudgetYear", oCapitalExpenditurePPT.BudgetYear)
        param(3) = New SqlParameter("@COAId", oCapitalExpenditurePPT.COAId)
        param(4) = New SqlParameter("@Price", oCapitalExpenditurePPT.Price)
        param(5) = New SqlParameter("@Remarks", oCapitalExpenditurePPT.Remarks)

        param(6) = New SqlParameter("@BudgetJan", oCapitalExpenditurePPT.BudgetJan)
        param(7) = New SqlParameter("@BudgetFeb", oCapitalExpenditurePPT.BudgetFeb)
        param(8) = New SqlParameter("@BudgetMar", oCapitalExpenditurePPT.BudgetMar)
        param(9) = New SqlParameter("@BudgetApr", oCapitalExpenditurePPT.BudgetApr)
        param(10) = New SqlParameter("@BudgetMay", oCapitalExpenditurePPT.BudgetMay)
        param(11) = New SqlParameter("@BudgetJun", oCapitalExpenditurePPT.BudgetJun)
        param(12) = New SqlParameter("@BudgetJul", oCapitalExpenditurePPT.BudgetJul)
        param(13) = New SqlParameter("@BudgetAug", oCapitalExpenditurePPT.BudgetAug)
        param(14) = New SqlParameter("@BudgetSep", oCapitalExpenditurePPT.BudgetSep)
        param(15) = New SqlParameter("@BudgetOct", oCapitalExpenditurePPT.BudgetOct)
        param(16) = New SqlParameter("@BudgetNov", oCapitalExpenditurePPT.BudgetNov)
        param(17) = New SqlParameter("@BudgetDec", oCapitalExpenditurePPT.BudgetDec)


        If oCapitalExpenditurePPT.RevJan = Nothing Then
            param(18) = New SqlParameter("@RevJan", System.DBNull.Value)
        Else
            param(18) = New SqlParameter("@RevJan", oCapitalExpenditurePPT.RevJan)
        End If
        If oCapitalExpenditurePPT.RevFeb = Nothing Then
            param(19) = New SqlParameter("@RevFeb", System.DBNull.Value)
        Else
            param(19) = New SqlParameter("@RevFeb", oCapitalExpenditurePPT.RevFeb)
        End If
        If oCapitalExpenditurePPT.RevMar = Nothing Then
            param(20) = New SqlParameter("@RevMar", System.DBNull.Value)
        Else
            param(20) = New SqlParameter("@RevMar", oCapitalExpenditurePPT.RevMar)
        End If
        If oCapitalExpenditurePPT.RevApr = Nothing Then
            param(21) = New SqlParameter("@RevApr", System.DBNull.Value)
        Else
            param(21) = New SqlParameter("@RevApr", oCapitalExpenditurePPT.RevApr)
        End If
        If oCapitalExpenditurePPT.RevMay = Nothing Then
            param(22) = New SqlParameter("@RevMay", System.DBNull.Value)
        Else
            param(22) = New SqlParameter("@RevMay", oCapitalExpenditurePPT.RevMay)
        End If
        If oCapitalExpenditurePPT.RevJun = Nothing Then
            param(23) = New SqlParameter("@RevJun", System.DBNull.Value)
        Else
            param(23) = New SqlParameter("@RevJun", oCapitalExpenditurePPT.RevJun)
        End If
        If oCapitalExpenditurePPT.RevJul = Nothing Then
            param(24) = New SqlParameter("@RevJul", System.DBNull.Value)
        Else
            param(24) = New SqlParameter("@RevJul", oCapitalExpenditurePPT.RevJul)
        End If
        If oCapitalExpenditurePPT.RevAug = Nothing Then
            param(25) = New SqlParameter("@RevAug", System.DBNull.Value)
        Else
            param(25) = New SqlParameter("@RevAug", oCapitalExpenditurePPT.RevAug)
        End If
        If oCapitalExpenditurePPT.RevSep = Nothing Then
            param(26) = New SqlParameter("@RevSep", System.DBNull.Value)
        Else
            param(26) = New SqlParameter("@RevSep", oCapitalExpenditurePPT.RevSep)
        End If
        If oCapitalExpenditurePPT.RevOct = Nothing Then
            param(27) = New SqlParameter("@RevOct", System.DBNull.Value)
        Else
            param(27) = New SqlParameter("@RevOct", oCapitalExpenditurePPT.RevOct)
        End If
        If oCapitalExpenditurePPT.RevNov = Nothing Then
            param(28) = New SqlParameter("@RevNov", System.DBNull.Value)
        Else
            param(28) = New SqlParameter("@RevNov", oCapitalExpenditurePPT.RevNov)
        End If
        If oCapitalExpenditurePPT.RevDec = Nothing Then
            param(29) = New SqlParameter("@RevDec", System.DBNull.Value)
        Else
            param(29) = New SqlParameter("@RevDec", oCapitalExpenditurePPT.RevDec)
        End If

        If oCapitalExpenditurePPT.PinkSlipJan = Nothing Then
            param(30) = New SqlParameter("@PinkJan", System.DBNull.Value)
        Else
            param(30) = New SqlParameter("@PinkJan", oCapitalExpenditurePPT.PinkSlipJan)
        End If
        If oCapitalExpenditurePPT.PinkSlipFeb = Nothing Then
            param(31) = New SqlParameter("@PinkFeb", System.DBNull.Value)
        Else
            param(31) = New SqlParameter("@PinkFeb", oCapitalExpenditurePPT.PinkSlipFeb)
        End If
        If oCapitalExpenditurePPT.PinkSlipMar = Nothing Then
            param(32) = New SqlParameter("@PinkMar", System.DBNull.Value)
        Else
            param(32) = New SqlParameter("@PinkMar", oCapitalExpenditurePPT.PinkSlipMar)
        End If
        If oCapitalExpenditurePPT.PinkSlipApr = Nothing Then
            param(33) = New SqlParameter("@PinkApr", System.DBNull.Value)
        Else
            param(33) = New SqlParameter("@PinkApr", oCapitalExpenditurePPT.PinkSlipApr)
        End If
        If oCapitalExpenditurePPT.PinkSlipMay = Nothing Then
            param(34) = New SqlParameter("@PinkMay", System.DBNull.Value)
        Else
            param(34) = New SqlParameter("@PinkMay", oCapitalExpenditurePPT.PinkSlipMay)
        End If
        If oCapitalExpenditurePPT.PinkSlipJun = Nothing Then
            param(35) = New SqlParameter("@PinkJun", System.DBNull.Value)
        Else
            param(35) = New SqlParameter("@PinkJun", oCapitalExpenditurePPT.PinkSlipJun)
        End If
        If oCapitalExpenditurePPT.PinkSlipJul = Nothing Then
            param(36) = New SqlParameter("@PinkJul", System.DBNull.Value)
        Else
            param(36) = New SqlParameter("@PinkJul", oCapitalExpenditurePPT.PinkSlipJul)
        End If
        If oCapitalExpenditurePPT.PinkSlipAug = Nothing Then
            param(37) = New SqlParameter("@PinkAug", System.DBNull.Value)
        Else
            param(37) = New SqlParameter("@PinkAug", oCapitalExpenditurePPT.PinkSlipAug)
        End If
        If oCapitalExpenditurePPT.PinkSlipSep = Nothing Then
            param(38) = New SqlParameter("@PinkSep", System.DBNull.Value)
        Else
            param(38) = New SqlParameter("@PinkSep", oCapitalExpenditurePPT.PinkSlipSep)

        End If
        If oCapitalExpenditurePPT.PinkSlipOct = Nothing Then
            param(39) = New SqlParameter("@PinkOct", System.DBNull.Value)
        Else
            param(39) = New SqlParameter("@PinkOct", oCapitalExpenditurePPT.PinkSlipOct)
        End If
        If oCapitalExpenditurePPT.PinkSlipNov = Nothing Then
            param(40) = New SqlParameter("@PinkNov", System.DBNull.Value)
        Else
            param(40) = New SqlParameter("@PinkNov", oCapitalExpenditurePPT.PinkSlipNov)
        End If
        If oCapitalExpenditurePPT.PinkSlipDec = Nothing Then
            param(41) = New SqlParameter("@PinkDec", System.DBNull.Value)
        Else
            param(41) = New SqlParameter("@PinkDec", oCapitalExpenditurePPT.PinkSlipDec)
        End If

        param(42) = New SqlParameter("@BudgetTotal", oCapitalExpenditurePPT.BudgetTotal)

        If oCapitalExpenditurePPT.SubDesc = Nothing Then
            param(43) = New SqlParameter("@SubDesc", System.DBNull.Value)
        Else
            param(43) = New SqlParameter("@SubDesc", oCapitalExpenditurePPT.SubDesc)
        End If

        If oCapitalExpenditurePPT.Qty = Nothing Then
            param(44) = New SqlParameter("@Qty", System.DBNull.Value)
        Else
            param(44) = New SqlParameter("@Qty", oCapitalExpenditurePPT.Qty)
        End If
        If oCapitalExpenditurePPT.Cost = Nothing Then
            param(45) = New SqlParameter("@Cost", System.DBNull.Value)
        Else
            param(45) = New SqlParameter("@Cost", oCapitalExpenditurePPT.Cost)
        End If
        If oCapitalExpenditurePPT.Day = Nothing Then
            param(46) = New SqlParameter("@Day", System.DBNull.Value)
        Else
            param(46) = New SqlParameter("@Day", oCapitalExpenditurePPT.Day)
        End If
        If oCapitalExpenditurePPT.Month = Nothing Then
            param(47) = New SqlParameter("@Month", System.DBNull.Value)
        Else
            param(47) = New SqlParameter("@Month", oCapitalExpenditurePPT.Month)
        End If
        If oCapitalExpenditurePPT.Percentage = Nothing Then
            param(48) = New SqlParameter("@Percentage", System.DBNull.Value)
        Else
            param(48) = New SqlParameter("@Percentage", oCapitalExpenditurePPT.Percentage)
        End If

        param(49) = New SqlParameter("@BudgetType", "CapitalExpend")

        param(50) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        param(51) = New SqlParameter("@CreatedOn", Date.Today())
        param(52) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(53) = New SqlParameter("@ModifiedOn", Date.Today())


        ds = objdb.ExecQuery("[Budget].[ExpBudAdminExpendInsert]", param)
        Return ds

    End Function
    Public Shared Function CapitalExpendUpdate(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim param(47) As SqlParameter
        Dim ds As New DataSet
        param(0) = New SqlParameter("@BudgetYear", oCapitalExpenditurePPT.BudgetYear)
        param(1) = New SqlParameter("@COAId", oCapitalExpenditurePPT.COAId)
        param(2) = New SqlParameter("@EstateID ", GlobalPPT.strEstateID)
        param(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        param(4) = New SqlParameter("@Remarks", oCapitalExpenditurePPT.Remarks)
        param(5) = New SqlParameter("@Amount", oCapitalExpenditurePPT.Cost)

        param(6) = New SqlParameter("@BudgetJan", oCapitalExpenditurePPT.BudgetJan)
        param(7) = New SqlParameter("@BudgetFeb", oCapitalExpenditurePPT.BudgetFeb)
        param(8) = New SqlParameter("@BudgetMar", oCapitalExpenditurePPT.BudgetMar)
        param(9) = New SqlParameter("@BudgetApr", oCapitalExpenditurePPT.BudgetApr)
        param(10) = New SqlParameter("@BudgetMay", oCapitalExpenditurePPT.BudgetMay)
        param(11) = New SqlParameter("@BudgetJun", oCapitalExpenditurePPT.BudgetJun)
        param(12) = New SqlParameter("@BudgetJul", oCapitalExpenditurePPT.BudgetJul)
        param(13) = New SqlParameter("@BudgetAug", oCapitalExpenditurePPT.BudgetAug)
        param(14) = New SqlParameter("@BudgetSep", oCapitalExpenditurePPT.BudgetSep)
        param(15) = New SqlParameter("@BudgetOct", oCapitalExpenditurePPT.BudgetOct)
        param(16) = New SqlParameter("@BudgetNov", oCapitalExpenditurePPT.BudgetNov)
        param(17) = New SqlParameter("@BudgetDec", oCapitalExpenditurePPT.BudgetDec)

        param(18) = New SqlParameter("@RevJan", oCapitalExpenditurePPT.RevJan)
        param(19) = New SqlParameter("@RevFeb", oCapitalExpenditurePPT.RevFeb)
        param(20) = New SqlParameter("@RevMar", oCapitalExpenditurePPT.RevMar)
        param(21) = New SqlParameter("@RevApr", oCapitalExpenditurePPT.RevApr)
        param(22) = New SqlParameter("@RevMay", oCapitalExpenditurePPT.RevMay)
        param(23) = New SqlParameter("@RevJun", oCapitalExpenditurePPT.RevJun)
        param(24) = New SqlParameter("@RevJul", oCapitalExpenditurePPT.RevJul)
        param(25) = New SqlParameter("@RevAug", oCapitalExpenditurePPT.RevAug)
        param(26) = New SqlParameter("@RevSep", oCapitalExpenditurePPT.RevSep)
        param(27) = New SqlParameter("@RevOct", oCapitalExpenditurePPT.RevOct)
        param(28) = New SqlParameter("@RevNov", oCapitalExpenditurePPT.RevNov)
        param(29) = New SqlParameter("@RevDec", oCapitalExpenditurePPT.RevDec)

        param(30) = New SqlParameter("@PinkSlipJan", oCapitalExpenditurePPT.PinkSlipJan)
        param(31) = New SqlParameter("@PinkSlipFeb", oCapitalExpenditurePPT.PinkSlipFeb)
        param(32) = New SqlParameter("@PinkSlipMar", oCapitalExpenditurePPT.PinkSlipMar)
        param(33) = New SqlParameter("@PinkSlipApr", oCapitalExpenditurePPT.PinkSlipApr)
        param(34) = New SqlParameter("@PinkSlipMay", oCapitalExpenditurePPT.PinkSlipMay)
        param(35) = New SqlParameter("@PinkSlipJun", oCapitalExpenditurePPT.PinkSlipJun)
        param(36) = New SqlParameter("@PinkSlipJul", oCapitalExpenditurePPT.PinkSlipJul)
        param(37) = New SqlParameter("@PinkSlipAug", oCapitalExpenditurePPT.PinkSlipAug)
        param(38) = New SqlParameter("@PinkSlipSep", oCapitalExpenditurePPT.PinkSlipSep)
        param(39) = New SqlParameter("@PinkSlipOct", oCapitalExpenditurePPT.PinkSlipOct)
        param(40) = New SqlParameter("@PinkSlipNov", oCapitalExpenditurePPT.PinkSlipNov)
        param(41) = New SqlParameter("@PinkSlipDec", oCapitalExpenditurePPT.PinkSlipDec)
        param(42) = New SqlParameter("@BudgetTotal", oCapitalExpenditurePPT.BudgetTotal)


        param(43) = New SqlParameter("@VersionNo", oCapitalExpenditurePPT.VersionNo)
        param(44) = New SqlParameter("@Status", oCapitalExpenditurePPT.Status)
        param(45) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(46) = New SqlParameter("@ModifiedOn", Date.Today())
        param(47) = New SqlParameter("@CapitalExpendId", oCapitalExpenditurePPT.BudgetID)

        ds = objdb.ExecQuery("[Budget].[CapitalExpendUpdate]", param)
        Return ds
    End Function

    Public Shared Function CapitalExpendSelect(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim param(2) As SqlParameter
        Dim dt As New DataTable

        'param(0) = New SqlParameter("@COAId", IIf(oCapitalExpenditurePPT.COAId <> String.Empty, oCapitalExpenditurePPT.COAId, DBNull.Value))
        'param(1) = New SqlParameter("@COADescp", IIf(oCapitalExpenditurePPT.COADescp <> String.Empty, oCapitalExpenditurePPT.COADescp, DBNull.Value))
     
        'param(0) = New SqlParameter("@COAId", oCapitalExpenditurePPT.COAId)
        'param(1) = New SqlParameter("@COACode", oCapitalExpenditurePPT.COACode)
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        If oCapitalExpenditurePPT.BudgetYear <> Nothing Then
            param(1) = New SqlParameter("@Budgetyear", oCapitalExpenditurePPT.BudgetYear)
        Else
            param(1) = New SqlParameter("@Budgetyear", GlobalPPT.intLoginYear)
        End If

        If oCapitalExpenditurePPT.COACode <> "" Then
            param(2) = New SqlParameter("@COACode", oCapitalExpenditurePPT.COACode)
        Else
            param(2) = New SqlParameter("@COACode", DBNull.Value)
        End If
        dt = objdb.ExecQuery("[Budget].[CapitalExpenditureSelect]", param).Tables(0)
        Return dt
    End Function
    Public Shared Function CapitalExpenditureSelect_Multi(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim param(4) As SqlParameter
        Dim dt As New DataTable
        param(0) = New SqlParameter("@CapitalExpendID", oCapitalExpenditurePPT.BudgetID)
        param(1) = New SqlParameter("@COAID", oCapitalExpenditurePPT.COAId)
        param(2) = New SqlParameter("@COACode", oCapitalExpenditurePPT.COACode)
        param(3) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(4) = New SqlParameter("@Budgetyear", GlobalPPT.intLoginYear)
        dt = objdb.ExecQuery("[Budget].[CapitalExpenditureSelect_Multi]", param).Tables(0)
        Return dt
    End Function
    Public Shared Function CapitalExpendDelete(ByVal oCapitalExpenditurePPT As CapitalExpenditurePPT) As DataSet
        '    Dim objdb As New SQLHelp
        '    Dim param(1) As SqlParameter
        '    Dim ds As New DataSet
        '    param(0) = New SqlParameter("@CapitalExpendID", oCapitalExpenditurePPT.BudgetID)
        '    param(1) = New SqlParameter("EstateID", GlobalPPT.strEstateID)
        '    ds = objdb.ExecQuery("[Budget].[CapitalExpendDelete]", param)
        '    Return ds
        'End Function
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(4) As SqlParameter
        param(0) = New SqlParameter("@BudgetID ", oCapitalExpenditurePPT.BudgetID)
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(2) = New SqlParameter("@COAId ", oCapitalExpenditurePPT.COAId)
        param(3) = New SqlParameter("@VersionNo ", oCapitalExpenditurePPT.VersionNo)
        param(4) = New SqlParameter("@BudgetYear ", oCapitalExpenditurePPT.BudgetYear)
        ds = objdb.ExecQuery("[Budget].[CapitalExpendDelete]", param)
        Return ds
    End Function

End Class

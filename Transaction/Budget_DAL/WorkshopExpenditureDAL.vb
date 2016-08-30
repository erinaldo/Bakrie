Imports System.Data.SqlClient
Imports Common_PPT
Imports Budget_PPT
Imports Common_DAL
Public Class WorkshopExpenditureDAL
    Public Shared Function WorkshopExpendCOACodeIsvalid(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@COACode", oWorkshopExpenditurePPT.COACode)

        ds = objdb.ExecQuery("[Budget].[AdminExpendCOACodeIsvalid]", param)
        Return ds
    End Function
    Public Shared Function AcctlookupSearch(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oWorkshopExpenditurePPT.COACode <> "" And oWorkshopExpenditurePPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oWorkshopExpenditurePPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oWorkshopExpenditurePPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oWorkshopExpenditurePPT.COACode <> "" And oWorkshopExpenditurePPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oWorkshopExpenditurePPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oWorkshopExpenditurePPT.COACode = "" And oWorkshopExpenditurePPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oWorkshopExpenditurePPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Param(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Param)
    End Function

    Public Shared Function WorkshopExpenditureInsert(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim param(53) As SqlParameter
        Dim ds As New DataSet
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        param(2) = New SqlParameter("@BudgetYear", oWorkshopExpenditurePPT.BudgetYear)
        param(3) = New SqlParameter("@COAId", oWorkshopExpenditurePPT.COAId)
        param(4) = New SqlParameter("@Price", oWorkshopExpenditurePPT.Price)
        param(5) = New SqlParameter("@Remarks", oWorkshopExpenditurePPT.Remarks)

        param(6) = New SqlParameter("@BudgetJan", oWorkshopExpenditurePPT.BudgetJan)
        param(7) = New SqlParameter("@BudgetFeb", oWorkshopExpenditurePPT.BudgetFeb)
        param(8) = New SqlParameter("@BudgetMar", oWorkshopExpenditurePPT.BudgetMar)
        param(9) = New SqlParameter("@BudgetApr", oWorkshopExpenditurePPT.BudgetApr)
        param(10) = New SqlParameter("@BudgetMay", oWorkshopExpenditurePPT.BudgetMay)
        param(11) = New SqlParameter("@BudgetJun", oWorkshopExpenditurePPT.BudgetJun)
        param(12) = New SqlParameter("@BudgetJul", oWorkshopExpenditurePPT.BudgetJul)
        param(13) = New SqlParameter("@BudgetAug", oWorkshopExpenditurePPT.BudgetAug)
        param(14) = New SqlParameter("@BudgetSep", oWorkshopExpenditurePPT.BudgetSep)
        param(15) = New SqlParameter("@BudgetOct", oWorkshopExpenditurePPT.BudgetOct)
        param(16) = New SqlParameter("@BudgetNov", oWorkshopExpenditurePPT.BudgetNov)
        param(17) = New SqlParameter("@BudgetDec", oWorkshopExpenditurePPT.BudgetDec)


        If oWorkshopExpenditurePPT.RevJan = Nothing Then
            param(18) = New SqlParameter("@RevJan", System.DBNull.Value)
        Else
            param(18) = New SqlParameter("@RevJan", oWorkshopExpenditurePPT.RevJan)
        End If
        If oWorkshopExpenditurePPT.RevFeb = Nothing Then
            param(19) = New SqlParameter("@RevFeb", System.DBNull.Value)
        Else
            param(19) = New SqlParameter("@RevFeb", oWorkshopExpenditurePPT.RevFeb)
        End If
        If oWorkshopExpenditurePPT.RevMar = Nothing Then
            param(20) = New SqlParameter("@RevMar", System.DBNull.Value)
        Else
            param(20) = New SqlParameter("@RevMar", oWorkshopExpenditurePPT.RevMar)
        End If
        If oWorkshopExpenditurePPT.RevApr = Nothing Then
            param(21) = New SqlParameter("@RevApr", System.DBNull.Value)
        Else
            param(21) = New SqlParameter("@RevApr", oWorkshopExpenditurePPT.RevApr)
        End If
        If oWorkshopExpenditurePPT.RevMay = Nothing Then
            param(22) = New SqlParameter("@RevMay", System.DBNull.Value)
        Else
            param(22) = New SqlParameter("@RevMay", oWorkshopExpenditurePPT.RevMay)
        End If
        If oWorkshopExpenditurePPT.RevJun = Nothing Then
            param(23) = New SqlParameter("@RevJun", System.DBNull.Value)
        Else
            param(23) = New SqlParameter("@RevJun", oWorkshopExpenditurePPT.RevJun)
        End If
        If oWorkshopExpenditurePPT.RevJul = Nothing Then
            param(24) = New SqlParameter("@RevJul", System.DBNull.Value)
        Else
            param(24) = New SqlParameter("@RevJul", oWorkshopExpenditurePPT.RevJul)
        End If
        If oWorkshopExpenditurePPT.RevAug = Nothing Then
            param(25) = New SqlParameter("@RevAug", System.DBNull.Value)
        Else
            param(25) = New SqlParameter("@RevAug", oWorkshopExpenditurePPT.RevAug)
        End If
        If oWorkshopExpenditurePPT.RevSep = Nothing Then
            param(26) = New SqlParameter("@RevSep", System.DBNull.Value)
        Else
            param(26) = New SqlParameter("@RevSep", oWorkshopExpenditurePPT.RevSep)
        End If
        If oWorkshopExpenditurePPT.RevOct = Nothing Then
            param(27) = New SqlParameter("@RevOct", System.DBNull.Value)
        Else
            param(27) = New SqlParameter("@RevOct", oWorkshopExpenditurePPT.RevOct)
        End If
        If oWorkshopExpenditurePPT.RevNov = Nothing Then
            param(28) = New SqlParameter("@RevNov", System.DBNull.Value)
        Else
            param(28) = New SqlParameter("@RevNov", oWorkshopExpenditurePPT.RevNov)
        End If
        If oWorkshopExpenditurePPT.RevDec = Nothing Then
            param(29) = New SqlParameter("@RevDec", System.DBNull.Value)
        Else
            param(29) = New SqlParameter("@RevDec", oWorkshopExpenditurePPT.RevDec)
        End If

        If oWorkshopExpenditurePPT.PinkJan = Nothing Then
            param(30) = New SqlParameter("@PinkJan", System.DBNull.Value)
        Else
            param(30) = New SqlParameter("@PinkJan", oWorkshopExpenditurePPT.PinkJan)
        End If
        If oWorkshopExpenditurePPT.PinkFeb = Nothing Then
            param(31) = New SqlParameter("@PinkFeb", System.DBNull.Value)
        Else
            param(31) = New SqlParameter("@PinkFeb", oWorkshopExpenditurePPT.PinkFeb)
        End If
        If oWorkshopExpenditurePPT.PinkMar = Nothing Then
            param(32) = New SqlParameter("@PinkMar", System.DBNull.Value)
        Else
            param(32) = New SqlParameter("@PinkMar", oWorkshopExpenditurePPT.PinkMar)
        End If
        If oWorkshopExpenditurePPT.PinkApr = Nothing Then
            param(33) = New SqlParameter("@PinkApr", System.DBNull.Value)
        Else
            param(33) = New SqlParameter("@PinkApr", oWorkshopExpenditurePPT.PinkApr)
        End If
        If oWorkshopExpenditurePPT.PinkMay = Nothing Then
            param(34) = New SqlParameter("@PinkMay", System.DBNull.Value)
        Else
            param(34) = New SqlParameter("@PinkMay", oWorkshopExpenditurePPT.PinkMay)
        End If
        If oWorkshopExpenditurePPT.PinkJun = Nothing Then
            param(35) = New SqlParameter("@PinkJun", System.DBNull.Value)
        Else
            param(35) = New SqlParameter("@PinkJun", oWorkshopExpenditurePPT.PinkJun)
        End If
        If oWorkshopExpenditurePPT.PinkJul = Nothing Then
            param(36) = New SqlParameter("@PinkJul", System.DBNull.Value)
        Else
            param(36) = New SqlParameter("@PinkJul", oWorkshopExpenditurePPT.PinkJul)
        End If
        If oWorkshopExpenditurePPT.PinkAug = Nothing Then
            param(37) = New SqlParameter("@PinkAug", System.DBNull.Value)
        Else
            param(37) = New SqlParameter("@PinkAug", oWorkshopExpenditurePPT.PinkAug)
        End If
        If oWorkshopExpenditurePPT.PinkSep = Nothing Then
            param(38) = New SqlParameter("@PinkSep", System.DBNull.Value)
        Else
            param(38) = New SqlParameter("@PinkSep", oWorkshopExpenditurePPT.PinkSep)

        End If
        If oWorkshopExpenditurePPT.PinkOct = Nothing Then
            param(39) = New SqlParameter("@PinkOct", System.DBNull.Value)
        Else
            param(39) = New SqlParameter("@PinkOct", oWorkshopExpenditurePPT.PinkOct)
        End If
        If oWorkshopExpenditurePPT.PinkNov = Nothing Then
            param(40) = New SqlParameter("@PinkNov", System.DBNull.Value)
        Else
            param(40) = New SqlParameter("@PinkNov", oWorkshopExpenditurePPT.PinkNov)
        End If
        If oWorkshopExpenditurePPT.PinkDec = Nothing Then
            param(41) = New SqlParameter("@PinkDec", System.DBNull.Value)
        Else
            param(41) = New SqlParameter("@PinkDec", oWorkshopExpenditurePPT.PinkDec)
        End If

        param(42) = New SqlParameter("@BudgetTotal", oWorkshopExpenditurePPT.BudgetTotal)

        If oWorkshopExpenditurePPT.SubDesc = Nothing Then
            param(43) = New SqlParameter("@SubDesc", System.DBNull.Value)
        Else
            param(43) = New SqlParameter("@SubDesc", oWorkshopExpenditurePPT.SubDesc)
        End If

        If oWorkshopExpenditurePPT.Qty = Nothing Then
            param(44) = New SqlParameter("@Qty", System.DBNull.Value)
        Else
            param(44) = New SqlParameter("@Qty", oWorkshopExpenditurePPT.Qty)
        End If
        If oWorkshopExpenditurePPT.Cost = Nothing Then
            param(45) = New SqlParameter("@Cost", System.DBNull.Value)
        Else
            param(45) = New SqlParameter("@Cost", oWorkshopExpenditurePPT.Cost)
        End If
        If oWorkshopExpenditurePPT.Day = Nothing Then
            param(46) = New SqlParameter("@Day", System.DBNull.Value)
        Else
            param(46) = New SqlParameter("@Day", oWorkshopExpenditurePPT.Day)
        End If
        If oWorkshopExpenditurePPT.Month = Nothing Then
            param(47) = New SqlParameter("@Month", System.DBNull.Value)
        Else
            param(47) = New SqlParameter("@Month", oWorkshopExpenditurePPT.Month)
        End If
        If oWorkshopExpenditurePPT.Percentage = Nothing Then
            param(48) = New SqlParameter("@Percentage", System.DBNull.Value)
        Else
            param(48) = New SqlParameter("@Percentage", oWorkshopExpenditurePPT.Percentage)
        End If

        param(49) = New SqlParameter("@BudgetType", "WorkshopExpend")

        param(50) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        param(51) = New SqlParameter("@CreatedOn", Date.Today())
        param(52) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(53) = New SqlParameter("@ModifiedOn", Date.Today())


        ds = objdb.ExecQuery("[Budget].[ExpBudAdminExpendInsert]", param)
        Return ds

    End Function
    Public Shared Function WorkshopExpendUpdate(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim param(47) As SqlParameter
        Dim ds As New DataSet
        param(0) = New SqlParameter("@BudgetYear", oWorkshopExpenditurePPT.BudgetYear)
        param(1) = New SqlParameter("@COAId", oWorkshopExpenditurePPT.COAId)
        param(2) = New SqlParameter("@EstateID ", GlobalPPT.strEstateID)
        param(3) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        param(4) = New SqlParameter("@Remarks", oWorkshopExpenditurePPT.Remarks)
        param(5) = New SqlParameter("@Amount", oWorkshopExpenditurePPT.Cost)

        param(6) = New SqlParameter("@BudgetJan", oWorkshopExpenditurePPT.BudgetJan)
        param(7) = New SqlParameter("@BudgetFeb", oWorkshopExpenditurePPT.BudgetFeb)
        param(8) = New SqlParameter("@BudgetMar", oWorkshopExpenditurePPT.BudgetMar)
        param(9) = New SqlParameter("@BudgetApr", oWorkshopExpenditurePPT.BudgetApr)
        param(10) = New SqlParameter("@BudgetMay", oWorkshopExpenditurePPT.BudgetMay)
        param(11) = New SqlParameter("@BudgetJun", oWorkshopExpenditurePPT.BudgetJun)
        param(12) = New SqlParameter("@BudgetJul", oWorkshopExpenditurePPT.BudgetJul)
        param(13) = New SqlParameter("@BudgetAug", oWorkshopExpenditurePPT.BudgetAug)
        param(14) = New SqlParameter("@BudgetSep", oWorkshopExpenditurePPT.BudgetSep)
        param(15) = New SqlParameter("@BudgetOct", oWorkshopExpenditurePPT.BudgetOct)
        param(16) = New SqlParameter("@BudgetNov", oWorkshopExpenditurePPT.BudgetNov)
        param(17) = New SqlParameter("@BudgetDec", oWorkshopExpenditurePPT.BudgetDec)

        param(18) = New SqlParameter("@RevJan", oWorkshopExpenditurePPT.RevJan)
        param(19) = New SqlParameter("@RevFeb", oWorkshopExpenditurePPT.RevFeb)
        param(20) = New SqlParameter("@RevMar", oWorkshopExpenditurePPT.RevMar)
        param(21) = New SqlParameter("@RevApr", oWorkshopExpenditurePPT.RevApr)
        param(22) = New SqlParameter("@RevMay", oWorkshopExpenditurePPT.RevMay)
        param(23) = New SqlParameter("@RevJun", oWorkshopExpenditurePPT.RevJun)
        param(24) = New SqlParameter("@RevJul", oWorkshopExpenditurePPT.RevJul)
        param(25) = New SqlParameter("@RevAug", oWorkshopExpenditurePPT.RevAug)
        param(26) = New SqlParameter("@RevSep", oWorkshopExpenditurePPT.RevSep)
        param(27) = New SqlParameter("@RevOct", oWorkshopExpenditurePPT.RevOct)
        param(28) = New SqlParameter("@RevNov", oWorkshopExpenditurePPT.RevNov)
        param(29) = New SqlParameter("@RevDec", oWorkshopExpenditurePPT.RevDec)

        param(30) = New SqlParameter("@PinkSlipJan", oWorkshopExpenditurePPT.PinkJan)
        param(31) = New SqlParameter("@PinkSlipFeb", oWorkshopExpenditurePPT.PinkFeb)
        param(32) = New SqlParameter("@PinkSlipMar", oWorkshopExpenditurePPT.PinkMar)
        param(33) = New SqlParameter("@PinkSlipApr", oWorkshopExpenditurePPT.PinkApr)
        param(34) = New SqlParameter("@PinkSlipMay", oWorkshopExpenditurePPT.PinkMay)
        param(35) = New SqlParameter("@PinkSlipJun", oWorkshopExpenditurePPT.PinkJun)
        param(36) = New SqlParameter("@PinkSlipJul", oWorkshopExpenditurePPT.PinkJul)
        param(37) = New SqlParameter("@PinkSlipAug", oWorkshopExpenditurePPT.PinkAug)
        param(38) = New SqlParameter("@PinkSlipSep", oWorkshopExpenditurePPT.PinkSep)
        param(39) = New SqlParameter("@PinkSlipOct", oWorkshopExpenditurePPT.PinkOct)
        param(40) = New SqlParameter("@PinkSlipNov", oWorkshopExpenditurePPT.PinkNov)
        param(41) = New SqlParameter("@PinkSlipDec", oWorkshopExpenditurePPT.PinkDec)
        param(42) = New SqlParameter("@BudgetTotal", oWorkshopExpenditurePPT.BudgetTotal)


        param(43) = New SqlParameter("@VersionNo", oWorkshopExpenditurePPT.VersionNo)
        param(44) = New SqlParameter("@Status", oWorkshopExpenditurePPT.Status)
        param(45) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(46) = New SqlParameter("@ModifiedOn", Date.Today())
        param(47) = New SqlParameter("@CapitalExpendId", oWorkshopExpenditurePPT.BudgetID)

        ds = objdb.ExecQuery("[Budget].[CapitalExpendUpdate]", param)
        Return ds
    End Function

    Public Shared Function WorkshopExpendSelect(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim param(2) As SqlParameter
        Dim dt As New DataTable

        'param(0) = New SqlParameter("@COAId", IIf(oWorkshopExpenditurePPT.COAId <> String.Empty, oWorkshopExpenditurePPT.COAId, DBNull.Value))
        'param(1) = New SqlParameter("@COADescp", IIf(oWorkshopExpenditurePPT.COADescp <> String.Empty, oWorkshopExpenditurePPT.COADescp, DBNull.Value))

        'param(0) = New SqlParameter("@COAId", oWorkshopExpenditurePPT.COAId)
        'param(1) = New SqlParameter("@COACode", oWorkshopExpenditurePPT.COACode)
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        If oWorkshopExpenditurePPT.BudgetYear <> Nothing Then
            param(1) = New SqlParameter("@Budgetyear", oWorkshopExpenditurePPT.BudgetYear)
        Else
            param(1) = New SqlParameter("@Budgetyear", GlobalPPT.intLoginYear)
        End If

        If oWorkshopExpenditurePPT.COACode <> "" Then
            param(2) = New SqlParameter("@COACode", oWorkshopExpenditurePPT.COACode)
        Else
            param(2) = New SqlParameter("@COACode", DBNull.Value)
        End If
        dt = objdb.ExecQuery("[Budget].[WorkshopExpenditureSelect]", param).Tables(0)
        Return dt
    End Function
    'Public Shared Function CapitalExpenditureSelect_Multi(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataTable
    '    Dim objdb As New SQLHelp
    '    Dim param(4) As SqlParameter
    '    Dim dt As New DataTable
    '    param(0) = New SqlParameter("@CapitalExpendID", oWorkshopExpenditurePPT.BudgetID)
    '    param(1) = New SqlParameter("@COAID", oWorkshopExpenditurePPT.COAId)
    '    param(2) = New SqlParameter("@COACode", oWorkshopExpenditurePPT.COACode)
    '    param(3) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
    '    param(4) = New SqlParameter("@Budgetyear", GlobalPPT.intLoginYear)
    '    dt = objdb.ExecQuery("[Budget].[CapitalExpenditureSelect_Multi]", param).Tables(0)
    '    Return dt
    'End Function
    Public Shared Function WorkshopExpendDelete(ByVal oWorkshopExpenditurePPT As WorkshopExpenditurePPT) As DataSet
        '    Dim objdb As New SQLHelp
        '    Dim param(1) As SqlParameter
        '    Dim ds As New DataSet
        '    param(0) = New SqlParameter("@CapitalExpendID", oWorkshopExpenditurePPT.BudgetID)
        '    param(1) = New SqlParameter("EstateID", GlobalPPT.strEstateID)
        '    ds = objdb.ExecQuery("[Budget].[CapitalExpendDelete]", param)
        '    Return ds
        'End Function
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(4) As SqlParameter
        param(0) = New SqlParameter("@BudgetID ", oWorkshopExpenditurePPT.BudgetID)
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(2) = New SqlParameter("@COAId ", oWorkshopExpenditurePPT.COAId)
        param(3) = New SqlParameter("@VersionNo ", oWorkshopExpenditurePPT.VersionNo)
        param(4) = New SqlParameter("@BudgetYear ", oWorkshopExpenditurePPT.BudgetYear)
        ds = objdb.ExecQuery("[Budget].[WorkshopExpendDelete]", param)
        Return ds
    End Function

End Class

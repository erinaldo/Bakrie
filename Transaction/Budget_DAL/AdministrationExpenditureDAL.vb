Imports System.Data.SqlClient
Imports Common_PPT
Imports Budget_PPT
Imports Common_DAL
Public Class AdministrationExpenditureDAL

    Public Shared Function AdminExpendInsert(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim param(53) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        param(2) = New SqlParameter("@BudgetYear", oAdministrationExpenditurePPT.BudgetYear)
        param(3) = New SqlParameter("@COAId", oAdministrationExpenditurePPT.COAId)
        param(4) = New SqlParameter("@Price", oAdministrationExpenditurePPT.Price)

        If oAdministrationExpenditurePPT.Remarks = Nothing Then
            param(5) = New SqlParameter("@Remarks", System.DBNull.Value)
        Else
            param(5) = New SqlParameter("@Remarks", oAdministrationExpenditurePPT.Remarks)
        End If


        param(6) = New SqlParameter("@BudgetJan", oAdministrationExpenditurePPT.BudgetJan)
        param(7) = New SqlParameter("@BudgetFeb", oAdministrationExpenditurePPT.BudgetFeb)
        param(8) = New SqlParameter("@BudgetMar", oAdministrationExpenditurePPT.BudgetMar)
        param(9) = New SqlParameter("@BudgetApr", oAdministrationExpenditurePPT.BudgetApr)
        param(10) = New SqlParameter("@BudgetMay", oAdministrationExpenditurePPT.BudgetMay)
        param(11) = New SqlParameter("@BudgetJun", oAdministrationExpenditurePPT.BudgetJun)
        param(12) = New SqlParameter("@BudgetJul", oAdministrationExpenditurePPT.BudgetJul)
        param(13) = New SqlParameter("@BudgetAug", oAdministrationExpenditurePPT.BudgetAug)
        param(14) = New SqlParameter("@BudgetSep", oAdministrationExpenditurePPT.BudgetSep)
        param(15) = New SqlParameter("@BudgetOct", oAdministrationExpenditurePPT.BudgetOct)
        param(16) = New SqlParameter("@BudgetNov", oAdministrationExpenditurePPT.BudgetNov)
        param(17) = New SqlParameter("@BudgetDec", oAdministrationExpenditurePPT.BudgetDec)


        If oAdministrationExpenditurePPT.RevJan = Nothing Then
            param(18) = New SqlParameter("@RevJan", System.DBNull.Value)
        Else
            param(18) = New SqlParameter("@RevJan", oAdministrationExpenditurePPT.RevJan)
        End If
        If oAdministrationExpenditurePPT.RevFeb = Nothing Then
            param(19) = New SqlParameter("@RevFeb", System.DBNull.Value)
        Else
            param(19) = New SqlParameter("@RevFeb", oAdministrationExpenditurePPT.RevFeb)
        End If
        If oAdministrationExpenditurePPT.RevMar = Nothing Then
            param(20) = New SqlParameter("@RevMar", System.DBNull.Value)
        Else
            param(20) = New SqlParameter("@RevMar", oAdministrationExpenditurePPT.RevMar)
        End If
        If oAdministrationExpenditurePPT.RevApr = Nothing Then
            param(21) = New SqlParameter("@RevApr", System.DBNull.Value)
        Else
            param(21) = New SqlParameter("@RevApr", oAdministrationExpenditurePPT.RevApr)
        End If
        If oAdministrationExpenditurePPT.RevMay = Nothing Then
            param(22) = New SqlParameter("@RevMay", System.DBNull.Value)
        Else
            param(22) = New SqlParameter("@RevMay", oAdministrationExpenditurePPT.RevMay)
        End If
        If oAdministrationExpenditurePPT.RevJun = Nothing Then
            param(23) = New SqlParameter("@RevJun", System.DBNull.Value)
        Else
            param(23) = New SqlParameter("@RevJun", oAdministrationExpenditurePPT.RevJun)
        End If
        If oAdministrationExpenditurePPT.RevJul = Nothing Then
            param(24) = New SqlParameter("@RevJul", System.DBNull.Value)
        Else
            param(24) = New SqlParameter("@RevJul", oAdministrationExpenditurePPT.RevJul)
        End If
        If oAdministrationExpenditurePPT.RevAug = Nothing Then
            param(25) = New SqlParameter("@RevAug", System.DBNull.Value)
        Else
            param(25) = New SqlParameter("@RevAug", oAdministrationExpenditurePPT.RevAug)
        End If
        If oAdministrationExpenditurePPT.RevSep = Nothing Then
            param(26) = New SqlParameter("@RevSep", System.DBNull.Value)
        Else
            param(26) = New SqlParameter("@RevSep", oAdministrationExpenditurePPT.RevSep)
        End If
        If oAdministrationExpenditurePPT.RevOct = Nothing Then
            param(27) = New SqlParameter("@RevOct", System.DBNull.Value)
        Else
            param(27) = New SqlParameter("@RevOct", oAdministrationExpenditurePPT.RevOct)
        End If
        If oAdministrationExpenditurePPT.RevNov = Nothing Then
            param(28) = New SqlParameter("@RevNov", System.DBNull.Value)
        Else
            param(28) = New SqlParameter("@RevNov", oAdministrationExpenditurePPT.RevNov)
        End If
        If oAdministrationExpenditurePPT.RevDec = Nothing Then
            param(29) = New SqlParameter("@RevDec", System.DBNull.Value)
        Else
            param(29) = New SqlParameter("@RevDec", oAdministrationExpenditurePPT.RevDec)
        End If

        If oAdministrationExpenditurePPT.PinkJan = Nothing Then
            param(30) = New SqlParameter("@PinkJan", System.DBNull.Value)
        Else
            param(30) = New SqlParameter("@PinkJan", oAdministrationExpenditurePPT.PinkJan)
        End If
        If oAdministrationExpenditurePPT.PinkFeb = Nothing Then
            param(31) = New SqlParameter("@PinkFeb", System.DBNull.Value)
        Else
            param(31) = New SqlParameter("@PinkFeb", oAdministrationExpenditurePPT.PinkFeb)
        End If
        If oAdministrationExpenditurePPT.PinkMar = Nothing Then
            param(32) = New SqlParameter("@PinkMar", System.DBNull.Value)
        Else
            param(32) = New SqlParameter("@PinkMar", oAdministrationExpenditurePPT.PinkMar)
        End If
        If oAdministrationExpenditurePPT.PinkApr = Nothing Then
            param(33) = New SqlParameter("@PinkApr", System.DBNull.Value)
        Else
            param(33) = New SqlParameter("@PinkApr", oAdministrationExpenditurePPT.PinkApr)
        End If
        If oAdministrationExpenditurePPT.PinkMay = Nothing Then
            param(34) = New SqlParameter("@PinkMay", System.DBNull.Value)
        Else
            param(34) = New SqlParameter("@PinkMay", oAdministrationExpenditurePPT.PinkMay)
        End If
        If oAdministrationExpenditurePPT.PinkJun = Nothing Then
            param(35) = New SqlParameter("@PinkJun", System.DBNull.Value)
        Else
            param(35) = New SqlParameter("@PinkJun", oAdministrationExpenditurePPT.PinkJun)
        End If
        If oAdministrationExpenditurePPT.PinkJul = Nothing Then
            param(36) = New SqlParameter("@PinkJul", System.DBNull.Value)
        Else
            param(36) = New SqlParameter("@PinkJul", oAdministrationExpenditurePPT.PinkJul)
        End If
        If oAdministrationExpenditurePPT.PinkAug = Nothing Then
            param(37) = New SqlParameter("@PinkAug", System.DBNull.Value)
        Else
            param(37) = New SqlParameter("@PinkAug", oAdministrationExpenditurePPT.PinkAug)
        End If
        If oAdministrationExpenditurePPT.PinkSep = Nothing Then
            param(38) = New SqlParameter("@PinkSep", System.DBNull.Value)
        Else
            param(38) = New SqlParameter("@PinkSep", oAdministrationExpenditurePPT.PinkSep)

        End If
        If oAdministrationExpenditurePPT.PinkOct = Nothing Then
            param(39) = New SqlParameter("@PinkOct", System.DBNull.Value)
        Else
            param(39) = New SqlParameter("@PinkOct", oAdministrationExpenditurePPT.PinkOct)
        End If
        If oAdministrationExpenditurePPT.PinkNov = Nothing Then
            param(40) = New SqlParameter("@PinkNov", System.DBNull.Value)
        Else
            param(40) = New SqlParameter("@PinkNov", oAdministrationExpenditurePPT.PinkNov)
        End If
        If oAdministrationExpenditurePPT.PinkDec = Nothing Then
            param(41) = New SqlParameter("@PinkDec", System.DBNull.Value)
        Else
            param(41) = New SqlParameter("@PinkDec", oAdministrationExpenditurePPT.PinkDec)
        End If

        param(42) = New SqlParameter("@BudgetTotal", oAdministrationExpenditurePPT.BudgetTotal)

        If oAdministrationExpenditurePPT.SubDesc = Nothing Then
            param(43) = New SqlParameter("@SubDesc", System.DBNull.Value)
        Else
            param(43) = New SqlParameter("@SubDesc", oAdministrationExpenditurePPT.SubDesc)
        End If
        If oAdministrationExpenditurePPT.Qty = Nothing Then
            param(44) = New SqlParameter("@Qty", System.DBNull.Value)
        Else
            param(44) = New SqlParameter("@Qty", oAdministrationExpenditurePPT.Qty)
        End If
        If oAdministrationExpenditurePPT.Cost = Nothing Then
            param(45) = New SqlParameter("@Cost", System.DBNull.Value)
        Else
            param(45) = New SqlParameter("@Cost", oAdministrationExpenditurePPT.Cost)
        End If
        If oAdministrationExpenditurePPT.Day = Nothing Then
            param(46) = New SqlParameter("@Day", System.DBNull.Value)
        Else
            param(46) = New SqlParameter("@Day", oAdministrationExpenditurePPT.Day)
        End If
        If oAdministrationExpenditurePPT.Month = Nothing Then
            param(47) = New SqlParameter("@Month", System.DBNull.Value)
        Else
            param(47) = New SqlParameter("@Month", oAdministrationExpenditurePPT.Month)
        End If
        If oAdministrationExpenditurePPT.Percentage = Nothing Then
            param(48) = New SqlParameter("@Percentage", System.DBNull.Value)
        Else
            param(48) = New SqlParameter("@Percentage", oAdministrationExpenditurePPT.Percentage)
        End If

        param(49) = New SqlParameter("@BudgetType", "AdminExpend")

        param(50) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        param(51) = New SqlParameter("@CreatedOn", Date.Today())
        param(52) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(53) = New SqlParameter("@ModifiedOn", Date.Today())

      


        ds = objdb.ExecQuery("[Budget].[ExpBudAdminExpendInsert]", param)
        Return ds
    End Function

    Public Shared Function ExpBudAdminExpendSelect(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataTable
        Dim objdb As New SQLHelp
        Dim dt As New DataTable
        Dim param(2) As SqlParameter

        param(0) = New SqlParameter("@BudgetYear", GlobalPPT.intLoginYear)
        param(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        If oAdministrationExpenditurePPT.COACode = "" Then
            param(2) = New SqlParameter("@COACode", DBNull.Value)
        Else
            param(2) = New SqlParameter("@COACode", oAdministrationExpenditurePPT.COACode)
        End If


        dt = objdb.ExecQuery("[Budget].[ExpBudAdminExpendSelect]", param).Tables(0)
        Return dt

    End Function

    Public Shared Function AcctlookupSearch(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oAdministrationExpenditurePPT.COACode <> "" And oAdministrationExpenditurePPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oAdministrationExpenditurePPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oAdministrationExpenditurePPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oAdministrationExpenditurePPT.COACode <> "" And oAdministrationExpenditurePPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oAdministrationExpenditurePPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oAdministrationExpenditurePPT.COACode = "" And oAdministrationExpenditurePPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oAdministrationExpenditurePPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Else
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        End If
        Param(3) = New SqlParameter("@IsDirect", IsDirect)
        Return objdb.ExecQuery("[STORE].[StoreIssueVoucherAcctCodeSelect]", Param)

    End Function

    Public Shared Function AdminExpendCOACodeIsvalid(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@COACode", oAdministrationExpenditurePPT.COACode)

        ds = objdb.ExecQuery("[Budget].[AdminExpendCOACodeIsvalid]", param)
        Return ds

    End Function

    Public Shared Function ExpBudAdminExpendUpdate(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim param(53) As SqlParameter
        param(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        param(2) = New SqlParameter("@BudgetYear", oAdministrationExpenditurePPT.BudgetYear)
        param(3) = New SqlParameter("@COAId", oAdministrationExpenditurePPT.COAId)
        param(4) = New SqlParameter("@Price", oAdministrationExpenditurePPT.Price)
        param(5) = New SqlParameter("@Remarks", oAdministrationExpenditurePPT.Remarks)
        param(6) = New SqlParameter("@BudgetJan", oAdministrationExpenditurePPT.BudgetJan)
        param(7) = New SqlParameter("@BudgetFeb", oAdministrationExpenditurePPT.BudgetFeb)
        param(8) = New SqlParameter("@BudgetMar", oAdministrationExpenditurePPT.BudgetMar)
        param(9) = New SqlParameter("@BudgetApr", oAdministrationExpenditurePPT.BudgetApr)
        param(10) = New SqlParameter("@BudgetMay", oAdministrationExpenditurePPT.BudgetMay)
        param(11) = New SqlParameter("@BudgetJun", oAdministrationExpenditurePPT.BudgetJun)
        param(12) = New SqlParameter("@BudgetJul", oAdministrationExpenditurePPT.BudgetJul)
        param(13) = New SqlParameter("@BudgetAug", oAdministrationExpenditurePPT.BudgetAug)
        param(14) = New SqlParameter("@BudgetSep", oAdministrationExpenditurePPT.BudgetSep)
        param(15) = New SqlParameter("@BudgetOct", oAdministrationExpenditurePPT.BudgetOct)
        param(16) = New SqlParameter("@BudgetNov", oAdministrationExpenditurePPT.BudgetNov)
        param(17) = New SqlParameter("@BudgetDec", oAdministrationExpenditurePPT.BudgetDec)


        If oAdministrationExpenditurePPT.RevJan = Nothing Then
            param(18) = New SqlParameter("@RevJan", System.DBNull.Value)
        Else
            param(18) = New SqlParameter("@RevJan", oAdministrationExpenditurePPT.RevJan)
        End If
        If oAdministrationExpenditurePPT.RevFeb = Nothing Then
            param(19) = New SqlParameter("@RevFeb", System.DBNull.Value)
        Else
            param(19) = New SqlParameter("@RevFeb", oAdministrationExpenditurePPT.RevFeb)
        End If
        If oAdministrationExpenditurePPT.RevMar = Nothing Then
            param(20) = New SqlParameter("@RevMar", System.DBNull.Value)
        Else
            param(20) = New SqlParameter("@RevMar", oAdministrationExpenditurePPT.RevMar)
        End If
        If oAdministrationExpenditurePPT.RevApr = Nothing Then
            param(21) = New SqlParameter("@RevApr", System.DBNull.Value)
        Else
            param(21) = New SqlParameter("@RevApr", oAdministrationExpenditurePPT.RevApr)
        End If
        If oAdministrationExpenditurePPT.RevMay = Nothing Then
            param(22) = New SqlParameter("@RevMay", System.DBNull.Value)
        Else
            param(22) = New SqlParameter("@RevMay", oAdministrationExpenditurePPT.RevMay)
        End If
        If oAdministrationExpenditurePPT.RevJun = Nothing Then
            param(23) = New SqlParameter("@RevJun", System.DBNull.Value)
        Else
            param(23) = New SqlParameter("@RevJun", oAdministrationExpenditurePPT.RevJun)
        End If
        If oAdministrationExpenditurePPT.RevJul = Nothing Then
            param(24) = New SqlParameter("@RevJul", System.DBNull.Value)
        Else
            param(24) = New SqlParameter("@RevJul", oAdministrationExpenditurePPT.RevJul)
        End If
        If oAdministrationExpenditurePPT.RevAug = Nothing Then
            param(25) = New SqlParameter("@RevAug", System.DBNull.Value)
        Else
            param(25) = New SqlParameter("@RevAug", oAdministrationExpenditurePPT.RevAug)
        End If
        If oAdministrationExpenditurePPT.RevSep = Nothing Then
            param(26) = New SqlParameter("@RevSep", System.DBNull.Value)
        Else
            param(26) = New SqlParameter("@RevSep", oAdministrationExpenditurePPT.RevSep)
        End If
        If oAdministrationExpenditurePPT.RevOct = Nothing Then
            param(27) = New SqlParameter("@RevOct", System.DBNull.Value)
        Else
            param(27) = New SqlParameter("@RevOct", oAdministrationExpenditurePPT.RevOct)
        End If
        If oAdministrationExpenditurePPT.RevNov = Nothing Then
            param(28) = New SqlParameter("@RevNov", System.DBNull.Value)
        Else
            param(28) = New SqlParameter("@RevNov", oAdministrationExpenditurePPT.RevNov)
        End If
        If oAdministrationExpenditurePPT.RevDec = Nothing Then
            param(29) = New SqlParameter("@RevDec", System.DBNull.Value)
        Else
            param(29) = New SqlParameter("@RevDec", oAdministrationExpenditurePPT.RevDec)
        End If

        If oAdministrationExpenditurePPT.PinkJan = Nothing Then
            param(30) = New SqlParameter("@PinkJan", System.DBNull.Value)
        Else
            param(30) = New SqlParameter("@PinkJan", oAdministrationExpenditurePPT.PinkJan)
        End If
        If oAdministrationExpenditurePPT.PinkFeb = Nothing Then
            param(31) = New SqlParameter("@PinkFeb", System.DBNull.Value)
        Else
            param(31) = New SqlParameter("@PinkFeb", oAdministrationExpenditurePPT.PinkFeb)
        End If
        If oAdministrationExpenditurePPT.PinkMar = Nothing Then
            param(32) = New SqlParameter("@PinkMar", System.DBNull.Value)
        Else
            param(32) = New SqlParameter("@PinkMar", oAdministrationExpenditurePPT.PinkMar)
        End If
        If oAdministrationExpenditurePPT.PinkApr = Nothing Then
            param(33) = New SqlParameter("@PinkApr", System.DBNull.Value)
        Else
            param(33) = New SqlParameter("@PinkApr", oAdministrationExpenditurePPT.PinkApr)
        End If
        If oAdministrationExpenditurePPT.PinkMay = Nothing Then
            param(34) = New SqlParameter("@PinkMay", System.DBNull.Value)
        Else
            param(34) = New SqlParameter("@PinkMay", oAdministrationExpenditurePPT.PinkMay)
        End If
        If oAdministrationExpenditurePPT.PinkJun = Nothing Then
            param(35) = New SqlParameter("@PinkJun", System.DBNull.Value)
        Else
            param(35) = New SqlParameter("@PinkJun", oAdministrationExpenditurePPT.PinkJun)
        End If
        If oAdministrationExpenditurePPT.PinkJul = Nothing Then
            param(36) = New SqlParameter("@PinkJul", System.DBNull.Value)
        Else
            param(36) = New SqlParameter("@PinkJul", oAdministrationExpenditurePPT.PinkJul)
        End If
        If oAdministrationExpenditurePPT.PinkAug = Nothing Then
            param(37) = New SqlParameter("@PinkAug", System.DBNull.Value)
        Else
            param(37) = New SqlParameter("@PinkAug", oAdministrationExpenditurePPT.PinkAug)
        End If
        If oAdministrationExpenditurePPT.PinkSep = Nothing Then
            param(38) = New SqlParameter("@PinkSep", System.DBNull.Value)
        Else
            param(38) = New SqlParameter("@PinkSep", oAdministrationExpenditurePPT.PinkSep)

        End If
        If oAdministrationExpenditurePPT.PinkOct = Nothing Then
            param(39) = New SqlParameter("@PinkOct", System.DBNull.Value)
        Else
            param(39) = New SqlParameter("@PinkOct", oAdministrationExpenditurePPT.PinkOct)
        End If
        If oAdministrationExpenditurePPT.PinkNov = Nothing Then
            param(40) = New SqlParameter("@PinkNov", System.DBNull.Value)
        Else
            param(40) = New SqlParameter("@PinkNov", oAdministrationExpenditurePPT.PinkNov)
        End If
        If oAdministrationExpenditurePPT.PinkDec = Nothing Then
            param(41) = New SqlParameter("@PinkDec", System.DBNull.Value)
        Else
            param(41) = New SqlParameter("@PinkDec", oAdministrationExpenditurePPT.PinkDec)
        End If
        param(42) = New SqlParameter("@BudgetTotal", oAdministrationExpenditurePPT.BudgetTotal)
        param(43) = New SqlParameter("@VersionNo", oAdministrationExpenditurePPT.VersionNo)
        param(44) = New SqlParameter("@Status", oAdministrationExpenditurePPT.Status)

        param(45) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        param(46) = New SqlParameter("@ModifiedOn", Date.Today())
        param(47) = New SqlParameter("@BudgetID", oAdministrationExpenditurePPT.BudgetID)

        param(48) = New SqlParameter("@SubDesc", oAdministrationExpenditurePPT.SubDesc)
        param(49) = New SqlParameter("@Qty", oAdministrationExpenditurePPT.Qty)
        param(50) = New SqlParameter("@Cost", oAdministrationExpenditurePPT.Cost)

        param(51) = New SqlParameter("@Day", oAdministrationExpenditurePPT.Day)
        param(52) = New SqlParameter("@Month", oAdministrationExpenditurePPT.Month)
        param(53) = New SqlParameter("@Percentage", oAdministrationExpenditurePPT.Percentage)
        'param(54) = New SqlParameter("@BudgetType", "AdminExpend")


        ds = objdb.ExecQuery("[Budget].[ExpBudAdminExpendUpdate]", param)
        Return ds
    End Function

    Public Shared Function AdminExpendDelete(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(4) As SqlParameter
        param(0) = New SqlParameter("@BudgetID ", oAdministrationExpenditurePPT.BudgetID)
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(2) = New SqlParameter("@COAId ", oAdministrationExpenditurePPT.COAId)
        param(3) = New SqlParameter("@VersionNo ", oAdministrationExpenditurePPT.VersionNo)
        param(4) = New SqlParameter("@BudgetYear ", oAdministrationExpenditurePPT.BudgetYear)
        ds = objdb.ExecQuery("[Budget].[AdminExpendDelete]", param)
        Return ds

    End Function


    Public Shared Function AdminExpendCOACodeSearch(ByVal oAdministrationExpenditurePPT As AdministrationExpenditurePPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim param(2) As SqlParameter

        If oAdministrationExpenditurePPT.COACode <> "" Then
            param(0) = New SqlParameter("@COACode", oAdministrationExpenditurePPT.COACode)
        Else
            param(0) = New SqlParameter("@COACode", DBNull.Value)
        End If
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(2) = New SqlParameter("@BDGYear", GlobalPPT.intLoginYear)
        ds = objdb.ExecQuery("[Budget].[AdminExpendCOACodeSearch]", param)
        Return ds

    End Function
End Class

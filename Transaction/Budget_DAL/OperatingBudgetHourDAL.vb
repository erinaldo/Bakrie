Imports Common_DAL
Imports Common_PPT
Imports Budget_PPT
Imports System.Data.SqlClient
Public Class OperatingBudgetHourDAL

    Public Shared Function OperatingBudgetByHoursInsert(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Param(34) As SqlParameter
        Param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Param(2) = New SqlParameter("@BudgetYear", oOperatingBudgetHourPPT.BudgetYear)
        Param(3) = New SqlParameter("@VHID", oOperatingBudgetHourPPT.VHID)
        Param(4) = New SqlParameter("@COAID", oOperatingBudgetHourPPT.COAID)
        Param(5) = New SqlParameter("@NoOfHours", oOperatingBudgetHourPPT.NoOfHours)

        Param(6) = New SqlParameter("@BudgetJan", oOperatingBudgetHourPPT.BudgetJan)
        Param(7) = New SqlParameter("@BudgetFeb", oOperatingBudgetHourPPT.BudgetFeb)
        Param(8) = New SqlParameter("@BudgetMar", oOperatingBudgetHourPPT.BudgetMar)
        Param(9) = New SqlParameter("@BudgetApr", oOperatingBudgetHourPPT.BudgetApr)
        Param(10) = New SqlParameter("@BudgetMay", oOperatingBudgetHourPPT.BudgetMay)
        Param(11) = New SqlParameter("@BudgetJun", oOperatingBudgetHourPPT.BudgetJun)
        Param(12) = New SqlParameter("@BudgetJul", oOperatingBudgetHourPPT.BudgetJul)
        Param(13) = New SqlParameter("@BudgetAug", oOperatingBudgetHourPPT.BudgetAug)
        Param(14) = New SqlParameter("@BudgetSep", oOperatingBudgetHourPPT.BudgetSep)
        Param(15) = New SqlParameter("@BudgetOct", oOperatingBudgetHourPPT.BudgetOct)
        Param(16) = New SqlParameter("@BudgetNov", oOperatingBudgetHourPPT.BudgetNov)
        Param(17) = New SqlParameter("@BudgetDec", oOperatingBudgetHourPPT.BudgetDec)

        Param(18) = New SqlParameter("@RevJan", oOperatingBudgetHourPPT.RevJan)
        Param(19) = New SqlParameter("@RevFeb", oOperatingBudgetHourPPT.RevFeb)
        Param(20) = New SqlParameter("@RevMar", oOperatingBudgetHourPPT.RevMar)
        Param(21) = New SqlParameter("@RevApr", oOperatingBudgetHourPPT.RevApr)
        Param(22) = New SqlParameter("@RevMay", oOperatingBudgetHourPPT.RevMay)
        Param(23) = New SqlParameter("@RevJun", oOperatingBudgetHourPPT.RevJun)
        Param(24) = New SqlParameter("@RevJul", oOperatingBudgetHourPPT.RevJul)
        Param(25) = New SqlParameter("@RevAug", oOperatingBudgetHourPPT.RevAug)
        Param(26) = New SqlParameter("@RevSep", oOperatingBudgetHourPPT.RevSep)
        Param(27) = New SqlParameter("@RevOct", oOperatingBudgetHourPPT.RevOct)
        Param(28) = New SqlParameter("@RevNov", oOperatingBudgetHourPPT.RevNov)
        Param(29) = New SqlParameter("@RevDec", oOperatingBudgetHourPPT.RevDec)
        Param(30) = New SqlParameter("@BalanceTotal", oOperatingBudgetHourPPT.BudgetTotal)
        'Param(31) = New SqlParameter("@Status", oOperatingBudgetHourPPT.Status)

        Param(31) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Param(32) = New SqlParameter("@CreatedOn", Date.Today())
        Param(33) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(34) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Budget].[OperatingBudgetByHoursInsert]", Param)
        Return ds
    End Function
    Public Shared Function OperatingBudgetByHoursSelect() As DataTable
        Dim dt As New DataTable
        Dim Objdb As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        param(1) = New SqlParameter("BudgetYear", GlobalPPT.intLoginYear)
        dt = Objdb.ExecQuery("[Budget].[OperatingBudgetByHoursSelect]", param).Tables(0)
        Return dt

    End Function
    Public Shared Function OperatingBudgetByHoursSelect_MultipleEntry(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataTable
        Dim dt As New DataTable
        Dim Objdb As New SQLHelp
        Dim param(1) As SqlParameter
        param(0) = New SqlParameter("VHNo", oOperatingBudgetHourPPT.VHNO)
        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        dt = Objdb.ExecQuery("[Budget].[OperatingBudgetByHoursSelect_MultipleEntry]", param).Tables(0)
        Return dt

    End Function
    Public Shared Function OperatingBudgetByHoursUpdate(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Param(35) As SqlParameter
        Param(0) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Param(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Param(2) = New SqlParameter("@BudgetYear", oOperatingBudgetHourPPT.BudgetYear)
        Param(3) = New SqlParameter("@VHID", oOperatingBudgetHourPPT.VHID)
        Param(4) = New SqlParameter("@COAID", oOperatingBudgetHourPPT.COAID)
        Param(5) = New SqlParameter("@NoOfHours", oOperatingBudgetHourPPT.NoOfHours)

        Param(6) = New SqlParameter("@BudgetJan", oOperatingBudgetHourPPT.BudgetJan)
        Param(7) = New SqlParameter("@BudgetFeb", oOperatingBudgetHourPPT.BudgetFeb)
        Param(8) = New SqlParameter("@BudgetMar", oOperatingBudgetHourPPT.BudgetMar)
        Param(9) = New SqlParameter("@BudgetApr", oOperatingBudgetHourPPT.BudgetApr)
        Param(10) = New SqlParameter("@BudgetMay", oOperatingBudgetHourPPT.BudgetMay)
        Param(11) = New SqlParameter("@BudgetJun", oOperatingBudgetHourPPT.BudgetJun)
        Param(12) = New SqlParameter("@BudgetJul", oOperatingBudgetHourPPT.BudgetJul)
        Param(13) = New SqlParameter("@BudgetAug", oOperatingBudgetHourPPT.BudgetAug)
        Param(14) = New SqlParameter("@BudgetSep", oOperatingBudgetHourPPT.BudgetSep)
        Param(15) = New SqlParameter("@BudgetOct", oOperatingBudgetHourPPT.BudgetOct)
        Param(16) = New SqlParameter("@BudgetNov", oOperatingBudgetHourPPT.BudgetNov)
        Param(17) = New SqlParameter("@BudgetDec", oOperatingBudgetHourPPT.BudgetDec)

        Param(18) = New SqlParameter("@RevJan", oOperatingBudgetHourPPT.RevJan)
        Param(19) = New SqlParameter("@RevFeb", oOperatingBudgetHourPPT.RevFeb)
        Param(20) = New SqlParameter("@RevMar", oOperatingBudgetHourPPT.RevMar)
        Param(21) = New SqlParameter("@RevApr", oOperatingBudgetHourPPT.RevApr)
        Param(22) = New SqlParameter("@RevMay", oOperatingBudgetHourPPT.RevMay)
        Param(23) = New SqlParameter("@RevJun", oOperatingBudgetHourPPT.RevJun)
        Param(24) = New SqlParameter("@RevJul", oOperatingBudgetHourPPT.RevJul)
        Param(25) = New SqlParameter("@RevAug", oOperatingBudgetHourPPT.RevAug)
        Param(26) = New SqlParameter("@RevSep", oOperatingBudgetHourPPT.RevSep)
        Param(27) = New SqlParameter("@RevOct", oOperatingBudgetHourPPT.RevOct)
        Param(28) = New SqlParameter("@RevNov", oOperatingBudgetHourPPT.RevNov)
        Param(29) = New SqlParameter("@RevDec", oOperatingBudgetHourPPT.RevDec)
        Param(30) = New SqlParameter("@BalanceTotal", oOperatingBudgetHourPPT.BudgetTotal)
        Param(31) = New SqlParameter("@VersionNo", oOperatingBudgetHourPPT.VersionNo)
        Param(32) = New SqlParameter("@Status", oOperatingBudgetHourPPT.Status)

        'Param(33) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        'Param(34) = New SqlParameter("@CreatedOn", Date.Today())
        Param(33) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Param(34) = New SqlParameter("@ModifiedOn", Date.Today())
        Param(35) = New SqlParameter("@OperatingBudgetByHoursID", oOperatingBudgetHourPPT.OperatingBudgetByHoursID)

        ds = objdb.ExecQuery("[Budget].[OperatingBudgetByHoursUpdate]", Param)
        Return ds
    End Function
    Public Shared Function OperatingHoursViewSearch(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As DataSet
        'Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim rowsAffected As Integer = 0
        Dim Param(2) As SqlParameter
        'param(0) = New SqlParameter("@COAGroup", oOperatingBudgetHourPPT.COAGroup)
        'Param(0) = New SqlParameter("@BudgetYear", oOperatingBudgetHourPPT.BudgetYear)

        If oOperatingBudgetHourPPT.COACode <> "" Then
            Param(0) = New SqlParameter("@COACode", oOperatingBudgetHourPPT.COACode)
        Else
            Param(0) = New SqlParameter("@COACode", DBNull.Value)
        End If

        If oOperatingBudgetHourPPT.VHNO <> "" Then
            Param(1) = New SqlParameter("@VHNo", oOperatingBudgetHourPPT.VHNO)
        Else
            Param(1) = New SqlParameter("@VHNo", DBNull.Value)
        End If
        'param(1) = New SqlParameter("@VHNo", oOperatingBudgetHourPPT.VHNO)
        Param(2) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)
        Return objdb.ExecQuery("[Budget].[OperatingHoursViewSearch]", Param)

    End Function
    Public Shared Function OperatingBudgetByHoursDelete(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT) As Integer
        Dim objdb As New SQLHelp
        Dim param(2) As SqlParameter
        Dim rowsAffected As Integer = 0

        param(0) = New SqlParameter("@OperatingBudgetByHoursID ", oOperatingBudgetHourPPT.OperatingBudgetByHoursID)

        param(1) = New SqlParameter("@EstateId", GlobalPPT.strEstateID)

        param(2) = New SqlParameter("@COAID", oOperatingBudgetHourPPT.COAID)

        rowsAffected = objdb.ExecNonQuery("[Budget].[OperatingBudgetByHoursDelete]", param)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Shared Function AcctlookupSearch(ByVal oOperatingBudgetHourPPT As OperatingBudgetHourPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Param(3) As SqlParameter
        If oOperatingBudgetHourPPT.COACode <> "" And oOperatingBudgetHourPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", oOperatingBudgetHourPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", oOperatingBudgetHourPPT.COADescp)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oOperatingBudgetHourPPT.COACode <> "" And oOperatingBudgetHourPPT.COADescp = "" Then
            Param(0) = New SqlParameter("@Accountcode", oOperatingBudgetHourPPT.COACode)
            Param(1) = New SqlParameter("@AccountDesc", DBNull.Value)
            Param(2) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ElseIf oOperatingBudgetHourPPT.COACode = "" And oOperatingBudgetHourPPT.COADescp <> "" Then
            Param(0) = New SqlParameter("@Accountcode", DBNull.Value)
            Param(1) = New SqlParameter("@AccountDesc", oOperatingBudgetHourPPT.COADescp)
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

Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class StoreMonthEndClosingDAL

    Public Shared Function DoStoreMonthEndClosing(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@EstateCodeL", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(5) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(6) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(7) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(12) = New SqlParameter("@ModID", 2)
        Parms(13) = New SqlParameter("@newActiveMonthYearID", "")
        ds = objdb.ExecQuery("[Store].[StoreMonthEndClosing]", Parms)

        Return ds

    End Function

    Public Shared Function StoreMonthEndClosing_UpdateStockMaster(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT, ByVal strNewActiveMonthYearID As String) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@newActiveMonthYearID", strNewActiveMonthYearID)
        Parms(2) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)

        ds = objdb.ExecQuery("[Store].[StoreMonthEndClosing_UpdateStockMaster]", Parms)

        Return ds

    End Function


    Public Shared Function TaskConfigTaskCheckGet(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        ds = objdb.ExecQuery("[Store].[TaskConfigTaskCheckGet]", Parms)

        Return ds

    End Function

    Public Shared Function TaskMonitorGet(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", 2)

        ds = objdb.ExecQuery("[General].[TaskMonitorGet]", Parms)

        Return ds

    End Function

    Public Shared Function ApprovalCheck(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ModID", 2)
        Parms(3) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(4) = New SqlParameter("@ModifiedOn", Date.Today())

        ds = objdb.ExecQuery("[Store].[ApprovalCheck]", Parms)

        Return ds

    End Function
    Public Shared Function TaskMonitorUpdate(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(7) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@ModID", objStoreMonthEndClosingPPT.ModID)
        Parms(2) = New SqlParameter("@Task", objStoreMonthEndClosingPPT.Task)
        Parms(3) = New SqlParameter("@Complete", objStoreMonthEndClosingPPT.Complete)
        Parms(4) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(5) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(6) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(7) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)

        ds = objdb.ExecQuery("[General].[TaskMonitorUPDATE]", Parms)

        Return ds

    End Function

    ''Public Shared Function TaskMonitorInsert(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

    ''    Dim ds As New DataSet
    ''    Dim objdb As New SQLHelp
    ''    Dim Parms(8) As SqlParameter
    ''    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    ''    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    ''    Parms(2) = New SqlParameter("@StoreModID", "2")
    ''    Parms(3) = New SqlParameter("@Task", "Store month end closing")
    ''    Parms(4) = New SqlParameter("@Complete", "N")
    ''    Parms(5) = New SqlParameter("@CreatedBy", "System")
    ''    Parms(6) = New SqlParameter("@CreatedOn", Date.Today())
    ''    Parms(7) = New SqlParameter("@ModifiedBy", "System")
    ''    Parms(8) = New SqlParameter("@ModifiedOn", Date.Today())

    ''    ds = objdb.ExecQuery("[Store].[TaskMonitorINSERT]", Parms)

    ''    Return ds

    ''End Function

    'Public Shared Function AutoBSPBackup(ByVal BeforeOrAfter As String) As DataSet

    '    Dim ds As New DataSet
    '    Dim objdb As New SQLHelp
    '    Dim Parms(3) As SqlParameter
    '    Parms(0) = New SqlParameter("@BeforeOrAfter", BeforeOrAfter)
    '    Parms(1) = New SqlParameter("@Amonth", GlobalPPT.IntActiveMonth)
    '    Parms(2) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
    '    Parms(3) = New SqlParameter("@ModID", 2)

    '    ds = objdb.ExecQuery("[General].[AutoBSPBackup]", Parms)

    '    Return ds

    'End Function

End Class

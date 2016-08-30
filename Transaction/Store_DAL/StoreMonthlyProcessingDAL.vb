Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class StoreMonthlyProcessingDAL

    Public Shared Function MonthlyProcessingDeleteAll(ByVal objStoreMonthlyProcessingPPT As StoreMonthlyProcessingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@EstateCodeL", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Store].[MonthlyProcessingDeleteAll]", Parms)
        Return ds

    End Function

    Public Shared Function DoStoreMonthlyProcessing(ByVal objStoreMonthlyProcessingPPT As StoreMonthlyProcessingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@EstateCodeL", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@LoginMonth", GlobalPPT.IntLoginMonth)
        Parms(5) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(6) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(7) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        ds = objdb.ExecQuery("[Store].[StoreMonthlyProcessing]", Parms)

        Return ds

    End Function

    Public Shared Function TaskMonitorStatusGet(ByVal objStoreMonthEndClosingPPT As StoreMonthEndClosingPPT) As DataSet

        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ModID", 2)
        Parms(2) = New SqlParameter("@Task", objStoreMonthEndClosingPPT.Task)
        Parms(3) = New SqlParameter("@AYear", GlobalPPT.intActiveYear)
        Parms(4) = New SqlParameter("@AMonth", GlobalPPT.IntActiveMonth)

        ds = objdb.ExecQuery("[General].[TaskMonitorStatusGet]", Parms)

        Return ds

    End Function

End Class

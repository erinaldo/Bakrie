﻿Imports Store_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL
Public Class LaporanstockDAL
    Public Function GetInterfaceYear(ByVal objLaporanstockPPT As LaporanstockPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", 2)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Store].[StockDetailMonthYearGET]", Parms)
        Return ds
    End Function

    Public Function GetTaskComplete(ByVal objLaporanstockPPT As LaporanstockPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objLaporanstockPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objLaporanstockPPT.AMonth)
        Parms(3) = New SqlParameter("@Task", objLaporanstockPPT.Task)
        Parms(4) = New SqlParameter("@ModID", 2)

        ds = objdb.ExecQuery("[General].[TaskMonitorStatusGet]", Parms)
        Return ds
    End Function
    Public Function GetFYearDate(ByVal objLaporanstockPPT As LaporanstockPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objLaporanstockPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objLaporanstockPPT.AMonth)
        ds = objdb.ExecQuery("[Store].[SummaryReportFYearDateGet]", Parms)
        Return ds
    End Function
End Class

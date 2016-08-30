Imports Vehicle_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class DistribusiBiayaBengkelReportDAL

    Public Function GetInterfaceYear(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", 3)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Vehicle].[WorkshoplogMonthYearGET]", Parms)
        Return ds
    End Function
    Public Function GetTaskComplete(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objDistribusiBiayaBengkelReportPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objDistribusiBiayaBengkelReportPPT.AMonth)
        Parms(3) = New SqlParameter("@Task", objDistribusiBiayaBengkelReportPPT.Task)
        Parms(4) = New SqlParameter("@ModID", 3)

        ds = objdb.ExecQuery("[General].[TaskMonitorStatusGet]", Parms)
        Return ds
    End Function
    Public Function ActiveMonthYearIDGet(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objDistribusiBiayaBengkelReportPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objDistribusiBiayaBengkelReportPPT.AMonth)
        Parms(3) = New SqlParameter("@ModID", 3)

        ds = objdb.ExecQuery("[General].[ActiveMonthYearIDGet]", Parms)
        Return ds
    End Function
    Public Function GetFYearDate(ByVal objDistribusiBiayaBengkelReportPPT As DistribusiBiayaBengkelReportPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objDistribusiBiayaBengkelReportPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objDistribusiBiayaBengkelReportPPT.AMonth)
        'Parms(3) = New SqlParameter("@ModID", 3)

        ds = objdb.ExecQuery("[Store].[SummaryReportFYearDateGet]", Parms)
        Return ds
    End Function
End Class

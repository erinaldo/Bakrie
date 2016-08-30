Imports Vehicle_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class VehicleLedgerDAL

    Public Function GetInterfaceYear(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@ModID", objVehicleLedgerPPT.ModID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Vehicle].[LedgerAllModuleMonthYearGET]", Parms)
        Return ds
    End Function
    Public Function GetTaskComplete(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objVehicleLedgerPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objVehicleLedgerPPT.AMonth)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", objVehicleLedgerPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@ModID", objVehicleLedgerPPT.ModID)

        ds = objdb.ExecQuery("[Accounts].[LedgerReportCheck]", Parms)
        Return ds
    End Function
    Public Function ActiveMonthYearIDGet(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objVehicleLedgerPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objVehicleLedgerPPT.AMonth)
        Parms(3) = New SqlParameter("@ModID", 3)

        ds = objdb.ExecQuery("[General].[ActiveMonthYearIDGet]", Parms)
        Return ds
    End Function
    Public Function GetFYearDate(ByVal objVehicleLedgerPPT As VehicleLedgerPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@AYear", objVehicleLedgerPPT.AYear)
        Parms(2) = New SqlParameter("@AMonth", objVehicleLedgerPPT.AMonth)
        'Parms(3) = New SqlParameter("@ModID", 3)

        ds = objdb.ExecQuery("[Store].[SummaryReportFYearDateGet]", Parms)
        Return ds
    End Function

End Class

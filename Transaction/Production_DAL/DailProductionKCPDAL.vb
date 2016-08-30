Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class DailProductionKCPDAL

    Public Shared Function DailyProductionKCPDateSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT, ByVal LoadorSearch As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)
        Parms(2) = New SqlParameter("@LoadorSearchDate", LoadorSearch)

        ds = objdb.ExecQuery("[Production].[DailyProductionKCPDateSelect]", Parms)
        Return ds
    End Function

    Public Shared Function DailyProductionKCPBFQtySelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)
        Parms(2) = New SqlParameter("@ActiveYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@AMonth", GlobalPPT.IntLoginMonth)
        ds = objdb.ExecQuery("[Production].[DailyProductionKCPBFQtySelect]", Parms)
        Return ds
    End Function

    Public Shared Function DailyProductionKCPCPKOCFSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)

        ds = objdb.ExecQuery("[Production].[DailyProductionKCPCPKOCFSelect]", Parms)
        Return ds
    End Function

    Public Shared Function DailyProductionKCPKernelBalanceCFSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)

        ds = objdb.ExecQuery("[Production].[DailyProductionKCPKernelBalanceCFSelect]", Parms)
        Return ds
    End Function

    Public Shared Function DailyProductionKCPKernelIntakeSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)

        ds = objdb.ExecQuery("[Production].[DailyProductionKCPKernelIntakeSelect]", Parms)
        Return ds
    End Function
    Public Shared Function DailyProductionLoadingCPKOSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT, ByVal LoadDescp As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)
        Parms(2) = New SqlParameter("@Descp", LoadDescp)
        Parms(3) = New SqlParameter("@ActiveYear", GlobalPPT.intLoginYear)
        Parms(4) = New SqlParameter("@AMonth", GlobalPPT.IntLoginMonth)

        ds = objdb.ExecQuery("[Production].[DailyProductionLoadingCPKOSelect]", Parms)
        Return ds
    End Function
    Public Shared Function DailProductionSartStopHrsSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionlogDate", objDailyProductionKCPPPT.ProductionDate)

        ds = objdb.ExecQuery("[Production].[DailProductionSartStopHrsSelect]", Parms)
        Return ds
    End Function

    Public Shared Function DailProductionBDSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objDailyProductionKCPPPT.ProductionDate)
        Parms(2) = New SqlParameter("@ActiveYear", GlobalPPT.intLoginYear)
        Parms(3) = New SqlParameter("@ActiveMonthyearID", GlobalPPT.strActMthYearID)


        ds = objdb.ExecQuery("[Production].[DailProductionBDSelect]", Parms)
        Return ds
    End Function


    Public Shared Function DailProductionPressInfoSelect(ByVal objDailyProductionKCPPPT As DailyProductionKCPPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", objDailyProductionKCPPPT.ProductionDate)

        ds = objdb.ExecQuery("[Production].[DailProductionPressInfoSelect]", Parms)
        Return ds
    End Function

End Class

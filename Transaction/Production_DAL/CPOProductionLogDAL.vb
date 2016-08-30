Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class CPOProductionLogDAL
    Public Shared Function CPOGetMonthYearQty(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearHrs]", Parms)
    End Function

    Public Shared Function CPOGetMonthYearQtyCheck(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearHrsCheck]", Parms)
    End Function
    Public Shared Function CPOGetFFBNetWeight(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(1) = New SqlParameter("@ProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Return objdb.ExecQuery("[Production].[CPOGetFFBNetWeight]", Parms)
    End Function
    Public Shared Function CPOLogFFBLorryProcessed(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Return objdb.ExecQuery("[Production].[CPOLogFFBLorryProcessed]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearElectricalBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetMonthYearElectricalBD]", Parms)
    End Function

    Public Shared Function CPOGetMonthYearEPHours(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetMonthYearEPHours]", Parms)
    End Function

    Public Shared Function CPOGetMonthYearFFB(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetMonthYearFFB]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearHrs(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetMonthYearHrs]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearKER(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearKER]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearLorry(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearLorry]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearLorryWeight(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearLorryWeight]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearLossKernel(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearLossKernel]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearMechanicalBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearMechanicalBD]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearOER(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearOER]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearProcessingBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearProcessingBD]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearThroughput(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearThroughput]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearAvgThroughput(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearThroughput]", Parms)
    End Function
    Public Shared Function CPOGetTodayQtyForOERKernel(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionDate", objCPOLogPPT.ProductionLogDate)
        Return objdb.ExecQuery("[Production].[CPOGetTodayQtyForOERKernel]", Parms)
    End Function
    Public Shared Function CPOGetTodayQtyForOERCPO(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionDate", objCPOLogPPT.ProductionLogDate)
        Return objdb.ExecQuery("[Production].[CPOGetTodayQtyForOERCPO]", Parms)
    End Function
    Public Shared Function CPOGetMonthYearTotalBD(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOLogPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearTotalBD]", Parms)
    End Function
    Public Shared Function saveCPOLogProduction(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(45) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYield", objCPOLogPPT.CropYieldID)
        Parms(4) = New SqlParameter("@ProductionLogDate", IIf(objCPOLogPPT.ProductionLogDate <> Nothing, objCPOLogPPT.ProductionLogDate, DBNull.Value))
        'Parms(5) = New SqlParameter("@AssistantEmpID", IIf(objCPOLogPPT.AssistantEmpID <> String.Empty, objCPOLogPPT.AssistantEmpID, DBNull.Value))
        'Parms(6) = New SqlParameter("@MandoreEmpID", IIf(objCPOLogPPT.MandoreEmpID <> String.Empty, objCPOLogPPT.MandoreEmpID, DBNull.Value))
        'Parms(7) = New SqlParameter("@Shift", objCPOLogPPT.Shift)
        'Parms(8) = New SqlParameter("@StartTime", objCPOLogPPT.StartTime)
        'Parms(9) = New SqlParameter("@StopTime", objCPOLogPPT.StopTime)
        'Parms(10) = New SqlParameter("@FFBProcessedEST", IIf(objCPOLogPPT.FFBProcessedEST <> Nothing, objCPOLogPPT.FFBProcessedEST, DBNull.Value))
        'Parms(11) = New SqlParameter("@LorryProcessedEST", IIf(objCPOLogPPT.LorryProcessedEST <> Nothing, objCPOLogPPT.LorryProcessedEST, DBNull.Value))
        Parms(5) = New SqlParameter("@TotalHours", IIf(objCPOLogPPT.TotalHours <> Nothing, objCPOLogPPT.TotalHours, DBNull.Value))
        Parms(6) = New SqlParameter("@MonthToDateHrs", IIf(objCPOLogPPT.MonthToDateHrs <> Nothing, objCPOLogPPT.MonthToDateHrs, DBNull.Value))
        Parms(7) = New SqlParameter("@YearToDateHrs", IIf(objCPOLogPPT.YeartoDateHrs <> Nothing, objCPOLogPPT.YeartoDateHrs, DBNull.Value))
        Parms(8) = New SqlParameter("@BalanceFFBBFQty", IIf(objCPOLogPPT.BalanceFFBBFQty <> Nothing, objCPOLogPPT.BalanceFFBBFQty, DBNull.Value))
        Parms(9) = New SqlParameter("@BalanceFFBBFNoLorry", IIf(objCPOLogPPT.BalanceFFBBFNoLorry <> Nothing, objCPOLogPPT.BalanceFFBBFNoLorry, DBNull.Value))
        Parms(10) = New SqlParameter("@FFBReceived", IIf(objCPOLogPPT.FFBReceived <> Nothing, objCPOLogPPT.FFBReceived, DBNull.Value))
        Parms(11) = New SqlParameter("@FFBReceivedLorry", IIf(objCPOLogPPT.FFBReceivedLorry <> Nothing, objCPOLogPPT.FFBReceivedLorry, DBNull.Value))
        Parms(12) = New SqlParameter("@FFBReceivedMTD", IIf(objCPOLogPPT.FFBReceivedMTD <> Nothing, objCPOLogPPT.FFBReceivedMTD, DBNull.Value))
        Parms(13) = New SqlParameter("@FFBReceivedACT", IIf(objCPOLogPPT.FFBProcessedACT <> Nothing, objCPOLogPPT.FFBProcessedACT, DBNull.Value))
        Parms(14) = New SqlParameter("@LorryProcessedACT", IIf(objCPOLogPPT.LorryProcessedACT <> Nothing, objCPOLogPPT.LorryProcessedACT, DBNull.Value))
        Parms(15) = New SqlParameter("@BalanceFFBCFQty", IIf(objCPOLogPPT.BalanceFFBCFQty <> Nothing, objCPOLogPPT.BalanceFFBCFQty, DBNull.Value))
        Parms(16) = New SqlParameter("@BalanceFFBCFNoLorry", IIf(objCPOLogPPT.BalanceFFBCFNoLorry <> Nothing, objCPOLogPPT.BalanceFFBCFNoLorry, DBNull.Value))
        Parms(17) = New SqlParameter("@KernelProduction", IIf(objCPOLogPPT.KernelProduction <> Nothing, objCPOLogPPT.KernelProduction, DBNull.Value))
        Parms(18) = New SqlParameter("@LossOfKernel", IIf(objCPOLogPPT.LossOfKernel <> Nothing, objCPOLogPPT.LossOfKernel, DBNull.Value))
        Parms(19) = New SqlParameter("@AvgLorryWeight", IIf(objCPOLogPPT.AvgLorryWeight <> Nothing, objCPOLogPPT.AvgLorryWeight, DBNull.Value))
        Parms(20) = New SqlParameter("@MechanicalBD", IIf(objCPOLogPPT.MechanicalBD <> Nothing, objCPOLogPPT.MechanicalBD, DBNull.Value))
        Parms(21) = New SqlParameter("@ElectricalBD", IIf(objCPOLogPPT.ElectricalBD <> Nothing, objCPOLogPPT.ElectricalBD, DBNull.Value))
        Parms(22) = New SqlParameter("@processingBD", IIf(objCPOLogPPT.ProcessingBD <> Nothing, objCPOLogPPT.ProcessingBD, DBNull.Value))
        Parms(23) = New SqlParameter("@TotalBD", IIf(objCPOLogPPT.TotalBD <> Nothing, objCPOLogPPT.TotalBD, DBNull.Value))
        Parms(24) = New SqlParameter("@EPHours", IIf(objCPOLogPPT.EffectiveProcessingHours <> Nothing, objCPOLogPPT.EffectiveProcessingHours, DBNull.Value))
        Parms(25) = New SqlParameter("@ThroPut", IIf(objCPOLogPPT.Throughput <> Nothing, objCPOLogPPT.Throughput, DBNull.Value))
        Parms(26) = New SqlParameter("@OER", IIf(objCPOLogPPT.OER <> Nothing, objCPOLogPPT.OER, DBNull.Value))
        Parms(27) = New SqlParameter("@KER", IIf(objCPOLogPPT.KER <> Nothing, objCPOLogPPT.KER, DBNull.Value))
        Parms(28) = New SqlParameter("@Remarks", IIf(objCPOLogPPT.Remarks <> String.Empty, objCPOLogPPT.Remarks, DBNull.Value))
        Parms(29) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(30) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(31) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(32) = New SqlParameter("@ModifiedOn", Date.Today())
        '' newly added on may 13 
        Parms(33) = New SqlParameter("@FFBProcessedMTD", IIf(objCPOLogPPT.FFBProcessedMTD <> Nothing, objCPOLogPPT.FFBProcessedMTD, DBNull.Value))
        Parms(34) = New SqlParameter("@LorryProcessedMTD", IIf(objCPOLogPPT.LorryProcessedMTD <> Nothing, objCPOLogPPT.LorryProcessedMTD, DBNull.Value))
        Parms(35) = New SqlParameter("@LossOfKernelMTD", IIf(objCPOLogPPT.LossOfKernelMTD <> Nothing, objCPOLogPPT.LossOfKernelMTD, DBNull.Value))
        Parms(36) = New SqlParameter("@MechanicalBDMTD", IIf(objCPOLogPPT.MechanicalBDMTD <> Nothing, objCPOLogPPT.MechanicalBDMTD, DBNull.Value))
        Parms(37) = New SqlParameter("@ElectricalBDMTD", IIf(objCPOLogPPT.ElectricalBDMTD <> Nothing, objCPOLogPPT.ElectricalBDMTD, DBNull.Value))
        Parms(38) = New SqlParameter("@processingBDMTD", IIf(objCPOLogPPT.ProcessingBDMTD <> Nothing, objCPOLogPPT.ProcessingBDMTD, DBNull.Value))
        Parms(39) = New SqlParameter("@FFBProcessedYTD", IIf(objCPOLogPPT.FFBProcessedYTD <> Nothing, objCPOLogPPT.FFBProcessedYTD, DBNull.Value))
        Parms(40) = New SqlParameter("@LorryProcessedYTD", IIf(objCPOLogPPT.LorryProcessedYTD <> Nothing, objCPOLogPPT.LorryProcessedYTD, DBNull.Value))
        Parms(41) = New SqlParameter("@LossOfKernelYTD", IIf(objCPOLogPPT.LossOfKernelYTD <> Nothing, objCPOLogPPT.LossOfKernelYTD, DBNull.Value))
        Parms(42) = New SqlParameter("@MechanicalBDYTD", IIf(objCPOLogPPT.MechanicalBDYTD <> Nothing, objCPOLogPPT.MechanicalBDYTD, DBNull.Value))
        Parms(43) = New SqlParameter("@ElectricalBDYTD", IIf(objCPOLogPPT.ElectricalBDYTD <> Nothing, objCPOLogPPT.ElectricalBDYTD, DBNull.Value))
        Parms(44) = New SqlParameter("@processingBDYTD", IIf(objCPOLogPPT.ProcessingBDYTD <> Nothing, objCPOLogPPT.ProcessingBDYTD, DBNull.Value))
        Parms(45) = New SqlParameter("@FFBReceivedYTD", IIf(objCPOLogPPT.FFBReceivedYTD <> Nothing, objCPOLogPPT.FFBReceivedYTD, DBNull.Value))


        Return objdb.ExecQuery("[Production].[CPOProductionLogInsert]", Parms)
    End Function
    Public Shared Function saveCPOLogShift(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(24) As SqlParameter
        Parms(0) = New SqlParameter("@CPOProductionLogID", objCPOLogPPT.CPOProductionLogID)
        Parms(1) = New SqlParameter("@Shift1", IIf(objCPOLogPPT.Shift1 <> String.Empty, objCPOLogPPT.Shift1, DBNull.Value))

        Parms(2) = New SqlParameter("@AssistantEmpID1", IIf(objCPOLogPPT.AssistantEmpID1 <> String.Empty, objCPOLogPPT.AssistantEmpID1, DBNull.Value))
        Parms(3) = New SqlParameter("@MandoreEmpID1", IIf(objCPOLogPPT.MandoreEmpID1 <> String.Empty, objCPOLogPPT.MandoreEmpID1, DBNull.Value))
        Parms(4) = New SqlParameter("@FFBProcessedEST1", IIf(objCPOLogPPT.FFBProcessedEST1 <> Nothing, objCPOLogPPT.FFBProcessedEST1, DBNull.Value))
        Parms(5) = New SqlParameter("@LorryProcessedEST1", IIf(objCPOLogPPT.LorryProcessedEST1 <> Nothing, objCPOLogPPT.LorryProcessedEST1, DBNull.Value))
        Parms(6) = New SqlParameter("@StartTime1", IIf(objCPOLogPPT.StartTime1 <> String.Empty, objCPOLogPPT.StartTime1, DBNull.Value))
        Parms(7) = New SqlParameter("@EndTime1", IIf(objCPOLogPPT.StopTime1 <> String.Empty, objCPOLogPPT.StopTime1, DBNull.Value))
        Parms(8) = New SqlParameter("@TotalBreakdown1", IIf(objCPOLogPPT.TotalBreakdown1 <> String.Empty, objCPOLogPPT.TotalBreakdown1, DBNull.Value))

        Parms(9) = New SqlParameter("@Shift2", IIf(objCPOLogPPT.Shift2 <> String.Empty, objCPOLogPPT.Shift2, DBNull.Value))
        Parms(10) = New SqlParameter("@AssistantEmpID2", IIf(objCPOLogPPT.AssistantEmpID2 <> String.Empty, objCPOLogPPT.AssistantEmpID2, DBNull.Value))
        Parms(11) = New SqlParameter("@MandoreEmpID2", IIf(objCPOLogPPT.MandoreEmpID2 <> String.Empty, objCPOLogPPT.MandoreEmpID2, DBNull.Value))
        Parms(12) = New SqlParameter("@FFBProcessedEST2", IIf(objCPOLogPPT.FFBProcessedEST2 <> Nothing, objCPOLogPPT.FFBProcessedEST2, DBNull.Value))
        Parms(13) = New SqlParameter("@LorryProcessedEST2", IIf(objCPOLogPPT.LorryProcessedEST2 <> Nothing, objCPOLogPPT.LorryProcessedEST2, DBNull.Value))
        Parms(14) = New SqlParameter("@StartTime2", IIf(objCPOLogPPT.StartTime2 <> String.Empty, objCPOLogPPT.StartTime2, DBNull.Value))
        Parms(15) = New SqlParameter("@EndTime2", IIf(objCPOLogPPT.StopTime2 <> String.Empty, objCPOLogPPT.StopTime2, DBNull.Value))
        Parms(16) = New SqlParameter("@TotalBreakdown2", IIf(objCPOLogPPT.TotalBreakdown2 <> String.Empty, objCPOLogPPT.TotalBreakdown2, DBNull.Value))

        Parms(17) = New SqlParameter("@Shift3", IIf(objCPOLogPPT.Shift3 <> String.Empty, objCPOLogPPT.Shift3, DBNull.Value))
        Parms(18) = New SqlParameter("@AssistantEmpID3", IIf(objCPOLogPPT.AssistantEmpID3 <> String.Empty, objCPOLogPPT.AssistantEmpID3, DBNull.Value))
        Parms(19) = New SqlParameter("@MandoreEmpID3", IIf(objCPOLogPPT.MandoreEmpID3 <> String.Empty, objCPOLogPPT.MandoreEmpID3, DBNull.Value))
        Parms(20) = New SqlParameter("@FFBProcessedEST3", IIf(objCPOLogPPT.FFBProcessedEST3 <> Nothing, objCPOLogPPT.FFBProcessedEST3, DBNull.Value))
        Parms(21) = New SqlParameter("@LorryProcessedEST3", IIf(objCPOLogPPT.LorryProcessedEST3 <> Nothing, objCPOLogPPT.LorryProcessedEST3, DBNull.Value))
        Parms(22) = New SqlParameter("@StartTime3", IIf(objCPOLogPPT.StartTime3 <> String.Empty, objCPOLogPPT.StartTime3, DBNull.Value))
        Parms(23) = New SqlParameter("@EndTime3", IIf(objCPOLogPPT.StopTime3 <> String.Empty, objCPOLogPPT.StopTime3, DBNull.Value))
        Parms(24) = New SqlParameter("@TotalBreakdown3", IIf(objCPOLogPPT.TotalBreakdown3 <> String.Empty, objCPOLogPPT.TotalBreakdown3, DBNull.Value))

        Return objdb.ExecQuery("[Production].[CPOProductionLogShiftInsert]", Parms)
    End Function
    Public Shared Function UpdateCPOProductionLog(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(45) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        'Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(2) = New SqlParameter("@CropYield", objCPOLogPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ProductionLogDate", IIf(objCPOLogPPT.ProductionLogDate <> Nothing, objCPOLogPPT.ProductionLogDate, DBNull.Value))
        ''Parms(4) = New SqlParameter("@AssistantEmpID", IIf(objCPOLogPPT.AssistantEmpID <> String.Empty, objCPOLogPPT.AssistantEmpID, DBNull.Value))
        ''Parms(5) = New SqlParameter("@MandoreEmpID", IIf(objCPOLogPPT.MandoreEmpID <> String.Empty, objCPOLogPPT.MandoreEmpID, DBNull.Value))
        ''Parms(6) = New SqlParameter("@Shift", objCPOLogPPT.Shift)
        ''Parms(7) = New SqlParameter("@StartTime", objCPOLogPPT.StartTime)
        ''Parms(8) = New SqlParameter("@StopTime", objCPOLogPPT.StopTime)
        ''Parms(9) = New SqlParameter("@FFBProcessedEST", IIf(objCPOLogPPT.FFBProcessedEST <> Nothing, objCPOLogPPT.FFBProcessedEST, DBNull.Value))
        ''Parms(10) = New SqlParameter("@LorryProcessedEST", IIf(objCPOLogPPT.LorryProcessedEST <> Nothing, objCPOLogPPT.LorryProcessedEST, DBNull.Value))
        Parms(4) = New SqlParameter("@TotalHours", IIf(objCPOLogPPT.TotalHours <> Nothing, objCPOLogPPT.TotalHours, DBNull.Value))
        Parms(5) = New SqlParameter("@MonthToDateHrs", IIf(objCPOLogPPT.MonthToDateHrs <> Nothing, objCPOLogPPT.MonthToDateHrs, DBNull.Value))
        Parms(6) = New SqlParameter("@YearToDateHrs", IIf(objCPOLogPPT.YeartoDateHrs <> Nothing, objCPOLogPPT.YeartoDateHrs, DBNull.Value))
        Parms(7) = New SqlParameter("@BalanceFFBBFQty", IIf(objCPOLogPPT.BalanceFFBBFQty <> Nothing, objCPOLogPPT.BalanceFFBBFQty, DBNull.Value))
        Parms(8) = New SqlParameter("@BalanceFFBBFNoLorry", IIf(objCPOLogPPT.BalanceFFBBFNoLorry <> Nothing, objCPOLogPPT.BalanceFFBBFNoLorry, DBNull.Value))
        Parms(9) = New SqlParameter("@FFBReceived", IIf(objCPOLogPPT.FFBReceived <> Nothing, objCPOLogPPT.FFBReceived, DBNull.Value))
        Parms(10) = New SqlParameter("@FFBReceivedLorry", IIf(objCPOLogPPT.FFBReceivedLorry <> Nothing, objCPOLogPPT.FFBReceivedLorry, DBNull.Value))
        Parms(11) = New SqlParameter("@FFBReceivedMTD", IIf(objCPOLogPPT.FFBReceivedMTD <> Nothing, objCPOLogPPT.FFBReceivedMTD, DBNull.Value))
        Parms(12) = New SqlParameter("@FFBProcessedACT", IIf(objCPOLogPPT.FFBProcessedACT <> Nothing, objCPOLogPPT.FFBProcessedACT, DBNull.Value))
        Parms(13) = New SqlParameter("@LorryProcessedACT", IIf(objCPOLogPPT.LorryProcessedACT <> Nothing, objCPOLogPPT.LorryProcessedACT, DBNull.Value))
        Parms(14) = New SqlParameter("@BalanceFFBCFQty", IIf(objCPOLogPPT.BalanceFFBCFQty <> Nothing, objCPOLogPPT.BalanceFFBCFQty, DBNull.Value))
        Parms(15) = New SqlParameter("@BalanceFFBCFNoLorry", IIf(objCPOLogPPT.BalanceFFBCFNoLorry <> Nothing, objCPOLogPPT.BalanceFFBCFNoLorry, DBNull.Value))
        Parms(16) = New SqlParameter("@KernelProduction", IIf(objCPOLogPPT.KernelProduction <> Nothing, objCPOLogPPT.KernelProduction, DBNull.Value))
        Parms(17) = New SqlParameter("@LossOfKernel", IIf(objCPOLogPPT.LossOfKernel <> Nothing, objCPOLogPPT.LossOfKernel, DBNull.Value))
        Parms(18) = New SqlParameter("@AvgLorryWeight", IIf(objCPOLogPPT.AvgLorryWeight <> Nothing, objCPOLogPPT.AvgLorryWeight, DBNull.Value))
        Parms(19) = New SqlParameter("@MechanicalBD", IIf(objCPOLogPPT.MechanicalBD <> Nothing, objCPOLogPPT.MechanicalBD, DBNull.Value))
        Parms(20) = New SqlParameter("@ElectricalBD", IIf(objCPOLogPPT.ElectricalBD <> Nothing, objCPOLogPPT.ElectricalBD, DBNull.Value))
        Parms(21) = New SqlParameter("@processingBD", IIf(objCPOLogPPT.ProcessingBD <> Nothing, objCPOLogPPT.ProcessingBD, DBNull.Value))
        Parms(22) = New SqlParameter("@TotalBD", IIf(objCPOLogPPT.TotalBD <> Nothing, objCPOLogPPT.TotalBD, DBNull.Value))
        Parms(23) = New SqlParameter("@EPHours", IIf(objCPOLogPPT.EffectiveProcessingHours <> Nothing, objCPOLogPPT.EffectiveProcessingHours, DBNull.Value))
        Parms(24) = New SqlParameter("@ThroPut", IIf(objCPOLogPPT.Throughput <> Nothing, objCPOLogPPT.Throughput, DBNull.Value))
        Parms(25) = New SqlParameter("@OER", IIf(objCPOLogPPT.OER <> Nothing, objCPOLogPPT.OER, DBNull.Value))
        Parms(26) = New SqlParameter("@KER", IIf(objCPOLogPPT.KER <> Nothing, objCPOLogPPT.KER, DBNull.Value))
        Parms(27) = New SqlParameter("@Remarks", IIf(objCPOLogPPT.Remarks <> String.Empty, objCPOLogPPT.Remarks, DBNull.Value))
        Parms(28) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(29) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(30) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(31) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(32) = New SqlParameter("@CPOProductionLogID", objCPOLogPPT.CPOProductionLogID)

        '' newly added on may 13 
        Parms(33) = New SqlParameter("@FFBProcessedMTD", IIf(objCPOLogPPT.FFBProcessedMTD <> Nothing, objCPOLogPPT.FFBProcessedMTD, DBNull.Value))
        Parms(34) = New SqlParameter("@LorryProcessedMTD", IIf(objCPOLogPPT.LorryProcessedMTD <> Nothing, objCPOLogPPT.LorryProcessedMTD, DBNull.Value))
        Parms(35) = New SqlParameter("@LossOfKernelMTD", IIf(objCPOLogPPT.LossOfKernelMTD <> Nothing, objCPOLogPPT.LossOfKernelMTD, DBNull.Value))
        Parms(36) = New SqlParameter("@MechanicalBDMTD", IIf(objCPOLogPPT.MechanicalBDMTD <> Nothing, objCPOLogPPT.MechanicalBDMTD, DBNull.Value))
        Parms(37) = New SqlParameter("@ElectricalBDMTD", IIf(objCPOLogPPT.ElectricalBDMTD <> Nothing, objCPOLogPPT.ElectricalBDMTD, DBNull.Value))
        Parms(38) = New SqlParameter("@processingBDMTD", IIf(objCPOLogPPT.ProcessingBDMTD <> Nothing, objCPOLogPPT.ProcessingBDMTD, DBNull.Value))
        Parms(39) = New SqlParameter("@FFBProcessedYTD", IIf(objCPOLogPPT.FFBProcessedYTD <> Nothing, objCPOLogPPT.FFBProcessedYTD, DBNull.Value))
        Parms(40) = New SqlParameter("@LorryProcessedYTD", IIf(objCPOLogPPT.LorryProcessedYTD <> Nothing, objCPOLogPPT.LorryProcessedYTD, DBNull.Value))
        Parms(41) = New SqlParameter("@LossOfKernelYTD", IIf(objCPOLogPPT.LossOfKernelYTD <> Nothing, objCPOLogPPT.LossOfKernelYTD, DBNull.Value))
        Parms(42) = New SqlParameter("@MechanicalBDYTD", IIf(objCPOLogPPT.MechanicalBDYTD <> Nothing, objCPOLogPPT.MechanicalBDYTD, DBNull.Value))
        Parms(43) = New SqlParameter("@ElectricalBDYTD", IIf(objCPOLogPPT.ElectricalBDYTD <> Nothing, objCPOLogPPT.ElectricalBDYTD, DBNull.Value))
        Parms(44) = New SqlParameter("@processingBDYTD", IIf(objCPOLogPPT.ProcessingBDYTD <> Nothing, objCPOLogPPT.ProcessingBDYTD, DBNull.Value))
        Parms(45) = New SqlParameter("@FFBReceivedYTD", IIf(objCPOLogPPT.FFBReceivedYTD <> Nothing, objCPOLogPPT.FFBReceivedYTD, DBNull.Value))

        Return objdb.ExecQuery("[Production].[CPOProductionLogUpdate]", Parms)
    End Function
    Public Shared Function UpdateCPOLogShift(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(24) As SqlParameter
        Parms(0) = New SqlParameter("@CPOProductionLogID", objCPOLogPPT.CPOProductionLogID)
        Parms(1) = New SqlParameter("@AssistantEmpID1", IIf(objCPOLogPPT.AssistantEmpID1 <> String.Empty, objCPOLogPPT.AssistantEmpID1, DBNull.Value))
        Parms(2) = New SqlParameter("@MandoreEmpID1", IIf(objCPOLogPPT.MandoreEmpID1 <> String.Empty, objCPOLogPPT.MandoreEmpID1, DBNull.Value))
        Parms(3) = New SqlParameter("@Shift1", IIf(objCPOLogPPT.Shift1 <> String.Empty, objCPOLogPPT.Shift1, DBNull.Value))
        Parms(4) = New SqlParameter("@StartTime1", IIf(objCPOLogPPT.StartTime1 <> String.Empty, objCPOLogPPT.StartTime1, DBNull.Value))
        Parms(5) = New SqlParameter("@EndTime1", IIf(objCPOLogPPT.StopTime1 <> String.Empty, objCPOLogPPT.StopTime1, DBNull.Value))
        Parms(6) = New SqlParameter("@TotalBreakdown1", IIf(objCPOLogPPT.TotalBreakdown1 <> String.Empty, objCPOLogPPT.TotalBreakdown1, DBNull.Value))
        Parms(7) = New SqlParameter("@FFBProcessedEST1", IIf(objCPOLogPPT.FFBProcessedEST1 <> Nothing, objCPOLogPPT.FFBProcessedEST1, DBNull.Value))
        Parms(8) = New SqlParameter("@LorryProcessedEST1", IIf(objCPOLogPPT.LorryProcessedEST1 <> Nothing, objCPOLogPPT.LorryProcessedEST1, DBNull.Value))

        Parms(9) = New SqlParameter("@AssistantEmpID2", IIf(objCPOLogPPT.AssistantEmpID2 <> String.Empty, objCPOLogPPT.AssistantEmpID2, DBNull.Value))
        Parms(10) = New SqlParameter("@MandoreEmpID2", IIf(objCPOLogPPT.MandoreEmpID2 <> String.Empty, objCPOLogPPT.MandoreEmpID2, DBNull.Value))
        Parms(11) = New SqlParameter("@Shift2", IIf(objCPOLogPPT.Shift2 <> String.Empty, objCPOLogPPT.Shift2, DBNull.Value))
        Parms(12) = New SqlParameter("@StartTime2", IIf(objCPOLogPPT.StartTime2 <> String.Empty, objCPOLogPPT.StartTime2, DBNull.Value))
        Parms(13) = New SqlParameter("@EndTime2", IIf(objCPOLogPPT.StopTime2 <> String.Empty, objCPOLogPPT.StopTime2, DBNull.Value))
        Parms(14) = New SqlParameter("@TotalBreakdown2", IIf(objCPOLogPPT.TotalBreakdown2 <> String.Empty, objCPOLogPPT.TotalBreakdown2, DBNull.Value))
        Parms(15) = New SqlParameter("@FFBProcessedEST2", IIf(objCPOLogPPT.FFBProcessedEST2 <> Nothing, objCPOLogPPT.FFBProcessedEST2, DBNull.Value))
        Parms(16) = New SqlParameter("@LorryProcessedEST2", IIf(objCPOLogPPT.LorryProcessedEST2 <> Nothing, objCPOLogPPT.LorryProcessedEST2, DBNull.Value))

        Parms(17) = New SqlParameter("@AssistantEmpID3", IIf(objCPOLogPPT.AssistantEmpID3 <> String.Empty, objCPOLogPPT.AssistantEmpID3, DBNull.Value))
        Parms(18) = New SqlParameter("@MandoreEmpID3", IIf(objCPOLogPPT.MandoreEmpID3 <> String.Empty, objCPOLogPPT.MandoreEmpID3, DBNull.Value))
        Parms(19) = New SqlParameter("@Shift3", IIf(objCPOLogPPT.Shift3 <> String.Empty, objCPOLogPPT.Shift3, DBNull.Value))
        Parms(20) = New SqlParameter("@StartTime3", IIf(objCPOLogPPT.StartTime3 <> String.Empty, objCPOLogPPT.StartTime3, DBNull.Value))
        Parms(21) = New SqlParameter("@EndTime3", IIf(objCPOLogPPT.StopTime3 <> String.Empty, objCPOLogPPT.StopTime3, DBNull.Value))
        Parms(22) = New SqlParameter("@TotalBreakdown3", IIf(objCPOLogPPT.TotalBreakdown3 <> String.Empty, objCPOLogPPT.TotalBreakdown3, DBNull.Value))
        Parms(23) = New SqlParameter("@FFBProcessedEST3", IIf(objCPOLogPPT.FFBProcessedEST3 <> Nothing, objCPOLogPPT.FFBProcessedEST3, DBNull.Value))
        Parms(24) = New SqlParameter("@LorryProcessedEST3", IIf(objCPOLogPPT.LorryProcessedEST3 <> Nothing, objCPOLogPPT.LorryProcessedEST3, DBNull.Value))
       

        Return objdb.ExecQuery("[Production].[CPOProductionLogShiftUpdate]", Parms)
    End Function
    Public Function GetCPOlogDetails(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(2) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPOlogDate", IIf(objCPOLogPPT.ProductionLogDate <> Nothing, objCPOLogPPT.ProductionLogDate, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objCPOLogPPT.CropYieldID)

        dt = objdb.ExecQuery("[Production].[CPOProductionLogSearch]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function GetCPOLogShiftInfo(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CPOProductionLogID", objCPOLogPPT.CPOProductionLogID)
        ds = objdb.ExecQuery("[Production].[GetCPOLogShiftInfo]", Parms)
        Return ds
    End Function

    'Public Function GetPKOProductionLogShiftSelect(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
    '    Dim objdb As New SQLHelp
    '    Dim ds As New DataSet
    '    Dim Parms(0) As SqlParameter
    '    Parms(0) = New SqlParameter("@PKOProductionLogID", ObjPKOProductionLogPPT.PKOProductionLogID)
    '    ds = objdb.ExecQuery("[Production].[PKOProductionLogShiftSelect]", Parms)
    '    Return ds
    'End Function

    Public Function Delete_CPOLogDetail(ByVal objCPOLogPPT As CPOProductionLogPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPOProductionLogID", objCPOLogPPT.CPOProductionLogID)
        rowsAffected = objdb.ExecNonQuery("[Production].[CPOLogDelete]", Parms)
        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function
    Public Shared Function DuplicateDateCheck(ByVal ObjCPOLogPPT As CPOProductionLogPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@CPOProductionLogDate", ObjCPOLogPPT.ProductionLogDate)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        objExists = objdb.ExecuteScalar("[Production].[DateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
    '''''''''For Press Tab''''''''''''''''''''''''''''''''

    Public Shared Function SaveProductionCPOLogPress(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@Stage", objCPOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@MachineID", IIf(objCPOProductionLogPPT.MachineID <> String.Empty, objCPOProductionLogPPT.MachineID, DBNull.Value)) 'objCPOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@MeterFrom", objCPOProductionLogPPT.MeterFrom)
        Parms(5) = New SqlParameter("@MeterTo", objCPOProductionLogPPT.MeterTo)
        Parms(6) = New SqlParameter("@OPHrs", objCPOProductionLogPPT.OPHrs)
        Parms(7) = New SqlParameter("@ScrewStatus", objCPOProductionLogPPT.ScrewStatus)
        Parms(8) = New SqlParameter("@PCage", objCPOProductionLogPPT.PCage)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(13) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(14) = New SqlParameter("@CPOProductionLogID", objCPOProductionLogPPT.CPOProductionLogID)
        Parms(15) = New SqlParameter("@ScrewAge", objCPOProductionLogPPT.ScrewAge)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressInsert]", Parms)
        Return ds
    End Function

    Public Shared Function UpdateProductionCPOLogPress(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@Stage", objCPOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@MachineID", IIf(objCPOProductionLogPPT.MachineID <> String.Empty, objCPOProductionLogPPT.MachineID, DBNull.Value))
        Parms(4) = New SqlParameter("@MeterFrom", objCPOProductionLogPPT.MeterFrom)
        Parms(5) = New SqlParameter("@MeterTo", objCPOProductionLogPPT.MeterTo)
        Parms(6) = New SqlParameter("@OPHrs", objCPOProductionLogPPT.OPHrs)
        Parms(7) = New SqlParameter("@ScrewStatus", objCPOProductionLogPPT.ScrewStatus)
        Parms(8) = New SqlParameter("@PCage", objCPOProductionLogPPT.PCage)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(11) = New SqlParameter("@ProductionLogPressID", objCPOProductionLogPPT.ProductionLogPressID)
        Parms(12) = New SqlParameter("@CPOProductionLogID", objCPOProductionLogPPT.CPOProductionLogID)
        Parms(13) = New SqlParameter("@ScrewAge", objCPOProductionLogPPT.ScrewAge)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressUpdate]", Parms)
        Return ds
    End Function

    Public Function GetPKOProductionLogPressMonthValue(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressMonthValueSelect]", Parms)
        Return ds

    End Function
    Public Function GetCPOProductionLogPressYearValue(ByVal ObjCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjCPOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressYearValueSelect]", Parms)
        Return ds

    End Function

    Public Function GetPKOProductionLogPress(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOProductionLogID", ObjPKOProductionLogPPT.PKOProductionLogID)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogPressSelect]", Parms).Tables(0)
        Return ds
    End Function

    Public Function GetPKOProductionLogPressOPHrsValue(ByVal ObjPKOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressOPHrsValueSelect]", Parms)
        Return ds
    End Function

    Public Function GetProductionPKOlogPressNo(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT, ByVal IsDirect As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PressNo", ObjPKOProductionLogPPT.PressNo)
        Parms(2) = New SqlParameter("@IsDirect", IsDirect)
        ds = objdb.ExecQuery("[Production].[ProductionPKOlogPressNoSelect]", Parms)
        Return ds
    End Function
    Public Function GetCPOProductionlogCPOTodayValue(ByVal ObjCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPOProductionLogDate", ObjCPOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[CPOProductionlogCPOTodayValueSelect]", Parms)
        Return ds
    End Function
    Public Function GetCPOProductionLogPressMonthValue(ByVal ObjCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", ObjCPOProductionLogPPT.ProductionLogDate)
        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressMonthValueSelect]", Parms)
        Return ds

    End Function
    Public Function GetCPOProductionLogPress(ByVal ObjCPOProductionLogPPT As CPOProductionLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOProductionLogID", ObjCPOProductionLogPPT.CPOProductionLogID)
        ds = objdb.ExecQuery("[Production].[CPOProductionLogPressSelect]", Parms).Tables(0)
        Return ds
    End Function
    Public Function CPOProductionLogBalanceBF(ByVal ObjCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjCPOProductionLogPPT.ProductionLogDate)
        ds = objdb.ExecQuery("[Production].[CPOProductionLogBalanceBF]", Parms)
        Return ds
    End Function



    '''''''''For Press Tab Summary''''''''''''''''''''''''''''''''

    Public Shared Function SaveCPOProductionPressSummary(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPOProductionLogID", objCPOProductionLogPPT.CPOProductionLogID)
        Parms(2) = New SqlParameter("@Stage", objCPOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@TotalPressHrsToday", objCPOProductionLogPPT.TotalPressHrsToday) 'objCPOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@TotalPressHrsMTD", objCPOProductionLogPPT.TotalPressHrsMTD)
        Parms(5) = New SqlParameter("@TotalPressHrsYTD", objCPOProductionLogPPT.TotalPressHrsYTD)
        Parms(6) = New SqlParameter("@AvgPressThrToday", objCPOProductionLogPPT.AvgPressThrToday)
        Parms(7) = New SqlParameter("@AvgPressThrMTD", objCPOProductionLogPPT.AvgPressThrMTD)
        Parms(8) = New SqlParameter("@AvgPressThrYTD", objCPOProductionLogPPT.AvgPressThrYTD)
        Parms(9) = New SqlParameter("@UtilizationToday", objCPOProductionLogPPT.UtilizationToday)
        Parms(10) = New SqlParameter("@UtilizationMTD", objCPOProductionLogPPT.UtilizationMTD)
        Parms(11) = New SqlParameter("@UtilizationYTD", objCPOProductionLogPPT.UtilizationYTD)
        Parms(12) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)



        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[CPOProductionPressSummaryInsert]", Parms)
        Return ds
    End Function

    Public Shared Function UpdateCPOProductionPressSummary(ByVal objCPOProductionLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPOProductionLogID", objCPOProductionLogPPT.CPOProductionLogID)
        Parms(2) = New SqlParameter("@Stage", objCPOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@TotalPressHrsToday", objCPOProductionLogPPT.TotalPressHrsToday) 'objCPOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@TotalPressHrsMTD", objCPOProductionLogPPT.TotalPressHrsMTD)
        Parms(5) = New SqlParameter("@TotalPressHrsYTD", objCPOProductionLogPPT.TotalPressHrsYTD)
        Parms(6) = New SqlParameter("@AvgPressThrToday", objCPOProductionLogPPT.AvgPressThrToday)
        Parms(7) = New SqlParameter("@AvgPressThrMTD", objCPOProductionLogPPT.AvgPressThrMTD)
        Parms(8) = New SqlParameter("@AvgPressThrYTD", objCPOProductionLogPPT.AvgPressThrYTD)
        Parms(9) = New SqlParameter("@UtilizationToday", objCPOProductionLogPPT.UtilizationToday)
        Parms(10) = New SqlParameter("@UtilizationMTD", objCPOProductionLogPPT.UtilizationMTD)
        Parms(11) = New SqlParameter("@UtilizationYTD", objCPOProductionLogPPT.UtilizationYTD)
        Parms(12) = New SqlParameter("@PressSummaryID", objCPOProductionLogPPT.PressSummaryID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[CPOProductionPressSummaryUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function CPOGetMonthYearQtySumm(ByVal objCPOLogPPT As CPOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionLogDate", objCPOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(4) = New SqlParameter("@Stage", objCPOLogPPT.StagePress)

        ds = objdb.ExecQuery("[Production].[CPOProductionPressSummaryHrs]", Parms)
        Return ds
    End Function


    Public Function CPOProductionLogPressMultiEntryDelete(ByVal ObjCPOProductionLogPPT As CPOProductionLogPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogPressID", ObjCPOProductionLogPPT.ProductionLogPressID)

        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionLogPressMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function



    Public Function UpdateCPOProductionLogReceivedDate()
        Dim objdb As New SQLHelp
        Dim dt As New DataTable

        'dt = objdb.ExecNonQuery("[Production].[UpdateCPOProductionLogReceivedDate]
        Return 0
    End Function

End Class

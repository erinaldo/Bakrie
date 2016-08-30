Imports Production_PPT
Imports System.Data.SqlClient
Imports Common_PPT
Imports Common_DAL

Public Class PKOProductionLogDAL
    Public Shared Function SaveProductionPKOLog(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(32) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOProductionLogPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ProductionLogDate", objPKOProductionLogPPT.ProductionLogDate)
        Parms(4) = New SqlParameter("@TotalHours", objPKOProductionLogPPT.TotalHours)
        Parms(5) = New SqlParameter("@MonthToDateHrs", objPKOProductionLogPPT.MonthToDateHrs)
        Parms(6) = New SqlParameter("@YeartoDateHrs", objPKOProductionLogPPT.YeartoDateHrs)
        Parms(7) = New SqlParameter("@BalanceKERBFQty", objPKOProductionLogPPT.BalanceKERBFQty)
        Parms(8) = New SqlParameter("@KernelProcessedACT", objPKOProductionLogPPT.KernelProcessedACT)
        Parms(9) = New SqlParameter("@KernelProcessedACTMTD", objPKOProductionLogPPT.KernelProcessedACTMTD)
        Parms(10) = New SqlParameter("@KernelProcessedACTYT", objPKOProductionLogPPT.KernelProcessedACTYT)
        Parms(11) = New SqlParameter("@LossOfKernel", objPKOProductionLogPPT.LossOfKernel)
        Parms(12) = New SqlParameter("@MechanicalBD", objPKOProductionLogPPT.MechanicalBD)
        Parms(13) = New SqlParameter("@ElectricalBD", objPKOProductionLogPPT.ElectricalBD)
        Parms(14) = New SqlParameter("@ProcessingBD", objPKOProductionLogPPT.ProcessingBD)
        Parms(15) = New SqlParameter("@TotalBD", objPKOProductionLogPPT.TotalBD)
        Parms(16) = New SqlParameter("@EffectiveProcessingHours", objPKOProductionLogPPT.EffectiveProcessingHours)
        Parms(17) = New SqlParameter("@Throughput", objPKOProductionLogPPT.Throughput)
        Parms(18) = New SqlParameter("@OER", objPKOProductionLogPPT.OER)
        Parms(19) = New SqlParameter("@Remarks", objPKOProductionLogPPT.Remarks)
        Parms(20) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(21) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(22) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(23) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(24) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        '' newly added on may 13 
        Parms(25) = New SqlParameter("@LossOfKernelMTD", IIf(objPKOProductionLogPPT.LossOfKernelMTD <> Nothing, objPKOProductionLogPPT.LossOfKernelMTD, DBNull.Value))
        Parms(26) = New SqlParameter("@MechanicalBDMTD", IIf(objPKOProductionLogPPT.MechanicalBDMTD <> Nothing, objPKOProductionLogPPT.MechanicalBDMTD, DBNull.Value))
        Parms(27) = New SqlParameter("@ElectricalBDMTD", IIf(objPKOProductionLogPPT.ElectricalBDMTD <> Nothing, objPKOProductionLogPPT.ElectricalBDMTD, DBNull.Value))
        Parms(28) = New SqlParameter("@processingBDMTD", IIf(objPKOProductionLogPPT.ProcessingBDMTD <> Nothing, objPKOProductionLogPPT.ProcessingBDMTD, DBNull.Value))
        Parms(29) = New SqlParameter("@LossOfKernelYTD", IIf(objPKOProductionLogPPT.LossOfKernelYTD <> Nothing, objPKOProductionLogPPT.LossOfKernelYTD, DBNull.Value))
        Parms(30) = New SqlParameter("@MechanicalBDYTD", IIf(objPKOProductionLogPPT.MechanicalBDYTD <> Nothing, objPKOProductionLogPPT.MechanicalBDYTD, DBNull.Value))
        Parms(31) = New SqlParameter("@ElectricalBDYTD", IIf(objPKOProductionLogPPT.ElectricalBDYTD <> Nothing, objPKOProductionLogPPT.ElectricalBDYTD, DBNull.Value))
        Parms(32) = New SqlParameter("@processingBDYTD", IIf(objPKOProductionLogPPT.ProcessingBDYTD <> Nothing, objPKOProductionLogPPT.ProcessingBDYTD, DBNull.Value))



        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionLogInsert]", Parms)
        Return ds
    End Function
    Public Shared Function SaveProductionPKOLogShift(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(18) As SqlParameter
        Parms(0) = New SqlParameter("@KernelProcessedEST3", objPKOProductionLogPPT.KernelProcessedEST3)
        Parms(1) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(2) = New SqlParameter("@AssistantEmpID1", objPKOProductionLogPPT.AssistantEmpID1)
        Parms(3) = New SqlParameter("@MandoreEmpID1", objPKOProductionLogPPT.MandoreEmpID1)
        Parms(4) = New SqlParameter("@Shift1", IIf(objPKOProductionLogPPT.Shift1 <> "0", objPKOProductionLogPPT.Shift1, DBNull.Value))
        Parms(5) = New SqlParameter("@StartTime1", IIf(objPKOProductionLogPPT.Starttime1 Is Nothing, DBNull.Value, objPKOProductionLogPPT.Starttime1))
        Parms(6) = New SqlParameter("@EndTime1", IIf(objPKOProductionLogPPT.StopTime1 Is Nothing, DBNull.Value, objPKOProductionLogPPT.StopTime1))
        Parms(7) = New SqlParameter("@KernelProcessedEST1", objPKOProductionLogPPT.KernelProcessedEST1)
        Parms(8) = New SqlParameter("@AssistantEmpID2", objPKOProductionLogPPT.AssistantEmpID2)
        Parms(9) = New SqlParameter("@MandoreEmpID2", objPKOProductionLogPPT.MandoreEmpID2)
        Parms(10) = New SqlParameter("@Shift2", IIf(objPKOProductionLogPPT.Shift2 <> "0", objPKOProductionLogPPT.Shift2, DBNull.Value))
        Parms(11) = New SqlParameter("@StartTime2", IIf(objPKOProductionLogPPT.Starttime2 Is Nothing, DBNull.Value, objPKOProductionLogPPT.Starttime2))
        Parms(12) = New SqlParameter("@EndTime2", IIf(objPKOProductionLogPPT.StopTime2 Is Nothing, DBNull.Value, objPKOProductionLogPPT.StopTime2))
        Parms(13) = New SqlParameter("@KernelProcessedEST2", objPKOProductionLogPPT.KernelProcessedEST2)
        Parms(14) = New SqlParameter("@AssistantEmpID3", objPKOProductionLogPPT.AssistantEmpID3)
        Parms(15) = New SqlParameter("@MandoreEmpID3", objPKOProductionLogPPT.MandoreEmpID3)
        Parms(16) = New SqlParameter("@Shift3", IIf(objPKOProductionLogPPT.Shift3 <> "0", objPKOProductionLogPPT.Shift3, DBNull.Value))
        Parms(17) = New SqlParameter("@StartTime3", IIf(objPKOProductionLogPPT.Starttime3 Is Nothing, DBNull.Value, objPKOProductionLogPPT.Starttime3))
        Parms(18) = New SqlParameter("@EndTime3", IIf(objPKOProductionLogPPT.StopTime3 Is Nothing, DBNull.Value, objPKOProductionLogPPT.StopTime3))
       
        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionLogShiftsInsert]", Parms)
        Return ds
    End Function
    Public Shared Function SaveProductionPKOKERReceived(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(3) = New SqlParameter("@LoadingLocationID", objPKOProductionLogPPT.LoadingLocationID)
        Parms(4) = New SqlParameter("@Qty", objPKOProductionLogPPT.KernelReceivedQty)
        Parms(5) = New SqlParameter("@Todate", objPKOProductionLogPPT.KernelReceivedQtyTodate)
        Parms(6) = New SqlParameter("@YearToDate", objPKOProductionLogPPT.KernelReceivedQtyYearTodate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(11) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionKERReceivedInsert]", Parms)
        Return ds
    End Function

    Public Shared Function SaveProductionPKOLogPress(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(15) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@Stage", objPKOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@MachineID", objPKOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@MeterFrom", objPKOProductionLogPPT.MeterFrom)
        Parms(5) = New SqlParameter("@MeterTo", objPKOProductionLogPPT.MeterTo)
        Parms(6) = New SqlParameter("@OPHrs", objPKOProductionLogPPT.OPHrs)
        Parms(7) = New SqlParameter("@ScrewStatus", objPKOProductionLogPPT.ScrewStatus)
        Parms(8) = New SqlParameter("@PCage", objPKOProductionLogPPT.PCage)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today)
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(13) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(14) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(15) = New SqlParameter("@ScrewAge", objPKOProductionLogPPT.ScrewAge)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionLogPressInsert]", Parms)
        Return ds
    End Function



    Public Shared Function UpDatePKOProductionLog(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet

        Dim objdb As New SQLHelp
        Dim Parms(30) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOProductionLogPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ProductionLogDate", objPKOProductionLogPPT.ProductionLogDate)
        'Parms(4) = New SqlParameter("@AssistantEmpID", objPKOProductionLogPPT.AssistantEmpID)
        'Parms(5) = New SqlParameter("@MandoreEmpID", objPKOProductionLogPPT.MandoreEmpID)
        'Parms(6) = New SqlParameter("@Shift", objPKOProductionLogPPT.Shift)
        'Parms(7) = New SqlParameter("@StartTime", objPKOProductionLogPPT.Starttime)
        'Parms(8) = New SqlParameter("@StopTime", objPKOProductionLogPPT.StopTime)
        'Parms(9) = New SqlParameter("@KernelProcessedEST", objPKOProductionLogPPT.KernelProcessedEST)
        Parms(4) = New SqlParameter("@TotalHours", objPKOProductionLogPPT.TotalHours)
        Parms(5) = New SqlParameter("@MonthToDateHrs", objPKOProductionLogPPT.MonthToDateHrs)
        Parms(6) = New SqlParameter("@YeartoDateHrs", objPKOProductionLogPPT.YeartoDateHrs)
        Parms(7) = New SqlParameter("@BalanceKERBFQty", objPKOProductionLogPPT.BalanceKERBFQty)
        Parms(8) = New SqlParameter("@KernelProcessedACT", objPKOProductionLogPPT.KernelProcessedACT)
        Parms(9) = New SqlParameter("@KernelProcessedACTMTD", objPKOProductionLogPPT.KernelProcessedACTMTD)
        Parms(10) = New SqlParameter("@KernelProcessedACTYT", objPKOProductionLogPPT.KernelProcessedACTYT)
        Parms(11) = New SqlParameter("@LossOfKernel", objPKOProductionLogPPT.LossOfKernel)
        Parms(12) = New SqlParameter("@MechanicalBD", objPKOProductionLogPPT.MechanicalBD)
        Parms(13) = New SqlParameter("@ElectricalBD", objPKOProductionLogPPT.ElectricalBD)
        Parms(14) = New SqlParameter("@ProcessingBD", objPKOProductionLogPPT.ProcessingBD)
        Parms(15) = New SqlParameter("@TotalBD", objPKOProductionLogPPT.TotalBD)
        Parms(16) = New SqlParameter("@EffectiveProcessingHours", objPKOProductionLogPPT.EffectiveProcessingHours)
        Parms(17) = New SqlParameter("@Throughput", objPKOProductionLogPPT.Throughput)
        Parms(18) = New SqlParameter("@OER", objPKOProductionLogPPT.OER)
        Parms(19) = New SqlParameter("@Remarks", objPKOProductionLogPPT.Remarks)
        Parms(20) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(21) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(22) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        '' newly added on may 13 
        Parms(23) = New SqlParameter("@LossOfKernelMTD", IIf(objPKOProductionLogPPT.LossOfKernelMTD <> Nothing, objPKOProductionLogPPT.LossOfKernelMTD, DBNull.Value))
        Parms(24) = New SqlParameter("@MechanicalBDMTD", IIf(objPKOProductionLogPPT.MechanicalBDMTD <> Nothing, objPKOProductionLogPPT.MechanicalBDMTD, DBNull.Value))
        Parms(25) = New SqlParameter("@ElectricalBDMTD", IIf(objPKOProductionLogPPT.ElectricalBDMTD <> Nothing, objPKOProductionLogPPT.ElectricalBDMTD, DBNull.Value))
        Parms(26) = New SqlParameter("@processingBDMTD", IIf(objPKOProductionLogPPT.ProcessingBDMTD <> Nothing, objPKOProductionLogPPT.ProcessingBDMTD, DBNull.Value))
        Parms(27) = New SqlParameter("@LossOfKernelYTD", IIf(objPKOProductionLogPPT.LossOfKernelYTD <> Nothing, objPKOProductionLogPPT.LossOfKernelYTD, DBNull.Value))
        Parms(28) = New SqlParameter("@MechanicalBDYTD", IIf(objPKOProductionLogPPT.MechanicalBDYTD <> Nothing, objPKOProductionLogPPT.MechanicalBDYTD, DBNull.Value))
        Parms(29) = New SqlParameter("@ElectricalBDYTD", IIf(objPKOProductionLogPPT.ElectricalBDYTD <> Nothing, objPKOProductionLogPPT.ElectricalBDYTD, DBNull.Value))
        Parms(30) = New SqlParameter("@processingBDYTD", IIf(objPKOProductionLogPPT.ProcessingBDYTD <> Nothing, objPKOProductionLogPPT.ProcessingBDYTD, DBNull.Value))


        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionLogUpdate]", Parms)
        Return ds

    End Function

    Public Shared Function UpdateProductionPKOLogShift(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(18) As SqlParameter
        Parms(0) = New SqlParameter("@KernelProcessedEST3", objPKOProductionLogPPT.KernelProcessedEST3)
        Parms(1) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(2) = New SqlParameter("@AssistantEmpID1", objPKOProductionLogPPT.AssistantEmpID1)
        Parms(3) = New SqlParameter("@MandoreEmpID1", objPKOProductionLogPPT.MandoreEmpID1)
        Parms(4) = New SqlParameter("@Shift1", IIf(objPKOProductionLogPPT.Shift1 <> "0", objPKOProductionLogPPT.Shift1, DBNull.Value))
        Parms(5) = New SqlParameter("@StartTime1", IIf(objPKOProductionLogPPT.Starttime1 Is Nothing, DBNull.Value, objPKOProductionLogPPT.Starttime1))
        Parms(6) = New SqlParameter("@EndTime1", IIf(objPKOProductionLogPPT.StopTime1 Is Nothing, DBNull.Value, objPKOProductionLogPPT.StopTime1))
        Parms(7) = New SqlParameter("@KernelProcessedEST1", objPKOProductionLogPPT.KernelProcessedEST1)
        Parms(8) = New SqlParameter("@AssistantEmpID2", objPKOProductionLogPPT.AssistantEmpID2)
        Parms(9) = New SqlParameter("@MandoreEmpID2", objPKOProductionLogPPT.MandoreEmpID2)
        Parms(10) = New SqlParameter("@Shift2", IIf(objPKOProductionLogPPT.Shift2 <> "0", objPKOProductionLogPPT.Shift2, DBNull.Value))
        Parms(11) = New SqlParameter("@StartTime2", IIf(objPKOProductionLogPPT.Starttime2 Is Nothing, DBNull.Value, objPKOProductionLogPPT.Starttime2))
        Parms(12) = New SqlParameter("@EndTime2", IIf(objPKOProductionLogPPT.StopTime2 Is Nothing, DBNull.Value, objPKOProductionLogPPT.StopTime2))
        Parms(13) = New SqlParameter("@KernelProcessedEST2", objPKOProductionLogPPT.KernelProcessedEST2)
        Parms(14) = New SqlParameter("@AssistantEmpID3", objPKOProductionLogPPT.AssistantEmpID3)
        Parms(15) = New SqlParameter("@MandoreEmpID3", objPKOProductionLogPPT.MandoreEmpID3)
        Parms(16) = New SqlParameter("@Shift3", IIf(objPKOProductionLogPPT.Shift3 <> "0", objPKOProductionLogPPT.Shift3, DBNull.Value))
        Parms(17) = New SqlParameter("@StartTime3", IIf(objPKOProductionLogPPT.Starttime3 Is Nothing, DBNull.Value, objPKOProductionLogPPT.Starttime3))
        Parms(18) = New SqlParameter("@EndTime3", IIf(objPKOProductionLogPPT.StopTime3 Is Nothing, DBNull.Value, objPKOProductionLogPPT.StopTime3))

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionLogShiftsUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function UpdateProductionPKOKERReceived(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(9) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(3) = New SqlParameter("@LoadingLocationID", objPKOProductionLogPPT.LoadingLocationID)
        Parms(4) = New SqlParameter("@Qty", objPKOProductionLogPPT.KernelReceivedQty)
        Parms(5) = New SqlParameter("@Todate", objPKOProductionLogPPT.KernelReceivedQtyTodate)
        Parms(6) = New SqlParameter("@YearToDate", objPKOProductionLogPPT.KernelReceivedQtyYearTodate)
        Parms(7) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(9) = New SqlParameter("@PKOKERReceivedID", objPKOProductionLogPPT.PKOKERReceivedID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionKERReceivedUpdate]", Parms)
        Return ds
    End Function

    Public Shared Function UpdateProductionPKOLogPress(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@Stage", objPKOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@MachineID", objPKOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@MeterFrom", objPKOProductionLogPPT.MeterFrom)
        Parms(5) = New SqlParameter("@MeterTo", objPKOProductionLogPPT.MeterTo)
        Parms(6) = New SqlParameter("@OPHrs", objPKOProductionLogPPT.OPHrs)
        Parms(7) = New SqlParameter("@ScrewStatus", objPKOProductionLogPPT.ScrewStatus)
        Parms(8) = New SqlParameter("@PCage", objPKOProductionLogPPT.PCage)
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today)
        Parms(11) = New SqlParameter("@ProductionLogPressID", objPKOProductionLogPPT.ProductionLogPressID)
        Parms(12) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(13) = New SqlParameter("@ScrewAge", objPKOProductionLogPPT.ScrewAge)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionLogPressUpdate]", Parms)
        Return ds
    End Function
    Public Function GetPKOProductionLogShiftSelect(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@PKOProductionLogID", ObjPKOProductionLogPPT.PKOProductionLogID)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogShiftSelect]", Parms)
        Return ds
    End Function


    Public Function GetMonthValues(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogMonthValueSelect]", Parms)
        Return ds
    End Function

    Public Function GetYearValues(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(2) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogYearValueSelect]", Parms)
        Return ds
    End Function
    Public Function GetMonthYearValues(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@ActiveYear", GlobalPPT.intLoginYear)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogMonthYearSelect]", Parms)
        Return ds
    End Function
   

    Public Function DeletePKOProductionLog(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOProductionLogID", ObjPKOProductionLogPPT.PKOProductionLogID)
        rowsAffected = objdb.ExecNonQuery("[Production].[PKOProductionLogDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected

    End Function

    Public Function GetKernelProductionStorage(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogKernelStorageSelect]", Parms)
        Return ds
    End Function


    Public Function GetPKOProdLogLoadingLocation(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim ds As New DataTable
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Production].[PKOProdLogLoadingLocationSelect]", Parms).Tables(0)
        Return ds
    End Function

    Public Function DuplicatePKOProductionDate(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)

        objExists = objdb.ExecuteScalar("[Production].[PKOProductionLogIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function

    Public Function GetQuantityForCorrespondigLocation(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@TranshipLoadingLocationID", ObjPKOProductionLogPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@CPODate", ObjPKOProductionLogPPT.ProductionLogDate)
        objExists = objdb.ExecuteScalar("[Production].[GetQuantityForCorrespondigLocation]", Parms)
        Return objExists
    End Function



    Public Function GetPKOProductionLogPressMonthValue(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearId", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogPressMonthValueSelect]", Parms)
        Return ds

    End Function
    Public Function GetPKOProductionLogPressYearValue(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogPressYearValueSelect]", Parms)
        Return ds

    End Function

    Public Function GetPKOProductionLog(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        ds = objdb.ExecQuery("[Production].[PKOProductionLogSelect]", Parms).Tables(0)
        Return ds
    End Function
    Public Function GetPKOProductionLogKerReceived(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim ds As New DataTable

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOProductionLogID", ObjPKOProductionLogPPT.PKOProductionLogID)
        ds = objdb.ExecQuery("[Production].[PKOProductionKERReceivedSelect]", Parms).Tables(0)
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



    Public Function GetPKOProductionLogPressOPHrsValue(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[PKOProductionLogPressOPHrsValueSelect]", Parms)
        Return ds
    End Function
    Public Function GetPKOProductionlogPKOMonthYearValue(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[PKOProductionLogPKOQtySelect]", Parms)
        Return ds
    End Function
    Public Function GetPKOProductionlogPKOMonthYearValueSelect(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[PKOProductionlogPKOMonthYearValueSelect]", Parms)
        Return ds
    End Function
    Public Function GetPKOProductionlogPKOTodayValue(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        ds = objdb.ExecQuery("[Production].[PKOProductionlogPKOTodayValueSelect]", Parms)
        Return ds
    End Function

    Public Function GetProductionPKOlogPressNo(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT, ByVal IsDirect As String, ByVal Type As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PressNo", ObjPKOProductionLogPPT.PressNo)
        Parms(2) = New SqlParameter("@IsDirect", IsDirect)
        Parms(3) = New SqlParameter("@Type", Type)

        ds = objdb.ExecQuery("[Production].[ProductionPKOlogPressNoSelect]", Parms)
        Return ds
    End Function

    Public Function GetPKOProductionlogCropYieldID(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ds = objdb.ExecQuery("[Production].[PKOProductionlogCropYieldIDSelect]", Parms)
        Return ds
    End Function

    Public Function GetPKOProductionLogKerRecdMonthValueCheckSelect(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LoadingLoactionID", ObjPKOProductionLogPPT.LoadingLocationID)


        ds = objdb.ExecQuery("[Production].[PKOProductionLogKerRecdMonthValueCheckSelect]", Parms)
        Return ds
    End Function
    Public Function GetPKOProductionLogKerRecdMonthValueSelect(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Dim ds As New DataSet

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogDate", ObjPKOProductionLogPPT.ProductionLogDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@LoadingLoactionID", ObjPKOProductionLogPPT.LoadingLocationID)
        Parms(4) = New SqlParameter("@ActiveYear", GlobalPPT.intActiveYear)

        ds = objdb.ExecQuery("[Production].[PKOProductionLogKerRecdMonthValueSelect]", Parms)
        Return ds
    End Function

    Public Shared Function PKOGetMonthYearQty(ByVal objPKOLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@ProductionLogDate", objPKOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        ds = objdb.ExecQuery("[Production].[PKOGetMonthYearHrs]", Parms)
        Return ds
    End Function
    '''''''''For Press Tab Summary''''''''''''''''''''''''''''''''

    Public Shared Function SavePKOProductionPressSummary(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(2) = New SqlParameter("@Stage", objPKOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@TotalPressHrsToday", objPKOProductionLogPPT.TotalPressHrsToday) 'objPKOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@TotalPressHrsMTD", objPKOProductionLogPPT.TotalPressHrsMTD)
        Parms(5) = New SqlParameter("@TotalPressHrsYTD", objPKOProductionLogPPT.TotalPressHrsYTD)
        Parms(6) = New SqlParameter("@AvgPressThrToday", objPKOProductionLogPPT.AvgPressThrToday)
        Parms(7) = New SqlParameter("@AvgPressThrMTD", objPKOProductionLogPPT.AvgPressThrMTD)
        Parms(8) = New SqlParameter("@AvgPressThrYTD", objPKOProductionLogPPT.AvgPressThrYTD)
        Parms(9) = New SqlParameter("@UtilizationToday", objPKOProductionLogPPT.UtilizationToday)
        Parms(10) = New SqlParameter("@UtilizationMTD", objPKOProductionLogPPT.UtilizationMTD)
        Parms(11) = New SqlParameter("@UtilizationYTD", objPKOProductionLogPPT.UtilizationYTD)
        Parms(12) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionPressSummaryInsert]", Parms)
        Return ds
    End Function

    Public Shared Function UpdatePKOProductionPressSummary(ByVal objPKOProductionLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOProductionLogID", objPKOProductionLogPPT.PKOProductionLogID)
        Parms(2) = New SqlParameter("@Stage", objPKOProductionLogPPT.StagePress)
        Parms(3) = New SqlParameter("@TotalPressHrsToday", objPKOProductionLogPPT.TotalPressHrsToday) 'objPKOProductionLogPPT.MachineID)
        Parms(4) = New SqlParameter("@TotalPressHrsMTD", objPKOProductionLogPPT.TotalPressHrsMTD)
        Parms(5) = New SqlParameter("@TotalPressHrsYTD", objPKOProductionLogPPT.TotalPressHrsYTD)
        Parms(6) = New SqlParameter("@AvgPressThrToday", objPKOProductionLogPPT.AvgPressThrToday)
        Parms(7) = New SqlParameter("@AvgPressThrMTD", objPKOProductionLogPPT.AvgPressThrMTD)
        Parms(8) = New SqlParameter("@AvgPressThrYTD", objPKOProductionLogPPT.AvgPressThrYTD)
        Parms(9) = New SqlParameter("@UtilizationToday", objPKOProductionLogPPT.UtilizationToday)
        Parms(10) = New SqlParameter("@UtilizationMTD", objPKOProductionLogPPT.UtilizationMTD)
        Parms(11) = New SqlParameter("@UtilizationYTD", objPKOProductionLogPPT.UtilizationYTD)
        Parms(12) = New SqlParameter("@PressSummaryID", objPKOProductionLogPPT.PressSummaryID)

        Dim ds As New DataSet
        ds = objdb.ExecQuery("[Production].[PKOProductionPressSummaryUpdate]", Parms)
        Return ds
    End Function



    Public Shared Function PKOGetMonthYearQtySumm(ByVal objPKOLogPPT As PKOProductionLogPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim ds As New DataSet
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@PKOProductionLogDate", objPKOLogPPT.ProductionLogDate)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Parms(4) = New SqlParameter("@Stage", objPKOLogPPT.StagePress)

        ds = objdb.ExecQuery("[Production].[PKOProductionPressSummaryHrs]", Parms)
        Return ds
    End Function


    Public Function PKOProductionLogPressMultiEntryDelete(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionLogPressID", ObjPKOProductionLogPPT.ProductionLogPressID)

        rowsAffected = objdb.ExecNonQuery("[Production].[PKOProductionLogPressMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function


    Public Function PKOProductionKerRecdMultiEntryDelete(ByVal ObjPKOProductionLogPPT As PKOProductionLogPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@PKOKERReceivedID", ObjPKOProductionLogPPT.PKOKERReceivedID)

        rowsAffected = objdb.ExecNonQuery("[Production].[PKOProductionKerRecdMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function


End Class

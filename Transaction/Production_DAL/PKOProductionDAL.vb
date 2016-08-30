Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class PKOProductionDAL
    Public Shared Function loadCmbStorage() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[PKOGetStorage]", Parms)
    End Function
    Public Shared Function GetTankID(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objPKOPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function UpdateTankMasterBFQty(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@StockTankID", IIf(objPKOPPT.StockTankID <> String.Empty, objPKOPPT.StockTankID, DBNull.Value))
        Parms(2) = New SqlParameter("@CurrentReading", objPKOPPT.CurrentReading)
        Parms(3) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Return objdb.ExecQuery("[Production].[TankMasterBFUpdate]", Parms)
    End Function
    Public Shared Function PKOGetMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearQty]", Parms)
    End Function
    Public Shared Function PKOGetTodayQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Return objdb.ExecQuery("[Production].[CPOGetTodayQty]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Descp", objPKOPPT.Descp)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLocationID]", Parms)
    End Function

    Public Shared Function tankDetailSelect(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@TankID", objPKOPPT.TankID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOTankDetailSelect]", Parms)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Type", "Loading")
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocation]", Parms)
    End Function
    Public Shared Function GetCropYield(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objPKOPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetPKOAddInfo(ByVal objPKOPPT As PKOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@StockTankID", objPKOPPT.StockTankID)
        'Parms(2) = New SqlParameter("@LoadTankID", objPKOPPT.LoadTankID)
        'Parms(3) = New SqlParameter("@TransTankID", objPKOPPT.TransTankID)
        'Parms(4) = New SqlParameter("@LoadLocationID", objPKOPPT.LoadingLocationID)
        'Parms(5) = New SqlParameter("@TransLocationID", objPKOPPT.TransLocationID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        'Parms(4) = New SqlParameter("@TankNo", objPKOPPT.TankNo)
        Parms(3) = New SqlParameter("@CPODate", objPKOPPT.PKODate)

        Return objdb.ExecQuery("[Production].[GetCPOAddInfo]", Parms).Tables(0)
    End Function
    Public Shared Function savePKOProduction(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(28) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objPKOPPT.StockTankID <> String.Empty, objPKOPPT.StockTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadTankID", IIf(objPKOPPT.LoadTankID <> String.Empty, objPKOPPT.LoadTankID, DBNull.Value))
        Parms(5) = New SqlParameter("@TransTankID", IIf(objPKOPPT.TransTankID <> String.Empty, objPKOPPT.TransTankID, DBNull.Value))
        Parms(6) = New SqlParameter("@Capacity", objPKOPPT.Capacity)
        Parms(7) = New SqlParameter("@BalanceBF", objPKOPPT.balance)
        Parms(8) = New SqlParameter("@CurrentReading", objPKOPPT.CurrentReading)
        Parms(9) = New SqlParameter("@Measurement", objPKOPPT.Measurement)
        Parms(10) = New SqlParameter("@Temp", objPKOPPT.Temparature)
        Parms(11) = New SqlParameter("@FFAP", objPKOPPT.FFA)
        Parms(12) = New SqlParameter("@MoistureP", objPKOPPT.Moisture)
        Parms(13) = New SqlParameter("@DirtP", objPKOPPT.Dirt)
        Parms(14) = New SqlParameter("@LoadingLocationID", objPKOPPT.LoadingLocationID)
        Parms(15) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(16) = New SqlParameter("@CPOProductionDate", objPKOPPT.PKODate)
        Parms(17) = New SqlParameter("@QtyToday", objPKOPPT.ProductionToday)
        Parms(18) = New SqlParameter("@QtyMonthToDate", objPKOPPT.ProductionMonth)
        Parms(19) = New SqlParameter("@QtyYearTodate", objPKOPPT.ProductionYear)
        Parms(20) = New SqlParameter("@TransQty", objPKOPPT.TransQty)
        Parms(21) = New SqlParameter("@TransMonthToDate", objPKOPPT.TransMonthToDate)
        Parms(22) = New SqlParameter("@LoadQty", objPKOPPT.LoadQty)
        Parms(23) = New SqlParameter("@LoadMonthToDate", objPKOPPT.LoadMonthToDate)
        Parms(24) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(25) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(26) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(27) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(28) = New SqlParameter("@TransLocationID", objPKOPPT.TransLocationID)
        Return objdb.ExecQuery("[Production].[PKOProductionInsert]", Parms)
    End Function
    ' '' '' '' '' '' '' ''Public Shared Function saveCPOProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
    ' '' '' '' '' '' '' ''    Dim objdb As New SQLHelp
    ' '' '' '' '' '' '' ''    Dim Parms(11) As SqlParameter
    ' '' '' '' '' '' '' ''    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    ' '' '' '' '' '' '' ''    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    ' '' '' '' '' '' '' ''    Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
    ' '' '' '' '' '' '' ''    'Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(4) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(5) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(6) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
    ' '' '' '' '' '' '' ''    'Parms(7) = New SqlParameter("@BalanceBF", objCPOPPT.balance)
    ' '' '' '' '' '' '' ''    'Parms(8) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
    ' '' '' '' '' '' '' ''    'Parms(9) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
    ' '' '' '' '' '' '' ''    'Parms(10) = New SqlParameter("@Temp", objCPOPPT.Temparature)
    ' '' '' '' '' '' '' ''    'Parms(11) = New SqlParameter("@FFAP", objCPOPPT.FFA)
    ' '' '' '' '' '' '' ''    'Parms(12) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
    ' '' '' '' '' '' '' ''    'Parms(13) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
    ' '' '' '' '' '' '' ''    'Parms(14) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
    ' '' '' '' '' '' '' ''    Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
    ' '' '' '' '' '' '' ''    Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
    ' '' '' '' '' '' '' ''    Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
    ' '' '' '' '' '' '' ''    Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
    ' '' '' '' '' '' '' ''    'Parms(20) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
    ' '' '' '' '' '' '' ''    'Parms(21) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
    ' '' '' '' '' '' '' ''    'Parms(22) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
    ' '' '' '' '' '' '' ''    'Parms(23) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
    ' '' '' '' '' '' '' ''    Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
    ' '' '' '' '' '' '' ''    'Parms(28) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Return objdb.ExecQuery("[Production].[CPOProductionInsert]", Parms)
    ' '' '' '' '' '' '' ''End Function
    ' '' '' '' '' '' '' ''Public Shared Function saveCPOTransProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
    ' '' '' '' '' '' '' ''    Dim objdb As New SQLHelp
    ' '' '' '' '' '' '' ''    Dim Parms(12) As SqlParameter
    ' '' '' '' '' '' '' ''    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    ' '' '' '' '' '' '' ''    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    ' '' '' '' '' '' '' ''    Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
    ' '' '' '' '' '' '' ''    'Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(4) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(3) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(6) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
    ' '' '' '' '' '' '' ''    'Parms(7) = New SqlParameter("@BalanceBF", objCPOPPT.balance)
    ' '' '' '' '' '' '' ''    'Parms(8) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
    ' '' '' '' '' '' '' ''    'Parms(9) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
    ' '' '' '' '' '' '' ''    'Parms(10) = New SqlParameter("@Temp", objCPOPPT.Temparature)
    ' '' '' '' '' '' '' ''    'Parms(11) = New SqlParameter("@FFAP", objCPOPPT.FFA)
    ' '' '' '' '' '' '' ''    'Parms(12) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
    ' '' '' '' '' '' '' ''    'Parms(13) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
    ' '' '' '' '' '' '' ''    'Parms(14) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(4) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
    ' '' '' '' '' '' '' ''    'Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
    ' '' '' '' '' '' '' ''    'Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
    ' '' '' '' '' '' '' ''    'Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
    ' '' '' '' '' '' '' ''    'Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
    ' '' '' '' '' '' '' ''    Parms(5) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
    ' '' '' '' '' '' '' ''    Parms(6) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
    ' '' '' '' '' '' '' ''    'Parms(22) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
    ' '' '' '' '' '' '' ''    'Parms(23) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
    ' '' '' '' '' '' '' ''    Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(11) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(12) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
    ' '' '' '' '' '' '' ''    Return objdb.ExecQuery("[Production].[CPOProductionTransInsert]", Parms)
    ' '' '' '' '' '' '' ''End Function
    ' '' '' '' '' '' '' ''Public Shared Function saveCPOStockProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
    ' '' '' '' '' '' '' ''    Dim objdb As New SQLHelp
    ' '' '' '' '' '' '' ''    Dim Parms(17) As SqlParameter
    ' '' '' '' '' '' '' ''    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    ' '' '' '' '' '' '' ''    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    ' '' '' '' '' '' '' ''    Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
    ' '' '' '' '' '' '' ''    Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(4) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(5) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(4) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
    ' '' '' '' '' '' '' ''    Parms(5) = New SqlParameter("@BalanceBF", objCPOPPT.balance)
    ' '' '' '' '' '' '' ''    Parms(6) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
    ' '' '' '' '' '' '' ''    Parms(7) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
    ' '' '' '' '' '' '' ''    Parms(8) = New SqlParameter("@Temp", objCPOPPT.Temparature)
    ' '' '' '' '' '' '' ''    Parms(9) = New SqlParameter("@FFAP", objCPOPPT.FFA)
    ' '' '' '' '' '' '' ''    Parms(10) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
    ' '' '' '' '' '' '' ''    Parms(11) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
    ' '' '' '' '' '' '' ''    'Parms(14) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(12) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
    ' '' '' '' '' '' '' ''    'Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
    ' '' '' '' '' '' '' ''    'Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
    ' '' '' '' '' '' '' ''    'Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
    ' '' '' '' '' '' '' ''    'Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
    ' '' '' '' '' '' '' ''    'Parms(20) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
    ' '' '' '' '' '' '' ''    'Parms(21) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
    ' '' '' '' '' '' '' ''    'Parms(22) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
    ' '' '' '' '' '' '' ''    'Parms(23) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
    ' '' '' '' '' '' '' ''    Parms(13) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(14) = New SqlParameter("@CreatedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(15) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(16) = New SqlParameter("@ModifiedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(17) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
    ' '' '' '' '' '' '' ''    'Parms(28) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Return objdb.ExecQuery("[Production].[CPOProductionStockInsert]", Parms)
    ' '' '' '' '' '' '' ''End Function
    ' '' '' '' '' '' '' ''Public Shared Function saveCPOLoadProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
    ' '' '' '' '' '' '' ''    Dim objdb As New SQLHelp
    ' '' '' '' '' '' '' ''    Dim Parms(13) As SqlParameter
    ' '' '' '' '' '' '' ''    Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
    ' '' '' '' '' '' '' ''    Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
    ' '' '' '' '' '' '' ''    Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
    ' '' '' '' '' '' '' ''    Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(4) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(5) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
    ' '' '' '' '' '' '' ''    'Parms(6) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
    ' '' '' '' '' '' '' ''    'Parms(7) = New SqlParameter("@BalanceBF", objCPOPPT.balance)
    ' '' '' '' '' '' '' ''    'Parms(8) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
    ' '' '' '' '' '' '' ''    'Parms(9) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
    ' '' '' '' '' '' '' ''    'Parms(10) = New SqlParameter("@Temp", objCPOPPT.Temparature)
    ' '' '' '' '' '' '' ''    'Parms(11) = New SqlParameter("@FFAP", objCPOPPT.FFA)
    ' '' '' '' '' '' '' ''    'Parms(12) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
    ' '' '' '' '' '' '' ''    'Parms(13) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
    ' '' '' '' '' '' '' ''    Parms(5) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Parms(6) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
    ' '' '' '' '' '' '' ''    'Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
    ' '' '' '' '' '' '' ''    'Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
    ' '' '' '' '' '' '' ''    'Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
    ' '' '' '' '' '' '' ''    'Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
    ' '' '' '' '' '' '' ''    'Parms(20) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
    ' '' '' '' '' '' '' ''    'Parms(21) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
    ' '' '' '' '' '' '' ''    Parms(7) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
    ' '' '' '' '' '' '' ''    Parms(8) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
    ' '' '' '' '' '' '' ''    Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(10) = New SqlParameter("@CreatedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
    ' '' '' '' '' '' '' ''    Parms(12) = New SqlParameter("@ModifiedOn", Date.Today())
    ' '' '' '' '' '' '' ''    Parms(13) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
    ' '' '' '' '' '' '' ''    'Parms(28) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
    ' '' '' '' '' '' '' ''    Return objdb.ExecQuery("[Production].[CPOProductionLoadInsert]", Parms)
    ' '' '' '' '' '' '' ''End Function



    Public Shared Function UpdatePKOProduction(ByVal objPKOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(29) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objPKOPPT.StockTankID <> String.Empty, objPKOPPT.StockTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadTankID", IIf(objPKOPPT.LoadTankID <> String.Empty, objPKOPPT.LoadTankID, DBNull.Value))
        Parms(5) = New SqlParameter("@TransTankID", IIf(objPKOPPT.TransTankID <> String.Empty, objPKOPPT.TransTankID, DBNull.Value))
        Parms(6) = New SqlParameter("@Capacity", objPKOPPT.Capacity)
        Parms(7) = New SqlParameter("@BalanceBF", objPKOPPT.balance)
        Parms(8) = New SqlParameter("@CurrentReading", objPKOPPT.CurrentReading)
        Parms(9) = New SqlParameter("@Measurement", objPKOPPT.Measurement)
        Parms(10) = New SqlParameter("@Temp", objPKOPPT.Temparature)
        Parms(11) = New SqlParameter("@FFAP", objPKOPPT.FFA)
        Parms(12) = New SqlParameter("@MoistureP", objPKOPPT.Moisture)
        Parms(13) = New SqlParameter("@DirtP", objPKOPPT.Dirt)
        Parms(14) = New SqlParameter("@LoadingLocationID", objPKOPPT.LoadingLocationID)
        Parms(15) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(16) = New SqlParameter("@CPOProductionDate", objPKOPPT.PKODate)
        Parms(17) = New SqlParameter("@QtyToday", objPKOPPT.ProductionToday)
        Parms(18) = New SqlParameter("@QtyMonthToDate", objPKOPPT.ProductionMonth)
        Parms(19) = New SqlParameter("@QtyYearTodate", objPKOPPT.ProductionYear)
        Parms(20) = New SqlParameter("@TransQty", objPKOPPT.TransQty)
        Parms(21) = New SqlParameter("@TransMonthToDate", objPKOPPT.TransMonthToDate)
        Parms(22) = New SqlParameter("@LoadQty", objPKOPPT.LoadQty)
        Parms(23) = New SqlParameter("@LoadMonthToDate", objPKOPPT.LoadMonthToDate)
        Parms(24) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(25) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(26) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(27) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(28) = New SqlParameter("@TransLocationID", objPKOPPT.TransLocationID)
        Parms(29) = New SqlParameter("@ProductionID", objPKOPPT.ProductionID)

        Return objdb.ExecQuery("[Production].[PKOProductionUpdate]", Parms)
    End Function
    Public Function GetPKODetails(ByVal objPKOPPT As PKOProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objPKOPPT.PKODate <> Nothing, objPKOPPT.PKODate, DBNull.Value))
        ' params(1) = New SqlParameter("@ProdStockID", IIf(objPKOPPT.ProdStockID <> "", objPKOPPT.ProdStockID, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        ' params(3) = New SqlParameter("@TankNo", objPKOPPT.TankNo)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Production].[CPOProductionSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_PKODetail(ByVal objPKOPPT As PKOProductionPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim rowsAffected As Integer = 0

        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(0) = New SqlParameter("@ProductionID", objPKOPPT.ProductionID)
        Parms(1) = New SqlParameter("@ProdStockID", objPKOPPT.ProdStockID)
        Parms(2) = New SqlParameter("@ProdTranshipID", objPKOPPT.ProdTranshipID)
        Parms(3) = New SqlParameter("@ProdLoadingID", objPKOPPT.ProdLoadingID)

        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function

    ''Changed by kumar
    Public Shared Function loadCmbStorageBalanceBF(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Return objdb.ExecQuery("[Production].[CPOGetStorageBalanceBF]", Parms)
    End Function


    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetLoadingCPOMonthtodate]", Parms)
    End Function

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetTranshipCPOMonthtodate]", Parms)
    End Function

    Public Shared Function CPOProductionMonthYeartodate(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOProductionMonthYeartodate]", Parms)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As PKOProductionPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "PKO")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function

    Public Function DuplicateDateCheck(ByVal objCPOPPT As PKOProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[CPODateIsExist]", Parms)
        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If
    End Function
End Class

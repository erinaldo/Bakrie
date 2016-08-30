Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class KernalProductionDAL
    Public Shared Function loadCmbKernalStorage() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[KernalGetStorage]", Parms)
    End Function
    Public Shared Function loadCmbKernalCodeDesc() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[KernelGetCodeDesc]", Parms)
    End Function
    Public Shared Function GetKernalID(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@KernalType", objKernalPPT.KernelType)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetKernalID]", Parms)
    End Function
    Public Shared Function GetTankID(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objKernalPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function KernelGetMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)
        Return objdb.ExecQuery("[Production].[CPOGetMonthYearQty]", Parms)
    End Function
    Public Shared Function KernelGetTodayQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Return objdb.ExecQuery("[Production].[CPOGetTodayQty]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Descp", objKernalPPT.Descp)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLocationID]", Parms)
    End Function

    Public Shared Function tankDetailSelect(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@TankID", objKernalPPT.TankID)
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
    Public Shared Function GetCropYield(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objKernalPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetKernalAddInfo(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)

        Parms(3) = New SqlParameter("@KernalDate", objKernalPPT.KernalDate)

        Return objdb.ExecQuery("[Production].[GetKernelStockAddInfo]", Parms).Tables(0)
    End Function
    Public Shared Function GetKernelLoadAddInfo(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)
        Parms(3) = New SqlParameter("@KernalDate", objKernalPPT.KernalDate)

        Return objdb.ExecQuery("[Production].[GetKernelLoadAddInfo]", Parms).Tables(0)
    End Function
    Public Shared Function GetKernelTransAddInfo(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)
        Parms(3) = New SqlParameter("@KernalDate", objKernalPPT.KernalDate)

        Return objdb.ExecQuery("[Production].[GetKernelTransAddInfo]", Parms).Tables(0)
    End Function
    Public Shared Function saveKernalTransProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)

        Parms(3) = New SqlParameter("@KernelStorageID", IIf(objKernalPPT.TransTankID <> String.Empty, objKernalPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@TransQty", objKernalPPT.TransQty)
        Parms(5) = New SqlParameter("@TransMonthToDate", objKernalPPT.TransMonthToDate)
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@TransLocationID", IIf(objKernalPPT.TransLocationID <> String.Empty, objKernalPPT.TransLocationID, DBNull.Value))
        Parms(11) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)
        Parms(12) = New SqlParameter("@TransRemarks", objKernalPPT.TransRemarks)
        Parms(13) = New SqlParameter("@TransTankID", DBNull.Value)

        Return objdb.ExecQuery("[Production].[KernalProductionTransInsert]", Parms)
    End Function
    Public Shared Function saveKernalProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objKernalPPT.KernalDate)
        Parms(5) = New SqlParameter("@QtyToday", objKernalPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objKernalPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objKernalPPT.ProductionYear)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Return objdb.ExecQuery("[Production].[KernalProductionInsert]", Parms)
    End Function
    Public Shared Function saveKernalStockProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(19) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockKernalID", IIf(objKernalPPT.StockKernalID <> String.Empty, objKernalPPT.StockKernalID, DBNull.Value))
        Parms(4) = New SqlParameter("@Capacity", objKernalPPT.Capacity)
        Parms(5) = New SqlParameter("@BalanceBF", objKernalPPT.balance)
        Parms(6) = New SqlParameter("@CurrentReading", objKernalPPT.CurrentReading)
        Parms(7) = New SqlParameter("@Measurement", objKernalPPT.Measurement)
        Parms(8) = New SqlParameter("@Temp", objKernalPPT.Temparature)
        Parms(9) = New SqlParameter("@FFAP", objKernalPPT.FFA)
        Parms(10) = New SqlParameter("@MoistureP", objKernalPPT.Moisture)
        Parms(11) = New SqlParameter("@DirtP", objKernalPPT.Dirt)
        Parms(12) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(14) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(15) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(16) = New SqlParameter("@StockTankID", IIf(objKernalPPT.StockTankID <> String.Empty, objKernalPPT.StockTankID, DBNull.Value))
        Parms(17) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)
        Parms(18) = New SqlParameter("@Writeoff", objKernalPPT.Writeoff)
        Parms(19) = New SqlParameter("@Reason", objKernalPPT.Reason)


        Return objdb.ExecQuery("[Production].[KernalProductionStockInsert]", Parms)
    End Function
    Public Shared Function saveKernalLoadProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(13) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@LoadTankID", IIf(objKernalPPT.LoadTankID <> String.Empty, objKernalPPT.LoadTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@KernelStorageID", IIf(objKernalPPT.LoadTankID <> String.Empty, objKernalPPT.LoadTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objKernalPPT.LoadingLocationID <> String.Empty, objKernalPPT.LoadingLocationID, DBNull.Value))
        Parms(5) = New SqlParameter("@LoadQty", objKernalPPT.LoadQty)
        Parms(6) = New SqlParameter("@LoadMonthToDate", objKernalPPT.LoadMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)
        Parms(12) = New SqlParameter("@LoadRemarks", objKernalPPT.LoadRemarks)
        Parms(13) = New SqlParameter("@LoadTankID", DBNull.Value)

        Return objdb.ExecQuery("[Production].[KernalProductionLoadInsert]", Parms)
    End Function
    Public Shared Function UpdateKernalProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(10) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objKernalPPT.KernalDate)
        Parms(5) = New SqlParameter("@QtyToday", objKernalPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objKernalPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objKernalPPT.ProductionYear)
        'Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        'Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)

        Return objdb.ExecQuery("[Production].[KernalProductionUpdate]", Parms)
    End Function
    Public Shared Function UpdateKernalStockProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(20) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objKernalPPT.StockTankID <> String.Empty, objKernalPPT.StockTankID, DBNull.Value))
       
        Parms(4) = New SqlParameter("@Capacity", objKernalPPT.Capacity)
        Parms(5) = New SqlParameter("@BalanceBF", objKernalPPT.balance)
        Parms(6) = New SqlParameter("@CurrentReading", objKernalPPT.CurrentReading)
        Parms(7) = New SqlParameter("@Measurement", objKernalPPT.Measurement)
        Parms(8) = New SqlParameter("@Temp", objKernalPPT.Temparature)
        Parms(9) = New SqlParameter("@FFAP", objKernalPPT.FFA)
        Parms(10) = New SqlParameter("@MoistureP", objKernalPPT.Moisture)
        Parms(11) = New SqlParameter("@DirtP", objKernalPPT.Dirt)
        Parms(12) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(13) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(14) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(15) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(16) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)
        Parms(17) = New SqlParameter("@ProdStockID", objKernalPPT.ProdStockID)
        Parms(18) = New SqlParameter("@StockKernalID", IIf(objKernalPPT.StockKernalID <> String.Empty, objKernalPPT.StockKernalID, DBNull.Value))
        Parms(19) = New SqlParameter("@Writeoff", objKernalPPT.Writeoff)
        Parms(20) = New SqlParameter("@Reason", objKernalPPT.Reason)

        Return objdb.ExecQuery("[Production].[KernalProductionStockUpdate]", Parms)
    End Function
    Public Shared Function UpdateKernalLoadProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@LoadTankID", IIf(objKernalPPT.LoadTankID <> String.Empty, objKernalPPT.LoadTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@KernelStorageID", IIf(objKernalPPT.LoadTankID <> String.Empty, objKernalPPT.LoadTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objKernalPPT.LoadingLocationID <> String.Empty, objKernalPPT.LoadingLocationID, DBNull.Value))
        Parms(5) = New SqlParameter("@LoadQty", objKernalPPT.LoadQty)
        Parms(6) = New SqlParameter("@LoadMonthToDate", objKernalPPT.LoadMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)
        Parms(12) = New SqlParameter("@ProdLoadingID", objKernalPPT.ProdLoadingID)
        Parms(13) = New SqlParameter("@LoadRemarks", objKernalPPT.LoadRemarks)
        Parms(14) = New SqlParameter("@LoadTankID", DBNull.Value)


        Return objdb.ExecQuery("[Production].[KernalProductionLoadUpdate]", Parms)
    End Function
    Public Shared Function UpdateKernalTransProduction(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@TransTankID", IIf(objKernalPPT.TransTankID <> String.Empty, objKernalPPT.TransTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@KernelStorageID", IIf(objKernalPPT.TransTankID <> String.Empty, objKernalPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@TransQty", objKernalPPT.TransQty)
        Parms(5) = New SqlParameter("@TransMonthToDate", objKernalPPT.TransMonthToDate)
        
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@TransLocationID", IIf(objKernalPPT.TransLocationID <> String.Empty, objKernalPPT.TransLocationID, DBNull.Value))
        Parms(11) = New SqlParameter("@ProductionID", objKernalPPT.ProductionID)
        Parms(12) = New SqlParameter("@ProdTranshipID", objKernalPPT.ProdTranshipID)
        Parms(13) = New SqlParameter("@TransRemarks", objKernalPPT.TransRemarks)
        Parms(14) = New SqlParameter("@TransTankID", DBNull.Value)

        Return objdb.ExecQuery("[Production].[KernalProductionTransUpdate]", Parms)
    End Function
    Public Function GetKernalDetails(ByVal objKernalPPT As KernalProductionPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objKernalPPT.KernalDate <> Nothing, objKernalPPT.KernalDate, DBNull.Value))
        ' params(1) = New SqlParameter("@ProdStockID", IIf(objCPOPPT.ProdStockID <> "", objCPOPPT.ProdStockID, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        dt = objdb.ExecQuery("[Production].[KernelProductionSearch]", params).Tables(0)
        Return dt
    End Function
    Public Shared Function KernalDetailSelect(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@KernalStorageID", objKernalPPT.KernalID)
        Parms(1) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[KernalDetailSelect]", Parms)
    End Function
    Public Function Delete_KernalDetail(ByVal objKernalPPT As KernalProductionPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0


        Parms(0) = New SqlParameter("@CPOProductionDate", objKernalPPT.KernalDate)
        Parms(1) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)

        rowsAffected = objdb.ExecNonQuery("[Production].[KernalProductionDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function
    Public Shared Function UpdateTankMasterBFQty(ByVal objKernalPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(4) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(1) = New SqlParameter("@StockKernalID", IIf(objKernalPPT.StockTankID <> String.Empty, objKernalPPT.StockKernalID, DBNull.Value))
        ' Parms(2) = New SqlParameter("@CurrentReading", objKernalPPT.CurrentReading)
        Parms(1) = New SqlParameter("@CPODate", objKernalPPT.KernalDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernalPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(4) = New SqlParameter("@KernelStorageID", objKernalPPT.KernalID)
        Return objdb.ExecQuery("[Production].[KernelMasterBFUpdate]", Parms)
    End Function
    Public Shared Function KernelGetLoadVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(2) = New SqlParameter("@LoadLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@KernelStorageID", objCPOPPT.KernalID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(6) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Return objdb.ExecQuery("[Production].[KernelGetLoadVsLocMonthQty]", Parms)
    End Function
    Public Shared Function KernelGetTransVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(6) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(2) = New SqlParameter("@LoadLocationID", objCPOPPT.LoadingLocationID)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@KernelStorageID", objCPOPPT.KernalID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(6) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Return objdb.ExecQuery("[Production].[KernelGetTransVsLocMonthQty]", Parms)
    End Function


    ''Changed by kumar
    Public Shared Function loadCmbStorageBalanceBF(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.KernalDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@KernelStorageID", objCPOPPT.KernalID)
        Return objdb.ExecQuery("[Production].[KernelGetStorageBalanceBF]", Parms)
    End Function


    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.KernalDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@KernelStorageID", objCPOPPT.KernalID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[KernelGetLoadingCPOMonthtodate]", Parms)
    End Function

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.KernalDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@KernelStorageID", objCPOPPT.KernalID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[KernelGetTranshipCPOMonthtodate]", Parms)
    End Function

    Public Shared Function CPOProductionMonthYeartodate(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.KernalDate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOProductionMonthYeartodate]", Parms)
    End Function

    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As KernalProductionPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "Kernel")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function
    Public Function DuplicateDateCheck(ByVal objCPOPPT As KernalProductionPPT) As Object
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.KernalDate)
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

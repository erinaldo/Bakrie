Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class TransferKernelDAL


    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetStorage]", Parms)
    End Function
    Public Shared Function loadCmbKernalCodeDesc() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[KernelGetCodeDesc]", Parms)
    End Function
    Public Function EditDateCheck(ByVal objKernelPPT As TransferKernelPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[EditDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function SearchDateCheck(ByVal objKernelPPT As TransferKernelPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[LoadingSearchDateCheck]", Parms)

         Return objExists


    End Function

    Public Function DuplicateDateCheck(ByVal objKernelPPT As TransferKernelPPT) As Object


        'Dim objdb As New SQLHelp
        'Dim Parms(2) As SqlParameter
        'Dim objExists As Object
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        'Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        'objExists = objdb.ExecuteScalar("[Production].[CPODateIsExist]", Parms)
        'If objExists <> Nothing Then
        '    objExists = 0
        '    Return objExists
        'Else
        '    objExists = 1
        '    Return objExists
        'End If
        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[LoadingCPODateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function CompareCPOPLoadingDateIsExist(ByVal objKernelPPT As TransferKernelPPT) As Object


        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[CompareCPOPLoadingDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Shared Function GetProductionID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Return objdb.ExecQuery("[Production].[CPOGetProductionID]", Parms)
    End Function

    Public Shared Function GetTankID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objKernelPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Descp", objKernelPPT.Descp)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLocationID]", Parms)
    End Function

    Public Shared Function loadCmbLocation() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Type", "Transfer To KCP")
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocationKCP]", Parms)
    End Function

    Public Shared Function KernelGetLoadTransMonthQty(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        ' Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetLoadTransMonthQty]", Parms)
    End Function


    Public Shared Function GetCropYield(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objKernelPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetCropYieldID(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CropYieldCode", objKernelPPT.CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetCropYieldID]", Parms)
    End Function


    Public Shared Function GetKernelAddLoadInfo(ByVal objKernelPPT As TransferKernelPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(3) = New SqlParameter("@KernalDate", objKernelPPT.KernelDate)

        Return objdb.ExecQuery("[Production].[GetKernelLoadAddInfo]", Parms).Tables(0)
    End Function




    Public Shared Function saveKernelLoadProduction(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@StockTankID", IIf(objKernelPPT.StockTankID <> String.Empty, objKernelPPT.StockTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@LoadTankID", IIf(objKernelPPT.LoadTankID <> String.Empty, objKernelPPT.LoadTankID, DBNull.Value))
        Parms(5) = New SqlParameter("@LoadingLocationID", IIf(objKernelPPT.LoadingLocationID <> String.Empty, objKernelPPT.LoadingLocationID, DBNull.Value))
        Parms(6) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(7) = New SqlParameter("@LoadQty", objKernelPPT.LoadQty)
        Parms(8) = New SqlParameter("@LoadMonthToDate", objKernelPPT.LoadMonthToDate)
        Parms(9) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(11) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(12) = New SqlParameter("@ModifiedOn", Date.Today())
        ' Parms(13) = New SqlParameter("@ProductionID", objKernelPPT.ProductionID)
        Parms(13) = New SqlParameter("@LoadRemarks", objKernelPPT.LoadRemarks)
        Parms(14) = New SqlParameter("@LoadDate", objKernelPPT.KernelDate)
        ' Parms(15) = New SqlParameter("@BalanceBF", objKernelPPT.LoadBalanceBF)
        'Parms(28) = New SqlParameter("@TransLocationID", IIf(objKernelPPT.TransLocationID <> String.Empty, objKernelPPT.TransLocationID, DBNull.Value))
        Return objdb.ExecQuery("[Production].[CPOProductionLoadInsert]", Parms)
    End Function




    Public Shared Function UpdateKernelLoadProduction(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@StockTankID", IIf(objKernelPPT.StockTankID <> String.Empty, objKernelPPT.StockTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@LoadTankID", IIf(objKernelPPT.LoadTankID <> String.Empty, objKernelPPT.LoadTankID, DBNull.Value))
        'Parms(5) = New SqlParameter("@TransTankID", IIf(objKernelPPT.TransTankID <> String.Empty, objKernelPPT.TransTankID, DBNull.Value))
        'Parms(6) = New SqlParameter("@Capacity", objKernelPPT.Capacity)
        'Parms(7) = New SqlParameter("@BalanceBF", objKernelPPT.balance)
        'Parms(8) = New SqlParameter("@CurrentReading", objKernelPPT.CurrentReading)
        'Parms(9) = New SqlParameter("@Measurement", objKernelPPT.Measurement)
        'Parms(10) = New SqlParameter("@Temp", objKernelPPT.Temparature)
        'Parms(11) = New SqlParameter("@FFAP", objKernelPPT.FFA)
        'Parms(12) = New SqlParameter("@MoistureP", objKernelPPT.Moisture)
        'Parms(13) = New SqlParameter("@DirtP", objKernelPPT.Dirt)
        Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objKernelPPT.LoadingLocationID <> String.Empty, objKernelPPT.LoadingLocationID, DBNull.Value))
        'Parms(15) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        'Parms(16) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        'Parms(17) = New SqlParameter("@QtyToday", objKernelPPT.ProductionToday)
        'Parms(18) = New SqlParameter("@QtyMonthToDate", objKernelPPT.ProductionMonth)
        'Parms(19) = New SqlParameter("@QtyYearTodate", objKernelPPT.ProductionYear)
        'Parms(20) = New SqlParameter("@TransQty", objKernelPPT.TransQty)
        'Parms(21) = New SqlParameter("@TransMonthToDate", objKernelPPT.TransMonthToDate)
        Parms(5) = New SqlParameter("@LoadQty", objKernelPPT.LoadQty)
        Parms(6) = New SqlParameter("@LoadMonthToDate", objKernelPPT.LoadMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        'Parms(28) = New SqlParameter("@TransLocationID", IIf(objKernelPPT.TransLocationID <> String.Empty, objKernelPPT.TransLocationID, DBNull.Value))
        'Parms(11) = New SqlParameter("@ProductionID", objKernelPPT.ProductionID)
        Parms(11) = New SqlParameter("@ProdLoadingID", objKernelPPT.ProdLoadingID)
        Parms(12) = New SqlParameter("@LoadRemarks", objKernelPPT.LoadRemarks)
        'Parms(13) = New SqlParameter("@LoadDate", objKernelPPT.KernelDate)
        ' Parms(13) = New SqlParameter("@BalanceBF", objKernelPPT.LoadBalanceBF)
        Return objdb.ExecQuery("[Production].[CPOProductionLoadUpdate]", Parms)
    End Function

    Public Function GetKernelDetails(ByVal objKernelPPT As TransferKernelPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objKernelPPT.KernelDate <> Nothing, objKernelPPT.KernelDate, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        'params(3) = New SqlParameter("@TankNo", objKernelPPT.TankNo)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' params(4) = New SqlParameter("@TankNo", objKernelPPT.TankNo)

        dt = objdb.ExecQuery("[Production].[LoadingCPOSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_KernelDetail(ByVal objKernelPPT As TransferKernelPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim rowsAffected As Integer = 0

        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(0) = New SqlParameter("@ProductionID", objKernelPPT.ProductionID)
        'Parms(1) = New SqlParameter("@ProdStockID", objKernelPPT.ProdStockID)
        'Parms(2) = New SqlParameter("@ProdTranshipID", objKernelPPT.ProdTranshipID)
        'Parms(3) = New SqlParameter("@ProdLoadingID", objKernelPPT.ProdLoadingID)
        ' Parms(0) = New SqlParameter("@StockTankID", objKernelPPT.StockTankID)
        Parms(0) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        Parms(1) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)

        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionLoadDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function




    Public Shared Function KernelGetLoadingKernelMonthtodate(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objKernelPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objKernelPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetLoadingCPOMonthtodate]", Parms)
    End Function





    Public Shared Function ProductionCropYieldIDSelect(ByVal objKernelPPT As TransferKernelPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "Kernel")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function




    Public Function DeleteMultiEntryProdLoading(ByVal ObjKernelProductionPPT As TransferKernelPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProdLoadID", ObjKernelProductionPPT.ProdLoadingID)

        rowsAffected = objdb.ExecNonQuery("[Production].[LoadCPOMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function





End Class

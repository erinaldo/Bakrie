Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class TranshipmentKernelDAL

    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetStorage]", Parms)
    End Function

    Public Function DeleteMultiEntryProdTranship(ByVal ObjCPOProductionPPT As TranshipmentKernelPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Dim rowsAffected As Integer = 0

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProdTranshipID", ObjCPOProductionPPT.ProdTranshipID)

        rowsAffected = objdb.ExecNonQuery("[Production].[TranshipCPOMultiEntryDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If
        Return rowsAffected
    End Function

    Public Function EditDateCheck(ByVal objKernelPPT As TranshipmentKernelPPT) As Object

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

    Public Function TransSearchDateCheck(ByVal objKernelPPT As TranshipmentKernelPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[TransSearchDateCheck]", Parms)

        Return objExists


    End Function
    Public Function DuplicateDateCheck(ByVal objKernelPPT As TranshipmentKernelPPT) As Object
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

        objExists = objdb.ExecuteScalar("[Production].[TransCPODateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function CompareCPOPTransDateIsExist(ByVal objKernelPPT As TranshipmentKernelPPT) As Object
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

        objExists = objdb.ExecuteScalar("[Production].[CompareCPOPTransDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function


    Public Shared Function GetTankID(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objKernelPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
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
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocation]", Parms)
    End Function



    Public Shared Function KernelGetLoadTransMonthQty(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        ' Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetLoadTransMonthQty]", Parms)
    End Function


    Public Shared Function GetCropYield(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objKernelPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetCropYieldID(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CropYieldCode", objKernelPPT.CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetCropYieldID]", Parms)
    End Function


    Public Shared Function GetKernelAddTransInfo(ByVal objKernelPPT As TranshipmentKernelPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)

        Parms(3) = New SqlParameter("@CPODate", objKernelPPT.KernelDate)
        Return objdb.ExecQuery("[Production].[GetCPOAddTransInfo]", Parms).Tables(0)
    End Function
    Public Shared Function saveKernelProduction(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        Parms(5) = New SqlParameter("@QtyToday", objKernelPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objKernelPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objKernelPPT.ProductionYear)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Return objdb.ExecQuery("[Production].[CPOProductionInsert]", Parms)
    End Function
    Public Shared Function saveKernelTransProduction(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@TransTankID", IIf(objKernelPPT.TransTankID <> String.Empty, objKernelPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(5) = New SqlParameter("@TransQty", objKernelPPT.TransQty)
        Parms(6) = New SqlParameter("@TransMonthToDate", objKernelPPT.TransMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@TransLocationID", IIf(objKernelPPT.TransLocationID <> String.Empty, objKernelPPT.TransLocationID, DBNull.Value))
        Parms(12) = New SqlParameter("@ProductionID", objKernelPPT.ProductionID)
        Parms(13) = New SqlParameter("@TransRemarks", objKernelPPT.TransRemarks)
        Parms(14) = New SqlParameter("@TranshipDate", objKernelPPT.KernelDate)
        Return objdb.ExecQuery("[Production].[CPOProductionTransInsert]", Parms)
    End Function


    Public Shared Function UpdateKernelTransProduction(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@StockTankID", IIf(objKernelPPT.StockTankID <> String.Empty, objKernelPPT.StockTankID, DBNull.Value))
        'Parms(3) = New SqlParameter("@LoadTankID", IIf(objKernelPPT.LoadTankID <> String.Empty, objKernelPPT.LoadTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@TransTankID", IIf(objKernelPPT.TransTankID <> String.Empty, objKernelPPT.TransTankID, DBNull.Value))
        'Parms(6) = New SqlParameter("@Capacity", objKernelPPT.Capacity)
        'Parms(7) = New SqlParameter("@BalanceBF", objKernelPPT.balance)
        'Parms(8) = New SqlParameter("@CurrentReading", objKernelPPT.CurrentReading)
        'Parms(9) = New SqlParameter("@Measurement", objKernelPPT.Measurement)
        'Parms(10) = New SqlParameter("@Temp", objKernelPPT.Temparature)
        'Parms(11) = New SqlParameter("@FFAP", objKernelPPT.FFA)
        'Parms(12) = New SqlParameter("@MoistureP", objKernelPPT.Moisture)
        'Parms(13) = New SqlParameter("@DirtP", objKernelPPT.Dirt)
        'Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objKernelPPT.LoadingLocationID <> String.Empty, objKernelPPT.LoadingLocationID, DBNull.Value))
        'Parms(15) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        'Parms(16) = New SqlParameter("@CPOProductionDate", objKernelPPT.KernelDate)
        'Parms(17) = New SqlParameter("@QtyToday", objKernelPPT.ProductionToday)
        'Parms(18) = New SqlParameter("@QtyMonthToDate", objKernelPPT.ProductionMonth)
        'Parms(19) = New SqlParameter("@QtyYearTodate", objKernelPPT.ProductionYear)
        Parms(4) = New SqlParameter("@TransQty", objKernelPPT.TransQty)
        Parms(5) = New SqlParameter("@TransMonthToDate", objKernelPPT.TransMonthToDate)
        'Parms(5) = New SqlParameter("@LoadQty", objKernelPPT.LoadQty)
        'Parms(6) = New SqlParameter("@LoadMonthToDate", objKernelPPT.LoadMonthToDate)
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@TransLocationID", IIf(objKernelPPT.TransLocationID <> String.Empty, objKernelPPT.TransLocationID, DBNull.Value))
        ' Parms(11) = New SqlParameter("@ProductionID", objKernelPPT.ProductionID)
        Parms(11) = New SqlParameter("@ProdTranshipID", objKernelPPT.ProdTranshipID)
        Parms(12) = New SqlParameter("@TransRemarks", objKernelPPT.TransRemarks)
        Return objdb.ExecQuery("[Production].[CPOProductionTransUpdate]", Parms)
    End Function
    Public Function GetKernelDetails(ByVal objKernelPPT As TranshipmentKernelPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objKernelPPT.KernelDate <> Nothing, objKernelPPT.KernelDate, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        'params(3) = New SqlParameter("@TankNo", objKernelPPT.TankNo)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' params(4) = New SqlParameter("@TankNo", objKernelPPT.TankNo)

        dt = objdb.ExecQuery("[Production].[TranshipmentCPOSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_KernelDetail(ByVal objKernelPPT As TranshipmentKernelPPT) As Integer
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
        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionTransDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function




    Public Shared Function KernelGetTranshipKernelMonthtodate(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objKernelPPT.KernelDate)
        Parms(2) = New SqlParameter("@CropYieldID", objKernelPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objKernelPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objKernelPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetTranshipCPOMonthtodate]", Parms)
    End Function



    Public Shared Function ProductionCropYieldIDSelect(ByVal objKernelPPT As TranshipmentKernelPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "Kernel")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function



End Class

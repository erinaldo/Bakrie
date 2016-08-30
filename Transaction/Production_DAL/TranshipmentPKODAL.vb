Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient
Public Class TranshipmentPKODAL

    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetStorage]", Parms)
    End Function
    Public Function EditDateCheck(ByVal objPKOPPT As TranshipmentPKOPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objPKOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[EditDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function TransSearchDateCheck(ByVal objPKOPPT As TranshipmentPKOPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objPKOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[TransSearchDateCheck]", Parms)

         Return objExists

    End Function
    Public Function DeleteMultiEntryProdTranship(ByVal ObjCPOProductionPPT As TranshipmentPKOPPT) As Integer
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
    Public Function DuplicateDateCheck(ByVal objPKOPPT As TranshipmentPKOPPT) As Object
        'Dim objdb As New SQLHelp
        'Dim Parms(2) As SqlParameter
        'Dim objExists As Object
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@PKODate", objPKOPPT.PKODate)
        'Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

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
        Parms(1) = New SqlParameter("@CPODate", objPKOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[TransCPODateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function CompareCPOPTransDateIsExist(ByVal objPKOPPT As TranshipmentPKOPPT) As Object
        'Dim objdb As New SQLHelp
        'Dim Parms(2) As SqlParameter
        'Dim objExists As Object
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@PKODate", objPKOPPT.PKODate)
        'Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

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
        Parms(1) = New SqlParameter("@CPODate", objPKOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[CompareCPOPTransDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function


    Public Shared Function GetTankID(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objPKOPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Descp", objPKOPPT.Descp)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLocationID]", Parms)
    End Function

    Public Shared Function loadCmbLocation() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Type", "Transshipment")
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocation]", Parms)
    End Function

    Public Shared Function loadCmbLocationPKO() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Type", "Transshipment")
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocationPKO]", Parms)
    End Function

    Public Shared Function PKOGetLoadTransMonthQty(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objPKOPPT.PKODate)
        ' Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetLoadTransMonthQty]", Parms)
    End Function


    Public Shared Function GetCropYield(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objPKOPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetCropYieldID(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CropYieldCode", objPKOPPT.CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetCropYieldID]", Parms)
    End Function


    Public Shared Function GetPKOAddTransInfo(ByVal objPKOPPT As TranshipmentPKOPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)

        Parms(3) = New SqlParameter("@CPODate", objPKOPPT.PKODate)
        Return objdb.ExecQuery("[Production].[GetCPOAddTransInfo]", Parms).Tables(0)
    End Function
    Public Shared Function savePKOProduction(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objPKOPPT.PKODate)
        Parms(5) = New SqlParameter("@QtyToday", objPKOPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objPKOPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objPKOPPT.ProductionYear)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Return objdb.ExecQuery("[Production].[CPOProductionInsert]", Parms)
    End Function
    Public Shared Function savePKOTransProduction(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@TransTankID", IIf(objPKOPPT.TransTankID <> String.Empty, objPKOPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(5) = New SqlParameter("@TransQty", objPKOPPT.TransQty)
        Parms(6) = New SqlParameter("@TransMonthToDate", objPKOPPT.TransMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@TransLocationID", IIf(objPKOPPT.TransLocationID <> String.Empty, objPKOPPT.TransLocationID, DBNull.Value))
        Parms(12) = New SqlParameter("@ProductionID", objPKOPPT.ProductionID)
        Parms(13) = New SqlParameter("@TransRemarks", objPKOPPT.TransRemarks)
        Parms(14) = New SqlParameter("@TranshipDate", objPKOPPT.PKODate)
        Return objdb.ExecQuery("[Production].[CPOProductionTransInsert]", Parms)
    End Function


    Public Shared Function UpdatePKOTransProduction(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@StockTankID", IIf(objPKOPPT.StockTankID <> String.Empty, objPKOPPT.StockTankID, DBNull.Value))
        'Parms(3) = New SqlParameter("@LoadTankID", IIf(objPKOPPT.LoadTankID <> String.Empty, objPKOPPT.LoadTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@TransTankID", IIf(objPKOPPT.TransTankID <> String.Empty, objPKOPPT.TransTankID, DBNull.Value))
        'Parms(6) = New SqlParameter("@Capacity", objPKOPPT.Capacity)
        'Parms(7) = New SqlParameter("@BalanceBF", objPKOPPT.balance)
        'Parms(8) = New SqlParameter("@CurrentReading", objPKOPPT.CurrentReading)
        'Parms(9) = New SqlParameter("@Measurement", objPKOPPT.Measurement)
        'Parms(10) = New SqlParameter("@Temp", objPKOPPT.Temparature)
        'Parms(11) = New SqlParameter("@FFAP", objPKOPPT.FFA)
        'Parms(12) = New SqlParameter("@MoistureP", objPKOPPT.Moisture)
        'Parms(13) = New SqlParameter("@DirtP", objPKOPPT.Dirt)
        'Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objPKOPPT.LoadingLocationID <> String.Empty, objPKOPPT.LoadingLocationID, DBNull.Value))
        'Parms(15) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        'Parms(16) = New SqlParameter("@CPOProductionDate", objPKOPPT.PKODate)
        'Parms(17) = New SqlParameter("@QtyToday", objPKOPPT.ProductionToday)
        'Parms(18) = New SqlParameter("@QtyMonthToDate", objPKOPPT.ProductionMonth)
        'Parms(19) = New SqlParameter("@QtyYearTodate", objPKOPPT.ProductionYear)
        Parms(4) = New SqlParameter("@TransQty", objPKOPPT.TransQty)
        Parms(5) = New SqlParameter("@TransMonthToDate", objPKOPPT.TransMonthToDate)
        'Parms(5) = New SqlParameter("@LoadQty", objPKOPPT.LoadQty)
        'Parms(6) = New SqlParameter("@LoadMonthToDate", objPKOPPT.LoadMonthToDate)
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@TransLocationID", IIf(objPKOPPT.TransLocationID <> String.Empty, objPKOPPT.TransLocationID, DBNull.Value))
        ' Parms(11) = New SqlParameter("@ProductionID", objPKOPPT.ProductionID)
        Parms(11) = New SqlParameter("@ProdTranshipID", objPKOPPT.ProdTranshipID)
        Parms(12) = New SqlParameter("@TransRemarks", objPKOPPT.TransRemarks)
        Return objdb.ExecQuery("[Production].[CPOProductionTransUpdate]", Parms)
    End Function
    Public Function GetPKODetails(ByVal objPKOPPT As TranshipmentPKOPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objPKOPPT.PKODate <> Nothing, objPKOPPT.PKODate, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        'params(3) = New SqlParameter("@TankNo", objPKOPPT.TankNo)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' params(4) = New SqlParameter("@TankNo", objPKOPPT.TankNo)

        dt = objdb.ExecQuery("[Production].[TranshipmentCPOSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_PKODetail(ByVal objPKOPPT As TranshipmentPKOPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim rowsAffected As Integer = 0

        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(0) = New SqlParameter("@ProductionID", objPKOPPT.ProductionID)
        'Parms(1) = New SqlParameter("@ProdStockID", objPKOPPT.ProdStockID)
        'Parms(2) = New SqlParameter("@ProdTranshipID", objPKOPPT.ProdTranshipID)
        'Parms(3) = New SqlParameter("@ProdLoadingID", objPKOPPT.ProdLoadingID)
        ' Parms(0) = New SqlParameter("@StockTankID", objPKOPPT.StockTankID)
        Parms(0) = New SqlParameter("@CPOProductionDate", objPKOPPT.PKODate)
        Parms(1) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionTransDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function




    Public Shared Function PKOGetTranshipPKOMonthtodate(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objPKOPPT.PKODate)
        Parms(2) = New SqlParameter("@CropYieldID", objPKOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objPKOPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objPKOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetTranshipCPOMonthtodate]", Parms)
    End Function



    Public Shared Function ProductionCropYieldIDSelect(ByVal objPKOPPT As TranshipmentPKOPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "PKO")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function


End Class

Imports Production_PPT
Imports Common_DAL
Imports Common_PPT
Imports System.Data.SqlClient

Public Class TranshipmentCPODAL
    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetStorage]", Parms)
    End Function

    Public Function DeleteMultiEntryProdTranship(ByVal ObjCPOProductionPPT As TranshipmentCPOPPT) As Integer
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

    Public Function EditDateCheck(ByVal objCPOPPT As TranshipmentCPOPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[EditDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function TransSearchDateCheck(ByVal objCPOPPT As TranshipmentCPOPPT) As Object

        Dim objdb As New SQLHelp
        Dim Parms(2) As SqlParameter
        Dim objExists As Object
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[TransSearchDateCheck]", Parms)

        Return objExists


    End Function
    Public Function DuplicateDateCheck(ByVal objCPOPPT As TranshipmentCPOPPT) As Object
        'Dim objdb As New SQLHelp
        'Dim Parms(2) As SqlParameter
        'Dim objExists As Object
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        'Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

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
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[TransCPODateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

    Public Function CompareCPOPTransDateIsExist(ByVal objCPOPPT As TranshipmentCPOPPT) As Object
        'Dim objdb As New SQLHelp
        'Dim Parms(2) As SqlParameter
        'Dim objExists As Object
        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        'Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        'Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

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
        Parms(1) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        objExists = objdb.ExecuteScalar("[Production].[CompareCPOPTransDateIsExist]", Parms)

        If objExists <> Nothing Then
            objExists = 0
            Return objExists
        Else
            objExists = 1
            Return objExists
        End If


    End Function

   
    Public Shared Function GetTankID(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankNo", objCPOPPT.TankNo)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetTankID]", Parms)
    End Function
    Public Shared Function GetLocationID(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Descp", objCPOPPT.Descp)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetLocationID]", Parms)
    End Function

    Public Shared Function loadCmbLocation() As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@Type", "Transshipment")
        'Return objdb.ExecQuery("[Production].[CPOGetLoadingLocation]", Parms)
        Return objdb.ExecQuery("[Production].[CPOGetLoadingLocationCPO]", Parms)
    End Function
   
   
    
    Public Shared Function CPOGetLoadTransMonthQty(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        ' Parms(4) = New SqlParameter("@LoginYear", GlobalPPT.intLoginYear)

        Return objdb.ExecQuery("[Production].[CPOGetLoadTransMonthQty]", Parms)
    End Function

    
    Public Shared Function GetCropYield(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@TankID", objCPOPPT.TankID)
        'Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Return objdb.ExecQuery("[Production].[CPOGetCropYield]", Parms)
    End Function
    Public Shared Function GetCropYieldID(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(0) As SqlParameter
        Parms(0) = New SqlParameter("@CropYieldCode", objCPOPPT.CropYieldCode)
        Return objdb.ExecQuery("[Production].[CPOGetCropYieldID]", Parms)
    End Function

    Public Shared Function GetCPOAddTransInfo(ByVal objCPOPPT As TranshipmentCPOPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter

        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)

        Parms(3) = New SqlParameter("@CPODate", objCPOPPT.CPODate)
        Return objdb.ExecQuery("[Production].[GetCPOAddTransInfoCPO]", Parms).Tables(0)
    End Function
    Public Shared Function saveCPOProduction(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(11) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(4) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(5) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
        Parms(6) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
        Parms(7) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
        Parms(8) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(10) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(11) = New SqlParameter("@ModifiedOn", Date.Today())
        Return objdb.ExecQuery("[Production].[CPOProductionInsert]", Parms)
    End Function
    Public Shared Function saveCPOTransProduction(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(14) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        Parms(3) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
        Parms(4) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(5) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
        Parms(6) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
        Parms(7) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(8) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(9) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(10) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(11) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
        Parms(12) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(13) = New SqlParameter("@TransRemarks", objCPOPPT.TransRemarks)
        Parms(14) = New SqlParameter("@TranshipDate", objCPOPPT.CPODate)
        Return objdb.ExecQuery("[Production].[CPOProductionTransInsert]", Parms)
    End Function
   

    Public Shared Function UpdateCPOTransProduction(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(12) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(2) = New SqlParameter("@EstateCode", GlobalPPT.strEstateCode)
        'Parms(3) = New SqlParameter("@StockTankID", IIf(objCPOPPT.StockTankID <> String.Empty, objCPOPPT.StockTankID, DBNull.Value))
        'Parms(3) = New SqlParameter("@LoadTankID", IIf(objCPOPPT.LoadTankID <> String.Empty, objCPOPPT.LoadTankID, DBNull.Value))
        Parms(3) = New SqlParameter("@TransTankID", IIf(objCPOPPT.TransTankID <> String.Empty, objCPOPPT.TransTankID, DBNull.Value))
        'Parms(6) = New SqlParameter("@Capacity", objCPOPPT.Capacity)
        'Parms(7) = New SqlParameter("@BalanceBF", objCPOPPT.balance)
        'Parms(8) = New SqlParameter("@CurrentReading", objCPOPPT.CurrentReading)
        'Parms(9) = New SqlParameter("@Measurement", objCPOPPT.Measurement)
        'Parms(10) = New SqlParameter("@Temp", objCPOPPT.Temparature)
        'Parms(11) = New SqlParameter("@FFAP", objCPOPPT.FFA)
        'Parms(12) = New SqlParameter("@MoistureP", objCPOPPT.Moisture)
        'Parms(13) = New SqlParameter("@DirtP", objCPOPPT.Dirt)
        'Parms(4) = New SqlParameter("@LoadingLocationID", IIf(objCPOPPT.LoadingLocationID <> String.Empty, objCPOPPT.LoadingLocationID, DBNull.Value))
        'Parms(15) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        'Parms(16) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        'Parms(17) = New SqlParameter("@QtyToday", objCPOPPT.ProductionToday)
        'Parms(18) = New SqlParameter("@QtyMonthToDate", objCPOPPT.ProductionMonth)
        'Parms(19) = New SqlParameter("@QtyYearTodate", objCPOPPT.ProductionYear)
        Parms(4) = New SqlParameter("@TransQty", objCPOPPT.TransQty)
        Parms(5) = New SqlParameter("@TransMonthToDate", objCPOPPT.TransMonthToDate)
        'Parms(5) = New SqlParameter("@LoadQty", objCPOPPT.LoadQty)
        'Parms(6) = New SqlParameter("@LoadMonthToDate", objCPOPPT.LoadMonthToDate)
        Parms(6) = New SqlParameter("@CreatedBy", GlobalPPT.strUserName)
        Parms(7) = New SqlParameter("@CreatedOn", Date.Today())
        Parms(8) = New SqlParameter("@ModifiedBy", GlobalPPT.strUserName)
        Parms(9) = New SqlParameter("@ModifiedOn", Date.Today())
        Parms(10) = New SqlParameter("@TransLocationID", IIf(objCPOPPT.TransLocationID <> String.Empty, objCPOPPT.TransLocationID, DBNull.Value))
        ' Parms(11) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        Parms(11) = New SqlParameter("@ProdTranshipID", objCPOPPT.ProdTranshipID)
        Parms(12) = New SqlParameter("@TransRemarks", objCPOPPT.TransRemarks)
        Return objdb.ExecQuery("[Production].[CPOProductionTransUpdate]", Parms)
    End Function
    Public Function GetCPODetails(ByVal objCPOPPT As TranshipmentCPOPPT) As DataTable
        Dim objdb As New SQLHelp
        Dim params(3) As SqlParameter
        Dim dt As New DataTable

        params(0) = New SqlParameter("@CPODate", IIf(objCPOPPT.CPODate <> Nothing, objCPOPPT.CPODate, DBNull.Value))
        params(1) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        params(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        'params(3) = New SqlParameter("@TankNo", objCPOPPT.TankNo)
        params(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' params(4) = New SqlParameter("@TankNo", objCPOPPT.TankNo)

        dt = objdb.ExecQuery("[Production].[TranshipmentCPOSearch]", params).Tables(0)
        Return dt
    End Function
    Public Function Delete_CPODetail(ByVal objCPOPPT As TranshipmentCPOPPT) As Integer
        Dim objdb As New SQLHelp
        Dim Parms(3) As SqlParameter
        Dim rowsAffected As Integer = 0

        'Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        ' Parms(0) = New SqlParameter("@ProductionID", objCPOPPT.ProductionID)
        'Parms(1) = New SqlParameter("@ProdStockID", objCPOPPT.ProdStockID)
        'Parms(2) = New SqlParameter("@ProdTranshipID", objCPOPPT.ProdTranshipID)
        'Parms(3) = New SqlParameter("@ProdLoadingID", objCPOPPT.ProdLoadingID)
        ' Parms(0) = New SqlParameter("@StockTankID", objCPOPPT.StockTankID)
        Parms(0) = New SqlParameter("@CPOProductionDate", objCPOPPT.CPODate)
        Parms(1) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(2) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)
        Parms(3) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        rowsAffected = objdb.ExecNonQuery("[Production].[CPOProductionTransDelete]", Parms)

        If rowsAffected <= 0 Then
            Return rowsAffected
        End If

        Return rowsAffected
    End Function


    

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim objdb As New SQLHelp
        Dim Parms(5) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@ProductionDate", objCPOPPT.CPODate)
        Parms(2) = New SqlParameter("@CropYieldID", objCPOPPT.CropYieldID)
        Parms(3) = New SqlParameter("@TankID", objCPOPPT.TankID)
        Parms(4) = New SqlParameter("@LoadingLocationID", objCPOPPT.LoadingLocationID)
        Parms(5) = New SqlParameter("@ActiveMonthYearID", GlobalPPT.strActMthYearID)

        Return objdb.ExecQuery("[Production].[CPOGetTranshipCPOMonthtodate]", Parms)
    End Function

   

    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As TranshipmentCPOPPT) As DataSet
        Dim ds As New DataSet
        Dim objdb As New SQLHelp
        Dim Parms(1) As SqlParameter
        Parms(0) = New SqlParameter("@EstateID", GlobalPPT.strEstateID)
        Parms(1) = New SqlParameter("@CropYieldCode", "CPO")
        ds = objdb.ExecQuery("[Production].[ProductionCropYieldIDSelect]", Parms)
        Return ds
    End Function


End Class

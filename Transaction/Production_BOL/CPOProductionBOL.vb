Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
'Imports System.Data.SqlClient
Public Class CPOProductionBOL
    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return CPOProductionDAL.loadCmbStorage(CropYieldCode)
    End Function

    Public Shared Function GetTankID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.GetTankID(objCPOPPT)
    End Function
    Public Shared Function CPOGetLoadVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetLoadVsLocMonthQty(objCPOPPT)
    End Function
    Public Shared Function CPOGetTransVsLocMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetTransVsLocMonthQty(objCPOPPT)
    End Function
    Public Shared Function GetProductionID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.GetProductionID(objCPOPPT)
    End Function
    Public Function CalculateCurrentReading(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.CalculateCurrentReading(objCPOPPT)
    End Function
    Public Function DuplicateLoadTankCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateLoadTankCheck(objCPOPPT)
    End Function
    Public Function DuplicateTankFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateTankFirstCheck(objCPOPPT)
    End Function
    Public Function DuplicateLoadLocationFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateLoadLocationFirstCheck(objCPOPPT)
    End Function
    Public Function DuplicateKernelTransLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateKernelTransLocationCheck(objCPOPPT)
    End Function
    Public Function DuplicateKernelLoadLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateKernelLoadLocationCheck(objCPOPPT)
    End Function
    Public Function DuplicateTransLocationFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateTransLocationFirstCheck(objCPOPPT)
    End Function
    Public Function DuplicateStockTankCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateStockTankCheck(objCPOPPT)
    End Function
    Public Function DuplicateKernalCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateKernalCheck(objCPOPPT)
    End Function
    Public Function DuplicateKernalFirstCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateKernalFirstCheck(objCPOPPT)
    End Function
    Public Function DuplicateLoadLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateLoadLocationCheck(objCPOPPT)
    End Function
    Public Function DuplicateTransTankCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateTransTankCheck(objCPOPPT)
    End Function
    Public Function DuplicateTransLocationCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateTransLocationCheck(objCPOPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objCPOPPT As CPOProductionPPT) As Object
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.DuplicateDateCheck(objCPOPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.GetLocationID(objCPOPPT)
    End Function
    Public Shared Function tankDetailSelect(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.tankDetailSelect(objCPOPPT)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Return CPOProductionDAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.GetCropYield(objCPOPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.GetCropYieldID(objCPOPPT)
    End Function
    Public Shared Function GetCPOAddInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Return CPOProductionDAL.GetCPOAddInfo(objCPOPPT)
    End Function

    Public Shared Function GetCPOAddStockInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Return CPOProductionDAL.GetCPOAddStockInfo(objCPOPPT)
    End Function
    Public Shared Function GetCPOAddTransInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Return CPOProductionDAL.GetCPOAddTransInfo(objCPOPPT)
    End Function
    Public Shared Function GetCPOAddLoadInfo(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Return CPOProductionDAL.GetCPOAddLoadInfo(objCPOPPT)
    End Function
    Public Shared Function saveCPOLoadProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.saveCPOLoadProduction(objCPOPPT)
    End Function
    Public Shared Function saveCPOTransProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.saveCPOTransProduction(objCPOPPT)
    End Function
    Public Shared Function saveCPOProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.saveCPOProduction(objCPOPPT)
    End Function
    Public Shared Function saveCPOStockProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.saveCPOStockProduction(objCPOPPT)
    End Function
    Public Shared Function UpdateTankMasterBFQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.UpdateTankMasterBFQty(objCPOPPT)
    End Function
    Public Shared Function UpdateCPOStockProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.UpdateCPOStockProduction(objCPOPPT)
    End Function
    Public Shared Function UpdateCPOProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.UpdateCPOProduction(objCPOPPT)
    End Function
    Public Shared Function UpdateCPOLoadProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.UpdateCPOLoadProduction(objCPOPPT)
    End Function
    Public Shared Function UpdateCPOTransProduction(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.UpdateCPOTransProduction(objCPOPPT)
    End Function
    Public Shared Function GetCPODetails(ByVal objCPOPPT As CPOProductionPPT) As DataTable
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.GetCPODetails(objCPOPPT)
    End Function
    Public Function Delete_CPODetail(ByVal objCPOPPT As CPOProductionPPT) As Integer
        Dim objCPODAL As New CPOProductionDAL
        Return objCPODAL.Delete_CPODetail(objCPOPPT)
    End Function
    Public Shared Function CPOGetLoadMonthTodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetLoadMonthTodate(objCPOPPT)
    End Function
    Public Shared Function CPOGetTransMonthTodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetTransMonthTodate(objCPOPPT)
    End Function
    Public Shared Function CPOGetStockMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetStockMonthYearQty(objCPOPPT)
    End Function
    Public Shared Function CPOGetLoadMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetLoadMonthYearQty(objCPOPPT)
    End Function
    Public Shared Function CPOGetTransMonthYearQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetTransMonthYearQty(objCPOPPT)
    End Function
    Public Shared Function CPOGetLoadTransMonthQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetLoadTransMonthQty(objCPOPPT)
    End Function

    Public Shared Function CPOGetTodayQty(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetTodayQty(objCPOPPT)
    End Function

    ''Changed by kumar
    Public Shared Function loadCmbStorageBalanceBF(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.loadCmbStorageBalanceBF(objCPOPPT)
    End Function

    ''Changed by kumar
    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetLoadingCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function CPOGetTranshipCPOMonthtodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOGetTranshipCPOMonthtodate(objCPOPPT)
    End Function

    Public Shared Function CPOProductionMonthYeartodate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOProductionMonthYeartodate(objCPOPPT)
    End Function
    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.ProductionCropYieldIDSelect(objCPOPPT)
    End Function


    Public Shared Function DeleteMultiEntryProdStock(ByVal objCPOPPT As CPOProductionPPT) As Integer
        Dim ObjCPOProductionDAL As New CPOProductionDAL
        Return ObjCPOProductionDAL.DeleteMultiEntryProdStock(objCPOPPT)
    End Function

    Public Shared Function DeleteMultiEntryProdLoading(ByVal objCPOPPT As CPOProductionPPT) As Integer
        Dim ObjCPOProductionDAL As New CPOProductionDAL
        Return ObjCPOProductionDAL.DeleteMultiEntryProdLoading(objCPOPPT)
    End Function

    Public Shared Function DeleteMultiEntryProdTranship(ByVal objCPOPPT As CPOProductionPPT) As Integer
        Dim ObjCPOProductionDAL As New CPOProductionDAL
        Return ObjCPOProductionDAL.DeleteMultiEntryProdTranship(objCPOPPT)
    End Function

    Public Shared Function CPOProductionTranshipqtySelect(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Dim ObjCPOProductionDAL As New CPOProductionDAL
        Return ObjCPOProductionDAL.CPOProductionTranshipqtySelect(objCPOPPT)
    End Function

    Public Shared Function CPOProdLoadInsert(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOProdLoadInsert(objCPOPPT)
    End Function

    Public Shared Function CPOProdLoadupdate(ByVal objCPOPPT As CPOProductionPPT) As DataSet
        Return CPOProductionDAL.CPOProdLoadUpdate(objCPOPPT)
    End Function


End Class

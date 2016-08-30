Imports Production_BOL
Imports Production_DAL
Imports Production_PPT
Public Class LoadingPKOBOL
    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return LoadingPKODAL.loadCmbStorage(CropYieldCode)
    End Function

    Public Shared Function GetTankID(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.GetTankID(objPKOPPT)
    End Function

    Public Shared Function GetProductionID(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.GetProductionID(objPKOPPT)
    End Function
    Public Function EditDateCheck(ByVal objPKOPPT As LoadingPKOPPT) As Object
        Dim objPKODAL As New LoadingPKODAL
        Return objPKODAL.EditDateCheck(objPKOPPT)
    End Function

    Public Function SearchDateCheck(ByVal objPKOPPT As LoadingPKOPPT) As Object
        Dim objPKODAL As New LoadingPKODAL
        Return objPKODAL.SearchDateCheck(objPKOPPT)
    End Function

    Public Function DuplicateDateCheck(ByVal objPKOPPT As LoadingPKOPPT) As Object
        Dim objPKODAL As New LoadingPKODAL
        Return objPKODAL.DuplicateDateCheck(objPKOPPT)
    End Function
    Public Function CompareCPOPLoadingDateIsExist(ByVal objPKOPPT As LoadingPKOPPT) As Object
        Dim objPKODAL As New LoadingPKODAL
        Return objPKODAL.CompareCPOPLoadingDateIsExist(objPKOPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.GetLocationID(objPKOPPT)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Return LoadingPKODAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.GetCropYield(objPKOPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.GetCropYieldID(objPKOPPT)
    End Function
    Public Shared Function GetPKOAddLoadInfo(ByVal objPKOPPT As LoadingPKOPPT) As DataTable
        Return LoadingPKODAL.GetPKOAddLoadInfo(objPKOPPT)
    End Function
    Public Shared Function savePKOLoadProduction(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.savePKOLoadProduction(objPKOPPT)
    End Function

    Public Shared Function UpdatePKOLoadProduction(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.UpdatePKOLoadProduction(objPKOPPT)
    End Function

    Public Shared Function GetPKODetails(ByVal objPKOPPT As LoadingPKOPPT) As DataTable
        Dim objPKODAL As New LoadingPKODAL
        Return objPKODAL.GetPKODetails(objPKOPPT)
    End Function
    Public Function Delete_PKODetail(ByVal objPKOPPT As LoadingPKOPPT) As Integer
        Dim objPKODAL As New LoadingPKODAL
        Return objPKODAL.Delete_PKODetail(objPKOPPT)
    End Function

    Public Shared Function PKOGetLoadTransMonthQty(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.PKOGetLoadTransMonthQty(objPKOPPT)
    End Function

    Public Shared Function PKOGetLoadingPKOMonthtodate(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.PKOGetLoadingPKOMonthtodate(objPKOPPT)
    End Function
    Public Shared Function ProductionCropYieldIDSelect(ByVal objPKOPPT As LoadingPKOPPT) As DataSet
        Return LoadingPKODAL.ProductionCropYieldIDSelect(objPKOPPT)
    End Function

    Public Shared Function DeleteMultiEntryProdLoading(ByVal objPKOPPT As LoadingPKOPPT) As Integer
        Dim ObjPKOProductionDAL As New LoadingPKODAL
        Return ObjPKOProductionDAL.DeleteMultiEntryProdLoading(objPKOPPT)
    End Function

End Class

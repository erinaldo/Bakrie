Imports Production_BOL
Imports Production_DAL
Imports Production_PPT

Public Class LoadingCPOBOL
    Public Shared Function loadCmbStorage(ByVal CropYieldCode As String) As DataSet
        Return LoadingCPODAL.loadCmbStorage(CropYieldCode)
    End Function

    Public Shared Function GetTankID(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.GetTankID(objCPOPPT)
    End Function

    Public Shared Function GetProductionID(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.GetProductionID(objCPOPPT)
    End Function
    Public Function DuplicateDateCheck(ByVal objCPOPPT As LoadingCPOPPT) As Object
        Dim objCPODAL As New LoadingCPODAL
        Return objCPODAL.DuplicateDateCheck(objCPOPPT)
    End Function
    Public Function CompareCPOPLoadingDateIsExist(ByVal objCPOPPT As LoadingCPOPPT) As Object
        Dim objCPODAL As New LoadingCPODAL
        Return objCPODAL.CompareCPOPLoadingDateIsExist(objCPOPPT)
    End Function
    Public Function EditDateCheck(ByVal objCPOPPT As LoadingCPOPPT) As Object
        Dim objCPODAL As New LoadingCPODAL
        Return objCPODAL.EditDateCheck(objCPOPPT)
    End Function

    Public Function SearchDateCheck(ByVal objCPOPPT As LoadingCPOPPT) As Object
        Dim objCPODAL As New LoadingCPODAL
        Return objCPODAL.SearchDateCheck(objCPOPPT)
    End Function
    Public Shared Function GetLocationID(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.GetLocationID(objCPOPPT)
    End Function
    Public Shared Function loadCmbLocation() As DataSet
        Return LoadingCPODAL.loadCmbLocation()
    End Function
    Public Shared Function GetCropYield(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.GetCropYield(objCPOPPT)
    End Function
    Public Shared Function GetCropYieldID(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.GetCropYieldID(objCPOPPT)
    End Function
    Public Shared Function GetCPOAddLoadInfo(ByVal objCPOPPT As LoadingCPOPPT) As DataTable
        Return LoadingCPODAL.GetCPOAddLoadInfo(objCPOPPT)
    End Function
    Public Shared Function saveCPOLoadProduction(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.saveCPOLoadProduction(objCPOPPT)
    End Function

    Public Shared Function UpdateCPOLoadProduction(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.UpdateCPOLoadProduction(objCPOPPT)
    End Function

    Public Shared Function GetCPODetails(ByVal objCPOPPT As LoadingCPOPPT) As DataTable
        Dim objCPODAL As New LoadingCPODAL
        Return objCPODAL.GetCPODetails(objCPOPPT)
    End Function

    Public Function Delete_CPODetail(ByVal objCPOPPT As LoadingCPOPPT) As Integer
        Dim objCPODAL As New LoadingCPODAL
        Return objCPODAL.Delete_CPODetail(objCPOPPT)
    End Function

    Public Shared Function CPOGetLoadTransMonthQty(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.CPOGetLoadTransMonthQty(objCPOPPT)
    End Function

    Public Shared Function CPOGetLoadingCPOMonthtodate(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.CPOGetLoadingCPOMonthtodate(objCPOPPT)
    End Function
    Public Shared Function ProductionCropYieldIDSelect(ByVal objCPOPPT As LoadingCPOPPT) As DataSet
        Return LoadingCPODAL.ProductionCropYieldIDSelect(objCPOPPT)
    End Function

    Public Shared Function DeleteMultiEntryProdLoading(ByVal objCPOPPT As LoadingCPOPPT) As Integer
        Dim ObjCPOProductionDAL As New LoadingCPODAL
        Return ObjCPOProductionDAL.DeleteMultiEntryProdLoading(objCPOPPT)
    End Function

End Class
